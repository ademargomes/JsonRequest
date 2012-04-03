JsonRequest
=========================================================================

**JsonRequest provides a simple way to make Json http requests.** Great to use against REST APIs.
It is ready to serialize/deserialize Json and bind it with your classes or into simple strings.

I wrote it to help me avoid a lot of code repetition when it is necessary interacting a lot with Rest APIs.

The library is in a very early stage but has got json deserializer/serializer, basic authentication and a basic way of handling cookies. 

Thanks to @thebigal for the valuable inputs on tests and good ideas on how to enhance it. 

**Please read LICENSE.md**

In case you find any problem please let me know, I am happy to hear from you and try to find the solution as quick as possible. 
Leave a comment or get in touch on Twitter : @ademarsgomes

How To Use It?
------------------
Build the project and copy JsonRequest.dll, Newtonsoft.Json.dll and Newtonsoft.Json.xml to your bin folder, then create the reference for JsonRequest.dll. 
You can also download the binaries from the [Download Page] here on GitHub, and simple drop the files in the bin folder under your project folder.

Then simple type:

    var request = new Request();
    var response = request.Execute("http://localhost:1234/");

In the above case, the variable response would be the following valid Json string:

`{"Statuscode" : "200","Location" : "123456"}`

(**NOTE: This example is in the test project, which also has a little http server in order to facilitate the tests. Read more about it on test section**)

The example bellow shows how to deserialize the same Json into an object.
Given the class:

    public class httpresponse
        { 
            public int Statuscode { get; set; }
            public string Location { get; set; }
        }


You would write the call like:


    var response = (httpresponse)request.Execute<httpresponse>("http://localhost:1234/");


To create a post request and inform a object to be serialized:

			var request = new Request();
            var user = new User {username = "Bob",password = "password"};

            var response = (Httpresponse)request.Execute<Httpresponse>("http://localhost:1234/",user,"POST");
			
To create a post request pass a string:

			var request = new Request();
            var user = "your json string here";

            var response = (Httpresponse)request.Execute<Httpresponse>("http://localhost:1234/",user,"POST");


Basic Authentication
------------------

Though I believe most of the API's out there use OAuth or digest authentications, some requires basic authenctication. In order to  use it you should only pass user name and password to the Credentials property of the request:

			request.Credentials.UserName
            request.Credentials.Password	
			
That is it, the request will then pass the encoded credentials to the server. **Basic authentication is a not a secure way of transfering data over HTTP.**


Cookies
------------------
Request is prepared to store cookies. Once a server sends back a cookie it is stored and while using the same object, the cookie is sent back to the server in the next requests. In case keeping the same Request object is a problem, its possible to store request.CookieContainer and pass it to the next Request object.
			
Test projects
------------------
The test projects are there to show how to use the library.
Because the purpose of JsonRequest is to interact with http servers, I created a little one with very basic functionality in order to demonstrate how it works. For that I used the great **micro framework Nancy**. More about Nancy [here].

Before you run the tests, you should first run the server. To do that, go to **\JsonRequest\JsonRequest.Tests.ConsoleServer\bin\Release** and execute **JsonRequest.Tests.ConsoleServer.exe**.


After the command windows is up and running, you can go to the project **JsonRequest.Tests**.
There are 3 classes, a unit test one, with very basic tests for the internal functionalities.
Then there is JsonRequestTwitterTests.cs that contains a little example on how to connect with ***Twitter*** in few lines and perform a search showing result in the test command window.

And then, there is JsonRequestTests with different tests against the internal little server.


Dependencies
------------------

JsonRequest uses the very good Json serializer Newtonsoft.Json. [More about it here].


[here]: http://nancyfx.org/
[More about it here]: http://james.newtonking.com/
[Download Page]: https://github.com/ademargomes/JsonRequest/downloads