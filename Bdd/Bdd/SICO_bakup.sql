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
  `id` int(11),
  `telefono2` int(11)
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
  `identificacion` varchar(120),
  `tipoidentidad` varchar(1),
  `id` int(11),
  `telefono2` int(11)
);

--
-- Temporary table structure for view `vclientes`
--
DROP TABLE IF EXISTS `vclientes`;
DROP VIEW IF EXISTS `vclientes`;
CREATE TABLE `vclientes` (
  `id` int(11),
  `identidades` int(11),
  `usu` int(11),
  `fmodif` datetime,
  `estado` int(1) unsigned,
  `entidadnombre` varchar(120),
  `espersonanatural` int(1) unsigned
);

--
-- Temporary table structure for view `ventidades`
--
DROP TABLE IF EXISTS `ventidades`;
DROP VIEW IF EXISTS `ventidades`;
CREATE TABLE `ventidades` (
  `IdEntidad` int(11),
  `telefono` int(11),
  `direccion` varchar(150),
  `correo` varchar(45),
  `espersonanatural` int(1) unsigned,
  `rtn` varchar(14),
  `entidadnombre` varchar(120),
  `identificacion` varchar(120),
  `tipoidentidad` varchar(1),
  `telefono2` int(11)
);

--
-- Temporary table structure for view `vproductos`
--
DROP TABLE IF EXISTS `vproductos`;
DROP VIEW IF EXISTS `vproductos`;
CREATE TABLE `vproductos` (
  `idproducto` int(11),
  `codigo` varchar(45),
  `descripcion` varchar(45),
  `precioventa` decimal(15,2),
  `usuario` int(11),
  `fmodifica` datetime
);

--
-- Temporary table structure for view `vproveedores`
--
DROP TABLE IF EXISTS `vproveedores`;
DROP VIEW IF EXISTS `vproveedores`;
CREATE TABLE `vproveedores` (
  `idproveedor` int(11),
  `identidades` int(11),
  `idcontacto` int(11),
  `estado` int(1) unsigned,
  `descripcion` varchar(120)
);

--
-- Temporary table structure for view `vsucursal`
--
DROP TABLE IF EXISTS `vsucursal`;
DROP VIEW IF EXISTS `vsucursal`;
CREATE TABLE `vsucursal` (
  `idsucursal` int(11),
  `identidades` int(11),
  `idusuario` int(11),
  `idmunicipio` int(11),
  `estado` int(1),
  `numerofactura` int(11),
  `descripcion` varchar(120)
);

