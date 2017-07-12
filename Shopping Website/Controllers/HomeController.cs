using Shopping_Website.Security;
using SW.BAL;
using SW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace Shopping_Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        
        {
            List<SW.Entities.ProductDTO> list = ProductBO.getProducts();
            return View(list);
        }

        public ActionResult DisplaySingleItem()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ValidateUser(string login, string password)
        {
            Object data = null;
            try
            {
                var url = "";
                var flag = false;

                var obj = SW.BAL.CustomerBO.ValidateCustomer(login, password);
                if (obj != null)
                {
                    flag = true;
                    SessionManager.Customer = obj;
                        url = Url.Content("~/Home/Home");
                }

                data = new
                {
                    valid = flag,
                    urlToRedirect = url

                };

            }
            catch (Exception)
            {
                data = new
                {
                    valid = false,
                    urlToRedirect = ""
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Security.SessionManager.ClearSession();
            return Redirect("~/Home/Home");
        }

        public ActionResult AddtoCart(string cid,string pid)
        {
            ProductBO.addToCart(Convert.ToInt32(cid), Convert.ToInt32(pid));
            return Redirect("/Home/Checkout?c_id="+cid);
        }
        public ActionResult Checkout(string c_id)
        {
            List<int> Products_list = ProductBO.getProductsOfCustomerInCart(Convert.ToInt32(c_id));
            List<ProductDTO> list = new List<ProductDTO>();
            for (int i = 0; i < Products_list.Count;i++ )
            {
                list.Add(ProductBO.getProduct(Products_list[i]));
            }
                return View(list);
        }

        public ActionResult Wishlist(string c_id)
        {
            List<int> Products_list = ProductBO.getProductsOfCustomerInWishlist(Convert.ToInt32(c_id));
            List<ProductDTO> list = new List<ProductDTO>();
            for (int i = 0; i < Products_list.Count; i++)
            {
                list.Add(ProductBO.getProduct(Products_list[i]));
            }
            return View(list);
        }
        public ActionResult AddtoWishlist(string c_id,string p_id)
        {
            ProductBO.addToWishlist(Convert.ToInt32(c_id), Convert.ToInt32(p_id));
            return Redirect("/Home/Wishlist?c_id=" + c_id);
        }
        public ActionResult RemoveItemFromCart(string cid,string pid)
        {
            ProductBO.deleteProductFromCart(Convert.ToInt32(cid), Convert.ToInt32(pid));
            return Redirect("/Home/Checkout?c_id=" + cid);
        }
        public ActionResult RemoveItemFromWishlist(string cid, string pid)
        {
            ProductBO.deleteProductFromWishlist(Convert.ToInt32(cid), Convert.ToInt32(pid));
            return Redirect("/Home/Wishlist?c_id=" + cid);
        }
        public ActionResult AddFromWishlistToCart(string cid, string pid)
        {
            ProductBO.deleteProductFromWishlist(Convert.ToInt32(cid), Convert.ToInt32(pid));
            ProductBO.addToCart(Convert.ToInt32(cid), Convert.ToInt32(pid));
            return Redirect("/Home/Checkout?c_id=" + cid);
        }
        public ActionResult Account(string id)
        {
            if (SessionManager.Customer == null)
            {
                return Redirect("/Home/Home");
            }
            CustomerDTO dto = CustomerBO.getCustomerInfo(Convert.ToInt32(id));
            ArrayList list = new ArrayList();
            list.Add(dto.email);
            list.Add(dto.name);
            list.Add(dto.address);
            list.Add(dto.country);
            list.Add(dto.city);
            list.Add(dto.phone_no);
            list.Add(dto.gender);
            list.AddRange(CustomerBO.getAccountInfo(Convert.ToInt32(id)));
            list.Add(dto.password);
            return View(list);
        }
        public ActionResult AdminPanel(string id)
        {
            if(SessionManager.Customer==null)
            {
                return Redirect("/Home/Home");
            }
           
            return View();
        }
        public ActionResult DisplayAllItems(string category)
        {
            List<SW.Entities.ProductDTO> list = ProductBO.getProducts(category);
            ViewBag.Name = category;
            return View(list);
        }

        public ActionResult RemoveAllFromCart(string c_id)
        {
            ProductBO.deleteAllItemFromCart(Convert.ToInt32(c_id));
            return Redirect("/Home/Checkout?c_id=" + c_id);
        }


        public JsonResult Register(CustomerDTO dto)
        {
            Object data = null;
            try
            {
                var url = "";
                var flag = false;
                var message = "";

                var obj = SW.BAL.CustomerBO.Register(dto);
                if (obj != 0)
                {
                    flag = true;
                    url = Url.Content("~/Home/Home");
                    message = "Account Created Successfully";
                }

                data = new
                {
                    valid = flag,
                    urlToRedirect = url,
                    msg=message
                };

            }
            catch (Exception)
            {
                data = new
                {
                    valid = false,
                    urlToRedirect = "",
                    msg=""
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }

}