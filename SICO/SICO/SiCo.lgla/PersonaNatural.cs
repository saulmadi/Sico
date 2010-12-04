using System;
using System.Collections.Generic;
using System.Text;

namespace SiCo.lgla
{
    public class PersonaNatural : Entidad
    {

        #region Declaraciones
        private TipoIdentidad _TipoIdentidad = new TipoIdentidad();
        #endregion 

        #region Constructores

        public PersonaNatural():base()
        {
            ComandoSelect = "PersonaNatural_Buscar";
            ComandoMantenimiento = "PersonaNatural_Buscar";
            this.CambioId += new CambioIdEventArgs(PersonaNatural_CambioId); 
        }       

        #endregion

        #region Propiedades

        public int? Telefono
        {
            get;
            set;
        }

        public string Direccion
        {
            get;
            set;
        }

        public string correo
        {
            get;
            set;
        }

        public string  rtn
        {
            get;
            set;
        }

        public string nombre
        {
            get;
            set;
        }

        public string apellidos
        {
            get;
            set;
        }

        public string identidad
        {
            get;
            set;
        }

        public TipoIdentidad tipoidentidad
        {
            get { return _TipoIdentidad; }
            set {_TipoIdentidad= value ;}
        }

        #endregion

        #region Eventos

        void PersonaNatural_CambioId()
        {
            Buscar(this.Id.ToString(), string.Empty , string.Empty , string.Empty );
        }

        #endregion      

        #region Metodos

        public void Guardar()
        {   
            bool Accion= false;  

            Parametro[] parametro= { new Parametro("id",Id, System.Data.ParameterDirection.InputOutput),
                                   new Parametro("telefono",Telefono),
                                   new Parametro("direccion",Direccion),
                                   new Parametro("correo",correo),
                                   new Parametro("rtn",rtn),
                                   new Parametro("nombre",nombre),
                                   new Parametro("apellidos",apellidos),
                                   new Parametro("identidad",identidad),
                                   new Parametro("tipoidentidad",tipoidentidad.Valor ),
                                   new Parametro("usu",Usuario.Id),
                                   new Parametro("fmodif",fmodif),
                                   new Parametro("Accion",Accion)} ;
            
            this.Mantenimiento(ref parametro);

            foreach (Parametro i in parametro)
            {
                if (i.Nombre == "id")
                {
                    Id = Convert.ToInt32( i.Valor); 
                }
                if (i.Nombre == "Accion")
                {
                    Accion = Convert.ToBoolean(i.Valor);
                }
            }
            if (!Accion)
            {
                LlamadoErrores("El registro de Persona Natural no se pudo registrar en el servidor");
            }
              

        }

        public void Buscar(string  id, string nombrecompleto, string identidad, string rtn )
        {
            Parametro[] parametros = { new Parametro("id",id),
                                      new Parametro("nombrecompleto",nombrecompleto),
                                      new Parametro("identidad",identidad),
                                      new Parametro("rtn",rtn) };
            LlenadoTabla(parametros);
            this.CargadoValores();  
 
        }

        protected override  void CargadoValores()
        {
            if (this.TotalRegistros > 0)
            {
                base.CargadoValores();
                Telefono = (int)PrimerRegistro("telefono");
                nombre = PrimerRegistro("nombre").ToString();
                apellidos = PrimerRegistro("apellidos").ToString();
                identidad = PrimerRegistro("identidad").ToString();
                Direccion = PrimerRegistro("direccion").ToString();
                correo = PrimerRegistro("correo").ToString();
                rtn = (string)PrimerRegistro("RTN");

                if (PrimerRegistro("TipoIdentidad").ToString() == "I")
                    tipoidentidad = new TipoIdentidad("Identidad", PrimerRegistro("TipoIdentidad").ToString());
                else
                    tipoidentidad = new TipoIdentidad("Pasaporte", PrimerRegistro("TipoIdentidad").ToString());
            }

 
        }

        #endregion

    }
}
