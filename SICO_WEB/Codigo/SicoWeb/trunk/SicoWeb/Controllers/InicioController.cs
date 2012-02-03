using System.Web.Mvc;

namespace SicoWeb.Controllers
{
    public partial class InicioController : Controller
    {

        public virtual ActionResult Index()
        {
           return View();
        }

        
    }
}
