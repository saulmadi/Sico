DELIMITER $$

DROP PROCEDURE IF EXISTS `Mantenimientos_Buscar` $$
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

DELIMITER ;