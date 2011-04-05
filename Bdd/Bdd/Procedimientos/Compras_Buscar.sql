DELIMITER $$

DROP PROCEDURE IF EXISTS `Compra_Buscar` $$
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

DELIMITER ;