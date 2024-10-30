using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PERFILES_SA.DATA
{
    public class ConexionDB
    {
        public static string cn = ConfigurationManager.ConnectionStrings["PERFILES_SA"].ToString();
    }
}