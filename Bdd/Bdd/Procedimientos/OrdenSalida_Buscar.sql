DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`OrdenSalida_Buscar` $$
CREATE PROCEDURE `sico`.`OrdenSalida_Buscar` (

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

set @join=" join vsucursal v on v.idsucursal = o.sucursalenvia join vsucursal vr on vr.idsucursal= o.sucursalrecibe ";

set @campos= concat( @campos," o.*, v.idsucursal idsucursalenvia, v.identidades as identidadesenvia, v.descripcion as descripcionenvia, vr.idsucursal idsucursalrecibe, vr.identidades as identidadesrecibe, vr.descripcion as descripcionrecibe  ");

set @from= concat(@from," from ordensalida o ");



if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if codigo<>"" then
  set @where= concat(@where, " and codigo = '", codigo, "' ");
end if;

if codigoparecido<>"" then
  set @where= concat(@where, " and codigo like '", codigoparecido, "%' ");
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


set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;