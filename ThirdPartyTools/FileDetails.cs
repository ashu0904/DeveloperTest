﻿using System;
using ThirdPartyTools.Interface;

namespace ThirdPartyTools
{
    public class FileDetails : IFileDetails
    {
        private readonly Random _random = new Random();

        public string Version(string filePath)
        {
            return string.Format("{0}.{1}.{2}", _random.Next(5), _random.Next(8), _random.Next(22)); 
        }

        public int Size(string filePath)
        {
            return _random.Next(100000) + 100000;
        }
    }
}
