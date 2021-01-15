using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {
        public RequestResult<string> mgcFileReadAllText(string str_path)
        {
            try
            {
                string result = System.IO.File.ReadAllText(str_path);
                return new RequestResult<string>(result, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, statusSomethingWrong, message: $"can not read all txt in file: {str_path} with error {ex.Message}",  ex );
            }
        }

        public bool mgcFileIsExist(string path)
        => System.IO.File.Exists(path);

        public void mgcFileDeleteIfExist(string path)
        {
            if (mgcFileIsExist(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
