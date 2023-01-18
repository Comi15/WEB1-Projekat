using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class LoginParams
    {
        string logusername;
        string logpassword;

        public LoginParams()
        {
            
        }

        public string LogUsername { get => logusername; set => logusername = value; }
        public string LogPassword { get => logpassword; set => logpassword = value; }
    }
}