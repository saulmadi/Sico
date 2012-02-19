
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SicoWeb.Aplicacion.ServiceLayer;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Servicios;

namespace SicoWeb.Plumbing
{
    public abstract class ControllerMantenimientos<T> : ControllerBase<T> where T:IEntidadServicioMantenimiento 
    {
        private readonly IServicioMantenimiento<T> _servicio;

        protected ControllerMantenimientos(IServicioMantenimiento<T> servicio )
        {
            _servicio = servicio;
            Editable = true;
            Eliminable = true;
            Agregable = true;
        }

        
#region Propiedades
        public bool Editable
        {
            get { return (bool)ViewData[ViewDataVariables.MantenimientoEditable]; }
            set { ViewData[ViewDataVariables.MantenimientoEditable] = value; }
        }

        public bool Eliminable
        {
            get { return (bool)ViewData[ViewDataVariables.MantenimientoEditable]; }
            set { ViewData[ViewDataVariables.MantenimientoEditable] = value; }
        }

        public bool Agregable
        {
            get { return (bool)ViewData[ViewDataVariables.MantenimientoAgregable]; }
            set { ViewData[ViewDataVariables.MantenimientoAgregable] = value; }
        }

        public override string SubTitleMenu()
        {
            return "Administrativo";
        }

        public override IEnumerable<IEntidadServicio> SubMenuItems()
        {
            return new List<IEntidadServicio>();
        }
#endregion 
        


        public ActionResult Index()
        {
            var lista = _servicio.GetTodos();
            return View(lista);
        }


        //
        // GET: /TiposFacturas/Create
        
        public ActionResult Create()
        {

            return PartialView();
        }

        //
        // POST: /TiposFacturas/Create
        
        [HttpPost]
        public ActionResult Create(T entidadServicioMantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicio.AgregarMantenimiento(entidadServicioMantenimiento);
                    ActionResult view;
                    if (ActionResult(entidadServicioMantenimiento, out view)) return view;

                    Message = "Creado Correctamente";
                    return Content(Boolean.TrueString );
                }
                return Content("Revise el formulario" );
            }
            catch (SiCoWebAplicattionException ex)
            {
                ErrorMessage = ex.Message;
                return PartialView();
            }
        }

        private bool ActionResult(T entidadServicioMantenimiento, out ActionResult view)
        {
            if (_servicio.HasError())
            {
                _servicio.Errores.ForEach(c => ErrorMessage  =  c.ToString());
                {
                    view = PartialView(entidadServicioMantenimiento);
                    return true;
                }
            }
            view = null;
            return false;
        }

        //
        // GET: /TiposFacturas/Edit/5

        public ActionResult Edit(int id)
        {
            var tipo = _servicio.GetById(id);
            return View(tipo);
        }

        //
        // POST: /TiposFacturas/Edit/5

        [HttpPost]
        public ActionResult Edit(T entidadServicioMantenimiento)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _servicio.AgregarMantenimiento(entidadServicioMantenimiento);
                    ActionResult view;
                    if (ActionResult(entidadServicioMantenimiento, out view)) return view;

                    Message = "Guardado Correctamente";
                    return RedirectToAction("Index");
                }
                return View(entidadServicioMantenimiento);
            }
            catch (SiCoWebAplicattionException ex)
            {
                ErrorMessage = ex.Message;
                return View(entidadServicioMantenimiento);
            }
        }

    }
}