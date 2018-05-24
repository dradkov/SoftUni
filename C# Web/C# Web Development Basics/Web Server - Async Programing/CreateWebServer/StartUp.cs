namespace CreateWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            int port = 1337;
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            TcpListener tcpListener = new TcpListener(ipAddress, port);

            tcpListener.Start();

            Task
                .Run(async () => await Connect(tcpListener))
                .GetAwaiter()
                .GetResult();
        }
        public static async Task Connect(TcpListener listener)
        {
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                var buffer = new byte[1024];

                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                string clientMsg = Encoding.UTF8.GetString(buffer);


                string responseMsg = "HTTP/1.1 200 OK\nContent-Type: text/plain\n\nHello from server";

                var data = Encoding.UTF8.GetBytes(responseMsg);
                await client.GetStream().WriteAsync(data, 0, data.Length);

                Console.WriteLine(clientMsg);

                client.Dispose();
            }
        }
    }
}
