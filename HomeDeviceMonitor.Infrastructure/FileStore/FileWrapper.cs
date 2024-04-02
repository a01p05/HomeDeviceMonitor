using HomeDeviceMonitor.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Infrastructure.FileStore
{
    public class FileWrapper : IFileWrapper
    {
        public void WriteAllBytes(string outputFile, byte[] content)
        {
            File.WriteAllBytes(outputFile, content);
        }
    }
}
