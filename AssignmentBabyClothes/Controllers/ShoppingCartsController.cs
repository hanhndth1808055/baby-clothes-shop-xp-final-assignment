using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignmentBabyClothes.Models;

namespace AssignmentBabyClothes.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private const string ShoppingCartName = "ShoppingCartName";

        // GET: ShoppingCart
        public ActionResult Index()
        {

            return View(GetShoppingCart());
        }

        private ShoppingCart GetShoppingCart()
        {
            ShoppingCart shoppingCart = null;
            if (Session[ShoppingCartName] != null)
            {
                try
                {
                    shoppingCart = Session[ShoppingCartName] as ShoppingCart;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
            }

            return shoppingCart;
        }

        // GET: ShoppingCart/Details/5
        public ActionResult AddToCart(int productId, int quantity)
        {
            var existingProduct = db.Products.FirstOrDefault(p => p.Id == productId);

            if (existingProduct == null)
            {
                return new HttpNotFoundResult();
            }

            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.Add(existingProduct, quantity, false);
            SetShoppingCart(shoppingCart);

            return RedirectToAction("Index");
        }

        private void SetShoppingCart(ShoppingCart shoppingCart)
        {
            Session[ShoppingCartName] = shoppingCart;
        }

        public ActionResult ClearShoppingCart()
        {
            Session[ShoppingCartName] = null;
            return View("Index", GetShoppingCart());
        }

        public ActionResult RemoveCartItem(int productId)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            shoppingCart.Delete(productId);
            SetShoppingCart(shoppingCart);
            return View("Index", GetShoppingCart());
        }

        public ActionResult RemoveOneItem(int productId)
        {
            ShoppingCart shoppingCart = GetShoppingCart();
            if (!shoppingCart.Items.ContainsKey(productId))
            {
                return View("Index", GetShoppingCart());

            }
            if (shoppingCart.Items[productId].Quantity > 1)
            {
                shoppingCart.Items[productId].Quantity--;
            }
            else if (shoppingCart.Items[productId].Quantity == 1)
            {
                RemoveCartItem(productId);
            }
            SetShoppingCart(shoppingCart);
            return View("Index", GetShoppingCart());
        }
    }
}