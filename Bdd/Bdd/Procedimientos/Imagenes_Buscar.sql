DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`Imagenes_Buscar` $$
CREATE PROCEDURE `sico`.`Imagenes_Buscar` (

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

DELIMITER ;