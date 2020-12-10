using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {
        public RequestResult<System.IO.Stream> mgcRsrGetStreamByName(Assembly assembly, string name)
        {
            var var_name = mgcRsrGetFullName(assembly, name);
            if (!var_name.IsValid)
            {
                return new RequestResult<Stream>(null, var_name.Status, var_name.Message);
            }

            try
            {
                System.IO.Stream stream = assembly.GetManifestResourceStream(var_name.Data);
                return new RequestResult<Stream>(stream, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<Stream>(null, statusSomethingWrong, message: ex.Message);
            }
        }

        /// <summary>
        /// Получение полного пути до ресурса в выбранном Assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public RequestResult<string> mgcRsrGetFullName(Assembly assembly, string name)
        {
            try
            {
                List<string> resources = assembly.GetManifestResourceNames().Where(x => x.EndsWith(name)).ToList();
                if (resources.Count == 1)
                {
                    return new RequestResult<string>(resources.First(), statusOk);
                }
                else if (resources.Count > 1)
                {
                    return new RequestResult<string>(string.Empty, statusNotOneValue, message: $"name: {name}, has: {resources.Count} items");
                }
                else
                {
                    return new RequestResult<string>(string.Empty, statusNotFound, message: $"can not find resource: {name}");
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, statusSomethingWrong, message: $"can not get resource with error: { ex.Message}");
            }

        }
    }
}
