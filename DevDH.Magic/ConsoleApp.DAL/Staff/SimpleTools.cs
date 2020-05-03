using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp.DAL.Staff
{
    public class SimpleTools : ConsoleApp.Abstractions.Staff.SimpleTools
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public static new SimpleTools Instance => LazyInstance.Value;
    }
}
