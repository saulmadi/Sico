DELIMITER $$

DROP PROCEDURE IF EXISTS `Productos_Buscar` $$
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

DELIMITER ;