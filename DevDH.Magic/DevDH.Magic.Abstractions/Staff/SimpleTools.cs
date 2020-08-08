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
    public class SimpleTools : constantBase
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public static SimpleTools Instance => LazyInstance.Value;

        /// <summary>
        /// Формируем строку из набора ошибок
        /// </summary>
        /// <param name="exceptions"></param>
        /// <returns></returns>
        public string ConvertExceptionList2String(List<Exception> exceptions)
        {
            string result = string.Empty;

            try
            {
                if (exceptions == null)
                {
                    return result;
                }

                if (exceptions?.Count == 0)
                {
                    return result;
                }

                foreach (Exception exception in exceptions)
                {
                    result = result + "\n" + exception.Message;
                }
            }
            catch
            { }

            return result;
        }

        #region ResourceAction

        public RequestResult<System.IO.Stream> RsrGetStreamByName(Assembly assembly, string name)
        {
            var var_name = RsrGetFullName(assembly, name);
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

        public RequestResult<string> RsrGetFullName(Assembly assembly, string name)
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
                    return new RequestResult<string>(string.Empty, statusNotFound);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, statusSomethingWrong, message: ex.Message);
            }

        }

        #endregion

        #region Json

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
        public RequestResult<T> JsnDeserializeFromFile<T>(string str_path) where T: class
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

        #endregion

        public string GuidGetString()
        {
            string result = new Guid().ToString();
            return result;
        }
        #region Converters
        public RequestResult<Tuple<int>> ConsvertString2Int(string str, int my_default_int = default_int)
        {
            int result = my_default_int;
            if (Int32.TryParse(str, out result))
            {
                return new RequestResult<Tuple<int>>(Tuple.Create(result), statusOk);
            }
            else
            {
                return new RequestResult<Tuple<int>>(null, statusSomethingWrong);
            }
        }

        public RequestResult<Tuple<bool>> ConverStringIntToBool(string str)
        {
            if (str.Equals("1"))
            {
                return new RequestResult<Tuple<bool>>(Tuple.Create(true), statusOk);
            }
            else
            {
                return new RequestResult<Tuple<bool>>(Tuple.Create(false), statusOk);
            }
        }

        public RequestResult<Tuple<bool>> ConverStringToBool(string str)
        {
            if (Boolean.Parse(str))
            {
                return new RequestResult<Tuple<bool>>(Tuple.Create(true), statusOk);
            }
            else
            {
                return new RequestResult<Tuple<bool>>(null, statusSomethingWrong);
            }
        }

        public RequestResult<Tuple<DateTimeOffset>> ConvertString2DateTimeOffset(string str)
        {
            DateTimeOffset result;
            try
            {
                result = Convert.ToDateTime(str);
                return new RequestResult<Tuple<DateTimeOffset>>(Tuple.Create(result), statusOk);
            }
            catch
            {
                return new RequestResult<Tuple<DateTimeOffset>>(null, statusSomethingWrong);
            }
        }

        public bool ConvertListBool2Bool(List<bool> list)
            => list.All(x => x == true);

        #endregion

        public bool CheckStringSimple(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region IsSomething
        public bool IsList(object obj)
        {
            bool result = obj is IList && obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
            return result;
        }

        public bool IsClass(object obj)
        {
            Type myType = obj.GetType();
            bool result = myType.IsClass;
            return result;
        }
        #endregion

        #region SpecialFolder
        public string SpcFldGetPath(Environment.SpecialFolder specialFolder = Environment.SpecialFolder.LocalApplicationData)
            => Environment.GetFolderPath(specialFolder);

        public string SpcFldGetPathByName(string file_name, Environment.SpecialFolder specialFolder = Environment.SpecialFolder.LocalApplicationData)
            => System.IO.Path.Combine(SpcFldGetPath(specialFolder), file_name);
        #endregion

        #region FileAction

        public RequestResult<string> FileReadAllText(string str_path)
        {
            try
            {
                string result = File.ReadAllText(str_path);
                return new RequestResult<string>(result, statusOk);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, statusSomethingWrong, message: ex.Message);
            }
        }

        public bool FileIsExist(string path)
        => File.Exists(path);

        public void FileDeleteIfExist(string path)
        {
            if (FileIsExist(path))
            {
                File.Delete(path);
            }
        }
        #endregion
    }
}
