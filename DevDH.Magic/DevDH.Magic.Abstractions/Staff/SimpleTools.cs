using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using constantBase = DevDH.Magic.Abstractions.Constants.ConstantBase;

namespace DevDH.Magic.Abstractions.Staff
{
    /// <summary>
    /// Набор простых функций используемых в данном приложении
    /// </summary>
    public partial class SimpleTools : constantBase
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public static SimpleTools Instance => LazyInstance.Value;



        public string mgcGuidGetString()
            => new Guid().ToString();


        public bool CheckStringSimple(string text)
            => !string.IsNullOrWhiteSpace(text);        
                
    }
}
