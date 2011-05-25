DELIMITER $$

DROP PROCEDURE IF EXISTS `FacturaEncabezado_Buscar` $$
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

DELIMITER ;