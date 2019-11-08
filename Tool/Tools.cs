using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        static string dirPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        static bool status;
        public static void CreateXml<T>(List<T> list, string xmlName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            FileStream file = new FileStream(dirPath + @"\" + xmlName + ".xml", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            serializer.Serialize(sw, list);
            sw.Flush();
            sw.Close();
        }

        public static XElement ReadXml(string name)
        {
            XElement xml = null;
            if (dirPath == null)
                return null;
            try
            {
                xml = XElement.Load(dirPath + @"\" + name);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
            }
            return xml;
        }

        public static List<string> GetXmlName()
        {
            status = true;
            return GetFilePath(status);
        }

        public static bool DeleteXml(string name)
        {
            if (!name.Contains("xml"))
            {
                try
                {
                    File.Delete(dirPath + @"\upload\" + name);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    File.Delete(dirPath + @"\" + name);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<string> GetXmlInfo()
        {
            status = false;
            return GetFilePath(status);
        }

        public static List<string> GetFilePath(bool status)
        {
            List<string> list = new List<string>();
            DirectoryInfo TheFolder = new DirectoryInfo(dirPath);
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                if (NextFile.Name.Contains(".xml"))
                {
                    if (status)
                    {
                        list.Add(NextFile.Name);
                    }
                    if (!status)
                    {
                        list.Add(NextFile.FullName);
                    }
                }
            }
            return list;
        }

        public static void OpenXml(string path)
        {
            System.Diagnostics.Process.Start(path);
        }

        public static bool Upload()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    file.SaveAs(dirPath + @"\upload\" + file.FileName);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<string> GetUploadInfo()
        {
            List<string> list = new List<string>();
            DirectoryInfo TheFolder = new DirectoryInfo(dirPath + @"\upload\");
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                list.Add(NextFile.Name);
            }
            return list;
        }

        public static void DownLoad(string fileName)
        {
            if (fileName.Contains("'"))
            {
                var context = fileName.Split('\'');
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;FileName=" + HttpUtility.UrlEncode(Path.GetFileName(context[1])));
                HttpContext.Current.Response.WriteFile(dirPath + @"upload\" + context[1]);
                HttpContext.Current.Response.End();
            }
            else
            {
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;FileName=" + HttpUtility.UrlEncode(Path.GetFileName(fileName)));
                HttpContext.Current.Response.WriteFile(dirPath + @"upload\" + fileName);
                HttpContext.Current.Response.End();
            }
        }

        public static List<string> FileDetails(string fileName)
        {
            List<string> list = new List<string>();
            FileInfo NextFile = new FileInfo(dirPath + @"\upload\" + fileName);
            list.Add(NextFile.Extension);
            list.Add((NextFile.Length / 1024) + "KB");
            list.Add(NextFile.LastWriteTime.ToString());
            return list;
        }
    }
}