using System;
using Nancy.ModelBinding;

namespace TinyJson.Tests.ConsoleServer
{
    public class MainModule : Nancy.NancyModule
    {
        public MainModule()
        {
            Get["/"] = x =>
                           {
                               return "{\"Statuscode\" : \"200\"," +
                                       "\"Location\" : \"123456\"}";
                           };

            Post["/"] = x =>
                            {
                                user request = this.Bind();

                                return "{\"Statuscode\" : \"200\"," +
                                   "\"Location\" : \"Your Username is: " + request.username + "\"}";
                            };

            Post["/string"] = x => 
                            {
                                string stringrequest = this.Bind().ToString();
                                return "{\"Statuscode\" : \"200\"," + "\"Location\" : \"Request: " + stringrequest + "\"}";
                            };
        }
    }

    public class user
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}