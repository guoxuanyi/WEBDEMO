using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Web_Api_Demo.Models.DTO;

namespace Web_Api_Demo
{
    public static class Tools
    {
        public static void CreateXml<T>(List<T> list)
        {
            string dirPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\XML";

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            FileStream file = new FileStream(dirPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            serializer.Serialize(sw, list);
            sw.Flush();
            sw.Close();
            //XDocument xdoc = new XDocument();
            //XElement root = new XElement("root");
            //xdoc.Add(root);

            //list.ForEach(item =>
            //{
                //XElement opportunity = new XElement("Opportunity");
                //root.Add(opportunity);
                //XElement opportunityId = new XElement("OpportunityId");
                //XElement opportunityNm = new XElement("OpportunityNm");
                //XElement operatingUnitCd = new XElement("OperatingUnitCd");
                //XElement contractExtensionFl = new XElement("ContractExtensionFl");
                //XElement serviceGroupNm = new XElement("ServiceGroupNm");
                //XElement expectContractSignQtr = new XElement("ExpectContractSignQtr");
                //XElement ROStageCd = new XElement("ROStageCd");
                //XElement subCSGNm = new XElement("SubCSGNm");
                //XElement createUserId = new XElement("CreateUserId");
                //XElement archiveInd = new XElement("ArchiveInd");
                //opportunity.Add(
                //    opportunityId, opportunityNm, operatingUnitCd, contractExtensionFl, serviceGroupNm,
                //    expectContractSignQtr, ROStageCd, subCSGNm, createUserId, archiveInd);
                //opportunityId.SetValue(item.OpportunityId == null ? "" : item.OpportunityId);
                //opportunityNm.SetValue(item.OpportunityNm == null ? "" : item.OpportunityNm);
                //operatingUnitCd.SetValue(item.OperatingUnitCd == null ? "" : item.OperatingUnitCd);
                //contractExtensionFl.SetValue(item.ContractExtensionFl == null ? "" : item.ContractExtensionFl);
                //serviceGroupNm.SetValue(item.ServiceGroupNm == null ? "" : item.ServiceGroupNm);
                //expectContractSignQtr.SetValue(item.ExpectContractSignQtr == null ? "" : item.ExpectContractSignQtr);
                //ROStageCd.SetValue(item.ROStageCd == null ? "" : item.ROStageCd);
                //subCSGNm.SetValue(item.SubCSGNm == null ? "" : item.SubCSGNm);
                //createUserId.SetValue(item.CreateUserId == null ? "" : item.CreateUserId);
                //archiveInd.SetValue(item.ArchiveInd);
            //});
            //StreamWriter sw = null;
            //try
            //{
            //    FileStream file = new FileStream(dirPath, FileMode.Create, FileAccess.Write);
            //    sw = new StreamWriter(file);
            //    sw.Write(xdoc);
            //}
            //catch
            //{
            //    Console.WriteLine("error");
            //}
            //finally
            //{
            //    sw.Close();
            //}
        }
    }
}