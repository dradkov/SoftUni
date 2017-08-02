using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string name, params string[] fieldsName)
    {
        var type = Type.GetType(name);

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);


        var findFields = fields.Where(f => fieldsName.Contains(f.Name));

        var sb = new StringBuilder();

        Object instance = Activator.CreateInstance(type, new object[] { });

        sb.AppendLine($"Class under investigation: {type}");


        foreach (var field in findFields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
        }

        return sb.ToString().Trim();


    }
    public string AnalyzeAcessModifiers(string className)
    {
        var type = Type.GetType(className);

        var classfields = type.GetFields(BindingFlags.Instance| BindingFlags.Static | BindingFlags.Public );
        var classpublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public );
        var classnonpublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
      


        var sb = new StringBuilder();

        foreach (var field in classfields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var publicMethod in classnonpublicMethods.Where(p=>p.Name.StartsWith("get")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be public!");
        }
        foreach (var nonPublic in classpublicMethods.Where(p=>p.Name.StartsWith("set")))
        {
            sb.AppendLine($"{nonPublic.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var type = Type.GetType(className);

        var classMethods = type.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic);

        var sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {type}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");


        foreach (var method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        var type = Type.GetType(className);

        var classMethods = 
            type.GetMethods(BindingFlags.Instance |BindingFlags.NonPublic| BindingFlags.Public);

        var sb = new StringBuilder();
        foreach (var method in classMethods.Where(f=>f.Name.StartsWith("get")))
        {         
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
         
        }
        foreach (var method in classMethods.Where(f => f.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");

        }






        return sb.ToString().Trim();
    }
}

