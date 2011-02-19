DELIMITER $$

DROP PROCEDURE IF EXISTS `Inventario_Buscar` $$
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

DELIMITER ;