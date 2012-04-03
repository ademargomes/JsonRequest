using System;
using NUnit.Framework;

namespace JsonRequest.Tests
{
    [TestFixture]
    public class JsonRequestTests
    {
        [Test]
        public void ShouldDeserializeJsonToObject()
        {
            var request = new Request();
            request.Verb = "GET";
            request.URL = "http://localhost:1234/";

            var response = (Httpresponse)request.Execute<Httpresponse>();

            Console.WriteLine(response.Statuscode);
            Console.WriteLine(response.Location);

            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Statuscode.ToString());
            Assert.AreEqual(200,response.Statuscode);
        }

        [Test]
        public void ShouldDeserializeJsonToObjectFromConstructor()
        {
            var request = new Request("http://localhost:1234/","GET");
            var response = (Httpresponse)request.Execute<Httpresponse>();

            Console.WriteLine(response.Statuscode);
            Console.WriteLine(response.Location);

            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Statuscode.ToString());
            Assert.AreEqual(200, response.Statuscode);
        }

        [Test]
        public void ShouldDeserializeJsonToString()
        {
            var request = new Request();
            request.Verb = "GET";
            request.URL = "http://localhost:1234/";

            var response = request.Execute();

            Console.WriteLine(response);

            Assert.IsNotNull(response);
            Assert.IsNotEmpty((string) response);
        }

        [Test]
        public void ShouldReceiveJsonToString()
        {
            var request = new Request();
            request.Verb = "GET";

            var response = request.Execute("http://localhost:1234/");

            Console.WriteLine(response);

            Assert.IsNotNull(response);
            Assert.IsNotEmpty((string)response);
        }

        [Test]
        public void ShouldDeserializePostJsonToObject()
        {
            var request = new Request();
            var user = new User {username = "Bob",password = "password"};

            var response = (Httpresponse)request.Execute<Httpresponse>("http://localhost:1234/",user,"POST");

            Console.WriteLine(response.Statuscode);
            Console.WriteLine(response.Location);

            Assert.IsNotNull(response);
        }

        [Test]
        public void Should_send_string_and_respond_string()
        {
            var request = new Request();

            var response = request.Execute("http://localhost:1234/string", "test", "POST");

            Console.WriteLine(response);
            Assert.IsNotNull(response);
        }

        [Test]
        public void ShouldDeserializePostJsonToString()
        {
            var request = new Request();

            var user = new User { username = "Bob", password = "password" };

            var response = request.Execute("http://localhost:1234/",user,"POST");

            Console.WriteLine(response);

            Assert.IsNotNull(response);
            Assert.IsNotEmpty((string)response);
        }

    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class Httpresponse
    {
        public int Statuscode { get; set; }
        public string Location { get; set; }
    }
}
