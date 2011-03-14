DELIMITER $$

DROP PROCEDURE IF EXISTS `OrdenCompra_Buscar` $$
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
  set @where= concat(@where, " and idproveedor = ", idproveedor, " ");
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

DELIMITER ;