using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interns2.AppServices.API.Models
{
    public class GetTokenReponse
    {
        public string Token_type { get; set; }

        public string Expires_in { get; set; }

        public string Ext_expires_in { get; set; }

        public string Expires_on { get; set; }

        public string Not_before { get; set; }

        public string Resource { get; set; }

        public string Access_token { get; set; }
    }
}
