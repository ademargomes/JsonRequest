using System;
using NUnit.Framework;

namespace JsonRequest.Tests
{
    [TestFixture]
    public class JsonRequestUnitTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public static void ShouldThrowExceptionWhenUrlIsNullConstructorOne()
        {
            var request = new Request();
            var response = request.Execute();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public static void ShouldThrowExceptionWhenUrlIsNullConstructorTwo()
        {
            var request = new Request();
            var response = request.Execute<string>();
        }
    }
}