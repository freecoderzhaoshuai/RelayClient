using Microsoft.Azure.Relay;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HybridConnectionClient client = new HybridConnectionClient("Endpoint=sb://relayzs.servicebus.windows.net/;SharedAccessKeyName=sas;SharedAccessKey=WBhKG1Fb51sYz4I1Nsv/mZsLhnru+O08YQxeq+SyRfo=;EntityPath=hybirdconn1");
            Task<HybridConnectionStream> task= client.CreateConnectionAsync();
            while (!task.IsCompleted) { }
            HybridConnectionStream stream = task.Result;
            StreamWriter writer = new StreamWriter(stream);
            StreamReader reader = new StreamReader(stream);
            writer.WriteLine("Hello Server!");
            writer.Flush();
            String line =reader.ReadLine();
            Console.WriteLine(line);
            reader.Close();
            writer.Close();
        }
    }
}
