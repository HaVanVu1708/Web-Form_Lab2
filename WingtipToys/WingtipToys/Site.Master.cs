using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Logic;
using WingtipToys.Models;
using Microsoft.AspNet.Identity;


namespace WingtipToys
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        //{
        //    Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //}
        public IQueryable<Category> GetCategories()
        {
            var _db = new WingtipToys.Models.ProductContext();
            IQueryable<Category> query = _db.Categories;
            return query;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (ShippingCartAction usersShoppingCart = new ShippingCartAction())
            {
                string cartStr = string.Format("Cart ({0})", usersShoppingCart.GetCount());
                cartCount.InnerText = cartStr;
            }
        }

    }
}