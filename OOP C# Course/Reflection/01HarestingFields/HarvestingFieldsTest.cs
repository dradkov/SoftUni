namespace _01HarestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
      public  static void Main(string[] args)
        {
            var type = typeof(HarvestingFields);

             
            var allFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic );


            string inputInfo;

            while ((inputInfo = Console.ReadLine()) != "HARVEST")
            {



                if (inputInfo == "private")
                {
                    foreach (var field in allFields)
                    {
                        if (field.IsPrivate)
                        {
                            Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                        }
                     
                    }
                }


                else if (inputInfo == "public")
                {
                    foreach (var field in allFields)
                    {
                        if (field.IsPublic)
                        {
                            Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                        }

                    }
                }
                else if (inputInfo == "protected")
                {
                    foreach (var field in allFields)
                    {
                        if (!field.IsPublic && !field.IsPrivate )
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }

                    }
                }
                else if(inputInfo == "all")
                {
                    foreach (var field in allFields)
                    {
                        if (!field.IsPublic && !field.IsPrivate)
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                        else if (field.IsPublic)
                        {
                            Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                        }
                        else if (field.IsPrivate)
                        {
                            Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                        }

                    }
                }


            }
        }
    }
}
