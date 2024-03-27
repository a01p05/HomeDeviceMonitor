using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Domain.Exceptions
{
    public class DomainUrlException: Exception
    {
        public DomainUrlException(string url, Exception ex): base($"Url: {url} is invalid.", ex) 
        { 
        }
    }
}
