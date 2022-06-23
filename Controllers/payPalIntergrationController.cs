using Microsoft.AspNetCore.Mvc;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
namespace VisionStore.Controllers
{
    public class payPalIntergrationController : Controller
    {
        #region ClientId_ClientSecret
        private string _paypalEnvironment = "sandbox";
        private string _clientId = "ATl6zaxuHp8rCIa - der0seGwLWooOHXk_ZnoL7e46 - 4esc5Y6cO1waxr2ZIydPkJm4CwTlpMLIULekzD";
        private string _secret= "EBJv8U4V0rGC6yIHIVBmy6WcZLTZ4B5MjOadDI7PNeYpurHWLDB1GnRgrr4mRbCH0ceyiGN1zA411zTC";
        #endregion
        public IActionResult Index()
        {
            return View();
        }

    }
}
