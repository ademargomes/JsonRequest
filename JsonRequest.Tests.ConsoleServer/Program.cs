using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonRequest.Tests.ConsoleServer
{
    /// <summary>
    /// This Class was created so its possible to test the library against a real server.
    /// For this it is using nancy micro framework. More information about please visit
    /// http://www.nancyfx.org/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var nancyHost = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:1234"));
            nancyHost.Start();

            Console.ReadLine();
            nancyHost.Stop();
        }
    }
}
