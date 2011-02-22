DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`Compra_Buscar` $$
CREATE PROCEDURE `sico`.`Compra_Buscar` (


id nvarchar(11),
facturacompra nvarchar(11),
idproveedor nvarchar(11),
fechacompra nvarchar(11)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from compras");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if facturacompra<>"" then
  set @where= concat(@where, " and facturacompra = ", facturacompra, " ");
end if;


if idproveedor<>"" then
  set @where= concat(@where, " and idproveedor = ", idproveedor, " ");
end if;

if fechacompra<>"" then
  set @where= concat(@where, " and ", fechacompra, " ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$

DELIMITER ;