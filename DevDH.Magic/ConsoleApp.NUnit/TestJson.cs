using NUnit.Framework;
using System;
using System.Collections.Generic;
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

            string str_file_path = simpleTools.Instance.SpcFldGetPathByName(str_file_name);

            simpleTools.Instance.FileDeleteIfExist(str_file_path);

            var var_serialize = await simpleTools.Instance.JsnAsnSerialize2File(mdlJson, str_file_path);
            SimpleAssert(var_serialize.IsValid, var_serialize.Message);

            //simpleTools.Instance.jsna
        }
    }
}
