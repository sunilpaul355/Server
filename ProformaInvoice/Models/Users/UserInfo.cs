using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProformaInvoice.Models.Users
{
    public class UserInfo
    {   
        public int userId { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string cnfrmPassword { get; set; }

        public string address { get; set; }

        public string email { get; set; }

        public string mobileNumber { get; set; }

        public string city { get; set; }

        public string country { get; set; }

    }
}