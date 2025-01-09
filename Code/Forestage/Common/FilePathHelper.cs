namespace Forestage.Common
{
    public class FilePathHelper
    {
        private readonly IConfiguration _configuration;

        public FilePathHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetWritePath(string folderName)
        {
            return Path.Combine("..", "FileServer", "Files", folderName);
        }

        public string GetReadPath(string folderName, string fileName)
        {
            string? serverUrl = _configuration["FileServer:Url"];
            if (string.IsNullOrEmpty(serverUrl)) throw new Exception("請配置FileServerUrl");
            return $"{serverUrl}/Files/{folderName}/{fileName}";
        }
    }
}
