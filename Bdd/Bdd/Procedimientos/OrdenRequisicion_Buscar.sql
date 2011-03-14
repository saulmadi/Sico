DELIMITER $$

DROP PROCEDURE IF EXISTS `OrdenRequisicion_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenRequisicion_Buscar`(

id nvarchar(11),
codigo nvarchar(70),
codigoparecido nvarchar(70),
sucursalenvia nvarchar(11),
sucursalrecibe nvarchar(11),
estado nvarchar(11),
fechaemision nvarchar(150)
)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from ordenescompras");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if codigo<>"" then
  set @where= concat(@where, " and codigo = '", codigo, "' ");
end if;

if codigoparecido<>"" then
  set @where= concat(@where, " and codigo like '", codigo, "%' ");
end if;

if sucursalenvia<>"" then
  set @where= concat(@where, " and sucursalenvia = ", sucursalenvia, " ");
end if;

if sucursalrecibe<>"" then
  set @where= concat(@where, " and sucursalrecibe = ", sucursalrecibe, " ");
end if;

if estado<>"" then
  set @where= concat(@where, " and estado = '", estado, "' ");
end if;


if fechaemision<>"" then
  set @where= concat(@where, " and ", fechaemision, " ");
end if;


set @sql = concat(@campos,@from,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$

DELIMITER ;