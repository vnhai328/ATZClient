using ATZClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATZClient.Controllers
{
    public class HomeController : Controller
    {
        ClientDBContext db = new ClientDBContext();
        public ActionResult ViewCart()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Header() 
       {
            var model = db.tblHeaders.FirstOrDefault();
            return PartialView(model);
       }
       public ActionResult HeaderMenu() 
       {
            var model = db.tblMenus.Where(x => x.Status == "1").OrderBy(x => x.ID).ToList();
            return PartialView(model); 
       }
        public ActionResult Slider() 
        {
            var model = db.tblSliders.Where(x => x.Status == 1).Take(3).ToList();
            return PartialView(model);
        }
        public ActionResult PopularProduct()
        {
            var model = (from a in db.tblProducts
                         join b in db.tblProductPrices
                         on a.ProductID equals b.ProductID
                         select new
                         {
                             ID = a.ProductID,
                             ImageUrl = a.ImageUrl,
                             Name = a.Name,
                             Price = b.Price,
                             PriceSale = b.PriceSale,
                             Color = a.Color
                         }).ToList();
            List<ProductView> _IsProduct = new List<ProductView>();
            if (model != null && model.Count > 0) 
            {
                foreach(var item in model)
                {
                    ProductView _productView = new ProductView();
                    _productView._Product = new tblProduct();
                    _productView._ProductPrice = new tblProductPrice();

                    _productView._Product.ProductID = item.ID;
                    _productView._Product.Name = item.Name;
                    _productView._Product.ImageUrl = item.ImageUrl;
                    _productView._ProductPrice.Price = item.Price;
                    _productView._ProductPrice.PriceSale = item.PriceSale;
                    _productView._Product.Color = item.Color;
                    _IsProduct.Add(_productView);
                }
            }
            return PartialView(_IsProduct);
        }
        public ActionResult AddCart(int ID, string ImageUrl, string Price, string Name, string Color) 
        {
            decimal Total = 0;
            var lstItem = new List<CartItem>();
            Session["TotalProduct"] = 0;
            //kiem tra gio hang co null k?
            if (Session["Cart"] == null) 
            {
                //them moi
                var item = new CartItem();
                item.ID = ID;
                item.ImageUrl = ImageUrl;
                item.Price = Convert.ToDecimal(Price);
                item.Name = Name;
                item.Color = Color;
                lstItem.Add(item);
                Session["Cart"] = lstItem;
                item.Quantily = 1;               
                Session["TotalMoney"] = item.Price * item.Quantily;
                Session["TotalProduct"] = 1;
                Total = 1;
            }
            else
            {
                //kiem tra sp
                //so luong
                //them moi
                bool bCheck = false;
                lstItem = (List<CartItem>)Session["Cart"];
                foreach(var item in lstItem)
                {
                    if (item.ID == ID)
                    {
                        item.Quantily = item.Quantily + 1;
                        bCheck = true;
                        break;
                    }                   
                }
                if (bCheck == false)
                {
                    var item = new CartItem();
                    item.ID = ID;
                    item.ImageUrl = ImageUrl;
                    item.Price = Convert.ToDecimal(Price);
                    item.Name = Name;
                    lstItem.Add(item);
                    Session["Cart"] = lstItem;
                    item.Quantily = 1;
                }
                Session["Cart"] = lstItem;
                
                foreach (var item in lstItem)
                {
                    Total = Total + item.Quantily * item.Price;
                }
                Session["TotalProduct"] = lstItem.Count;
                Session["TotalMoney"] = Total;
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult RemoveCart(int ID)
        {
            decimal Total = 0;
            var lstItem = (List<CartItem>)Session["Cart"];
            foreach (var item in lstItem)
            {
                if (item.ID == ID)
                {
                    lstItem.Remove(item);
                    item.Quantily = item.Quantily - 1;
                    break;
                }
            }
            Session["Cart"] = lstItem;
            foreach (var item in lstItem)
            {
                Total = Total + item.Quantily * item.Price;
            }
            Session["TotalProduct"] = lstItem.Count;
            Session["TotalMoney"] = Total;
            return RedirectToAction("Index", "Home");
        }
        public JsonResult Login(string ID, string Password) 
        {
            var item = db.tblAccounts.Where(x => x.Account == ID && x.Password == Password).FirstOrDefault();
            if (item != null)
            {
                //var item = new tblAccount();
                item.Account = ID;
                item.Status = 1;
                Session["UserLogin"] = item;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                Session["UserLogin"] = null;
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult LocalStorage()
        {
            var model = (from a in db.tblProducts
                         join b in db.tblProductPrices
                         on a.ProductID equals b.ProductID
                         select new
                         {
                             ID = a.ProductID,
                             ImageUrl = a.ImageUrl,
                             Name = a.Name,
                             Price = b.Price,
                             PriceSale = b.PriceSale,
                             Color = a.Color
                         }).ToList();
            List<ProductView> _IsProduct = new List<ProductView>();
            if (model != null && model.Count > 0)
            {
                foreach (var item in model)
                {
                    ProductView _productView = new ProductView();
                    _productView._Product = new tblProduct();
                    _productView._ProductPrice = new tblProductPrice();

                    _productView._Product.ProductID = item.ID;
                    _productView._Product.Name = item.Name;
                    _productView._Product.ImageUrl = item.ImageUrl;
                    _productView._ProductPrice.Price = item.Price;
                    _productView._ProductPrice.PriceSale = item.PriceSale;
                    _productView._Product.Color = item.Color;
                    _IsProduct.Add(_productView);
                }
            }
            return PartialView(_IsProduct);
        }
    }
}