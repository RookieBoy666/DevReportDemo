using System;
using System.Configuration;
using System.Xml;
namespace DevReportDemo.Helper
{
    static public class ConfigHelper
    {
        // private  static string strUserProfiePath =Environment.CurrentDirectory.ToString()+ "\\Locdata\\Userprofie.config";
        private static string strUserProfiePath = AppDomain.CurrentDomain.BaseDirectory + "\\Locdata\\Userprofie.config";
        static public string GetConfigVal(string strConfigName)
        {
            //不建议通过这种自带的方式进行读取;如果手动修改了配置文件，则不会第二次读取的时候，依旧是内存中的值。可以通过XML方式进行读取。
            //return ConfigurationSettings.AppSettings[key];
            XmlDocument doc = loadConfigDocument(strUserProfiePath);
            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");
            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");
            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", strConfigName));
                if (elem != null)
                {
                    // add value for key
                    return elem.GetAttribute("value");
                }
            }
            catch
            {
                throw;
            }
            return "";
        }
        static public void SetConfigVal(string key, string value)
        {
            XmlDocument doc = loadConfigDocument(strUserProfiePath);
            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//appSettings");
            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");
            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(string.Format("//add[@key='{0}']", key));
                if (elem != null)
                {
                    // add value for key
                    elem.SetAttribute("value", value);
                }
                else
                {
                    // key was not found so create the 'add' element
                    // and set it's key/value attributes
                    elem = doc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    node.AppendChild(elem);
                }
                doc.Save(strUserProfiePath);
            }
            catch
            {

                throw;
            }
        }

        private static XmlDocument loadConfigDocument(string strConfigPath)
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(strConfigPath);
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("配置文件丢失.", e);
            }
        }


        public static void SetDBConfigVal(string strConfigName, string strVal, bool bEntityClient)
        {
            bool isModified = false;    //记录该连接串是否已经存在
            //如果要更改的连接串已经存在
            if (ConfigurationManager.ConnectionStrings[strConfigName] != null)
            {
                isModified = true;
            }

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 如果连接串已存在，首先删除它
            if (isModified)
            {
                cfa.ConnectionStrings.ConnectionStrings.Remove(strConfigName);
            }
            string strEntityClient = "System.Data.SqlClient";
            if (bEntityClient)
            {
                strEntityClient = "System.Data.EntityClient";
            }
            //strVal = new EncryptTY().EncryptString(strVal, "?^?--?\v\u0016");
            ConnectionStringSettings constring = new ConnectionStringSettings(strConfigName, strVal, strEntityClient);


            // 将新的连接串添加到配置文件中.
            cfa.ConnectionStrings.ConnectionStrings.Add(constring);
            // 保存对配置文件所作的更改
            cfa.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("ConnectionStrings");



        }
        /// <summary>
        /// 配置其它程序的配置文件
        /// </summary>
        /// <param name="strConfigName"></param>
        /// <param name="strVal"></param>
        /// <param name="bEntityClient"></param>
        public static void SetOtherDBConfigVal(string exePath, string strConfigName, string strVal, bool bEntityClient)
        {



            bool isModified = false;    //记录该连接串是否已经存在

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(exePath);

            //如果要更改的连接串已经存在
            if (cfa.ConnectionStrings.ConnectionStrings[strConfigName] != null)
            {
                isModified = true;
            }

            // 如果连接串已存在，首先删除它
            if (isModified)
            {
                cfa.ConnectionStrings.ConnectionStrings.Remove(strConfigName);
            }


            string strEntityClient = "System.Data.SqlClient";
            if (bEntityClient)
            {
                strEntityClient = "System.Data.EntityClient";
            }
            ConnectionStringSettings constring = new ConnectionStringSettings(strConfigName, strVal, strEntityClient);

            // 将新的连接串添加到配置文件中.
            cfa.ConnectionStrings.ConnectionStrings.Add(constring);
            // 保存对配置文件所作的更改
            cfa.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }





        /// <summary>
        /// 获取ConnectionStrings节点的值
        /// </summary>
        /// <param name="strConfigName"></param>
        /// <returns></returns>
        public static string GetConfigValConn(string strConfigName)
        {
            return ConfigurationManager.ConnectionStrings[strConfigName].ToString();
        }
        /// <summary>
        /// 获取ConnectionStrings节点的值
        /// </summary>
        /// <param name="strConfigName"></param>
        /// <returns></returns>
        public static string GetConfigValConn(string strConfigName, string defaultVale, bool saveFlag)
        {
            return ConfigurationManager.ConnectionStrings[strConfigName].ToString();
        }
        ///<summary>
        ///更新连接字符串
        ///</summary>
        ///<param name="newName">连接字符串名称</param>
        ///<param name="newConString">连接字符串内容</param>
        ///<param name="newProviderName">数据提供程序名称</param>
        ///<param name="config">Configuration实例</param>
        public static void UpdateConnectionStringsConfig(string newName, string newConString, string newProviderName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool isModified = false;             //记录该连接串是否已经存在
            //如果要更改的连接串已经存在
            if (config.ConnectionStrings.ConnectionStrings[newName] != null)
            {
                isModified = true;
            }
            //新建一个连接字符串实例
            ConnectionStringSettings mySettings = new ConnectionStringSettings(newName, newConString, newProviderName);
            // 如果连接串已存在，首先删除它
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // 将新的连接串添加到配置文件中.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改
            config.Save(ConfigurationSaveMode.Modified);
        }


    }
}
