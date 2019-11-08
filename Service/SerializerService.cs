using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Web_Api_Demo.Models.DTO;
using Web_Api_Demo.Service.Interface;

namespace Web_Api_Demo.Service
{
    public class SerializerService : ISerializerService
    {
        public bool CreateXml(string xmlName)
        {
            OoportunityService ooportunityService = new OoportunityService();
            try
            {
                switch (xmlName)
                {
                    case "Opp":
                        var Opp = ooportunityService.GetOpportunities();
                        Tools.CreateXml(Opp, xmlName);
                        break;
                    case "AddOpp":
                        var AddOpp = ooportunityService.GetNewAddOpportunity();
                        Tools.CreateXml(AddOpp, xmlName);
                        break;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public List<string> GetXmlName()
        {
            return Tools.GetXmlName();
        }

        public string ReadXml(string xmlName)
        {
            return Tools.ReadXml(xmlName).ToString();
        }

        public bool DeleteXml(string xmlName)
        {
            return Tools.DeleteXml(xmlName);
        }

        public List<string> GetXmlInfo()
        {
            return Tools.GetXmlInfo();
        }

        public void OpenPath(string name)
        {
            Tools.OpenXml(name);
        }

        public bool Upload()
        {
            return Tools.Upload();
        }

        public List<string> GetUploadInfo()
        {
            return Tools.GetUploadInfo();
        }

        public void DownLoad( string fileName)
        {
            Tools.DownLoad(fileName);
        }

        public List<string> FileDetails(string fileName)
        {
            return Tools.FileDetails(fileName);
        }
    }
}