using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Zhurnal
{
    public partial class People
    {
        public int Id { get; set; }
        public string Teacher { get; set; }
        public string GroupName { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Birth { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Iin { get; set; }
        public string Certificates { get; set; }
        public string Hobby { get; set; }
        public string SocialStatus { get; set; }
        public string WorkPlace { get; set; }
        public string NameImg { get; set; }
    }
}
