using System.Collections.Generic;
using System.Web.Mvc;
using Castle.Core.Logging;
using SicoWeb.Aplicacion.ServiceLayer;

namespace SicoWeb.Plumbing
{
    public abstract class ControllerBase<TEnti> : Controller, IAbstractController<TEnti> where TEnti : IEntidadServicio
    {
        public abstract string Title();
        public  abstract string SubTitleMenu();
        public abstract IEnumerable<IEntidadServicio> SubMenuItems(); 
       

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.Title = Title();
            ViewBag.SubTitleMenu = SubTitleMenu();
            ViewData["SubMenuItmes"] = SubMenuItems(); 
            base.OnActionExecuted(filterContext);
        }

        
        public ILogger Logger { get; set; }

        public virtual string GetControllerName()
        {
            return GetType().Name.Replace("Controller", "");
        }


      
        public virtual void AppendMetaDescription(string text)
        {
            ViewData["MetaDescription"] = text;
        }

        public string Message
        {
            get { return TempData["message"] as string; }
            set { TempData["message"] = value; }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Response.Clear();
            base.OnException(filterContext);
        }
     
    }
}