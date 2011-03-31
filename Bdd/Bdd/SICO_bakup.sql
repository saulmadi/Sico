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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `clientes`
--

/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES  (1,4,2,'2011-02-07 00:00:00',NULL),
 (2,8,2,'2011-02-09 22:32:06',NULL),
 (3,6,2,'2011-02-07 00:00:00',NULL),
 (4,22,2,'2011-02-07 21:43:56',NULL),
 (5,24,2,'2011-02-09 22:33:56',NULL);
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
  PRIMARY KEY (`id`),
  KEY `FK_compras_Sucursal` (`idsucursal`),
  KEY `FK_compras_proveedor` (`idproveedor`),
  CONSTRAINT `FK_compras_proveedor` FOREIGN KEY (`idproveedor`) REFERENCES `proveedores` (`id`),
  CONSTRAINT `FK_compras_Sucursal` FOREIGN KEY (`idsucursal`) REFERENCES `sucursales` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `compras`
--

/*!40000 ALTER TABLE `compras` DISABLE KEYS */;
INSERT INTO `compras` VALUES  (20,'878789',1,'2011-02-26',1,2,'2011-02-26 11:32:29','25.00'),
 (21,'45445',1,'2011-02-26',1,2,'2011-02-26 11:47:41','25.00'),
 (22,'454',1,'2011-02-26',1,2,'2011-02-26 11:50:05','5.00'),
 (23,'98',1,'2011-02-26',1,2,'2011-02-26 11:50:31','1.00'),
 (24,'458954854',1,'2011-02-26',2,2,'2011-02-26 11:51:43','25.00'),
 (25,'12345679801',1,'2011-02-26',1,2,'2011-02-26 12:03:44','390.00'),
 (26,'2123132',2,'2011-02-26',2,2,'2011-02-26 14:59:26','225.00'),
 (27,'63565',3,'2011-02-26',1,2,'2011-02-26 19:24:10','22.00'),
 (28,'42324',1,'2011-02-27',2,2,'2011-02-27 19:17:09','99.00'),
 (29,'443',2,'2011-02-27',2,2,'2011-02-27 19:24:15','46.00'),
 (31,'32432',1,'2011-02-27',2,2,'2011-02-27 19:30:41','132.00'),
 (32,'4234',1,'2011-02-27',1,2,'2011-02-27 19:34:31','16848.00'),
 (33,'34234',3,'2011-02-28',2,2,'2011-02-28 00:53:48','30450.00'),
 (34,'456465',2,'2011-02-28',1,2,'2011-02-28 00:56:18','27775.00'),
 (35,'24324223434',3,'2011-03-03',2,2,'2011-03-03 21:14:32','69.00'),
 (38,'43234',2,'2011-03-03',1,2,'2011-03-03 23:14:01','110144.00');
/*!40000 ALTER TABLE `compras` ENABLE KEYS */;


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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

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
 (28,38,2,32,'3442.00',1,2,'2011-03-03 23:14:01');
/*!40000 ALTER TABLE `detallecompras` ENABLE KEYS */;


--
-- Definition of trigger `DetalleCompra_trigg`
--

DROP TRIGGER /*!50030 IF EXISTS */ `DetalleCompra_trigg`;

DELIMITER $$

CREATE DEFINER = `root`@`localhost` TRIGGER `DetalleCompra_trigg` AFTER INSERT ON `detallecompras` FOR EACH ROW BEGIN


    CALL Inventarios_Triggers(new.idsucursal,new.idproducto,new.cantidad,new.usu,new.fmodif);

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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

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
 (12,11,2,32,'2011-03-27 23:38:56',2);
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
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `entidades`
--

