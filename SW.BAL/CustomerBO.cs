using SW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.DAL;
using System.Collections;

namespace SW.BAL
{
    public static class CustomerBO
    {
        public static CustomerDTO ValidateCustomer(string login, string pass)
        {
            return CustomerDAO.ValidateCustomer(login, pass);
        }
        public static CustomerDTO getCustomerInfo(int id)
        {
            return CustomerDAO.getCustomerInfo(id);
        }
        public static ArrayList getAccountInfo(int id)
        {
            return DAL.CustomerDAO.getAccountInfo(id);
        }
        public static int Register(CustomerDTO dto)
        {
            return DAL.CustomerDAO.Register(dto);
        }

    }
}
