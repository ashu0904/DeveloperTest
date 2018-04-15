

namespace FileData
{
    using System;
    using ThirdPartyTools.Interface;

    public class Application : IApplication
    {
        private readonly IFileDetails _fileDetails;
        private string version = string.Empty;
        private int size = 0;
        private string consoleMessage = string.Empty;

        public Application(IFileDetails fileDetails)
        {
            _fileDetails = fileDetails;
        }

        public string GetVersionOrSize(string[] args)
        {
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0])) 
            {
                if (args[0] == "-v" || args[0] == "--v" || args[0] == "/v")
                {
                    version = GetVersion(args[1]);
                    consoleMessage = "The version of the file is " + version;
                }
                else if (args[0] == "-s" || args[0] == "--s" || args[0] == "/s")
                {
                    size = GetSize(args[1]);
                    consoleMessage = "The size of the file is " + size;
                }
                else
                {
                    throw new ArgumentException("First Argument is Invalid");
                }
            }
            else
            {
                throw new ArgumentException("First Argument is empty");
            }
            return consoleMessage;
        }

        private string GetVersion(string filePath)
        {
            string fileVersion = string.Empty;
            if (!String.IsNullOrEmpty(filePath))
            {
                fileVersion = _fileDetails.Version(filePath);
            }
            else
            {
                throw new ArgumentException("Second Argument is empty");
            }
            return fileVersion;
            
        }

        private int GetSize(string filePath)
        {
            return _fileDetails.Size(filePath);
        }

    }
}
