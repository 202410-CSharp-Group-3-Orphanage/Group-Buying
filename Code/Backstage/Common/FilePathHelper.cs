using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Backstage.Common
{
    public class FilePathHelper
    {
        private readonly string _fileServerUrl;
        private readonly string _fileBasePath;

        public FilePathHelper()
        {
            _fileServerUrl = ConfigurationManager.AppSettings["FileServer:Url"];

            // 取得當前專案的根目錄
            string currentPath = HttpContext.Current.Server.MapPath("~/");
            // 往上一層到解決方案目錄，然後進入 FileServer 專案的 Files 目錄
            _fileBasePath = Path.GetFullPath(Path.Combine(currentPath, @"..\FileServer\Files"));
        }

        public string GetWritePath(string folderName)
        {
            // 確保基礎路徑存在
            if (!Directory.Exists(_fileBasePath))
            {
                Directory.CreateDirectory(_fileBasePath);
            }

            // 建立完整的目標路徑（包含子資料夾）
            string fullPath = Path.Combine(_fileBasePath, folderName);

            // 確保目標資料夾存在
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }

        public string GetReadPath(string folderName, string fileName)
        {
            if (fileName.StartsWith("http")) return fileName;

            if (string.IsNullOrEmpty(_fileServerUrl))
                throw new Exception("請配置FileServer:Url在Web.config的AppSettings中");

            return $"{_fileServerUrl}/Files/{folderName}/{fileName}";
        }
    }
}