using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABB.Entity
{
    public class JwtSettings
    {
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string audience { get; set; }
        public string grant_type { get; set; }
    }
    public class AuthZeroResponse
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
    }
}
