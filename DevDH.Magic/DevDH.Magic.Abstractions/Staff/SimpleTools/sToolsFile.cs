using System;
using System.Collections.Generic;
using System.Text;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {
        public RequestResult<string> FileReadAllText(string str_path)
        {
            try
            {
                string result = System.IO.File.ReadAllText(str_path);
                return new RequestResult<string>(result, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, statusSomethingWrong, message: ex.Message);
            }
        }

        public bool FileIsExist(string path)
        => System.IO.File.Exists(path);

        public void FileDeleteIfExist(string path)
        {
            if (FileIsExist(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
