using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDigestAuth
{
    public class DigestAuthenticate
    {
        public string qop { get; set; }
        public string realm { get; set; }
        public string nonce { get; set; }
        public bool stale { get; set; }
    }
}
