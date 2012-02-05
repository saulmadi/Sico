using System;
using NUnit.Framework;
using SicoWeb.Aplicacion.ServiceLayer.Helpers;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento.Entidades;
using SicoWeb.Dominio.Core.Entidades;
using SicoWeb.Aplicacion.ServiceLayer.Mantenimiento;
using SicoWeb.Dominio.Core.Entidades.Mantenimientos;

namespace SicoWeb.Aplicacion.ServiceLayer.Test
{
    [TestFixture]
    public class HelpersTestToEntiServicio
    {
        [TestCase(2,"2/12/2011",1)]
        public void ToEntidadServicio(int id,string fmodif, int usu )
        {
            var entidad = new FakeEntibase {Id = id, Fmodif =Convert.ToDateTime(fmodif), Usu = usu};
            var entidadServicio = entidad.ToEntidadServicio<FakeEntidadServicio>();

            Assert.AreEqual(id, entidadServicio.Id);
            Assert.AreEqual(Convert.ToDateTime(fmodif), entidadServicio.Fmodif);
            Assert.AreEqual(usu, entidadServicio.Usu);
        }

       
        [TestCase(2, "2/12/2011", 1)]
        public void ToEntiBase(int id, string fmodif, int usu)
        {
            var entidad = new FakeEntidadServicio { Id = id, Fmodif = Convert.ToDateTime(fmodif), Usu = usu };
            var entiBase = entidad.ToEntiBase<FakeEntibase>();

            Assert.AreEqual(id, entiBase.Id);
            Assert.AreEqual(Convert.ToDateTime(fmodif), entiBase.Fmodif);
            Assert.AreEqual(usu, entiBase.Usu);
        }

        [TestCase(2, "2/12/2011", 1,"Descripcion",true)]
        [TestCase(2, "2/12/2011", 1, "Descripcion", false)]
        public void ToEntiMantenimiento(int id, string fmodif, int usu,string descripcion, bool habilitado)
        {

            var entidadSevicio = new FakeEntidadServicioMantenimiento
                                     {
                                         Descripcion = descripcion,
                                         Fmodif = Convert.ToDateTime(fmodif),
                                         Habilitado = habilitado,
                                         Id = id,
                                         Usu = usu
                                     };
            var entiMantenimiento = entidadSevicio.ToEntiMantenimientos<FakeEntiMantenimientos>();

            Assert.AreEqual(id, entiMantenimiento.Id);
            Assert.AreEqual(Convert.ToDateTime(fmodif), entiMantenimiento.Fmodif);
            Assert.AreEqual(usu, entiMantenimiento.Usu);
            Assert.AreEqual(descripcion, entiMantenimiento.Descripcion);
            Assert.AreEqual(habilitado, entiMantenimiento.Habilitado);

        }

        [TestCase(2, "2/12/2011", 1, "Descripcion", true)]
        [TestCase(2, "2/12/2011", 1, "Descripcion", false)]
        public void ToEntidadServiciosMantenimientos(int id, string fmodif, int usu, string descripcion, bool habilitado)
        {

            var entiMantenimientos = new FakeEntiMantenimientos
            {
                Descripcion = descripcion,
                Fmodif = Convert.ToDateTime(fmodif),
                Habilitado = habilitado,
                Id = id,
                Usu = usu
            };
            var entidadServicioMantenimiento =
                entiMantenimientos.ToEntidadServicioMantenimiento<FakeEntidadServicioMantenimiento>();

            Assert.AreEqual(id, entidadServicioMantenimiento.Id);
            Assert.AreEqual(Convert.ToDateTime(fmodif), entidadServicioMantenimiento.Fmodif);
            Assert.AreEqual(usu, entidadServicioMantenimiento.Usu);
            Assert.AreEqual(descripcion, entidadServicioMantenimiento.Descripcion);
            Assert.AreEqual(habilitado, entidadServicioMantenimiento.Habilitado);

        }
    }

    public class FakeEntibase:IEntiBase
    {
        public int Id { get; set; }
        public int Usu { get; set; }
        public DateTime Fmodif { get; set; }
    }
    public class FakeEntidadServicio:IEntidadServicio
    {
        public int Id { get; set; }
        public int Usu { get; set; }
        public DateTime Fmodif { get; set; }
    }

    public class FakeEntidadServicioMantenimiento:IEntidadServicioMantenimiento
    {
        public int Id { get; set; }
        public int Usu { get; set; }
        public DateTime Fmodif { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
    public class FakeEntiMantenimientos:IEntiMantenimientos
    {
        public int Id { get; set; }
        public int Usu { get; set; }
        public DateTime Fmodif { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}