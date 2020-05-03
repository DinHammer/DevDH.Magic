using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.DAL.Staff
{
    public class SimpleTools : DevDH.Magic.Abstractions.Staff.SimpleTools
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public static new SimpleTools Instance => LazyInstance.Value;
    }
}
