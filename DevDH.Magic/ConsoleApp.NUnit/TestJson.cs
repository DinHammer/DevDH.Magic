using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models = ConsoleApp.NUnit.Staff.Models;
using simpleTools = ConsoleApp.DAL.Staff.SimpleTools;

namespace ConsoleApp.NUnit
{
    [TestFixture]
    public class TestJson : BaseTest
    {

        models.MdlJsonTest mdlJson { get; set; }

        [OneTimeSetUp]
        public void Init()
        {
            mdlJson = new models.MdlJsonTest();
            mdlJson.int_data = 42;
            mdlJson.str_data = "ololoPishPish";
        }

        [Test]
        public async Task TestSerialize2File()
        {
            string str_file_name = $"{nameof(mdlJson)}.json";
            string str_file_path = simpleTools.Instance.mgcSpcFldGetPathByName(str_file_name);

            simpleTools.Instance.mgcFileDeleteIfExist(str_file_path);

            var var_serialize = await simpleTools.Instance.mgcJsnAsncSerialize2File(mdlJson, str_file_path);
            SimpleAssert(var_serialize.IsValid, var_serialize.Message);

            var var_deserialize = await simpleTools.Instance.mgcJsnAsncDeserializeFromFile<models.MdlJsonTest>(str_file_path);
            SimpleAssert(var_deserialize.IsValid, var_deserialize.Message);

            SimpleAssert(var_deserialize.Data.int_data == mdlJson.int_data, "Данные в сериализации и без не совпадают");

            simpleTools.Instance.mgcFileDeleteIfExist(str_file_path);
        }

        [Test]
        public async Task TestDeserializeFromResources()
        {
            System.Reflection.Assembly assembly = ConsoleApp.Program.GetAssembly();

            string str_name = $"{nameof(mdlJson)}.json";
            //string str_name = $"{nameof(mdlJson)}";




            var var_name = simpleTools.Instance.mgcRsrGetFullName(assembly, str_name);
            SimpleAssert(var_name.IsValid, var_name.Message);

            var var_stream = simpleTools.Instance.mgcRsrGetStreamByName(assembly, str_name);
            SimpleAssert(var_stream.IsValid, var_stream.Message);


            var var_deserialize = await simpleTools.Instance.mgcJsncAsnDeserializeFromResource<models.MdlJsonTest>(assembly, str_name);
            SimpleAssert(var_deserialize.IsValid, var_deserialize.Message);

            SimpleAssert(var_deserialize.Data.int_data == mdlJson.int_data, "Данные в сериализации и без не совпадают");            
        }
    }
}
