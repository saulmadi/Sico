-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.1.51-community


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema sico
--

CREATE DATABASE IF NOT EXISTS sico;
USE sico;

--
-- Temporary table structure for view `personasjuridicas`
--
DROP TABLE IF EXISTS `personasjuridicas`;
DROP VIEW IF EXISTS `personasjuridicas`;
CREATE TABLE `personasjuridicas` (
  `RazonSocial` varchar(120),
  `telefono` int(11),
  `direccion` varchar(150),
  `correo` varchar(45),
  `RTN` varchar(14),
  `id` int(11)
);

--
-- Temporary table structure for view `personasnaturales`
--
DROP TABLE IF EXISTS `personasnaturales`;
DROP VIEW IF EXISTS `personasnaturales`;
CREATE TABLE `personasnaturales` (
  `telefono` int(11),
  `direccion` varchar(150),
  `correo` varchar(45),
  `RTN` varchar(14),
  `usu` int(11),
  `fmodif` date,
  `NombreCompleto` varchar(120),
  `identificacion` varchar(20),
  `tipoidentidad` varchar(1),
  `id` int(11)
);

--
-- Definition of table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE `clientes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identidades` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Entidad_Unica` (`identidades`),
  KEY `fk_Clientes_Entidades1` (`identidades`),
  CONSTRAINT `fk_Clientes_Entidades1` FOREIGN KEY (`identidades`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `clientes`
--

/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;


--
-- Definition of table `departamentos`
--

DROP TABLE IF EXISTS `departamentos`;
CREATE TABLE `departamentos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `departamento` varchar(45) NOT NULL,
  `habilitados` tinyint(1) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `departamentos`
--

/*!40000 ALTER TABLE `departamentos` DISABLE KEYS */;
/*!40000 ALTER TABLE `departamentos` ENABLE KEYS */;


--
-- Definition of table `entidades`
--

