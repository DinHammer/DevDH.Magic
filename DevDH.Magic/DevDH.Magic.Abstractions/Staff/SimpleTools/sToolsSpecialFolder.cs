using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {
        public string mgcSpcFldGetPath(Environment.SpecialFolder specialFolder = Environment.SpecialFolder.LocalApplicationData)
            => Environment.GetFolderPath(specialFolder);

        public string mgcSpcFldGetPathByName(string file_name, Environment.SpecialFolder specialFolder = Environment.SpecialFolder.LocalApplicationData)
            => System.IO.Path.Combine(mgcSpcFldGetPath(specialFolder), file_name);
    }
}
