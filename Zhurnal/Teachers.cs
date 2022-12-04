using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zhurnal
{
    public partial class Teachers
    {
        public int Id { get; set; }
        public string Teacher { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ItemName { get; set; }
        public string Audience { get; set; }
    }
}
