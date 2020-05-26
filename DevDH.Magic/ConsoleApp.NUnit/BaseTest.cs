using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using DevDH.Magic.Abstractions;

namespace ConsoleApp.NUnit
{
    public class BaseTest
    {
        protected void SimpleAssert(bool is_valid, string message = null)
        {
            Assert.True(is_valid, message);
        }

        protected void SimpleAssertRequest(RequestResult requestResult)
        {
            SimpleAssert(requestResult.IsValid, requestResult.Message);
        }

        protected void SimpleAssertRequest<T>(RequestResult<T> requestResult) where T : class
        {
            SimpleAssert(requestResult.IsValid, requestResult.Message);
        }
    }
}
