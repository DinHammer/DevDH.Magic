using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {
        public bool mgcIsList(object obj)
        {
            bool result = obj is IList && obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
            return result;
        }

        public bool mgcIsClass(object obj)
        {
            Type myType = obj.GetType();
            bool result = myType.IsClass;
            return result;
        }
    }
}
