namespace SiCo.lgla
{
    public abstract class Entidades : Entidad
    {
        #region Declaraciones

        protected bool _espersonanatural = true;

        #endregion

        #region Constructores

        public Entidades()
        {
            ComandoMantenimiento = "Entidades_Mant";

            ColeccionParametrosMantenimiento.Add(new Parametro("telefono", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("direccion", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("correo", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("espersonanatural", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("rtn", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("entidadnombre", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("identificacion", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("tipoIdentidad", null));
            ColeccionParametrosMantenimiento.Add(new Parametro("telefono2", null));
            TablaEliminar = "entidades";
        }

        #endregion

        #region Propiedades

        public int? telefono { get; set; }

        public string direccion { get; set; }

        public string correo { get; set; }

        public string rtn { get; set; }

        public int? telefono2 { get; set; }

        public bool espersonanatural
        {
            get { return _espersonanatural; }
        }

        #endregion

        #region Metodos

        protected override void CargadoPropiedades(int indice)
        {
            if (TotalRegistros > 0)
            {
                telefono = (int?) Registro(indice, "telefono");
                direccion = (string) Registro(indice, "direccion");
                correo = (string) Registro(indice, "correo");
                rtn = (string) Registro(indice, "RTN");
                telefono2 = (int?) Registro(indice, "telefono2");
                base.CargadoPropiedades(indice);
            }
        }

        public override void Guardar()
        {
            ValorParametrosMantenimiento("telefono", telefono);
            ValorParametrosMantenimiento("direccion", direccion);
            ValorParametrosMantenimiento("correo", correo);
            ValorParametrosMantenimiento("rtn", rtn);
            ValorParametrosMantenimiento("espersonanatural", espersonanatural);
            ValorParametrosMantenimiento("telefono2", telefono2);
            base.Guardar();
        }

        #endregion
    }
}