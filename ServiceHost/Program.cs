using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StocksTracker.WCFService;
using System.ServiceModel.Description;
using System.Threading;

namespace ServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(10000);
            Uri baseAddress = new Uri("http://localhost:8733/service");


            // Create the ServiceHost.
            using (System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(Service1), baseAddress))
            {
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();
                IService1 service1 = new Service1();
                service1.GetData();
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }

        }
    }
}
