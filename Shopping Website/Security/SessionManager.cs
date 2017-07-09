using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SW.Entities;

namespace Shopping_Website.Security
{
    public static class SessionManager
    {
        public static CustomerDTO Customer
        {
            get
            {
                CustomerDTO dto = null;
                if (HttpContext.Current.Session["Customer"] != null)
                {
                    dto = HttpContext.Current.Session["Customer"] as CustomerDTO;
                }

                return dto;
            }
            set
            {
                HttpContext.Current.Session["Customer"] = value;
            }
        }

        public static Boolean isValidUser
        {
            get
            {
                if (Customer != null)
                    return true;
                else
                    return false;
            }
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
        }
    }
}