/*!40000 ALTER TABLE `entidades` DISABLE KEYS */;
INSERT INTO `entidades` VALUES  (4,27729729,'col. miraflores tegucigalpacol. miraflores tegucigalpacol. miraflores tegucigalpacol. miraflores tegucigalpacol. miraflores tegucigalpacol. miraflores','saulmadiqg@aksdfjk.com',1,'08011988125246',2,'2011-03-02','saul antonio mayorquin diaz&','0801-1988-12524','I',96330670),
 (5,NULL,NULL,NULL,1,NULL,2,'2011-02-09','asdf asdf asdf%','34f83cac-180f-4355-89e3-f0dce27714fe','N',NULL),
 (6,4322340,'aaklsdfjakl','sad@jfsdk.com',0,'REWIE',2,'2011-03-04','Varideades Canezu','c4b7213f-8a54-4d91-ae3b-25e9a20e6f59','J',34872342),
 (7,NULL,NULL,NULL,1,NULL,1,'2011-01-27','carlos diaz@','0301-1989-12345','I',NULL),
 (8,34234,'fdsdfsdfsdf',NULL,0,NULL,2,'2011-02-09','ENEE','dcc75552-7454-4f88-9829-c124225baac2','J',342443),
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
 (22,434342,NULL,NULL,0,NULL,2,'2011-02-07','SANAA','0b1dc0fa-70a9-4b02-badb-05ef777d85dc','J',34234234),
 (23,NULL,NULL,NULL,1,NULL,2,'2011-02-09','Raul Valladares@','189e0c80-2b7d-49f5-8841-f61c0b9c814e','N',NULL),
 (24,43533535,NULL,'sadkjkldf@ddd.df',1,NULL,2,'2011-03-04','Hector valladares@','7b28fd99-db02-47b2-a987-c5d20a7c34c3','N',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `inventario`
--

/*!40000 ALTER TABLE `inventario` DISABLE KEYS */;
INSERT INTO `inventario` VALUES  (8,2,1,0,2,'2011-03-27 16:08:06'),
 (9,9,1,4567,2,'2011-03-25 22:25:17'),
 (10,2,2,146,2,'2011-03-27 23:48:44'),
 (11,6,1,0,2,'2011-03-25 22:09:07'),
 (12,5,2,5,2,'2011-02-26 14:59:26'),
 (13,10,1,4,2,'2011-02-26 19:24:10'),
 (14,9,2,1048,2,'2011-03-27 23:34:11'),
 (15,6,2,68,2,'2011-03-27 23:47:32');
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `marcas`
--

/*!40000 ALTER TABLE `marcas` DISABLE KEYS */;
INSERT INTO `marcas` VALUES  (10,'KMF',1,1,'2011-01-09 00:00:00'),
 (11,'YAMAHA',1,1,'2011-01-09 00:00:00'),
 (12,'HONDA',1,2,'2011-03-23 00:00:00');
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
  `precioventa` decimal(10,2) NOT NULL,
  `preciocompra` decimal(10,2) NOT NULL,
  `fechaIngreso` date NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

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
 (11,'OS-002-20110327-002-0000010',2,NULL,2,1,'E',NULL,'2011-03-27 23:38:56',2,'2011-03-27');
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
 (2,'XXX-XXX','Abrazadera','3442.00','11454.00',2,'2011-02-20 22:23:10'),
 (3,'d','d',NULL,'145849111.11',2,'2011-02-11 21:17:42'),
 (5,'hhj-jjkk-klk-df','cluch','45.00','465.45',2,'2011-02-12 00:54:50'),
 (6,'FSADF','hule de hierro','465.00','123.00',2,'2011-02-26 11:54:54'),
 (7,'ATOG-022-1221','Amortiguador',NULL,'1545.40',2,'2011-02-21 18:17:31'),
 (8,'RITI-TIKUT-4454','Foco Delantero',NULL,'47455.45',2,'2011-02-21 18:32:52'),
 (9,'DKKPSD-454-24554','Hule de casilla','5.00','456.40',2,'2011-02-21 19:22:21'),
 (10,'4554456','MOTOR','5.50','2.00',2,'2011-02-26 19:22:40');
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
  CONSTRAINT `fk_ProveeedorProducto_productos1` FOREIGN KEY (`productos_id`) REFERENCES `productos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProveeedorProducto_proveedores1` FOREIGN KEY (`proveedores_id`) REFERENCES `proveedores` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
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
INSERT INTO `sucursales` VALUES  (1,18,3,NULL,2,'2011-02-11 00:02:07',1,12345),
 (2,19,2,NULL,2,'2011-02-02 22:29:15',1,0);
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;


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
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from compras m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO compras(facturacompra,idproveedor,fechacompra,idsucursal,totalcompra,usu,fmodif)

  VALUES(facturacompra,idproveedor,fechacompra,idsucursal,totalcompra,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE compras c set
        c.facturacompra=facturacompra,
        c.idsucursal=idsucursal,
        c.idproveedor=idproveedor,
        c.fechacompra=fechacompra,
        c.totalcompra=totalcompra,
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

set @campos= concat( @campos," * ");

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

  CALL Inventarios_Triggers(idsucursal,idproducto,(cantidad * -1),usu,fmodif);


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

set @campos= concat( @campos," m.*,s.*,mo.descripcion as descricpionmodelos , ma.descripcion as descripcionmarcas ");

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

id int(11),
imagen longblob,
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from motocilectasimgenes c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO productosimagenes (id,imagen,usu,fmodif)
  VALUES(id,imagen,usu,fmodif);


else

  UPDATE motocilectasimgenes c set
        c.imagen= imagen,
        c.usu=usu,
        c.fmodif = fmodif
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
