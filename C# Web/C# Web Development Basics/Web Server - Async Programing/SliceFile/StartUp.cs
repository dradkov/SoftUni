namespace SliceFile
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class StartUp
    {

        public static void Main(string[] args)
        {
            string videoPath = Console.ReadLine();
            string destination = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            SliveAsync(videoPath, destination, pieces);
        }

        private static void SliveAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() =>
           {
               Slice(sourceFile, destinationPath, parts);
           });
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (FileStream source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);

                long partLen = (sourceFile.Length / parts) + 1;
                long currentByte = 0;


                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    string filePAth = string.Format($"{0}/Part-{1}{2}", destinationPath, currentPart, fileInfo.Extension);

                    using (FileStream destination = new FileStream(filePAth, FileMode.Create))
                    {
                        byte[] buffer = new byte[Int32.MaxValue];

                        while (currentByte <= partLen * currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }

                }

                Console.WriteLine("Slice Complete!");


            }

        }
    }
}
