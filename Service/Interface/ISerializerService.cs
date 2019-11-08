using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Web_Api_Demo.Models.DTO;

namespace Web_Api_Demo.Service.Interface
{
    public interface ISerializerService
    {
        bool CreateXml(string xmlName);
        string ReadXml(string xmlName);
        List<string> GetXmlName();
        List<string> GetXmlInfo();
        void OpenPath(string name);

    }
}
