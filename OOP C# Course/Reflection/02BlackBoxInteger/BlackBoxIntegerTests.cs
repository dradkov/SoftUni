using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace _02BlackBoxInteger
{
    using System;

    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {

            var type = typeof(BlackBoxInt);

            BlackBoxInt box = (BlackBoxInt) Activator.CreateInstance(type,true); // Return Default ctor

            //ConstructorInfo ctroBox = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,Type.DefaultBinder,new Type[]{},null );


            string inputInfo;

            while ((inputInfo = Console.ReadLine()) != "END")
            {
                var split = inputInfo.Split('_');
                var command = split[0];
                var intParam = int.Parse(split[1]);

                var method = type.GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic).Invoke(box, new object[] { intParam });

   
                var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First().GetValue(box);


                Console.WriteLine(field);
              
            }
        }

    }










    //foreach (var method in methods)
    //{
    //    if (method.Name == "Add")
    //    {

    //    }
    //}







}
