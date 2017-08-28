namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<string>> departmantLog = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctorLog = new Dictionary<string, List<string>>();

            string departmantInfo;

            while ((departmantInfo = Console.ReadLine()) != "Output")
            {
                string[] splitInfo = departmantInfo
                    .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                string departmant = splitInfo[0];
                string doctorName = splitInfo[1] + " " + splitInfo[2];
                string patientName = splitInfo[3];

                if (!departmantLog.ContainsKey(departmant))
                {
                    departmantLog.Add(departmant, new List<string>());
                }
                if (!doctorLog.ContainsKey(doctorName))
                {
                    doctorLog.Add(doctorName, new List<string>());
                }
                if (departmantLog[departmant].Count <= 60)
                {
                    departmantLog[departmant].Add(patientName);
                }
                doctorLog[doctorName].Add(patientName);

            }

            while ((departmantInfo = Console.ReadLine()) != "End")
            {

                string[] splitInfo = departmantInfo.Trim()
                    .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                if (splitInfo.Length > 1)
                {
                    if (splitInfo[0] == "Cardiology" || splitInfo[0] == "Oncology" || splitInfo[0] == "Emergency")
                    {
                        int roomNumber = int.Parse(splitInfo[1]);

                        string[] result = departmantLog[splitInfo[0].Trim()].Skip((roomNumber * 3) - 3).Take(3).OrderBy(x => x).ToArray();

                        foreach (var name in result)
                        {
                            Console.WriteLine(name);
                        }

                    }
                    else
                    {

                        string[] result = doctorLog[departmantInfo.Trim()].OrderBy(x => x).ToArray();

                        foreach (var name in result)
                        {
                            Console.WriteLine(name);
                        }
                    }
                }
                else
                {

                    foreach (var patients in departmantLog[departmantInfo])
                    {
                        Console.WriteLine(patients);
                    }

                }
            }
        }
    }
}
