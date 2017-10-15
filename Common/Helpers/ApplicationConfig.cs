using System;
using System.Configuration;

namespace Common.Helpers
{
    public class ApplicationConfig
    {
        public string FileDataCreateQueue { get => ConfigurationManager.AppSettings["FileDataCreateQueue"]; }
        public string FileMetaDeleteQueue { get => ConfigurationManager.AppSettings["FileMetaDeleteQueue"]; }
        public string FileOpenedQueue { get => ConfigurationManager.AppSettings["FileOpenedQueue"]; }

        public string RabbitConnection { get => ConfigurationManager.AppSettings["RabbitConnection"]; }
        public string RedisServerName { get => ConfigurationManager.AppSettings["RedisServerName"]; }
        public string WebServerUrl { get => ConfigurationManager.AppSettings["WebServerUrl"]; }
        public string BlobConnectionString { get => ConfigurationManager.AppSettings["BlobConnectionString"]; }
        public string CsvContainer { get => ConfigurationManager.AppSettings["CsvContainer"]; }
        public string RedisFileMetaList { get => ConfigurationManager.AppSettings["RedisFileMetaList"]; }
        public string AcceptedFiles { get => ConfigurationManager.AppSettings["AcceptedFiles"]; }
        public string RedisConnectionString { get => ConfigurationManager.AppSettings["RedisConnectionString"]; }

        public int RabbitConnectionPort { get => Convert.ToInt32(ConfigurationManager.AppSettings["RabbitConnectionPort"]); }
        public string RabbitConnectionUsername { get => ConfigurationManager.AppSettings["RabbitConnectionUsername"]; }
        public string RabbitConnectionPassword { get => ConfigurationManager.AppSettings["RabbitConnectionPassword"]; }
    }
}