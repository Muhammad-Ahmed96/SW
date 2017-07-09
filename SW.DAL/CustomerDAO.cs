using SW.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SW.DAL
{
    public static class CustomerDAO
    {
        public static CustomerDTO ValidateCustomer(string login, string pass)
        {
            string query = string.Format("select * from customers where email='{0}' and Password='{1}'", login, pass);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                CustomerDTO dto = null;
                if (reader.Read())
                {
                    dto = fillDTO(reader);
                }
                return dto;
            }
        }

        public static CustomerDTO getCustomerInfo(int id)
        {
            string query = "select * from customers where id=" + id;
            using(DBHelper helper=new DBHelper())
            {
                CustomerDTO dto = new CustomerDTO();

                var reader = helper.ExecuteReader(query);
                if (reader.Read())
                {
                    dto = fillDTO(reader);
                }
                return dto;
            }
        }
        private static CustomerDTO fillDTO(SqlDataReader reader)
        {
            CustomerDTO dto = new CustomerDTO();
            dto.ID = reader.GetInt32(0);
            dto.email = reader.GetString(1);
            dto.password = reader.GetString(2);
            dto.name = reader.GetString(3);
            dto.address = reader.GetString(4);
            dto.country = reader.GetString(5);
            dto.city = reader.GetString(6);
            dto.phone_no = reader.GetString(7);
            dto.gender = reader.GetString(8);
            dto.isAdmin = reader.GetBoolean(9);
            dto.isActive = reader.GetBoolean(10);
            return dto;
        }
        public static ArrayList getAccountInfo(int id)
        {
            string query = "select card_no,balance from accounts where id=" + id;
            using (DBHelper helper = new DBHelper())
            {
                ArrayList list = new ArrayList();
                var reader = helper.ExecuteReader(query);
                if(reader.Read())
                {
                    list.Add(reader.GetString(0));
                    list.Add(reader.GetInt32(1));
                }
                return list;
            }
        }
        
    }
}