DROP TABLE IF EXISTS `entidades`;
CREATE TABLE `entidades` (
  `id` int(11) NOT NULL,
  `telefono` int(11) DEFAULT NULL,
  `direccion` varchar(150) DEFAULT NULL,
  `correo` varchar(45) DEFAULT NULL,
  `espersonanatural` tinyint(1) NOT NULL,
  `RTN` varchar(14) DEFAULT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  `entidadnombre` varchar(120) NOT NULL,
  `identificacion` varchar(20) DEFAULT NULL,
  `tipoidentidad` varchar(1) DEFAULT NULL COMMENT 'I identidad, P pasaporte',
  PRIMARY KEY (`id`),
  UNIQUE KEY `NombreUnico` (`entidadnombre`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `entidades`
--

/*!40000 ALTER TABLE `entidades` DISABLE KEYS */;
/*!40000 ALTER TABLE `entidades` ENABLE KEYS */;


--
-- Definition of table `facturadetalle`
--

DROP TABLE IF EXISTS `facturadetalle`;
CREATE TABLE `facturadetalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idfacturaencabezado` int(11) NOT NULL,
  `idproductos` int(11) NOT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `precioventa` decimal(10,4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `factura_Productos` (`idfacturaencabezado`,`idproductos`),
  KEY `fk_FacturaDetalle_FacturaEncabezado1` (`idfacturaencabezado`),
  KEY `fk_FacturaDetalle_Productos1` (`idproductos`),
  CONSTRAINT `fk_FacturaDetalle_FacturaEncabezado1` FOREIGN KEY (`idfacturaencabezado`) REFERENCES `facturaencabezado` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_FacturaDetalle_Productos1` FOREIGN KEY (`idproductos`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturadetalle`
--

/*!40000 ALTER TABLE `facturadetalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `facturadetalle` ENABLE KEYS */;


--
-- Definition of table `facturaencabezado`
--

DROP TABLE IF EXISTS `facturaencabezado`;
CREATE TABLE `facturaencabezado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idsucursales` int(11) NOT NULL,
  `numerofactura` int(11) DEFAULT NULL,
  `idclientes` int(11) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `idtiposfacturas` int(11) NOT NULL,
  `total` decimal(10,4) NOT NULL,
  `isv` decimal(10,4) NOT NULL,
  `subtotal` decimal(10,4) NOT NULL,
  `descuentovalor` decimal(10,4) DEFAULT NULL,
  `descuento` int(11) DEFAULT NULL,
  `ventaexenta` tinyint(1) DEFAULT NULL,
  `enproceso` tinyint(1) DEFAULT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `numeroFactura_Suscursal` (`numerofactura`,`idsucursales`),
  KEY `fk_FacturaEncabezado_Sucursales1` (`idsucursales`),
  KEY `fk_FacturaEncabezado_Clientes1` (`idclientes`),
  KEY `fk_FacturaEncabezado_Tiposfacturas1` (`idtiposfacturas`),
  CONSTRAINT `fk_FacturaEncabezado_Clientes1` FOREIGN KEY (`idclientes`) REFERENCES `clientes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_FacturaEncabezado_Sucursales1` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_FacturaEncabezado_Tiposfacturas1` FOREIGN KEY (`idtiposfacturas`) REFERENCES `tiposfacturas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturaencabezado`
--

/*!40000 ALTER TABLE `facturaencabezado` DISABLE KEYS */;
/*!40000 ALTER TABLE `facturaencabezado` ENABLE KEYS */;


--
-- Definition of table `facturasnumeros`
--

DROP TABLE IF EXISTS `facturasnumeros`;
CREATE TABLE `facturasnumeros` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idsucursales` int(11) NOT NULL,
  `numerofactura` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idsucursales_UNIQUE` (`idsucursales`),
  KEY `fk_FacturasNumeros_Sucursales1` (`idsucursales`),
  CONSTRAINT `fk_FacturasNumeros_Sucursales1` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturasnumeros`
--

/*!40000 ALTER TABLE `facturasnumeros` DISABLE KEYS */;
/*!40000 ALTER TABLE `facturasnumeros` ENABLE KEYS */;


--
-- Definition of table `inventario`
--

DROP TABLE IF EXISTS `inventario`;
CREATE TABLE `inventario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idproductos` int(11) NOT NULL,
  `idsucursales` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `usu` int(11) DEFAULT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Productos_Sucursal` (`idproductos`,`idsucursales`),
  KEY `fk_Inventario_Productos1` (`idproductos`),
  KEY `fk_Inventario_Sucursales1` (`idsucursales`),
  CONSTRAINT `fk_Inventario_Productos1` FOREIGN KEY (`idproductos`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Inventario_Sucursales1` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventario`
--

/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
/*!40000 ALTER TABLE `inventario` ENABLE KEYS */;


--
-- Definition of table `marcas`
--

DROP TABLE IF EXISTS `marcas`;
CREATE TABLE `marcas` (
  `id` int(11) NOT NULL,
  `marca` varchar(45) NOT NULL,
  `habilitado` tinyint(1) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `marcas`
--

/*!40000 ALTER TABLE `marcas` DISABLE KEYS */;
/*!40000 ALTER TABLE `marcas` ENABLE KEYS */;


--
-- Definition of table `modelos`
--

DROP TABLE IF EXISTS `modelos`;
CREATE TABLE `modelos` (
  `id` int(11) NOT NULL,
  `modelo` varchar(45) NOT NULL,
  `habilitado` tinyint(1) NOT NULL,
  `idmarca` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Modelos_Marcas1` (`idmarca`),
  CONSTRAINT `fk_Modelos_Marcas1` FOREIGN KEY (`idmarca`) REFERENCES `marcas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `modelos`
--

/*!40000 ALTER TABLE `modelos` DISABLE KEYS */;
/*!40000 ALTER TABLE `modelos` ENABLE KEYS */;


--
-- Definition of table `motocicletas`
--

DROP TABLE IF EXISTS `motocicletas`;
CREATE TABLE `motocicletas` (
  `id` int(11) NOT NULL,
  `motor` varchar(45) NOT NULL,
  `chasis` varchar(45) NOT NULL,
  `idmarcas` int(11) NOT NULL,
  `idmodelos` int(11) NOT NULL,
  `idtiposmotocicletas` int(11) NOT NULL,
  `idsucurasales` int(11) NOT NULL,
  `cilindraje` int(11) NOT NULL,
  `anio` int(11) NOT NULL,
  `precioventa` decimal(10,4) NOT NULL,
  `preciocompra` decimal(10,4) NOT NULL,
  `fechaIngreso` date DEFAULT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `motor_UNIQUE` (`motor`),
  UNIQUE KEY `chasis_UNIQUE` (`chasis`),
  KEY `fk_Motocicletas_Marcas1` (`idmarcas`),
  KEY `fk_Motocicletas_Modelos1` (`idmodelos`),
  KEY `fk_Motocicletas_TiposMotocicletas1` (`idtiposmotocicletas`),
  KEY `fk_Motocicletas_Sucursales1` (`idsucurasales`),
  CONSTRAINT `fk_Motocicletas_Marcas1` FOREIGN KEY (`idmarcas`) REFERENCES `marcas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Motocicletas_Modelos1` FOREIGN KEY (`idmodelos`) REFERENCES `modelos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Motocicletas_Sucursales1` FOREIGN KEY (`idsucurasales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Motocicletas_TiposMotocicletas1` FOREIGN KEY (`idtiposmotocicletas`) REFERENCES `tiposmotocicletas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `motocicletas`
--

/*!40000 ALTER TABLE `motocicletas` DISABLE KEYS */;
/*!40000 ALTER TABLE `motocicletas` ENABLE KEYS */;


--
-- Definition of table `motocicletasimagenes`
--

DROP TABLE IF EXISTS `motocicletasimagenes`;
CREATE TABLE `motocicletasimagenes` (
  `id` int(11) NOT NULL,
  `imagen` longblob,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Motocicletas_Imagenes` (`id`),
  CONSTRAINT `Motocicletas_Imagenes` FOREIGN KEY (`id`) REFERENCES `motocicletas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `motocicletasimagenes`
--

/*!40000 ALTER TABLE `motocicletasimagenes` DISABLE KEYS */;
/*!40000 ALTER TABLE `motocicletasimagenes` ENABLE KEYS */;


--
-- Definition of table `municipio`
--

DROP TABLE IF EXISTS `municipio`;
CREATE TABLE `municipio` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `municipio` varchar(45) NOT NULL,
  `iddepartamento` int(11) NOT NULL,
  `habilitado` tinyint(1) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Municipio_Departamentos1` (`iddepartamento`),
  CONSTRAINT `fk_Municipio_Departamentos1` FOREIGN KEY (`iddepartamento`) REFERENCES `departamentos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `municipio`
--

/*!40000 ALTER TABLE `municipio` DISABLE KEYS */;
/*!40000 ALTER TABLE `municipio` ENABLE KEYS */;


--
-- Definition of table `productos`
--

DROP TABLE IF EXISTS `productos`;
CREATE TABLE `productos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(45) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `idproveedor` int(11) DEFAULT NULL,
  `preciocosto` decimal(10,4) NOT NULL,
  `precioventa` decimal(10,4) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Id_Proveedor` (`idproveedor`),
  CONSTRAINT `Id_Proveedor` FOREIGN KEY (`idproveedor`) REFERENCES `proveedores` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `productos`
--

/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;


--
-- Definition of table `productosimagenes`
--

DROP TABLE IF EXISTS `productosimagenes`;
CREATE TABLE `productosimagenes` (
  `id` int(11) NOT NULL,
  `imagen` longblob,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Producto_Imagenes` (`id`),
  CONSTRAINT `Producto_Imagenes` FOREIGN KEY (`id`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `productosimagenes`
--

/*!40000 ALTER TABLE `productosimagenes` DISABLE KEYS */;
/*!40000 ALTER TABLE `productosimagenes` ENABLE KEYS */;


--
-- Definition of table `proveedores`
--

DROP TABLE IF EXISTS `proveedores`;
CREATE TABLE `proveedores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identidades` int(11) NOT NULL,
  `idcontacto` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Contactos_Entidades` (`idcontacto`),
  KEY `Proveedores_Entidades` (`identidades`),
  CONSTRAINT `Proveedores_Entidades` FOREIGN KEY (`identidades`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Contactos_Entidades` FOREIGN KEY (`idcontacto`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proveedores`
--

/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;


--
-- Definition of table `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `id` int(11) NOT NULL,
  `rol` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `roles`
--

/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;


--
-- Definition of table `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
CREATE TABLE `sucursales` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identidades` int(11) NOT NULL,
  `idusuario` int(11) DEFAULT NULL COMMENT 'Administrador de la Sucursal',
  `idmunicipio` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Sucursales_Entidades1` (`identidades`),
  KEY `fk_Sucursales_Usuarios1` (`idusuario`),
  KEY `fk_Sucursales_Municipio1` (`idmunicipio`),
  CONSTRAINT `fk_Sucursales_Entidades1` FOREIGN KEY (`identidades`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Sucursales_Municipio1` FOREIGN KEY (`idmunicipio`) REFERENCES `municipio` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Sucursales_Usuarios1` FOREIGN KEY (`idusuario`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sucursales`
--

/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;


--
-- Definition of table `tiposfacturas`
--

DROP TABLE IF EXISTS `tiposfacturas`;
CREATE TABLE `tiposfacturas` (
  `id` int(11) NOT NULL,
  `Tipo` varchar(45) DEFAULT NULL,
  `habilitado` tinyint(1) DEFAULT NULL,
  `usu` int(11) DEFAULT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tiposfacturas`
--

/*!40000 ALTER TABLE `tiposfacturas` DISABLE KEYS */;
/*!40000 ALTER TABLE `tiposfacturas` ENABLE KEYS */;


--
-- Definition of table `tiposmotocicletas`
--

DROP TABLE IF EXISTS `tiposmotocicletas`;
CREATE TABLE `tiposmotocicletas` (
  `id` int(11) NOT NULL,
  `tipo` varchar(45) NOT NULL,
  `habilitado` tinyint(1) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tiposmotocicletas`
--

/*!40000 ALTER TABLE `tiposmotocicletas` DISABLE KEYS */;
/*!40000 ALTER TABLE `tiposmotocicletas` ENABLE KEYS */;


--
-- Definition of table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identidad` int(11) NOT NULL,
  `contrasena` varchar(30) NOT NULL,
  `idrol` int(11) NOT NULL,
  `usuario` varchar(45) NOT NULL,
  `estado` tinyint(1) NOT NULL,
  `idsucursales` int(11) DEFAULT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `InicioSesion` (`usuario`),
  UNIQUE KEY `Entidad` (`identidad`),
  KEY `Usuarios_Entidad` (`identidad`),
  KEY `Usuarios_Roles` (`idrol`),
  KEY `fk_Usuarios_Sucursales1` (`idsucursales`),
  CONSTRAINT `Usuarios_Entidad` FOREIGN KEY (`identidad`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Usuarios_Roles` FOREIGN KEY (`idrol`) REFERENCES `roles` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuarios_Sucursales1` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usuarios`
--

/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;


--
-- Definition of procedure `Clientes_Buscar`
--

DROP PROCEDURE IF EXISTS `Clientes_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Clientes_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
identidades nvarchar(11)
)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from clientes ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if identidades<>"" then
  set @where = concat(@where, " and identidades = ",identidades," ");
end if;

set @sql = concat(@campos,@from,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Clientes_Mant`
--

DROP PROCEDURE IF EXISTS `Clientes_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Clientes_Mant`(

/*definicion de parametros*/

inout id int,
identidades int,
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(c.id) from clientes c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO clientes(identidades,usu,fmodif)

  VALUES(identidades,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE clientes c set
        c.identidades= identidades,
        c.usu=usu,
        c.fmodif=fmodif
  where e.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Entidades_Mant`
--

DROP PROCEDURE IF EXISTS `Entidades_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Entidades_Mant`(

/*definicion de parametros*/

inout id int,
telefono int,
direccion varchar(150),
correo varchar (45),
espersonanatural bool,
rtn varchar(18),
entidadnombre varchar(120),
identificacion varchar(20),
tipoidentidad varchar(1),
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(e.id) from entidades E where E.id=id into @conteo;

if @conteo =0 then

  INSERT INTO entidades(telefono, direccion,correo,espersonanatural, RTN, usu,fmodif,entidadnombre,identificacion,tipoidentidad)

  VALUES(telefono,direccion,correo,espersonanatural,rtn,usu,fmodif,entidadnombre,identificacion,tipoidentidad);

  select last_insert_id() into id;

else

  UPDATE entidades e SET
        e.telefono=telefono,
        e.direccion=direccion,
        e.correo=correo,
        e.espersonanatural= espersonanatural,
        e.RTN= rtn,
        e.usu=usu,
        e.fmodif= fmodif,
        e.entidadnombre=entidadnombre,
        e.identificacion=identificacion,
        e.tipoidentidad=identificacion
  where e.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `PersonaJuridica_Buscar`
--

DROP PROCEDURE IF EXISTS `PersonaJuridica_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PersonaJuridica_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
razonsocial nvarchar(125),
rtn nvarchar(18)
)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by razonsocial ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from personasjuridicas ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if razonsocial<>"" then
  set @where = concat(@where, " and razonsocial like '",razonsocial, "%' ");
end if;


if rtn<>"" then
  set @where = concat(@where, " and rtn = '",rtn,"' ");
end if;

set @sql = concat(@campos,@from,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `PersonaNatural_Buscar`
--

DROP PROCEDURE IF EXISTS `PersonaNatural_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PersonaNatural_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
nombrecompleto nvarchar(125),
identificacion nvarchar(45),
rtn nvarchar(18) 

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by NombreCompleto ";
set @sql="";

set @campos= concat( @campos," * ");


set @from= concat(@from," from personasnaturales ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if nombrecompleto<>"" then
  set @where = concat(@where, " and NombreCompleto like '",nombrecompleto, "%' ");
end if;

if identificacion<>"" then
  set @where = concat(@where, " and identificacion = '",identificacion,"' ");
end if;

if rtn<>"" then
  set @where = concat(@where, " and rtn = '",rtn,"´' ");
end if;



set @sql = concat(@campos,@from,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of view `personasjuridicas`
--

DROP TABLE IF EXISTS `personasjuridicas`;
DROP VIEW IF EXISTS `personasjuridicas`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `personasjuridicas` AS select `entidades`.`entidadnombre` AS `RazonSocial`,`entidades`.`telefono` AS `telefono`,`entidades`.`direccion` AS `direccion`,`entidades`.`correo` AS `correo`,`entidades`.`RTN` AS `RTN`,`entidades`.`id` AS `id` from `entidades` where (`entidades`.`espersonanatural` = 0);

--
-- Definition of view `personasnaturales`
--

DROP TABLE IF EXISTS `personasnaturales`;
DROP VIEW IF EXISTS `personasnaturales`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `personasnaturales` AS select `e`.`telefono` AS `telefono`,`e`.`direccion` AS `direccion`,`e`.`correo` AS `correo`,`e`.`RTN` AS `RTN`,`e`.`usu` AS `usu`,`e`.`fmodif` AS `fmodif`,`e`.`entidadnombre` AS `NombreCompleto`,`e`.`identificacion` AS `identificacion`,`e`.`tipoidentidad` AS `tipoidentidad`,`e`.`id` AS `id` from `entidades` `e` where (`e`.`espersonanatural` = 1);



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
