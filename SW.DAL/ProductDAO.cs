using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Entities;

namespace SW.DAL
{
    public static class ProductDAO
    {
        public static int addToCart(int cid,int pid)
        {
            string query = "insert into cart values(" + cid + "," + pid + "," + 0 + ")";
            using (DBHelper helper = new DBHelper())
            {
                var rowsEffected = helper.ExecuteQuery(query);
                return rowsEffected;
            }
        }
        public static int addToWishlist(int cid, int pid)
        {
            string query = "insert into wishlist values(" + cid + "," + pid + "," + 0 + ")";
            using (DBHelper helper = new DBHelper())
            {
                var rowsEffected = helper.ExecuteQuery(query);
                return rowsEffected;
            }
        }

        public static List<SW.Entities.ProductDTO> getProducts()
        {
            string query = string.Format("select * from products");
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                List<ProductDTO> list = new List<ProductDTO>();
                while (reader.Read())
                {
                    ProductDTO dto = new ProductDTO();
                    dto.pid = reader.GetInt32(0);
                    dto.p_name = reader.GetString(1);
                    dto.p_price = reader.GetInt32(2);
                    list.Add(dto);
                }
                return list;
            }
        }
        public static ProductDTO getProduct(int pid)
        {
            string query = string.Format("select * from products where pid={0}", pid);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                ProductDTO dto = new ProductDTO();
                while (reader.Read())
                {
                    dto.pid = reader.GetInt32(0);
                    dto.p_name = reader.GetString(1);
                    dto.p_price = reader.GetInt32(2);
                }
                return dto;
            }
        }

        public static ProductDTO getProduct(string name)
        {
            string query = string.Format("select * from products where p_name={0}", name);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                ProductDTO dto = new ProductDTO();
                while (reader.Read())
                {
                    dto.pid = reader.GetInt32(0);
                    dto.p_name = reader.GetString(1);
                    dto.p_price = reader.GetInt32(2);
                }
                return dto;
            }
        }

        public static int deleteProductFromCart(int c_id,int p_id)
        {
            string query = string.Format("delete from cart where c_id={0} and item_id={1}", c_id, p_id);
            using (DBHelper helper = new DBHelper())
            {
                var rowsEffected = helper.ExecuteQuery(query);
                return rowsEffected;
            }
        }

        public static int deleteProductFromWishlist(int c_id, int p_id)
        {
            string query = string.Format("delete from wishlist where c_id={0} and item_id={1}", c_id, p_id);
            using (DBHelper helper = new DBHelper())
            {
                var rowsEffected = helper.ExecuteQuery(query);
                return rowsEffected;
            }
        }
        public static int getCountOfProductsOfCustomer(int pid)
        {
            string query = string.Format("select count(*) from cart where c_id={0}", pid);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                if (reader.Read())
                    return reader.GetInt32(0);
                else
                    return -1;
            }
        }
        public static int getCountOfProductsOfCustomerInWishlist(int pid)
        {
            string query = string.Format("select count(*) from wishlist where c_id={0}", pid);
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                if (reader.Read())
                    return reader.GetInt32(0);
                else
                    return -1;
            }
        }
        public static List<int> getProductsOfCustomerInCart(int cid)
        {
            string query = string.Format("select item_id from cart where c_id={0}", cid);
            List<int> list = new List<int>();
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                while (reader.Read())
                    list.Add(reader.GetInt32(0));
                return list;
            }
        }

        public static List<int> getProductsOfCustomerInWishlist(int cid)
        {
            string query = string.Format("select item_id from wishlist where c_id={0}", cid);
            List<int> list = new List<int>();
            using (DBHelper helper = new DBHelper())
            {
                var reader = helper.ExecuteReader(query);
                while (reader.Read())
                    list.Add(reader.GetInt32(0));
                return list;
            }
        }
    }
}