--
-- Definition of table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE `clientes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identidades` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `estado` int(1) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Entidad_Unica` (`identidades`),
  KEY `fk_Clientes_Entidades1` (`identidades`),
  CONSTRAINT `fk_Clientes_Entidades1` FOREIGN KEY (`identidades`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `clientes`
--

/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES  (1,4,2,'2011-07-31 20:16:20',NULL),
 (2,8,2,'2011-07-23 14:02:52',NULL),
 (3,6,2,'2011-02-07 00:00:00',NULL),
 (4,22,2,'2011-07-23 14:12:57',NULL),
 (5,24,2,'2011-02-09 22:33:56',NULL),
 (6,25,2,'2011-05-24 00:50:10',NULL);
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;


--
-- Definition of table `compras`
--

DROP TABLE IF EXISTS `compras`;
CREATE TABLE `compras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `facturacompra` varchar(18) NOT NULL,
  `idproveedor` int(11) NOT NULL,
  `fechacompra` date NOT NULL,
  `idsucursal` int(11) NOT NULL COMMENT 'sucurasal a la q esta destinada la compra',
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `totalcompra` decimal(16,2) NOT NULL,
  `Estado` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_compras_Sucursal` (`idsucursal`),
  KEY `FK_compras_proveedor` (`idproveedor`),
  CONSTRAINT `FK_compras_proveedor` FOREIGN KEY (`idproveedor`) REFERENCES `proveedores` (`id`),
  CONSTRAINT `FK_compras_Sucursal` FOREIGN KEY (`idsucursal`) REFERENCES `sucursales` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `compras`
--

/*!40000 ALTER TABLE `compras` DISABLE KEYS */;
INSERT INTO `compras` VALUES  (20,'878789',1,'2011-02-26',1,2,'2011-02-26 11:32:29','25.00',NULL),
 (21,'45445',1,'2011-02-26',1,2,'2011-02-26 11:47:41','25.00',NULL),
 (22,'454',1,'2011-02-26',1,2,'2011-02-26 11:50:05','5.00',NULL),
 (23,'98',1,'2011-02-26',1,2,'2011-02-26 11:50:31','1.00',NULL),
 (24,'458954854',1,'2011-02-26',2,2,'2011-02-26 11:51:43','25.00',NULL),
 (25,'12345679801',1,'2011-02-26',1,2,'2011-02-26 12:03:44','390.00',NULL),
 (26,'2123132',2,'2011-02-26',2,2,'2011-02-26 14:59:26','225.00',NULL),
 (27,'63565',3,'2011-02-26',1,2,'2011-02-26 19:24:10','22.00',NULL),
 (28,'42324',1,'2011-02-27',2,2,'2011-02-27 19:17:09','99.00',NULL),
 (29,'443',2,'2011-02-27',2,2,'2011-02-27 19:24:15','46.00',NULL),
 (31,'32432',1,'2011-02-27',2,2,'2011-02-27 19:30:41','132.00',NULL),
 (32,'4234',1,'2011-02-27',1,2,'2011-02-27 19:34:31','16848.00',NULL),
 (33,'34234',3,'2011-02-28',2,2,'2011-02-28 00:53:48','30450.00',NULL),
 (34,'456465',2,'2011-02-28',1,2,'2011-02-28 00:56:18','27775.00',NULL),
 (35,'24324223434',3,'2011-03-03',2,2,'2011-03-03 21:14:32','69.00',NULL),
 (38,'43234',2,'2011-03-03',1,2,'2011-03-03 23:14:01','110144.00',NULL),
 (39,'342432',2,'2011-04-03',1,2,'2011-04-04 21:08:13','7666.00','C'),
 (40,'5435',2,'2011-04-04',2,2,'2011-04-04 21:50:53','528.00','C'),
 (41,'4234',1,'2011-04-04',2,2,'2011-04-04 21:53:34','3443000.00','C'),
 (42,'34234',1,'2011-04-04',2,2,'2011-04-04 22:03:00','22037.00','C'),
 (43,'124',1,'2011-04-04',1,2,'2011-04-04 22:06:12','80750.00','C');
/*!40000 ALTER TABLE `compras` ENABLE KEYS */;


--
-- Definition of table `controlcaja`
--

DROP TABLE IF EXISTS `controlcaja`;
CREATE TABLE `controlcaja` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idtransaccionescaja` int(11) NOT NULL,
  `monto` decimal(18,2) NOT NULL,
  `fecha` date NOT NULL,
  `cajero` int(11) NOT NULL,
  `idsucursales` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` varchar(45) NOT NULL,
  `descripcion` varchar(500) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idusuario_cajero` (`cajero`),
  KEY `idtrasnsacciones_transaccionse` (`idtransaccionescaja`),
  KEY `idsucursale_sucursales` (`idsucursales`),
  CONSTRAINT `idsucursale_sucursales` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idtrasnsacciones_transaccionse` FOREIGN KEY (`idtransaccionescaja`) REFERENCES `transaccionescaja` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idusuario_cajero` FOREIGN KEY (`cajero`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `controlcaja`
--

/*!40000 ALTER TABLE `controlcaja` DISABLE KEYS */;
INSERT INTO `controlcaja` VALUES  (1,4,'34234.00','2011-07-24',2,2,2,'2011-07-24 12:42:50','Apertura de caja para el usuario saul antonio mayorquin diaz'),
 (2,2,'11454.00','2011-07-24',2,2,2,'2011-07-24 12:43:02','Pago en efectivo en factura'),
 (3,2,'11454.00','0001-01-01',2,2,2,'2011-07-24 12:48:45','Pago en efectivo en factura'),
 (4,2,'11454.00','2011-07-24',2,2,2,'2011-07-24 12:50:18','Pago en efectivo en factura'),
 (5,6,'5345.00','2011-07-24',2,2,2,'2011-07-24 12:51:18','Se retiro efectivo para el usuario saul antonio mayorquin diaz'),
 (6,4,'5235.00','2011-07-25',2,2,2,'2011-07-25 22:53:37','Apertura de caja para el usuario saul antonio mayorquin diaz'),
 (7,7,'12324.00','2011-07-25',2,2,2,'2011-07-25 23:04:19','Se ingreso efectivo para el usuario saul antonio mayorquin diaz'),
 (8,6,'1233.11','2011-07-25',2,2,2,'2011-07-25 23:04:36','Se retiro efectivo para el usuario saul antonio mayorquin diaz'),
 (9,4,'552345.00','2011-07-26',2,2,2,'2011-07-26 22:30:05','Apertura de caja para el usuario saul antonio mayorquin diaz'),
 (10,7,'424.00','2011-07-26',2,2,2,'2011-07-26 22:30:19','Se ingreso efectivo para el usuario saul antonio mayorquin diaz'),
 (11,6,'44242.00','2011-07-26',2,2,2,'2011-07-26 22:30:35','Se retiro efectivo para el usuario saul antonio mayorquin diaz'),
 (12,3,'11454.00','2011-07-26',2,2,2,'2011-07-26 23:18:29','Pago con tarjeta de crédito en factura'),
 (13,2,'2.00','2011-07-26',2,2,2,'2011-07-26 23:50:34','Pago en efectivo en factura'),
 (14,3,'2.00','2011-07-26',2,2,2,'2011-07-26 23:50:34','Pago con tarjeta de crédito en factura'),
 (15,4,'2435.00','2011-07-30',2,2,2,'2011-07-30 21:37:32','Apertura de caja para el usuario saul antonio mayorquin diaz'),
 (16,2,'22908.00','2011-07-30',2,2,2,'2011-07-30 21:49:31','Pago en efectivo en factura'),
 (17,4,'4243.00','2011-07-31',2,2,2,'2011-07-31 19:00:13','Apertura de caja para el usuario saul antonio mayorquin diaz'),
 (18,2,'11454.00','2011-07-31',2,2,2,'2011-07-31 19:00:37','Pago en efectivo en factura'),
 (19,10,'11454.00','2011-07-31',2,2,2,'2011-07-31 19:02:44','Anulación de factura para el usuario saul antonio mayorquin diaz'),
 (20,2,'22908.00','2011-07-31',2,2,2,'2011-07-31 19:05:15','Pago en efectivo en factura'),
 (21,10,'22908.00','2011-07-31',2,2,2,'2011-07-31 19:05:34','Anulación de factura para el usuario saul antonio mayorquin diaz'),
 (22,2,'34434.00','2011-07-31',2,2,2,'2011-07-31 20:08:09','Pago en efectivo en factura'),
 (23,10,'34434.00','2011-07-31',2,2,2,'2011-07-31 20:14:47','Anulación de factura para el usuario saul antonio mayorquin diaz'),
 (24,2,'34434.00','2011-07-31',2,2,2,'2011-07-31 20:16:28','Pago en efectivo en factura'),
 (25,10,'34434.00','2011-07-31',2,2,2,'2011-07-31 20:17:51','Anulación de factura para el usuario saul antonio mayorquin diaz'),
 (26,4,'12123.00','2011-08-01',2,2,2,'2011-08-01 21:27:55','Apertura de caja para el usuario saul antonio mayorquin diaz'),
 (27,2,'11454.00','2011-08-01',2,2,2,'2011-08-01 21:30:58','Pago en efectivo en factura'),
 (28,5,'23572.00','2011-08-01',2,2,2,'2011-08-01 21:34:32','Cierre de caja para el usuario saul antonio mayorquin diaz'),
 (29,8,'5.00','2011-08-01',2,2,2,'2011-08-01 21:34:32','Faltante de caja para el usuario  saul antonio mayorquin diaz'),
 (30,4,'12231.00','2011-08-02',2,2,2,'2011-08-02 21:46:57','Apertura de caja para el usuario saul antonio mayorquin diaz'),
 (31,5,'12231.00','2011-08-02',2,2,2,'2011-08-02 21:47:17','Cierre de caja para el usuario saul antonio mayorquin diaz');
/*!40000 ALTER TABLE `controlcaja` ENABLE KEYS */;


--
-- Definition of table `controlcajafactura`
--

DROP TABLE IF EXISTS `controlcajafactura`;
CREATE TABLE `controlcajafactura` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idfacturaencabezado` int(11) NOT NULL,
  `idcontrolcaja` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `FacturaEncabazadoControlCajaUnico` (`idfacturaencabezado`,`idcontrolcaja`),
  KEY `facturaencabezado_Tintermedia` (`idfacturaencabezado`),
  KEY `ControlCaja_Tintermedia` (`idcontrolcaja`),
  CONSTRAINT `ControlCaja_Tintermedia` FOREIGN KEY (`idcontrolcaja`) REFERENCES `controlcaja` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `facturaencabezado_Tintermedia` FOREIGN KEY (`idfacturaencabezado`) REFERENCES `facturaencabezado` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `controlcajafactura`
--

/*!40000 ALTER TABLE `controlcajafactura` DISABLE KEYS */;
INSERT INTO `controlcajafactura` VALUES  (1,50,13,2,'2011-07-26 23:50:34'),
 (2,50,14,2,'2011-07-26 23:50:34'),
 (3,51,16,2,'2011-07-30 21:49:31'),
 (4,52,18,2,'2011-07-31 19:00:37'),
 (5,52,19,2,'2011-07-31 19:02:46'),
 (6,53,20,2,'2011-07-31 19:05:15'),
 (7,53,21,2,'2011-07-31 19:05:34'),
 (8,55,22,2,'2011-07-31 20:08:09'),
 (9,55,23,2,'2011-07-31 20:14:47'),
 (10,56,24,2,'2011-07-31 20:16:28'),
 (11,56,25,2,'2011-07-31 20:17:51'),
 (12,57,27,2,'2011-08-01 21:30:58');
/*!40000 ALTER TABLE `controlcajafactura` ENABLE KEYS */;


--
-- Definition of table `cuentacorriente`
--

DROP TABLE IF EXISTS `cuentacorriente`;
CREATE TABLE `cuentacorriente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(70) NOT NULL,
  `identidaddeudora` int(11) NOT NULL,
  `identidadbeneficiaria` int(11) NOT NULL,
  `estado` varchar(5) NOT NULL,
  `idsucursales` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `habilitado` int(1) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `entidaddeudora_cuentacorriente` (`identidaddeudora`),
  KEY `entidadbeneficiaria_cuentacorriente` (`identidadbeneficiaria`),
  CONSTRAINT `entidadbeneficiaria_cuentacorriente` FOREIGN KEY (`identidadbeneficiaria`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `entidaddeudora_cuentacorriente` FOREIGN KEY (`identidaddeudora`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cuentacorriente`
--

/*!40000 ALTER TABLE `cuentacorriente` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuentacorriente` ENABLE KEYS */;


--
-- Definition of table `departamentos`
--

DROP TABLE IF EXISTS `departamentos`;
CREATE TABLE `departamentos` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `habilitado` int(1) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Descripcion` (`descripcion`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `departamentos`
--

/*!40000 ALTER TABLE `departamentos` DISABLE KEYS */;
INSERT INTO `departamentos` VALUES  (3,'Comayagua',1,2,'2011-03-23 00:00:00'),
 (8,'Francisco Morazan',1,1,'2010-01-01 00:00:00');
/*!40000 ALTER TABLE `departamentos` ENABLE KEYS */;


--
-- Definition of table `detallecompras`
--

DROP TABLE IF EXISTS `detallecompras`;
CREATE TABLE `detallecompras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idcompras` int(11) NOT NULL,
  `idproducto` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `preciocompra` decimal(14,2) NOT NULL,
  `idsucursal` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `LLave_Primaria` (`idcompras`,`idproducto`),
  KEY `FK_detallecompras_Producto` (`idproducto`),
  KEY `FK_detallecompras_Sucursal` (`idsucursal`),
  CONSTRAINT `FK_detallecompras_Producto` FOREIGN KEY (`idproducto`) REFERENCES `productos` (`id`),
  CONSTRAINT `FK_detallecompras_ResumenCompras` FOREIGN KEY (`idcompras`) REFERENCES `compras` (`id`),
  CONSTRAINT `FK_detallecompras_Sucursal` FOREIGN KEY (`idsucursal`) REFERENCES `sucursales` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detallecompras`
--

/*!40000 ALTER TABLE `detallecompras` DISABLE KEYS */;
INSERT INTO `detallecompras` VALUES  (12,20,2,5,'5.00',1,2,'2011-02-26 11:32:29'),
 (13,21,9,5,'5.00',1,2,'2011-02-26 11:47:41'),
 (14,22,9,1,'5.00',1,2,'2011-02-26 11:50:05'),
 (15,23,2,1,'1.00',1,2,'2011-02-26 11:50:31'),
 (16,24,2,5,'5.00',2,2,'2011-02-26 11:51:43'),
 (17,25,6,5,'78.00',1,2,'2011-02-26 12:03:44'),
 (18,26,5,5,'45.00',2,2,'2011-02-26 14:59:26'),
 (19,27,10,4,'5.50',1,2,'2011-02-26 19:24:10'),
 (20,28,9,3,'33.00',2,2,'2011-02-27 19:17:09'),
 (21,29,2,2,'23.00',2,2,'2011-02-27 19:24:15'),
 (22,31,2,3,'44.00',2,2,'2011-02-27 19:30:41'),
 (23,32,2,312,'54.00',1,2,'2011-02-27 19:34:31'),
 (24,33,9,45,'5.00',2,2,'2011-02-28 00:53:48'),
 (25,33,6,65,'465.00',2,2,'2011-02-28 00:53:49'),
 (26,34,9,5555,'5.00',1,2,'2011-02-28 00:56:18'),
 (27,35,2,3,'23.00',2,2,'2011-03-03 21:14:32'),
 (28,38,2,32,'3442.00',1,2,'2011-03-03 23:14:01'),
 (29,39,2,232,'32.00',1,2,'2011-04-04 21:08:15'),
 (30,39,9,2,'76.00',1,2,'2011-04-04 21:08:21'),
 (31,39,6,2,'45.00',1,2,'2011-04-04 21:08:25'),
 (32,40,9,22,'22.00',2,2,'2011-04-04 21:50:53'),
 (33,40,6,22,'2.00',2,2,'2011-04-04 21:50:53'),
 (34,41,2,1000,'3443.00',2,2,'2011-04-04 21:53:34'),
 (35,42,2,43,'432.00',2,2,'2011-04-04 22:03:00'),
 (36,42,6,34,'43.00',2,2,'2011-04-04 22:03:00'),
 (37,42,10,1999,'1.00',2,2,'2011-04-04 22:03:00'),
 (38,43,2,3333,'22.00',1,2,'2011-04-04 22:06:12'),
 (39,43,10,232,'32.00',1,2,'2011-04-04 22:06:12');
/*!40000 ALTER TABLE `detallecompras` ENABLE KEYS */;


--
-- Definition of trigger `DetalleCompra_trigg`
--

DROP TRIGGER /*!50030 IF EXISTS */ `DetalleCompra_trigg`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `DetalleCompra_trigg` AFTER INSERT ON `detallecompras` FOR EACH ROW BEGIN


    /*CALL Inventarios_Triggers(new.idsucursal,new.idproducto,new.cantidad,new.usu,new.fmodif);

    /*set @idpro=0;
    select idproveedor from compras c where c.id = new.idcompras into @idpro;

    CALL ProveedorProducto_Trigg(@idpro,new.idproducto,new.preciocompra );*/


    update productos p set preciocosto = new.preciocompra where p.id= new.idproducto;

  END $$

DELIMITER ;

--
-- Definition of table `detalleorden`
--

DROP TABLE IF EXISTS `detalleorden`;
CREATE TABLE `detalleorden` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idordencompra` int(11) NOT NULL,
  `idproducto` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IdOrden_IdProducto_Unico` (`idordencompra`,`idproducto`),
  KEY `Producto_Detalle` (`idproducto`),
  KEY `Orden_Detalle` (`idordencompra`),
  CONSTRAINT `Orden_Detalle` FOREIGN KEY (`idordencompra`) REFERENCES `ordenescompras` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Producto_Detalle` FOREIGN KEY (`idproducto`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detalleorden`
--

/*!40000 ALTER TABLE `detalleorden` DISABLE KEYS */;
INSERT INTO `detalleorden` VALUES  (1,6,2,4324,2,'2011-03-04 22:51:54'),
 (2,7,2,4156,2,'2011-03-04 22:58:07'),
 (3,8,2,5465,2,'2011-03-05 00:22:57'),
 (4,9,2,46978,2,'2011-03-05 00:30:53'),
 (5,10,2,5464,2,'2011-03-05 00:35:37'),
 (6,11,2,54,2,'2011-03-05 00:38:40'),
 (7,12,10,54,2,'2011-03-23 19:32:22'),
 (8,12,2,454,2,'2011-03-23 19:32:22'),
 (9,13,2,45454,2,'2011-03-23 19:35:54'),
 (10,14,6,267,2,'2011-03-23 19:36:42'),
 (11,15,2,54545,2,'2011-03-23 20:45:25'),
 (12,16,2,2,2,'2011-03-23 21:26:26'),
 (13,17,2,454,2,'2011-03-23 21:36:17'),
 (14,18,2,4154,2,'2011-03-23 21:36:52'),
 (15,19,2,4234,2,'2011-03-23 22:57:59');
/*!40000 ALTER TABLE `detalleorden` ENABLE KEYS */;


--
-- Definition of table `detallerequisicion`
--

DROP TABLE IF EXISTS `detallerequisicion`;
CREATE TABLE `detallerequisicion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idrequisicion` int(11) NOT NULL,
  `idproducto` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `usu` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `LLave_Requisicion` (`idrequisicion`,`idproducto`),
  KEY `idproducto_productos_requiscion` (`idproducto`),
  KEY `idrequicion_detalle` (`idrequisicion`),
  CONSTRAINT `idproducto_productos_requiscion` FOREIGN KEY (`idproducto`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idrequicion_detalle` FOREIGN KEY (`idrequisicion`) REFERENCES `ordenesrequisicion` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detallerequisicion`
--

/*!40000 ALTER TABLE `detallerequisicion` DISABLE KEYS */;
INSERT INTO `detallerequisicion` VALUES  (2,6,2,65,'2011-03-14 23:50:41',2),
 (3,7,2,45,'2011-03-13 18:34:46',2),
 (4,7,9,1,'2011-03-13 18:34:46',2),
 (5,7,10,45,'2011-03-13 18:34:46',2),
 (6,8,2,45,'2011-03-13 18:43:47',2),
 (7,8,9,25,'2011-03-13 18:43:47',2),
 (8,9,2,5265,'2011-03-13 18:52:06',2),
 (9,10,2,45,'2011-03-13 18:54:12',2),
 (10,11,2,5,'2011-03-13 19:00:58',2),
 (11,12,2,5,'2011-03-13 19:02:40',2),
 (13,14,2,554,'2011-03-23 19:24:03',2),
 (14,14,10,45,'2011-03-23 19:24:03',2),
 (15,15,9,454,'2011-03-23 19:39:20',2),
 (16,15,6,78,'2011-03-23 19:39:20',2),
 (17,16,2,454,'2011-03-23 20:15:01',2),
 (18,17,2,45,'2011-03-23 21:06:13',2),
 (19,18,2,5,'2011-03-23 21:37:29',2),
 (20,19,2,45,'2011-03-23 21:37:53',2),
 (21,20,2,24154,'2011-03-23 21:38:50',2),
 (22,20,6,1121,'2011-03-23 21:38:51',2),
 (23,20,9,1212,'2011-03-23 21:38:51',2),
 (24,21,2,33,'2011-03-23 21:59:05',2),
 (25,22,2,89,'2011-03-23 22:21:05',2),
 (26,23,2,888,'2011-03-23 22:23:40',2),
 (27,23,9,4334,'2011-03-23 22:23:41',2),
 (28,23,10,4343,'2011-03-23 22:23:41',2),
 (29,24,2,323,'2011-03-23 22:24:39',2),
 (30,25,2,4234,'2011-03-23 22:42:37',2),
 (31,25,10,234,'2011-03-23 22:42:40',2),
 (32,26,9,433,'2011-03-23 22:56:09',2),
 (33,26,6,32434,'2011-03-23 22:56:12',2),
 (34,26,2,32,'2011-03-23 22:56:15',2),
 (35,27,9,67,'2011-03-23 23:18:49',2),
 (36,27,6,56,'2011-03-23 23:18:49',2),
 (37,28,2,7567,'2011-03-23 23:20:26',2);
/*!40000 ALTER TABLE `detallerequisicion` ENABLE KEYS */;


--
-- Definition of table `detallesalida`
--

DROP TABLE IF EXISTS `detallesalida`;
CREATE TABLE `detallesalida` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idsalida` int(11) NOT NULL,
  `idproducto` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `usu` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `detalles_salida` (`idsalida`),
  KEY `detalles_productos` (`idproducto`),
  CONSTRAINT `detalles_productos` FOREIGN KEY (`idproducto`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `detalles_salida` FOREIGN KEY (`idsalida`) REFERENCES `ordenessalida` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detallesalida`
--

/*!40000 ALTER TABLE `detallesalida` DISABLE KEYS */;
INSERT INTO `detallesalida` VALUES  (1,2,2,55,'2011-03-25 21:36:00',2),
 (2,3,2,5,'2011-03-25 21:48:20',2),
 (3,4,2,5,'2011-03-25 21:54:08',2),
 (4,5,2,5,'2011-03-25 21:59:22',2),
 (5,5,6,3,'2011-03-25 21:59:22',2),
 (6,6,6,2,'2011-03-25 22:09:07',2),
 (7,7,9,1000,'2011-03-25 22:25:17',2),
 (8,7,2,100,'2011-03-25 22:25:17',2),
 (9,8,2,5,'2011-03-25 22:28:47',2),
 (10,9,2,55,'2011-03-25 22:33:04',2),
 (11,10,2,4,'2011-03-27 16:08:06',2),
 (12,11,2,32,'2011-03-27 23:38:56',2),
 (13,12,2,3,'2011-04-02 22:35:03',2),
 (14,13,2,2,'2011-04-02 22:41:30',2),
 (15,14,2,89,'2011-04-02 22:44:37',2),
 (16,14,9,343,'2011-04-02 22:44:37',2),
 (17,15,2,23,'2011-04-02 22:49:35',2),
 (18,16,2,34,'2011-04-02 23:01:17',2),
 (19,17,2,32,'2011-04-03 12:05:17',2),
 (20,18,2,2,'2011-04-03 14:33:03',2),
 (22,19,2,3,'2011-04-03 12:13:16',2),
 (23,18,9,434,'2011-04-03 14:33:08',2),
 (24,20,2,37,'2011-04-03 14:53:13',3),
 (25,20,6,18,'2011-04-03 14:53:17',3),
 (27,21,9,1000,'2011-04-03 14:55:25',3),
 (28,20,9,1000,'2011-04-03 14:53:22',3),
 (29,22,9,1000,'2011-04-03 14:59:39',2),
 (30,23,10,222,'2011-04-04 22:13:58',2),
 (31,23,2,34,'2011-04-04 22:13:58',2),
 (32,23,9,12,'2011-04-04 22:13:58',2),
 (33,23,6,100,'2011-04-04 22:13:58',2),
 (34,24,10,100,'2011-04-04 22:22:31',2),
 (35,25,2,1000,'2011-04-04 22:24:37',2),
 (36,26,2,1000,'2011-04-04 22:29:32',2),
 (37,27,2,100,'2011-04-04 22:33:49',2),
 (38,28,2,34,'2011-04-04 22:40:11',2),
 (39,29,2,3,'2011-04-10 20:53:51',2),
 (40,30,2,2,'2011-05-23 23:26:04',2);
/*!40000 ALTER TABLE `detallesalida` ENABLE KEYS */;


--
-- Definition of table `entidades`
--

DROP TABLE IF EXISTS `entidades`;
CREATE TABLE `entidades` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `telefono` int(11) DEFAULT NULL,
  `direccion` varchar(150) DEFAULT NULL,
  `correo` varchar(45) DEFAULT NULL,
  `espersonanatural` int(1) unsigned NOT NULL,
  `RTN` varchar(14) DEFAULT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  `entidadnombre` varchar(120) NOT NULL,
  `identificacion` varchar(120) NOT NULL,
  `tipoidentidad` varchar(1) NOT NULL COMMENT 'I identidad, R resiendica',
  `telefono2` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Identificacion` (`identificacion`,`tipoidentidad`) USING BTREE,
  UNIQUE KEY `Nombre` (`entidadnombre`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `entidades`
--

/*!40000 ALTER TABLE `entidades` DISABLE KEYS */;
INSERT INTO `entidades` VALUES  (4,27729729,'col. miraflores tegucigalpacol. miraflores tegucigalpacol. miraflores tegucigalpacol. miraflores tegucigalpacol. miraflores tegucigalpacol. miraflores','saulmadiqg@aksdfjk.com',1,'08011988125246',2,'2011-07-31','saul antonio mayorquin diaz&','0801-1988-12524','I',96330670),
 (5,NULL,NULL,NULL,1,NULL,2,'2011-02-09','asdf asdf asdf%','34f83cac-180f-4355-89e3-f0dce27714fe','N',NULL),
 (6,4322340,'aaklsdfjakl','sad@jfsdk.com',0,'REWIE',2,'2011-03-04','Varideades Canezu','c4b7213f-8a54-4d91-ae3b-25e9a20e6f59','J',34872342),
 (7,NULL,NULL,NULL,1,NULL,1,'2011-01-27','carlos diaz@','0301-1989-12345','I',NULL),
 (8,34234,'fdsdfsdfsdf',NULL,0,'8958394858093',2,'2011-07-23','ENEE','013402fc-5708-43fb-b5ff-9455b8856234','J',342443),
 (9,NULL,NULL,NULL,1,'S33DD343',2,'2011-03-01','Pamela castro@','fdfdfd','R',NULL),
 (10,NULL,NULL,NULL,1,'KSADFSJ43342',2,'2011-01-28','carlo madrid@','skd243','R',NULL),
 (11,NULL,NULL,NULL,1,NULL,2,'2011-03-01','carlos maldonado@','21ddf','R',NULL),
 (12,NULL,NULL,NULL,0,NULL,2,'2011-01-29','varideade cksdfjadfskj','70526885-db46-46d8-a64c-d90d45c1963e','J',NULL),
 (13,NULL,NULL,NULL,0,NULL,2,'2011-01-29','variedades jkasdfjkdfsldfkj','f6386566-4909-44e5-ad17-a43e3d48bd1c','J',NULL),
 (14,NULL,NULL,NULL,0,NULL,2,'2011-02-09','variedades kdfsjkdfsjlkdsjf','5cd12777-9003-4371-b5b6-098d0ee955bd','J',NULL),
 (15,NULL,NULL,NULL,0,NULL,2,'2011-01-29','variedades kdsfjaiorjewkjdsklfj','a7414e96-4e36-4a7a-b285-6f57d8c25ec4','J',NULL),
 (16,NULL,NULL,NULL,0,NULL,2,'2011-01-29','variedades kdjfskljsdlldfskj','30a6e721-0247-4b34-9b32-efb4219afa98','J',NULL),
 (17,NULL,NULL,NULL,0,NULL,2,'2011-01-29','variedades asdkfjdsfkljlakjfkljdsfkjlas','1a969030-ace7-4cdd-9d61-4c34b2285db6','J',NULL),
 (18,4323434,'blv. 4to Centenario, frente a instituto leon alvarado asdasdf asdasdfasdf',NULL,0,NULL,2,'2011-02-13','Colmotos Sucursal','afb8b1a2-ecfa-47bf-823c-4d3ed9f485fd','J',3423324),
 (19,42342,'424324',NULL,0,NULL,2,'2011-02-02','Colomotos Principal','e2f65f96-99d8-459d-b927-858bfdaef286','J',432324),
 (20,42432,NULL,NULL,1,'4DFS',2,'2011-02-03','Carlos recarte@','423','R',4323),
 (21,323432,NULL,NULL,0,NULL,2,'2011-02-03','Ultra Motor','52c4467a-93e7-4e9c-9e1f-fcf64283363c','J',424234),
 (22,434342,NULL,NULL,0,NULL,2,'2011-07-23','SANAA','cd349d46-e156-488a-8b8b-560c33d8fe7d','J',34234234),
 (23,NULL,NULL,NULL,1,NULL,2,'2011-02-09','Raul Valladares@','189e0c80-2b7d-49f5-8841-f61c0b9c814e','N',NULL),
 (24,43533535,NULL,'sadkjkldf@ddd.df',1,NULL,2,'2011-03-04','Hector valladares@','7b28fd99-db02-47b2-a987-c5d20a7c34c3','N',NULL),
 (25,NULL,NULL,NULL,1,NULL,2,'2011-05-24','carlos alberto villalta morazan&','1a7206f5-02fb-48b2-952c-03be51e7e331','N',NULL),
 (26,NULL,NULL,NULL,1,'94949',2,'2011-08-16','Luis Fernando Carbajal Calvo&','83839298348','R',45353445);
/*!40000 ALTER TABLE `entidades` ENABLE KEYS */;


--
-- Definition of table `facturacuentacorriente`
--

DROP TABLE IF EXISTS `facturacuentacorriente`;
CREATE TABLE `facturacuentacorriente` (
  `id` int(11) NOT NULL,
  `idfacturaencabezado` int(11) NOT NULL,
  `idcuentacorriente` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `facturaencabezado_facuturaencabezado` (`idfacturaencabezado`),
  KEY `cuentacorriente_facturacuentacorriente` (`idcuentacorriente`),
  CONSTRAINT `cuentacorriente_facturacuentacorriente` FOREIGN KEY (`idcuentacorriente`) REFERENCES `movimientoscuentacorriente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `facturaencabezado_facuturaencabezado` FOREIGN KEY (`idfacturaencabezado`) REFERENCES `facturaencabezado` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturacuentacorriente`
--

/*!40000 ALTER TABLE `facturacuentacorriente` DISABLE KEYS */;
/*!40000 ALTER TABLE `facturacuentacorriente` ENABLE KEYS */;


--
-- Definition of table `facturadetalle`
--

DROP TABLE IF EXISTS `facturadetalle`;
CREATE TABLE `facturadetalle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idfacturaencabezado` int(11) NOT NULL,
  `idproductos` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `precioventa` decimal(10,4) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `factura_Productos` (`idfacturaencabezado`,`idproductos`),
  KEY `fk_FacturaDetalle_FacturaEncabezado1` (`idfacturaencabezado`),
  KEY `fk_FacturaDetalle_Productos1` (`idproductos`),
  CONSTRAINT `fk_FacturaDetalle_FacturaEncabezado1` FOREIGN KEY (`idfacturaencabezado`) REFERENCES `facturaencabezado` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_FacturaDetalle_Productos1` FOREIGN KEY (`idproductos`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturadetalle`
--

/*!40000 ALTER TABLE `facturadetalle` DISABLE KEYS */;
INSERT INTO `facturadetalle` VALUES  (2,10,2,1,'11454.0000',2,'2011-05-24 00:46:17'),
 (3,12,2,2,'11454.0000',2,'2011-05-24 00:50:29'),
 (4,13,2,1,'12.0000',2,'2011-05-24 00:50:11'),
 (5,13,10,1,'13.0000',2,'2011-05-24 00:50:11'),
 (6,14,2,2,'11454.0000',2,'2011-05-25 23:22:46'),
 (7,14,10,1,'2.0000',2,'2011-05-25 23:22:46'),
 (8,16,2,2,'11454.0000',2,'2011-05-20 23:46:45'),
 (9,16,9,12,'456.4000',2,'2011-05-20 23:46:45'),
 (10,17,2,1,'100.0000',2,'2011-05-24 00:49:18'),
 (11,19,2,1,'11454.0000',2,'2011-05-24 21:40:38'),
 (12,21,2,1,'11454.0000',2,'2011-05-24 22:51:02'),
 (13,22,2,12,'11454.0000',2,'2011-06-02 20:34:56'),
 (14,27,2,1,'11454.0000',2,'2011-06-16 20:07:23'),
 (15,30,2,4,'11454.0000',2,'2011-07-22 19:24:36'),
 (16,32,2,1,'11454.0000',2,'2011-07-22 20:26:40'),
 (17,36,2,1,'11454.0000',2,'2011-07-23 00:54:24'),
 (18,41,2,1,'11454.0000',2,'2011-07-23 14:12:57'),
 (19,41,10,12,'2.0000',2,'2011-07-23 14:12:57'),
 (20,42,2,3,'11454.0000',2,'2011-07-24 12:01:15'),
 (21,43,10,1,'2.0000',2,'2011-07-24 12:02:10'),
 (22,44,2,1,'11454.0000',2,'2011-07-24 12:30:06'),
 (23,45,2,1,'11454.0000',2,'2011-07-24 12:42:56'),
 (24,46,2,1,'11454.0000',2,'2011-07-24 12:47:01'),
 (26,47,2,1,'11454.0000',2,'2011-07-24 12:48:12'),
 (27,48,2,1,'11454.0000',2,'2011-07-24 12:50:08'),
 (28,49,2,1,'11454.0000',2,'2011-07-26 23:18:10'),
 (29,50,10,2,'2.0000',2,'2011-07-26 23:50:34'),
 (30,51,2,2,'11454.0000',2,'2011-07-30 21:49:31'),
 (31,52,2,1,'11454.0000',2,'2011-07-31 19:00:37'),
 (32,53,2,2,'11454.0000',2,'2011-07-31 19:05:15'),
 (33,54,10,1,'2.0000',2,'2011-07-31 19:49:06'),
 (34,57,2,1,'11454.0000',2,'2011-08-01 21:30:58');
/*!40000 ALTER TABLE `facturadetalle` ENABLE KEYS */;


--
-- Definition of table `facturaencabezado`
--

DROP TABLE IF EXISTS `facturaencabezado`;
CREATE TABLE `facturaencabezado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(150) NOT NULL,
  `idsucursales` int(11) NOT NULL,
  `numerofactura` varchar(100) DEFAULT NULL,
  `idclientes` int(11) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `idtiposfacturas` int(11) NOT NULL,
  `total` decimal(10,4) NOT NULL,
  `isv` decimal(10,4) NOT NULL,
  `subtotal` decimal(10,4) NOT NULL,
  `descuentovalor` decimal(10,4) DEFAULT NULL,
  `descuento` int(11) DEFAULT NULL,
  `ventaexenta` int(1) unsigned DEFAULT NULL,
  `estado` varchar(5) DEFAULT NULL,
  `motoproducto` varchar(5) DEFAULT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` date NOT NULL,
  `elabora` int(11) unsigned NOT NULL,
  `factura` int(11) unsigned DEFAULT NULL,
  `idmotocicletas` int(11) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_FacturaEncabezado_Sucursales1` (`idsucursales`),
  KEY `fk_FacturaEncabezado_Clientes1` (`idclientes`),
  KEY `fk_FacturaEncabezado_Tiposfacturas1` (`idtiposfacturas`),
  KEY `Numero_Factura_Repetido` (`numerofactura`,`idsucursales`),
  CONSTRAINT `fk_FacturaEncabezado_Clientes1` FOREIGN KEY (`idclientes`) REFERENCES `clientes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_FacturaEncabezado_Sucursales1` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_FacturaEncabezado_Tiposfacturas1` FOREIGN KEY (`idtiposfacturas`) REFERENCES `tiposfacturas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturaencabezado`
--

/*!40000 ALTER TABLE `facturaencabezado` DISABLE KEYS */;
INSERT INTO `facturaencabezado` VALUES  (10,'FE-002-20110519-002-0000001',2,'2',NULL,'2011-05-24',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-05-24',2,NULL,NULL),
 (12,'FE-002-20110519-002-0000002',2,'5',1,'2011-05-24',1,'22908.0000','2748.9600','22908.0000','0.0000',0,0,'F','P',2,'2011-05-24',2,NULL,NULL),
 (13,'FE-002-20110519-002-0000003',2,'4',6,'2011-05-24',1,'22.0000','0.0000','25.0000','0.0000',0,1,'F','P',2,'2011-05-24',2,NULL,NULL),
 (14,'FE-002-20110520-002-0000004',2,'8',NULL,'2011-05-25',1,'22910.0000','2749.2000','22910.0000','0.0000',0,0,'F','P',2,'2011-05-25',2,2,NULL),
 (16,'FE-002-20110520-002-0000005',2,'0',NULL,'2011-05-20',1,'28384.8000','3406.1760','28384.8000','0.0000',0,0,'P','P',2,'2011-05-20',2,NULL,NULL),
 (17,'FE-002-20110522-002-0000006',2,'3',NULL,'2011-05-24',2,'77.4400','0.0000','100.0000','12.0000',12,1,'F','P',2,'2011-05-24',2,NULL,NULL),
 (19,'FE-002-20110524-002-0000007',2,'6',NULL,'2011-05-24',2,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-05-24',2,2,NULL),
 (21,'FE-002-20110524-002-0000008',2,'7',NULL,'2011-05-24',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-05-24',2,2,NULL),
 (22,'FE-002-20110602-002-0000009',2,'9',NULL,'2011-06-02',1,'120954.2400','0.0000','137448.0000','0.0000',0,1,'F','P',2,'2011-06-02',2,2,NULL),
 (25,'FE-002-20110609-002-0000010',2,'8a19b567-d765-44d8-b664-4bd2d3cafea4',NULL,'2011-06-09',1,'342342.0000','41081.0400','342342.0000','0.0000',0,0,'P','M',2,'2011-06-09',2,NULL,NULL),
 (26,'FE-002-20110609-002-0000011',2,'f5da4808-c5a1-4fa0-b8d1-03f3cbb79608',NULL,'2011-06-09',1,'342342.0000','41081.0400','342342.0000','0.0000',0,0,'P','M',2,'2011-06-09',2,NULL,5),
 (27,'FE-002-20110615-002-0000012',2,'11',NULL,'2011-06-16',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-06-16',2,2,NULL),
 (28,'FE-002-20110615-002-0000013',2,'10',NULL,'2011-06-16',1,'342342.0000','41081.0400','342342.0000','0.0000',0,0,'F','M',2,'2011-06-16',2,NULL,5),
 (29,'FE-002-20110616-002-0000014',2,'12',1,'2011-06-16',1,'23123.0000','2774.7600','23123.0000','0.0000',0,0,'F','M',2,'2011-06-16',2,NULL,11),
 (30,'FE-002-20110721-002-0000015',2,'20',NULL,'2011-07-22',1,'45816.0000','5497.9200','45816.0000','0.0000',0,0,'F','P',2,'2011-07-22',2,2,NULL),
 (32,'FE-002-20110722-002-0000016',2,'34',NULL,'2011-07-22',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-07-22',2,2,NULL),
 (33,'FE-002-20110722-002-0000017',2,'35',1,'2011-07-22',1,'45345.0000','5441.4000','45345.0000','0.0000',0,0,'F','M',2,'2011-07-22',2,NULL,6),
 (34,'FE-002-20110722-002-0000018',2,'36',1,'2011-07-22',1,'43242.0000','5189.0400','43242.0000','0.0000',0,0,'F','M',2,'2011-07-22',2,NULL,8),
 (36,'FE-002-20110722-002-0000019',2,'a45802c3-2095-4a64-b335-d4ce43fda9a6',1,'2011-07-23',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'P','P',2,'2011-07-23',2,NULL,NULL),
 (37,'FE-002-20110722-002-0000020',2,'37',1,'2011-07-22',1,'3424.0000','410.8800','3424.0000','0.0000',0,0,'F','M',2,'2011-07-22',2,NULL,3),
 (38,'FE-002-20110722-002-0000021',2,'b4f89f20-4345-4c14-813a-abb9d1b07686',1,'2011-07-22',1,'4323.0000','518.7600','4323.0000','0.0000',0,0,'P','M',2,'2011-07-22',2,NULL,4),
 (39,'FE-002-20110723-002-0000022',2,'9a06179e-5c38-459a-922e-8d0b026ef309',1,'2011-07-23',1,'34434.0000','4132.0800','34434.0000','0.0000',0,0,'P','M',2,'2011-07-23',2,NULL,1),
 (40,'FE-002-20110723-002-0000023',2,'39',2,'2011-07-23',1,'434234.0000','52108.0800','434234.0000','0.0000',0,0,'F','M',2,'2011-07-23',2,NULL,9),
 (41,'FE-002-20110723-002-0000024',2,'40',4,'2011-07-23',1,'11478.0000','1377.3600','11478.0000','0.0000',0,0,'F','P',2,'2011-07-23',2,2,NULL),
 (42,'FE-002-20110724-002-0000025',2,'41',1,'2011-07-24',1,'34362.0000','4123.4400','34362.0000','0.0000',0,0,'F','P',2,'2011-07-24',2,2,NULL),
 (43,'FE-002-20110724-002-0000026',2,'43',NULL,'2011-07-24',1,'2.0000','0.2400','2.0000','0.0000',0,0,'F','P',2,'2011-07-24',2,2,NULL),
 (44,'FE-002-20110724-002-0000027',2,'44',NULL,'2011-07-24',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-07-24',2,2,NULL),
 (45,'FE-002-20110724-002-0000028',2,'45',NULL,'2011-07-24',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-07-24',2,2,NULL),
 (46,'FE-002-20110724-002-0000029',2,'46',NULL,'2011-07-24',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-07-24',2,2,NULL),
 (47,'FE-002-20110724-002-0000030',2,'47',NULL,'2011-07-24',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-07-24',2,2,NULL),
 (48,'FE-002-20110724-002-0000031',2,'48',NULL,'2011-07-24',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-07-24',2,2,NULL),
 (49,'FE-002-20110726-002-0000032',2,'49',NULL,'2011-07-26',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-07-26',2,2,NULL),
 (50,'FE-002-20110726-002-0000033',2,'50',NULL,'2011-07-26',1,'4.0000','0.4800','4.0000','0.0000',0,0,'F','P',2,'2011-07-26',2,2,NULL),
 (51,'FE-002-20110730-002-0000034',2,'51',NULL,'2011-07-30',1,'22908.0000','2748.9600','22908.0000','0.0000',0,0,'F','P',2,'2011-07-30',2,2,NULL),
 (52,'FE-002-20110731-002-0000035',2,'52',NULL,'2011-07-31',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'A','P',2,'2011-07-31',2,2,NULL),
 (53,'FE-002-20110731-002-0000036',2,'53',NULL,'2011-07-31',1,'22908.0000','2748.9600','22908.0000','0.0000',0,0,'A','P',2,'2011-07-31',2,2,NULL),
 (54,'FE-002-20110731-002-0000037',2,'ed83da7d-d075-4011-969f-c616e64eda66',NULL,'2011-07-31',1,'2.0000','0.2400','2.0000','0.0000',0,0,'P','P',2,'2011-07-31',2,NULL,NULL),
 (55,'FE-002-20110731-002-0000038',2,'54',1,'2011-07-31',1,'34434.0000','4132.0800','34434.0000','0.0000',0,0,'A','M',2,'2011-07-31',2,NULL,1),
 (56,'FE-002-20110731-002-0000039',2,'55',1,'2011-07-31',1,'34434.0000','4132.0800','34434.0000','0.0000',0,0,'A','M',2,'2011-07-31',2,NULL,1),
 (57,'FE-002-20110801-002-0000040',2,'56',NULL,'2011-08-01',1,'11454.0000','1374.4800','11454.0000','0.0000',0,0,'F','P',2,'2011-08-01',2,2,NULL);
/*!40000 ALTER TABLE `facturaencabezado` ENABLE KEYS */;


--
-- Definition of table `inventario`
--

DROP TABLE IF EXISTS `inventario`;
CREATE TABLE `inventario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idproductos` int(11) NOT NULL,
  `idsucursales` int(11) NOT NULL,
  `cantidad` int(11) unsigned NOT NULL,
  `usu` int(11) DEFAULT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Productos_Sucursal` (`idproductos`,`idsucursales`),
  KEY `fk_Inventario_Productos1` (`idproductos`),
  KEY `fk_Inventario_Sucursales1` (`idsucursales`),
  CONSTRAINT `fk_Inventario_Productos1` FOREIGN KEY (`idproductos`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Inventario_Sucursales1` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventario`
--

/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
INSERT INTO `inventario` VALUES  (8,2,1,2522,2,'2011-05-23 23:25:59'),
 (9,9,1,2490,2,'2011-04-04 22:21:19'),
 (12,5,2,5,2,'2011-02-26 14:59:26'),
 (13,10,1,358,2,'2011-04-04 22:22:31'),
 (14,9,2,149,2,'2011-04-04 22:13:58'),
 (15,6,2,24,2,'2011-04-04 22:13:58'),
 (16,10,2,1758,2,'2011-07-26 23:50:34'),
 (17,2,2,28,2,'2011-08-01 21:30:58');
/*!40000 ALTER TABLE `inventario` ENABLE KEYS */;


--
-- Definition of table `marcas`
--

DROP TABLE IF EXISTS `marcas`;
CREATE TABLE `marcas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `habilitado` int(1) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Descripción` (`descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `marcas`
--

/*!40000 ALTER TABLE `marcas` DISABLE KEYS */;
INSERT INTO `marcas` VALUES  (10,'KMF',1,1,'2011-01-09 00:00:00'),
 (11,'YAMAHA',1,1,'2011-01-09 00:00:00'),
 (12,'HONDA',1,2,'2011-03-23 00:00:00'),
 (13,'KAWASAKI',0,2,'2011-06-22 00:00:00'),
 (14,'Italika',1,2,'2011-08-16 00:00:00');
/*!40000 ALTER TABLE `marcas` ENABLE KEYS */;


--
-- Definition of table `modelos`
--

DROP TABLE IF EXISTS `modelos`;
CREATE TABLE `modelos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `habilitado` int(1) NOT NULL,
  `idderivada` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Modelos_Marcas1` (`idderivada`),
  KEY `Descripcion` (`descripcion`),
  CONSTRAINT `fk_Modelos_Marcas1` FOREIGN KEY (`idderivada`) REFERENCES `marcas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `modelos`
--

/*!40000 ALTER TABLE `modelos` DISABLE KEYS */;
INSERT INTO `modelos` VALUES  (1,'YZ250M',1,11,1,'2011-01-12 00:00:00'),
 (2,'XT200',1,10,2,'2011-03-29 00:00:00');
/*!40000 ALTER TABLE `modelos` ENABLE KEYS */;


--
-- Definition of table `motocicletas`
--

DROP TABLE IF EXISTS `motocicletas`;
CREATE TABLE `motocicletas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `motor` varchar(45) NOT NULL,
  `chasis` varchar(45) NOT NULL,
  `idmarcas` int(11) NOT NULL,
  `idmodelos` int(11) NOT NULL,
  `idtiposmotocicletas` int(11) NOT NULL,
  `idsucursales` int(11) NOT NULL,
  `cilindraje` int(11) NOT NULL,
  `anio` int(11) NOT NULL,
  `precioventa` decimal(15,2) NOT NULL,
  `precioingreso` decimal(15,2) NOT NULL,
  `fechaingreso` date NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `estado` varchar(5) NOT NULL COMMENT 'V vendida, P pendiente',
  `hp` int(10) unsigned NOT NULL,
  `idproveedor` int(11) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `motor_UNIQUE` (`motor`),
  UNIQUE KEY `chasis_UNIQUE` (`chasis`),
  KEY `fk_Motocicletas_Marcas1` (`idmarcas`),
  KEY `fk_Motocicletas_Modelos1` (`idmodelos`),
  KEY `fk_Motocicletas_TiposMotocicletas1` (`idtiposmotocicletas`),
  KEY `fk_Motocicletas_Sucursales1` (`idsucursales`),
  CONSTRAINT `fk_Motocicletas_Marcas1` FOREIGN KEY (`idmarcas`) REFERENCES `marcas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Motocicletas_Modelos1` FOREIGN KEY (`idmodelos`) REFERENCES `modelos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Motocicletas_Sucursales1` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Motocicletas_TiposMotocicletas1` FOREIGN KEY (`idtiposmotocicletas`) REFERENCES `tiposmotocicletas` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `motocicletas`
--

/*!40000 ALTER TABLE `motocicletas` DISABLE KEYS */;
INSERT INTO `motocicletas` VALUES  (1,'jdfk33kjfd3','kdkj43d34',10,2,10,1,434,3343,'34434.00','0.00','2011-04-04',2,'2011-07-31 20:17:57','I',334,1),
 (2,'kdie43dki3','kdk43',10,2,10,2,343,343,'578548754.00','433.00','2011-04-04',2,'2011-04-04 23:56:54','I',343,1),
 (3,'432r34e','432d232dd43',11,1,11,1,234,2222,'3424.00','424234.00','2011-04-05',2,'2011-07-22 20:55:42','F',343,1),
 (4,'jd9j349k','kjkd93jk',11,1,10,1,933,3333,'4323.00','4234.00','2011-04-06',2,'2011-07-22 20:58:06','F',343,1),
 (5,'034io3io','343242lljkjk34',10,2,10,2,342,3424,'342342.00','34234.00','2011-04-06',2,'2011-06-16 20:05:21','F',342,1),
 (6,'34234w','3423',10,2,10,2,32,3423,'45345.00','43535.00','2011-04-06',2,'2011-07-22 20:48:31','F',342,2),
 (8,'34324','3423dsfdewerse234',11,1,10,1,34,3333,'43242.00','2343.00','2011-04-04',2,'2011-07-22 20:50:01','F',3,2),
 (9,'jkdfjk3939jidi','993jds932jd9jk9',10,2,10,1,333,3234,'434234.00','342.00','2011-05-30',2,'2011-07-23 14:02:52','F',333,1),
 (10,'saulmayorquin22299','kjdskjdkfs934234k9',10,2,10,2,342,3434,'34234.00','34234.00','2011-05-30',2,'2011-05-30 23:31:00','I',342,1),
 (11,'1324234dfdfssdfkl42342','342343421234fsdfw4r4234fdsfs32',10,2,10,1,342,3424,'23123.00','32132.00','2011-06-09',2,'2011-06-16 20:16:23','F',342,1);
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
INSERT INTO `motocicletasimagenes` VALUES  (5,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28CD31E5541C9C5003E8AA2DA9C01F66F5DDE99A9A3BB8DFA30A00B14520607A1A5A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A29ACEAA32C40A00754724A91AE588154A7D446E2900DEDED55FC9798EEB8724F6553C5653AB186E3487DD6AEB146CC91BB81D76826B95BEF10CF72C513312FA1E0D75CA15570A001EC2AADD6996778A44B02E7FBCA307F315CB2C4B64CE9C9AD19C46E62DBB71CFAE6ADDBEA373011B64240EC6B4AE7C2E546EB49BE88FFE35953D95DDA67CF8182FF7874A519F6672B85481B56BE2265C0941FAD6D5B6B30CC07CE327D6B864656E9D6A45254E54915B2ACD6E38D66B73D152E51FA1A98303DEB808352B883187C8F435AD6BE20C604808ADA3562CDA3562CEAA8ACDB7D561980C30ABA93A38E0D68684B4526734B40051451400514514005145140051451400514514005145140051451400514514005145140051451400514521A005CD21200A8A5B8489492C2B9DD4BC491C79480EF7FD293924AEC4E4A2AECDDBABE8ADD0B330181DCD6425F477EC4FDA576FF701C1AE52EAF67BC62D2B9FA678AAC23C1DC0956F51C1AE6A955C95A3A18FB7B3D8EFD116350100029FBAB8AB7D4EFAD78594BAFA3F3FAD6ADB78910E05CC4C87D57915C6E12368D7833A1CD19AA76F7F6D743F7332B1F406AC66A36364D3D89375070C3900FD6999A334014EE747B2B9C931EC7FEF2F5AC9B8F0FDC45936F20907653D6BA2CD2E6A94DA3395284B747152C735BB159A27423DB8FCE9A194F435DABA248BB5D430F423359B73A15A4E4B266273DD4F1F955AA8BA9CF2C33FB2CE796464395620D5C8358B887AB6E14DB9D0EF6024C589907A75FCAB2E46689F64C8D1B7A30C56B19B5B332B4E99D6DAF88A36C073B4FBD6C41A94528E181FC6BCFE1B79AE119E35F90705CF406A616D7F6B099DB30A0E85CE037D3D6BA2355F54691ACFAA3D156556E8453C106BCF6DBC497106048370F5ADDB3F13DB4B8567DADFED568A7166B1A91674D455386FE2940218735695D5BA1AB2C7514514005145140051451400514514005145140051451400514668CD00145359C28C9359B7DAC4168A77B807D3BD0DD81B4B7341E55404938AC6D475E82D4101B73FA0AE7AFF005EB8BA25623B13D7BD6492598962493DEB09D64B48984EB74897AF756B9BD63962A9FDD15440A555DC7007356E2D3A79392BB47BD60DB9339EEE4CA805380AD54D2E34E647247A631532DB5AC5D173F5E69F2B1A833182F34A133DAB6F16E3A44BFF007CD2FEE7FE798FCA8E41F279987E58CE46411E9C55A8351BDB6C6D977A8FE17AD2C41FF3CD7FEF9A6B5BDB49D4007DB8A4E9DC694A3B3160F1021216E22287BB0E95A50DEC138CC72A9FC7158F269A8C3E46C7D79ACF9ACE480EEC11E8CB59CA89B2AD38FC48EBF752EEAE421D4EF6DBEEC9BD7D1F9FD6B460F114678B88CC67D4722B274E48D635E1237B752EEAA76F7D6F743F7332BFB03D2A7DD506C9AE84BBAA29A086E10ACB1AB83D72297751BA8B81461D16D6DEE84F082B83F733F2D2DF4860124D25B4D3EE233B48E07B0ABDBA8DD5AC6B4A3A10E9C6C6669DA8DBC8AF288E3B2B7438D920E58D66F89FECB33AC968B18751972A7AD6E5D585ADEA159E156F7C73F9D705E2B863D12E228EDB3B6452DF337DDADE35B9FDDB1854A6E31161D56E2CC8293951E84F5AEF3C3FA94B7702B4AC84E3F86BC5BED0F34A09CC873C93D07D2BD4BC1A196D53312C631D8F5AE8A572695CEE81C8A5A6A7DD14EAD8DC28A28A0028A28A0028A28A0028A28A0028A6B3051926A95DEA50DAA12EE063DE802EB385EF59F79AAC16A84BB815CDDFF89249494B71807F88D61C92C93BEE91CB1F7AC65592D8C67592D8D9BFF114B3E5600557D6B15DDE56DCEC58FA9A4029C16B9E5372DCE694DCB71B8ABB6B60F71866F953D6996B08967553D3BD6F0508B81D00E29C6371C237D595C456F6511623007538C9AAAF757771B4C3091093C9575DE47B026AC4877939E4552D3A0B79B5FF00F48C4463C18C0E371FAF7A26DA5A1D34926EC5AB7B5B8B8CADBDC12E3EF25C29C8FC40C53AE6CE3B4B3926B89E4B994F0120C10BF4FF00EBD745749712438B695637F565DC0D62C7A4DC9908319B553C97867C027D4A815873B7D4E8E48F632ECA46588F9B3020F203F0C3EB56525123EC45766F653FCEAE95D393747712D9DDDDA9C2A950A4FB1EB4926AB342B1A15364475578B29FF7D55FB57D0CFD926EE54919E1FF005B148A3E99FE5491CD1CBF71B27D3A1ADCD3F507BB5F9D1197A09226DCA7FC2B37C4705A5BDB8990AC5744FC9B782FFE342AAEF662745742359197DC54E0875E7907AD5384B1850C830C4735660CE0FA56E60656A569E41F313EE9EDE9598CD5BDAB3AAD9107B9E2B9B2D5125A994D598A4ED39562A7D41AB76FAD5F5AFF00CB412AFF0075FB56796A616A9693DC2329476674D6DE2981C85B88DA33DD8722B620BEB6B9506299181E9CF35E7C4E6A9CD7D1DB313139F37B6C359BA29EC6F1C44BA9EA9BA977572FE0FD46E2FF004F99AE242EC8F81939205747BAB092E5763AE2EEAE4BBABCEFE231CEA167C163E51E3B7535DFEEAF3DF88673A85A03B8E633C0EFC9ABA3F1A22AFC0CE423E641925CE7A2F415EB1E0B005AA62365E3AB1EB5E4F11C3804EDC1FBABDBEB5EB1E0CC1B5520C84E3ABFF4AF469EE73D3DCEED3EE8A75353EE8A756C6E14514500145148481400B9A33504B731C60E587158F7BE22B783215F737A0A4DA5B89B4B7371A5551C9AA175AB5BDB292F2018AE4EE75EB8B97DAADE5A1EA472454B1E832DD5B9BB9A7609EA572C47D2B3756FF099BAB7F85162EFC4724C4C76C873EA6B324B0D4EE58BCB1B9EF92454F168D76B32CB6EA92459E19C601FAD6FCA6E6E047BED236788646C9C7F2C567ACBE233D65F11C62C3231C04727D36D38DBCAA32D1B81EA56BA1B7D4E45BE905CA470050412A30C3FC6A59B5BB796D1A0576766EACE3B5472C6DB99F246DB9CC62940A9644457FDDB165F52314D02B33324B693C9995FB77ADC470EA181C8358152C33C909F91BF03551958B8CAC69C91907207150490C730C3AE71DFA1A747A8A1FF00580835387825E8C3E99AD34668A4BA15D04F0AED82E65897D060FF003A24592E062E26797EA71FCAAC983D1BF4A6F92DED4B91762F9A5DCA373E4410E5A2DC3D075FCEA5B2B7744FB44B7AB6D678C98B21D8FD739FD2AC34058618022A25D360041F25011C8E2A650722A13E5DC9FF00B6628D248ECECA7589B38963DA39F500D51B8BA478099A78AF95704895583AFD3000ABAC8918CBB803F2A864BDB180026456FA726A7D925D4AF6DDCAD6B0CD2CE24884915B11F724C67F0AD19258EDA22CEC00159173AFF51027D19AB22E2EE6B86CCAE4FE3C0AB4D256309545D0B5A96A06EE5F9788D7A56796A616A866B88E15CC8D81FCEA77327A9316AAD3DDC500F99BE6ECA3AD66DD6A8CC0843E5A7A9EA7E959AF33312D9C03FC4DD4D5288D44BD75A93C9919D8A7F84753541E466EA4A83DBB9A61E39FBB9EAC7A9A3EEF23E507F88F535562923D07C0071A4CE318FDE7E35D76EAE3BC0671A5CFC1FF0059DFBD759BABCFABF1B3BE9FC289435701F104E6FAD3E6C0F2CF03A9E4D777BAB82F1F1FF4FB53B82FEECF3DFA9E95543E344D6F819CAC5C32F22319E3B9FC6BD5FC18C0DB2FEF4C9C0ED8C5793C430E0801727AB7535EB3E0C626D541911B03F8074AF4A9EE73D3DCEE93EE8A75353EE8A756C6E145145002374AC1D635896C948581BFDE2462B75FEED70DE2B71B5866727D0E76D4CDB4B4226DA5A142E752B9BB24BC8769EC0D6AE8F616DA82179551420C150C72E7F1AE0C5D3C6E02C8E873D0F4ABB6DAA48986619C1FBE87A572A6EF77A9CA9BBDDEA76F77A2ACA91A45125B9249FBDC0FAE7FA558B0B496187CA4D49B1FECAE573F88AE406AAB7807993B1C70039C1ADA8B5A9ADE08E2B745509CE5FE639AA528DEF6294E37BD8B1A835F585E45E75D974EC5001C7D2923D7160C2431B053F7A46FBC7FA5509EF9EE72D22AB39EAC4671F4AAB50E6D3D097369E858BD9A2B89DA48E32A09E7279355C0A5A2A1BB90DDC28A2909A042D213485A985A801C4D37791D0D30B530B53026F3E453C3B7E74E17F70BD253550B530B531DD971B52BAFF9EA7F2150497D3BF595AAB16A633501764AD3B9EAEC7F1A84B534B5319C28249000F5A00796F7A8A49563525D801EA6A85C6A8AB95846E3DD8F4159335CBCCC4925C8EE7A2D524524695CEA9C110E157FBEDFD2B2E49DA424E493DDDBFA54449727F8C8EE7EE8A43F367F8C8EE7EEAD5245585C92491CFABB7F4A4F5239F576FE941F9BFDB23F05147DE24FDF23BFF08A630EA491CFAB9FE940EE47FDF6DFD28FBC7FBE477EC28FBD9FE223B9FBA2803BBF02B7FC4B27E49FDE753DEBAADD5C9F821BFE25B3E5B27CCFC2BA8DD5E6D6FE233BA9FC08977570BE3A24DF5A9007119F98F6E4D76BBAB88F1C7CD7D6BF2E488CF27A0E4D561FF88855BE067310F32640DDCF56EF5EB5E0D0C2D501545E3A2D792C5F3480105C83F403E95EB1E0C4DB6AB8844608F5C935E9D3DCE7A7B9DDA7DD14EA6A7DD14EAD8D828A28A006BFDDAE17C58E0AB0FB431FF636D774FF0076B86F163BEC60678F6FF740F9BF9D44FE122A7C2704C7E60038FF00758520F948CA9439EAA72295F2C40CAB8F43D4D229098505A339FBA7915CC72922BB10482928CF5E8454F15DBC5BB6C8F1F3D1F9CD55DB91968D5C83F790F4A7862DBB1203CF3E60FE5401AF1EA6CBFEB63C8F5435722BC826E1641BB1D0D73A711E4ED7889EEBCE69E1998F212418E838353626C74C0E7E9499AC08EF648C8092B2903EEBF4156E3D4C855F35323BBA9E3F2A56158D32D4D2D55A3BC865036B8C9EC7834F2D4AC21E5A985A985E985A980E2F4C2F4C2D4C2D4C63CB530B530B534B50038B530B7A9AAB717D141C13B9FF00BA39AC8B9D424949524853FC0BFD69A434AE69DCEA31C476A7CEFEDD2B22E2F5E66F998B1FEEAF41559DC9F94F03FB8BD7F1A6F4F94F03B22F5FC6AD22D2B0ACC59B04EE3FDD1D0521E4E0FCC7B2AF41F5A3A70781D917FAD1D3E53C03D117FAD3181E4E0FCC7FBA3A0A0F3C1F98FF00757A0A0F1C1E07645FE4683C0DA781D917FAD00079383F311FC2BD07D683D707E623F857A0A0F030781D957AFE341E3E53C0EC8BFD68003C9C1F98F651D05079383F31FEE8E828E9F2F41D917AFE3474F94F03FB8BFD6803B6F051C69D38E3FD6741DABA70D5CAF8338D3A61803F79D3D2BA6CD7975BF88CEFA5F0224DD5C578DB9BDB5E093E59C01D3A9EB5D8E6B97F12E9F36A1A85BA459DBB3E6C7D4D5E1B5A889ABAC6C7231F320072C73F753B57ADF82E2C59A111C8B9EEFDEB1743F07AC655DD3247A8AF41D3EC45B200057AF18B4630835AB3497EE8A5A00E28AB340A28A2801AFF0076B87F168711B1D9081FDE1F7ABB87FBB5C378B230119BECEA3FE9A16FE9513D88A9F09C1B824825430F51D69A878003F19FB8FD695C00C18A107FBEA68425C70CAE33D1B8635CC72815C7DE46539FE03C53C12FBB052503BF4C53061381BE2E7A7514F2B9C96457F743D28017214B61DA327FBE3229597BB2718FBD19E4D26E27216407DA4141C21CED68CE3EF2F39A0050776143ABF1F718734CFBA41F9A33EBD569E416C64248B8E8386A667185566538FBAC3814009BDB00E15C7F787069D1DE3C7C2CA473F75FA9A8D9718629CFF790F02A324B0E1838CFF1F06803457522389633F55E6A64BA8A5CEC7071D6B0D884C81BE3E7A75148CCC725955FD0A1A2C2B1BC5A9A5AB152F245276CBD07490714FB8BF94443184E396F5FA52B0AC5F9EEA28172EDCF603A9AC9BAD49DC100F9687A7A9AA324CCC4B038CF576EA7E95167AB0E3D59BA9FA55245243DE4639C9DA0FE2C699D07F701FCCD1D32C38CFF001B75340E3E61F2E7AB3753F4AA280F03FB83F534741CFCA0F6FE234741B87CBEACDD4FD28E9F30E33D59BA9FA5001D073F283F99A3A0FEE83F99A071F30F97D59BA9FA51D8B0E33D59BA9FA5001D07F701FC49A0FCA3FB8A7F163474CB0F947766EA7E94740587CBEAEDD4FD28003F28FEE03F9B51D07F741FCCD1D06E1C67AB3753F4A3A65871EACDD4FD28003C7FB20FE668E83FB80FE668F561C67AB3753F4A960B796E1F10A124FF00111D6803ADF0771A7CD8040F33BF5ADE96E63847CCDC9E8077AC6D0346D422B73121DA1DB73377AECB4CF0CA4644920DCE7A935CFF0053739B949D91D9095A29191043797C40890C687F88F5AE834EF0FAC243C99673D49ADB82CA385400A2AD0000AECA74A14D7BA81B6C861B64880C0153018A5A2B5105145140051451400D7FBB5C278B1570C7CA973EA4FCB5DDBFDDAE13C58CA55977CC4E7EEE3E5A89EC454F84E11F01C7DE43F98A002C3242B8CFDF5E0D0C70C0072A7FBAC38A00E8CC9CE7EF21E05731CA2AB00081215E7EEB8E4D2918CEE464F4D869012C0E1D5C67F8C60D2F099C6F8B27A75CD003F25C1C6C971DBA62932149C334671CEEE452B2EECEE45718FE03CD0189242BF38FBB20E0500232E704A6463EF21E4D37390AAAE187F718734E202FCDB590E3EFAF34D39600FCB20FC9A802360148C86439EDF7698D9719C2C833F7870453C90B850CC9CFDD3D298E33CB20273F790F4A008890320395E7A38EB51B8C677215F7435292581C38619FE318351361338DD193E9CE698C6312D900AC9C743C62A39C61010A4607258F03E95238273B955F8FE13CD473E0A0003310380DD05302A75248F98FF78F41F4A3AE48E4F763D3F0A0FCC4E7E723F055A3EF139F9C8FFBE4531875248F9BD58F41F4A3A9C8F98FF78F4147DE3CFCC47FDF228EA79F9C8FC00A003A92C3E63DD8F41F4A072723E6F566E83E941F98FF007C8FC00A3A9E7E723F214000E791C9EEC7A7E140E72473EACDD07D28FBC79F9C8FC851F78F3F311F92D001D4961CFAB374FC28EB961F37AB1E83E94753FDF23F0514A0191B681BDBB003814009D4923E6F566E83E94E8E3795F11A9763FC47A0FA56BE9DE1EBABE652EA76F618E2BBBD1FC231C214B273EB56A0D971A6D9C6697E17B8BB757941E4FA577DA478562B75525066BA6B3D2A28146140AD158D54702B45148DA3148A76BA7C7028C28AB8AA147029D4551414514500145145001451450014514500237DDAE17C5AE3632FDA41FF00636F35DD1191597A969B15E465648C30F715325756264AEAC78E31C90A181FF65BA9A40029190D1B67B72B5D8EA3E140599A35C7A62B9F9F46BAB53850768EDDAB0709239DD3922872E33849067EF0E08A50C1776D90AF3C89067F2A1E2643FBC84839EABC62943160D870E3FDB1822A081597192D195F4319EB4B92FC029271F74F04521C213F7E23EA39CD291BBEF2AC831FC27068013852396438FE2E54534824062808FEFA1E69C0F2155F9C7DD71C0A690010C54A9FEFAF4A0066780AAE0F3F75C726A27017EF2B21CFF0F4A94E580E55C7BF06A2242F00B47CFDD3C8A006365C1C059067A8E315112173872B9ECE3AD48E339DC809CF5434C249DD870DECE3A531913AE3259081EA87AD327C346A371738E83FAD3DB0B9E1A3E3A8E734DB83FBB196E08E8BD4D302A1E4ED3D47445EDF5A43CFCA7AFF00717B7D683C0C7DD07F84753F5A0F031F747F757A9FAD3181E4ED3C91FC0BFD683CFCA7AFF717FAD078E3EE8FEE8EA7EB41E38FBA0FF0AF53F5A000F2429E4FF757FAD1D7E53C91D117A0FAD078183F283FC2BD4FD68E8307E51FDD5EA7EB40075F94F247455EDF5A0F242F53D917FAD5CB3D36E6F582C68554FB5765A2F8371B5A45C9AA516CA8C5B393B1D16EAFD946CDA87B0AEDF45F072C6159D327E95D7E9FA1456EA3E51C7B56D456E918C015AA8A46D18246658E8D0DBA8C28E2B552258C600A93A51545851451400514514005145140051451400514514005145140052100D2D140113C08E39154E7D2E29472A3F2AD1A280395BCF0D452670BFA573B7BE1565C955CD7A59506A37811FAAD4B8A7B92E29EE78F4FA55D5B96C6EFF81722A9B21527CC8D97FDA4EB5EBF3E9514A395158D79E1A8E4C95519ACDD25D0CDD1EC79C125B0A0AC981F74F5A61C291CB46DE879515D4DEF85DD72556B0EE34BBAB7E304A8EC47159B84919384919EC0B00C51587F7D6A32DC615F8CFDD71C9A92442846F8CAB03D57A5464961D56419FE2E0D49244E319DCAC9CFF0F4A6365F380920F6E08A7B617382F1F3D0F39A8DC752C80FBA1A632324293872A71FC638A6DC644633B5411D4753F4A792493870DC7471D29938C4790A14E39627F953029FDDCFF003DCFDE6A3A67F841EE7EF1A3D587E2CDFD281DC8FC5DBBFD298C0FCBFEC83DCFDE347DDE7EE03DCF5352430C93BE2242CC7F888AE9349F09CD72C1E604E79A6A2DEC528B7B1CF5B59CF74DB218C807A9EE6BACD1FC1EEECAF32924FAD767A578622B755F90574D6F631C2A00515AA825B9AC69A5B987A678761B755F907E55D0436A9128000A9C2851C52D59A08000314B45140051451400514514005145140051451400514514005145140051451400514514005145140051451400521506968A0085EDD1FA8AA371A4C5283F28FCAB528A00E42F7C2F1499C2FE42B99BFF093A92D18FD2BD50A83DAA17B647EA054B8A64B8A7B9E2773A4DEDB67E52C3BE466B31D76E772B21FF66BDC6E34886507282B06FF00C2904D9FDD8CD43A5D8CDD2EC794B65F23E4938E9D08A8E71F20214F03F8BA0AEC2FFC1922E4C59FC6B317C2F79349B24076AF4A8E46999F249339954695F080C8C7B9E83E95B9A67866E2F5D5A5071E95D9E8FE0F48B696404FB8AEC6CF498A051F28AD153EE6B1A7DCE6747F09C50052539F5AEB2D74E8A0500281F855D48D507029F5A1A8D540A38A7514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500148541EA2968A00824B547EA054234F8836768ABB45004690A20C015251450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145007FFFD900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,2,'2011-04-06'),
 (6,NULL,2,'2011-04-06'),
 (8,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F9FE8A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A31462800A28C518A0028A28C5001451462800A28C518A0028A306970680128A3068A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A0024E00A904129E91B1FC28023A2ADC5A75CCB8DB1FE7C54E345BB2795503FDEA00CEC50462B663D0891F3C841F6A906811FF00CF76FCA803069703D6BA14D0A21D58B7E153AE8F6E3AC59A00E5E8AEAC6916A7FE5DE94E8F6A3FE5DE80393A4C575BFD8F6DFF003EF42E916C7816DFA1A00E4FF0A50326BAF1E1B59BEEC4547D2ACC3E10895833827DB156A0D90E691C46C6EC0D288643D2373FF01AF4FB5D0EC600336618FBE6B5ED60D3E320359A28F619AE8861E0F799CD531338ED0B9E362DE6C7FAA7FF00BE4D218641D5187FC06BDE638348970AA801F75A99FC31A5DD2E42C473EE2B6FA941FC3339DE6338FC54D9F3F1523A83F95271E95ED97BE00B19012B081F4AE5352F87FE59668091ED8A99602A2578BB9A4332A52766AC79F1C5256B5EE837964C77A1C0ACC2A54905706B9274E707692B1DB0A909ABC5DC8F1462968ACCB128A5A4A0028A28A0028A28A0028A28A0028A28A0028A28A002940E2929C3D2801B8A5029C14B1C01935A563A15FDF301140D8F52294A518ABB60DD8D5B5B2B5F2236F217763AE2AFC56CC5711C600AB36DA54D1C691B9E54608AE9B4ED20F939E2A79D7715D1CBA584EDEA2ACA69721EB5DC59F87FCCC926ADB68022FE1CFD29F3AEE173815D23279156174641FC19FC2BAE92D62B7FF589B40EE6ABB5FE9D17DE9E21F5354B5D8673ABA428E917E9520D376FFCB1FD2B565D7B4B87ADD43FF7D55593C5DA445D6656FA1A00AC2C0E3887F4A536454730FE9528F1A68C4FDFFD6ACDA789B4CBD902A1CD528B93B213928ABB2A45A7B4A7FD4FE95A706951AE098F9FA5743A7C9692A8D98FC6B6A3D3A194020C75D1EC6515AA39255E2DE8CE563B489463CB1527D9A13FF2CC5749268E9DB93ED54E6D265404AA9C54B4D0D34F66639B484FF08A8DAC203DAAF4913C470E3151923B0CD22AC507D32261F29C5422C2484E62720D69E452124F7A6AEB5B834BAA2B457F7D6E71231751EF565750B5BB255E32AFF4A46C7A03F5A85A34273800FB56D4EBCE2CE6A98684D14755D2A3994E10106B80D6BC34A0B346A01AF528E3F31480D9FAD62EA966558E5457746A42AAB3470F2D4C3BBA678B5C5A496CC43AD56C57A06AFA6A4CAD85E6B89BBB46B790861C579D88C37B3D63B1EB61F12AAAB3DCAA6929C7A714DC5721D4145145001451450014514500145145001460D029DD6801B562D2D64BA942460E4D47126F703AE6BB9F0EE9890C61D802D9EB8AC3115D518DFA913972A2DF873C1C85965BAE4FA1AF4ED2746B78955523503D71589A7B850BED5D459DC828064015E054AB3A8EF267339391C55E42A97D3003A31AD9D3D3F71D3B5635DB937D363FBC6B6B4F6FDC7E15ED47E14742D8E874D41B7A56A3DAEF4CA839ACCD35B22B691D5539359D6BF268296C72BADE90D750BA962A71D8D78FF897C357764E658E576527D4D7BC5F4919072735C8EAD0C72C6CAC0106BCDA589A94E57B9829B4CF0290C8AE56466C8F535112738AE9BC51A4FD9A76950704F415CC918E6BDFA5515582923AE32BA1CAA4B01DC9AEE7C3764B12ABB0E6B8FD3E3125C006BBBD3CF96AA057A98282F899C18E9E9CA779A548AAA0715D35B5C28039AE1EC6E766306B720BD381CD773D59E3DACCEA96EBFDAA905D631C823D2B9D4BD3EB4FFB693DEA1C514A6D1B33343700878C0F7AC5BCB3F289688F14A6F38EB4D3779041E6B39D08C9686F4F1338BF228961F8F7A4DF51DE4FE590D8C83E9DAA24B859002A7AD714E0E0ECCF469D45515D160B546ED8E69ACD834D27350684B0CA5241E9576F6D16EAD8B2F5C5668E1C7D6B6E005A003B1AA849C591382946CCF3FBE80AB32B5725ACE9E1A366039AF44D7AD562B8207A572B7D0864618ED5E96952163CDA6DD399E70EA5588F434CAB9A8C422B8207AD53AF166AD268F7A2EF14C4A28A2A4614514500145145001451450028A285EB4BD6805B9774C50F74A08AF43B31B2340BD302BCF34C904576A4D7A0D9B874520F1815E56657BA39EA9B96F332815AB6D78571CD64DB26E02B463878AF28C471B689E42F8E49CD6FE9F671187A76AC458D87AD584B9B88C615C8AF41635256B1AFB43A58904230052DC5DF9511C9ED5CD3EA17407FAC354A7BE9D861A43515317CF1E5B039DD1A773A98248CD61DE5E7984E0D559E73CF26B3A59F39E715C4B73133FC42166B4248E466BCE24E1CFD6BBDD6AE36DA107BD704E72E4F6CD7B79726A9BB9D54AF62F6967FD2057636CF802B89B39047700D75D6EF94520D7D0E0A5A58E2C74754CE82DE7200E6B4E2BA231CD73B0B9E39ABD1C878AEC3CE92D4DE5BC3EB522DE1F5AC5121A956538A0868D7177EF4BF6A1EB597BF8A915B8CD04D8BB34A258997B915911DC35B5C6D278CD5B6936C65AB2247DD31607249AE4C4A563B7077B9D3472891037AD3B354B4F62D08CFA55DC1AE43D01D182D20FAD7416A8444056458C05E407B56F281180281F4B9CDF8823FDF93ED5C85E20018D763E2060D3120F18AE3B5191562624E2BD4A7A41367912D6AD8F3BD631F6B359D56F51904972C47A9AA95E355D66D9EF5256820A4345150585145140051451400514514000A5CF340345003D1F638615D768BAA29408CDCD71D524533C2C194F4AC6BD18D58D99128F323D86C6E90A8C356F5BBA150735E4BA6F887CBDAAE71F5AEBACB5F465186CD785570F3A5D0E7942C7729B4FA52B2AFB57370EB2A71F38FCEACFF006B2E33BC7E75859906A48A07A5675C95E718AAB2EAC083F3566DC6AA307073459B0B325B990007A5645CDC22062C718AAB7DAC4680E5F9FAD72FA86B2F3E554F15D987C2CA7BA348C2E3B59D48CEC6353C0358B9E28662C72D40E6BDCA5054E36474A5642AB6D208F5AE934ABC52A158F35CD647E1535BCED0C80835D342AFB3919D6A6A713BC8A401873C55F89B38AE6EC7504954648CD6EDACD923915EB465192BA3C5A90717666A46A48A956324D36160C055F8A2CE2A8C2E42B11A90426AE2C38155EF2E63B74C039634A52E5428A73959146F66544083BD5045048C0E4D3DD8C8C588CE7A55BB1B53238623A579D5A7CECF5A852F66B534AC232B10C8AD0861695F683C5105B33E140E9E95B96768B10DCCBCD64CD92D0759DA886304F5A74F22C713123B54CEEA884E4002B9AD5754DD98D58003BD6D469B9330AF55421632F53BADC5813C66B84F11EA4891B468DC9AD4D735D8ED9195482D5E7B7774D75317635BE26B28AE546382C3394B9E45766DC493D49A6D29A4AF2D9EC09452E2929005145140051451400514B8A38A000528029514B3614124D743A3F85EE75075250ED35152A469ABC989C9475660470C92B62342C7DAB734DF09DFEA043794553D48AF4AD23C2163A6C2269D3E61FDE353DD5F895FC9B28D55471C0AF36A662DE904632ACDEC719178360B7C798FB9FD01AD7B5F0B3BA7EED4AAFAD75FA56845C892404B1E79AEB6D7498D540DA2B8A588A927AB32736CF2C3E14BD4E54B544FA06A49D0357B27F67A01F74531B4E43FC03F2A4AAF742B9E39FD83A930C156FCA90785EF58FCF902BD8FFB353FB83F2A69D2D0F61F9557B55D105D9E2D73E112CBF3AB1F7AC99FC15E603E492187635EF3368C8EA781F95606A1A014CBC63047A5358AA91F858D4E5D0F07BFF0DDFD8925A22CBEB8AC8742870CA41AF7B5487982EE207B722B1759F01DB5EC6D35BAE09F4AECA5997D9A88D6357B9E39D6802B7356F0DDD69B230642547B56260E718E6BD2A7523515E2CDA2EFA924733C241535B961AD052A1CD63C3653CC46C8D8D6A43E1CBA930D20D83E95D947DAAF856873D6F64FE2675567AAC6E06D615B76FA92AA8258115C5C3A43DBF08E49FAD68436F2200598E7EB5DAEBF2AD56A707D514DE8F43A69B58DC36A71545E6323658E735451257380335B361A64D290594E2B92751CB73AA9D08D3D109696CF2B03B78AE9AC74FCA8E314EB3B34814657A568999557E51B40EF599AD996208520519EB4B3DEC7021691C002B9BD5FC530D8214886F93D41AE1B50D7752D498E49543D0018ADE9D172D598CE76D8EBB59F1540A59565000F7AF3FD5FC59BCB242724F7AAF3D94970312BB7E75465D01DB2636CD6F525351E5A68C69D2A4E5CD5199171752DC3969189CD4279ABB369971083BD08FC2A9B29538208AF32719EF247A71946DEE8DA2948E38A4A8B941486968A004A29692800A28A2801D8A92185A6708A3AD3110BB051D4D75DA069206D775C9ACABD654A17264EC8B5E1EF0D06659245CFD6BD12D62B7D36DC360020550B1896DE104F61599AB6A2D23EC0DC57813A92AF2F78E572E6658D43559AFE7F2E32427B56C68BA7AF071F5CD73BA747960C6BB1D35C2A8AC9BE84E874F61022A8CF6AD688A9E9C0AC4B7B80147357A3B8F97AD2034B22818AA62E31520981E87268B8168014EDAA474AAC2603A9C1F4A904B9E73C51A8130518E9552E6DD64078A9BCDCF0291D82A1672001D49E295C574CE4758D2D64059170C2B020BF360E63B86F947AD6F7883C4D6D6B986D809653C715C9C5A55FEB5379D71958CFF0D7AF83C9EBE27DF9FBB130A988853EB71759BFB1BE8CC6906F63DC0AC1B3F04ADDCBE798F62E73CD77D67A1D9E9F1EF655000C926B0B5CF12FCC6D6C0003BB0AFA7C36070F838DD6ACE555EAD5768333E7B4D33474DAAAAF20EC2B32591EE4F236AF6A6A216937BB1773CE4D685B58BCEC302A6A6224F48E87652C325ACB56538ADC745524D69DA6872DC30CA9C1AE8B4BD03382EA2BA782C63B750028AE67EA75A39CB1F0E451282EA335AD1D8C718C2A8C56AAC1B8F4E29258B030BC55429B9113ACA0644B1A44A49EDDAB075169AE7291E552BA992D371C9E6A07B207B575D3A2A271D4C4CA4702FA3649272C7BE6A26D2303EEE3DB15DE3D82F5DA2ABCB600F38ADD2473BAACE025D2C7F76AABDA3C272ABD2BBA9AC473C565DCD8E33C552337519CF43F67B91B2E6301AAB5F785A2994BC4011ED5A573699C9C734DB4BF92D1F6CA4B27A1A728A968CA5392D62CE1AFBC3B3400940703B563CD6D2C270CB5EC725BC17D17988003E95CF6A5A0C72139406B96A60E2FE03B28E3DAD2679B515BBA8684F012C838AC6923646DAC306BCEA94A507A9E953AB1A8AF1647494E231498ACCD04A28A28035747B4371723DABD0AC2D846157D2B9BF0C5A078D64EE457691C5E5AEEC57878EABCD3697439AA49DEC25EDC79101C1AE795BCE9371F5AB3AB5C166DA0F7AAB6F818AC20AD1B9091B566DB40AE86D26C015CCDB374AD5826DAA39AC097B9D3C375D39ABC975F2F5AE6E19F819357A3B8C2E49E2981BAB75D39A9D675C64B6DF7AE56EF5C8ACE2254891FB0AC29F52D4B516E1DA343D94D6B0C3CE7E4776172EAF88D52B23BBB9F1169F660F9B36E61E9C9AC99FE20449916F6ED27FBCA6B0EC3C353DFBE5F24FABD755A7F81E104195FF015DB0C1C3A9EB4329C3D257A9239EB8F1B6AF31FF478962FA311542E75DF125F45E5BDC49B4F50AD9AF54B4F0A6971E03C0ADEE456CDB78734A43F2DB463F0AEA861A2B648A6F01056E4B9F3FC56BA8C1299407673DC8ABC35AD7ADFF8FE51DB757BEB683A61523ECB1FE55CA78AAC747D36C8B0B68B7B64631D2BB3DA575B4CC9BCBE5BD13C8750F11EA978BE4BB607720D6742769CF209EB5B525AC6F2310B804F02A4B6D1BCC6DE79155EDAA35EF338A587C3B9374E3619A6D9ADC107A7B1AECB4BD291769C562DAD8159004C8C7A57496B33DAA0079AA557A3319619AD63A9AC91840153AD5948B0373567DB6A766F26C699564F4CD5D694E473907A57550A4A7A9E6E2AACA9BE5266700600A8F83D699E60F5A619003D6BB52B6879CE57D5B1CC0735130148CFCF5A8D9EAEC45C4702AB498E6A477AAF235315CAD328359F3440E6AFC8D54E53D6824C5BAB71823BD63DD5B75C8AE8A700F3DEB3AE1030E94D3293316DEE25B4941C9D95B292C7751649E6B2EE21DC08C7150DBCED6F260F4A7765349A2DDD580901E322B99D4F424932CA30C2BB58645B84EB55AE2D95C9C75A99C5495A4553AB383D0F28BAB396D9C8607155719AEFF54D3165520AE4D7197D66D6B2118E335E66230EE0EE8F670F8955559EE52C514A692B94EA3D07C20E86DD17BE2BB59A002DB23D2BC774AD564B09460FCB5DBDBF8A925B6C17E48AF0F19859FB4724B46734E2EF72BDFB66E5969605C62A06945C4A651DEAD4233594B48D89D9176138C55E8DFDF9ACF8D8838C55B4C11C9E6B9590D1A11CC14658F150CFA834DFBA80F354DA579DC449D3D6B420B710A818193DEBB70F42EB9A47D0657967B5FDED55A114569DDC1DE7D6BA5D274C5F95E45E2B263189066BA3B393118C1ED5DA9D8FA0A9EE43921A236AD9913845000F4AD382419EBCD61C330ABD15C56B16795521737E197A64815763B8031E95811DCD585BAE3835AA6724A91B72DE2C68D213F2815E4DE2ED54EA1A9B856FDD8E82BB5D4AFF00C8B09327AA915E5371219272F9EA6AD339AA439592DB4664946456D220894002A969F18037115798D32122FD8C2AC77639AB17404485B6F18A8F4E1914FD5240BA7381D7351276474E1E2E5351382D52399AF0CF6B236F5EC0D6DF87FC56CECB6977FEB7A0CD5161F313EF59BA858798A6684E241D31C5451C4CE9CBC8F5F1F9552C553B5ACD23D384A244DC0F149E68AE3BC35AE9940B49C90EBF28C9AE9F7F381D0D7D152AAAA43991F9D62B0D3C3D574E7D0B05AA366A88C9838A6B495A1CE2BB540EE6867A85DA8258C77AAB2354AED55DCD022093A1AA528AB721AAD20CD0522949186159971175C75AD865AAB345BA994994AC6E5A293631E335B4A15D411CE6B9F9A331BE4569D85C6F0149E4537B0DAB8EBBB7DC385E6B98D5B4E12211B3E6FA576EC9B96B32F6D77027149AE68D98E9D47095D1E4F736ED6F2B2B0E86ABD757AEE9FD5C0E9CD72A7835E356A7ECE5667BF42AFB485C29CAEC87E5634CCD19AC7756353A5D23514D82373F37BD7430B2B00CA4579D2B953907157EDB57B9B7C6D638AE2AF84E7D62652A77D4F418C93523B948F3DEB8FB7F14C8B8122E6BA0D26FC6A970BB5702BCFF00AA548CAF25A1784C3BAB5944E8B4EB7D917984726AF22F5DDD7B51147B1063B0AE9FC3FA2C5A846D249D8E2BB229B563ED6738D0824736A85B903A55DB5B92876906BB91E1BB103EEFE94F5F0DD8FF0077F4AB54A4724B1F49E963958AE32455D8AE3DEBA01E1CB11FC3FA54ABA0597A1FCAA95391CD2C55230D2EB1DEA61759EF5B8BA0587707F2A77F60E9FE87F2AAE5918BC4526CE3F5C91E6B3015AB8C5B299A40A077AF5DBAF0ED9C91E11883F4ACA8BC28AB367CD207D2B48E9B9C95A7193BA396B6B299611F2D3DAD27C648AEE974285140F39BF2A43A245FF3D5BFEF9ABB992396B0468D3E6A835593FD199077AEBFFB1211FF002D5BFEF9A8E4D02DDC7CFCD44D5D1D1426A151499E645769E47069A40DC315E92DE19B27E8BCFD2B8CD5F4E5B2BA2A9F7735CB28B8ABB3DFA38B8D59591C85EA369F791DDA70072715DB69D75F68B28E5CF2CB9AE675284C967211D40A97C2F75248B242DD178AF4B2DAAE35392E7CF7126194E8FB65BA3AA2FC5216A8B776F4A426BDD3E1C733544E734E34D340885AA0715618544C2802AB0A8996AD32D46528029B479A85E126B40C79A431503B98B2DB6ECE6AA46A619B8E99ADE960E3A5675D5BF04FA5514A45FB77DE82A5921122E2B3AC24C1DB5BB12864C5244BEE71FACD8031B8C76AF35BD87C9BA74F435ED1AA5AE626E3B57957882131DD31C7535C98C8AE5E63D1CBEA3E6E5661514515E51EC0A28ED494A7AD00397961F5AF42F0A46A855B1CD79D838606BB9F075D879550D6759B713BB2F6957573D1150EC04576DE131FE8722FAB57236EA1940EE6BAAF0CDCC36D0C892C8012DC64D71D3D19EE635B941D8EA42D3C2FB542B776E79F353F3A905DC1FF003D53F3AEAD0F15A91205A704FF006AA317707FCF44FCE9DF6AB7FF009EA9F9D17443522509EF404C7AD345DDB8FF0096A9F9D2FDB2DFFE7B27E745D0AD2EC3B68F4A4299A4FB5DBFFCF64FCE8FB5DBFF00CF64FCE8E64167D8366290AFBD2FDAEDB1FEB57F3A61BAB71FF2D57F3A2E835EC215A8D94E69CD756E7FE5B2FE74C3776E7FE5AA7E745D1493BEC2E0EE15C178897FD308EB5DC1BCB65059A65E3DEB88D5DD6E2EC94208CD6559A6AC7760AEA6DB398BE422D24C7A554F0C13BAE7D41ABFAA9F2ED253DF154FC371B2995C8FBC735AE5EAF8844E7B25F526BFADCE914F1EF4B4C1C134E06BE94FCEC5A434A68C714C089A98454C56936D0057294C31D5BF2F3408E802A88CE7A538439ED56D62C9A94434019B243C74AA1736F952315D03C1C5549ADC10698B6672B08F2AEB1EF5D1DAAEF0B8AC5B88765D0E3BD749A64394538A562AF721BFB6FF004763ED5E43E2E40938C7F7ABDAB55748AD1C9C6715E27E2BB959AE70A0706B1C4AF7395F53AF029FB5395A28A2BC53DE014BD69052D00256CF87EF4DADEA738158F52452796C1875069495D58D294DC26A47BDE8F70B710A3839E056E8B62C0489C62BCBBC1DE204256291F073DCD7AB69D7092229DC0835C0D3523E8FDAFB4A7CF1611A3E4659BF3ABB1424F566FCEA7169FC6A339A9A3461C15C552473CA6848ED94FF0011FCEAD4764A7BD4B0A0C74ABD0C63D2B448E69CDA2AA58467D4D4EBA6478CED35A514231D2A5740636EDC55A89CAEAC8C09469F0B949265561D41350B4BA60FF9784FCEB8BF14BC89AD4CA2423F1AC88D2E251F2C8C7F1AAE4447B795CF457B8D340FF8F94FCEAB3DD69F9FF8F95FCEB8436B767AB3546D6B759FBCD43A68B58968EDDEE6C89C2DCA93F5A8898CF2B213F8D71D159DC9947CCD5BF069F74CAB826A1D25D0D638A65878DA4242B37E751CD179311E3935AB1C02DE0C30CB573FAD5FADAC4CD9CB761584958F4E8C9CF5473DAC4C6599618FE6DDC102B4EC20F22DD06DC122B374FB47BAB837127033915BA109E3D3A57B396E1DC23CF23E573EC72AB354A0F6DC7039FAD3C0A020007AD395457AECF9B0C5285A78514F0829011EC149E5D4E12A4118A065711D3843ED56562A9562A40564879E9532C356522152AC428B8D22A343C74AA93DBFCA4D6C34631556755031551644976389D5F6C12AB1A9EDF5B8A0B65C30E0562FC40BCFB1C4850E1B078AF31975DBA9136EF2056157131A6ECF73B2860A5555D6C77DE26F17A346D1A3F278E0D79A5D5CBDD4A598F5A8A499E56DCEC49A61EB5E6D7AEEA33D6C3E1A1450DA28A2B9CE9014B4945002D2AFD69B4E519140162D2E9ED67574278AF52F09F8C62212299B9E9CD792F43CD4B0CEF03EE4620D67529F3AD0EBC3E25D2767B1F55E93A8C7728AC8E08ADF8A28EE07079AF9AFC39E389EC1D52490EDAF5CD07C736B70AA1A5504FBD73FC3A347734AB2BD33D0058B272BCD58890A9C15AA763ACC13AA957439F46CE6B5A3B989C75C1AD636671D4738E924393D3153328F2CFD288C2139DD9A7B8F91B1CF15A24733773C77C5C3FE27B37D6ABE9A31F955CF15DB4ADADCAC17BD45A6DA4C573B2A8CFA9609F50298CB939C55A36B28EB19CD35A0980FB948A5723B741E602715D041B46DC74C573EBBD0F22AE8BB664D89907143DAC8B8AD6F27A15F5DD722B3054365FB015C82A4FA95D79D303E583C0AB7776C8F786490EF20F7AB092AED0146D03B57561B2F93F7EA6C7363B3A8C69FB1A1BF72786308A028C0153E09C5411C82A6120F4AF66D64923E65C9C9DDEE48AB9A9156A35907D2A55968B30B922AE6A40845315C7A548AF8A566171CA95204A62B935209117EF30A077448A98A95501AAFF6B813ACF18FAB81514DADE9F6CA4CB7917E0E0D27A6E3577B234D5314F038AE46EFE21E83660E6E1988EC1735CE6A1F176D9148B3B60C7B31245652AB05BB358D1A92D91E9F21555249000F535CCEBDE2AD3B49858BCCAD281C00735E45AA7C47D67502C8253121EC0D72571773DD485E699989F5AE79E2D47489D94B2F94B59B367C4FE23935CBC2DD2353C573D9CFE1413D85274AF3E72727767AB08282E542134678A4345494145145001451450014A0E2928A005CE68CD251400EDC2ACDB6A135AB831B11F4AA940A4D27B8D49C5DD33B3D2FC7D7D6247EF1971DD4F35DCE93F17A5450B29F34FAC86BC505381C566E8C7A1D51C64ED692B9F4AD97C5AB5700CA224FF74E6B5E2F8B3A29522495C71D857CAA2565E8C45385C4BDA46FCE854E4B66375E93DE07D0FAA78E348BCBB79525383EA29B69E3AD2A05C34A6BE7AFB44DFF003D1BF3A4F3E6FF009E87F3A7C93EE47B4A3FCAFEF3E88B8F895A44408F309FC2B26E3E29E8E3237CDF8257861766E59893481B1DAA945F5339CE3F651EC6FF0013B472739B8FFBF74C6F899A573B5EE071FDCAF1E2E4F1407AB49277326DB5A9D76A3E33BC9AE59EDA67084F19E2A28FC6DA946305B77D4D72FBA97756CAB4D6CCE7787A6F7475E9E3DD413AA29FC4D4EBF116FD7FE58467EAC6B89DD46EAAFACD5FE623EA743F94EE87C49BE1FF002EB17FDF46947C4BD43B5BC63FE046B850C28DC28FACD5FE60FA951FE53B96F895A8B7FCB141FF000235137C45D54FDD2147B31AE2B7D1BE8FACD5EE1F53A2BEC9D7B7C42D68FDD9D97E8D54A6F1A6B92939BF9467FDAAE737D1BAA5D7A8FED16B0F4D7D946ACBAF6A53E7CDBC95BEA6A8C9752B9CB393F5AAFBA937566E4DEECD1412D9129707EB4DCFBE2A3DD464D49A0E2F485F34DA2900B9A0114945000793451450014514500145145001451450014514500145145002E68CD251400B9A334945002E68CD251400A1B14BBA9B45002E79A4A28A005CD2668A2800CD19A28A00334668A280173466928A0028A28A003345145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145007FFD900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,2,'2011-04-06');
/*!40000 ALTER TABLE `motocicletasimagenes` ENABLE KEYS */;


--
-- Definition of table `movimientoscuentacorriente`
--

DROP TABLE IF EXISTS `movimientoscuentacorriente`;
CREATE TABLE `movimientoscuentacorriente` (
  `id` int(11) NOT NULL,
  `idcuentacorriente` int(11) NOT NULL,
  `idtipomovimiento` int(11) NOT NULL,
  `monto` decimal(18,2) NOT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  `fechavencimiento` date DEFAULT NULL,
  `fecha` date NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `tipomontocuenta_moviemientocuenta` (`idtipomovimiento`),
  KEY `cuentacorriente_movimientoscuentacorriente` (`idcuentacorriente`),
  CONSTRAINT `tipomontocuenta_moviemientocuenta` FOREIGN KEY (`idtipomovimiento`) REFERENCES `tipomontocuentacorriente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `cuentacorriente_movimientoscuentacorriente` FOREIGN KEY (`idcuentacorriente`) REFERENCES `cuentacorriente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `movimientoscuentacorriente`
--

/*!40000 ALTER TABLE `movimientoscuentacorriente` DISABLE KEYS */;
/*!40000 ALTER TABLE `movimientoscuentacorriente` ENABLE KEYS */;


--
-- Definition of table `municipios`
--

DROP TABLE IF EXISTS `municipios`;
CREATE TABLE `municipios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `idderivada` int(11) NOT NULL,
  `habilitado` int(1) unsigned NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Municipio_Departamentos1` (`idderivada`),
  CONSTRAINT `fk_Municipio_Departamentos1` FOREIGN KEY (`idderivada`) REFERENCES `departamentos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `municipios`
--

/*!40000 ALTER TABLE `municipios` DISABLE KEYS */;
/*!40000 ALTER TABLE `municipios` ENABLE KEYS */;


--
-- Definition of table `ordenescompras`
--

DROP TABLE IF EXISTS `ordenescompras`;
CREATE TABLE `ordenescompras` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(70) NOT NULL,
  `elaboradopor` int(11) NOT NULL,
  `idproveedor` int(11) NOT NULL,
  `fechaorden` date NOT NULL,
  `idsucursal` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Codigo_Unico` (`codigo`),
  KEY `Sucursal_Orden` (`idsucursal`),
  KEY `Proveedor_Orden` (`idproveedor`),
  KEY `Usuario_Orden` (`elaboradopor`),
  CONSTRAINT `Proveedor_Orden` FOREIGN KEY (`idproveedor`) REFERENCES `proveedores` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Sucursal_Orden` FOREIGN KEY (`idsucursal`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Usuario_Orden` FOREIGN KEY (`elaboradopor`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordenescompras`
--

/*!40000 ALTER TABLE `ordenescompras` DISABLE KEYS */;
INSERT INTO `ordenescompras` VALUES  (6,'OC-001-20110304-002-0000001',2,2,'2011-03-04',1,2,'2011-03-04 22:51:50'),
 (7,'OC-001-20110304-002-0000002',2,3,'2011-03-04',1,2,'2011-03-04 22:58:07'),
 (8,'OC-001-20110305-002-0000003',2,1,'2011-03-05',1,2,'2011-03-05 00:22:57'),
 (9,'OC-001-20110305-002-0000004',2,2,'2011-03-05',1,2,'2011-03-05 00:30:53'),
 (10,'OC-001-20110305-002-0000005',2,3,'2011-03-05',1,2,'2011-03-05 00:35:37'),
 (11,'OC-001-20110305-002-0000006',2,3,'2011-03-05',1,2,'2011-03-05 00:38:40'),
 (12,'OC-001-20110323-002-0000007',2,3,'2011-03-23',1,2,'2011-03-23 19:32:21'),
 (13,'OC-001-20110323-002-0000008',2,2,'2011-03-23',1,2,'2011-03-23 19:35:54'),
 (14,'OC-001-20110323-002-0000009',2,3,'2011-03-23',1,2,'2011-03-23 19:36:41'),
 (15,'OC-001-20110323-002-0000010',2,1,'2011-03-23',1,2,'2011-03-23 20:45:24'),
 (16,'OC-001-20110323-002-0000011',2,1,'2011-03-23',1,2,'2011-03-23 21:26:25'),
 (17,'OC-001-20110323-002-0000012',2,2,'2011-03-23',1,2,'2011-03-23 21:36:16'),
 (18,'OC-001-20110323-002-0000013',2,1,'2011-03-23',1,2,'2011-03-23 21:36:51'),
 (19,'OC-001-20110323-002-0000014',2,3,'2011-03-23',1,2,'2011-03-23 22:57:59');
/*!40000 ALTER TABLE `ordenescompras` ENABLE KEYS */;


--
-- Definition of table `ordenesrequisicion`
--

DROP TABLE IF EXISTS `ordenesrequisicion`;
CREATE TABLE `ordenesrequisicion` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(70) NOT NULL,
  `fechaemision` date NOT NULL,
  `enviadopor` int(11) NOT NULL,
  `recibidopor` int(11) DEFAULT NULL,
  `sucursalenvia` int(11) NOT NULL,
  `sucursalrecibe` int(11) DEFAULT NULL,
  `estado` varchar(3) NOT NULL COMMENT 'E enviado\nR recibida\n',
  `fmodif` datetime NOT NULL,
  `usu` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `codigo_unico` (`codigo`),
  KEY `recibido_usuario` (`recibidopor`),
  KEY `enviado_usuario` (`enviadopor`),
  KEY `sucursalenvia_usuario` (`sucursalenvia`),
  KEY `sucursalrecibe_usuario` (`sucursalrecibe`),
  CONSTRAINT `enviado_usuario` FOREIGN KEY (`enviadopor`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `recibido_usuario` FOREIGN KEY (`recibidopor`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `sucursalenvia_usuario` FOREIGN KEY (`sucursalenvia`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `sucursalrecibe_usuario` FOREIGN KEY (`sucursalrecibe`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordenesrequisicion`
--

/*!40000 ALTER TABLE `ordenesrequisicion` DISABLE KEYS */;
INSERT INTO `ordenesrequisicion` VALUES  (6,'OR-002-20110313-002-0000001','2011-03-13',2,3,2,1,'R','2011-03-14 23:50:41',2),
 (7,'OR-002-20110313-002-0000002','2011-03-13',2,NULL,2,1,'E','2011-03-13 18:34:46',2),
 (8,'OR-002-20110313-002-0000003','2011-03-13',2,NULL,2,1,'E','2011-03-13 18:43:47',2),
 (9,'OR-002-20110313-002-0000004','2011-03-13',2,NULL,2,1,'E','2011-03-13 18:52:06',2),
 (10,'OR-002-20110313-002-0000005','2011-03-13',2,NULL,2,1,'E','2011-03-13 18:54:12',2),
 (11,'OR-002-20110313-002-0000006','2011-03-13',2,NULL,2,2,'E','2011-03-13 19:00:58',2),
 (12,'OR-002-20110313-002-0000007','2011-03-13',2,NULL,2,1,'E','2011-03-13 19:02:40',2),
 (14,'OR-001-20110323-002-0000008','2011-03-23',2,NULL,1,2,'E','2011-03-23 19:24:03',2),
 (15,'OR-001-20110323-002-0000009','2011-03-23',2,NULL,1,1,'E','2011-03-23 19:39:20',2),
 (16,'OR-001-20110323-002-0000010','2011-03-23',2,NULL,1,2,'E','2011-03-23 20:15:01',2),
 (17,'OR-001-20110323-002-0000011','2011-03-23',2,NULL,1,1,'E','2011-03-23 21:06:12',2),
 (18,'OR-001-20110323-002-0000012','2011-03-23',2,NULL,1,1,'E','2011-03-23 21:37:29',2),
 (19,'OR-001-20110323-002-0000013','2011-03-23',2,NULL,1,1,'E','2011-03-23 21:37:53',2),
 (20,'OR-001-20110323-002-0000014','2011-03-23',2,NULL,1,2,'E','2011-03-23 21:38:50',2),
 (21,'OR-001-20110323-002-0000015','2011-03-23',2,NULL,1,1,'E','2011-03-23 21:59:00',2),
 (22,'OR-001-20110323-002-0000016','2011-03-23',2,NULL,1,2,'E','2011-03-23 22:21:04',2),
 (23,'OR-001-20110323-002-0000017','2011-03-23',2,NULL,1,2,'E','2011-03-23 22:23:40',2),
 (24,'OR-001-20110323-002-0000018','2011-03-23',2,NULL,1,2,'E','2011-03-23 22:24:39',2),
 (25,'OR-001-20110323-002-0000019','2011-03-23',2,NULL,1,1,'E','2011-03-23 22:42:34',2),
 (26,'OR-001-20110323-002-0000020','2011-03-23',2,NULL,1,2,'E','2011-03-23 22:56:06',2),
 (27,'OR-001-20110323-002-0000021','2011-03-23',2,NULL,1,2,'E','2011-03-23 23:18:49',2),
 (28,'OR-001-20110323-002-0000022','2011-03-23',2,NULL,1,2,'E','2011-03-23 23:20:26',2);
/*!40000 ALTER TABLE `ordenesrequisicion` ENABLE KEYS */;


--
-- Definition of table `ordenessalida`
--

DROP TABLE IF EXISTS `ordenessalida`;
CREATE TABLE `ordenessalida` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(70) NOT NULL,
  `enviadopor` int(11) NOT NULL,
  `recibidopor` int(11) DEFAULT NULL,
  `sucursalenvia` int(11) NOT NULL,
  `sucursalrecibe` int(11) NOT NULL,
  `estado` varchar(11) NOT NULL,
  `requisicion` int(11) DEFAULT NULL,
  `fmodif` datetime NOT NULL,
  `usu` int(11) NOT NULL,
  `fechaemision` date NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `salida_sucursalenvia` (`sucursalenvia`),
  KEY `salida_sucursalrecibe` (`sucursalrecibe`),
  KEY `salida_enviadopor` (`enviadopor`),
  KEY `salida_recibidopor` (`recibidopor`),
  KEY `salida_requisicion` (`requisicion`),
  CONSTRAINT `salida_enviadopor` FOREIGN KEY (`enviadopor`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `salida_recibidopor` FOREIGN KEY (`recibidopor`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `salida_requisicion` FOREIGN KEY (`requisicion`) REFERENCES `ordenesrequisicion` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `salida_sucursalenvia` FOREIGN KEY (`sucursalenvia`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `salida_sucursalrecibe` FOREIGN KEY (`sucursalrecibe`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordenessalida`
--

/*!40000 ALTER TABLE `ordenessalida` DISABLE KEYS */;
INSERT INTO `ordenessalida` VALUES  (2,'OS-001-20110325-002-0000001',2,2,1,2,'R',NULL,'2011-03-27 23:48:44',2,'2011-03-25'),
 (3,'OS-001-20110325-002-0000002',2,NULL,1,1,'E',NULL,'2011-03-25 21:48:20',2,'2011-03-25'),
 (4,'OS-001-20110325-002-0000003',2,NULL,1,2,'E',NULL,'2011-03-25 21:54:07',2,'2011-03-25'),
 (5,'OS-001-20110325-002-0000004',2,2,1,2,'R',NULL,'2011-03-27 23:47:32',2,'2011-03-25'),
 (6,'OS-001-20110325-002-0000005',2,NULL,1,1,'E',NULL,'2011-03-25 22:09:06',2,'2011-03-25'),
 (7,'OS-001-20110325-002-0000006',2,2,1,2,'R',NULL,'2011-03-27 23:32:19',2,'2011-03-25'),
 (8,'OS-001-20110325-002-0000007',2,NULL,1,1,'E',NULL,'2011-03-25 22:28:47',2,'2011-03-25'),
 (9,'OS-001-20110325-002-0000008',2,NULL,1,1,'E',NULL,'2011-03-25 22:33:04',2,'2011-03-25'),
 (10,'OS-001-20110327-002-0000009',2,NULL,1,2,'E',NULL,'2011-03-27 16:08:06',2,'2011-03-27'),
 (11,'OS-002-20110327-002-0000010',2,NULL,2,1,'E',NULL,'2011-03-27 23:38:56',2,'2011-03-27'),
 (12,'OS-002-20110402-002-0000011',2,2,2,1,'R',NULL,'2011-04-02 22:57:42',2,'2011-04-02'),
 (13,'OS-002-20110402-002-0000012',2,2,2,1,'R',NULL,'2011-04-02 22:53:11',2,'2011-04-02'),
 (14,'OS-002-20110402-002-0000013',2,2,2,1,'R',NULL,'2011-04-02 22:57:20',2,'2011-04-02'),
 (15,'OS-002-20110402-002-0000014',2,NULL,2,1,'E',NULL,'2011-04-02 22:49:35',2,'2011-04-02'),
 (16,'OS-002-20110402-002-0000015',2,NULL,2,1,'E',NULL,'2011-04-02 23:01:05',2,'2011-04-02'),
 (17,'OS-002-20110403-002-0000016',2,NULL,2,1,'E',NULL,'2011-04-03 12:05:17',2,'2011-04-03'),
 (18,'OS-002-20110403-002-0000017',2,2,2,2,'R',NULL,'2011-04-03 14:38:50',2,'2011-04-03'),
 (19,'OS-002-20110403-002-0000018',2,2,2,2,'R',NULL,'2011-04-03 12:23:44',2,'2011-04-03'),
 (20,'OS-002-20110403-002-0000019',3,3,2,1,'E',NULL,'2011-04-03 14:53:09',3,'2011-04-03'),
 (21,'OS-002-20110403-003-0000020',3,NULL,2,1,'E',NULL,'2011-04-03 14:54:54',3,'2011-04-03'),
 (22,'OS-002-20110403-002-0000021',2,NULL,2,1,'E',NULL,'2011-04-03 14:59:35',2,'2011-04-03'),
 (23,'OS-002-20110404-002-0000022',2,2,2,1,'R',NULL,'2011-04-04 22:21:19',2,'2011-04-04'),
 (24,'OS-001-20110404-002-0000023',2,NULL,1,1,'E',NULL,'2011-04-04 22:22:31',2,'2011-04-04'),
 (25,'OS-001-20110404-002-0000024',2,NULL,1,1,'P',NULL,'2011-04-04 22:24:37',2,'2011-04-04'),
 (26,'OS-001-20110404-002-0000025',2,NULL,1,1,'E',NULL,'2011-04-04 22:29:32',2,'2011-04-04'),
 (27,'OS-001-20110404-002-0000026',2,2,1,2,'R',NULL,'2011-04-04 22:46:27',2,'2011-04-04'),
 (28,'OS-001-20110404-002-0000027',2,NULL,1,2,'P',NULL,'2011-04-04 22:40:11',2,'2011-04-04'),
 (29,'OS-001-20110410-002-0000028',2,NULL,1,2,'E',NULL,'2011-04-10 20:53:51',2,'2011-04-10'),
 (30,'OS-002-20110523-002-0000029',2,NULL,2,1,'E',NULL,'2011-05-23 23:26:04',2,'2011-05-23');
/*!40000 ALTER TABLE `ordenessalida` ENABLE KEYS */;


--
-- Definition of table `productos`
--

DROP TABLE IF EXISTS `productos`;
CREATE TABLE `productos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(45) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  `preciocosto` decimal(15,2) DEFAULT NULL,
  `precioventa` decimal(15,2) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Codigo_unico` (`codigo`),
  UNIQUE KEY `Descripcion_Unica` (`descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `productos`
--

/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES  (1,'asdfadf','dfsadf','5.00','11.00',2,'2011-02-11 20:48:51'),
 (2,'XXX-XXX','Abrazadera','22.00','11454.00',2,'2011-02-20 22:23:10'),
 (3,'d','d',NULL,'145849111.11',2,'2011-02-11 21:17:42'),
 (5,'hhj-jjkk-klk-df','cluch','45.00','465.45',2,'2011-02-12 00:54:50'),
 (6,'FSADF','hule de hierro','43.00','123.00',2,'2011-02-26 11:54:54'),
 (7,'ATOG-022-1221','Amortiguador',NULL,'1545.40',2,'2011-02-21 18:17:31'),
 (8,'RITI-TIKUT-4454','Foco Delantero',NULL,'47455.45',2,'2011-02-21 18:32:52'),
 (9,'DKKPSD-454-24554','Hule de casilla','22.00','456.40',2,'2011-02-21 19:22:21'),
 (10,'4554456','MOTOR','32.00','2.00',2,'2011-02-26 19:22:40');
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
INSERT INTO `productosimagenes` VALUES  (2,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A4A09C726BC47C6DF1275A6F114B63E1DB90905BFCACEAA1B71EFD7D2A2738C15E45420E6ED13DBF38ACBD67C45A5E836AF3EA1771C4AA33B739623D877AF077F1DF8BF51B17D2AF2E76890E5E751B5F6FA0C567259E64325C4D2DC376F39CBE3E99AE3AB985286DAB3AE9606A4F7D0F55BFF008BB6314A834DD3EE2F6265C97CF9783E98350C7F1794CCAB2E893A464F2FE68381F4AF3A180300714135E7BCD2ADF448EE596D3B6AD9EF9A178974CF1142F269F3EF2870C8C30C3F0AB971AA595AC9E54D731ACB8C88F77CC7E82BE7CB0D62E3C3BA826A9671F992A02BE5E480F9F5C5747E09F13E7C46F26B76D6C24B9DF299DD8B18C0E428CF4FC2BD3C3E361562AFA33CFAF849D393B6A8F698E412C6AEB9C30C8C8C1A7572C3E22785F784FED35C9381F2375FCABA5B7B88AEA059A091648D864329C835D6A49ECCE5716B74494514531051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400550D46EAEE0091D95A79F33F4DC76A8FA9ABF58DE29D7E1F0DE8173A8CCD828B88F23AB1E82803CABE28788BC490DD59DAED934FCE72F6D3121B3EB5C3E8F6B25BC0ED36E32C8C5999BA93EB53ADD5EEB9A849AB6A32BBCB29E158F0A2AE1AF031D8AE76E11D8F730586E44A72DC28A4A0D79A7A026F5C9F9871D694B28EA4014EF0CF86A0F126A57F0C92CF16CE55A36E2AEEA5E0DB4B5BB5B57BDB9BB9BAF9108CB0FA9ED5D8B0B7B6A723C55AFA1969730B92038C838351BCD68F70A8EC8655FBB9EB5D84DA558C5A525B5EF87E78A14FF96A9F338F7E2974BD0BC1902B868AE6FC4AB82550BB467F0E86B58E0D5F76652C5B4B639665575C1008239AF4AF843A94F3E9F7FA6CADBA3B39008CE3B3735CEAFC378354BA61A3EBED0C44716F70BFBC5FA8F4AF47F04F8517C27A2FD91E449EE598B4B32AE37F3C66BBB05859D19B6DE871E2F130AD1492D4E9A8A28AF48F3C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B87F8AFA75C6A5E05BA8EDA232346CB2B01D957926BB8AF28F8D5ACEA1A7E9D65676B398A0B92DE6ED38240C719A89B4A2DB2A09B92B1E63A35DB5CD9AFC842AF00FAD69554D38C66CE3F2C8231CE3D6ADD7CAD569CDD91F4D4935057621200C9E82991C57BA8E22D3AD6599DF8076903F3A73B054249C002BD07E19DCCF73A1CBE68FDDA49888E31C56B87A6A776FA19626AB8249752AE81A3BF82FC37717974375EC9D141E727802BA5F0DE92D6767F6ABA01AFAE3E799CF5C9EC3DAAA6B84DE78934CB21CAC6DE6C8BEA3A574E06303B57A2F4479BBB119430208041EA0D73D2DB41E1ED405D41105B7B870B22A8E8C7BD7455475883CFD2AE100F9B612A40E87D6A53195759D212F61FB45B9315E45F3C72270723D7D6B73C35AC0D67488E660566426391588CEE1C13F8D6668B38B8D2603B8B15508C4F524706AAF864C761E2ED56D4E41BADB2C6A3A000735D7869B52E5673D78E9CC76D45145771CA1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C4FC47F0745E28D1C4BF68F26E2D159E366385F7CFE55DB551D66DBED9A2DE5B6C67F36164DA8704E476CD2924D598D369DD1F25E991DEDEEB634AD3D8BCDBF6B321CA8C77CFA5741AF5B6A3E179161B9BA864246727AD65787B41D48F8F7ECBA6CCF6AF13B0639059141E41ED9AF7ABDF09E95ADDB42BAB5AADD3460619B824FAF15E5D6852E649AD0F4294EA28B69EA7947863C31AB78B42DC4CDE4596793FDE1ED5ED5A56996DA45845676A81238C6062A7B5B586CADD20B78D6389061540E82A6ACF45A2564536DEECE60391F11595F1B0D88DB9F5DC6BA7AE3FC5C92E99A958EBD0A33A42DB2703FB9FFEB35B91EB96CF00999240A57702A85863EA2B47194926919F324ECCD4A64C4089C9E062B22DBC59A2DE4A6286F51A41D53F8BF2AA5E25F1469D63A64B1B5C059651B173C7278A8E496D62F9916BC28B2AE97279ADB89B890823D377151C25BFE167596CC6CFB1C9BF1EB918A9747D4F4F8747876CEAC1501765E4671CF34FF07C1FDA1ACEA1AD3440C2C4476B2E7AA8186FD6BA2845FB4B98D56940EDA8A4A5AF40E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800ACFD756E1B41BF5B40C6E0C0FE5853825B1C62B4291BEE9FA500786FC2AD264517BA95EA117924A6370DC9520E0F35EAC060015C8F82C6CB5BD46186FB74C71FF0002AEBABC8A9FC491E947E08851451500473C115CC0F0CC81E3718653DEB9C834DD67C36EE348912E6C0FFCBA4E7EEFD0D74F9A2B48549436265052DCE4E3BC0972F35B783523BD3D6578C0527D7239ACCBDD2B5097543A8EB165A55C6F188EDDDF013E9C735DFD715E3CB681EE349B8B98BCC8D2E15304F1962056EB13393B193A314AE5A1A5EA5A85A8B3FB2D8E9D60472B6DC971DC74E2BA5F095F5BB5B4DA64512C5259304745E983D0FE54F8A348A254450AAA3000ED58DA0DE4769E3BD46C84797BB4594BFA6D18AAA156539FBCC9AB4E318E877345145769CC145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001475A2A26BA812411BCD1AB9E8A5803F95007053C6344F195C5B98C456D7ABE64183C6E1F7BF9D7471BEF506B8FF00881A8C9AA6A6BA35AA79325A9595EEB1F329EA02FF005A9746F112EF8ECAEDB6DC80003D9FDEB8713879C7F7A968CEBA15E32FDDB7AA3ADA298922B8E0D3EB8D1D0CE5B59B6D7EDB515D4ACA51736F19C9B41C647B1F5A9F4DF196977CDE54F21B3B91F7A2B81B39F627AD7459AC19AC2DB5BBB9E0BFD2008D07CB3BA8CB7D0F5AB4D3DC977E86DA4A92286475653D0839AE5BE2002DA2DA04237FDBA1C7FDF55237816C11B75ADD5EC041CF13B11F966AC41E13805C472DD5D4F72233B95646E01F5A71B277B89DDAB1BB1822350C7270326B9DD12D9EEBE255E5E46A0C56D0F96EDBBA12011C55CD7B5FB7D1A158FF00D65DCC76430AFDE663D2B47C1BA1CDA569F25C5EA8FB7DDB79931073F41F80E2BA30B077E631AF256B1D28A28A2BB8E50A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AA7AA5F47A6E9B3DD4922279684A973804F61401CFEB3E2433DE49A4E9849947134C3A27B0F7ACA6D0ED6501A66965B80062776CB8FC6AA78695A6B79AFE54549AEA4323A8EC4D6ED75C6092B58E5949B77385B5B496DBC55756B7B7724EB26D31C921CB11E99ADEB8D0A286FA3D42D6353320C156FE21FE359BE27D35AF75BB01048619B0583AF5C8AE82EAF0699A6AC939DF22A81FEF35128A943925B0A3271973ADCCAD67C6FA7687A79B8BA1224DD04246189FF0ACAD0BE29AEA68F2358BB429DE33B9BF1146A51AEA963753EA5024B12C65802BC29AA5A7E996361221B1B6024907DC5E9F5AE386594D5EECEA9E613696875D67E3FD0AED0B79ED185FBC5D7183EF57078CFC3A47FC8560FCCD73A86E34AB8B7FECE8ED6396F1B6CD14F16E407FBD8F5AE86CBC4563688D06B3A727DA54FDEB7B4DC8C3D7A5632C0A4F7358E2F996C3478C74B99CC76265BD970484B74DC4D543A8F8AF59574D2746366071E6DE9D847B85EF5B5178C7C3F09578ACEE109E856CC83FCAA47F881A2C48CCEB78AA3A936CD4470915BEA37886F62BE81E0382CEE63D4F5799AFF541CF98FF00750FFB23B57655C64FE2BBCD413ED1A422C76A07DF9E3397FA0ED51D978BB5CF2C2DCE89E63027F789285047D0F35D0A9B4B4460E69BD59DBD15C35C7C40B8B797649A40001C1CDCA8207AE2B5B4BF1BE87AB5FF00D860BB0B738FB8E3193E80F7A1A6B71A927B1D1D140A290C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCE3C6B7F1EA7AC7F64CB024B0428240EB21E1F3D081C7E75D178CBC48340D3552289A5BBB92638514E307D49ED5E65A2593417CD1C92BCB34ADE6C8EE72493EF5BD085E577B18569D9591DD584220B38D40C71D2ACD22A8540A3A014B5BB31472FE244BD8758D3EFEDD4BC10AB798BEBD2A2D4EF575A92CA3870612DB9813821C76AEA656848D92153938C1EF55E3D26CA1B8F3D2050FEB8A04D32AEABA709BC3F7169120DCF1E31EA6A2D174F16366B7170A04BB7A1FE1ADBAE53C51AB4B1DEC3636F22AB05F35C67EF0E98A2FA832ADE5C49A86BF6B1C60811C9E61FA74AED40E07D2B82B0736CC6EA4917CD639EBF747A569FFC240ED8FDFC7C7A55B8DC952B1D5554BCB2176D1EF72A8A725477AC35D6E756FF005A87D891505A7881E7BC512B064DED900FA5271683991D25D5DC1A740A5C8519C2A8EF5902E4DB3CF7DA85CFC92711C2A7EE8FF1AC8D735386E358801622244270DEB52699A25E6BD7F05D4CAD0D8C0E1D14F5723BFD2B0AD5614A1CD27AF636A34E556568EC5B6D4D26024874669D0FF1941C8FC6B3AE9F41D62558AE206B0BD4E6391414287EBDEBD25224450A14003DAB2BC43A15B6B3A5CD0B46A26DA4C7201CA9F6AF3639849BF7A2AC77BC1C52F75BB8FF00097882EE4B86D2353659268D3743700E04ABEFEF5D9578259EA575E1F8F4CBCD5943C967704360F3D31CFE15EE3A7DFDB6A76515DDA4C92C322865743915D938A4EEB639E12BAD772D514515058514514005145140051451400514514005145140051451400514514005145140051451400552D5B54B7D1B4C9EFEE8E22857271576BCD7E20DEC97DABDA68EA7FD1D079D2953D4F4DA455462E4EC8994B955CE78DC4FAB6A771ACDD97065FF0055139CF949E956BC349F68BE9646E40738CF7150DD32C36721E985C0AD3F08C2E962AD281BF6F38F5AF41C541591C3CDCCEECE968A283D0D646860696B15EEB57B76C03152117DB1D6B7EB03C2D2ACB05D955DA45C383F9D6FD0B600CE2B1BC37A2697E25D47599754B08EE0C3702389DF3F776838FCEB608C823D6A3F053C1677BA8E9E5FFD21A4F34023EF2E3AD655AF634A56B9A8BE09F0E2A851A54200EDCD03C11E1B5C91A54033CF435D05707E3AF88116831B5869A567D4DC7AE562F7358462E4ECB7369CE308B94B6450F16FFC211E162A65D2A19EF987C902139C7BFA578F5BF88CDB789C4EC822B0776222539D99F7A8352BB9EE2E5E7BA9DA6BA94E64918F35CEDEBBEFF2D172CFC035DEE87B185DBD4F3A18975E768AD0F74D2F4AB2BF9E0D5AFB6919C4087BFBFBD7A0C4AAB1A85181E82B8282349F4EF0FD811B66F292518E3850335DF2FCA8A338AF99AB525526E7267D2429C69C14623A8A2A28EE619A49238E45678CE1C03D0D40CF22F8956B241AF411ABFF00A34DFBD2A47F1F4FE54EF87FE2B1E16D5BECB72656D3EE885001C8898F7C52FC4EBC12F89ECED147DC8B793F8D728EBBD48E9EFE95F5580A2AB60D296E7CA66188787C6F3476EA7D4CAC19430E846452D79AFC2AF153DFD9C9A2DF4A5AEAD7FD5B39FBC9DBEA6BD2AB825171938B3D784D4E2A51D985145152505145140051451400514514005145140051451400514514005145140051451400D77088CE7A2824D78DB4F0EA1ABDFEA7006F2EE652577F518E3FA5751F10B59BC8A4834AB192581E4432B4D19C7038DB5C7E968B158A46A724673EB9CD7561A3AF31CB889AF848F5BF9B4E68C121988031F5AEBF418F669E3E5E6B8CD51BFD32C232787948C7E15DDE96BB6C53DC5744FA98C0B9487EE9FA52D21E87E9591A1CA78119BEC77EAC4E45E4BD7FDEAEB2B90F0296586FD5FEF1BB908FA6EAEBE8E81D42B9FD1351B5D37C6FA9DCEA1702148E0C867E06DC8E6BA0240049E00AE335CD2A0D625BDBB405A2480A6EEC5B39E3D6A651E6D071972EA6C78CFE25D945A5FD9FC3F7915C5E4C76964E7CA1EB5E3EECC9E64F348D24CE773BB1C96354ECEE62DACE4FCD923F0A86E2E5A66C0FBBE95E961E8C292E65AB678D8AAF57113E47A244523991CB1E4935DAF843C0136A1730EA5A9218EDD08748C8E5CF63F4AE2E099ADE78E650098D8300464715D349F1AEF2DE2308D3E332AF0181E3F2AF37349D7E550A6B47BB3D5CAA14799CEA3D5743D3EDE2FB578CD36A8096316DC7FBC2A1F1A5F5DC1AB68905BCC63492E54C801C6E19E9591F0AF55BAF114BA96B377B0493155DA9C00071563C707FE2B3F0EA92705FD3BE6BE7E31E59DA5D0F7A72E68DD1E84A7E51F4AE6FC3DFF21ED77FEBE07FE822BA45FBA3E95CCE9F7705AEA1AE4C5447E5CB9663DCEDACD6C5DB53CD3C6F70B77E349C0E3C81B0FD6B229935DFF696B77B7C460CD21269F5F7181A7ECF0F189F079954F69899489AC3519F44D5AD756B6389206F9B8CE54F5FD2BE94D2B518756D2EDEFADCE6299038CF519F5AF998804107906BD2BE0F6B4626BBD0A79A30AA7CCB7527E66CF503E95CB9851DAA2F99DD94E237A32F91EB7451457947B8145145001451450014514500145145001451450014514500145145001451450078EEB1349278EB564989F91944433FC38E6A9CF6477F9B6F218A4CE481D1BEB52FC5CBF1A378A74DB8B60A279213BD71F7C67BD66E99E25B0D4309E608A6C64A3715E85069C35382B2B4C8E57B89B5AB6867887EEBE70E0F06BD22C3FE3C62FF0076BCFE7655D6ADDF20ABAED07DEBBBD2A4F32C94673B78A72D98A2F52E9A43D0D2D07A1ACCD0E0BC3FAA5BD85C5C896E235FF48937062010335D31F10DA4AE23B5592E2423E50AA707F1E95C940BA7196E2EAEE384289DC3BB28E80D6E5978C3C3E0AC16F22A20E010B8155CAECAC47324F534D60BED43FE3EF10407AC4A7E63EC4D66F8C7508B46F0D4E916D5765DA8B497FE3BD26D37A472F9928FE115E5DE20D5F53F125FEF68BCB814FC8AE7B55469C9BD88A95A115AB3097A7B9E694D5A5D2E6620BCDB07A28CD4ABA45BEE0CECECC3FDA22BBD4656D11E54AAD3BDDB33CC88B8CB28CF4E6AFF00867C2169E2CD64C535DC16B6F1E0CD2BB853F419AB0B636CBFF2C94E3FBC33522C10AE76C6A33E82A6AE1E552366C74B1B0A52BA4D9EA5E0F8347F0C5E5DE8B677D04AB1952195C12D9FE7557C5B72ADF10B4050C0A056078CE0E462BCDBC8457F3231E5C83A3AF0735D4FC3C7FEDAD767D1F506696E48FB45BDCB1CB4657F98AF0B1595CE937514AE99EFE0F36A75ED071B347B0493A476CD23300154935F3FEB1E2EB9D49EF2DADDC25BBCA77EDEAD8E39AF665F0DF88B51F32CB529EDA0B323FD740C4BB8F420F4AF23F889E1D4F0EF8B9D23F2D62BA512A220C600E39ACB2FC3AF68BDAA3A330AED527EC998B611958CB1EFD2AE53630046A17A638A757D6C5591F11397349B0A9F4BD424D1B5FB1D4E27D862902BB7FB04F3FA5414D9504913A1EE2A2AC39E0E25D0A8E954535D0FA8AD6E23BAB58AE226DD1C8A194FA83535735E03D43FB43C2364E5367949E575CE76F19AE96BE65AB3B1F649DD5C28A28A06145145001451450014514500145145001451450014514500145148481D4E2803C1FE38807C55A57FD7B3FF00E855E6654370457B27C6BD0669D6CF5D88964B75313A81D01E771AF1C041191D2BD5C1B4E9D8F231C9AA973A1F0CB4B7BA8F9534D232C6B94F9BEE9F6AF4AD0935285DC2BACD1F6078C5793689A926977E27913721E188ED5EB1E1EF13E95340545DC6A49E031C1A2AA516C7464E491D1192EC463102B3F71BF155DDF5297E510C70AE396DDBAAC2EA166C8185CC5B4F7DC2A8DFF89F48B1898CB7B1120642AB024D73D8E9BA3C564B9BABBD4AF20B99CBC51DC3E13A77AB06342BB4A8DBE955576CFAA5D5C459113CACE3F13572BD6C3C1469A563C0C65472AADA622A2AF4502968A2B738EED8514514005145140052E8BE229FC31E2A8B50B6852670855D09C1D87AD31DC229663C0ACC823F3F51F3CE78523DAB0C441548F2773AF09374A7ED3B1F56697AB5AEABA6C17B04D1B472A83F2B6707B8AF0CF8D1731CFE32B35B76F39A3B62AE23F98A9CF435C7586B72D8DBCD6E67995013B5558815AB6F33DAD9342007B8BAFBD2B72C057C954C77D5EA3496A8FB4A783FAC534DBD1A3160BE283CB6462C3B01CD4A355B60C15D8A31EC456FC11C56ECA7CA46C750475AD132E91791986F34B89171C342307F1CD5C3896A5ECE28C2A70BD2B5D49DCE623B88A5FB8E0D52D4E790279511DA4F53ED57B5BF0DC760E2E74E9F746DF36D07A7B573725CB3BF97FC5DC9AF5A967146B5377D19E454C92AD0AAADAA3E83F05EBB25F7852C60D2A28AC113F7724F28C82E38E07726BB0D22EB5096E2E9AFF625B02160DCBB58E07CC48FAD7CCFA0EB375A5AAC7A6DD4B04C5B8DA723EB835D14FAB5FDD1866D77529EED633F737633EDC57893C7538BD533E869E0E725A347D1AB246E70AEAC7D8E69F5F35C7AD5F595EB5E686B716A1BA0F33208F420D7A0D87C57B916D0A5CE8934B380048F138C7D71554F194A7A37614F09563ADAE7A9D15CD695E3BD0356B936D15DF9538EA93294C9F419EB5D20208C8E95D29A7B1CED35B8B45145310514514005145140051451400514514014356D5EDB48B5334E496FE08D7EF39F402BCDFC616DADF8CE188D91934B54FBAE66657C7704038A9F53D41D7C7FA925D2B492431A0B2881CE411C9FCEB4934DD4B524CDE4DF6588FF00CB284FCDFF007D57157AF352E589D54A941C79A479A4FF000F35078A48751F175D344C30D1F9C5B3F514CB2F8553498167AA9962071F3AE0D7ADC5A269966A1DA04675EB2C9CB1FA9ACAD47C73A1E9738B58E4F3EE338F2605DCDF95670C5568BF765A953C3D192F7A3A1C9C1F083254CDA8B0F50AA2BB0D33C11A3E9B69E42DAC6E49CB3B2E589FAD6B6957D3EA16DE7CB6AF6E1BEEABF0D8F71579982F52054D5C455A9A4E4D8E950A54DDE1148E66F7C11A6DCDACB1C4AD1BB03B4863C1AF29D5FE1DEB9A73BC820FB5469C89139E2BDD25BFB58595649954B1C004D58E187A835787C5D4A0EF1D7D48C46169D65692B1F355BCE90298A4051D4F3915605CC27F8C5755F123C13A836B305EE9063097722C4C8C30158F435413E0CF8D5A162F358ABE3801FF00FAD5F4B4734A7282763E6AB64F3537666135E42A3EFE690DF440679AD66F833E3B0A4EEB1381DA5E7F953348F09EA1022A6A1E0CD4E6962243C82E08573EC3154F318F444C7287D5994DA8DBAF56C7D6A23AC5A83F7BF5AF6DF0E695E1EBEB7B7B3BAF064F6F285C33DCDB6403EEDDEBC9BE20F81E4F0F78AAEAE859EDD36E0EE88A2FC89ED531CC252972A562E5954211E66DB3306A909E81A91F513FC29F9D662AA0C61FF5A9323D6BB23524D6A70CA8534F444E5E5B970A4F5AB05574FB37676CB1ACD6BE8ACDB7B48A081D33D6AA497B36A52893715841E3DEB0C462A9D183937A9D1430752BCD452B44B7A747F68BF84139F9B711ED5D3C5FBCD41D9461635D95CD698ED16AF091C2B0C135D0DADC22DFDCC24E18B6457C362DB949BF23EEF08A318A5E66851475A2BCD3D10201041E86B86BD022D45C71B771ED5D8DE5EC5670B3BB738E147535C44CCD7172D27392C4907DFB57A1818BD5BD8F3F1B25A25B92C727D9D84F19C30E4115D068F0C9763EDB74DBD89F907615CE32EE755046D5E4815D1695AA42B10865C211D0F6ADB12A5C9EEAD4CB0CE3CFEF3D0DCA724AF136E462A7D41A89658DFEEBA9FC694BA81CB0FCEBCAB347A974CD16BBB7BF8F65FC0A5C0C24E830E87D735DD7C32F125DDCDC5CE857B319CDB2078A663CB2F4C7BD7964FA85BDBAE5E404FA0EB5D3FC28B69358F16CDA8AB3C705AA71C70E7D2BD5CBE7579ECF63CCC7C69725D6E7BB514515ED9E385145140051451400514514001A439C714B450079BE997D6D3F8AB57B8BE291DE24822D8FC1551D08FAD5BD4FC5DA7D8B08A293ED172C7090C3F3313F415D3EA9E19D1F5970F7F6114B274DFCAB7E639AC6D6B40D3741F0BEA32E93670DACDE51FDE819651DF93CD724F0F797337A1D31AD68F2A5A9E6FA9FFC25BE31BEFB0DADD436769B8ACDE4B6E283D0B74CFB0AECBC33E05D27C371878E2F3AE88F9E7979635A9A15B59D8E8D6EB6A1046503161DC9EA6A96A1AA6A1A84AD61A05BF9F3F469C9C4717B93FD2B99C9C9F2411B28DBDE9B24D77C5165A205472D24EFC24318DCCC7E82B91F174FE2A8BC343589275D2A0691544457320DC70093DABD1BC3BE13B7D181B9B97FB66A327325CC8BCE7D147615B1A8E9B67AB58CB657F6E93DB4A30F1B8C835D54F0D18ABCB5673CEBC9BB4744713E16D261B7D3639E49CDDDC4AA19E6739DDF4AE8B200F415159F836CF4F4F2ACEEEF21800C2C4240557E9919A5B8F0A7DA3E53ABDFA26304295E7F1C560F0B52E6DEDE1639CD7B545BBD5B4ED1EC0F9D7725C2BBECE7CB407927D2BD1146001ED593A3786B4BD0831B2B7C4AFF007E673B9DBEA4D6BD7652A7C91B1CB527CEEE1498A5A2B5204A8E7B582EA231CF12488460875CD4B4500728FF000DBC22F2191B44B72C4E49E7AFE74AFF000E3C2522956D16DF07EBFE35D55029F33EE2E55D8F16F117ECFF00617D3F9DA3DFB5A966259251B947B0AE566F83BE2AB47F2A0B7867897FE5A0902E7F0AFA4E8A89C14F72E3271D8F91EF7C2BAF5A4DB5F4BBCCA3725222471EF5952B4A97064937AC8386CF18AFB30A823900D507D0F499092FA6DA3127249854E7F4AC1E1D773555D9F25A6B570808FB467EB515C7882552775C373CE057D6DFF08EE8BFF40AB2FF00BF0BFE1597A8FC3EF0BEA9389AE74980B818F906D1FA54AC1534EE57D6AA5AD73E5FD067B1D6B5A86DB50BD6B485D86E918647FF005ABE8193E17F84B55F0F797A5A4425DA025E44DB8961EB5B963F0EBC2BA7DD2DC41A4C2245E9B86E1F91AE96DEDA0B588456F124518E8A8B815BC69C62AC918B9C9BBB67CB9ADFC3CF126853B1934F926476C2BC037EE03BE074ACA9341D66389A57D2AF111796668480057D7B8CD3248A395192445646182A4641A87878BD8B559A3E37732C2B972EA3DF8ABB0E91ADDCDBA4F0E9D792C2E3E5748D981FCABEAE7D0F4A7186D36D587A1857FC2ADC30436F12C50C491C6BD1557007E152B0D1EAC7EDD9F21C9A36BC13FE409A83B7FD706AF62F82B797565653E937DA3DE5A485CC825962214FB74AF5EC0F414B81E95AC29463B19CAA4A5B8514515A1014514500145145001451450014514500151CF047730BC3322BC6E0AB2B0C823D2A4A28039DFF0084274811F9682E638F39D893B003DBAF4ADAB2B0B6D3AD96DED2158A25ECA3F535628A9518AD90DC9BDD8514515420A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A3145140051451400628A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00FFD90000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,2,'2011-02-20'),
 (5,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A4A09C726BC47C6DF1275A6F114B63E1DB90905BFCACEAA1B71EFD7D2A2738C15E45420E6ED13DBF38ACBD67C45A5E836AF3EA1771C4AA33B739623D877AF077F1DF8BF51B17D2AF2E76890E5E751B5F6FA0C567259E64325C4D2DC376F39CBE3E99AE3AB985286DAB3AE9606A4F7D0F55BFF008BB6314A834DD3EE2F6265C97CF9783E98350C7F1794CCAB2E893A464F2FE68381F4AF3A180300714135E7BCD2ADF448EE596D3B6AD9EF9A178974CF1142F269F3EF2870C8C30C3F0AB971AA595AC9E54D731ACB8C88F77CC7E82BE7CB0D62E3C3BA826A9671F992A02BE5E480F9F5C5747E09F13E7C46F26B76D6C24B9DF299DD8B18C0E428CF4FC2BD3C3E361562AFA33CFAF849D393B6A8F698E412C6AEB9C30C8C8C1A7572C3E22785F784FED35C9381F2375FCABA5B7B88AEA059A091648D864329C835D6A49ECCE5716B74494514531051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400550D46EAEE0091D95A79F33F4DC76A8FA9ABF58DE29D7E1F0DE8173A8CCD828B88F23AB1E82803CABE28788BC490DD59DAED934FCE72F6D3121B3EB5C3E8F6B25BC0ED36E32C8C5999BA93EB53ADD5EEB9A849AB6A32BBCB29E158F0A2AE1AF031D8AE76E11D8F730586E44A72DC28A4A0D79A7A026F5C9F9871D694B28EA4014EF0CF86A0F126A57F0C92CF16CE55A36E2AEEA5E0DB4B5BB5B57BDB9BB9BAF9108CB0FA9ED5D8B0B7B6A723C55AFA1969730B92038C838351BCD68F70A8EC8655FBB9EB5D84DA558C5A525B5EF87E78A14FF96A9F338F7E2974BD0BC1902B868AE6FC4AB82550BB467F0E86B58E0D5F76652C5B4B639665575C1008239AF4AF843A94F3E9F7FA6CADBA3B39008CE3B3735CEAFC378354BA61A3EBED0C44716F70BFBC5FA8F4AF47F04F8517C27A2FD91E449EE598B4B32AE37F3C66BBB05859D19B6DE871E2F130AD1492D4E9A8A28AF48F3C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B87F8AFA75C6A5E05BA8EDA232346CB2B01D957926BB8AF28F8D5ACEA1A7E9D65676B398A0B92DE6ED38240C719A89B4A2DB2A09B92B1E63A35DB5CD9AFC842AF00FAD69554D38C66CE3F2C8231CE3D6ADD7CAD569CDD91F4D4935057621200C9E82991C57BA8E22D3AD6599DF8076903F3A73B054249C002BD07E19DCCF73A1CBE68FDDA49888E31C56B87A6A776FA19626AB8249752AE81A3BF82FC37717974375EC9D141E727802BA5F0DE92D6767F6ABA01AFAE3E799CF5C9EC3DAAA6B84DE78934CB21CAC6DE6C8BEA3A574E06303B57A2F4479BBB119430208041EA0D73D2DB41E1ED405D41105B7B870B22A8E8C7BD7455475883CFD2AE100F9B612A40E87D6A53195759D212F61FB45B9315E45F3C72270723D7D6B73C35AC0D67488E660566426391588CEE1C13F8D6668B38B8D2603B8B15508C4F524706AAF864C761E2ED56D4E41BADB2C6A3A000735D7869B52E5673D78E9CC76D45145771CA1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C4FC47F0745E28D1C4BF68F26E2D159E366385F7CFE55DB551D66DBED9A2DE5B6C67F36164DA8704E476CD2924D598D369DD1F25E991DEDEEB634AD3D8BCDBF6B321CA8C77CFA5741AF5B6A3E179161B9BA864246727AD65787B41D48F8F7ECBA6CCF6AF13B0639059141E41ED9AF7ABDF09E95ADDB42BAB5AADD3460619B824FAF15E5D6852E649AD0F4294EA28B69EA7947863C31AB78B42DC4CDE4596793FDE1ED5ED5A56996DA45845676A81238C6062A7B5B586CADD20B78D6389061540E82A6ACF45A2564536DEECE60391F11595F1B0D88DB9F5DC6BA7AE3FC5C92E99A958EBD0A33A42DB2703FB9FFEB35B91EB96CF00999240A57702A85863EA2B47194926919F324ECCD4A64C4089C9E062B22DBC59A2DE4A6286F51A41D53F8BF2AA5E25F1469D63A64B1B5C059651B173C7278A8E496D62F9916BC28B2AE97279ADB89B890823D377151C25BFE167596CC6CFB1C9BF1EB918A9747D4F4F8747876CEAC1501765E4671CF34FF07C1FDA1ACEA1AD3440C2C4476B2E7AA8186FD6BA2845FB4B98D56940EDA8A4A5AF40E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800ACFD756E1B41BF5B40C6E0C0FE5853825B1C62B4291BEE9FA500786FC2AD264517BA95EA117924A6370DC9520E0F35EAC060015C8F82C6CB5BD46186FB74C71FF0002AEBABC8A9FC491E947E08851451500473C115CC0F0CC81E3718653DEB9C834DD67C36EE348912E6C0FFCBA4E7EEFD0D74F9A2B48549436265052DCE4E3BC0972F35B783523BD3D6578C0527D7239ACCBDD2B5097543A8EB165A55C6F188EDDDF013E9C735DFD715E3CB681EE349B8B98BCC8D2E15304F1962056EB13393B193A314AE5A1A5EA5A85A8B3FB2D8E9D60472B6DC971DC74E2BA5F095F5BB5B4DA64512C5259304745E983D0FE54F8A348A254450AAA3000ED58DA0DE4769E3BD46C84797BB4594BFA6D18AAA156539FBCC9AB4E318E877345145769CC145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001475A2A26BA812411BCD1AB9E8A5803F95007053C6344F195C5B98C456D7ABE64183C6E1F7BF9D7471BEF506B8FF00881A8C9AA6A6BA35AA79325A9595EEB1F329EA02FF005A9746F112EF8ECAEDB6DC80003D9FDEB8713879C7F7A968CEBA15E32FDDB7AA3ADA298922B8E0D3EB8D1D0CE5B59B6D7EDB515D4ACA51736F19C9B41C647B1F5A9F4DF196977CDE54F21B3B91F7A2B81B39F627AD7459AC19AC2DB5BBB9E0BFD2008D07CB3BA8CB7D0F5AB4D3DC977E86DA4A92286475653D0839AE5BE2002DA2DA04237FDBA1C7FDF55237816C11B75ADD5EC041CF13B11F966AC41E13805C472DD5D4F72233B95646E01F5A71B277B89DDAB1BB1822350C7270326B9DD12D9EEBE255E5E46A0C56D0F96EDBBA12011C55CD7B5FB7D1A158FF00D65DCC76430AFDE663D2B47C1BA1CDA569F25C5EA8FB7DDB79931073F41F80E2BA30B077E631AF256B1D28A28A2BB8E50A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AA7AA5F47A6E9B3DD4922279684A973804F61401CFEB3E2433DE49A4E9849947134C3A27B0F7ACA6D0ED6501A66965B80062776CB8FC6AA78695A6B79AFE54549AEA4323A8EC4D6ED75C6092B58E5949B77385B5B496DBC55756B7B7724EB26D31C921CB11E99ADEB8D0A286FA3D42D6353320C156FE21FE359BE27D35AF75BB01048619B0583AF5C8AE82EAF0699A6AC939DF22A81FEF35128A943925B0A3271973ADCCAD67C6FA7687A79B8BA1224DD04246189FF0ACAD0BE29AEA68F2358BB429DE33B9BF1146A51AEA963753EA5024B12C65802BC29AA5A7E996361221B1B6024907DC5E9F5AE386594D5EECEA9E613696875D67E3FD0AED0B79ED185FBC5D7183EF57078CFC3A47FC8560FCCD73A86E34AB8B7FECE8ED6396F1B6CD14F16E407FBD8F5AE86CBC4563688D06B3A727DA54FDEB7B4DC8C3D7A5632C0A4F7358E2F996C3478C74B99CC76265BD970484B74DC4D543A8F8AF59574D2746366071E6DE9D847B85EF5B5178C7C3F09578ACEE109E856CC83FCAA47F881A2C48CCEB78AA3A936CD4470915BEA37886F62BE81E0382CEE63D4F5799AFF541CF98FF00750FFB23B57655C64FE2BBCD413ED1A422C76A07DF9E3397FA0ED51D978BB5CF2C2DCE89E63027F789285047D0F35D0A9B4B4460E69BD59DBD15C35C7C40B8B797649A40001C1CDCA8207AE2B5B4BF1BE87AB5FF00D860BB0B738FB8E3193E80F7A1A6B71A927B1D1D140A290C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCE3C6B7F1EA7AC7F64CB024B0428240EB21E1F3D081C7E75D178CBC48340D3552289A5BBB92638514E307D49ED5E65A2593417CD1C92BCB34ADE6C8EE72493EF5BD085E577B18569D9591DD584220B38D40C71D2ACD22A8540A3A014B5BB31472FE244BD8758D3EFEDD4BC10AB798BEBD2A2D4EF575A92CA3870612DB9813821C76AEA656848D92153938C1EF55E3D26CA1B8F3D2050FEB8A04D32AEABA709BC3F7169120DCF1E31EA6A2D174F16366B7170A04BB7A1FE1ADBAE53C51AB4B1DEC3636F22AB05F35C67EF0E98A2FA832ADE5C49A86BF6B1C60811C9E61FA74AED40E07D2B82B0736CC6EA4917CD639EBF747A569FFC240ED8FDFC7C7A55B8DC952B1D5554BCB2176D1EF72A8A725477AC35D6E756FF005A87D891505A7881E7BC512B064DED900FA5271683991D25D5DC1A740A5C8519C2A8EF5902E4DB3CF7DA85CFC92711C2A7EE8FF1AC8D735386E358801622244270DEB52699A25E6BD7F05D4CAD0D8C0E1D14F5723BFD2B0AD5614A1CD27AF636A34E556568EC5B6D4D26024874669D0FF1941C8FC6B3AE9F41D62558AE206B0BD4E6391414287EBDEBD25224450A14003DAB2BC43A15B6B3A5CD0B46A26DA4C7201CA9F6AF3639849BF7A2AC77BC1C52F75BB8FF00097882EE4B86D2353659268D3743700E04ABEFEF5D9578259EA575E1F8F4CBCD5943C967704360F3D31CFE15EE3A7DFDB6A76515DDA4C92C322865743915D938A4EEB639E12BAD772D514515058514514005145140051451400514514005145140051451400514514005145140051451400552D5B54B7D1B4C9EFEE8E22857271576BCD7E20DEC97DABDA68EA7FD1D079D2953D4F4DA455462E4EC8994B955CE78DC4FAB6A771ACDD97065FF0055139CF949E956BC349F68BE9646E40738CF7150DD32C36721E985C0AD3F08C2E962AD281BF6F38F5AF41C541591C3CDCCEECE968A283D0D646860696B15EEB57B76C03152117DB1D6B7EB03C2D2ACB05D955DA45C383F9D6FD0B600CE2B1BC37A2697E25D47599754B08EE0C3702389DF3F776838FCEB608C823D6A3F053C1677BA8E9E5FFD21A4F34023EF2E3AD655AF634A56B9A8BE09F0E2A851A54200EDCD03C11E1B5C91A54033CF435D05707E3AF88116831B5869A567D4DC7AE562F7358462E4ECB7369CE308B94B6450F16FFC211E162A65D2A19EF987C902139C7BFA578F5BF88CDB789C4EC822B0776222539D99F7A8352BB9EE2E5E7BA9DA6BA94E64918F35CEDEBBEFF2D172CFC035DEE87B185DBD4F3A18975E768AD0F74D2F4AB2BF9E0D5AFB6919C4087BFBFBD7A0C4AAB1A85181E82B8282349F4EF0FD811B66F292518E3850335DF2FCA8A338AF99AB525526E7267D2429C69C14623A8A2A28EE619A49238E45678CE1C03D0D40CF22F8956B241AF411ABFF00A34DFBD2A47F1F4FE54EF87FE2B1E16D5BECB72656D3EE885001C8898F7C52FC4EBC12F89ECED147DC8B793F8D728EBBD48E9EFE95F5580A2AB60D296E7CA66188787C6F3476EA7D4CAC19430E846452D79AFC2AF153DFD9C9A2DF4A5AEAD7FD5B39FBC9DBEA6BD2AB825171938B3D784D4E2A51D985145152505145140051451400514514005145140051451400514514005145140051451400D77088CE7A2824D78DB4F0EA1ABDFEA7006F2EE652577F518E3FA5751F10B59BC8A4834AB192581E4432B4D19C7038DB5C7E968B158A46A724673EB9CD7561A3AF31CB889AF848F5BF9B4E68C121988031F5AEBF418F669E3E5E6B8CD51BFD32C232787948C7E15DDE96BB6C53DC5744FA98C0B9487EE9FA52D21E87E9591A1CA78119BEC77EAC4E45E4BD7FDEAEB2B90F0296586FD5FEF1BB908FA6EAEBE8E81D42B9FD1351B5D37C6FA9DCEA1702148E0C867E06DC8E6BA0240049E00AE335CD2A0D625BDBB405A2480A6EEC5B39E3D6A651E6D071972EA6C78CFE25D945A5FD9FC3F7915C5E4C76964E7CA1EB5E3EECC9E64F348D24CE773BB1C96354ECEE62DACE4FCD923F0A86E2E5A66C0FBBE95E961E8C292E65AB678D8AAF57113E47A244523991CB1E4935DAF843C0136A1730EA5A9218EDD08748C8E5CF63F4AE2E099ADE78E650098D8300464715D349F1AEF2DE2308D3E332AF0181E3F2AF37349D7E550A6B47BB3D5CAA14799CEA3D5743D3EDE2FB578CD36A8096316DC7FBC2A1F1A5F5DC1AB68905BCC63492E54C801C6E19E9591F0AF55BAF114BA96B377B0493155DA9C00071563C707FE2B3F0EA92705FD3BE6BE7E31E59DA5D0F7A72E68DD1E84A7E51F4AE6FC3DFF21ED77FEBE07FE822BA45FBA3E95CCE9F7705AEA1AE4C5447E5CB9663DCEDACD6C5DB53CD3C6F70B77E349C0E3C81B0FD6B229935DFF696B77B7C460CD21269F5F7181A7ECF0F189F079954F69899489AC3519F44D5AD756B6389206F9B8CE54F5FD2BE94D2B518756D2EDEFADCE6299038CF519F5AF998804107906BD2BE0F6B4626BBD0A79A30AA7CCB7527E66CF503E95CB9851DAA2F99DD94E237A32F91EB7451457947B8145145001451450014514500145145001451450014514500145145001451450078EEB1349278EB564989F91944433FC38E6A9CF6477F9B6F218A4CE481D1BEB52FC5CBF1A378A74DB8B60A279213BD71F7C67BD66E99E25B0D4309E608A6C64A3715E85069C35382B2B4C8E57B89B5AB6867887EEBE70E0F06BD22C3FE3C62FF0076BCFE7655D6ADDF20ABAED07DEBBBD2A4F32C94673B78A72D98A2F52E9A43D0D2D07A1ACCD0E0BC3FAA5BD85C5C896E235FF48937062010335D31F10DA4AE23B5592E2423E50AA707F1E95C940BA7196E2EAEE384289DC3BB28E80D6E5978C3C3E0AC16F22A20E010B8155CAECAC47324F534D60BED43FE3EF10407AC4A7E63EC4D66F8C7508B46F0D4E916D5765DA8B497FE3BD26D37A472F9928FE115E5DE20D5F53F125FEF68BCB814FC8AE7B55469C9BD88A95A115AB3097A7B9E694D5A5D2E6620BCDB07A28CD4ABA45BEE0CECECC3FDA22BBD4656D11E54AAD3BDDB33CC88B8CB28CF4E6AFF00867C2169E2CD64C535DC16B6F1E0CD2BB853F419AB0B636CBFF2C94E3FBC33522C10AE76C6A33E82A6AE1E552366C74B1B0A52BA4D9EA5E0F8347F0C5E5DE8B677D04AB1952195C12D9FE7557C5B72ADF10B4050C0A056078CE0E462BCDBC8457F3231E5C83A3AF0735D4FC3C7FEDAD767D1F506696E48FB45BDCB1CB4657F98AF0B1595CE937514AE99EFE0F36A75ED071B347B0493A476CD23300154935F3FEB1E2EB9D49EF2DADDC25BBCA77EDEAD8E39AF665F0DF88B51F32CB529EDA0B323FD740C4BB8F420F4AF23F889E1D4F0EF8B9D23F2D62BA512A220C600E39ACB2FC3AF68BDAA3A330AED527EC998B611958CB1EFD2AE53630046A17A638A757D6C5591F11397349B0A9F4BD424D1B5FB1D4E27D862902BB7FB04F3FA5414D9504913A1EE2A2AC39E0E25D0A8E954535D0FA8AD6E23BAB58AE226DD1C8A194FA83535735E03D43FB43C2364E5367949E575CE76F19AE96BE65AB3B1F649DD5C28A28A06145145001451450014514500145145001451450014514500145148481D4E2803C1FE38807C55A57FD7B3FF00E855E6654370457B27C6BD0669D6CF5D88964B75313A81D01E771AF1C041191D2BD5C1B4E9D8F231C9AA973A1F0CB4B7BA8F9534D232C6B94F9BEE9F6AF4AD0935285DC2BACD1F6078C5793689A926977E27913721E188ED5EB1E1EF13E95340545DC6A49E031C1A2AA516C7464E491D1192EC463102B3F71BF155DDF5297E510C70AE396DDBAAC2EA166C8185CC5B4F7DC2A8DFF89F48B1898CB7B1120642AB024D73D8E9BA3C564B9BABBD4AF20B99CBC51DC3E13A77AB06342BB4A8DBE955576CFAA5D5C459113CACE3F13572BD6C3C1469A563C0C65472AADA622A2AF4502968A2B738EED8514514005145140052E8BE229FC31E2A8B50B6852670855D09C1D87AD31DC229663C0ACC823F3F51F3CE78523DAB0C441548F2773AF09374A7ED3B1F56697AB5AEABA6C17B04D1B472A83F2B6707B8AF0CF8D1731CFE32B35B76F39A3B62AE23F98A9CF435C7586B72D8DBCD6E67995013B5558815AB6F33DAD9342007B8BAFBD2B72C057C954C77D5EA3496A8FB4A783FAC534DBD1A3160BE283CB6462C3B01CD4A355B60C15D8A31EC456FC11C56ECA7CA46C750475AD132E91791986F34B89171C342307F1CD5C3896A5ECE28C2A70BD2B5D49DCE623B88A5FB8E0D52D4E790279511DA4F53ED57B5BF0DC760E2E74E9F746DF36D07A7B573725CB3BF97FC5DC9AF5A967146B5377D19E454C92AD0AAADAA3E83F05EBB25F7852C60D2A28AC113F7724F28C82E38E07726BB0D22EB5096E2E9AFF625B02160DCBB58E07CC48FAD7CCFA0EB375A5AAC7A6DD4B04C5B8DA723EB835D14FAB5FDD1866D77529EED633F737633EDC57893C7538BD533E869E0E725A347D1AB246E70AEAC7D8E69F5F35C7AD5F595EB5E686B716A1BA0F33208F420D7A0D87C57B916D0A5CE8934B380048F138C7D71554F194A7A37614F09563ADAE7A9D15CD695E3BD0356B936D15DF9538EA93294C9F419EB5D20208C8E95D29A7B1CED35B8B45145310514514005145140051451400514514014356D5EDB48B5334E496FE08D7EF39F402BCDFC616DADF8CE188D91934B54FBAE66657C7704038A9F53D41D7C7FA925D2B492431A0B2881CE411C9FCEB4934DD4B524CDE4DF6588FF00CB284FCDFF007D57157AF352E589D54A941C79A479A4FF000F35078A48751F175D344C30D1F9C5B3F514CB2F8553498167AA9962071F3AE0D7ADC5A269966A1DA04675EB2C9CB1FA9ACAD47C73A1E9738B58E4F3EE338F2605DCDF95670C5568BF765A953C3D192F7A3A1C9C1F083254CDA8B0F50AA2BB0D33C11A3E9B69E42DAC6E49CB3B2E589FAD6B6957D3EA16DE7CB6AF6E1BEEABF0D8F71579982F52054D5C455A9A4E4D8E950A54DDE1148E66F7C11A6DCDACB1C4AD1BB03B4863C1AF29D5FE1DEB9A73BC820FB5469C89139E2BDD25BFB58595649954B1C004D58E187A835787C5D4A0EF1D7D48C46169D65692B1F355BCE90298A4051D4F3915605CC27F8C5755F123C13A836B305EE9063097722C4C8C30158F435413E0CF8D5A162F358ABE3801FF00FAD5F4B4734A7282763E6AB64F3537666135E42A3EFE690DF440679AD66F833E3B0A4EEB1381DA5E7F953348F09EA1022A6A1E0CD4E6962243C82E08573EC3154F318F444C7287D5994DA8DBAF56C7D6A23AC5A83F7BF5AF6DF0E695E1EBEB7B7B3BAF064F6F285C33DCDB6403EEDDEBC9BE20F81E4F0F78AAEAE859EDD36E0EE88A2FC89ED531CC252972A562E5954211E66DB3306A909E81A91F513FC29F9D662AA0C61FF5A9323D6BB23524D6A70CA8534F444E5E5B970A4F5AB05574FB37676CB1ACD6BE8ACDB7B48A081D33D6AA497B36A52893715841E3DEB0C462A9D183937A9D1430752BCD452B44B7A747F68BF84139F9B711ED5D3C5FBCD41D9461635D95CD698ED16AF091C2B0C135D0DADC22DFDCC24E18B6457C362DB949BF23EEF08A318A5E66851475A2BCD3D10201041E86B86BD022D45C71B771ED5D8DE5EC5670B3BB738E147535C44CCD7172D27392C4907DFB57A1818BD5BD8F3F1B25A25B92C727D9D84F19C30E4115D068F0C9763EDB74DBD89F907615CE32EE755046D5E4815D1695AA42B10865C211D0F6ADB12A5C9EEAD4CB0CE3CFEF3D0DCA724AF136E462A7D41A89658DFEEBA9FC694BA81CB0FCEBCAB347A974CD16BBB7BF8F65FC0A5C0C24E830E87D735DD7C32F125DDCDC5CE857B319CDB2078A663CB2F4C7BD7964FA85BDBAE5E404FA0EB5D3FC28B69358F16CDA8AB3C705AA71C70E7D2BD5CBE7579ECF63CCC7C69725D6E7BB514515ED9E385145140051451400514514001A439C714B450079BE997D6D3F8AB57B8BE291DE24822D8FC1551D08FAD5BD4FC5DA7D8B08A293ED172C7090C3F3313F415D3EA9E19D1F5970F7F6114B274DFCAB7E639AC6D6B40D3741F0BEA32E93670DACDE51FDE819651DF93CD724F0F797337A1D31AD68F2A5A9E6FA9FFC25BE31BEFB0DADD436769B8ACDE4B6E283D0B74CFB0AECBC33E05D27C371878E2F3AE88F9E7979635A9A15B59D8E8D6EB6A1046503161DC9EA6A96A1AA6A1A84AD61A05BF9F3F469C9C4717B93FD2B99C9C9F2411B28DBDE9B24D77C5165A205472D24EFC24318DCCC7E82B91F174FE2A8BC343589275D2A0691544457320DC70093DABD1BC3BE13B7D181B9B97FB66A327325CC8BCE7D147615B1A8E9B67AB58CB657F6E93DB4A30F1B8C835D54F0D18ABCB5673CEBC9BB4744713E16D261B7D3639E49CDDDC4AA19E6739DDF4AE8B200F415159F836CF4F4F2ACEEEF21800C2C4240557E9919A5B8F0A7DA3E53ABDFA26304295E7F1C560F0B52E6DEDE1639CD7B545BBD5B4ED1EC0F9D7725C2BBECE7CB407927D2BD1146001ED593A3786B4BD0831B2B7C4AFF007E673B9DBEA4D6BD7652A7C91B1CB527CEEE1498A5A2B5204A8E7B582EA231CF12488460875CD4B4500728FF000DBC22F2191B44B72C4E49E7AFE74AFF000E3C2522956D16DF07EBFE35D55029F33EE2E55D8F16F117ECFF00617D3F9DA3DFB5A966259251B947B0AE566F83BE2AB47F2A0B7867897FE5A0902E7F0AFA4E8A89C14F72E3271D8F91EF7C2BAF5A4DB5F4BBCCA3725222471EF5952B4A97064937AC8386CF18AFB30A823900D507D0F499092FA6DA3127249854E7F4AC1E1D773555D9F25A6B570808FB467EB515C7882552775C373CE057D6DFF08EE8BFF40AB2FF00BF0BFE1597A8FC3EF0BEA9389AE74980B818F906D1FA54AC1534EE57D6AA5AD73E5FD067B1D6B5A86DB50BD6B485D86E918647FF005ABE8193E17F84B55F0F797A5A4425DA025E44DB8961EB5B963F0EBC2BA7DD2DC41A4C2245E9B86E1F91AE96DEDA0B588456F124518E8A8B815BC69C62AC918B9C9BBB67CB9ADFC3CF126853B1934F926476C2BC037EE03BE074ACA9341D66389A57D2AF111796668480057D7B8CD3248A395192445646182A4641A87878BD8B559A3E37732C2B972EA3DF8ABB0E91ADDCDBA4F0E9D792C2E3E5748D981FCABEAE7D0F4A7186D36D587A1857FC2ADC30436F12C50C491C6BD1557007E152B0D1EAC7EDD9F21C9A36BC13FE409A83B7FD706AF62F82B797565653E937DA3DE5A485CC825962214FB74AF5EC0F414B81E95AC29463B19CAA4A5B8514515A1014514500145145001451450014514500151CF047730BC3322BC6E0AB2B0C823D2A4A28039DFF0084274811F9682E638F39D893B003DBAF4ADAB2B0B6D3AD96DED2158A25ECA3F535628A9518AD90DC9BDD8514515420A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A3145140051451400628A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00FFD90000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,2,'2011-02-12'),
 (6,NULL,2,'2011-02-26');
INSERT INTO `productosimagenes` VALUES  (7,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A4A09C726BC47C6DF1275A6F114B63E1DB90905BFCACEAA1B71EFD7D2A2738C15E45420E6ED13DBF38ACBD67C45A5E836AF3EA1771C4AA33B739623D877AF077F1DF8BF51B17D2AF2E76890E5E751B5F6FA0C567259E64325C4D2DC376F39CBE3E99AE3AB985286DAB3AE9606A4F7D0F55BFF008BB6314A834DD3EE2F6265C97CF9783E98350C7F1794CCAB2E893A464F2FE68381F4AF3A180300714135E7BCD2ADF448EE596D3B6AD9EF9A178974CF1142F269F3EF2870C8C30C3F0AB971AA595AC9E54D731ACB8C88F77CC7E82BE7CB0D62E3C3BA826A9671F992A02BE5E480F9F5C5747E09F13E7C46F26B76D6C24B9DF299DD8B18C0E428CF4FC2BD3C3E361562AFA33CFAF849D393B6A8F698E412C6AEB9C30C8C8C1A7572C3E22785F784FED35C9381F2375FCABA5B7B88AEA059A091648D864329C835D6A49ECCE5716B74494514531051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400550D46EAEE0091D95A79F33F4DC76A8FA9ABF58DE29D7E1F0DE8173A8CCD828B88F23AB1E82803CABE28788BC490DD59DAED934FCE72F6D3121B3EB5C3E8F6B25BC0ED36E32C8C5999BA93EB53ADD5EEB9A849AB6A32BBCB29E158F0A2AE1AF031D8AE76E11D8F730586E44A72DC28A4A0D79A7A026F5C9F9871D694B28EA4014EF0CF86A0F126A57F0C92CF16CE55A36E2AEEA5E0DB4B5BB5B57BDB9BB9BAF9108CB0FA9ED5D8B0B7B6A723C55AFA1969730B92038C838351BCD68F70A8EC8655FBB9EB5D84DA558C5A525B5EF87E78A14FF96A9F338F7E2974BD0BC1902B868AE6FC4AB82550BB467F0E86B58E0D5F76652C5B4B639665575C1008239AF4AF843A94F3E9F7FA6CADBA3B39008CE3B3735CEAFC378354BA61A3EBED0C44716F70BFBC5FA8F4AF47F04F8517C27A2FD91E449EE598B4B32AE37F3C66BBB05859D19B6DE871E2F130AD1492D4E9A8A28AF48F3C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B87F8AFA75C6A5E05BA8EDA232346CB2B01D957926BB8AF28F8D5ACEA1A7E9D65676B398A0B92DE6ED38240C719A89B4A2DB2A09B92B1E63A35DB5CD9AFC842AF00FAD69554D38C66CE3F2C8231CE3D6ADD7CAD569CDD91F4D4935057621200C9E82991C57BA8E22D3AD6599DF8076903F3A73B054249C002BD07E19DCCF73A1CBE68FDDA49888E31C56B87A6A776FA19626AB8249752AE81A3BF82FC37717974375EC9D141E727802BA5F0DE92D6767F6ABA01AFAE3E799CF5C9EC3DAAA6B84DE78934CB21CAC6DE6C8BEA3A574E06303B57A2F4479BBB119430208041EA0D73D2DB41E1ED405D41105B7B870B22A8E8C7BD7455475883CFD2AE100F9B612A40E87D6A53195759D212F61FB45B9315E45F3C72270723D7D6B73C35AC0D67488E660566426391588CEE1C13F8D6668B38B8D2603B8B15508C4F524706AAF864C761E2ED56D4E41BADB2C6A3A000735D7869B52E5673D78E9CC76D45145771CA1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C4FC47F0745E28D1C4BF68F26E2D159E366385F7CFE55DB551D66DBED9A2DE5B6C67F36164DA8704E476CD2924D598D369DD1F25E991DEDEEB634AD3D8BCDBF6B321CA8C77CFA5741AF5B6A3E179161B9BA864246727AD65787B41D48F8F7ECBA6CCF6AF13B0639059141E41ED9AF7ABDF09E95ADDB42BAB5AADD3460619B824FAF15E5D6852E649AD0F4294EA28B69EA7947863C31AB78B42DC4CDE4596793FDE1ED5ED5A56996DA45845676A81238C6062A7B5B586CADD20B78D6389061540E82A6ACF45A2564536DEECE60391F11595F1B0D88DB9F5DC6BA7AE3FC5C92E99A958EBD0A33A42DB2703FB9FFEB35B91EB96CF00999240A57702A85863EA2B47194926919F324ECCD4A64C4089C9E062B22DBC59A2DE4A6286F51A41D53F8BF2AA5E25F1469D63A64B1B5C059651B173C7278A8E496D62F9916BC28B2AE97279ADB89B890823D377151C25BFE167596CC6CFB1C9BF1EB918A9747D4F4F8747876CEAC1501765E4671CF34FF07C1FDA1ACEA1AD3440C2C4476B2E7AA8186FD6BA2845FB4B98D56940EDA8A4A5AF40E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800ACFD756E1B41BF5B40C6E0C0FE5853825B1C62B4291BEE9FA500786FC2AD264517BA95EA117924A6370DC9520E0F35EAC060015C8F82C6CB5BD46186FB74C71FF0002AEBABC8A9FC491E947E08851451500473C115CC0F0CC81E3718653DEB9C834DD67C36EE348912E6C0FFCBA4E7EEFD0D74F9A2B48549436265052DCE4E3BC0972F35B783523BD3D6578C0527D7239ACCBDD2B5097543A8EB165A55C6F188EDDDF013E9C735DFD715E3CB681EE349B8B98BCC8D2E15304F1962056EB13393B193A314AE5A1A5EA5A85A8B3FB2D8E9D60472B6DC971DC74E2BA5F095F5BB5B4DA64512C5259304745E983D0FE54F8A348A254450AAA3000ED58DA0DE4769E3BD46C84797BB4594BFA6D18AAA156539FBCC9AB4E318E877345145769CC145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001475A2A26BA812411BCD1AB9E8A5803F95007053C6344F195C5B98C456D7ABE64183C6E1F7BF9D7471BEF506B8FF00881A8C9AA6A6BA35AA79325A9595EEB1F329EA02FF005A9746F112EF8ECAEDB6DC80003D9FDEB8713879C7F7A968CEBA15E32FDDB7AA3ADA298922B8E0D3EB8D1D0CE5B59B6D7EDB515D4ACA51736F19C9B41C647B1F5A9F4DF196977CDE54F21B3B91F7A2B81B39F627AD7459AC19AC2DB5BBB9E0BFD2008D07CB3BA8CB7D0F5AB4D3DC977E86DA4A92286475653D0839AE5BE2002DA2DA04237FDBA1C7FDF55237816C11B75ADD5EC041CF13B11F966AC41E13805C472DD5D4F72233B95646E01F5A71B277B89DDAB1BB1822350C7270326B9DD12D9EEBE255E5E46A0C56D0F96EDBBA12011C55CD7B5FB7D1A158FF00D65DCC76430AFDE663D2B47C1BA1CDA569F25C5EA8FB7DDB79931073F41F80E2BA30B077E631AF256B1D28A28A2BB8E50A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AA7AA5F47A6E9B3DD4922279684A973804F61401CFEB3E2433DE49A4E9849947134C3A27B0F7ACA6D0ED6501A66965B80062776CB8FC6AA78695A6B79AFE54549AEA4323A8EC4D6ED75C6092B58E5949B77385B5B496DBC55756B7B7724EB26D31C921CB11E99ADEB8D0A286FA3D42D6353320C156FE21FE359BE27D35AF75BB01048619B0583AF5C8AE82EAF0699A6AC939DF22A81FEF35128A943925B0A3271973ADCCAD67C6FA7687A79B8BA1224DD04246189FF0ACAD0BE29AEA68F2358BB429DE33B9BF1146A51AEA963753EA5024B12C65802BC29AA5A7E996361221B1B6024907DC5E9F5AE386594D5EECEA9E613696875D67E3FD0AED0B79ED185FBC5D7183EF57078CFC3A47FC8560FCCD73A86E34AB8B7FECE8ED6396F1B6CD14F16E407FBD8F5AE86CBC4563688D06B3A727DA54FDEB7B4DC8C3D7A5632C0A4F7358E2F996C3478C74B99CC76265BD970484B74DC4D543A8F8AF59574D2746366071E6DE9D847B85EF5B5178C7C3F09578ACEE109E856CC83FCAA47F881A2C48CCEB78AA3A936CD4470915BEA37886F62BE81E0382CEE63D4F5799AFF541CF98FF00750FFB23B57655C64FE2BBCD413ED1A422C76A07DF9E3397FA0ED51D978BB5CF2C2DCE89E63027F789285047D0F35D0A9B4B4460E69BD59DBD15C35C7C40B8B797649A40001C1CDCA8207AE2B5B4BF1BE87AB5FF00D860BB0B738FB8E3193E80F7A1A6B71A927B1D1D140A290C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCE3C6B7F1EA7AC7F64CB024B0428240EB21E1F3D081C7E75D178CBC48340D3552289A5BBB92638514E307D49ED5E65A2593417CD1C92BCB34ADE6C8EE72493EF5BD085E577B18569D9591DD584220B38D40C71D2ACD22A8540A3A014B5BB31472FE244BD8758D3EFEDD4BC10AB798BEBD2A2D4EF575A92CA3870612DB9813821C76AEA656848D92153938C1EF55E3D26CA1B8F3D2050FEB8A04D32AEABA709BC3F7169120DCF1E31EA6A2D174F16366B7170A04BB7A1FE1ADBAE53C51AB4B1DEC3636F22AB05F35C67EF0E98A2FA832ADE5C49A86BF6B1C60811C9E61FA74AED40E07D2B82B0736CC6EA4917CD639EBF747A569FFC240ED8FDFC7C7A55B8DC952B1D5554BCB2176D1EF72A8A725477AC35D6E756FF005A87D891505A7881E7BC512B064DED900FA5271683991D25D5DC1A740A5C8519C2A8EF5902E4DB3CF7DA85CFC92711C2A7EE8FF1AC8D735386E358801622244270DEB52699A25E6BD7F05D4CAD0D8C0E1D14F5723BFD2B0AD5614A1CD27AF636A34E556568EC5B6D4D26024874669D0FF1941C8FC6B3AE9F41D62558AE206B0BD4E6391414287EBDEBD25224450A14003DAB2BC43A15B6B3A5CD0B46A26DA4C7201CA9F6AF3639849BF7A2AC77BC1C52F75BB8FF00097882EE4B86D2353659268D3743700E04ABEFEF5D9578259EA575E1F8F4CBCD5943C967704360F3D31CFE15EE3A7DFDB6A76515DDA4C92C322865743915D938A4EEB639E12BAD772D514515058514514005145140051451400514514005145140051451400514514005145140051451400552D5B54B7D1B4C9EFEE8E22857271576BCD7E20DEC97DABDA68EA7FD1D079D2953D4F4DA455462E4EC8994B955CE78DC4FAB6A771ACDD97065FF0055139CF949E956BC349F68BE9646E40738CF7150DD32C36721E985C0AD3F08C2E962AD281BF6F38F5AF41C541591C3CDCCEECE968A283D0D646860696B15EEB57B76C03152117DB1D6B7EB03C2D2ACB05D955DA45C383F9D6FD0B600CE2B1BC37A2697E25D47599754B08EE0C3702389DF3F776838FCEB608C823D6A3F053C1677BA8E9E5FFD21A4F34023EF2E3AD655AF634A56B9A8BE09F0E2A851A54200EDCD03C11E1B5C91A54033CF435D05707E3AF88116831B5869A567D4DC7AE562F7358462E4ECB7369CE308B94B6450F16FFC211E162A65D2A19EF987C902139C7BFA578F5BF88CDB789C4EC822B0776222539D99F7A8352BB9EE2E5E7BA9DA6BA94E64918F35CEDEBBEFF2D172CFC035DEE87B185DBD4F3A18975E768AD0F74D2F4AB2BF9E0D5AFB6919C4087BFBFBD7A0C4AAB1A85181E82B8282349F4EF0FD811B66F292518E3850335DF2FCA8A338AF99AB525526E7267D2429C69C14623A8A2A28EE619A49238E45678CE1C03D0D40CF22F8956B241AF411ABFF00A34DFBD2A47F1F4FE54EF87FE2B1E16D5BECB72656D3EE885001C8898F7C52FC4EBC12F89ECED147DC8B793F8D728EBBD48E9EFE95F5580A2AB60D296E7CA66188787C6F3476EA7D4CAC19430E846452D79AFC2AF153DFD9C9A2DF4A5AEAD7FD5B39FBC9DBEA6BD2AB825171938B3D784D4E2A51D985145152505145140051451400514514005145140051451400514514005145140051451400D77088CE7A2824D78DB4F0EA1ABDFEA7006F2EE652577F518E3FA5751F10B59BC8A4834AB192581E4432B4D19C7038DB5C7E968B158A46A724673EB9CD7561A3AF31CB889AF848F5BF9B4E68C121988031F5AEBF418F669E3E5E6B8CD51BFD32C232787948C7E15DDE96BB6C53DC5744FA98C0B9487EE9FA52D21E87E9591A1CA78119BEC77EAC4E45E4BD7FDEAEB2B90F0296586FD5FEF1BB908FA6EAEBE8E81D42B9FD1351B5D37C6FA9DCEA1702148E0C867E06DC8E6BA0240049E00AE335CD2A0D625BDBB405A2480A6EEC5B39E3D6A651E6D071972EA6C78CFE25D945A5FD9FC3F7915C5E4C76964E7CA1EB5E3EECC9E64F348D24CE773BB1C96354ECEE62DACE4FCD923F0A86E2E5A66C0FBBE95E961E8C292E65AB678D8AAF57113E47A244523991CB1E4935DAF843C0136A1730EA5A9218EDD08748C8E5CF63F4AE2E099ADE78E650098D8300464715D349F1AEF2DE2308D3E332AF0181E3F2AF37349D7E550A6B47BB3D5CAA14799CEA3D5743D3EDE2FB578CD36A8096316DC7FBC2A1F1A5F5DC1AB68905BCC63492E54C801C6E19E9591F0AF55BAF114BA96B377B0493155DA9C00071563C707FE2B3F0EA92705FD3BE6BE7E31E59DA5D0F7A72E68DD1E84A7E51F4AE6FC3DFF21ED77FEBE07FE822BA45FBA3E95CCE9F7705AEA1AE4C5447E5CB9663DCEDACD6C5DB53CD3C6F70B77E349C0E3C81B0FD6B229935DFF696B77B7C460CD21269F5F7181A7ECF0F189F079954F69899489AC3519F44D5AD756B6389206F9B8CE54F5FD2BE94D2B518756D2EDEFADCE6299038CF519F5AF998804107906BD2BE0F6B4626BBD0A79A30AA7CCB7527E66CF503E95CB9851DAA2F99DD94E237A32F91EB7451457947B8145145001451450014514500145145001451450014514500145145001451450078EEB1349278EB564989F91944433FC38E6A9CF6477F9B6F218A4CE481D1BEB52FC5CBF1A378A74DB8B60A279213BD71F7C67BD66E99E25B0D4309E608A6C64A3715E85069C35382B2B4C8E57B89B5AB6867887EEBE70E0F06BD22C3FE3C62FF0076BCFE7655D6ADDF20ABAED07DEBBBD2A4F32C94673B78A72D98A2F52E9A43D0D2D07A1ACCD0E0BC3FAA5BD85C5C896E235FF48937062010335D31F10DA4AE23B5592E2423E50AA707F1E95C940BA7196E2EAEE384289DC3BB28E80D6E5978C3C3E0AC16F22A20E010B8155CAECAC47324F534D60BED43FE3EF10407AC4A7E63EC4D66F8C7508B46F0D4E916D5765DA8B497FE3BD26D37A472F9928FE115E5DE20D5F53F125FEF68BCB814FC8AE7B55469C9BD88A95A115AB3097A7B9E694D5A5D2E6620BCDB07A28CD4ABA45BEE0CECECC3FDA22BBD4656D11E54AAD3BDDB33CC88B8CB28CF4E6AFF00867C2169E2CD64C535DC16B6F1E0CD2BB853F419AB0B636CBFF2C94E3FBC33522C10AE76C6A33E82A6AE1E552366C74B1B0A52BA4D9EA5E0F8347F0C5E5DE8B677D04AB1952195C12D9FE7557C5B72ADF10B4050C0A056078CE0E462BCDBC8457F3231E5C83A3AF0735D4FC3C7FEDAD767D1F506696E48FB45BDCB1CB4657F98AF0B1595CE937514AE99EFE0F36A75ED071B347B0493A476CD23300154935F3FEB1E2EB9D49EF2DADDC25BBCA77EDEAD8E39AF665F0DF88B51F32CB529EDA0B323FD740C4BB8F420F4AF23F889E1D4F0EF8B9D23F2D62BA512A220C600E39ACB2FC3AF68BDAA3A330AED527EC998B611958CB1EFD2AE53630046A17A638A757D6C5591F11397349B0A9F4BD424D1B5FB1D4E27D862902BB7FB04F3FA5414D9504913A1EE2A2AC39E0E25D0A8E954535D0FA8AD6E23BAB58AE226DD1C8A194FA83535735E03D43FB43C2364E5367949E575CE76F19AE96BE65AB3B1F649DD5C28A28A06145145001451450014514500145145001451450014514500145148481D4E2803C1FE38807C55A57FD7B3FF00E855E6654370457B27C6BD0669D6CF5D88964B75313A81D01E771AF1C041191D2BD5C1B4E9D8F231C9AA973A1F0CB4B7BA8F9534D232C6B94F9BEE9F6AF4AD0935285DC2BACD1F6078C5793689A926977E27913721E188ED5EB1E1EF13E95340545DC6A49E031C1A2AA516C7464E491D1192EC463102B3F71BF155DDF5297E510C70AE396DDBAAC2EA166C8185CC5B4F7DC2A8DFF89F48B1898CB7B1120642AB024D73D8E9BA3C564B9BABBD4AF20B99CBC51DC3E13A77AB06342BB4A8DBE955576CFAA5D5C459113CACE3F13572BD6C3C1469A563C0C65472AADA622A2AF4502968A2B738EED8514514005145140052E8BE229FC31E2A8B50B6852670855D09C1D87AD31DC229663C0ACC823F3F51F3CE78523DAB0C441548F2773AF09374A7ED3B1F56697AB5AEABA6C17B04D1B472A83F2B6707B8AF0CF8D1731CFE32B35B76F39A3B62AE23F98A9CF435C7586B72D8DBCD6E67995013B5558815AB6F33DAD9342007B8BAFBD2B72C057C954C77D5EA3496A8FB4A783FAC534DBD1A3160BE283CB6462C3B01CD4A355B60C15D8A31EC456FC11C56ECA7CA46C750475AD132E91791986F34B89171C342307F1CD5C3896A5ECE28C2A70BD2B5D49DCE623B88A5FB8E0D52D4E790279511DA4F53ED57B5BF0DC760E2E74E9F746DF36D07A7B573725CB3BF97FC5DC9AF5A967146B5377D19E454C92AD0AAADAA3E83F05EBB25F7852C60D2A28AC113F7724F28C82E38E07726BB0D22EB5096E2E9AFF625B02160DCBB58E07CC48FAD7CCFA0EB375A5AAC7A6DD4B04C5B8DA723EB835D14FAB5FDD1866D77529EED633F737633EDC57893C7538BD533E869E0E725A347D1AB246E70AEAC7D8E69F5F35C7AD5F595EB5E686B716A1BA0F33208F420D7A0D87C57B916D0A5CE8934B380048F138C7D71554F194A7A37614F09563ADAE7A9D15CD695E3BD0356B936D15DF9538EA93294C9F419EB5D20208C8E95D29A7B1CED35B8B45145310514514005145140051451400514514014356D5EDB48B5334E496FE08D7EF39F402BCDFC616DADF8CE188D91934B54FBAE66657C7704038A9F53D41D7C7FA925D2B492431A0B2881CE411C9FCEB4934DD4B524CDE4DF6588FF00CB284FCDFF007D57157AF352E589D54A941C79A479A4FF000F35078A48751F175D344C30D1F9C5B3F514CB2F8553498167AA9962071F3AE0D7ADC5A269966A1DA04675EB2C9CB1FA9ACAD47C73A1E9738B58E4F3EE338F2605DCDF95670C5568BF765A953C3D192F7A3A1C9C1F083254CDA8B0F50AA2BB0D33C11A3E9B69E42DAC6E49CB3B2E589FAD6B6957D3EA16DE7CB6AF6E1BEEABF0D8F71579982F52054D5C455A9A4E4D8E950A54DDE1148E66F7C11A6DCDACB1C4AD1BB03B4863C1AF29D5FE1DEB9A73BC820FB5469C89139E2BDD25BFB58595649954B1C004D58E187A835787C5D4A0EF1D7D48C46169D65692B1F355BCE90298A4051D4F3915605CC27F8C5755F123C13A836B305EE9063097722C4C8C30158F435413E0CF8D5A162F358ABE3801FF00FAD5F4B4734A7282763E6AB64F3537666135E42A3EFE690DF440679AD66F833E3B0A4EEB1381DA5E7F953348F09EA1022A6A1E0CD4E6962243C82E08573EC3154F318F444C7287D5994DA8DBAF56C7D6A23AC5A83F7BF5AF6DF0E695E1EBEB7B7B3BAF064F6F285C33DCDB6403EEDDEBC9BE20F81E4F0F78AAEAE859EDD36E0EE88A2FC89ED531CC252972A562E5954211E66DB3306A909E81A91F513FC29F9D662AA0C61FF5A9323D6BB23524D6A70CA8534F444E5E5B970A4F5AB05574FB37676CB1ACD6BE8ACDB7B48A081D33D6AA497B36A52893715841E3DEB0C462A9D183937A9D1430752BCD452B44B7A747F68BF84139F9B711ED5D3C5FBCD41D9461635D95CD698ED16AF091C2B0C135D0DADC22DFDCC24E18B6457C362DB949BF23EEF08A318A5E66851475A2BCD3D10201041E86B86BD022D45C71B771ED5D8DE5EC5670B3BB738E147535C44CCD7172D27392C4907DFB57A1818BD5BD8F3F1B25A25B92C727D9D84F19C30E4115D068F0C9763EDB74DBD89F907615CE32EE755046D5E4815D1695AA42B10865C211D0F6ADB12A5C9EEAD4CB0CE3CFEF3D0DCA724AF136E462A7D41A89658DFEEBA9FC694BA81CB0FCEBCAB347A974CD16BBB7BF8F65FC0A5C0C24E830E87D735DD7C32F125DDCDC5CE857B319CDB2078A663CB2F4C7BD7964FA85BDBAE5E404FA0EB5D3FC28B69358F16CDA8AB3C705AA71C70E7D2BD5CBE7579ECF63CCC7C69725D6E7BB514515ED9E385145140051451400514514001A439C714B450079BE997D6D3F8AB57B8BE291DE24822D8FC1551D08FAD5BD4FC5DA7D8B08A293ED172C7090C3F3313F415D3EA9E19D1F5970F7F6114B274DFCAB7E639AC6D6B40D3741F0BEA32E93670DACDE51FDE819651DF93CD724F0F797337A1D31AD68F2A5A9E6FA9FFC25BE31BEFB0DADD436769B8ACDE4B6E283D0B74CFB0AECBC33E05D27C371878E2F3AE88F9E7979635A9A15B59D8E8D6EB6A1046503161DC9EA6A96A1AA6A1A84AD61A05BF9F3F469C9C4717B93FD2B99C9C9F2411B28DBDE9B24D77C5165A205472D24EFC24318DCCC7E82B91F174FE2A8BC343589275D2A0691544457320DC70093DABD1BC3BE13B7D181B9B97FB66A327325CC8BCE7D147615B1A8E9B67AB58CB657F6E93DB4A30F1B8C835D54F0D18ABCB5673CEBC9BB4744713E16D261B7D3639E49CDDDC4AA19E6739DDF4AE8B200F415159F836CF4F4F2ACEEEF21800C2C4240557E9919A5B8F0A7DA3E53ABDFA26304295E7F1C560F0B52E6DEDE1639CD7B545BBD5B4ED1EC0F9D7725C2BBECE7CB407927D2BD1146001ED593A3786B4BD0831B2B7C4AFF007E673B9DBEA4D6BD7652A7C91B1CB527CEEE1498A5A2B5204A8E7B582EA231CF12488460875CD4B4500728FF000DBC22F2191B44B72C4E49E7AFE74AFF000E3C2522956D16DF07EBFE35D55029F33EE2E55D8F16F117ECFF00617D3F9DA3DFB5A966259251B947B0AE566F83BE2AB47F2A0B7867897FE5A0902E7F0AFA4E8A89C14F72E3271D8F91EF7C2BAF5A4DB5F4BBCCA3725222471EF5952B4A97064937AC8386CF18AFB30A823900D507D0F499092FA6DA3127249854E7F4AC1E1D773555D9F25A6B570808FB467EB515C7882552775C373CE057D6DFF08EE8BFF40AB2FF00BF0BFE1597A8FC3EF0BEA9389AE74980B818F906D1FA54AC1534EE57D6AA5AD73E5FD067B1D6B5A86DB50BD6B485D86E918647FF005ABE8193E17F84B55F0F797A5A4425DA025E44DB8961EB5B963F0EBC2BA7DD2DC41A4C2245E9B86E1F91AE96DEDA0B588456F124518E8A8B815BC69C62AC918B9C9BBB67CB9ADFC3CF126853B1934F926476C2BC037EE03BE074ACA9341D66389A57D2AF111796668480057D7B8CD3248A395192445646182A4641A87878BD8B559A3E37732C2B972EA3DF8ABB0E91ADDCDBA4F0E9D792C2E3E5748D981FCABEAE7D0F4A7186D36D587A1857FC2ADC30436F12C50C491C6BD1557007E152B0D1EAC7EDD9F21C9A36BC13FE409A83B7FD706AF62F82B797565653E937DA3DE5A485CC825962214FB74AF5EC0F414B81E95AC29463B19CAA4A5B8514515A1014514500145145001451450014514500151CF047730BC3322BC6E0AB2B0C823D2A4A28039DFF0084274811F9682E638F39D893B003DBAF4ADAB2B0B6D3AD96DED2158A25ECA3F535628A9518AD90DC9BDD8514515420A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A3145140051451400628A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00FFD90000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,2,'2011-02-21'),
 (8,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A4A09C726BC47C6DF1275A6F114B63E1DB90905BFCACEAA1B71EFD7D2A2738C15E45420E6ED13DBF38ACBD67C45A5E836AF3EA1771C4AA33B739623D877AF077F1DF8BF51B17D2AF2E76890E5E751B5F6FA0C567259E64325C4D2DC376F39CBE3E99AE3AB985286DAB3AE9606A4F7D0F55BFF008BB6314A834DD3EE2F6265C97CF9783E98350C7F1794CCAB2E893A464F2FE68381F4AF3A180300714135E7BCD2ADF448EE596D3B6AD9EF9A178974CF1142F269F3EF2870C8C30C3F0AB971AA595AC9E54D731ACB8C88F77CC7E82BE7CB0D62E3C3BA826A9671F992A02BE5E480F9F5C5747E09F13E7C46F26B76D6C24B9DF299DD8B18C0E428CF4FC2BD3C3E361562AFA33CFAF849D393B6A8F698E412C6AEB9C30C8C8C1A7572C3E22785F784FED35C9381F2375FCABA5B7B88AEA059A091648D864329C835D6A49ECCE5716B74494514531051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400550D46EAEE0091D95A79F33F4DC76A8FA9ABF58DE29D7E1F0DE8173A8CCD828B88F23AB1E82803CABE28788BC490DD59DAED934FCE72F6D3121B3EB5C3E8F6B25BC0ED36E32C8C5999BA93EB53ADD5EEB9A849AB6A32BBCB29E158F0A2AE1AF031D8AE76E11D8F730586E44A72DC28A4A0D79A7A026F5C9F9871D694B28EA4014EF0CF86A0F126A57F0C92CF16CE55A36E2AEEA5E0DB4B5BB5B57BDB9BB9BAF9108CB0FA9ED5D8B0B7B6A723C55AFA1969730B92038C838351BCD68F70A8EC8655FBB9EB5D84DA558C5A525B5EF87E78A14FF96A9F338F7E2974BD0BC1902B868AE6FC4AB82550BB467F0E86B58E0D5F76652C5B4B639665575C1008239AF4AF843A94F3E9F7FA6CADBA3B39008CE3B3735CEAFC378354BA61A3EBED0C44716F70BFBC5FA8F4AF47F04F8517C27A2FD91E449EE598B4B32AE37F3C66BBB05859D19B6DE871E2F130AD1492D4E9A8A28AF48F3C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B87F8AFA75C6A5E05BA8EDA232346CB2B01D957926BB8AF28F8D5ACEA1A7E9D65676B398A0B92DE6ED38240C719A89B4A2DB2A09B92B1E63A35DB5CD9AFC842AF00FAD69554D38C66CE3F2C8231CE3D6ADD7CAD569CDD91F4D4935057621200C9E82991C57BA8E22D3AD6599DF8076903F3A73B054249C002BD07E19DCCF73A1CBE68FDDA49888E31C56B87A6A776FA19626AB8249752AE81A3BF82FC37717974375EC9D141E727802BA5F0DE92D6767F6ABA01AFAE3E799CF5C9EC3DAAA6B84DE78934CB21CAC6DE6C8BEA3A574E06303B57A2F4479BBB119430208041EA0D73D2DB41E1ED405D41105B7B870B22A8E8C7BD7455475883CFD2AE100F9B612A40E87D6A53195759D212F61FB45B9315E45F3C72270723D7D6B73C35AC0D67488E660566426391588CEE1C13F8D6668B38B8D2603B8B15508C4F524706AAF864C761E2ED56D4E41BADB2C6A3A000735D7869B52E5673D78E9CC76D45145771CA1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C4FC47F0745E28D1C4BF68F26E2D159E366385F7CFE55DB551D66DBED9A2DE5B6C67F36164DA8704E476CD2924D598D369DD1F25E991DEDEEB634AD3D8BCDBF6B321CA8C77CFA5741AF5B6A3E179161B9BA864246727AD65787B41D48F8F7ECBA6CCF6AF13B0639059141E41ED9AF7ABDF09E95ADDB42BAB5AADD3460619B824FAF15E5D6852E649AD0F4294EA28B69EA7947863C31AB78B42DC4CDE4596793FDE1ED5ED5A56996DA45845676A81238C6062A7B5B586CADD20B78D6389061540E82A6ACF45A2564536DEECE60391F11595F1B0D88DB9F5DC6BA7AE3FC5C92E99A958EBD0A33A42DB2703FB9FFEB35B91EB96CF00999240A57702A85863EA2B47194926919F324ECCD4A64C4089C9E062B22DBC59A2DE4A6286F51A41D53F8BF2AA5E25F1469D63A64B1B5C059651B173C7278A8E496D62F9916BC28B2AE97279ADB89B890823D377151C25BFE167596CC6CFB1C9BF1EB918A9747D4F4F8747876CEAC1501765E4671CF34FF07C1FDA1ACEA1AD3440C2C4476B2E7AA8186FD6BA2845FB4B98D56940EDA8A4A5AF40E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800ACFD756E1B41BF5B40C6E0C0FE5853825B1C62B4291BEE9FA500786FC2AD264517BA95EA117924A6370DC9520E0F35EAC060015C8F82C6CB5BD46186FB74C71FF0002AEBABC8A9FC491E947E08851451500473C115CC0F0CC81E3718653DEB9C834DD67C36EE348912E6C0FFCBA4E7EEFD0D74F9A2B48549436265052DCE4E3BC0972F35B783523BD3D6578C0527D7239ACCBDD2B5097543A8EB165A55C6F188EDDDF013E9C735DFD715E3CB681EE349B8B98BCC8D2E15304F1962056EB13393B193A314AE5A1A5EA5A85A8B3FB2D8E9D60472B6DC971DC74E2BA5F095F5BB5B4DA64512C5259304745E983D0FE54F8A348A254450AAA3000ED58DA0DE4769E3BD46C84797BB4594BFA6D18AAA156539FBCC9AB4E318E877345145769CC145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001475A2A26BA812411BCD1AB9E8A5803F95007053C6344F195C5B98C456D7ABE64183C6E1F7BF9D7471BEF506B8FF00881A8C9AA6A6BA35AA79325A9595EEB1F329EA02FF005A9746F112EF8ECAEDB6DC80003D9FDEB8713879C7F7A968CEBA15E32FDDB7AA3ADA298922B8E0D3EB8D1D0CE5B59B6D7EDB515D4ACA51736F19C9B41C647B1F5A9F4DF196977CDE54F21B3B91F7A2B81B39F627AD7459AC19AC2DB5BBB9E0BFD2008D07CB3BA8CB7D0F5AB4D3DC977E86DA4A92286475653D0839AE5BE2002DA2DA04237FDBA1C7FDF55237816C11B75ADD5EC041CF13B11F966AC41E13805C472DD5D4F72233B95646E01F5A71B277B89DDAB1BB1822350C7270326B9DD12D9EEBE255E5E46A0C56D0F96EDBBA12011C55CD7B5FB7D1A158FF00D65DCC76430AFDE663D2B47C1BA1CDA569F25C5EA8FB7DDB79931073F41F80E2BA30B077E631AF256B1D28A28A2BB8E50A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AA7AA5F47A6E9B3DD4922279684A973804F61401CFEB3E2433DE49A4E9849947134C3A27B0F7ACA6D0ED6501A66965B80062776CB8FC6AA78695A6B79AFE54549AEA4323A8EC4D6ED75C6092B58E5949B77385B5B496DBC55756B7B7724EB26D31C921CB11E99ADEB8D0A286FA3D42D6353320C156FE21FE359BE27D35AF75BB01048619B0583AF5C8AE82EAF0699A6AC939DF22A81FEF35128A943925B0A3271973ADCCAD67C6FA7687A79B8BA1224DD04246189FF0ACAD0BE29AEA68F2358BB429DE33B9BF1146A51AEA963753EA5024B12C65802BC29AA5A7E996361221B1B6024907DC5E9F5AE386594D5EECEA9E613696875D67E3FD0AED0B79ED185FBC5D7183EF57078CFC3A47FC8560FCCD73A86E34AB8B7FECE8ED6396F1B6CD14F16E407FBD8F5AE86CBC4563688D06B3A727DA54FDEB7B4DC8C3D7A5632C0A4F7358E2F996C3478C74B99CC76265BD970484B74DC4D543A8F8AF59574D2746366071E6DE9D847B85EF5B5178C7C3F09578ACEE109E856CC83FCAA47F881A2C48CCEB78AA3A936CD4470915BEA37886F62BE81E0382CEE63D4F5799AFF541CF98FF00750FFB23B57655C64FE2BBCD413ED1A422C76A07DF9E3397FA0ED51D978BB5CF2C2DCE89E63027F789285047D0F35D0A9B4B4460E69BD59DBD15C35C7C40B8B797649A40001C1CDCA8207AE2B5B4BF1BE87AB5FF00D860BB0B738FB8E3193E80F7A1A6B71A927B1D1D140A290C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCE3C6B7F1EA7AC7F64CB024B0428240EB21E1F3D081C7E75D178CBC48340D3552289A5BBB92638514E307D49ED5E65A2593417CD1C92BCB34ADE6C8EE72493EF5BD085E577B18569D9591DD584220B38D40C71D2ACD22A8540A3A014B5BB31472FE244BD8758D3EFEDD4BC10AB798BEBD2A2D4EF575A92CA3870612DB9813821C76AEA656848D92153938C1EF55E3D26CA1B8F3D2050FEB8A04D32AEABA709BC3F7169120DCF1E31EA6A2D174F16366B7170A04BB7A1FE1ADBAE53C51AB4B1DEC3636F22AB05F35C67EF0E98A2FA832ADE5C49A86BF6B1C60811C9E61FA74AED40E07D2B82B0736CC6EA4917CD639EBF747A569FFC240ED8FDFC7C7A55B8DC952B1D5554BCB2176D1EF72A8A725477AC35D6E756FF005A87D891505A7881E7BC512B064DED900FA5271683991D25D5DC1A740A5C8519C2A8EF5902E4DB3CF7DA85CFC92711C2A7EE8FF1AC8D735386E358801622244270DEB52699A25E6BD7F05D4CAD0D8C0E1D14F5723BFD2B0AD5614A1CD27AF636A34E556568EC5B6D4D26024874669D0FF1941C8FC6B3AE9F41D62558AE206B0BD4E6391414287EBDEBD25224450A14003DAB2BC43A15B6B3A5CD0B46A26DA4C7201CA9F6AF3639849BF7A2AC77BC1C52F75BB8FF00097882EE4B86D2353659268D3743700E04ABEFEF5D9578259EA575E1F8F4CBCD5943C967704360F3D31CFE15EE3A7DFDB6A76515DDA4C92C322865743915D938A4EEB639E12BAD772D514515058514514005145140051451400514514005145140051451400514514005145140051451400552D5B54B7D1B4C9EFEE8E22857271576BCD7E20DEC97DABDA68EA7FD1D079D2953D4F4DA455462E4EC8994B955CE78DC4FAB6A771ACDD97065FF0055139CF949E956BC349F68BE9646E40738CF7150DD32C36721E985C0AD3F08C2E962AD281BF6F38F5AF41C541591C3CDCCEECE968A283D0D646860696B15EEB57B76C03152117DB1D6B7EB03C2D2ACB05D955DA45C383F9D6FD0B600CE2B1BC37A2697E25D47599754B08EE0C3702389DF3F776838FCEB608C823D6A3F053C1677BA8E9E5FFD21A4F34023EF2E3AD655AF634A56B9A8BE09F0E2A851A54200EDCD03C11E1B5C91A54033CF435D05707E3AF88116831B5869A567D4DC7AE562F7358462E4ECB7369CE308B94B6450F16FFC211E162A65D2A19EF987C902139C7BFA578F5BF88CDB789C4EC822B0776222539D99F7A8352BB9EE2E5E7BA9DA6BA94E64918F35CEDEBBEFF2D172CFC035DEE87B185DBD4F3A18975E768AD0F74D2F4AB2BF9E0D5AFB6919C4087BFBFBD7A0C4AAB1A85181E82B8282349F4EF0FD811B66F292518E3850335DF2FCA8A338AF99AB525526E7267D2429C69C14623A8A2A28EE619A49238E45678CE1C03D0D40CF22F8956B241AF411ABFF00A34DFBD2A47F1F4FE54EF87FE2B1E16D5BECB72656D3EE885001C8898F7C52FC4EBC12F89ECED147DC8B793F8D728EBBD48E9EFE95F5580A2AB60D296E7CA66188787C6F3476EA7D4CAC19430E846452D79AFC2AF153DFD9C9A2DF4A5AEAD7FD5B39FBC9DBEA6BD2AB825171938B3D784D4E2A51D985145152505145140051451400514514005145140051451400514514005145140051451400D77088CE7A2824D78DB4F0EA1ABDFEA7006F2EE652577F518E3FA5751F10B59BC8A4834AB192581E4432B4D19C7038DB5C7E968B158A46A724673EB9CD7561A3AF31CB889AF848F5BF9B4E68C121988031F5AEBF418F669E3E5E6B8CD51BFD32C232787948C7E15DDE96BB6C53DC5744FA98C0B9487EE9FA52D21E87E9591A1CA78119BEC77EAC4E45E4BD7FDEAEB2B90F0296586FD5FEF1BB908FA6EAEBE8E81D42B9FD1351B5D37C6FA9DCEA1702148E0C867E06DC8E6BA0240049E00AE335CD2A0D625BDBB405A2480A6EEC5B39E3D6A651E6D071972EA6C78CFE25D945A5FD9FC3F7915C5E4C76964E7CA1EB5E3EECC9E64F348D24CE773BB1C96354ECEE62DACE4FCD923F0A86E2E5A66C0FBBE95E961E8C292E65AB678D8AAF57113E47A244523991CB1E4935DAF843C0136A1730EA5A9218EDD08748C8E5CF63F4AE2E099ADE78E650098D8300464715D349F1AEF2DE2308D3E332AF0181E3F2AF37349D7E550A6B47BB3D5CAA14799CEA3D5743D3EDE2FB578CD36A8096316DC7FBC2A1F1A5F5DC1AB68905BCC63492E54C801C6E19E9591F0AF55BAF114BA96B377B0493155DA9C00071563C707FE2B3F0EA92705FD3BE6BE7E31E59DA5D0F7A72E68DD1E84A7E51F4AE6FC3DFF21ED77FEBE07FE822BA45FBA3E95CCE9F7705AEA1AE4C5447E5CB9663DCEDACD6C5DB53CD3C6F70B77E349C0E3C81B0FD6B229935DFF696B77B7C460CD21269F5F7181A7ECF0F189F079954F69899489AC3519F44D5AD756B6389206F9B8CE54F5FD2BE94D2B518756D2EDEFADCE6299038CF519F5AF998804107906BD2BE0F6B4626BBD0A79A30AA7CCB7527E66CF503E95CB9851DAA2F99DD94E237A32F91EB7451457947B8145145001451450014514500145145001451450014514500145145001451450078EEB1349278EB564989F91944433FC38E6A9CF6477F9B6F218A4CE481D1BEB52FC5CBF1A378A74DB8B60A279213BD71F7C67BD66E99E25B0D4309E608A6C64A3715E85069C35382B2B4C8E57B89B5AB6867887EEBE70E0F06BD22C3FE3C62FF0076BCFE7655D6ADDF20ABAED07DEBBBD2A4F32C94673B78A72D98A2F52E9A43D0D2D07A1ACCD0E0BC3FAA5BD85C5C896E235FF48937062010335D31F10DA4AE23B5592E2423E50AA707F1E95C940BA7196E2EAEE384289DC3BB28E80D6E5978C3C3E0AC16F22A20E010B8155CAECAC47324F534D60BED43FE3EF10407AC4A7E63EC4D66F8C7508B46F0D4E916D5765DA8B497FE3BD26D37A472F9928FE115E5DE20D5F53F125FEF68BCB814FC8AE7B55469C9BD88A95A115AB3097A7B9E694D5A5D2E6620BCDB07A28CD4ABA45BEE0CECECC3FDA22BBD4656D11E54AAD3BDDB33CC88B8CB28CF4E6AFF00867C2169E2CD64C535DC16B6F1E0CD2BB853F419AB0B636CBFF2C94E3FBC33522C10AE76C6A33E82A6AE1E552366C74B1B0A52BA4D9EA5E0F8347F0C5E5DE8B677D04AB1952195C12D9FE7557C5B72ADF10B4050C0A056078CE0E462BCDBC8457F3231E5C83A3AF0735D4FC3C7FEDAD767D1F506696E48FB45BDCB1CB4657F98AF0B1595CE937514AE99EFE0F36A75ED071B347B0493A476CD23300154935F3FEB1E2EB9D49EF2DADDC25BBCA77EDEAD8E39AF665F0DF88B51F32CB529EDA0B323FD740C4BB8F420F4AF23F889E1D4F0EF8B9D23F2D62BA512A220C600E39ACB2FC3AF68BDAA3A330AED527EC998B611958CB1EFD2AE53630046A17A638A757D6C5591F11397349B0A9F4BD424D1B5FB1D4E27D862902BB7FB04F3FA5414D9504913A1EE2A2AC39E0E25D0A8E954535D0FA8AD6E23BAB58AE226DD1C8A194FA83535735E03D43FB43C2364E5367949E575CE76F19AE96BE65AB3B1F649DD5C28A28A06145145001451450014514500145145001451450014514500145148481D4E2803C1FE38807C55A57FD7B3FF00E855E6654370457B27C6BD0669D6CF5D88964B75313A81D01E771AF1C041191D2BD5C1B4E9D8F231C9AA973A1F0CB4B7BA8F9534D232C6B94F9BEE9F6AF4AD0935285DC2BACD1F6078C5793689A926977E27913721E188ED5EB1E1EF13E95340545DC6A49E031C1A2AA516C7464E491D1192EC463102B3F71BF155DDF5297E510C70AE396DDBAAC2EA166C8185CC5B4F7DC2A8DFF89F48B1898CB7B1120642AB024D73D8E9BA3C564B9BABBD4AF20B99CBC51DC3E13A77AB06342BB4A8DBE955576CFAA5D5C459113CACE3F13572BD6C3C1469A563C0C65472AADA622A2AF4502968A2B738EED8514514005145140052E8BE229FC31E2A8B50B6852670855D09C1D87AD31DC229663C0ACC823F3F51F3CE78523DAB0C441548F2773AF09374A7ED3B1F56697AB5AEABA6C17B04D1B472A83F2B6707B8AF0CF8D1731CFE32B35B76F39A3B62AE23F98A9CF435C7586B72D8DBCD6E67995013B5558815AB6F33DAD9342007B8BAFBD2B72C057C954C77D5EA3496A8FB4A783FAC534DBD1A3160BE283CB6462C3B01CD4A355B60C15D8A31EC456FC11C56ECA7CA46C750475AD132E91791986F34B89171C342307F1CD5C3896A5ECE28C2A70BD2B5D49DCE623B88A5FB8E0D52D4E790279511DA4F53ED57B5BF0DC760E2E74E9F746DF36D07A7B573725CB3BF97FC5DC9AF5A967146B5377D19E454C92AD0AAADAA3E83F05EBB25F7852C60D2A28AC113F7724F28C82E38E07726BB0D22EB5096E2E9AFF625B02160DCBB58E07CC48FAD7CCFA0EB375A5AAC7A6DD4B04C5B8DA723EB835D14FAB5FDD1866D77529EED633F737633EDC57893C7538BD533E869E0E725A347D1AB246E70AEAC7D8E69F5F35C7AD5F595EB5E686B716A1BA0F33208F420D7A0D87C57B916D0A5CE8934B380048F138C7D71554F194A7A37614F09563ADAE7A9D15CD695E3BD0356B936D15DF9538EA93294C9F419EB5D20208C8E95D29A7B1CED35B8B45145310514514005145140051451400514514014356D5EDB48B5334E496FE08D7EF39F402BCDFC616DADF8CE188D91934B54FBAE66657C7704038A9F53D41D7C7FA925D2B492431A0B2881CE411C9FCEB4934DD4B524CDE4DF6588FF00CB284FCDFF007D57157AF352E589D54A941C79A479A4FF000F35078A48751F175D344C30D1F9C5B3F514CB2F8553498167AA9962071F3AE0D7ADC5A269966A1DA04675EB2C9CB1FA9ACAD47C73A1E9738B58E4F3EE338F2605DCDF95670C5568BF765A953C3D192F7A3A1C9C1F083254CDA8B0F50AA2BB0D33C11A3E9B69E42DAC6E49CB3B2E589FAD6B6957D3EA16DE7CB6AF6E1BEEABF0D8F71579982F52054D5C455A9A4E4D8E950A54DDE1148E66F7C11A6DCDACB1C4AD1BB03B4863C1AF29D5FE1DEB9A73BC820FB5469C89139E2BDD25BFB58595649954B1C004D58E187A835787C5D4A0EF1D7D48C46169D65692B1F355BCE90298A4051D4F3915605CC27F8C5755F123C13A836B305EE9063097722C4C8C30158F435413E0CF8D5A162F358ABE3801FF00FAD5F4B4734A7282763E6AB64F3537666135E42A3EFE690DF440679AD66F833E3B0A4EEB1381DA5E7F953348F09EA1022A6A1E0CD4E6962243C82E08573EC3154F318F444C7287D5994DA8DBAF56C7D6A23AC5A83F7BF5AF6DF0E695E1EBEB7B7B3BAF064F6F285C33DCDB6403EEDDEBC9BE20F81E4F0F78AAEAE859EDD36E0EE88A2FC89ED531CC252972A562E5954211E66DB3306A909E81A91F513FC29F9D662AA0C61FF5A9323D6BB23524D6A70CA8534F444E5E5B970A4F5AB05574FB37676CB1ACD6BE8ACDB7B48A081D33D6AA497B36A52893715841E3DEB0C462A9D183937A9D1430752BCD452B44B7A747F68BF84139F9B711ED5D3C5FBCD41D9461635D95CD698ED16AF091C2B0C135D0DADC22DFDCC24E18B6457C362DB949BF23EEF08A318A5E66851475A2BCD3D10201041E86B86BD022D45C71B771ED5D8DE5EC5670B3BB738E147535C44CCD7172D27392C4907DFB57A1818BD5BD8F3F1B25A25B92C727D9D84F19C30E4115D068F0C9763EDB74DBD89F907615CE32EE755046D5E4815D1695AA42B10865C211D0F6ADB12A5C9EEAD4CB0CE3CFEF3D0DCA724AF136E462A7D41A89658DFEEBA9FC694BA81CB0FCEBCAB347A974CD16BBB7BF8F65FC0A5C0C24E830E87D735DD7C32F125DDCDC5CE857B319CDB2078A663CB2F4C7BD7964FA85BDBAE5E404FA0EB5D3FC28B69358F16CDA8AB3C705AA71C70E7D2BD5CBE7579ECF63CCC7C69725D6E7BB514515ED9E385145140051451400514514001A439C714B450079BE997D6D3F8AB57B8BE291DE24822D8FC1551D08FAD5BD4FC5DA7D8B08A293ED172C7090C3F3313F415D3EA9E19D1F5970F7F6114B274DFCAB7E639AC6D6B40D3741F0BEA32E93670DACDE51FDE819651DF93CD724F0F797337A1D31AD68F2A5A9E6FA9FFC25BE31BEFB0DADD436769B8ACDE4B6E283D0B74CFB0AECBC33E05D27C371878E2F3AE88F9E7979635A9A15B59D8E8D6EB6A1046503161DC9EA6A96A1AA6A1A84AD61A05BF9F3F469C9C4717B93FD2B99C9C9F2411B28DBDE9B24D77C5165A205472D24EFC24318DCCC7E82B91F174FE2A8BC343589275D2A0691544457320DC70093DABD1BC3BE13B7D181B9B97FB66A327325CC8BCE7D147615B1A8E9B67AB58CB657F6E93DB4A30F1B8C835D54F0D18ABCB5673CEBC9BB4744713E16D261B7D3639E49CDDDC4AA19E6739DDF4AE8B200F415159F836CF4F4F2ACEEEF21800C2C4240557E9919A5B8F0A7DA3E53ABDFA26304295E7F1C560F0B52E6DEDE1639CD7B545BBD5B4ED1EC0F9D7725C2BBECE7CB407927D2BD1146001ED593A3786B4BD0831B2B7C4AFF007E673B9DBEA4D6BD7652A7C91B1CB527CEEE1498A5A2B5204A8E7B582EA231CF12488460875CD4B4500728FF000DBC22F2191B44B72C4E49E7AFE74AFF000E3C2522956D16DF07EBFE35D55029F33EE2E55D8F16F117ECFF00617D3F9DA3DFB5A966259251B947B0AE566F83BE2AB47F2A0B7867897FE5A0902E7F0AFA4E8A89C14F72E3271D8F91EF7C2BAF5A4DB5F4BBCCA3725222471EF5952B4A97064937AC8386CF18AFB30A823900D507D0F499092FA6DA3127249854E7F4AC1E1D773555D9F25A6B570808FB467EB515C7882552775C373CE057D6DFF08EE8BFF40AB2FF00BF0BFE1597A8FC3EF0BEA9389AE74980B818F906D1FA54AC1534EE57D6AA5AD73E5FD067B1D6B5A86DB50BD6B485D86E918647FF005ABE8193E17F84B55F0F797A5A4425DA025E44DB8961EB5B963F0EBC2BA7DD2DC41A4C2245E9B86E1F91AE96DEDA0B588456F124518E8A8B815BC69C62AC918B9C9BBB67CB9ADFC3CF126853B1934F926476C2BC037EE03BE074ACA9341D66389A57D2AF111796668480057D7B8CD3248A395192445646182A4641A87878BD8B559A3E37732C2B972EA3DF8ABB0E91ADDCDBA4F0E9D792C2E3E5748D981FCABEAE7D0F4A7186D36D587A1857FC2ADC30436F12C50C491C6BD1557007E152B0D1EAC7EDD9F21C9A36BC13FE409A83B7FD706AF62F82B797565653E937DA3DE5A485CC825962214FB74AF5EC0F414B81E95AC29463B19CAA4A5B8514515A1014514500145145001451450014514500151CF047730BC3322BC6E0AB2B0C823D2A4A28039DFF0084274811F9682E638F39D893B003DBAF4ADAB2B0B6D3AD96DED2158A25ECA3F535628A9518AD90DC9BDD8514515420A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A3145140051451400628A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00FFD90000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,2,'2011-02-21'),
 (9,NULL,2,'2011-02-21');
INSERT INTO `productosimagenes` VALUES  (10,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A4A09C726BC47C6DF1275A6F114B63E1DB90905BFCACEAA1B71EFD7D2A2738C15E45420E6ED13DBF38ACBD67C45A5E836AF3EA1771C4AA33B739623D877AF077F1DF8BF51B17D2AF2E76890E5E751B5F6FA0C567259E64325C4D2DC376F39CBE3E99AE3AB985286DAB3AE9606A4F7D0F55BFF008BB6314A834DD3EE2F6265C97CF9783E98350C7F1794CCAB2E893A464F2FE68381F4AF3A180300714135E7BCD2ADF448EE596D3B6AD9EF9A178974CF1142F269F3EF2870C8C30C3F0AB971AA595AC9E54D731ACB8C88F77CC7E82BE7CB0D62E3C3BA826A9671F992A02BE5E480F9F5C5747E09F13E7C46F26B76D6C24B9DF299DD8B18C0E428CF4FC2BD3C3E361562AFA33CFAF849D393B6A8F698E412C6AEB9C30C8C8C1A7572C3E22785F784FED35C9381F2375FCABA5B7B88AEA059A091648D864329C835D6A49ECCE5716B74494514531051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400550D46EAEE0091D95A79F33F4DC76A8FA9ABF58DE29D7E1F0DE8173A8CCD828B88F23AB1E82803CABE28788BC490DD59DAED934FCE72F6D3121B3EB5C3E8F6B25BC0ED36E32C8C5999BA93EB53ADD5EEB9A849AB6A32BBCB29E158F0A2AE1AF031D8AE76E11D8F730586E44A72DC28A4A0D79A7A026F5C9F9871D694B28EA4014EF0CF86A0F126A57F0C92CF16CE55A36E2AEEA5E0DB4B5BB5B57BDB9BB9BAF9108CB0FA9ED5D8B0B7B6A723C55AFA1969730B92038C838351BCD68F70A8EC8655FBB9EB5D84DA558C5A525B5EF87E78A14FF96A9F338F7E2974BD0BC1902B868AE6FC4AB82550BB467F0E86B58E0D5F76652C5B4B639665575C1008239AF4AF843A94F3E9F7FA6CADBA3B39008CE3B3735CEAFC378354BA61A3EBED0C44716F70BFBC5FA8F4AF47F04F8517C27A2FD91E449EE598B4B32AE37F3C66BBB05859D19B6DE871E2F130AD1492D4E9A8A28AF48F3C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B87F8AFA75C6A5E05BA8EDA232346CB2B01D957926BB8AF28F8D5ACEA1A7E9D65676B398A0B92DE6ED38240C719A89B4A2DB2A09B92B1E63A35DB5CD9AFC842AF00FAD69554D38C66CE3F2C8231CE3D6ADD7CAD569CDD91F4D4935057621200C9E82991C57BA8E22D3AD6599DF8076903F3A73B054249C002BD07E19DCCF73A1CBE68FDDA49888E31C56B87A6A776FA19626AB8249752AE81A3BF82FC37717974375EC9D141E727802BA5F0DE92D6767F6ABA01AFAE3E799CF5C9EC3DAAA6B84DE78934CB21CAC6DE6C8BEA3A574E06303B57A2F4479BBB119430208041EA0D73D2DB41E1ED405D41105B7B870B22A8E8C7BD7455475883CFD2AE100F9B612A40E87D6A53195759D212F61FB45B9315E45F3C72270723D7D6B73C35AC0D67488E660566426391588CEE1C13F8D6668B38B8D2603B8B15508C4F524706AAF864C761E2ED56D4E41BADB2C6A3A000735D7869B52E5673D78E9CC76D45145771CA1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C4FC47F0745E28D1C4BF68F26E2D159E366385F7CFE55DB551D66DBED9A2DE5B6C67F36164DA8704E476CD2924D598D369DD1F25E991DEDEEB634AD3D8BCDBF6B321CA8C77CFA5741AF5B6A3E179161B9BA864246727AD65787B41D48F8F7ECBA6CCF6AF13B0639059141E41ED9AF7ABDF09E95ADDB42BAB5AADD3460619B824FAF15E5D6852E649AD0F4294EA28B69EA7947863C31AB78B42DC4CDE4596793FDE1ED5ED5A56996DA45845676A81238C6062A7B5B586CADD20B78D6389061540E82A6ACF45A2564536DEECE60391F11595F1B0D88DB9F5DC6BA7AE3FC5C92E99A958EBD0A33A42DB2703FB9FFEB35B91EB96CF00999240A57702A85863EA2B47194926919F324ECCD4A64C4089C9E062B22DBC59A2DE4A6286F51A41D53F8BF2AA5E25F1469D63A64B1B5C059651B173C7278A8E496D62F9916BC28B2AE97279ADB89B890823D377151C25BFE167596CC6CFB1C9BF1EB918A9747D4F4F8747876CEAC1501765E4671CF34FF07C1FDA1ACEA1AD3440C2C4476B2E7AA8186FD6BA2845FB4B98D56940EDA8A4A5AF40E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800ACFD756E1B41BF5B40C6E0C0FE5853825B1C62B4291BEE9FA500786FC2AD264517BA95EA117924A6370DC9520E0F35EAC060015C8F82C6CB5BD46186FB74C71FF0002AEBABC8A9FC491E947E08851451500473C115CC0F0CC81E3718653DEB9C834DD67C36EE348912E6C0FFCBA4E7EEFD0D74F9A2B48549436265052DCE4E3BC0972F35B783523BD3D6578C0527D7239ACCBDD2B5097543A8EB165A55C6F188EDDDF013E9C735DFD715E3CB681EE349B8B98BCC8D2E15304F1962056EB13393B193A314AE5A1A5EA5A85A8B3FB2D8E9D60472B6DC971DC74E2BA5F095F5BB5B4DA64512C5259304745E983D0FE54F8A348A254450AAA3000ED58DA0DE4769E3BD46C84797BB4594BFA6D18AAA156539FBCC9AB4E318E877345145769CC145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001475A2A26BA812411BCD1AB9E8A5803F95007053C6344F195C5B98C456D7ABE64183C6E1F7BF9D7471BEF506B8FF00881A8C9AA6A6BA35AA79325A9595EEB1F329EA02FF005A9746F112EF8ECAEDB6DC80003D9FDEB8713879C7F7A968CEBA15E32FDDB7AA3ADA298922B8E0D3EB8D1D0CE5B59B6D7EDB515D4ACA51736F19C9B41C647B1F5A9F4DF196977CDE54F21B3B91F7A2B81B39F627AD7459AC19AC2DB5BBB9E0BFD2008D07CB3BA8CB7D0F5AB4D3DC977E86DA4A92286475653D0839AE5BE2002DA2DA04237FDBA1C7FDF55237816C11B75ADD5EC041CF13B11F966AC41E13805C472DD5D4F72233B95646E01F5A71B277B89DDAB1BB1822350C7270326B9DD12D9EEBE255E5E46A0C56D0F96EDBBA12011C55CD7B5FB7D1A158FF00D65DCC76430AFDE663D2B47C1BA1CDA569F25C5EA8FB7DDB79931073F41F80E2BA30B077E631AF256B1D28A28A2BB8E50A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AA7AA5F47A6E9B3DD4922279684A973804F61401CFEB3E2433DE49A4E9849947134C3A27B0F7ACA6D0ED6501A66965B80062776CB8FC6AA78695A6B79AFE54549AEA4323A8EC4D6ED75C6092B58E5949B77385B5B496DBC55756B7B7724EB26D31C921CB11E99ADEB8D0A286FA3D42D6353320C156FE21FE359BE27D35AF75BB01048619B0583AF5C8AE82EAF0699A6AC939DF22A81FEF35128A943925B0A3271973ADCCAD67C6FA7687A79B8BA1224DD04246189FF0ACAD0BE29AEA68F2358BB429DE33B9BF1146A51AEA963753EA5024B12C65802BC29AA5A7E996361221B1B6024907DC5E9F5AE386594D5EECEA9E613696875D67E3FD0AED0B79ED185FBC5D7183EF57078CFC3A47FC8560FCCD73A86E34AB8B7FECE8ED6396F1B6CD14F16E407FBD8F5AE86CBC4563688D06B3A727DA54FDEB7B4DC8C3D7A5632C0A4F7358E2F996C3478C74B99CC76265BD970484B74DC4D543A8F8AF59574D2746366071E6DE9D847B85EF5B5178C7C3F09578ACEE109E856CC83FCAA47F881A2C48CCEB78AA3A936CD4470915BEA37886F62BE81E0382CEE63D4F5799AFF541CF98FF00750FFB23B57655C64FE2BBCD413ED1A422C76A07DF9E3397FA0ED51D978BB5CF2C2DCE89E63027F789285047D0F35D0A9B4B4460E69BD59DBD15C35C7C40B8B797649A40001C1CDCA8207AE2B5B4BF1BE87AB5FF00D860BB0B738FB8E3193E80F7A1A6B71A927B1D1D140A290C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCE3C6B7F1EA7AC7F64CB024B0428240EB21E1F3D081C7E75D178CBC48340D3552289A5BBB92638514E307D49ED5E65A2593417CD1C92BCB34ADE6C8EE72493EF5BD085E577B18569D9591DD584220B38D40C71D2ACD22A8540A3A014B5BB31472FE244BD8758D3EFEDD4BC10AB798BEBD2A2D4EF575A92CA3870612DB9813821C76AEA656848D92153938C1EF55E3D26CA1B8F3D2050FEB8A04D32AEABA709BC3F7169120DCF1E31EA6A2D174F16366B7170A04BB7A1FE1ADBAE53C51AB4B1DEC3636F22AB05F35C67EF0E98A2FA832ADE5C49A86BF6B1C60811C9E61FA74AED40E07D2B82B0736CC6EA4917CD639EBF747A569FFC240ED8FDFC7C7A55B8DC952B1D5554BCB2176D1EF72A8A725477AC35D6E756FF005A87D891505A7881E7BC512B064DED900FA5271683991D25D5DC1A740A5C8519C2A8EF5902E4DB3CF7DA85CFC92711C2A7EE8FF1AC8D735386E358801622244270DEB52699A25E6BD7F05D4CAD0D8C0E1D14F5723BFD2B0AD5614A1CD27AF636A34E556568EC5B6D4D26024874669D0FF1941C8FC6B3AE9F41D62558AE206B0BD4E6391414287EBDEBD25224450A14003DAB2BC43A15B6B3A5CD0B46A26DA4C7201CA9F6AF3639849BF7A2AC77BC1C52F75BB8FF00097882EE4B86D2353659268D3743700E04ABEFEF5D9578259EA575E1F8F4CBCD5943C967704360F3D31CFE15EE3A7DFDB6A76515DDA4C92C322865743915D938A4EEB639E12BAD772D514515058514514005145140051451400514514005145140051451400514514005145140051451400552D5B54B7D1B4C9EFEE8E22857271576BCD7E20DEC97DABDA68EA7FD1D079D2953D4F4DA455462E4EC8994B955CE78DC4FAB6A771ACDD97065FF0055139CF949E956BC349F68BE9646E40738CF7150DD32C36721E985C0AD3F08C2E962AD281BF6F38F5AF41C541591C3CDCCEECE968A283D0D646860696B15EEB57B76C03152117DB1D6B7EB03C2D2ACB05D955DA45C383F9D6FD0B600CE2B1BC37A2697E25D47599754B08EE0C3702389DF3F776838FCEB608C823D6A3F053C1677BA8E9E5FFD21A4F34023EF2E3AD655AF634A56B9A8BE09F0E2A851A54200EDCD03C11E1B5C91A54033CF435D05707E3AF88116831B5869A567D4DC7AE562F7358462E4ECB7369CE308B94B6450F16FFC211E162A65D2A19EF987C902139C7BFA578F5BF88CDB789C4EC822B0776222539D99F7A8352BB9EE2E5E7BA9DA6BA94E64918F35CEDEBBEFF2D172CFC035DEE87B185DBD4F3A18975E768AD0F74D2F4AB2BF9E0D5AFB6919C4087BFBFBD7A0C4AAB1A85181E82B8282349F4EF0FD811B66F292518E3850335DF2FCA8A338AF99AB525526E7267D2429C69C14623A8A2A28EE619A49238E45678CE1C03D0D40CF22F8956B241AF411ABFF00A34DFBD2A47F1F4FE54EF87FE2B1E16D5BECB72656D3EE885001C8898F7C52FC4EBC12F89ECED147DC8B793F8D728EBBD48E9EFE95F5580A2AB60D296E7CA66188787C6F3476EA7D4CAC19430E846452D79AFC2AF153DFD9C9A2DF4A5AEAD7FD5B39FBC9DBEA6BD2AB825171938B3D784D4E2A51D985145152505145140051451400514514005145140051451400514514005145140051451400D77088CE7A2824D78DB4F0EA1ABDFEA7006F2EE652577F518E3FA5751F10B59BC8A4834AB192581E4432B4D19C7038DB5C7E968B158A46A724673EB9CD7561A3AF31CB889AF848F5BF9B4E68C121988031F5AEBF418F669E3E5E6B8CD51BFD32C232787948C7E15DDE96BB6C53DC5744FA98C0B9487EE9FA52D21E87E9591A1CA78119BEC77EAC4E45E4BD7FDEAEB2B90F0296586FD5FEF1BB908FA6EAEBE8E81D42B9FD1351B5D37C6FA9DCEA1702148E0C867E06DC8E6BA0240049E00AE335CD2A0D625BDBB405A2480A6EEC5B39E3D6A651E6D071972EA6C78CFE25D945A5FD9FC3F7915C5E4C76964E7CA1EB5E3EECC9E64F348D24CE773BB1C96354ECEE62DACE4FCD923F0A86E2E5A66C0FBBE95E961E8C292E65AB678D8AAF57113E47A244523991CB1E4935DAF843C0136A1730EA5A9218EDD08748C8E5CF63F4AE2E099ADE78E650098D8300464715D349F1AEF2DE2308D3E332AF0181E3F2AF37349D7E550A6B47BB3D5CAA14799CEA3D5743D3EDE2FB578CD36A8096316DC7FBC2A1F1A5F5DC1AB68905BCC63492E54C801C6E19E9591F0AF55BAF114BA96B377B0493155DA9C00071563C707FE2B3F0EA92705FD3BE6BE7E31E59DA5D0F7A72E68DD1E84A7E51F4AE6FC3DFF21ED77FEBE07FE822BA45FBA3E95CCE9F7705AEA1AE4C5447E5CB9663DCEDACD6C5DB53CD3C6F70B77E349C0E3C81B0FD6B229935DFF696B77B7C460CD21269F5F7181A7ECF0F189F079954F69899489AC3519F44D5AD756B6389206F9B8CE54F5FD2BE94D2B518756D2EDEFADCE6299038CF519F5AF998804107906BD2BE0F6B4626BBD0A79A30AA7CCB7527E66CF503E95CB9851DAA2F99DD94E237A32F91EB7451457947B8145145001451450014514500145145001451450014514500145145001451450078EEB1349278EB564989F91944433FC38E6A9CF6477F9B6F218A4CE481D1BEB52FC5CBF1A378A74DB8B60A279213BD71F7C67BD66E99E25B0D4309E608A6C64A3715E85069C35382B2B4C8E57B89B5AB6867887EEBE70E0F06BD22C3FE3C62FF0076BCFE7655D6ADDF20ABAED07DEBBBD2A4F32C94673B78A72D98A2F52E9A43D0D2D07A1ACCD0E0BC3FAA5BD85C5C896E235FF48937062010335D31F10DA4AE23B5592E2423E50AA707F1E95C940BA7196E2EAEE384289DC3BB28E80D6E5978C3C3E0AC16F22A20E010B8155CAECAC47324F534D60BED43FE3EF10407AC4A7E63EC4D66F8C7508B46F0D4E916D5765DA8B497FE3BD26D37A472F9928FE115E5DE20D5F53F125FEF68BCB814FC8AE7B55469C9BD88A95A115AB3097A7B9E694D5A5D2E6620BCDB07A28CD4ABA45BEE0CECECC3FDA22BBD4656D11E54AAD3BDDB33CC88B8CB28CF4E6AFF00867C2169E2CD64C535DC16B6F1E0CD2BB853F419AB0B636CBFF2C94E3FBC33522C10AE76C6A33E82A6AE1E552366C74B1B0A52BA4D9EA5E0F8347F0C5E5DE8B677D04AB1952195C12D9FE7557C5B72ADF10B4050C0A056078CE0E462BCDBC8457F3231E5C83A3AF0735D4FC3C7FEDAD767D1F506696E48FB45BDCB1CB4657F98AF0B1595CE937514AE99EFE0F36A75ED071B347B0493A476CD23300154935F3FEB1E2EB9D49EF2DADDC25BBCA77EDEAD8E39AF665F0DF88B51F32CB529EDA0B323FD740C4BB8F420F4AF23F889E1D4F0EF8B9D23F2D62BA512A220C600E39ACB2FC3AF68BDAA3A330AED527EC998B611958CB1EFD2AE53630046A17A638A757D6C5591F11397349B0A9F4BD424D1B5FB1D4E27D862902BB7FB04F3FA5414D9504913A1EE2A2AC39E0E25D0A8E954535D0FA8AD6E23BAB58AE226DD1C8A194FA83535735E03D43FB43C2364E5367949E575CE76F19AE96BE65AB3B1F649DD5C28A28A06145145001451450014514500145145001451450014514500145148481D4E2803C1FE38807C55A57FD7B3FF00E855E6654370457B27C6BD0669D6CF5D88964B75313A81D01E771AF1C041191D2BD5C1B4E9D8F231C9AA973A1F0CB4B7BA8F9534D232C6B94F9BEE9F6AF4AD0935285DC2BACD1F6078C5793689A926977E27913721E188ED5EB1E1EF13E95340545DC6A49E031C1A2AA516C7464E491D1192EC463102B3F71BF155DDF5297E510C70AE396DDBAAC2EA166C8185CC5B4F7DC2A8DFF89F48B1898CB7B1120642AB024D73D8E9BA3C564B9BABBD4AF20B99CBC51DC3E13A77AB06342BB4A8DBE955576CFAA5D5C459113CACE3F13572BD6C3C1469A563C0C65472AADA622A2AF4502968A2B738EED8514514005145140052E8BE229FC31E2A8B50B6852670855D09C1D87AD31DC229663C0ACC823F3F51F3CE78523DAB0C441548F2773AF09374A7ED3B1F56697AB5AEABA6C17B04D1B472A83F2B6707B8AF0CF8D1731CFE32B35B76F39A3B62AE23F98A9CF435C7586B72D8DBCD6E67995013B5558815AB6F33DAD9342007B8BAFBD2B72C057C954C77D5EA3496A8FB4A783FAC534DBD1A3160BE283CB6462C3B01CD4A355B60C15D8A31EC456FC11C56ECA7CA46C750475AD132E91791986F34B89171C342307F1CD5C3896A5ECE28C2A70BD2B5D49DCE623B88A5FB8E0D52D4E790279511DA4F53ED57B5BF0DC760E2E74E9F746DF36D07A7B573725CB3BF97FC5DC9AF5A967146B5377D19E454C92AD0AAADAA3E83F05EBB25F7852C60D2A28AC113F7724F28C82E38E07726BB0D22EB5096E2E9AFF625B02160DCBB58E07CC48FAD7CCFA0EB375A5AAC7A6DD4B04C5B8DA723EB835D14FAB5FDD1866D77529EED633F737633EDC57893C7538BD533E869E0E725A347D1AB246E70AEAC7D8E69F5F35C7AD5F595EB5E686B716A1BA0F33208F420D7A0D87C57B916D0A5CE8934B380048F138C7D71554F194A7A37614F09563ADAE7A9D15CD695E3BD0356B936D15DF9538EA93294C9F419EB5D20208C8E95D29A7B1CED35B8B45145310514514005145140051451400514514014356D5EDB48B5334E496FE08D7EF39F402BCDFC616DADF8CE188D91934B54FBAE66657C7704038A9F53D41D7C7FA925D2B492431A0B2881CE411C9FCEB4934DD4B524CDE4DF6588FF00CB284FCDFF007D57157AF352E589D54A941C79A479A4FF000F35078A48751F175D344C30D1F9C5B3F514CB2F8553498167AA9962071F3AE0D7ADC5A269966A1DA04675EB2C9CB1FA9ACAD47C73A1E9738B58E4F3EE338F2605DCDF95670C5568BF765A953C3D192F7A3A1C9C1F083254CDA8B0F50AA2BB0D33C11A3E9B69E42DAC6E49CB3B2E589FAD6B6957D3EA16DE7CB6AF6E1BEEABF0D8F71579982F52054D5C455A9A4E4D8E950A54DDE1148E66F7C11A6DCDACB1C4AD1BB03B4863C1AF29D5FE1DEB9A73BC820FB5469C89139E2BDD25BFB58595649954B1C004D58E187A835787C5D4A0EF1D7D48C46169D65692B1F355BCE90298A4051D4F3915605CC27F8C5755F123C13A836B305EE9063097722C4C8C30158F435413E0CF8D5A162F358ABE3801FF00FAD5F4B4734A7282763E6AB64F3537666135E42A3EFE690DF440679AD66F833E3B0A4EEB1381DA5E7F953348F09EA1022A6A1E0CD4E6962243C82E08573EC3154F318F444C7287D5994DA8DBAF56C7D6A23AC5A83F7BF5AF6DF0E695E1EBEB7B7B3BAF064F6F285C33DCDB6403EEDDEBC9BE20F81E4F0F78AAEAE859EDD36E0EE88A2FC89ED531CC252972A562E5954211E66DB3306A909E81A91F513FC29F9D662AA0C61FF5A9323D6BB23524D6A70CA8534F444E5E5B970A4F5AB05574FB37676CB1ACD6BE8ACDB7B48A081D33D6AA497B36A52893715841E3DEB0C462A9D183937A9D1430752BCD452B44B7A747F68BF84139F9B711ED5D3C5FBCD41D9461635D95CD698ED16AF091C2B0C135D0DADC22DFDCC24E18B6457C362DB949BF23EEF08A318A5E66851475A2BCD3D10201041E86B86BD022D45C71B771ED5D8DE5EC5670B3BB738E147535C44CCD7172D27392C4907DFB57A1818BD5BD8F3F1B25A25B92C727D9D84F19C30E4115D068F0C9763EDB74DBD89F907615CE32EE755046D5E4815D1695AA42B10865C211D0F6ADB12A5C9EEAD4CB0CE3CFEF3D0DCA724AF136E462A7D41A89658DFEEBA9FC694BA81CB0FCEBCAB347A974CD16BBB7BF8F65FC0A5C0C24E830E87D735DD7C32F125DDCDC5CE857B319CDB2078A663CB2F4C7BD7964FA85BDBAE5E404FA0EB5D3FC28B69358F16CDA8AB3C705AA71C70E7D2BD5CBE7579ECF63CCC7C69725D6E7BB514515ED9E385145140051451400514514001A439C714B450079BE997D6D3F8AB57B8BE291DE24822D8FC1551D08FAD5BD4FC5DA7D8B08A293ED172C7090C3F3313F415D3EA9E19D1F5970F7F6114B274DFCAB7E639AC6D6B40D3741F0BEA32E93670DACDE51FDE819651DF93CD724F0F797337A1D31AD68F2A5A9E6FA9FFC25BE31BEFB0DADD436769B8ACDE4B6E283D0B74CFB0AECBC33E05D27C371878E2F3AE88F9E7979635A9A15B59D8E8D6EB6A1046503161DC9EA6A96A1AA6A1A84AD61A05BF9F3F469C9C4717B93FD2B99C9C9F2411B28DBDE9B24D77C5165A205472D24EFC24318DCCC7E82B91F174FE2A8BC343589275D2A0691544457320DC70093DABD1BC3BE13B7D181B9B97FB66A327325CC8BCE7D147615B1A8E9B67AB58CB657F6E93DB4A30F1B8C835D54F0D18ABCB5673CEBC9BB4744713E16D261B7D3639E49CDDDC4AA19E6739DDF4AE8B200F415159F836CF4F4F2ACEEEF21800C2C4240557E9919A5B8F0A7DA3E53ABDFA26304295E7F1C560F0B52E6DEDE1639CD7B545BBD5B4ED1EC0F9D7725C2BBECE7CB407927D2BD1146001ED593A3786B4BD0831B2B7C4AFF007E673B9DBEA4D6BD7652A7C91B1CB527CEEE1498A5A2B5204A8E7B582EA231CF12488460875CD4B4500728FF000DBC22F2191B44B72C4E49E7AFE74AFF000E3C2522956D16DF07EBFE35D55029F33EE2E55D8F16F117ECFF00617D3F9DA3DFB5A966259251B947B0AE566F83BE2AB47F2A0B7867897FE5A0902E7F0AFA4E8A89C14F72E3271D8F91EF7C2BAF5A4DB5F4BBCCA3725222471EF5952B4A97064937AC8386CF18AFB30A823900D507D0F499092FA6DA3127249854E7F4AC1E1D773555D9F25A6B570808FB467EB515C7882552775C373CE057D6DFF08EE8BFF40AB2FF00BF0BFE1597A8FC3EF0BEA9389AE74980B818F906D1FA54AC1534EE57D6AA5AD73E5FD067B1D6B5A86DB50BD6B485D86E918647FF005ABE8193E17F84B55F0F797A5A4425DA025E44DB8961EB5B963F0EBC2BA7DD2DC41A4C2245E9B86E1F91AE96DEDA0B588456F124518E8A8B815BC69C62AC918B9C9BBB67CB9ADFC3CF126853B1934F926476C2BC037EE03BE074ACA9341D66389A57D2AF111796668480057D7B8CD3248A395192445646182A4641A87878BD8B559A3E37732C2B972EA3DF8ABB0E91ADDCDBA4F0E9D792C2E3E5748D981FCABEAE7D0F4A7186D36D587A1857FC2ADC30436F12C50C491C6BD1557007E152B0D1EAC7EDD9F21C9A36BC13FE409A83B7FD706AF62F82B797565653E937DA3DE5A485CC825962214FB74AF5EC0F414B81E95AC29463B19CAA4A5B8514515A1014514500145145001451450014514500151CF047730BC3322BC6E0AB2B0C823D2A4A28039DFF0084274811F9682E638F39D893B003DBAF4ADAB2B0B6D3AD96DED2158A25ECA3F535628A9518AD90DC9BDD8514515420A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A3145140051451400628A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00FFD90000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,2,'2011-02-26');
/*!40000 ALTER TABLE `productosimagenes` ENABLE KEYS */;


--
-- Definition of table `propietario`
--

DROP TABLE IF EXISTS `propietario`;
CREATE TABLE `propietario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identidades` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `usu` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `entidades_propietario` (`identidades`),
  CONSTRAINT `entidades_propietario` FOREIGN KEY (`identidades`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `propietario`
--

/*!40000 ALTER TABLE `propietario` DISABLE KEYS */;
INSERT INTO `propietario` VALUES  (1,26,'2011-08-16 19:55:44',2);
/*!40000 ALTER TABLE `propietario` ENABLE KEYS */;


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
  `estado` int(1) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Contacto_unico` (`idcontacto`),
  UNIQUE KEY `Entidad_Unica` (`identidades`),
  KEY `Contactos_Entidades` (`idcontacto`),
  KEY `Proveedores_Entidades` (`identidades`),
  CONSTRAINT `Contactos_Entidades` FOREIGN KEY (`idcontacto`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Proveedores_Entidades` FOREIGN KEY (`identidades`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proveedores`
--

/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
INSERT INTO `proveedores` VALUES  (1,8,9,2,'2011-02-09',NULL),
 (2,14,23,2,'2011-02-09',NULL),
 (3,6,24,2,'2011-03-04',NULL);
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;


--
-- Definition of table `proveeedorproducto`
--

DROP TABLE IF EXISTS `proveeedorproducto`;
CREATE TABLE `proveeedorproducto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `proveedores_id` int(11) NOT NULL,
  `productos_id` int(11) NOT NULL,
  `preciocompra` decimal(10,4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `LLave_Primaria` (`proveedores_id`,`productos_id`),
  KEY `fk_ProveeedorProducto_proveedores1` (`proveedores_id`),
  KEY `fk_ProveeedorProducto_productos1` (`productos_id`),
  CONSTRAINT `fk_ProveeedorProducto_proveedores1` FOREIGN KEY (`proveedores_id`) REFERENCES `proveedores` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProveeedorProducto_productos1` FOREIGN KEY (`productos_id`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proveeedorproducto`
--

/*!40000 ALTER TABLE `proveeedorproducto` DISABLE KEYS */;
/*!40000 ALTER TABLE `proveeedorproducto` ENABLE KEYS */;


--
-- Definition of table `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
CREATE TABLE `sucursales` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identidades` int(11) NOT NULL,
  `idusuario` int(11) DEFAULT NULL COMMENT 'Administrador de la Sucursal',
  `idmunicipio` int(11) DEFAULT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `estado` int(1) NOT NULL,
  `numerofactura` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Sucursales_Entidades1` (`identidades`),
  KEY `fk_Sucursales_Usuarios1` (`idusuario`),
  KEY `fk_Sucursales_Municipio1` (`idmunicipio`),
  CONSTRAINT `fk_Sucursales_Entidades1` FOREIGN KEY (`identidades`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Sucursales_Municipio1` FOREIGN KEY (`idmunicipio`) REFERENCES `municipios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Sucursales_Usuarios1` FOREIGN KEY (`idusuario`) REFERENCES `usuarios` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sucursales`
--

/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
INSERT INTO `sucursales` VALUES  (1,18,3,NULL,2,'2011-02-11 00:02:07',1,1),
 (2,19,2,NULL,2,'2011-02-02 22:29:15',1,56);
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;


--
-- Definition of table `tarjetacredito`
--

DROP TABLE IF EXISTS `tarjetacredito`;
CREATE TABLE `tarjetacredito` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `habilitado` int(1) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tarjetacredito`
--

/*!40000 ALTER TABLE `tarjetacredito` DISABLE KEYS */;
INSERT INTO `tarjetacredito` VALUES  (2,'CREDOMATIC',0,2,'2011-06-22 00:00:00'),
 (3,'VISA',1,2,'2011-06-22 00:00:00'),
 (4,'DISCOVERY',0,2,'2011-06-22 00:00:00');
/*!40000 ALTER TABLE `tarjetacredito` ENABLE KEYS */;


--
-- Definition of table `tipomontocuentacorriente`
--

DROP TABLE IF EXISTS `tipomontocuentacorriente`;
CREATE TABLE `tipomontocuentacorriente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipomontocuentacorriente`
--

/*!40000 ALTER TABLE `tipomontocuentacorriente` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipomontocuentacorriente` ENABLE KEYS */;


--
-- Definition of table `tiposfacturas`
--

DROP TABLE IF EXISTS `tiposfacturas`;
CREATE TABLE `tiposfacturas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) DEFAULT NULL,
  `habilitado` int(1) DEFAULT NULL,
  `usu` int(11) DEFAULT NULL,
  `fmodif` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Descripcion` (`descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tiposfacturas`
--

/*!40000 ALTER TABLE `tiposfacturas` DISABLE KEYS */;
INSERT INTO `tiposfacturas` VALUES  (1,'Contado',1,1,'2011-01-09 00:00:00'),
 (2,'Crédito',1,1,'2011-01-09 00:00:00');
/*!40000 ALTER TABLE `tiposfacturas` ENABLE KEYS */;


--
-- Definition of table `tiposmotocicletas`
--

DROP TABLE IF EXISTS `tiposmotocicletas`;
CREATE TABLE `tiposmotocicletas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `habilitado` int(1) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Descripcion` (`descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tiposmotocicletas`
--

/*!40000 ALTER TABLE `tiposmotocicletas` DISABLE KEYS */;
INSERT INTO `tiposmotocicletas` VALUES  (9,'Turismo',1,1,'2011-01-09 00:00:00'),
 (10,'Montañeza',1,1,'2011-01-09 00:00:00'),
 (11,'Todo Terreno',1,2,'2011-02-19 00:00:00');
/*!40000 ALTER TABLE `tiposmotocicletas` ENABLE KEYS */;


--
-- Definition of table `transaccionescaja`
--

DROP TABLE IF EXISTS `transaccionescaja`;
CREATE TABLE `transaccionescaja` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) DEFAULT NULL,
  `usu` int(11) DEFAULT NULL,
  `fmodif` datetime DEFAULT NULL,
  `tipo` varchar(3) DEFAULT NULL COMMENT 'C=credito\nD=debito\nN=neutral\n',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaccionescaja`
--

/*!40000 ALTER TABLE `transaccionescaja` DISABLE KEYS */;
INSERT INTO `transaccionescaja` VALUES  (1,'Venta Credito',1,'2011-06-19 00:00:00','N'),
 (2,'Pago Contado',1,'2011-06-19 00:00:00','C'),
 (3,'Pago Tarjeta Credito',1,'2011-06-19 00:00:00','C'),
 (4,'Apertura Caja',1,'2011-06-19 00:00:00','C'),
 (5,'Cierre Caja',1,'2011-06-19 00:00:00','D'),
 (6,'Retiro Efectivo',1,'2011-06-19 00:00:00','D'),
 (7,'Ingreso Efectivo',1,'2011-06-19 00:00:00','C'),
 (8,'Faltante Caja',1,'2011-06-19 00:00:00','D'),
 (10,'Anulacion Factura',1,'2011-06-19 00:00:00','D');
/*!40000 ALTER TABLE `transaccionescaja` ENABLE KEYS */;


--
-- Definition of table `transaccionestarjetacredito`
--

DROP TABLE IF EXISTS `transaccionestarjetacredito`;
CREATE TABLE `transaccionestarjetacredito` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idfacturaencabezado` int(11) NOT NULL,
  `numerotarjeta` varchar(45) DEFAULT NULL,
  `codigoaprobacion` varchar(45) DEFAULT NULL,
  `vencimiento` varchar(45) DEFAULT NULL,
  `idtarjetacredito` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` varchar(45) NOT NULL,
  `idcontrolcaja` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idfacturaencabezado_transcaciontarjetacredito` (`idfacturaencabezado`),
  KEY `idtarejtacredit_transaccionestarjetacredito` (`idtarjetacredito`),
  KEY `idtranasccionestarjetacredito_idcontrolcaja` (`idcontrolcaja`),
  CONSTRAINT `idfacturaencabezado_transcaciontarjetacredito` FOREIGN KEY (`idfacturaencabezado`) REFERENCES `facturaencabezado` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idtarejtacredit_transaccionestarjetacredito` FOREIGN KEY (`idtarjetacredito`) REFERENCES `tarjetacredito` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idtranasccionestarjetacredito_idcontrolcaja` FOREIGN KEY (`idcontrolcaja`) REFERENCES `controlcaja` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaccionestarjetacredito`
--

/*!40000 ALTER TABLE `transaccionestarjetacredito` DISABLE KEYS */;
INSERT INTO `transaccionestarjetacredito` VALUES  (1,49,'323','342424234','4243',3,2,'2011-07-26',12),
 (2,50,'4345','45354','5354',3,2,'2011-07-26',14);
/*!40000 ALTER TABLE `transaccionestarjetacredito` ENABLE KEYS */;


--
-- Definition of table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `identidades` int(11) NOT NULL,
  `contrasena` varchar(8000) NOT NULL,
  `usuario` varchar(45) NOT NULL,
  `estado` int(1) unsigned NOT NULL,
  `idsucursales` int(11) DEFAULT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` varchar(45) NOT NULL,
  `idrol` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `InicioSesion` (`usuario`),
  UNIQUE KEY `Entidad` (`identidades`),
  UNIQUE KEY `Usuario` (`usuario`),
  KEY `fk_Usuarios_Sucursales1` (`idsucursales`),
  KEY `Usuarios_Entidad` (`identidades`),
  CONSTRAINT `fk_Usuarios_Sucursales1` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Usuarios_Entidad` FOREIGN KEY (`identidades`) REFERENCES `entidades` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usuarios`
--

/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES  (2,4,'OMKo9I4+ikzQp9ahaG2jINHeUAQpJ5eK','smayorquin',1,1,2,'2011-03-02 00:59:28',4),
 (3,9,'OMKo9I4+ikzQp9ahaG2jINHeUAQpJ5eK','pcastro',1,NULL,2,'2011-03-01 00:59:34',5),
 (4,11,'OMKo9I4+ikzQp9ahaG2jINHeUAQpJ5eK','cmaldonado',0,NULL,2,'2011-03-01 00:59:55',1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;


--
-- Definition of function `CrearCorrelativoCodigo`
--

DROP FUNCTION IF EXISTS `CrearCorrelativoCodigo`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` FUNCTION `CrearCorrelativoCodigo`(iniciales nvarchar(2),sucursal int(11), usuario int(11), correlativo int) RETURNS varchar(70) CHARSET utf8
BEGIN

return concat(upper(iniciales),"-",repeat("0",3-CHARACTER_LENGTH(sucursal)),upper(sucursal),"-", upper(year(now())),repeat("0",2-CHARACTER_LENGTH(upper(month(now())))) , upper(month(now())), repeat("0",2-CHARACTER_LENGTH(upper(day(now())))), upper(day(now())),"-",repeat("0",3-CHARACTER_LENGTH(usuario)),upper(usuario),"-", repeat("0",7-CHARACTER_LENGTH(correlativo)),upper(correlativo) );

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of function `CrearUsuario`
--

DROP FUNCTION IF EXISTS `CrearUsuario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` FUNCTION `CrearUsuario`(nombreusuario nvarchar(45) ) RETURNS varchar(45) CHARSET utf8
BEGIN
set @conteo =0;

select count(*) from usuarios where usuario = nombreusuario  into @conteo;

if @conteo =0 then
  return nombreusuario;
else
  set @conteo=@conteo +1;
  return concat(nombreusuario,@conteo);
end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `AcumuladosControlCaja`
--

DROP PROCEDURE IF EXISTS `AcumuladosControlCaja`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AcumuladosControlCaja`(

/*defiicion de parametros*/
id nvarchar(11),
idtransacciones nvarchar(150),
fecha nvarchar(200),
cajero nvarchar(11),
idsucursales nvarchar(11),
tipo nvarchar(1)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select c.id as id, sum(c.monto) as monto, t.descripcion as descripcion ";
set @from="  ";
set @where=" where 1=1 ";
set @sql="";
set @group=" group by idtransaccionescaja ";

set @from= concat(@from," from controlcaja c ");

set @join = (" join transaccionescaja t  on c.idtransaccionescaja=t.id");

/*defiicion de filtros*/

if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if cajero<>"" then
  set @where= concat(@where, " and c.cajero = ", cajero, " ");
end if;

if idtransacciones<>"" then
  set @where = concat(@where, " and c.idtransaccionescaja = ",idtransacciones, " ");
end if;

if fecha<>"" then
  set @join = concat(@join, " and ",fecha, " ");
end if;

if idsucursales<>"" then
  set @where = concat(@where, " and c.idsucursales = ",idsucursales, " ");
end if;

if tipo<>"" then
  set @where = concat(@where, " and t.tipo = '",tipo, "' ");
end if;


set @sql = concat(@campos,@from,@join,@where,@group);



/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;



END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Clientes_Buscar`
--

DROP PROCEDURE IF EXISTS `Clientes_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Clientes_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
identidades nvarchar(11),
entidadnombre nvarchar(120),
espersonanatural nvarchar(1)
)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from clientes c ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if identidades<>"" then
  set @where = concat(@where, " and c.identidades = ",identidades," ");
end if;

if entidadnombre<>"" and espersonanatural <>""  then
  set @where = concat(@where, " and   e.entidadnombre like'",entidadnombre, "%' ");
end if;

if espersonanatural <>"" then
  set @join= concat(@join, " inner join ventidades e on e.IdEntidad=c.identidades and espersonanatural = ",espersonanatural);
end if;

set @sql = concat(@campos,@from,@join,@where,@orden);

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

inout id int(11),
identidades int(11),
usu int(11),
fmodif datetime
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
  where c.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Compras_Mant`
--

DROP PROCEDURE IF EXISTS `Compras_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Compras_Mant`(

/*definicion de parametros*/

inout id int(11),
facturacompra nvarchar(18),
idsucursal int(11),
idproveedor int(11),
fechacompra date,
totalcompra decimal(16,4),
estado nvarchar(3),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from compras m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO compras(facturacompra,idproveedor,fechacompra,idsucursal,totalcompra,usu,fmodif,estado)

  VALUES(facturacompra,idproveedor,fechacompra,idsucursal,totalcompra,usu,fmodif,estado);

  select last_insert_id() into id;

else

  UPDATE compras c set
        c.facturacompra=facturacompra,
        c.idsucursal=idsucursal,
        c.idproveedor=idproveedor,
        c.fechacompra=fechacompra,
        c.totalcompra=totalcompra,
        c.estado=estado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Compra_Buscar`
--

DROP PROCEDURE IF EXISTS `Compra_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Compra_Buscar`(


id nvarchar(11),
facturacompra nvarchar(50),
idproveedor nvarchar(11),
fechacompra nvarchar(150)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";
set @join=" join vproveedores v on v.idproveedor= o.idproveedor ";

set @campos= concat( @campos," o.*,v.*, v.estado as estadoproveedor,o.estado as estadocompra ");

set @from= concat(@from," from compras o");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if facturacompra<>"" then
  set @where= concat(@where, " and facturacompra = '", facturacompra, "' ");
end if;


if idproveedor<>"" then
  set @where= concat(@where, " and o.idproveedor = ", idproveedor, " ");
end if;

if fechacompra<>"" then
  set @where= concat(@where, " and ", fechacompra, " ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `ControlCajaFactura_Mant`
--

DROP PROCEDURE IF EXISTS `ControlCajaFactura_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ControlCajaFactura_Mant`(

/*definicion de parametros*/

inout id int(11),
idfacturaencabezado int(11),
idcontrolcaja int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from controlcajafactura m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO controlcajafactura(idfacturaencabezado,idcontrolcaja,usu,fmodif)

  VALUES(idfacturaencabezado,idcontrolcaja,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE controlcajafactura c set
        c.idfacturaencabezado=idfacturaencabezado,
        c.idcontrolcaja=idcontrolcaja,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `ControlCaja_Buscar`
--

DROP PROCEDURE IF EXISTS `ControlCaja_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ControlCaja_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
idtransacciones nvarchar(150),
fecha nvarchar(200),
cajero nvarchar(11),
idsucursales nvarchar(11)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @sql="";

set @campos= concat( @campos," c.*, t.descripcion as descripciontransaccion, t.tipo as tipo, fe.numerofactura as numerofactura ");

set @from= concat(@from," from controlcaja c ");

set @join = (" inner join transaccionescaja t on c.idtransaccionescaja=t.id");
set @left = (" left join controlcajafactura h on h.idcontrolcaja =c.id ");
set @left = concat(@left," left join facturaencabezado fe on h.idfacturaencabezado=fe.id ");
/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if cajero<>"" then
  set @where= concat(@where, " and c.cajero = ", cajero, " ");
end if;

if idtransacciones<>"" then
  set @where = concat(@where, " and c.idtransaccionescaja = ",idtransacciones, " ");
end if;

if fecha<>"" then
  set @where = concat(@where, " and ",fecha, " ");
end if;

if idsucursales<>"" then
  set @where = concat(@where, " and c.idsucursales = ",idsucursales, " ");
end if;


set @sql = concat(@campos,@from,@join,@left,@where);


/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `ControlCaja_Mant`
--

DROP PROCEDURE IF EXISTS `ControlCaja_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ControlCaja_Mant`(

/*definicion de parametros*/

inout id int(11),
idtransaccionescaja nvarchar(18),
idsucursales int(11),
monto decimal(18,2),
fecha datetime,
cajero int(11),
descripcion nvarchar(500),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from controlcaja m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO controlcaja(idtransaccionescaja,monto,fecha,cajero,idsucursales,descripcion,usu,fmodif)

  VALUES(idtransaccionescaja,monto,fecha,cajero,idsucursales,descripcion,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE controlcaja c set
        c.idtransaccionescaja=idtransaccionescaja,
        c.idsucursales=idsucursales,
        c.monto=monto,
        c.fecha=fecha,
        c.cajero=cajero,
        c.descripcion=descripcion,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `CuentaCorriente_Buscar`
--

DROP PROCEDURE IF EXISTS `CuentaCorriente_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CuentaCorriente_Buscar`(

id nvarchar(11),
codigo nvarchar(70),
codigoparecido nvarchar(70),
entidaddeudora nvarchar(200),
entidadbeneficiaria nvarchar(200),
identidadbenficiaria nvarchar(11),
identidaddeudora nvarchar(11),
fecha nvarchar(150)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";
set @join=" join ventidades v on v.idEntidad= o.identidaddeudora join ventidades v2 on v2.idEntidad=o.identidadbeneficiaria  ";

set @campos= concat( @campos," o.*, v.entidadnombre as nomDeudora,v2.entidadnombre as nomBenficiaria  ");

set @from= concat(@from," from cuentacorriente o");



if id<>"" then
  set @where= concat(@where, " and o.id = ", id, " ");
end if;


if codigo<>"" then
  set @where= concat(@where, " and codigo = '", codigo, "' ");
end if;

if codigoparecido<>"" then
  set @where= concat(@where, " and codigo like '", codigoparecido, "%' ");
end if;

if idproveedor<>"" then
  set @where= concat(@where, " and o.idproveedor = ", idproveedor, " ");
end if;

if elaboradopor<>"" then
  set @where= concat(@where, " and elaboradopor = ", elaboradopor, " ");
end if;


if fechaorden<>"" then
  set @where= concat(@where, " and ", fechaorden, " ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `CuentaCorriente_Mant`
--

DROP PROCEDURE IF EXISTS `CuentaCorriente_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `CuentaCorriente_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(70),
identidaddeudora int(11),
identidadbeneficiaria int(11),
estado nvarchar(5),
idsucursales int(11),
fecha date,
habilitado int(1),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from cuentacorriente m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from cuentacorriente into @correlativo;

  select CrearCorrelativoCodigo("CC",idsucursal,elaboradopor,@correlativo) into codigo;

  INSERT INTO cuentacorriente(codigo,identidaddeudora,identidadbeneficiaria,estado,idsucursales,fecha,habilitado,usu,fmodif)

  VALUES(codigo,identidaddeudora,identidadbeneficiaria,estado,idsucursales,fecha,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE cuentacorriente c set
        c.identidaddeudora=identidaddeudora,
        c.identidadbeneficiaria=identidadbeneficiaria,
        c.estado=estado,
        c.idsucursales=idsucursales,
        c.fech=fecha,
        c.habilitado=habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Departamentos_Buscar`
--

DROP PROCEDURE IF EXISTS `Departamentos_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Departamentos_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from departamentos ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
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
-- Definition of procedure `Departamentos_Mant`
--

DROP PROCEDURE IF EXISTS `Departamentos_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Departamentos_Mant`(

/*definicion de parametros*/

inout id int(11),
descripcion nvarchar(45),
habilitado tinyint(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from departamentos d where d.id=id into @conteo;

if @conteo =0 then

  INSERT INTO departamentos(descripcion,habilitado,usu,fmodif)

  VALUES(descripcion,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE departamentos c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `DetalleCompras_Buscar`
--

DROP PROCEDURE IF EXISTS `DetalleCompras_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleCompras_Buscar`(


id nvarchar(11),
idcompras nvarchar(11),
idproducto nvarchar(11)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @join = "join vproductos p on d.idproducto=p.idproducto ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from detallecompras d ");



if id<>"" then
  set @where= concat(@where, " and d.id = ", id, " ");
end if;


if idcompras<>"" then
  set @where= concat(@where, " and d.idcompras = ", idcompras, " ");
end if;


if idproducto<>"" then
  set @where= concat(@where, " and d.idproducto = ", idproducto, " ");
end if;




set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `DetalleCompras_Mant`
--

DROP PROCEDURE IF EXISTS `DetalleCompras_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleCompras_Mant`(

/*definicion de parametros*/

inout id int(11),
idcompras int(11),
idproducto int(11),
cantidad int(11),
preciocompra decimal(16,2),
idsucursal int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detallecompras m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detallecompras(idcompras,idproducto,cantidad,preciocompra,idsucursal,usu,fmodif)

  VALUES(idcompras,idproducto,cantidad,preciocompra,idsucursal,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE detallecompras c set
        c.idcompras=idcompras,
        c.idproducto=idproducto,
        c.cantidad=cantidad,
        c.preciocompra=preciocompra,
        c.idsucursal=idsucursal,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `DetalleOrden_Buscar`
--

DROP PROCEDURE IF EXISTS `DetalleOrden_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleOrden_Buscar`(


id nvarchar(11),
idordencompra nvarchar(11),
idproducto nvarchar(11)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @join = "join vproductos p on d.idproducto=p.idproducto ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from detalleorden d ");



if id<>"" then
  set @where= concat(@where, " and d.id = ", id, " ");
end if;


if idordencompra<>"" then
  set @where= concat(@where, " and d.idordencompra = ", idordencompra, " ");
end if;


if idproducto<>"" then
  set @where= concat(@where, " and d.idproducto = ", idproducto, " ");
end if;




set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `DetalleOrden_Mant`
--

DROP PROCEDURE IF EXISTS `DetalleOrden_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleOrden_Mant`(

/*definicion de parametros*/

inout id int(11),
idordencompra int(11),
idproducto int(11),
cantidad int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detalleorden m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detalleorden(idordencompra,idproducto,cantidad,usu,fmodif)

  VALUES(idordencompra,idproducto,cantidad,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE detalleorden c set
        c.idordencompra=idordencompra,
        c.idproducto=idproducto,
        c.cantidad=cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `DetalleRequisicion_Buscar`
--

DROP PROCEDURE IF EXISTS `DetalleRequisicion_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleRequisicion_Buscar`(


id nvarchar(11),
idrequisicion nvarchar(11),
idproducto nvarchar(11)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @join = "join vproductos p on d.idproducto=p.idproducto ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from detallerequisicion d ");



if id<>"" then
  set @where= concat(@where, " and d.id = ", id, " ");
end if;


if idrequisicion<>"" then
  set @where= concat(@where, " and d.idrequisicion = ", idrequisicion, " ");
end if;


if idproducto<>"" then
  set @where= concat(@where, " and d.idproducto = ", idproducto, " ");
end if;




set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `DetalleRequisicion_Mant`
--

DROP PROCEDURE IF EXISTS `DetalleRequisicion_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleRequisicion_Mant`(

/*definicion de parametros*/

inout id int(11),
idrequisicion int(11),
idproducto int(11),
cantidad int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detallerequisicion m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detallerequisicion(idrequisicion,idproducto,cantidad,usu,fmodif)

  VALUES(idrequisicion,idproducto,cantidad,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE detallerequisicion c set
        c.idrequisicion=idrequisicion,
        c.idproducto=idproducto,
        c.cantidad=cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `DetalleSalida_Mant`
--

DROP PROCEDURE IF EXISTS `DetalleSalida_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleSalida_Mant`(
/*definicion de parametros*/

inout id int(11),
idsucursal int(11),
idsalida int(11),
idproducto int(11),
cantidad int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detallesalida m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detallesalida(idsalida,idproducto,cantidad,usu,fmodif)

  VALUES(idsalida,idproducto,cantidad,usu,fmodif);

  /*CALL Inventarios_Triggers(idsucursal,idproducto,(cantidad * -1),usu,fmodif);*/


  select last_insert_id() into id;

else

  UPDATE detallesalida c set
        c.idsalida=idsalida,
        c.idproducto=idproducto,
        c.cantidad=cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

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

inout id int(11),
telefono int(11),
direccion varchar(150),
correo varchar (45),
espersonanatural bool,
rtn varchar(18),
entidadnombre varchar(120),
identificacion varchar(45),
tipoidentidad varchar(1),
telefono2 int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(e.id) from entidades E where E.id=id into @conteo;

if @conteo =0 then

  INSERT INTO entidades(telefono, direccion,correo,espersonanatural, RTN, usu,fmodif,entidadnombre,identificacion,tipoidentidad,telefono2)

  VALUES(telefono,direccion,correo,espersonanatural,rtn,usu,fmodif,entidadnombre,identificacion,tipoidentidad,telefono2);

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
        e.tipoidentidad=tipoidentidad,
        e.telefono2=telefono2
  where e.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `FacturaDetalle_Mant`
--

DROP PROCEDURE IF EXISTS `FacturaDetalle_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `FacturaDetalle_Mant`(
/*definicion de parametros*/

inout id int(11),
idfacturaencabezado int(11),
idproductos int(11),
cantidad int(11),
precioventa decimal(18,2),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from facturadetalle m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO facturadetalle(idfacturaencabezado,idproductos,cantidad,precioventa,usu,fmodif)

  VALUES(idfacturaencabezado,idproductos,cantidad,precioventa,usu,fmodif);


  select last_insert_id() into id;

else

  UPDATE facturadetalle c set
        c.idfacturaencabezado=idfacturaencabezado,
        c.idproductos=idproductos,
        c.cantidad=cantidad,
        c.precioventa=precioventa,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `FacturaEncabezado_Buscar`
--

DROP PROCEDURE IF EXISTS `FacturaEncabezado_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `FacturaEncabezado_Buscar`(

id nvarchar(11),
codigo nvarchar(70),
codigoparecido nvarchar(70),
idsucursales nvarchar(11),
estado nvarchar(11),
idtiposfacturas nvarchar(11),
motoproducto nvarchar(5),
fecha nvarchar(150)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @join=" join vsucursal v on v.idsucursal = o.idsucursales LEFT OUTER JOIN vclientes c on c.id=o.idclientes ";

set @campos= concat( @campos," o.*, v.idsucursal idsucursalenvia, v.identidades as identidades, v.descripcion as descripcionsucursal, c.identidades as identidades, c.entidadnombre as nombrecliente,c.espersonanatural ");

set @from= concat(@from," from facturaencabezado o ");



if id<>"" then
  set @where= concat(@where, " and o.id = ", id, " ");
end if;


if codigo<>"" then
  set @where= concat(@where, " and codigo = '", codigo, "' ");
end if;

if codigoparecido<>"" then
  set @where= concat(@where, " and codigo like '", codigoparecido, "%' ");
end if;

if idsucursales<>"" then
  set @where= concat(@where, " and idsucursales = ", idsucursales, " ");
end if;

if idtiposfacturas<>"" then
  set @where= concat(@where, " and idtiposfacturas = ", idtiposfacturas, " ");
end if;

if estado<>"" then
  set @where= concat(@where, " and estado = '", estado, "' ");
end if;

if motoproducto<>"" then
  set @where =concat(@where," and o.motoproducto like '",motoproducto,"%' ");
end if;

if fecha<>"" then
  set @where= concat(@where, " and ", fecha, " ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);
 
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `FacturaEncabezado_Mant`
--

DROP PROCEDURE IF EXISTS `FacturaEncabezado_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `FacturaEncabezado_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(150),
idsucursales int(11),
numerofactura varchar(100),
idclientes int(11),
fecha date,
idtiposfacturas int(11),
total decimal(16,4),
isv decimal(16,4),
subtotal decimal(16,4),
descuentovalor decimal(16,4),
descuento int(11),
ventaexcenta int(1),
estado nvarchar(5),
motoproducto nvarchar(5),
elabora int(11),
factura int(11),
idmotocicletas int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from facturaencabezado m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from facturaencabezado into @correlativo;

  select CrearCorrelativoCodigo("FE",idsucursales,elabora,@correlativo) into codigo;



  INSERT INTO facturaencabezado(codigo,idsucursales,numerofactura,idclientes,fecha,idtiposfacturas,total,isv,subtotal,
              descuentovalor,descuento,ventaexenta,estado,motoproducto,elabora,factura,idmotocicletas,usu,fmodif)

  VALUES(codigo,idsucursales,numerofactura,idclientes,fecha,idtiposfacturas,total,isv,subtotal,
              descuentovalor,descuento,ventaexcenta,estado,motoproducto,elabora,factura,idmotocicletas,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE facturaencabezado c set
        c.idsucursales=idsucursales,
        c.numerofactura=numerofactura,
        c.idclientes=idclientes,
        c.fecha=fecha,
        c.idtiposfacturas=idtiposfacturas,
        c.total=total,
        c.isv=isv,
        c.subtotal=subtotal,
        c.descuentovalor=descuentovalor,
        c.descuento=descuento,
        c.ventaexenta=ventaexcenta,
        c.estado=estado,
        c.motoproducto=motoproducto,
        c.elabora=elabora,
        c.factura=factura,
        c.idmotocicletas=idmotocicletas,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `GenerarNumeroFactura`
--

DROP PROCEDURE IF EXISTS `GenerarNumeroFactura`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GenerarNumeroFactura`(
idfactura  int(11),
idsucursal  int(11),
estado nvarchar(1),
numerofactura int(11)

)
BEGIN

  if estado='F' or estado='f' and numerofactura=0 then
      set @numerofactura =0;
      select s.numerofactura from sucursales s where id =idsucursal into @numerofactura  ;

      update facturaencabezado f set
        f.numerofactura=@numerofactura +1
      where f.id=idfactura;

      update sucursales f set
        f.numerofactura=@numerofactura +1
      where f.id=idsucursal;

  else
    update facturaencabezado f set
      f.numerofactura=numerofactura
      where f.id=idfactura;

  end if;



END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `HistoricoCompras_Buscar`
--

DROP PROCEDURE IF EXISTS `HistoricoCompras_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `HistoricoCompras_Buscar`(

id nvarchar(11),
idproducto nvarchar(11),
fechacompra nvarchar(150)
)
BEGIN

set @Campos="select c.id, v.descripcion as proveedor, fechacompra,facturacompra,cantidad, preciocompra ";
set @from=" ";
set @where=" where 1=1 and ";
set @join = "";
set @orden= "order by c.fechacompra desc ";
set @sql="";





set @from= concat(@from," from compras c ");


if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if idproducto<>"" then
  set @join= concat(@join, " inner join detallecompras d on d.idcompras=c.id and d.idproducto = ", idproducto, " ");
else
  set @join= concat(@join, " inner join detallecompras d on d.idcompras=c.id  ");
end if;

if fechacompra<>"" then
  set @where= concat(@where,fechacompra,"  " );
end if;

set @join= concat(@join, " inner join vproveedores v on c.idproveedor = v.idproveedor ");

set @sql = concat(@campos,@from,@join,@where,@orden);

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Imagenes_Buscar`
--

DROP PROCEDURE IF EXISTS `Imagenes_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Imagenes_Buscar`(

id nvarchar(11),
tabla nvarchar (60)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from ", Tabla);



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Inventarios_Triggers`
--

DROP PROCEDURE IF EXISTS `Inventarios_Triggers`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Inventarios_Triggers`(

idsucursales int(11),
idproductos int(11),
cantidad int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from inventario m where m.idsucursales = idsucursales and m.idproductos = idproductos  into @conteo;

if @conteo =0 then

  INSERT INTO inventario(idsucursales,idproductos,cantidad,usu,fmodif)

  VALUES(idsucursales,idproductos,cantidad,usu,fmodif);


else

  UPDATE inventario c set
        c.cantidad=c.cantidad + cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.idsucursales=idsucursales and c.idproductos = idproductos;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Inventario_Buscar`
--

DROP PROCEDURE IF EXISTS `Inventario_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Inventario_Buscar`(


id nvarchar(11),
idsucursal nvarchar(11),
idproducto nvarchar(11)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from inventario");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if idsucursal<>"" then
  set @where= concat(@where, " and idsucursales = ", idsucursal, " ");
end if;


if idproducto<>"" then
  set @where= concat(@where, " and idproductos = ", idproducto, " ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Inventario_Mant`
--

DROP PROCEDURE IF EXISTS `Inventario_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Inventario_Mant`(

/*definicion de parametros*/

inout id int(11),
idsucursales int(11),
idproductos int(11),
cantidad int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from inventario m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO inventario(idsucursales,idproductos,cantidad,usu,fmodif)

  VALUES(idsucursales,idproductos,cantidad,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE inventario c set
        c.idsucursales=idsucursales,
        c.idproductos=idproductos,
        c.cantidad= cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `MantenimientosComplejos_Buscar`
--

DROP PROCEDURE IF EXISTS `MantenimientosComplejos_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `MantenimientosComplejos_Buscar`(

/*defiicion de parametros*/
id nvarchar(75),
identidades nvarchar(11),
entidadnombre nvarchar(120),
espersonanatural nvarchar(1),
usuario nvarchar(45),
contrasena nvarchar(30),
estado nvarchar(1),
idrol nvarchar(55),
tabla nvarchar(25)
)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from ", tabla,"  c ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if identidades<>"" then
  set @where = concat(@where, " and c.identidades = ",identidades," ");
end if;

if estado<>"" then
  set @where = concat(@where, " and c.estado = ",estado," ");
end if;

if idrol<>"" then
  set @where = concat(@where, " and c.idrol ",idrol," ");
end if;


if usuario<>"" and contrasena<> "" then
  set @where = concat(@where, " and c.usuario COLLATE latin1_general_cs like '",usuario,"' and  contrasena COLLATE latin1_general_cs like '",contrasena,"' ");
end if;

if usuario<>"" then
  set @where = concat(@where, " and c.usuario COLLATE latin1_general_cs like '",usuario,"' " );
end if;


if entidadnombre<>""  then
  set @where = concat(@where, " and   e.entidadnombre like '",entidadnombre, "%' ");
end if;

if espersonanatural <>"" then
  set @join= concat(@join, " inner join ventidades e on e.IdEntidad=c.identidades and espersonanatural = ",espersonanatural);
else
  set @join= concat(@join," inner join ventidades e on e.IdEntidad=c.identidades");
end if;

set @sql = concat(@campos,@from,@join,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Mantenimientos_Buscar`
--

DROP PROCEDURE IF EXISTS `Mantenimientos_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Mantenimientos_Buscar`(


id nvarchar(11),
descripcion nvarchar(45),
tabla nvarchar (60),
habilitado nvarchar(1),
idderivada nvarchar(11)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from ", Tabla);



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
end if;

if habilitado<>"" then
  set @where = concat(@where, " and habilitado =  ", habilitado, " ");
end if;

if idderivada<>"" then
  set @where = concat(@where, " and idderivada =  ", idderivada, " ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Marcas_Buscar`
--

DROP PROCEDURE IF EXISTS `Marcas_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Marcas_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from marcas ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
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
-- Definition of procedure `Marcas_Mant`
--

DROP PROCEDURE IF EXISTS `Marcas_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Marcas_Mant`(

/*definicion de parametros*/

inout id int(11),
descripcion nvarchar(45),
habilitado int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from Marcas m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO Marcas(descripcion,habilitado,usu,fmodif)

  VALUES(descripcion,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE Marcas c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Modelos_Buscar`
--

DROP PROCEDURE IF EXISTS `Modelos_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Modelos_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from modelos ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
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
-- Definition of procedure `Modelos_Mant`
--

DROP PROCEDURE IF EXISTS `Modelos_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Modelos_Mant`(

/*definicion de parametros*/

inout id int(11),
descripcion nvarchar(45),
habilitado bool,
idderivada int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from modelos m  where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO modelos(descripcion,habilitado,idderivada,usu,fmodif)

  VALUES(descripcion,habilitado,idderivada,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE modelos c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.idderivada= idderivada,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `MotocicletasImagenes_Mant`
--

DROP PROCEDURE IF EXISTS `MotocicletasImagenes_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `MotocicletasImagenes_Mant`(

/*definicion de parametros*/

id int(11),
imagen longblob,
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from motocicletasimagenes c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO motocicletasimagenes (id,imagen,usu,fmodif)
  VALUES(id,imagen,usu,fmodif);


else

  UPDATE motocicletasimagenes c set
        c.imagen= imagen,
        c.usu=usu,
        c.fmodif = fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Motocicletas_Buscar`
--

DROP PROCEDURE IF EXISTS `Motocicletas_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Motocicletas_Buscar`(


id nvarchar(11),
idmarca nvarchar(45),
idmodelo nvarchar(45),
motor nvarchar(45),
chasis nvarchar(45),
estado nvarchar(45),
idsucursal nvarchar(45)


)
BEGIN

set @Campos="select  ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by motor ";
set @sql="";
set @join="";
set @join = " inner join marcas ma on m.idmarcas=ma.id
              inner join modelos mo on m.idmodelos=mo.id
              inner join vsucursal s on m.idsucursales= s.idsucursal ";

set @campos= concat( @campos," m.*,s.*,mo.descripcion as descripcionmodelos , ma.descripcion as descripcionmarcas ");

set @from= concat(@from," from motocicletas m ");



if id<>"" then
  set @where= concat(@where, " and m.id = ", id, " ");
end if;

if idmarca<>"" then
  set @where= concat(@where, " and m.idmarcas = ", idmarca, " ");
end if;

if idmodelo<>"" then
  set @where= concat(@where, " and m.idmodelos = ", idmodelo, " ");
end if;

if motor<>"" then
  set @where= concat(@where, " and m.motor = '", motor, "' ");
end if;

if chasis<>"" then
  set @where= concat(@where, " and m.chasis = '", chasis, "' ");
end if;

if idsucursal<>"" then
  set @where= concat(@where, " and m.idsucursales = ", idsucursal, " ");
end if;

if estado<>"" then
  set @where= concat(@where, " and m.estado = '",estado , "' ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);



PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Motocicletas_Mant`
--

DROP PROCEDURE IF EXISTS `Motocicletas_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Motocicletas_Mant`(

/*definicion de parametros*/

inout id int(11),
motor nvarchar(45),
chasis nvarchar(45),
idmarcas int(11),
idmodelos int(11),
idtiposmotocicletas int(11),
idsucursales int(11),
cilindraje int(11),
anio int (4),
precioventa decimal(15,2) ,
precioingreso decimal (15,2),
fechaingreso date,
estado nvarchar(5),
hp int(11),
idproveedor int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from motocicletas c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO motocicletas(motor,chasis,idmarcas,idmodelos,idtiposmotocicletas,idsucursales,cilindraje
                           ,anio,precioventa,precioingreso,fechaingreso,estado,hp,idproveedor,usu,fmodif)

  VALUES(motor,chasis,idmarcas,idmodelos,idtiposmotocicletas,idsucursales,cilindraje
                           ,anio,precioventa,precioingreso,fechaingreso,estado,hp,idproveedor,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE motocicletas c set
        c.motor=motor,
        c.chasis=chasis,
        c.idmarcas=idmarcas,
        c.idmodelos=idmodelos,
        c.idtiposmotocicletas=idtiposmotocicletas,
        c.idsucursales=idsucursales,
        c.cilindraje=cilindraje,
        c.anio=anio,
        c.precioventa=precioventa,
        c.precioingreso=precioingreso,
        c.estado=estado,
        c.hp=hp,
        c.usu=usu,
        c.idproveedor=idproveedor,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Municipios_Buscar`
--

DROP PROCEDURE IF EXISTS `Municipios_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Municipios_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from municipios ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
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
-- Definition of procedure `Municipios_Mant`
--

DROP PROCEDURE IF EXISTS `Municipios_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Municipios_Mant`(

/*definicion de parametros*/

inout id int(11),
descripcion nvarchar(45),
habilitado bool,
idderivada int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from municipios m  where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO municipios(descripcion,habilitado,idderivada,usu,fmodif)

  VALUES(descripcion,habilitado,idderivada,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE municipios c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.idderivada= idderivada,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `ObtnerCorrelativo`
--

DROP PROCEDURE IF EXISTS `ObtnerCorrelativo`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObtnerCorrelativo`(

tabla nvarchar(50),
out correlativo int(11)
)
BEGIN


set @correlativo= 0;
set @sql="select count(id) from ";
set @sql=concat(@sql, tabla," into @correlativo; ");

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

select @correlativo into correlativo;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `OrdenCompra_Buscar`
--

DROP PROCEDURE IF EXISTS `OrdenCompra_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenCompra_Buscar`(

id nvarchar(11),
codigo nvarchar(70),
codigoparecido nvarchar(70),
elaboradopor nvarchar(11),
idproveedor nvarchar(11),
fechaorden nvarchar(150)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";
set @join=" join vproveedores v on v.idproveedor= o.idproveedor ";

set @campos= concat( @campos," * ");

set @from= concat(@from," from ordenescompras o");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if codigo<>"" then
  set @where= concat(@where, " and codigo = '", codigo, "' ");
end if;

if codigoparecido<>"" then
  set @where= concat(@where, " and codigo like '", codigoparecido, "%' ");
end if;

if idproveedor<>"" then
  set @where= concat(@where, " and o.idproveedor = ", idproveedor, " ");
end if;

if elaboradopor<>"" then
  set @where= concat(@where, " and elaboradopor = ", elaboradopor, " ");
end if;


if fechaorden<>"" then
  set @where= concat(@where, " and ", fechaorden, " ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `OrdenCompra_Mant`
--

DROP PROCEDURE IF EXISTS `OrdenCompra_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenCompra_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(70),
idsucursal int(11),
idproveedor int(11),
fechaorden date,
elaboradopor int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from ordenescompras m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from ordenescompras into @correlativo;

  select CrearCorrelativoCodigo("oc",idsucursal,elaboradopor,@correlativo) into codigo;

  INSERT INTO ordenescompras(codigo,idproveedor,fechaorden,idsucursal,elaboradopor,usu,fmodif)

  VALUES(codigo,idproveedor,fechaorden,idsucursal,elaboradopor,usu,fmodif);

  select last_insert_id() into id;


else

  UPDATE ordenescompras c set
        c.idsucursal=idsucursal,
        c.idproveedor=idproveedor,
        c.fechaorden=fechaorden,
        c.elaboradopor=elaboradopor,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `OrdenRequisicion_Buscar`
--

DROP PROCEDURE IF EXISTS `OrdenRequisicion_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenRequisicion_Buscar`(

id nvarchar(11),
codigo nvarchar(70),
codigoparecido nvarchar(70),
sucursalenvia nvarchar(11),
sucursalrecibe nvarchar(11),
estado nvarchar(11),
fechaemision nvarchar(150)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @join=" join vsucursal v on v.idsucursal = o.sucursalenvia join vsucursal vr on vr.idsucursal= o.sucursalrecibe ";

set @campos= concat( @campos," o.*, v.idsucursal idsucursalenvia, v.identidades as identidadesenvia, v.descripcion as descripcionenvia, vr.idsucursal idsucursalrecibe, vr.identidades as identidadesrecibe, vr.descripcion as descripcionrecibe  ");

set @from= concat(@from," from ordenesrequisicion o ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if codigo<>"" then
  set @where= concat(@where, " and codigo = '", codigo, "' ");
end if;

if codigoparecido<>"" then
  set @where= concat(@where, " and codigo like '", codigoparecido, "%' ");
end if;

if sucursalenvia<>"" then
  set @where= concat(@where, " and sucursalenvia = ", sucursalenvia, " ");
end if;

if sucursalrecibe<>"" then
  set @where= concat(@where, " and sucursalrecibe = ", sucursalrecibe, " ");
end if;

if estado<>"" then
  set @where= concat(@where, " and estado = '", estado, "' ");
end if;


if fechaemision<>"" then
  set @where= concat(@where, " and ", fechaemision, " ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `OrdenRequisicion_Mant`
--

DROP PROCEDURE IF EXISTS `OrdenRequisicion_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenRequisicion_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(70),
enviadopor int(11),
recibidopor int(11),
fechaemision date,
sucursalenvia int(11),
sucursalrecibe int(11),
estado nvarchar(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from ordenesrequisicion m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from ordenesrequisicion into @correlativo;

  select CrearCorrelativoCodigo("OR",sucursalenvia,enviadopor,@correlativo) into codigo;

  INSERT INTO ordenesrequisicion(codigo,fechaemision,enviadopor,recibidopor,sucursalenvia,sucursalrecibe,estado,usu,fmodif)

  VALUES(codigo,fechaemision,enviadopor,recibidopor,sucursalenvia,sucursalrecibe,estado,usu,fmodif);

  select last_insert_id() into id;


else

  UPDATE ordenesrequisicion c set
        c.fechaemision=fechaemision,
        c.enviadopor=enviadopor,
        c.recibidopor=recibidopor,
        c.sucursalenvia=sucursalenvia,
        c.estado=estado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `OrdenSalida_Buscar`
--

DROP PROCEDURE IF EXISTS `OrdenSalida_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenSalida_Buscar`(

id nvarchar(11),
codigo nvarchar(70),
codigoparecido nvarchar(70),
sucursalenvia nvarchar(11),
sucursalrecibe nvarchar(11),
estado nvarchar(11),
fechaemision nvarchar(150)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @join=" join vsucursal v on v.idsucursal = o.sucursalenvia join vsucursal vr on vr.idsucursal= o.sucursalrecibe ";

set @campos= concat( @campos," o.*, v.idsucursal idsucursalenvia, v.identidades as identidadesenvia, v.descripcion as descripcionenvia, vr.idsucursal idsucursalrecibe, vr.identidades as identidadesrecibe, vr.descripcion as descripcionrecibe  ");

set @from= concat(@from," from ordenessalida o ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if codigo<>"" then
  set @where= concat(@where, " and codigo = '", codigo, "' ");
end if;

if codigoparecido<>"" then
  set @where= concat(@where, " and codigo like '", codigoparecido, "%' ");
end if;

if sucursalenvia<>"" then
  set @where= concat(@where, " and sucursalenvia = ", sucursalenvia, " ");
end if;

if sucursalrecibe<>"" then
  set @where= concat(@where, " and sucursalrecibe = ", sucursalrecibe, " ");
end if;

if estado<>"" then
  set @where= concat(@where, " and estado = '", estado, "' ");
end if;


if fechaemision<>"" then
  set @where= concat(@where, " and ", fechaemision, " ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `OrdenSalida_Mant`
--

DROP PROCEDURE IF EXISTS `OrdenSalida_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenSalida_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(70),
enviadopor int(11),
recibidopor int(11),
fechaemision date,
sucursalenvia int(11),
sucursalrecibe int(11),
estado nvarchar(11),
requisicion int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from ordenessalida m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from ordenessalida into @correlativo;

  select CrearCorrelativoCodigo("OS",sucursalenvia,enviadopor,@correlativo) into codigo;

  INSERT INTO ordenessalida(codigo,fechaemision,enviadopor,recibidopor,sucursalenvia,sucursalrecibe,estado,requisicion,usu,fmodif)

  VALUES(codigo,fechaemision,enviadopor,recibidopor,sucursalenvia,sucursalrecibe,estado,requisicion,usu,fmodif);

  select last_insert_id() into id;


else

  UPDATE ordenessalida c set
        c.fechaemision=fechaemision,
        c.enviadopor=enviadopor,
        c.recibidopor=recibidopor,
        c.sucursalenvia=sucursalenvia,
        c.sucursalrecibe=sucursalrecibe,
        c.estado=estado,
        c.requisicion=requisicion,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

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
razonsocial nvarchar(120),
razonsocialigual nvarchar(120),
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

if razonsocialigual<>"" then
  set @where = concat(@where, " and razonsocial = '",razonsocialigual, "' ");
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
nombrecompleto nvarchar(120),
nombrecompletoigual nvarchar (120),
identificacion nvarchar(45),
tipoidentificacion nvarchar(1),
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

if nombrecompletoigual<>"" then
  set @where = concat(@where, " and NombreCompleto = '",nombrecompletoigual, "' ");
end if;




if tipoidentificacion<>"" then
  set @where = concat(@where, " and tipoidentidad = '",tipoidentificacion,"' ");
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
-- Definition of procedure `ProductosImagenes_Mant`
--

DROP PROCEDURE IF EXISTS `ProductosImagenes_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProductosImagenes_Mant`(

/*definicion de parametros*/

id int(11),
imagen longblob,
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from productosimagenes c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO productosimagenes (id,imagen,usu,fmodif)
  VALUES(id,imagen,usu,fmodif);


else

  UPDATE productosimagenes c set
        c.imagen= imagen,
        c.usu=usu,
        c.fmodif = fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Productos_Buscar`
--

DROP PROCEDURE IF EXISTS `Productos_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Productos_Buscar`(


id nvarchar(11),
descripcion nvarchar(45),
codigo nvarchar(45),
codigoigual nvarchar(45)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from productos ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
end if;

if codigo<>"" then
  set @where = concat(@where, " and codigo like '",codigo, "%' ");
end if;

if codigoigual<>"" then
  set @where = concat(@where, " and codigo = '",codigoigual, "' ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Productos_Mant`
--

DROP PROCEDURE IF EXISTS `Productos_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Productos_Mant`(

/*definicion de parametros*/

inout id int(11),
codigo nvarchar(45),
descripcion nvarchar(45),
preciocosto decimal(15,2),
precioventa decimal(15,2),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from productos c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO productos(codigo,descripcion,preciocosto,precioventa,usu,fmodif)

  VALUES(codigo,descripcion,preciocosto,precioventa,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE productos c set
        c.codigo=codigo,
        c.descripcion=descripcion,
        c.preciocosto=preciocosto,
        c.precioventa=precioventa,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Propietario_Buscar`
--

DROP PROCEDURE IF EXISTS `Propietario_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Propietario_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
identidades nvarchar(11),
entidadnombre nvarchar(120)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " inner join ventidades e on e.IdEntidad=c.identidades ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from propietario c ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if identidades<>"" then
  set @where = concat(@where, " and c.identidades = ",identidades," ");
end if;

if entidadnombre<>""  then
  set @where = concat(@where, " and   e.entidadnombre like'",entidadnombre, "%' ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Propietario_Mant`
--

DROP PROCEDURE IF EXISTS `Propietario_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Propietario_Mant`(

/*definicion de parametros*/

inout id int(11),
identidades int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from propietario m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO propietario(identidades,usu,fmodif)

  VALUES(identidades,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE propietario c set
        c.identidades=identidades,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Proveedores_Buscar`
--

DROP PROCEDURE IF EXISTS `Proveedores_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proveedores_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
identidades nvarchar(11),
entidadnombre nvarchar(120),
espersonanatural nvarchar(1)
)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from proveedores c ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if identidades<>"" then
  set @where = concat(@where, " and c.identidades = ",identidades," ");
end if;

if entidadnombre<>"" and espersonanatural <>""  then
  set @where = concat(@where, " and   e.entidadnombre like'",entidadnombre, "%' ");
end if;

if espersonanatural <>"" then
  set @join= concat(@join, " inner join ventidades e on e.IdEntidad=c.identidades and espersonanatural = ",espersonanatural);
end if;

set @sql = concat(@campos,@from,@join,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Proveedores_Mant`
--

DROP PROCEDURE IF EXISTS `Proveedores_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proveedores_Mant`(

/*definicion de parametros*/

inout id int(11),
identidades int(11),
idcontacto int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from proveedores c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO proveedores(identidades,idcontacto,usu,fmodif)

  VALUES(identidades,idcontacto,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE proveedores c set
        c.identidades= identidades,
        c.idcontacto=idcontacto,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `ProveedorProducto_Trigg`
--

DROP PROCEDURE IF EXISTS `ProveedorProducto_Trigg`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ProveedorProducto_Trigg`(

/*definicion de parametros*/


idproveedores int(11),
idproducto int(11),
preciocompra decimal(10,2)

)
BEGIN


set @conteo =0;
select count(id) from proveedorproducto m where m.productos_id = idproveedores and m.prodcutos_id=idproducto  ;

if @conteo =0 then

  INSERT INTO proveedorproducto(proveedores_id,productos_id,preciocompra)

  VALUES(idproveedores,idproducto,preciocompra);



else

  UPDATE proveedorproducto m set
      m.preciocompra=preciocompra
  where  m.productos_id = idproveedores and m.prodcutos_id=idproducto  ;

end if;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Sucursales_Mant`
--

DROP PROCEDURE IF EXISTS `Sucursales_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sucursales_Mant`(

/*definicion de parametros*/

inout id int(11),
identidades int(11),
estado int(1),
idusuario int(11),
idmunicipio int(11),
numerofactura int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from sucursales c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO sucursales (identidades,estado,idusuario,idmunicipio,usu,fmodif,numerofactura)

  VALUES(identidades,estado,idusuario,idmunicipio,usu,fmodif,numerofactura);

  select last_insert_id() into id;

else

  UPDATE sucursales c set
        c.identidades= identidades,
        c.estado=estado,
        c.idusuario = idusuario,
        c.idmunicipio=idmunicipio,
        c.usu=usu,
        c.numerofactura=numerofactura,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `TarjetaCredito_Mant`
--

DROP PROCEDURE IF EXISTS `TarjetaCredito_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TarjetaCredito_Mant`(

/*definicion de parametros*/

inout id int(11),
descripcion nvarchar(45),
habilitado int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from tarjetacredito m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO tarjetacredito(descripcion,habilitado,usu,fmodif)

  VALUES(descripcion,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE tarjetacredito c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `TiposFacturas_Buscar`
--

DROP PROCEDURE IF EXISTS `TiposFacturas_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TiposFacturas_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from tiposfacturas ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
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
-- Definition of procedure `TiposFacturas_Mant`
--

DROP PROCEDURE IF EXISTS `TiposFacturas_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TiposFacturas_Mant`(

/*definicion de parametros*/

inout id int(11),
descripcion nvarchar(45),
habilitado int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from tiposfacturas t where t.id=id into @conteo;

if @conteo =0 then

  INSERT INTO tiposfacturas(descripcion,habilitado,usu,fmodif)

  VALUES(descripcion,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE tiposfacturas c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `TiposMotocicletas_Buscar`
--

DROP PROCEDURE IF EXISTS `TiposMotocicletas_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,STRICT_ALL_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,TRADITIONAL,NO_AUTO_CREATE_USER' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TiposMotocicletas_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from tiposmotocicletas ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
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
-- Definition of procedure `TiposMotocicletas_Mant`
--

DROP PROCEDURE IF EXISTS `TiposMotocicletas_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TiposMotocicletas_Mant`(

/*definicion de parametros*/

inout id int(11),
descripcion nvarchar(45),
habilitado int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from tiposmotocicletas t  where t.id=id into @conteo;

if @conteo =0 then

  INSERT INTO tiposmotocicletas(descripcion,habilitado,usu,fmodif)

  VALUES(descripcion,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE tiposmotocicletas c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;


END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `TransaccionesProductosComplejo_Buscar`
--

DROP PROCEDURE IF EXISTS `TransaccionesProductosComplejo_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TransaccionesProductosComplejo_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
idproductos nvarchar(11),
idsucursales nvarchar(11),
tabla nvarchar(500),
campos nvarchar(500),
parametro nvarchar(500)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @join = "join vproductos p on p.idproducto = i.idproductos";
set @sql="";
set @group = "";

set @campos= concat( @campos," ",campos," ");

set @from= concat(@from," from inventario i ");

set @join=concat(@join," ",tabla," ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and t.id = ", id, " ");
end if;

/*defiicion de filtros*/
if idproductos<>"" then
  set @join= concat(@join, " and p.idproducto = ", idproductos, " ");
end if;

/*defiicion de filtros*/
if idsucursales<>"" then
  set @join= concat(@join, " and i.idsucursales = ", idsucursales, " ");
end if;

/*defiicion de filtros*/
if parametro<>"" then
  set @where= concat(@where," and ",parametro ,"   ");
end if;






set @sql = concat(@campos,@from,@join,@where,@group,@orden);


/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `TransaccionesProductos_Buscar`
--

DROP PROCEDURE IF EXISTS `TransaccionesProductos_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TransaccionesProductos_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
idproductos nvarchar(11),
idsucursales nvarchar(11),
descripcion nvarchar(45),
inventarioTotal nvarchar(1),
codigo nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @join = "join vproductos p on p.idproducto = i.idproductos";
set @sql="";
set @group = "";

set @campos= concat( @campos," * ");

set @from= concat(@from," from inventario i ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and i.id = ", id, " ");
end if;

/*defiicion de filtros*/
if idproductos<>"" then
  set @join= concat(@join, " and p.idproducto = ", idproductos, " ");
end if;

/*defiicion de filtros*/
if idsucursales<>"" then
  set @join= concat(@join, " and i.idsucursales = ", idsucursales, " ");
end if;

/*defiicion de filtros*/
if codigo<>"" then
  set @join= concat(@join, " and p.codigo = '", codigo, "'  ");
end if;

/*defiicion de filtros*/
if descripcion<>"" then
  set @join= concat(@join, " and p.descripcion like '", descripcion, "%'  ");
end if;


/*defiicion de filtros*/
if descripcion<>"" then
  set @join= concat(@join, " and p.descripcion like '", descripcion, "%'  ");
end if;

/*defiicion de filtros*/
if inventarioTotal<>"" then
    set @campos= "select i.id,i.usu,i.idsucursales,i.fmodif,idproductos, idproducto,codigo,descripcion, sum(cantidad) as cantidad,precioventa  ";
    set @group = "group by i.idproductos ";
end if;

set @sql = concat(@campos,@from,@join,@where,@group,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `TransaccionesTarjetaCredito_Mant`
--

DROP PROCEDURE IF EXISTS `TransaccionesTarjetaCredito_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TransaccionesTarjetaCredito_Mant`(

/*definicion de parametros*/

inout id int(11),
idfacturaencabezado int(11),
numerotarjeta nvarchar(45),
codigoaprobacion nvarchar(45),
vencimiento int(4),
idtarjetacredito int(11),
idcontrolcaja int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from transaccionestarjetacredito d where d.id=id into @conteo;

if @conteo =0 then

  INSERT INTO transaccionestarjetacredito(idfacturaencabezado,codigoaprobacion,vencimiento,idtarjetacredito,numerotarjeta,idcontrolcaja,usu,fmodif)

  VALUES(idfacturaencabezado,codigoaprobacion,vencimiento,idtarjetacredito,numerotarjeta,idcontrolcaja,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE transaccionestarjetacredito c set
        c.idfacturaencabezado= idfacturaencabezado,
        c.numerotarjeta =numerotarjeta,
        c.codigoaprobacion =codigoaprobacion,
        c.vencimiento =c.vencimiento,
        c.idtrajetacredito=idtrajetacredito,
        c.idcontrolcaja=idcontrolcaja,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `Usuarios_Mant`
--

DROP PROCEDURE IF EXISTS `Usuarios_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Usuarios_Mant`(

/*definicion de parametros*/

inout id int(11),
identidades int(11),
contrasena nvarchar(8000),
usuario nvarchar(45),
estado int(1),
idrol int(11),
idsucursales int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from usuarios c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO usuarios (identidades,contrasena,usuario,idrol,estado,idsucursales,usu,fmodif)

  VALUES(identidades,contrasena,usuario,idrol,estado,idsucursales,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE usuarios c set
        c.identidades= identidades,
        c.contrasena=contrasena,
        c.usuario = usuario,
        c.idrol=idrol,
        c.idsucursales=idsucursales,
        c.usu=usu,
        c.fmodif=fmodif,
        c.estado=estado

  where c.id= id;

end if;
END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of view `personasjuridicas`
--

DROP TABLE IF EXISTS `personasjuridicas`;
DROP VIEW IF EXISTS `personasjuridicas`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `personasjuridicas` AS select `entidades`.`entidadnombre` AS `RazonSocial`,`entidades`.`telefono` AS `telefono`,`entidades`.`direccion` AS `direccion`,`entidades`.`correo` AS `correo`,`entidades`.`RTN` AS `RTN`,`entidades`.`id` AS `id`,`entidades`.`telefono2` AS `telefono2` from `entidades` where (`entidades`.`espersonanatural` = 0);

--
-- Definition of view `personasnaturales`
--

DROP TABLE IF EXISTS `personasnaturales`;
DROP VIEW IF EXISTS `personasnaturales`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `personasnaturales` AS select `e`.`telefono` AS `telefono`,`e`.`direccion` AS `direccion`,`e`.`correo` AS `correo`,`e`.`RTN` AS `RTN`,`e`.`usu` AS `usu`,`e`.`fmodif` AS `fmodif`,`e`.`entidadnombre` AS `NombreCompleto`,`e`.`identificacion` AS `identificacion`,`e`.`tipoidentidad` AS `tipoidentidad`,`e`.`id` AS `id`,`e`.`telefono2` AS `telefono2` from `entidades` `e` where (`e`.`espersonanatural` = 1);

--
-- Definition of view `vclientes`
--

DROP TABLE IF EXISTS `vclientes`;
DROP VIEW IF EXISTS `vclientes`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vclientes` AS select `c`.`id` AS `id`,`c`.`identidades` AS `identidades`,`c`.`usu` AS `usu`,`c`.`fmodif` AS `fmodif`,`c`.`estado` AS `estado`,`v`.`entidadnombre` AS `entidadnombre`,`v`.`espersonanatural` AS `espersonanatural` from (`clientes` `c` join `ventidades` `v` on((`c`.`identidades` = `v`.`IdEntidad`)));

--
-- Definition of view `ventidades`
--

DROP TABLE IF EXISTS `ventidades`;
DROP VIEW IF EXISTS `ventidades`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ventidades` AS select `entidades`.`id` AS `IdEntidad`,`entidades`.`telefono` AS `telefono`,`entidades`.`direccion` AS `direccion`,`entidades`.`correo` AS `correo`,`entidades`.`espersonanatural` AS `espersonanatural`,`entidades`.`RTN` AS `rtn`,`entidades`.`entidadnombre` AS `entidadnombre`,`entidades`.`identificacion` AS `identificacion`,`entidades`.`tipoidentidad` AS `tipoidentidad`,`entidades`.`telefono2` AS `telefono2` from `entidades`;

--
-- Definition of view `vproductos`
--

DROP TABLE IF EXISTS `vproductos`;
DROP VIEW IF EXISTS `vproductos`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vproductos` AS select `productos`.`id` AS `idproducto`,`productos`.`codigo` AS `codigo`,`productos`.`descripcion` AS `descripcion`,`productos`.`precioventa` AS `precioventa`,`productos`.`usu` AS `usuario`,`productos`.`fmodif` AS `fmodifica` from `productos`;

--
-- Definition of view `vproveedores`
--

DROP TABLE IF EXISTS `vproveedores`;
DROP VIEW IF EXISTS `vproveedores`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vproveedores` AS select `p`.`id` AS `idproveedor`,`p`.`identidades` AS `identidades`,`p`.`idcontacto` AS `idcontacto`,`p`.`estado` AS `estado`,`v`.`RazonSocial` AS `descripcion` from (`proveedores` `p` join `personasjuridicas` `v` on((`p`.`identidades` = `v`.`id`)));

--
-- Definition of view `vsucursal`
--

DROP TABLE IF EXISTS `vsucursal`;
DROP VIEW IF EXISTS `vsucursal`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vsucursal` AS select `p`.`id` AS `idsucursal`,`p`.`identidades` AS `identidades`,`p`.`idusuario` AS `idusuario`,`p`.`idmunicipio` AS `idmunicipio`,`p`.`estado` AS `estado`,`p`.`numerofactura` AS `numerofactura`,`v`.`RazonSocial` AS `descripcion` from (`sucursales` `p` join `personasjuridicas` `v` on((`p`.`identidades` = `v`.`id`)));



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
