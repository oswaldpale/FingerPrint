using Digital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D

namespace DigitalPersonaSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            #if DEBUG
                        Bio _service = new Bio();
                        _service.OnDebug();
                        System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            #else
                                    ServiceBase[] ServicesToRun;
                                    ServicesToRun = new ServiceBase[]
                                    {
                                        new BiometricPersonal()
                                    };
                                    ServiceBase.Run(ServicesToRun);
            #endif
        }
    }
}
