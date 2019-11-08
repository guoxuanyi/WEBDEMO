using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using Web_Api_Demo.Service;

namespace Web_Api_Demo.Controllers
{
    public class SerializerController : ApiController
    {
        private readonly SerializerService _serializerService = new SerializerService();

        private const string createXml = "api/Serializer/createXml";
        [HttpGet]
        [Route(createXml)]
        public bool CreateOppXml([FromUri]string xmlName)
        {
            return _serializerService.CreateXml(xmlName);
        }

        private const string readXml = "api/Serializer/readXml";
        [HttpGet]
        [Route(readXml)]
        public string ReadXml([FromUri]string xmlName)
        {
            return _serializerService.ReadXml(xmlName);
        }

        private const string getXmlName = "api/Serializer/getXmlName";
        [HttpGet]
        [Route(getXmlName)]
        public List<string> GetXmlName()
        {
            return _serializerService.GetXmlName();
        }

        private const string deleteXmlName = "api/Serializer/deleteXmlName";
        [HttpDelete]
        [Route(deleteXmlName)]
        public bool DeleteXmlName([FromUri]string xmlName)
        {
            return _serializerService.DeleteXml(xmlName);
        }

        private const string openXml = "api/Serializer/openXml";
        [HttpGet]
        [Route(openXml)]
        public void OpenXml([FromUri]string name)
        {
            _serializerService.OpenPath(name);
        }

        private const string getXmlInfo = "api/Serializer/getXmlInfo";
        [HttpGet]
        [Route(getXmlInfo)]
        public List<string> GetXmlInfo()
        {
            return _serializerService.GetXmlInfo();
        }

        private const string upLoad = "api/Serializer/upLoad";
        [HttpPost]
        [Route(upLoad)]
        public bool UpLoad()
        {
            return _serializerService.Upload();
        }

        private const string getUploadInfo = "api/Serializer/getUploadInfo";
        [HttpGet]
        [Route(getUploadInfo)]
        public List<string> GetUploadInfo()
        {
            return _serializerService.GetUploadInfo();
        }

        private const string downLoadFile = "api/Serializer/downLoadFile";
        [HttpGet]
        [Route(downLoadFile)]
        public void DownLoadFile([FromUri]string fileName)
        {
             _serializerService.DownLoad(fileName);
        }

        private const string fileDetails = "api/Serializer/fileDetails";
        [HttpGet]
        [Route(fileDetails)]
        public List<string> FileDetails([FromUri]string fileName)
        {
            return _serializerService.FileDetails(fileName);
        }
    }
}