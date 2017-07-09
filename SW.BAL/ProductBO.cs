using SW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.BAL
{
    public static class ProductBO
    {
        public static int addToCart(int  cid,int pid)
        {
            return DAL.ProductDAO.addToCart(cid, pid);
        }
        public static List<SW.Entities.ProductDTO> getProducts()
        {
            return DAL.ProductDAO.getProducts();
        }
        public static ProductDTO getProduct(int pid)
        {
            return DAL.ProductDAO.getProduct(pid);
        }
        public static int getCountOfProductsOfCustomer(int pid)
        {
            return DAL.ProductDAO.getCountOfProductsOfCustomer(pid);
        }
        public static int getCountOfProductsOfCustomerInWishlist(int pid)
        {
            return DAL.ProductDAO.getCountOfProductsOfCustomerInWishlist(pid);
        }
        public static List<int> getProductsOfCustomerInCart(int pid)
        {
            return DAL.ProductDAO.getProductsOfCustomerInCart(pid);
        }
        public static List<int> getProductsOfCustomerInWishlist(int cid)
        {
            return DAL.ProductDAO.getProductsOfCustomerInWishlist(cid);
        }
        public static int addToWishlist(int cid, int pid)
        {
            return DAL.ProductDAO.addToWishlist(cid, pid);
        }
        public static int deleteProductFromCart(int c_id, int p_id)
        {
            return DAL.ProductDAO.deleteProductFromCart(c_id, p_id);
        }
        public static int deleteProductFromWishlist(int c_id, int p_id)
        {
            return DAL.ProductDAO.deleteProductFromWishlist(c_id, p_id);
        }
        public static List<SW.Entities.ProductDTO> getProducts(string category)
        {
            return DAL.ProductDAO.getProducts(category);
        }
        public static int deleteAllItemFromCart(int cid)
        {
            return DAL.ProductDAO.deleteAllItemFromCart(cid);
        }
    }
}
