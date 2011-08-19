DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`CuentaCorriente_Buscar` $$
CREATE PROCEDURE `sico`.`CuentaCorriente_Buscar` (

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

DELIMITER ;