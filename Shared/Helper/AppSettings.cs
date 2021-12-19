using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helper
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string BaseUrl { get; set; }
        public string BaseClientUrl { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public int JwtDurationInHoursLong { get; set; }
        public int JwtDurationInHoursShort { get; set; }
    }
}
