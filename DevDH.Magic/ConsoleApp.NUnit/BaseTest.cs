using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using DevDH.Magic.Abstractions;

namespace ConsoleApp.NUnit
{
    public class BaseTest
    {
        protected void SimpleAssert(bool is_valid)
        {
            Assert.True(is_valid);
        }

        protected void SimpleRequestAssert(RequestResult requestResult)
        {
            SimpleAssert(requestResult.IsValid);
        }

        protected void SimpleRequestAssert<T>(RequestResult<T> requestResult) where T : class
        {
            SimpleAssert(requestResult.IsValid);
        }
    }
}
