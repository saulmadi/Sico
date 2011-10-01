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
-- Temporary table structure for view `vmovimientoscuentacorriente`
--
DROP TABLE IF EXISTS `vmovimientoscuentacorriente`;
DROP VIEW IF EXISTS `vmovimientoscuentacorriente`;
CREATE TABLE `vmovimientoscuentacorriente` (
  `id` int(11),
  `idcuentacorriente` int(11),
  `idtipomovimiento` int(11),
  `monto` decimal(18,2),
  `descripcion` varchar(200),
  `fechavencimiento` date,
  `fecha` date,
  `usu` int(11),
  `fmodif` datetime,
  `idrubro` int(11),
  `codigo` varchar(70),
  `identidaddeudora` int(11),
  `identidadbeneficiaria` int(11),
  `estado` varchar(5),
  `fechacreacion` date,
  `idsucursales` int(11),
  `habilitado` int(1) unsigned,
  `debito` decimal(18,2),
  `credito` decimal(18,2)
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `clientes`
--

/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES  (1,8,1,'2011-08-20 13:14:41',NULL),
 (2,1,1,'2011-10-01 08:13:26',NULL),
 (3,9,1,'2011-09-27 22:52:45',NULL),
 (4,10,1,'2011-09-30 22:45:48',NULL);
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `compras`
--

/*!40000 ALTER TABLE `compras` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `controlcaja`
--

/*!40000 ALTER TABLE `controlcaja` DISABLE KEYS */;
INSERT INTO `controlcaja` VALUES  (1,4,'12342.00','2011-08-20',1,2,1,'2011-08-20 12:44:03','Apertura de caja para el usuario Saúl Antonio Mayorquin Díaz'),
 (2,2,'3.00','2011-08-20',1,2,1,'2011-08-20 13:12:09','Pago en efectivo en factura'),
 (3,3,'9.00','2011-08-20',1,2,1,'2011-08-20 13:15:06','Pago con tarjeta de crédito en factura'),
 (4,2,'6.00','2011-08-20',1,2,1,'2011-08-20 13:16:50','Pago en efectivo en factura'),
 (5,6,'21.00','2011-08-20',1,2,1,'2011-08-20 13:18:16','Se retiro efectivo para el usuario Saúl Antonio Mayorquin Díaz'),
 (6,5,'12339.00','2011-08-20',1,2,1,'2011-08-20 13:20:13','Cierre de caja para el usuario Saúl Antonio Mayorquin Díaz'),
 (7,4,'435.00','2011-08-24',1,1,1,'2011-08-24 21:40:59','Apertura de caja para el usuario Saúl Antonio Mayorquin Díaz'),
 (8,6,'452345.00','2011-08-24',1,1,1,'2011-08-24 21:43:50','Se retiro efectivo para el usuario Saúl Antonio Mayorquin Díaz'),
 (9,4,'332.00','2011-09-08',1,1,1,'2011-09-08 18:27:35','Apertura de caja para el usuario Saúl Antonio Mayorquin Díaz'),
 (10,4,'123312.00','2011-09-26',1,1,1,'2011-09-26 18:32:50','Apertura de caja para el usuario Saúl Antonio Mayorquin Díaz'),
 (36,1,'9.00','2011-09-26',1,1,1,'2011-09-26 21:00:12','Pago de factura al crédito para número de cliente 2'),
 (39,1,'2.97','2011-09-26',1,1,1,'2011-09-26 22:55:39','Pago de factura al crédito para número de cliente 2'),
 (40,4,'133.00','2011-09-27',1,1,1,'2011-09-27 20:41:00','Apertura de caja para el usuario Saúl Antonio Mayorquin Díaz'),
 (41,4,'123132.00','2011-09-28',1,1,1,'2011-09-28 20:48:45','Apertura de caja para el usuario Saúl Antonio Mayorquin Díaz'),
 (42,3,'30.00','2011-09-28',1,1,1,'2011-09-28 20:49:12','Pago con tarjeta de crédito en factura'),
 (43,11,'1.00','2011-09-28',1,1,1,'2011-09-28 21:29:14','Abono a cuenta  a cliente Saúl Antonio Mayorquin Díaz'),
 (44,12,'1.00','2011-09-28',1,1,1,'2011-09-28 21:29:14','Abono a cuenta  a cliente Saúl Antonio Mayorquin Díaz'),
 (45,4,'4654.00','2011-09-30',1,1,1,'2011-09-30 21:10:35','Apertura de caja para el usuario Saúl Antonio Mayorquin Díaz'),
 (47,1,'60.00','2011-09-30',1,1,1,'2011-09-30 22:39:52','Pago de factura al crédito para el cliente Javier Eduardo Atala'),
 (48,1,'60.00','2011-09-30',1,1,1,'2011-09-30 22:43:32','Pago de factura al crédito para el cliente Javier Eduardo Atala'),
 (49,11,'10.00','2011-09-30',1,1,1,'2011-09-30 22:44:28','Abono a cuenta  a cliente Javier Eduardo Atala');
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
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `controlcajafactura`
--

/*!40000 ALTER TABLE `controlcajafactura` DISABLE KEYS */;
INSERT INTO `controlcajafactura` VALUES  (1,1,2,1,'2011-08-20 13:12:09'),
 (2,2,3,1,'2011-08-20 13:15:06'),
 (3,3,4,1,'2011-08-20 13:16:50'),
 (29,9,36,1,'2011-09-26 21:00:12'),
 (32,10,39,1,'2011-09-26 22:55:39'),
 (33,12,42,1,'2011-09-28 20:49:12'),
 (35,13,47,1,'2011-09-30 22:39:55'),
 (36,13,48,1,'2011-09-30 22:43:32');
/*!40000 ALTER TABLE `controlcajafactura` ENABLE KEYS */;


--
-- Definition of table `controlcajamoviemiento`
--

DROP TABLE IF EXISTS `controlcajamoviemiento`;
CREATE TABLE `controlcajamoviemiento` (
  `id` int(11) NOT NULL,
  `idmovimientoscuentacorriente` int(11) NOT NULL,
  `idcontrolcaja` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_controlcajamoviemiento_movimientoscuentacorriente1` (`idmovimientoscuentacorriente`),
  KEY `fk_controlcaja_controlmovimientos` (`idcontrolcaja`),
  CONSTRAINT `fk_controlcajamoviemiento_movimientoscuentacorriente1` FOREIGN KEY (`idmovimientoscuentacorriente`) REFERENCES `movimientoscuentacorriente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_controlcaja_controlmovimientos` FOREIGN KEY (`idcontrolcaja`) REFERENCES `controlcaja` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `controlcajamoviemiento`
--

/*!40000 ALTER TABLE `controlcajamoviemiento` DISABLE KEYS */;
/*!40000 ALTER TABLE `controlcajamoviemiento` ENABLE KEYS */;


--
-- Definition of table `correlativocodigo`
--

DROP TABLE IF EXISTS `correlativocodigo`;
CREATE TABLE `correlativocodigo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(4) NOT NULL,
  `correlativo` mediumtext NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `correlativocodigo`
--

/*!40000 ALTER TABLE `correlativocodigo` DISABLE KEYS */;
INSERT INTO `correlativocodigo` VALUES  (2,'OC','1'),
 (3,'OR','1'),
 (4,'OS','1'),
 (6,'FE','8'),
 (16,'CC','4');
/*!40000 ALTER TABLE `correlativocodigo` ENABLE KEYS */;


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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cuentacorriente`
--

/*!40000 ALTER TABLE `cuentacorriente` DISABLE KEYS */;
INSERT INTO `cuentacorriente` VALUES  (3,'CC-001-20110926-001-0000003',1,4,'A',1,'2011-09-26',1,'2011-09-26 21:00:31',1),
 (5,'CC-001-20110930-001-0000004',10,4,'A',1,'2011-09-30',1,'2011-09-30 22:40:10',1);
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
INSERT INTO `departamentos` VALUES  (1,'Atlántida',1,1,'2011-08-20 11:18:24'),
 (2,'Colón',1,1,'2011-08-20 11:18:24'),
 (3,'Comayagua',1,1,'2011-08-20 11:18:24'),
 (4,'Copán',1,1,'2011-08-20 11:18:24'),
 (5,'Cortés',1,1,'2011-08-20 11:18:24'),
 (6,'Choluteca',1,1,'2011-08-20 11:18:24'),
 (7,'El Paraíso',1,1,'2011-08-20 11:18:24'),
 (8,'Francisco Morazán',1,1,'2011-08-20 11:18:24'),
 (9,'Gracias a Dios',1,1,'2011-08-20 11:18:24'),
 (10,'Intibucá',1,1,'2011-08-20 11:18:24'),
 (11,'Islas de la Bahía',1,1,'2011-08-20 11:18:24'),
 (12,'La Paz',1,1,'2011-08-20 11:18:24'),
 (13,'Lempira',1,1,'2011-08-20 11:18:24'),
 (14,'Ocotepeque',1,1,'2011-08-20 11:18:24'),
 (15,'Olancho',1,1,'2011-08-20 11:18:24'),
 (16,'Santa Bárbara',1,1,'2011-08-20 11:18:24'),
 (17,'Valle',1,1,'2011-08-20 11:18:24'),
 (18,'Yoro',1,1,'2011-08-20 11:18:24');
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detallecompras`
--

/*!40000 ALTER TABLE `detallecompras` DISABLE KEYS */;
/*!40000 ALTER TABLE `detallecompras` ENABLE KEYS */;


--
-- Definition of trigger `DetalleCompra_trigg`
--

DROP TRIGGER /*!50030 IF EXISTS */ `DetalleCompra_trigg`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `DetalleCompra_trigg` AFTER INSERT ON `detallecompras` FOR EACH ROW BEGIN


    


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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detalleorden`
--

/*!40000 ALTER TABLE `detalleorden` DISABLE KEYS */;
INSERT INTO `detalleorden` VALUES  (1,2,1,8,1,'2011-09-05 20:03:00');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detallerequisicion`
--

/*!40000 ALTER TABLE `detallerequisicion` DISABLE KEYS */;
INSERT INTO `detallerequisicion` VALUES  (1,1,1,41,'2011-09-05 20:33:29',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detallesalida`
--

/*!40000 ALTER TABLE `detallesalida` DISABLE KEYS */;
INSERT INTO `detallesalida` VALUES  (1,1,1,4,'2011-09-05 20:33:58',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `entidades`
--

/*!40000 ALTER TABLE `entidades` DISABLE KEYS */;
INSERT INTO `entidades` VALUES  (1,27729729,'Col. Piedras Bonitas','saulmadi@gmail.com',1,'08011988125246',1,'2011-10-01','Saúl Antonio Mayorquin Díaz&','0801-1988-12524','I',96330670),
 (2,27724816,'Col. INVA, bajos del hotel morales','colmotos@yahoo.com',0,NULL,1,'2011-08-20','Colmotos Principal','4e46eed3-4671-44fc-80bc-ffa407c384c6','J',NULL),
 (3,NULL,'Bo Cabañas, edificio roble, Comayagua,Comayagua','colmotos.g@gmail.com',1,NULL,1,'2011-08-20','Gustavo Adolfo Carvajal Calvo&','2403200602445','R',33517473),
 (4,NULL,NULL,'colmotos_@hotmail.com',1,'08018009213851',1,'2011-08-20','Luis Fernando Carvajal Castro&','0208200500330','R',NULL),
 (5,22214131,NULL,'ventas@intermotos.net',1,NULL,1,'2011-08-20','Manuel Paz@','44a406d3-5f93-4dcf-afd2-c4df1bd6b9af','N',98923713),
 (6,22214131,NULL,'ventas@intermotos.net',0,NULL,1,'2011-08-20','Intermotos','ee165b7d-eaf3-4972-9012-d16e9122fa36','J',22214131),
 (7,27723621,'Blv Cuarto Centenario,  bajos del hotel emperador',NULL,0,NULL,1,'2011-08-20','Colmotos Sucursal','536d4254-864c-4292-b262-6526a6852701','J',27723621),
 (8,NULL,NULL,NULL,1,NULL,1,'2011-08-20','Carlos Bogran@','387adf61-0154-4340-93ac-014d46047ab5','N',NULL),
 (9,NULL,NULL,NULL,1,NULL,1,'2011-09-27','carlos villa corta maldonado&','0301-1988-00001','I',NULL),
 (10,NULL,NULL,NULL,1,NULL,1,'2011-09-30','Javier Eduardo Atala%','0801-1122-12112','I',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturadetalle`
--

/*!40000 ALTER TABLE `facturadetalle` DISABLE KEYS */;
INSERT INTO `facturadetalle` VALUES  (1,1,1,1,'3.0000',1,'2011-08-20 13:12:09'),
 (2,2,1,3,'3.0000',1,'2011-08-20 13:15:06'),
 (3,3,1,2,'3.0000',1,'2011-08-20 13:16:50'),
 (4,4,1,1,'3.0000',1,'2011-08-24 21:49:17'),
 (5,6,1,4,'3.0000',1,'2011-09-05 20:34:34'),
 (6,7,1,2,'3.0000',1,'2011-09-08 18:28:02'),
 (7,8,1,1,'3.0000',1,'2011-09-16 23:10:37'),
 (8,9,1,3,'3.0000',1,'2011-09-26 21:01:31'),
 (9,10,1,1,'3.0000',1,'2011-09-26 22:55:50'),
 (10,11,1,1,'3.0000',1,'2011-09-27 20:56:59'),
 (11,12,1,10,'3.0000',1,'2011-09-28 20:49:12'),
 (12,13,1,20,'3.0000',1,'2011-09-30 22:43:37');
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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturaencabezado`
--

/*!40000 ALTER TABLE `facturaencabezado` DISABLE KEYS */;
INSERT INTO `facturaencabezado` VALUES  (1,'FE-002-20110820-001-0000001',2,'3124',NULL,'2011-08-20',1,'3.0000','0.3600','3.0000','0.0000',0,0,'F','P',1,'2011-08-20',1,1,NULL),
 (2,'FE-002-20110820-001-0000002',2,'3125',1,'2011-08-20',1,'9.0000','1.0800','9.0000','0.0000',0,0,'F','P',1,'2011-08-20',1,1,NULL),
 (3,'FE-002-20110820-001-0000003',2,'3126',NULL,'2011-08-20',1,'6.0000','0.7200','6.0000','0.0000',0,0,'F','P',1,'2011-08-20',1,1,NULL),
 (4,'FE-001-20110824-001-0000004',1,'b38ee6bd-0c60-40e0-9b06-745ff851053e',NULL,'2011-08-24',1,'3.0000','0.3600','3.0000','0.0000',0,0,'P','P',1,'2011-08-24',1,1,NULL),
 (6,'FE-001-20110905-001-0000001',1,'f493820e-e8ea-4de7-9ea8-6c52b0ad5450',NULL,'2011-09-05',1,'12.0000','1.4400','12.0000','0.0000',0,0,'P','P',1,'2011-09-05',1,NULL,NULL),
 (7,'FE-001-20110908-001-0000002',1,'1d982ba2-6e95-4a28-85d6-abcba7f9bdef',NULL,'2011-09-08',1,'6.0000','0.7200','6.0000','0.0000',0,0,'P','P',1,'2011-09-08',1,1,NULL),
 (8,'FE-001-20110916-001-0000003',1,'1f6f7848-f44d-4bbb-a275-eb7691fe4101',NULL,'2011-09-16',1,'3.0000','0.3600','3.0000','0.0000',0,0,'P','P',1,'2011-09-16',1,NULL,NULL),
 (9,'FE-001-20110926-001-0000004',1,'143',2,'2011-09-26',2,'9.0000','1.0800','9.0000','0.0000',0,0,'F','P',1,'2011-09-26',1,1,NULL),
 (10,'FE-001-20110926-001-0000005',1,'144',2,'2011-09-26',2,'2.9700','0.3564','3.0000','0.0300',0,0,'F','P',1,'2011-09-26',1,1,NULL),
 (11,'FE-001-20110926-001-0000006',1,'ae349a91-49a1-423d-bed9-df032699308d',3,'2011-09-27',2,'2.5608','0.0000','3.0000','0.0900',3,1,'P','P',1,'2011-09-27',1,NULL,NULL),
 (12,'FE-001-20110928-001-0000007',1,'145',NULL,'2011-09-28',1,'30.0000','3.6000','30.0000','0.0000',0,0,'F','P',1,'2011-09-28',1,1,NULL),
 (13,'FE-001-20110930-001-0000008',1,'146',4,'2011-09-30',2,'60.0000','7.2000','60.0000','0.0000',0,0,'F','P',1,'2011-09-30',1,1,NULL);
/*!40000 ALTER TABLE `facturaencabezado` ENABLE KEYS */;


--
-- Definition of table `facturatransaccionestarjetacredito`
--

DROP TABLE IF EXISTS `facturatransaccionestarjetacredito`;
CREATE TABLE `facturatransaccionestarjetacredito` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idfacturaencabezado` int(11) NOT NULL,
  `idtransaccionestarjetacredito` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_facturatransaccionestarjetacredito_facturaencabezado1` (`idfacturaencabezado`),
  KEY `fk_facturatransaccionestarjetacredito_transaccionestarjetacre1` (`idtransaccionestarjetacredito`),
  CONSTRAINT `fk_facturatransaccionestarjetacredito_facturaencabezado1` FOREIGN KEY (`idfacturaencabezado`) REFERENCES `facturaencabezado` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_facturatransaccionestarjetacredito_transaccionestarjetacre1` FOREIGN KEY (`idtransaccionestarjetacredito`) REFERENCES `transaccionestarjetacredito` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facturatransaccionestarjetacredito`
--

/*!40000 ALTER TABLE `facturatransaccionestarjetacredito` DISABLE KEYS */;
INSERT INTO `facturatransaccionestarjetacredito` VALUES  (1,12,2);
/*!40000 ALTER TABLE `facturatransaccionestarjetacredito` ENABLE KEYS */;


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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventario`
--

/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
INSERT INTO `inventario` VALUES  (1,1,2,9994,1,'2011-08-20 13:16:50'),
 (2,1,1,200,1,'2011-09-30 22:43:37');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `marcas`
--

/*!40000 ALTER TABLE `marcas` DISABLE KEYS */;
INSERT INTO `marcas` VALUES  (1,'KMF',1,1,'2011-08-20 00:00:00');
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `modelos`
--

/*!40000 ALTER TABLE `modelos` DISABLE KEYS */;
INSERT INTO `modelos` VALUES  (1,'ZX-200',1,1,1,'2011-08-20 00:00:00'),
 (2,'KB-150',1,1,1,'2011-08-20 00:00:00'),
 (3,'KS-150',1,1,1,'2011-08-20 00:00:00'),
 (4,'ZM-200',1,1,1,'2011-08-20 00:00:00'),
 (5,'BW-150',1,1,1,'2011-08-20 00:00:00'),
 (6,'KB-150 DUAL SPORT',1,1,1,'2011-08-20 00:00:00'),
 (7,'KS-150 DUAL SPORT',1,1,1,'2011-08-20 00:00:00');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `motocicletas`
--

/*!40000 ALTER TABLE `motocicletas` DISABLE KEYS */;
INSERT INTO `motocicletas` VALUES  (1,'54352erfwdfsdf345','effssfs322424',1,5,1,1,342,3424,'52345.00','5345.00','2011-08-20',1,'2011-08-20 18:20:06','I',424,1);
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
  KEY `Motocicletas_Imagenes` (`id`),
  KEY `Modelo_Imagines` (`id`),
  CONSTRAINT `Modelo_Imagines` FOREIGN KEY (`id`) REFERENCES `modelos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `motocicletasimagenes`
--

/*!40000 ALTER TABLE `motocicletasimagenes` DISABLE KEYS */;
INSERT INTO `motocicletasimagenes` VALUES  (5,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F7FA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A4A09C726BC47C6DF1275A6F114B63E1DB90905BFCACEAA1B71EFD7D2A2738C15E45420E6ED13DBF38ACBD67C45A5E836AF3EA1771C4AA33B739623D877AF077F1DF8BF51B17D2AF2E76890E5E751B5F6FA0C567259E64325C4D2DC376F39CBE3E99AE3AB985286DAB3AE9606A4F7D0F55BFF008BB6314A834DD3EE2F6265C97CF9783E98350C7F1794CCAB2E893A464F2FE68381F4AF3A180300714135E7BCD2ADF448EE596D3B6AD9EF9A178974CF1142F269F3EF2870C8C30C3F0AB971AA595AC9E54D731ACB8C88F77CC7E82BE7CB0D62E3C3BA826A9671F992A02BE5E480F9F5C5747E09F13E7C46F26B76D6C24B9DF299DD8B18C0E428CF4FC2BD3C3E361562AFA33CFAF849D393B6A8F698E412C6AEB9C30C8C8C1A7572C3E22785F784FED35C9381F2375FCABA5B7B88AEA059A091648D864329C835D6A49ECCE5716B74494514531051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400550D46EAEE0091D95A79F33F4DC76A8FA9ABF58DE29D7E1F0DE8173A8CCD828B88F23AB1E82803CABE28788BC490DD59DAED934FCE72F6D3121B3EB5C3E8F6B25BC0ED36E32C8C5999BA93EB53ADD5EEB9A849AB6A32BBCB29E158F0A2AE1AF031D8AE76E11D8F730586E44A72DC28A4A0D79A7A026F5C9F9871D694B28EA4014EF0CF86A0F126A57F0C92CF16CE55A36E2AEEA5E0DB4B5BB5B57BDB9BB9BAF9108CB0FA9ED5D8B0B7B6A723C55AFA1969730B92038C838351BCD68F70A8EC8655FBB9EB5D84DA558C5A525B5EF87E78A14FF96A9F338F7E2974BD0BC1902B868AE6FC4AB82550BB467F0E86B58E0D5F76652C5B4B639665575C1008239AF4AF843A94F3E9F7FA6CADBA3B39008CE3B3735CEAFC378354BA61A3EBED0C44716F70BFBC5FA8F4AF47F04F8517C27A2FD91E449EE598B4B32AE37F3C66BBB05859D19B6DE871E2F130AD1492D4E9A8A28AF48F3C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002B87F8AFA75C6A5E05BA8EDA232346CB2B01D957926BB8AF28F8D5ACEA1A7E9D65676B398A0B92DE6ED38240C719A89B4A2DB2A09B92B1E63A35DB5CD9AFC842AF00FAD69554D38C66CE3F2C8231CE3D6ADD7CAD569CDD91F4D4935057621200C9E82991C57BA8E22D3AD6599DF8076903F3A73B054249C002BD07E19DCCF73A1CBE68FDDA49888E31C56B87A6A776FA19626AB8249752AE81A3BF82FC37717974375EC9D141E727802BA5F0DE92D6767F6ABA01AFAE3E799CF5C9EC3DAAA6B84DE78934CB21CAC6DE6C8BEA3A574E06303B57A2F4479BBB119430208041EA0D73D2DB41E1ED405D41105B7B870B22A8E8C7BD7455475883CFD2AE100F9B612A40E87D6A53195759D212F61FB45B9315E45F3C72270723D7D6B73C35AC0D67488E660566426391588CEE1C13F8D6668B38B8D2603B8B15508C4F524706AAF864C761E2ED56D4E41BADB2C6A3A000735D7869B52E5673D78E9CC76D45145771CA1451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450015C4FC47F0745E28D1C4BF68F26E2D159E366385F7CFE55DB551D66DBED9A2DE5B6C67F36164DA8704E476CD2924D598D369DD1F25E991DEDEEB634AD3D8BCDBF6B321CA8C77CFA5741AF5B6A3E179161B9BA864246727AD65787B41D48F8F7ECBA6CCF6AF13B0639059141E41ED9AF7ABDF09E95ADDB42BAB5AADD3460619B824FAF15E5D6852E649AD0F4294EA28B69EA7947863C31AB78B42DC4CDE4596793FDE1ED5ED5A56996DA45845676A81238C6062A7B5B586CADD20B78D6389061540E82A6ACF45A2564536DEECE60391F11595F1B0D88DB9F5DC6BA7AE3FC5C92E99A958EBD0A33A42DB2703FB9FFEB35B91EB96CF00999240A57702A85863EA2B47194926919F324ECCD4A64C4089C9E062B22DBC59A2DE4A6286F51A41D53F8BF2AA5E25F1469D63A64B1B5C059651B173C7278A8E496D62F9916BC28B2AE97279ADB89B890823D377151C25BFE167596CC6CFB1C9BF1EB918A9747D4F4F8747876CEAC1501765E4671CF34FF07C1FDA1ACEA1AD3440C2C4476B2E7AA8186FD6BA2845FB4B98D56940EDA8A4A5AF40E30A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800ACFD756E1B41BF5B40C6E0C0FE5853825B1C62B4291BEE9FA500786FC2AD264517BA95EA117924A6370DC9520E0F35EAC060015C8F82C6CB5BD46186FB74C71FF0002AEBABC8A9FC491E947E08851451500473C115CC0F0CC81E3718653DEB9C834DD67C36EE348912E6C0FFCBA4E7EEFD0D74F9A2B48549436265052DCE4E3BC0972F35B783523BD3D6578C0527D7239ACCBDD2B5097543A8EB165A55C6F188EDDDF013E9C735DFD715E3CB681EE349B8B98BCC8D2E15304F1962056EB13393B193A314AE5A1A5EA5A85A8B3FB2D8E9D60472B6DC971DC74E2BA5F095F5BB5B4DA64512C5259304745E983D0FE54F8A348A254450AAA3000ED58DA0DE4769E3BD46C84797BB4594BFA6D18AAA156539FBCC9AB4E318E877345145769CC145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001475A2A26BA812411BCD1AB9E8A5803F95007053C6344F195C5B98C456D7ABE64183C6E1F7BF9D7471BEF506B8FF00881A8C9AA6A6BA35AA79325A9595EEB1F329EA02FF005A9746F112EF8ECAEDB6DC80003D9FDEB8713879C7F7A968CEBA15E32FDDB7AA3ADA298922B8E0D3EB8D1D0CE5B59B6D7EDB515D4ACA51736F19C9B41C647B1F5A9F4DF196977CDE54F21B3B91F7A2B81B39F627AD7459AC19AC2DB5BBB9E0BFD2008D07CB3BA8CB7D0F5AB4D3DC977E86DA4A92286475653D0839AE5BE2002DA2DA04237FDBA1C7FDF55237816C11B75ADD5EC041CF13B11F966AC41E13805C472DD5D4F72233B95646E01F5A71B277B89DDAB1BB1822350C7270326B9DD12D9EEBE255E5E46A0C56D0F96EDBBA12011C55CD7B5FB7D1A158FF00D65DCC76430AFDE663D2B47C1BA1CDA569F25C5EA8FB7DDB79931073F41F80E2BA30B077E631AF256B1D28A28A2BB8E50A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28AA7AA5F47A6E9B3DD4922279684A973804F61401CFEB3E2433DE49A4E9849947134C3A27B0F7ACA6D0ED6501A66965B80062776CB8FC6AA78695A6B79AFE54549AEA4323A8EC4D6ED75C6092B58E5949B77385B5B496DBC55756B7B7724EB26D31C921CB11E99ADEB8D0A286FA3D42D6353320C156FE21FE359BE27D35AF75BB01048619B0583AF5C8AE82EAF0699A6AC939DF22A81FEF35128A943925B0A3271973ADCCAD67C6FA7687A79B8BA1224DD04246189FF0ACAD0BE29AEA68F2358BB429DE33B9BF1146A51AEA963753EA5024B12C65802BC29AA5A7E996361221B1B6024907DC5E9F5AE386594D5EECEA9E613696875D67E3FD0AED0B79ED185FBC5D7183EF57078CFC3A47FC8560FCCD73A86E34AB8B7FECE8ED6396F1B6CD14F16E407FBD8F5AE86CBC4563688D06B3A727DA54FDEB7B4DC8C3D7A5632C0A4F7358E2F996C3478C74B99CC76265BD970484B74DC4D543A8F8AF59574D2746366071E6DE9D847B85EF5B5178C7C3F09578ACEE109E856CC83FCAA47F881A2C48CCEB78AA3A936CD4470915BEA37886F62BE81E0382CEE63D4F5799AFF541CF98FF00750FFB23B57655C64FE2BBCD413ED1A422C76A07DF9E3397FA0ED51D978BB5CF2C2DCE89E63027F789285047D0F35D0A9B4B4460E69BD59DBD15C35C7C40B8B797649A40001C1CDCA8207AE2B5B4BF1BE87AB5FF00D860BB0B738FB8E3193E80F7A1A6B71A927B1D1D140A290C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A002BCE3C6B7F1EA7AC7F64CB024B0428240EB21E1F3D081C7E75D178CBC48340D3552289A5BBB92638514E307D49ED5E65A2593417CD1C92BCB34ADE6C8EE72493EF5BD085E577B18569D9591DD584220B38D40C71D2ACD22A8540A3A014B5BB31472FE244BD8758D3EFEDD4BC10AB798BEBD2A2D4EF575A92CA3870612DB9813821C76AEA656848D92153938C1EF55E3D26CA1B8F3D2050FEB8A04D32AEABA709BC3F7169120DCF1E31EA6A2D174F16366B7170A04BB7A1FE1ADBAE53C51AB4B1DEC3636F22AB05F35C67EF0E98A2FA832ADE5C49A86BF6B1C60811C9E61FA74AED40E07D2B82B0736CC6EA4917CD639EBF747A569FFC240ED8FDFC7C7A55B8DC952B1D5554BCB2176D1EF72A8A725477AC35D6E756FF005A87D891505A7881E7BC512B064DED900FA5271683991D25D5DC1A740A5C8519C2A8EF5902E4DB3CF7DA85CFC92711C2A7EE8FF1AC8D735386E358801622244270DEB52699A25E6BD7F05D4CAD0D8C0E1D14F5723BFD2B0AD5614A1CD27AF636A34E556568EC5B6D4D26024874669D0FF1941C8FC6B3AE9F41D62558AE206B0BD4E6391414287EBDEBD25224450A14003DAB2BC43A15B6B3A5CD0B46A26DA4C7201CA9F6AF3639849BF7A2AC77BC1C52F75BB8FF00097882EE4B86D2353659268D3743700E04ABEFEF5D9578259EA575E1F8F4CBCD5943C967704360F3D31CFE15EE3A7DFDB6A76515DDA4C92C322865743915D938A4EEB639E12BAD772D514515058514514005145140051451400514514005145140051451400514514005145140051451400552D5B54B7D1B4C9EFEE8E22857271576BCD7E20DEC97DABDA68EA7FD1D079D2953D4F4DA455462E4EC8994B955CE78DC4FAB6A771ACDD97065FF0055139CF949E956BC349F68BE9646E40738CF7150DD32C36721E985C0AD3F08C2E962AD281BF6F38F5AF41C541591C3CDCCEECE968A283D0D646860696B15EEB57B76C03152117DB1D6B7EB03C2D2ACB05D955DA45C383F9D6FD0B600CE2B1BC37A2697E25D47599754B08EE0C3702389DF3F776838FCEB608C823D6A3F053C1677BA8E9E5FFD21A4F34023EF2E3AD655AF634A56B9A8BE09F0E2A851A54200EDCD03C11E1B5C91A54033CF435D05707E3AF88116831B5869A567D4DC7AE562F7358462E4ECB7369CE308B94B6450F16FFC211E162A65D2A19EF987C902139C7BFA578F5BF88CDB789C4EC822B0776222539D99F7A8352BB9EE2E5E7BA9DA6BA94E64918F35CEDEBBEFF2D172CFC035DEE87B185DBD4F3A18975E768AD0F74D2F4AB2BF9E0D5AFB6919C4087BFBFBD7A0C4AAB1A85181E82B8282349F4EF0FD811B66F292518E3850335DF2FCA8A338AF99AB525526E7267D2429C69C14623A8A2A28EE619A49238E45678CE1C03D0D40CF22F8956B241AF411ABFF00A34DFBD2A47F1F4FE54EF87FE2B1E16D5BECB72656D3EE885001C8898F7C52FC4EBC12F89ECED147DC8B793F8D728EBBD48E9EFE95F5580A2AB60D296E7CA66188787C6F3476EA7D4CAC19430E846452D79AFC2AF153DFD9C9A2DF4A5AEAD7FD5B39FBC9DBEA6BD2AB825171938B3D784D4E2A51D985145152505145140051451400514514005145140051451400514514005145140051451400D77088CE7A2824D78DB4F0EA1ABDFEA7006F2EE652577F518E3FA5751F10B59BC8A4834AB192581E4432B4D19C7038DB5C7E968B158A46A724673EB9CD7561A3AF31CB889AF848F5BF9B4E68C121988031F5AEBF418F669E3E5E6B8CD51BFD32C232787948C7E15DDE96BB6C53DC5744FA98C0B9487EE9FA52D21E87E9591A1CA78119BEC77EAC4E45E4BD7FDEAEB2B90F0296586FD5FEF1BB908FA6EAEBE8E81D42B9FD1351B5D37C6FA9DCEA1702148E0C867E06DC8E6BA0240049E00AE335CD2A0D625BDBB405A2480A6EEC5B39E3D6A651E6D071972EA6C78CFE25D945A5FD9FC3F7915C5E4C76964E7CA1EB5E3EECC9E64F348D24CE773BB1C96354ECEE62DACE4FCD923F0A86E2E5A66C0FBBE95E961E8C292E65AB678D8AAF57113E47A244523991CB1E4935DAF843C0136A1730EA5A9218EDD08748C8E5CF63F4AE2E099ADE78E650098D8300464715D349F1AEF2DE2308D3E332AF0181E3F2AF37349D7E550A6B47BB3D5CAA14799CEA3D5743D3EDE2FB578CD36A8096316DC7FBC2A1F1A5F5DC1AB68905BCC63492E54C801C6E19E9591F0AF55BAF114BA96B377B0493155DA9C00071563C707FE2B3F0EA92705FD3BE6BE7E31E59DA5D0F7A72E68DD1E84A7E51F4AE6FC3DFF21ED77FEBE07FE822BA45FBA3E95CCE9F7705AEA1AE4C5447E5CB9663DCEDACD6C5DB53CD3C6F70B77E349C0E3C81B0FD6B229935DFF696B77B7C460CD21269F5F7181A7ECF0F189F079954F69899489AC3519F44D5AD756B6389206F9B8CE54F5FD2BE94D2B518756D2EDEFADCE6299038CF519F5AF998804107906BD2BE0F6B4626BBD0A79A30AA7CCB7527E66CF503E95CB9851DAA2F99DD94E237A32F91EB7451457947B8145145001451450014514500145145001451450014514500145145001451450078EEB1349278EB564989F91944433FC38E6A9CF6477F9B6F218A4CE481D1BEB52FC5CBF1A378A74DB8B60A279213BD71F7C67BD66E99E25B0D4309E608A6C64A3715E85069C35382B2B4C8E57B89B5AB6867887EEBE70E0F06BD22C3FE3C62FF0076BCFE7655D6ADDF20ABAED07DEBBBD2A4F32C94673B78A72D98A2F52E9A43D0D2D07A1ACCD0E0BC3FAA5BD85C5C896E235FF48937062010335D31F10DA4AE23B5592E2423E50AA707F1E95C940BA7196E2EAEE384289DC3BB28E80D6E5978C3C3E0AC16F22A20E010B8155CAECAC47324F534D60BED43FE3EF10407AC4A7E63EC4D66F8C7508B46F0D4E916D5765DA8B497FE3BD26D37A472F9928FE115E5DE20D5F53F125FEF68BCB814FC8AE7B55469C9BD88A95A115AB3097A7B9E694D5A5D2E6620BCDB07A28CD4ABA45BEE0CECECC3FDA22BBD4656D11E54AAD3BDDB33CC88B8CB28CF4E6AFF00867C2169E2CD64C535DC16B6F1E0CD2BB853F419AB0B636CBFF2C94E3FBC33522C10AE76C6A33E82A6AE1E552366C74B1B0A52BA4D9EA5E0F8347F0C5E5DE8B677D04AB1952195C12D9FE7557C5B72ADF10B4050C0A056078CE0E462BCDBC8457F3231E5C83A3AF0735D4FC3C7FEDAD767D1F506696E48FB45BDCB1CB4657F98AF0B1595CE937514AE99EFE0F36A75ED071B347B0493A476CD23300154935F3FEB1E2EB9D49EF2DADDC25BBCA77EDEAD8E39AF665F0DF88B51F32CB529EDA0B323FD740C4BB8F420F4AF23F889E1D4F0EF8B9D23F2D62BA512A220C600E39ACB2FC3AF68BDAA3A330AED527EC998B611958CB1EFD2AE53630046A17A638A757D6C5591F11397349B0A9F4BD424D1B5FB1D4E27D862902BB7FB04F3FA5414D9504913A1EE2A2AC39E0E25D0A8E954535D0FA8AD6E23BAB58AE226DD1C8A194FA83535735E03D43FB43C2364E5367949E575CE76F19AE96BE65AB3B1F649DD5C28A28A06145145001451450014514500145145001451450014514500145148481D4E2803C1FE38807C55A57FD7B3FF00E855E6654370457B27C6BD0669D6CF5D88964B75313A81D01E771AF1C041191D2BD5C1B4E9D8F231C9AA973A1F0CB4B7BA8F9534D232C6B94F9BEE9F6AF4AD0935285DC2BACD1F6078C5793689A926977E27913721E188ED5EB1E1EF13E95340545DC6A49E031C1A2AA516C7464E491D1192EC463102B3F71BF155DDF5297E510C70AE396DDBAAC2EA166C8185CC5B4F7DC2A8DFF89F48B1898CB7B1120642AB024D73D8E9BA3C564B9BABBD4AF20B99CBC51DC3E13A77AB06342BB4A8DBE955576CFAA5D5C459113CACE3F13572BD6C3C1469A563C0C65472AADA622A2AF4502968A2B738EED8514514005145140052E8BE229FC31E2A8B50B6852670855D09C1D87AD31DC229663C0ACC823F3F51F3CE78523DAB0C441548F2773AF09374A7ED3B1F56697AB5AEABA6C17B04D1B472A83F2B6707B8AF0CF8D1731CFE32B35B76F39A3B62AE23F98A9CF435C7586B72D8DBCD6E67995013B5558815AB6F33DAD9342007B8BAFBD2B72C057C954C77D5EA3496A8FB4A783FAC534DBD1A3160BE283CB6462C3B01CD4A355B60C15D8A31EC456FC11C56ECA7CA46C750475AD132E91791986F34B89171C342307F1CD5C3896A5ECE28C2A70BD2B5D49DCE623B88A5FB8E0D52D4E790279511DA4F53ED57B5BF0DC760E2E74E9F746DF36D07A7B573725CB3BF97FC5DC9AF5A967146B5377D19E454C92AD0AAADAA3E83F05EBB25F7852C60D2A28AC113F7724F28C82E38E07726BB0D22EB5096E2E9AFF625B02160DCBB58E07CC48FAD7CCFA0EB375A5AAC7A6DD4B04C5B8DA723EB835D14FAB5FDD1866D77529EED633F737633EDC57893C7538BD533E869E0E725A347D1AB246E70AEAC7D8E69F5F35C7AD5F595EB5E686B716A1BA0F33208F420D7A0D87C57B916D0A5CE8934B380048F138C7D71554F194A7A37614F09563ADAE7A9D15CD695E3BD0356B936D15DF9538EA93294C9F419EB5D20208C8E95D29A7B1CED35B8B45145310514514005145140051451400514514014356D5EDB48B5334E496FE08D7EF39F402BCDFC616DADF8CE188D91934B54FBAE66657C7704038A9F53D41D7C7FA925D2B492431A0B2881CE411C9FCEB4934DD4B524CDE4DF6588FF00CB284FCDFF007D57157AF352E589D54A941C79A479A4FF000F35078A48751F175D344C30D1F9C5B3F514CB2F8553498167AA9962071F3AE0D7ADC5A269966A1DA04675EB2C9CB1FA9ACAD47C73A1E9738B58E4F3EE338F2605DCDF95670C5568BF765A953C3D192F7A3A1C9C1F083254CDA8B0F50AA2BB0D33C11A3E9B69E42DAC6E49CB3B2E589FAD6B6957D3EA16DE7CB6AF6E1BEEABF0D8F71579982F52054D5C455A9A4E4D8E950A54DDE1148E66F7C11A6DCDACB1C4AD1BB03B4863C1AF29D5FE1DEB9A73BC820FB5469C89139E2BDD25BFB58595649954B1C004D58E187A835787C5D4A0EF1D7D48C46169D65692B1F355BCE90298A4051D4F3915605CC27F8C5755F123C13A836B305EE9063097722C4C8C30158F435413E0CF8D5A162F358ABE3801FF00FAD5F4B4734A7282763E6AB64F3537666135E42A3EFE690DF440679AD66F833E3B0A4EEB1381DA5E7F953348F09EA1022A6A1E0CD4E6962243C82E08573EC3154F318F444C7287D5994DA8DBAF56C7D6A23AC5A83F7BF5AF6DF0E695E1EBEB7B7B3BAF064F6F285C33DCDB6403EEDDEBC9BE20F81E4F0F78AAEAE859EDD36E0EE88A2FC89ED531CC252972A562E5954211E66DB3306A909E81A91F513FC29F9D662AA0C61FF5A9323D6BB23524D6A70CA8534F444E5E5B970A4F5AB05574FB37676CB1ACD6BE8ACDB7B48A081D33D6AA497B36A52893715841E3DEB0C462A9D183937A9D1430752BCD452B44B7A747F68BF84139F9B711ED5D3C5FBCD41D9461635D95CD698ED16AF091C2B0C135D0DADC22DFDCC24E18B6457C362DB949BF23EEF08A318A5E66851475A2BCD3D10201041E86B86BD022D45C71B771ED5D8DE5EC5670B3BB738E147535C44CCD7172D27392C4907DFB57A1818BD5BD8F3F1B25A25B92C727D9D84F19C30E4115D068F0C9763EDB74DBD89F907615CE32EE755046D5E4815D1695AA42B10865C211D0F6ADB12A5C9EEAD4CB0CE3CFEF3D0DCA724AF136E462A7D41A89658DFEEBA9FC694BA81CB0FCEBCAB347A974CD16BBB7BF8F65FC0A5C0C24E830E87D735DD7C32F125DDCDC5CE857B319CDB2078A663CB2F4C7BD7964FA85BDBAE5E404FA0EB5D3FC28B69358F16CDA8AB3C705AA71C70E7D2BD5CBE7579ECF63CCC7C69725D6E7BB514515ED9E385145140051451400514514001A439C714B450079BE997D6D3F8AB57B8BE291DE24822D8FC1551D08FAD5BD4FC5DA7D8B08A293ED172C7090C3F3313F415D3EA9E19D1F5970F7F6114B274DFCAB7E639AC6D6B40D3741F0BEA32E93670DACDE51FDE819651DF93CD724F0F797337A1D31AD68F2A5A9E6FA9FFC25BE31BEFB0DADD436769B8ACDE4B6E283D0B74CFB0AECBC33E05D27C371878E2F3AE88F9E7979635A9A15B59D8E8D6EB6A1046503161DC9EA6A96A1AA6A1A84AD61A05BF9F3F469C9C4717B93FD2B99C9C9F2411B28DBDE9B24D77C5165A205472D24EFC24318DCCC7E82B91F174FE2A8BC343589275D2A0691544457320DC70093DABD1BC3BE13B7D181B9B97FB66A327325CC8BCE7D147615B1A8E9B67AB58CB657F6E93DB4A30F1B8C835D54F0D18ABCB5673CEBC9BB4744713E16D261B7D3639E49CDDDC4AA19E6739DDF4AE8B200F415159F836CF4F4F2ACEEEF21800C2C4240557E9919A5B8F0A7DA3E53ABDFA26304295E7F1C560F0B52E6DEDE1639CD7B545BBD5B4ED1EC0F9D7725C2BBECE7CB407927D2BD1146001ED593A3786B4BD0831B2B7C4AFF007E673B9DBEA4D6BD7652A7C91B1CB527CEEE1498A5A2B5204A8E7B582EA231CF12488460875CD4B4500728FF000DBC22F2191B44B72C4E49E7AFE74AFF000E3C2522956D16DF07EBFE35D55029F33EE2E55D8F16F117ECFF00617D3F9DA3DFB5A966259251B947B0AE566F83BE2AB47F2A0B7867897FE5A0902E7F0AFA4E8A89C14F72E3271D8F91EF7C2BAF5A4DB5F4BBCCA3725222471EF5952B4A97064937AC8386CF18AFB30A823900D507D0F499092FA6DA3127249854E7F4AC1E1D773555D9F25A6B570808FB467EB515C7882552775C373CE057D6DFF08EE8BFF40AB2FF00BF0BFE1597A8FC3EF0BEA9389AE74980B818F906D1FA54AC1534EE57D6AA5AD73E5FD067B1D6B5A86DB50BD6B485D86E918647FF005ABE8193E17F84B55F0F797A5A4425DA025E44DB8961EB5B963F0EBC2BA7DD2DC41A4C2245E9B86E1F91AE96DEDA0B588456F124518E8A8B815BC69C62AC918B9C9BBB67CB9ADFC3CF126853B1934F926476C2BC037EE03BE074ACA9341D66389A57D2AF111796668480057D7B8CD3248A395192445646182A4641A87878BD8B559A3E37732C2B972EA3DF8ABB0E91ADDCDBA4F0E9D792C2E3E5748D981FCABEAE7D0F4A7186D36D587A1857FC2ADC30436F12C50C491C6BD1557007E152B0D1EAC7EDD9F21C9A36BC13FE409A83B7FD706AF62F82B797565653E937DA3DE5A485CC825962214FB74AF5EC0F414B81E95AC29463B19CAA4A5B8514515A1014514500145145001451450014514500151CF047730BC3322BC6E0AB2B0C823D2A4A28039DFF0084274811F9682E638F39D893B003DBAF4ADAB2B0B6D3AD96DED2158A25ECA3F535628A9518AD90DC9BDD8514515420A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A3145140051451400628A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00FFD90000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,1,'2011-08-20'),
 (2,0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC00011080120014003012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F56FF84453FE7B47FF007E168FF84453FE7B47FF007E16BA6C7BD18F7AC3D843B1D1F59ABDCE67FE1114FF009ED1FF00DF85A3FE1114FF009ED1FF00DF85AE9B1EF463DE8F610EC1F59ABDCE67FE1114FF009ED1FF00DF85A3FE1114FF009ED1FF00DF85AE9B1EF463DE8F610EC2FACD5EE71F71E1455CFEF57F0894565CBE1F087FD69FFBE457A0C88185675C596EC9A8787815F5AABDCE164D1D547FAC3F9552934F099C48DF9D76375A7373806B22E34F906700D4BC3C05F5AA9DCE724B6DBFC6DFF7D540D111DDFF00EFB35B1358CA3F84D5492CE600FC86A1D0816B1350CB72CBDDFF00EFE1A80CADEB27FDFD357A5B69FF00E799AA8F04C3FE591FCAA254A08D1626A1179C7D64FF00BFA698D738FE297FEFEB53CC32F78CD46D039FE1A8F6702BEB3508DAEDBB197FEFF35466F9CF1FBDFF00BFCD4AF1329C6DA85E275E76D1ECA23FACCC91AF9D067F7BFF007FDAA06D5981FF0096BFF7FDA9191DC636D519EDE4073B4D2F6510FACCCBA7596F497FEFFB530EB0FE937FE04356798DC7F0D30A38FE1A5ECE23FAC54347FB61FD26FF00C087A636B5203D26FF00C087ACFC30FE1A4209EAB4D5380FEB150BE75C907F0CDFF812F4D3AF483F866FFC097ACF2A7FBB4D287FBB4F9203F6F50D13E2071FC337FE04BD37FE1217FEECDFF812F59AD19C7DDA8F69FEED572405EDEA1ADFF09049FDD9BFF025E93FB7E4FEECFF00F812F595823F868E7FBB47B3807B7A86AFF6FC9FDD9FFF00029E8FEDF93D27FF00C0A7FF001AC9EFD2803DA97B380FDBD435FF00B7A4F49FFF00029FFC683AEC9E93FF00E053FF008D657E1484E074A5C901FB7A86AFF6E49E971FF814FF00E347F6EC9E93FF00E053FF008D64EEF6A3F0A39201EDAA1ABFDBD27A4FFF00814FFE347F6ECBFDD9FF00F029FF00C6B2B6FB5183E94B9201EDAA1ADFDBB2FF00767FFC0A7FF1A3FB726FEECFFF00814FFE359601F4A7007D28E480FDB543EB3C0A3028A2BD53C80C0A3028A2800C0A3028A280106334A769A28A622368A36EA2A36B285872B538A5ED50D14517D36DCFF0537FB26D0F58EAF64E7A52919159B88EE66368B66DD63A85F41B03FF002CAB5C71D6B2B55BE36C323158CE2CAE629CDE1EB1C1223159573A259A1E1052C9E29C02848ACFB8D64480B6E1F9D66A0C7CC365D1ED8A92A9540E9B6FBF695A866F144368FB2471CD636A3E2FB617395938AA5063E62FDFDB5B5AAE700553862B7B8CFCB9AE7B56F1241731AE24EF458F8960B788FCE0B53E41F39D2B69907F76A06D320FEED60C9E31C77151AF8C2363F330A1D31A99BADA641FDDA8DB4C873F76A9C3E26B47FBCE2A47D7ECDDB024ACDC194A64874D83FBB51B69D08FE1A9E1BB8A6E55B39A9188FC2B36996A4516B0871F76A3FECF87FBB5A03691EF498A9BB41733CE9D0FF769A74E87FBB5A0714C2452BB1DCCF6D3A2CFDDA69D3A2FEED5E627348734AEC7728FF67C7FDDA63E9F191F76B431415C8A97263BA333FB3A3F4A5FB027A55F2B498A5CCC77451FB027A51F611E95780A4707B51CECA4D14BEC43D28FB10F4ABA1B8C53940EF50EA32B43E8FA28A2BDF3CA0A28A2800A28A2800A28A2800A42D8A5A69C77A01B1B24BB1738AC2D475E16A0F15A97B3A2467E61F9D70DACCA9216E69F2DCC6531977E3668D8800D616A5E3769948311ACBBE8D37138AE7EFD58F00F14FD9DC519DC96FF00C42F2312B9159ADAD5CBA9FDF301552685B6924D523D4834BD9A2F987DC5DCD2C8199CB62AACECF2BE6A529B54E2A3C91CD2E443E62191485008A6E095E29CCECE719A6EF64E28E441CC33CB63D4D2790A3F8A9ECE4D4458D572212931C06CE8F4AAEEAFBB766A30533CD35A4C70BD2B374D16A6CDEB1D7FECC0065CE2B4FF00E12B8CA8FDD8AE2B701D690CCB9C60D66E91A291DC2789A363F740A9BFE1218BDAB878C8233520C54FB1B95CE76675F88FA534EBB17B7E75C7134D2C297B043E63AB7F11A21C0406A36F1320FF009675C9B31CFB54649353EC115CC75A7C52A3FE59D20F14A93F72B91C1A508D49D00723AEFF0084997FB949FF0009229FE0AE4F6B5015AA3D8094CEB47889491F256A69F7A2EFB5702BBB22BB1F0CF39CD44A9234533A0FB3E4F4A78B538ABA002C3E95234781C572CE996A47BA51494B8AF6CE04046681C502834EC303CD2519A63385CD3B12D8F343138AA82E879841352BCE81339155CA4F31206C0C93593A9EA2215214D3AEAF804201AE56FAE99E46C9E28484E443A8EACE73F31FCEB9BBABF67CE4D5ABD707358B3B75AD628CA457B9B8C9358B773706B426C9CD655CAE41A7226266CB3F5CD5092519E2A6B91826A9B75AC99B21E24C8A8D9E9338A43CD4176184F34D269C40A69C6281586335445A9ED51B629AB95A085A98CD4B4C634C0697342BD211405149A1DCB0B2D48B201DEABA8A763352172D0914F7A5214F7AA7823BD26F61DEA18D32D155CD050542AC4E39A93B75A92906D0294EDC75A88E73D680A5B8CD514480AF634D2DCE2811EDEF40525C62B29B1246A5869C6E48E2BB1D2F4DFB28048ACDF0EC470095AEA97E600015C9391A226182054A878AAE80835682855CD73B65A3DBC51494B5EE24730521A5C6682302989887A551B9936E79ABC2B2B525620E2A919333669C89783566176963EB591249E5B1DD4F8AFC2F435466C9AF14A66B9DBD9064F3CD6CDE6A0AD191C572B79386727354912D95AE4E7359937535666933551CE6A892A4A0106B3668F39AD39180AA52F20D4B1A39FBC8F93C5663AE2B7AEA3CE6B2A68F06B291AC4A4149346D35301CD2E4541A22B329A888AB8CB9A89A2340EC546534C2A6AE184FA534C58ED45C2C522A698CB570C55134668E60B15B6D274A9CA1A8C8229DC761A09A52C4521C8E6901CD20B0EF30D3873511A72B6295807E4834EDE6A2279A713915361DC78249A9523763C0351DBC7B9C5749A7DB2F195CD4C9D914B532E2B0924C6456AD8E8A5981615B4902803E51572050A3815C9291AF292595AADAA818AD047DA6ABC4726ACC6BB8D73CA45244E84119A6BCFF00C20D3246D831490C45DB35936523DE4528A6834B5EFB38D3149C52824D349C0A61940EF52D8C94E0550BC6520D3A6B9C03835973CCCC4D4F392D185A96448D8E959A93ED6E6B7A6844D91DEB0B50B530024554664CA257BCB80CA706B16594E4D25C5CB06C1354DE7DC7AD6F1661243DDB351B1E293766A1924C5590453553914E2AD93BA98EBB863150D8D18B72C79E2B365049E95D14969BFB5576D333DAB366B1B9CE946CF14D31B56ECD63E57F0D54687271B4FE5506C9198320D4B1AEE619AD14D3F78CE2836055861682AC57F2548A8DAD41E95A51D93FA55816271D2B3722F94E7DAD2986D71DAB7DECF1DAAAC9060F4A8E60E5315ED87A5577800ADA921F6AACF08AA520B18D2C385E2ABECC56CC907078AA13478ED56992D14C8A4E94F22908AA4891BCE33402694B60522B64D0D017AC87CE2BABD3F802B96B33F30AE9F4F39C5615362A1B9AE08C55888F155B1C54F0F4AF3E4CEAB1721196AB0D27942ABC4719A607333E3D0D62D816632666AD085020AA96F1F9757546E15233D692E727AD5D8DF70AE76190EFEB5B36D2715EF2773CF916676DA84D644B70779E6B4EE4E6235CF4EC4487EB5132E2587989EF513C8369A899B8A8D8F159A914C467C1CD646AD2E623F4AD173C62B2B535CC44FB51196A4C96871B72FF00BC354249769A9EF9F648DCD64CB3E73CD76C19CD245F5BA1D334FCF99D2B144877F5AD6B26C819A72625124109CD5858B8E953000D4AAA3158B6CD944AA621E949B39E95719062A12B8350DB358C4AEF0AB0E40A85EC909FBA2AE919A00ACF98D5451405A05ED4E1020EA055A615090734F98761A51476A6328A918D44C6A1B2922B4A3AD5295326AEC9D6AAC9503284898AAAE957E419AAD22D5A2594A41C5519A2CE6B464155DD722AEE66D19862C531A2CD5B950835012456B16432AB47834CDB8A9A56E6A1EB54D9362ED99F9C5751607815C8DABE2415D6E9843015CF5763486E6C0E5454F03841CD44B80B4D66E0E2BCE91D259794B3616ACC11F43556D23DCDCD69A00B8ACC0B110E2ACA0AAC86AC4669D80EF23939EB5A96937419AE7D58EFEB5A76CC462BD5A7238A48DF63BA1AE72F5B129FAD6D2C99B7EB5CD5FCBB65624D39B1C49BCCE293771588FABA44F824531B5D88B7515CDA94CD863CD666ACFB6DDBE9501D7221FC42B3F52D66292161B874AD61164B6713AB5C913B0CD6509893D6A7D5AE165998A9ACECF039AEA8E866D1AB02EEE6B4E0F900ACAB27E9CD6A839144A438C4BF1BE6AC23567C4F8AB0B2566D9AA45B278A858D34C991D6903566D9A2405B14E193DE9ADF30A4008ACD9A0E2A6A1606A6DDC530827A0A3511030A8CA9F4AB622663D2A416FED4EC17335A3350B419AD76B71503DB9069F28B98C5921C66A94C9815B7728114D615D4DB4E29D85729C82A23CD4A64DDD453095A6491344185539E1DB9C0ABF4C68F3DAAD3158C69233E94CD9806B4E78863A567C8A466AAE4D88233B6615D668EFBB1CD72B1A1320AE974952AC2B1ABF0950DCEA0265052C50EEA92DF98C66A7C0038AF399D02463CA35690E6AAA0CB55A8EA40B482AC462A08EAD474D01D4A37CF5A513600ACA8CFCF5A0A70A2BB94AC72C91A6937EEB15CFEA8721CFB56889309D6B1B549711BF3DA8E6B891E7BAD5FB453901BBD648D564DDF78D375F9F37479EF592AD9ADE10B8499ACDA8C87F88D4525EC8E08DC6A8163485C8AD940CAE24E4B367350EEC629EC4B54441069B0346D24208AD88E4F96B16CD4922B5546056326688B68F9A9D189AAF0AE4D5D8E3E959DCD05009A705356122E95208A8291022135279791566384115208B9A122AE5110126AC476B9ED57238054EA81455D892A0B6C76A93ECFC7353BCC88B58BA8EB2B029DA684896CB537971F522B22EF508A362322B9FBED7659588526B3D7CFBA6C9CD5A890E46A5DEA224C81597207949201AD1B6D28B60B62B452CA188738A1C4148E60DB48DC007F2A6FD8E51D735D594B753D4530A447D2B39685A6736B6CE3A8A718B1D456F1B756E951B5883DA95CB48E7668722B2A74DA4D7513C1B72315877D0E33814EE268CE80A8719C5747A6BAB3002B9958C87AD8D31992419A53D5131DCEDEDFFD58A949C0AA7692EE41F4ABA064570C91D0351BE6AB71D5455F9AADC758B02DC756A3AAB1D5A8EA2E074D1E335A11FDDACF8EAE46D815DA9993412B6071585AC49881BE95B339E2B9CD6DF10373DAA96E433CBB5C933727EB55AD08239A4D65F3727EB4DB21902BB693316599570322ABBF22A6958F4A6C56ED383B735BDF4332B0E07DEA8C3E5F15664B09D1F9071F4AA4E7CB9707AE6B3634CDAB4E066AF0997A66B2E19C08B8EB8AAB25E3093A9A934475304CA3BD5F8EE5715C6A5E498E09A78BEBAC71BAA648D2F63BA86E933C9A94CF193C3579F0BFBC0DD5AA68F50BBDC32CD4B94398F41599001CD4CB2A9AE3ED6FE6206F26B4E1BFE064D0D58699D08940A7997287D6B2A1B8F30F06B4634CC79EF537344675E3C982391583756ED313926B7AF0BF3D6B29E4C139A4D92D1902C6356CB0A915628DBE5C66AE30590D6858D95A3266555DDEA6AA0C89238FBAD6A7499A344E05531A95E4B32A90704FAD745AC78743486581D467D2B3ECF459D250F24990B5B74336864C93471EF2ED9F4A2D6E2424649AD3B983CD0171C5450D8843D2B199A4116A07240AB4BCD431C5B45484E2B9E4D9B2457BB8C609C5605DC59CF15D05C3E57159732020D38B629239994797274ABB6D70A40000CD437B1E5F8A65AC45581AD9EC64B73AFD25F70ADC52302B0B468CEDCD6E28C62B8AA1D311A07EF2ACA556CFEF2ACA1AE72596505588C9AAC86AC466868A89D52702A60702AAABE0D4C5BE5ADE2C81246AE6F5E7C40DF4AE849CAD72BE276DB6E707B5527A9123CB7557CDD1FAD4D6272A2AADF0DF39FAD59B24210576D366322C4CC0E456B787620EC770E3358F2E7D2B77C3D3244AC5B15B7319337EE6C229380BCE2B84D774D6B798B05E335DF8BD81FF008C550D461B5B98882C09A2C4DCE0A004AE2AC2DA6E39C55B6B058E6243719A9446430C0E2A1E86D116DAC14E09AB4DE4449D064554B8B831C600E2A1B356BBB852CC7683CD28BB8E624FA8431B6318FC2A18EFD64718FE557F58D18BFEF215CF15971DADC1D91883041E4D5908E8AD63F3E22C3B0A6484C4DD6AFD8DBB8B5C32ED38ACCBE85A3724B1A891A44D3B0B8CB0E6BA4827FDCFE15C5D8CB9702BA3B79B6C78CD646E85BC95CE6B1E60598E6B4E73906A8BA8269363B11431A03CD68C566B347F29ACF29562DE478FB9C538B25A2E1B3C00A79A41620290075A9A3BD5039506A437A847402B572D097133E4B611A9047355593157A69039CE6A02B9AC5B2A2AC5614A5722ACF963D2A375C566CD519D72B85CD65CAFC1AD9BA1B9300563CD1150D9AA893230EF5F6B934CB59F7B81525E26F7A934EB70B282456927A19753ADD1BFD5FE15ADDC56669F85518AD226B86A337891B7DFA990D44DD6A5515821B459435623354D4E2AD446A9844E9875A94FDDA89793533F0B5A4590373F2D71DE2C722022BAEDDC571BE2D23C8354B7219E69292D31FAD685B0223ACE76C4C7EB5A96AD98C576D3D8C5931B19E4190FC1ABDA769372C8D87A812F597E4E315D2E86FBE2626AD3D4CE4548744B92326514F6D1AE33FEB01ADE0EB9C53FCB3C14AD96C65D4E62F34A7B74DC79E2A94006304735D75FC6D2427701D2B969408E4C5653368142EEDC4878A65BC0F09C2B006AF6DDDCD392052C18562A46F6B93C0D318F0EF9A7C509590B7AD2A0008A9CB0DA36F5157CC2E4270CD1A7CC7B5636A0FBF357CCAEFF002B550BF5D885A86CA51285B49E54B5BF6F71B94735CC46C5E6207AD6E5B2308EA0D122E4B703154DEE39A91A2622A9CC852A65728B692EEEF57625DD1F0335CE9BA319AD9D27518D80463C9A22162DF924738A63A376AD911C7245B877A845AE49E2ADB158CC58DBBD4AA86AF1B7C1C6297C8C76ACC97A157671556618AD368F02A94E9414999AE473C5655E8C838AD799719ACBB91906A90A4CC910296CB62AD4691A901719AA77024CFCB4DB38E659B2C0E29CB631BEA7556270A2B4326B3AC3EE8AD2C570543A6036A553D2A12714E56AC96E5B4585AB119AAC95612AD928EA62352B1E2AAC6F8A94BE68BE82635DB19AE23C4F365581AED243C1AE03C4EE01619ADA86E65338491B373F8D6BC04086B15B99F8F5AD38C308ABBE5A239A44AC46E183CD761E1F6C5BB57072BB46CA707AD755A2DFB4701F91BF2AA819C8EABB648A9127C0C2F35CE49AD3799B0237E552C77F220DC11B9F6AD9191B324CC55B72F15CAEA6E3ED248E0569CDA93F94C4A374F4AC2B89FCE52E50FE5594CDA0CB9014641CD5A118038ACDB4963E015AD247C818AE73A530D94E54269E149AB30C25A99A220483BE2B2F566C2B0AEA45B6233C573DA8DA17908C5328C7B18774B9C574D6B645C0E2A8DA59F95835D0D83AA8C1A10AE577B12A3A5665CD8B31E95D4CF2211F8567B8526B46958148E6C69258F2293EC2D6F38C645745B956ABCC0487359D8AB96F4F971100DCF157530CDC566C00AD5D864C1E4D3426CBBB14F6E698F181DA944A3343C80D36919B2A4AB8CD67CC2B465607354263CD66C68CBB83D78AC7BA279AD8B86193C564DDF20D085233E301A500D6C882310290A3358B18C4D5BB11060033572D8C96E3E03B48C71577248E2A8A2E1AAEC7F76BCFAA7553603AF34F4EB4DA7A0E6B9D3D4D64584AB09502D4C95A5CCCDE56A97755504D4AA69F4063A53FBB35E6FE29721DBEB5E8970C444715E69E269732383EB5AD0DCCA672911DD373EB5BB12831573F6CA4DCE73C66BA05915500CD774D3B1CD22BCA24320181806BA0B1BB58620A475F6AC2CEE954E78CD755651DB9B5CB0527157044B16DF65C5C0207E95B0B100000A2B2ECDA159FEF015ABF68857EEC809AD8C9A2BEA0A5606F9474AC710EFD3D9B68CE6B76EE78A6B67F9867159D6CD12D8152C0D67245239E46292E2B5EDCE40ACABB1FBE253A55DB29BA026B268DE0CDA8D455C83008AA29202055849302A19B26693380958B78CA1EAC49313D0D519FE66E4D099571A660178A96DEE083C1AAACAA17AD3A0281B96AB44B66AF9A48A697A8FED30A2FDF1555EF50B7045513A969DB34D1F773518B9565E94CF3723149A2CBD1BF15223735411B1C934EFB42A9C6EC521366834C54D34DC1355848AEBF7B34AA334AE22632922ABC8D9A7953503820F5A865A2A4F8E6B26E88C1AD69B8CD62DF36338AA88A463CF334726455ED3EF99DB69359939CB1A5B57F2E4CD5C96863D4EAE17DC6AFA9C2D64D8BEF02B5154D79F551D14D8F1CD489D6A2248A950D72ADCD59616A55A896A55AA251B00D480D4429C0D68B60625CBE213F4AF2BF124A5AE9C7BD7A7DCB0F24E48AF36D76347B8739EF5D3878EA63368E7ED57E6CD5E28CC7AD5069042DC5097E438E6BD1947439E45E8D253281D81AE86294456F8671D3D6B9AFED442B85C6EAA73EA1393D78FAD34886CEBEDA78DE5FBC3F3ABEF2450AEEDEA73EF5C0C17C546771CD39B519589058E3EB57626C76F0DD24B1B8DE3F3A864B848A32BB87E75C7477F2A29C31A6FDAE694F2C71F5A4D0EC74B25FDB8073D6A2B4BB065E0F19AE5DE53BCE58D59B2B93BC73594D1A44EF6DEE32A39AB5E771D6B9DB3B9240E6B444C4AD733354CBC27C9A82E27DB4DB76DC4E6A0D40E1491422AE324B92C319A623B367E6AC892E1D4F14B0DD396C56A811B1B5C9E5AAD450A019241AA96D1BC801AB5F677F7AB48D9451219A38F8AAF2DF2A9E2A7163B864935566B019C0CD3B038A237D509E066A259E6958119AB10E93B9BA5694360B101C54B467223B349720B1E2B5514D323DAA318A9830159333158715565AB0F27154E59735052654B96C29AE7EF64C935AB7D2E14D737753649AD222932A4AE375496E4330ACD9E621A961BCF2CE49AD5AD0C5B3B4D3880062B60138AE434DD59430C9AEA2DEFE3910722B86AC4E8A6CB6BCF5A72F5A62CA8DD0D394F35C9CAEE6F72CA9A956A05A997AD3711266A07CFB0AA97BAAC36919CB826B1357F11C56E85636E7D8D709A86B735D3B65CE2BA69523094CE8759F14B4AAC91B15F706B939AFA595896726AA4936E3EF51839AEF8412307264924A5B93510396E287E292323356D8D1328C0CF7A63B123AD29614C63915484D0D04834F049EF51679A7A7340AC4BBB8A54723BD348A45EB408590E73EB4D89CA3839A565A638349EA34745A7DD03804D6F4320602B86B69DA3615D058DEEEC026B2944B4CEA2050471C52CF0874C1AAB6F7036F5A98DC678CD67634465CD63B9CE053E0D379071578B8CF356EDDD78A68A432DED5A303AD5D44E79153C4548A9404CD6899576316D8BAD396CC0FBC326ACA380294CDCD3B8AECAE62551C0C5577520F5E2AEB1CD569985672248770E9DE954FBD5773839A51262A044EEC00ACEB8980271524F701475AC7BABB193CD09032AEA1393919AC791B20E6AD4EE5DCD529C102B4488666CE3737155C8C7157D5375569936313571D49228E4643C122ADA6A53A0E2422A96EE7A52B608AA9534C699B106B73A91990FE75B36FE282AA032E6B8C5E29FE776E6B195145A933D060F14C4C4060056CDAEB16D328F9D47E35E4A1DB3906AC477B347D1AB1744A5224B8BB92690B331E7DEAA3927A534B669335DB182473B638631D79A3760D3693BD5D843DB91518241A767DE938ACD96803134ECD378A5A680314E538A6D264D311316E2843CD4193522502273CD31C60519A19B228023CF3566DEE0C6D554D394E2868A474969A89DB826B4A0BADFDEB908E52A460D6A5ADC9007359B89499D0BCFD2AE5A4D9E735851CDBB19AD08241C60D4329337A39B2383532331359B03648E6B5AD8A8C679A84CBB96E1524734AF11CE6A459A351DA9DE6A30EA2B442B9519B1C556958E3356672BCE2A93B7073458572BB4BF362A19A708A689A45524F158D797449201A9B0AE3AEAF09240359EC5A534AA8D29AB09095EA28B0AE5474DABCD53B8E56B4E7C722B2AE3A9A6495A3386C513A0233428F9A96E0E231549EA26673A8069A7A53DF9A6569CE488291891D052D1D68B957052714848CF2697A526052D077173499AD33A29FFA08E9DFF810290E8C7FE823A77FE040A955625FB1999B4568FF00631FFA08E9DFF810297FB18FFD0474EFFC09155ED621EC6666E68CD697F631FF00A08E9DFF0081228FEC53FF00411D3BFF0002454F3C43D94CCD0696B47FB18FFD0474EFFC09140D18FF00D0474EFF00C0814FDA446A948CE141AD31A31FFA08E9DFF810286D18FF00D0474EFF00C08147B4887B299944D3D4D5F3A29FFA08E9DFF81229C34638FF00908E9DFF0081028F69117B19947349DEB47FB1CFFD0474EFFC0814BFD8E7FE821A77FE040A3DA445EC6667629318AD2FEC83FF00410D3BFF0002051FD904FF00CC474EFF00C08147B4887B2999CA79ABD6E78A71D19B3C6A1A77FE040AB3069653AEA1607FEDE054BA911FB29934448C55B8E565A741A7F4FF004DB23F49855C1A69238BAB5CFF00D751593A911FB2992DADD0C8C9AD78AED768E6B0BFB3248F9FB55AFF00DFD14F58245FF97CB4FF00BFC29A9447ECE66E9BACFF001527DAC8FE2AC611C9FF003F969FF7F85218A561C5DDA7FDFE154A7117B399B2D7EA072D546E352500E0D511613C9FF2F56BF84D4A347949F9AE6DFF00EFE8A3DA444E9CC825BC694E05442DDA43C8AD68B47C0CF9F013FEFD5A5D3C20FF005D07FDF6297B4882A533360B6D8BC8A598015A26D73D2783FEFBAAD3D9139FF48B71F59052E788FD94CC49DB2C6B367EB5B7269E4B1FF4BB4FC66154A6D2C93FF1FB65FF007F851ED223F63332D56A3BA384AD74D28E3FE3F6CBFEFF000AAD75A4923FE3FEC07D671429C43D8CCC1639A4AD33A31FFA08E9DFF810281A31FF00A08E9DFF008102B4E688BD8CCCB345699D189FF988E9DFF810281A29FF00A08E9DFF0081028E6887B199994569FF00631FFA08E9DFF81028FEC63FF411D3BFF02051CD10F6323FFFD900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000,1,'2011-08-20');
/*!40000 ALTER TABLE `motocicletasimagenes` ENABLE KEYS */;


--
-- Definition of table `movimientoscuentacorriente`
--

DROP TABLE IF EXISTS `movimientoscuentacorriente`;
CREATE TABLE `movimientoscuentacorriente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idcuentacorriente` int(11) NOT NULL,
  `idtipomovimiento` int(11) NOT NULL,
  `monto` decimal(18,2) NOT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  `fechavencimiento` date DEFAULT NULL,
  `fecha` date NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` datetime NOT NULL,
  `idrubro` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `tipomontocuenta_moviemientocuenta` (`idtipomovimiento`),
  KEY `cuentacorriente_movimientoscuentacorriente` (`idcuentacorriente`),
  KEY `rubroscuentacorriente_moviemitoscuetacorriente` (`idrubro`),
  CONSTRAINT `cuentacorriente_movimientoscuentacorriente` FOREIGN KEY (`idcuentacorriente`) REFERENCES `cuentacorriente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `rubroscuentacorriente_moviemitoscuetacorriente` FOREIGN KEY (`idrubro`) REFERENCES `rubroscuentacorriente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `tipomontocuenta_moviemientocuenta` FOREIGN KEY (`idtipomovimiento`) REFERENCES `tipomontocuentacorriente` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `movimientoscuentacorriente`
--

/*!40000 ALTER TABLE `movimientoscuentacorriente` DISABLE KEYS */;
INSERT INTO `movimientoscuentacorriente` VALUES  (3,3,1,'9.00','gjh','2011-10-26','2011-09-26',1,'2011-09-26 21:00:31',1),
 (4,3,2,'9.00',NULL,'2011-10-26','2011-09-26',1,'2011-09-26 21:00:31',1),
 (5,3,1,'2.97','GD','2011-10-26','2011-09-26',1,'2011-09-26 22:55:50',1),
 (6,3,2,'2.00','Abono a cuenta  a cliente Saúl Antonio Mayorquin Díaz','2011-09-28','2011-09-28',1,'2011-09-28 21:29:17',1),
 (7,5,1,'60.00','fadfasf','2011-10-30','2011-09-30',1,'2011-09-30 22:43:36',1),
 (8,5,2,'10.00','Abono a cuenta  a cliente Javier Eduardo Atala','2011-09-30','2011-09-30',1,'2011-09-30 22:44:28',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `municipios`
--

/*!40000 ALTER TABLE `municipios` DISABLE KEYS */;
INSERT INTO `municipios` VALUES  (1,'Comayagua',3,1,1,'2011-08-20 00:00:00'),
 (2,'La Paz',12,1,1,'2011-08-20 00:00:00'),
 (3,'Marcala',12,1,1,'2011-08-20 00:00:00'),
 (4,'Siguatepeque',3,1,1,'2011-08-20 00:00:00'),
 (5,'La Esperanza',10,1,1,'2011-08-20 00:00:00');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordenescompras`
--

/*!40000 ALTER TABLE `ordenescompras` DISABLE KEYS */;
INSERT INTO `ordenescompras` VALUES  (2,'OC-001-20110905-001-0000001',1,1,'2011-09-05',1,1,'2011-09-05 20:03:00');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordenesrequisicion`
--

/*!40000 ALTER TABLE `ordenesrequisicion` DISABLE KEYS */;
INSERT INTO `ordenesrequisicion` VALUES  (1,'OR-001-20110905-001-0000001','2011-09-05',1,NULL,1,1,'E','2011-09-05 20:33:29',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ordenessalida`
--

/*!40000 ALTER TABLE `ordenessalida` DISABLE KEYS */;
INSERT INTO `ordenessalida` VALUES  (1,'OS-001-20110905-001-0000001',1,NULL,1,1,'P',NULL,'2011-09-05 20:33:58',1,'2011-09-05');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `productos`
--

/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES  (1,'026470','ABRAZADERA PLASTICA',NULL,'3.00',1,'2011-08-24 21:46:10'),
 (2,'4545','ABRAZADER METALICA',NULL,'12.22',1,'2011-08-24 21:46:10');
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
INSERT INTO `propietario` VALUES  (1,4,'2011-08-20 12:07:19',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proveedores`
--

/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
INSERT INTO `proveedores` VALUES  (1,6,5,1,'2011-08-20',NULL);
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
  CONSTRAINT `fk_ProveeedorProducto_productos1` FOREIGN KEY (`productos_id`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProveeedorProducto_proveedores1` FOREIGN KEY (`proveedores_id`) REFERENCES `proveedores` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proveeedorproducto`
--

/*!40000 ALTER TABLE `proveeedorproducto` DISABLE KEYS */;
/*!40000 ALTER TABLE `proveeedorproducto` ENABLE KEYS */;


--
-- Definition of table `rubroscuentacorriente`
--

DROP TABLE IF EXISTS `rubroscuentacorriente`;
CREATE TABLE `rubroscuentacorriente` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rubroscuentacorriente`
--

/*!40000 ALTER TABLE `rubroscuentacorriente` DISABLE KEYS */;
INSERT INTO `rubroscuentacorriente` VALUES  (1,'Productos'),
 (2,'Motocicletas');
/*!40000 ALTER TABLE `rubroscuentacorriente` ENABLE KEYS */;


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
INSERT INTO `sucursales` VALUES  (1,2,1,1,1,'2011-08-20 11:27:49',1,146),
 (2,7,2,1,1,'2011-08-20 12:32:39',1,3126);
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tarjetacredito`
--

/*!40000 ALTER TABLE `tarjetacredito` DISABLE KEYS */;
INSERT INTO `tarjetacredito` VALUES  (1,'VISA',1,1,'2011-08-20 00:00:00'),
 (2,'MASTER CARD',1,1,'2011-08-20 00:00:00'),
 (3,'AMERICAN EXPRESS',1,1,'2011-08-20 00:00:00');
/*!40000 ALTER TABLE `tarjetacredito` ENABLE KEYS */;


--
-- Definition of table `tipomontocuentacorriente`
--

DROP TABLE IF EXISTS `tipomontocuentacorriente`;
CREATE TABLE `tipomontocuentacorriente` (
  `id` int(11) NOT NULL,
  `descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tipomontocuentacorriente`
--

/*!40000 ALTER TABLE `tipomontocuentacorriente` DISABLE KEYS */;
INSERT INTO `tipomontocuentacorriente` VALUES  (1,'Debito'),
 (2,'Credito');
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
 (2,'Crédito',1,1,'2011-09-26 00:00:00');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tiposmotocicletas`
--

/*!40000 ALTER TABLE `tiposmotocicletas` DISABLE KEYS */;
INSERT INTO `tiposmotocicletas` VALUES  (1,'Montañeza',1,1,'2011-08-20 00:00:00');
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

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
 (10,'Anulacion Factura',1,'2011-06-19 00:00:00','D'),
 (11,'Abono Contado Cuenta Corriente',1,'2011-06-19 00:00:00','C'),
 (12,'Abono Tarjeta Credito Cuenta Corriente',1,'2011-06-19 00:00:00','C');
/*!40000 ALTER TABLE `transaccionescaja` ENABLE KEYS */;


--
-- Definition of table `transaccionestarjetacredito`
--

DROP TABLE IF EXISTS `transaccionestarjetacredito`;
CREATE TABLE `transaccionestarjetacredito` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numerotarjeta` varchar(45) DEFAULT NULL,
  `codigoaprobacion` varchar(45) DEFAULT NULL,
  `vencimiento` varchar(45) DEFAULT NULL,
  `idtarjetacredito` int(11) NOT NULL,
  `usu` int(11) NOT NULL,
  `fmodif` varchar(45) NOT NULL,
  `idcontrolcaja` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idtarejtacredit_transaccionestarjetacredito` (`idtarjetacredito`),
  KEY `idtranasccionestarjetacredito_idcontrolcaja` (`idcontrolcaja`),
  CONSTRAINT `idtarejtacredit_transaccionestarjetacredito` FOREIGN KEY (`idtarjetacredito`) REFERENCES `tarjetacredito` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idtranasccionestarjetacredito_idcontrolcaja` FOREIGN KEY (`idcontrolcaja`) REFERENCES `controlcaja` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaccionestarjetacredito`
--

/*!40000 ALTER TABLE `transaccionestarjetacredito` DISABLE KEYS */;
INSERT INTO `transaccionestarjetacredito` VALUES  (1,'34234243','23412341324','1221',3,1,'2011-08-20',3),
 (2,'131321','1231231321','1111',3,1,'2011-09-28',42),
 (3,'12112','1212','1221',3,1,'2011-09-28',44);
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usuarios`
--

/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES  (1,1,'3P5lX3oURN2l1isXbJVY4ROiJ6H19iLSu3BaH9919Uw=','smayorquin',1,1,1,'2011-08-20 11:57:38',5),
 (2,3,'OMKo9I4+ikzQp9ahaG2jINHeUAQpJ5eK','gcarvajal',1,1,1,'2011-08-20 12:04:47',5);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;


--
-- Definition of function `CalcularSaldo`
--

DROP FUNCTION IF EXISTS `CalcularSaldo`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` FUNCTION `CalcularSaldo`(
idrubro int(11),
identidad int(11)
) RETURNS double
BEGIN
declare saldo double;

set saldo =0.00;

select  sum(case t.idtipomovimiento when 1 then t.monto when 2 then t.monto*-1 else 0 end)  saldo1
from movimientoscuentacorriente t
join cuentacorriente c on t.idcuentacorriente=c.id
where t.idrubro=idrubro and  c.identidaddeudora=identidad
group by t.idrubro,t.idcuentacorriente into saldo ;

return saldo;

END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of function `CargarCorrelativoCodigo`
--

DROP FUNCTION IF EXISTS `CargarCorrelativoCodigo`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` FUNCTION `CargarCorrelativoCodigo`(

codigo nvarchar(4)

) RETURNS mediumtext CHARSET latin1
BEGIN

set  @correlativocodigo =0;

select count(*) from correlativocodigo t where upper(t.codigo)=upper(codigo) into @correlativo;

if @correlativo=0 then
    insert into correlativocodigo(codigo,correlativo) values(upper(codigo),1);
    return 1;
else
    select t.correlativo+1 from correlativocodigo t where upper(t.codigo)=upper(codigo) into @correlativo;

    update correlativocodigo t set
      t.correlativo=@correlativo
    where upper(t.codigo)=upper(codigo);
    return @correlativo;

end if;

return 0;



END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of function `CrearCorrelativoCodigo`
--

DROP FUNCTION IF EXISTS `CrearCorrelativoCodigo`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` FUNCTION `CrearCorrelativoCodigo`(iniciales nvarchar(2),sucursal int(11), usuario int(11)) RETURNS varchar(70) CHARSET utf8
BEGIN
set @correlativoc=0;
select CargarCorrelativoCodigo(iniciales) into @correlativoc;
return concat(upper(iniciales),"-",repeat("0",3-CHARACTER_LENGTH(sucursal)),upper(sucursal),"-", upper(year(now())),repeat("0",2-CHARACTER_LENGTH(upper(month(now())))) , upper(month(now())), repeat("0",2-CHARACTER_LENGTH(upper(day(now())))), upper(day(now())),"-",repeat("0",3-CHARACTER_LENGTH(usuario)),upper(usuario),"-", repeat("0",7-CHARACTER_LENGTH(@correlativoc)),upper(@correlativoc) );

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


id nvarchar(11),
idtransacciones nvarchar(150),
fecha nvarchar(200),
cajero nvarchar(11),
idsucursales nvarchar(11),
tipo nvarchar(1)

)
BEGIN

set @Campos="select c.id as id, sum(c.monto) as monto, t.descripcion as descripcion ";
set @from="  ";
set @where=" where 1=1 ";
set @sql="";
set @group=" group by idtransaccionescaja ";

set @from= concat(@from," from controlcaja c ");

set @join = (" join transaccionescaja t  on c.idtransaccionescaja=t.id");



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




PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;



END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `AgregarCuentaPropietario`
--

DROP PROCEDURE IF EXISTS `AgregarCuentaPropietario`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarCuentaPropietario`(identidad           int(11),
                                          fechavencimiento    date,
                                          monto               decimal(18,2),
                                          descripcion         nvarchar(200),
                                          idrubro             int(11),
                                          idsucursal          int(11),
                                          idtipomonto         int(11),
                                          usu                 int(11),
                                          INOUT idcuentacorriente int(11),
                                          INOUT codigoCuentaCorriente nvarchar(70),
                                          INOUT idmovimento int(11))
BEGIN
      DECLARE idpropietario           int(11) DEFAULT 0;
      DECLARE esnatural           int(1) DEFAULT 0;
      SET codigoCuentaCorriente='';
      SET idcuentacorriente = 0;
      SET idmovimento=0;

      SELECT t.identidades
        FROM propietario t LIMIT 1
        INTO idpropietario ;

      SELECT e.espersonanatural
      FROM entidades e
      WHERE e.id = identidad INTO  esnatural;

      IF esnatural=1 THEN

        IF idpropietario>0 THEN
          SELECT id FROM cuentacorriente cuenta
            WHERE cuenta.identidaddeudora=identidad AND cuenta.identidadbeneficiaria= idpropietario
            INTO idcuentacorriente;

          IF idcuentacorriente=0 THEN
            CALL CuentaCorriente_Mant(idcuentacorriente,
                                      codigoCuentaCorriente,
                                      identidad,
                                      idpropietario,
                                      'A',
                                      idsucursal,
                                      curdate(),
                                      1,
                                       usu,
                                      now());
        END IF;

          IF idcuentacorriente>0 THEN

              CALL MovimientoCuentaCorriente_Mant(idmovimento,
                                                  idcuentacorriente,
                                                  idtipomonto,
                                                  monto,
                                                  fechavencimiento,
                                                  curdate(),
                                                  descripcion,
                                                  idrubro,
                                                  usu,
                                                  now());
        END IF;

        END IF;

      END IF;
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


id nvarchar(11),
identidades nvarchar(11),
entidadnombre nvarchar(120),
espersonanatural nvarchar(1)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from clientes c ");



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


id nvarchar(11),
idtransacciones nvarchar(150),
fecha nvarchar(200),
cajero nvarchar(11),
idsucursales nvarchar(11)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @sql="";

set @campos= concat( @campos," c.*, t.descripcion as descripciontransaccion, t.tipo as tipo, fe.numerofactura as numerofactura ");

set @from= concat(@from," from controlcaja c ");

set @join = (" inner join transaccionescaja t on c.idtransaccionescaja=t.id");
set @left = (" left join controlcajafactura h on h.idcontrolcaja =c.id ");
set @left = concat(@left," left join facturaencabezado fe on h.idfacturaencabezado=fe.id ");

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



INOUT id int(11),
INOUT codigo nvarchar(70),
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


SET @conteo =0;
SELECT count(id) FROM cuentacorriente m WHERE m.id=id INTO @conteo;
IF @conteo =0 THEN

    SELECT count(id) FROM cuentacorriente m
    WHERE m.identidadbeneficiaria = identidadbeneficiaria AND m.identidaddeudora = identidaddeudora INTO @conteo;

    IF @conteo >0 THEN
      SELECT id FROM cuentacorriente m
      WHERE m.identidadbeneficiaria = identidadbeneficiaria AND m.identidaddeudora = identidaddeudora INTO id;
    END IF;


END IF;

IF @conteo =0 THEN


  SELECT CrearCorrelativoCodigo("CC",idsucursales,usu) INTO codigo;

  INSERT INTO cuentacorriente(codigo,identidaddeudora,identidadbeneficiaria,estado,idsucursales,fecha,habilitado,usu,fmodif)

  VALUES(codigo,identidaddeudora,identidadbeneficiaria,estado,idsucursales,fecha,habilitado,usu,fmodif);

  SELECT last_insert_id() INTO id;

ELSE

  UPDATE cuentacorriente c SET
        c.identidaddeudora=identidaddeudora,
        c.identidadbeneficiaria=identidadbeneficiaria,
        c.estado=estado,
        c.idsucursales=idsucursales,
        c.fecha=fecha,
        c.habilitado=habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  WHERE c.id= id;

END IF;

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


id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from departamentos ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


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

  
  

  select CrearCorrelativoCodigo("FE",idsucursales,elabora) into codigo;



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

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from ", tabla,"  c ");



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


id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from marcas ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


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


id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from modelos ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


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
-- Definition of procedure `MoviemientosCuentaCorriente_Buscar`
--

DROP PROCEDURE IF EXISTS `MoviemientosCuentaCorriente_Buscar`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `MoviemientosCuentaCorriente_Buscar`(
   id                      nvarchar(11),
   identidadbenficiaria    nvarchar(11),
   identidaddeudora        nvarchar(11),
   idrubro nvarchar(1),
   propietario             int(1))
BEGIN
      DECLARE idpropietario   int(11) DEFAULT 0;
      SET @Campos = "select ";
      SET @from = " ";
      SET @where = " where 1=1 ";
      SET @orden = "order by id ";
      SET @sql = "";

      SET @campos = concat(@campos, " o.* ");

      SET @from = concat(@from, " from vmovimientoscuentacorriente o");


      IF propietario = 1
      THEN
         SELECT p.identidades
           FROM propietario p
           INTO idpropietario;

         SET @where =
                concat(@where,
                       " and o.identidadbeneficiaria = ",
                       idpropietario,
                       " ");
      ELSE
         SET @where =
                concat(@where,
                       " and o.identidadbenficiaria = ",
                       identidadbenficiaria,
                       " ");
      END IF;

      IF id <> ""
      THEN
         SET @where =
                concat(@where,
                       " and o.id = ",
                       id,
                       " ");
      END IF;

      IF identidaddeudora <> ""
      THEN
         SET @where =
                concat(@where,
                       " and o.identidaddeudora = ",
                       identidaddeudora,
                       " ");
      END IF;
      
      IF idrubro <> ""
      THEN
         SET @where =
                concat(@where,
                       " and o.idrubro = ",
                       idrubro,
                       " ");
      END IF;
        
      


      SET @sql =
             concat(@campos,
                    @from,
                    @where,
                    @orden);

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
   END $$
/*!50003 SET SESSION SQL_MODE=@TEMP_SQL_MODE */  $$

DELIMITER ;

--
-- Definition of procedure `MovimientoCuentaCorriente_Mant`
--

DROP PROCEDURE IF EXISTS `MovimientoCuentaCorriente_Mant`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `MovimientoCuentaCorriente_Mant`(

INOUT id int(11),
idcuentacorriente int(11),
idtipomovimiento int(11),
monto decimal(18,2),
fechavencimiento date,
fecha date,
descripcion nvarchar(200),
idrubro int(11),
usu int(11),
fmodif datetime
)
BEGIN

DECLARE habil int(1) DEFAULT 0;
SET @conteo =0;
SELECT count(id) FROM movimientoscuentacorriente m WHERE m.id=id INTO @conteo;

SELECT c.habilitado FROM cuentacorriente c where c.id=idcuentacorriente INTO habil;
IF habil =1 THEN
  IF @conteo =0 THEN

    INSERT INTO movimientoscuentacorriente(idcuentacorriente,idtipomovimiento,monto,fechavencimiento,
                                           fecha, descripcion, idrubro,usu,fmodif)

    VALUES(idcuentacorriente,idtipomovimiento,monto,fechavencimiento,
                                           fecha, descripcion,idrubro,usu,fmodif);

    SELECT last_insert_id() INTO id;

  ELSE

    UPDATE movimientoscuentacorriente c SET
          c.idcuentacorriente=idcuentacorriente,
          c.idtipomovimiento=idtipomovimiento,
          c.monto=monto,
          c.fechavencimiento=fechavencimiento,
          c.fecha=fecha,
          c.descripcion=descripcion,
          c.idrubro=idrubro,
          c.usu=usu,
          c.fmodif=fmodif
    WHERE c.id= id;
   END IF;
else 
  set id=0;
END IF;
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


id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from municipios ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


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


  select CrearCorrelativoCodigo("oc",idsucursal,elaboradopor) into codigo;

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

  select CrearCorrelativoCodigo("OR",sucursalenvia,enviadopor) into codigo;

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


  select CrearCorrelativoCodigo("OS",sucursalenvia,enviadopor) into codigo;

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


id nvarchar(11),
razonsocial nvarchar(120),
razonsocialigual nvarchar(120),
rtn nvarchar(18)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by razonsocial ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from personasjuridicas ");



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


id nvarchar(11),
nombrecompleto nvarchar(120),
nombrecompletoigual nvarchar (120),
identificacion nvarchar(45),
tipoidentificacion nvarchar(1),
rtn nvarchar(18) 

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by NombreCompleto ";
set @sql="";

set @campos= concat( @campos," * ");


set @from= concat(@from," from personasnaturales ");



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


id nvarchar(11),
identidades nvarchar(11),
entidadnombre nvarchar(120)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " inner join ventidades e on e.IdEntidad=c.identidades ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from propietario c ");



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


id nvarchar(11),
identidades nvarchar(11),
entidadnombre nvarchar(120),
espersonanatural nvarchar(1)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from proveedores c ");



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
-- Definition of procedure `SaldoCuentaCorriente`
--

DROP PROCEDURE IF EXISTS `SaldoCuentaCorriente`;

DELIMITER $$

/*!50003 SET @TEMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SaldoCuentaCorriente`(
id int(11),
idrubro int(11),
idcuentacorriente int(11)
)
BEGIN

select t.id, sum(case t.idtipomovimiento when 1 then t.monto when 2 then t.monto*-1 else 0 end)  saldo
from movimientoscuentacorriente t
where t.idrubro=idrubro and  t.idcuentacorriente=idcuentacorriente
group by t.idrubro,t.idcuentacorriente;



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


id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from tiposfacturas ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


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


id nvarchar(11),
descripcion nvarchar(45)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from tiposmotocicletas ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if descripcion<>"" then
  set @where = concat(@where, " and descripcion like '",descripcion, "%' ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


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


id nvarchar(11),
idproductos nvarchar(11),
idsucursales nvarchar(11),
tabla nvarchar(500),
campos nvarchar(500),
parametro nvarchar(500)

)
BEGIN

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



if id<>"" then
  set @where= concat(@where, " and t.id = ", id, " ");
end if;


if idproductos<>"" then
  set @join= concat(@join, " and p.idproducto = ", idproductos, " ");
end if;


if idsucursales<>"" then
  set @join= concat(@join, " and i.idsucursales = ", idsucursales, " ");
end if;


if parametro<>"" then
  set @where= concat(@where," and ",parametro ,"   ");
end if;






set @sql = concat(@campos,@from,@join,@where,@group,@orden);



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


id nvarchar(11),
idproductos nvarchar(11),
idsucursales nvarchar(11),
descripcion nvarchar(45),
inventarioTotal nvarchar(1),
codigo nvarchar(45)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @join = "join vproductos p on p.idproducto = i.idproductos";
set @sql="";
set @group = "";

set @campos= concat( @campos," * ");

set @from= concat(@from," from inventario i ");



if id<>"" then
  set @where= concat(@where, " and i.id = ", id, " ");
end if;


if idproductos<>"" then
  set @join= concat(@join, " and p.idproducto = ", idproductos, " ");
end if;


if idsucursales<>"" then
  set @join= concat(@join, " and i.idsucursales = ", idsucursales, " ");
end if;


if codigo<>"" then
  set @join= concat(@join, " and p.codigo = '", codigo, "'  ");
end if;


if descripcion<>"" then
  set @join= concat(@join, " and p.descripcion like '", descripcion, "%'  ");
end if;



if descripcion<>"" then
  set @join= concat(@join, " and p.descripcion like '", descripcion, "%'  ");
end if;


if inventarioTotal<>"" then
    set @campos= "select i.id,i.usu,i.idsucursales,i.fmodif,idproductos, idproducto,codigo,descripcion, sum(cantidad) as cantidad,precioventa  ";
    set @group = "group by i.idproductos ";
end if;

set @sql = concat(@campos,@from,@join,@where,@group,@orden);


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

  INSERT INTO transaccionestarjetacredito(codigoaprobacion,vencimiento,idtarjetacredito,numerotarjeta,idcontrolcaja,usu,fmodif)

  VALUES(codigoaprobacion,vencimiento,idtarjetacredito,numerotarjeta,idcontrolcaja,usu,fmodif);

  select last_insert_id() into id;
  if idfacturaencabezado>0 then
    insert into facturatransaccionestarjetacredito(idfacturaencabezado,idtransaccionestarjetacredito)
      values(idfacturaencabezado,id);
    
  end if;
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
-- Definition of view `vmovimientoscuentacorriente`
--

DROP TABLE IF EXISTS `vmovimientoscuentacorriente`;
DROP VIEW IF EXISTS `vmovimientoscuentacorriente`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vmovimientoscuentacorriente` AS select `m`.`id` AS `id`,`m`.`idcuentacorriente` AS `idcuentacorriente`,`m`.`idtipomovimiento` AS `idtipomovimiento`,`m`.`monto` AS `monto`,`m`.`descripcion` AS `descripcion`,`m`.`fechavencimiento` AS `fechavencimiento`,`m`.`fecha` AS `fecha`,`m`.`usu` AS `usu`,`m`.`fmodif` AS `fmodif`,`m`.`idrubro` AS `idrubro`,`c`.`codigo` AS `codigo`,`c`.`identidaddeudora` AS `identidaddeudora`,`c`.`identidadbeneficiaria` AS `identidadbeneficiaria`,`c`.`estado` AS `estado`,`c`.`fecha` AS `fechacreacion`,`c`.`idsucursales` AS `idsucursales`,`c`.`habilitado` AS `habilitado`,(case `m`.`idtipomovimiento` when 1 then `m`.`monto` else NULL end) AS `debito`,(case `m`.`idtipomovimiento` when 2 then `m`.`monto` else NULL end) AS `credito` from (`movimientoscuentacorriente` `m` join `cuentacorriente` `c` on((`m`.`idcuentacorriente` = `c`.`id`)));

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
