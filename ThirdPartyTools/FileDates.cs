using System;
using ThirdPartyTools.Interface;

namespace ThirdPartyTools
{
    public class FileDates : IFileDates
    {
        private readonly string _filePath;

        public FileDates(string filePath)
        {
            _filePath = filePath;
        }

        public DateTimeOffset Created
        {
            get
            {
                return DateTimeOffset.UtcNow; 
            }
        }

        public DateTimeOffset Modified
        {
            get
            {
                return DateTimeOffset.UtcNow;
            }
        }
    }
}
