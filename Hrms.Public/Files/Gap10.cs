using Hrms.Public.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Hrms.Public.Files
{
    public class Gap10 : IReadWriteFile
    {
        public List<Gap10Position> Positions { get; set; }
        public List<Gap10CostDistributions> CostDistributions { get; set; }

        public int TotalCount => throw new NotImplementedException();

        public int ReadFile(FileInfo fileInfo, FileInfo errorFile = null)
        {
            throw new NotImplementedException();
        }

        public int WriteFile(FileInfo fileInfo)
        {
            throw new NotImplementedException();
        }

        private 
    }

}
