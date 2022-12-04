using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zhurnal
{
    public partial class Authorities
    {
        public string Username { get; set; }
        public string Authority { get; set; }

        public virtual Users UsernameNavigation { get; set; }
    }
}
