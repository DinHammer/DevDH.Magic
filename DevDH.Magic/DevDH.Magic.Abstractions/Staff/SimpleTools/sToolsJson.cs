using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevDH.Magic.Abstractions.Staff
{
    public partial class SimpleTools
    {
        public Task<RequestResult<T>> JsnAsnDeserializeFromResource<T>(Assembly assembly, string str_name) where T : class
            => Task.Run(() => { return JsnDeserializeFromResource<T>(assembly, str_name); });
        public RequestResult<T> JsnDeserializeFromResource<T>(Assembly assembly, string str_name) where T : class
        {
            var var_stream = RsrGetStreamByName(assembly, str_name);
            if (!var_stream.IsValid)
            {
                return new RequestResult<T>(null, var_stream.Status, var_stream.Message);
            }

            try
            {
                using (Stream stream = var_stream.Data)
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        string content = streamReader.ReadToEnd();
                        T item = JsonConvert.DeserializeObject<T>(content);

                        return new RequestResult<T>(item, statusOk);
                    }
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(null, statusSomethingWrong, message: ex.Message);
            }
            finally
            {
                var_stream.Data?.Dispose();
            }
        }

        public Task<RequestResult<T>> JsnAsnDeserializeFromFile<T>(string str_path) where T : class
            => Task.Run(() => { return JsnDeserializeFromFile<T>(str_path); });
        public RequestResult<T> JsnDeserializeFromFile<T>(string str_path) where T : class
        {
            var var_string = FileReadAllText(str_path);
            if (!var_string.IsValid)
            {
                return new RequestResult<T>(null, var_string.Status, var_string.Message);
            }

            try
            {
                T result = JsonConvert.DeserializeObject<T>(var_string.Data);
                return new RequestResult<T>(result, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(null, statusSerializationError, message: ex.Message);
            }

        }

        //RequestResult<string> GetStringContentFromResource(Assembly assembly, string str_resource_name)
        //{
        //    try
        //    {
        //        using (Stream stream = assembly.GetManifestResourceStream(str_resource_name))
        //        {
        //            using (StreamReader streamReader = new StreamReader(stream))
        //            {
        //                string content = streamReader.ReadToEnd();
        //                return new RequestResult<string>(content, statusOk);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new RequestResult<string>(string.Empty, statusSomethingWrong, message: ex.Message);
        //    }
        //}

        public Task<RequestResult> JsnAsnSerialize2File(
            object item,
            string str_path,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore)
            => Task.Run(() => { return JsnSerialize2File(item, str_path, nullValueHandling); });
        public RequestResult JsnSerialize2File(
            object item,
            string str_path,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore)
        {
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.NullValueHandling = nullValueHandling;

                using (StreamWriter streamWriter = new StreamWriter(str_path))
                {
                    using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonSerializer.Serialize(jsonWriter, item);
                    }
                }
                return new RequestResult(statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult(statusSerializationError, message: ex.Message, exceptionList: new List<Exception> { ex });
            }
        }

        public Task<RequestResult<string>> JsnAsnGetStringByData(object item)
            => Task.Run(() => { return JsnGetStringByData(item); });
        public RequestResult<string> JsnGetStringByData(object item)
        {
            try
            {
                string result = JsonConvert.SerializeObject(item);
                return new RequestResult<string>(result, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, statusSerializationError, ex.Message);
            }
        }

        public Task<RequestResult<T>> JsnAsnGetDataByString<T>(string jsonString) where T : class
            => Task.Run(() => { return JsnGetDataByString<T>(jsonString); });
        public RequestResult<T> JsnGetDataByString<T>(string jsonString) where T : class
        {
            try
            {
                var data = JsonConvert.DeserializeObject<T>(jsonString);
                return new RequestResult<T>(data, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(default(T), statusSerializationError, ex.Message);
            }
        }
    }
}
