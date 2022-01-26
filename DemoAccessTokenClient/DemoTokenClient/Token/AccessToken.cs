using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTokenClient.Token
{
    public class AccessToken
    {
        public string Value { get; set; }
        public string Type { get; set; }
        public TimeSpan ExpiresIn { get; set; }
        public DateTime RetrievedAtUtc { get; set; }
        public bool IsValid()
        {
            return (RetrievedAtUtc + ExpiresIn) > DateTime.UtcNow;
        }
    }


   
}
