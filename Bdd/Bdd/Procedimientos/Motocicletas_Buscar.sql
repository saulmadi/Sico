DELIMITER $$

DROP PROCEDURE IF EXISTS `Motocicletas_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Motocicletas_Buscar`(


id nvarchar(11),
idmarca nvarchar(45),
idmodelo nvarchar(45),
motor nvarchar(45),
chasis nvarchar(45),
estado nvarchar(45),
idsucursal nvarchar(45)


)
BEGIN

set @Campos="select  ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by motor ";
set @sql="";
set @join="";
set @join = " inner join marcas ma on m.idmarcas=ma.id
              inner join modelos mo on m.idmodelos=mo.id
              inner join vsucursal s on m.idsucursales= s.idsucursal ";

set @campos= concat( @campos," m.*,s.*,mo.descripcion as descripcionmodelos , ma.descripcion as descripcionmarcas ");

set @from= concat(@from," from motocicletas m ");



if id<>"" then
  set @where= concat(@where, " and m.id = ", id, " ");
end if;

if idmarca<>"" then
  set @where= concat(@where, " and m.idmarcas = ", idmarca, " ");
end if;

if idmodelo<>"" then
  set @where= concat(@where, " and m.idmodelos = ", idmodelo, " ");
end if;

if motor<>"" then
  set @where= concat(@where, " and m.motor = '", motor, "' ");
end if;

if chasis<>"" then
  set @where= concat(@where, " and m.chasis = '", chasis, "' ");
end if;

if idsucursal<>"" then
  set @where= concat(@where, " and m.idsucursales = ", idsucursal, " ");
end if;

if estado<>"" then
  set @where= concat(@where, " and m.estado = '",estado , "' ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);



PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$

DELIMITER ;