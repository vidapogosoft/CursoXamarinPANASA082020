using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiOauth2.Controllers
{
    public class HomeController : Controller
    {
        #region Index method.

        /// <summary>
        /// Index method.
        /// </summary>
        /// <returns>Returns - Index view</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        #endregion
    }
}