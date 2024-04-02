using HomeDeviceMonitor.Domain.Common;
using HomeDeviceMonitor.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDeviceMonitor.Domain.ValueObject
{
    public class Url : ValueObjects
    {
        public string? Ip {  get; set; }
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? Protocol { get; set; }
        public string? Path { get; set; }
        public string? Parameter { get; set; }

        public static Url For(string url)
        {
            var urlObj = new Url();
            try
            {

            }
            catch (Exception ex)
            {
                throw new DomainUrlException(url, ex);
            }
            return urlObj;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Ip;
            yield return Host;
            yield return Port;
            yield return Protocol;
        }
    }
}
