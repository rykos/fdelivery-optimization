using System;
using System.Linq;
using System.ServiceProcess;

namespace fdelivery_optimization
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();
            ServiceController deliveryOptimization = scServices.FirstOrDefault(s => s.DisplayName == "Delivery Optimization");
            if (deliveryOptimization == default)
            {
                Console.WriteLine("'Delivery Optimization' service could not be found");
                Console.ReadKey();
            }
            else
            {
                StopService(deliveryOptimization);
            }
        }

        static void StopService(ServiceController service)
        {
            Console.WriteLine("'Delivery Optimization' stopper activated");
            while (true)
            {
                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    Console.WriteLine("update stopped");
                }
                service.WaitForStatus(ServiceControllerStatus.Running);
            }
        }
    }
}
