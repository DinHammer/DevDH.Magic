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
        public Task<RequestResult<T>> mgcJsncDeserializeFromResourceAsnc<T>(Assembly assembly, string str_name) where T : class
            => Task.Run(() => { return mgcJsnDeserializeFromResource<T>(assembly, str_name); });
        public RequestResult<T> mgcJsnDeserializeFromResource<T>(Assembly assembly, string str_name) where T : class
        {
            var var_stream = mgcRsrGetStreamByName(assembly, str_name);
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
                return new RequestResult<T>(null, statusSomethingWrong, message: $"can not deserialize json resouce: {str_name} with error: {ex.Message}", ex);
            }
            finally
            {
                var_stream.Data?.Dispose();
            }
        }

        public Task<RequestResult<T>> mgcJsnDeserializeFromFileAsnc<T>(string str_path) where T : class
            => Task.Run(() => { return mgcJsnDeserializeFromFile<T>(str_path); });
        public RequestResult<T> mgcJsnDeserializeFromFile<T>(string str_path) where T : class
        {
            var var_string = mgcFileReadAllText(str_path);
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
                return new RequestResult<T>(null, statusSerializationError, message: $"can not deserialize json from file: {str_path} with error: {ex.Message}", ex);
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

        public Task<RequestResult> mgcJsnSerialize2FileAsnc(
            object item,
            string str_path,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore)
            => Task.Run(() => { return mgcJsnSerialize2File(item, str_path, nullValueHandling); });
        public RequestResult mgcJsnSerialize2File(
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
                return new RequestResult(statusSerializationError, message: $"can not serialize json to file: {str_path} with error: {ex.Message}" , ex );
            }
        }

        public Task<RequestResult<string>> mgcJsnGetStringByDataAsnc(object item)
            => Task.Run(() => { return mgcJsnGetStringByData(item); });
        public RequestResult<string> mgcJsnGetStringByData(object item)
        {
            try
            {
                string result = JsonConvert.SerializeObject(item);
                return new RequestResult<string>(result, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, statusSerializationError, message: $"can not serialize object to json with error: {ex.Message}", ex );
            }
        }

        public Task<RequestResult<T>> mgcJsnGetDataByStringAsnc<T>(string jsonString) where T : class
            => Task.Run(() => { return mgcJsnGetDataByString<T>(jsonString); });
        public RequestResult<T> mgcJsnGetDataByString<T>(string jsonString) where T : class
        {
            try
            {
                var data = JsonConvert.DeserializeObject<T>(jsonString);
                return new RequestResult<T>(data, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(default(T), statusSerializationError, message:$"can not deserialize string to object with error: {ex.Message}", ex );
            }
        }
    }
}
