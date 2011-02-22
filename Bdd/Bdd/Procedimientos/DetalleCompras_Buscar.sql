DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`DetalleCompras_Buscar` $$
CREATE PROCEDURE `sico`.`DetalleCompras_Buscar` (


id nvarchar(11),
idcompras nvarchar(11),
idproducto nvarchar(11)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from detallecompras");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if idcompras<>"" then
  set @where= concat(@where, " and idcompras = ", idcompras, " ");
end if;


if idproducto<>"" then
  set @where= concat(@where, " and idproducto = ", idproducto, " ");
end if;




set @sql = concat(@campos,@from,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;