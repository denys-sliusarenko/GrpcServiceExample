using Grpc.Net.Client;
using GrpcServiceExample;
using System;
using System.Threading.Tasks;

namespace ClientGrpc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            Console.Write("Input name: ");
            string name = Console.ReadLine();
            var reply = await client.SayHelloAsync(new HelloRequest { Name = name });
            Console.WriteLine("Response:  " + reply.Message);
            Console.ReadKey();

            Console.Write("Input a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Input b: ");
            int b = int.Parse(Console.ReadLine());

            var result = await client.AddAsync(new AddRequest { A = a, B = b });
            Console.WriteLine("Summary:  " + result.Summary);
            Console.ReadKey();
        }
    }
}
