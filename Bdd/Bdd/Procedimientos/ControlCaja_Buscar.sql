DELIMITER $$

DROP PROCEDURE IF EXISTS `ControlCaja_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ControlCaja_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
idtransacciones nvarchar(150),
fecha nvarchar(200),
cajero nvarchar(11),
idsucursales nvarchar(11)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @sql="";

set @campos= concat( @campos," c.*, t.descripcion as descripciontransaccion, t.tipo as tipo ");

set @from= concat(@from," from controlcaja c ");

set @join = (" inner join transaccionescaja t on c.idtransaccionescaja=t.id");

/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if cajero<>"" then
  set @where= concat(@where, " and cajero = ", cajero, " ");
end if;

if idtransacciones<>"" then
  set @where = concat(@where, " and idtransaccionescaja = ",idtransacciones, " ");
end if;

if fecha<>"" then
  set @where = concat(@where, " and ",fecha, " ");
end if;

if idsucursales<>"" then
  set @where = concat(@where, " and idsucursales = ",idsucursales, " ");
end if;


set @sql = concat(@campos,@from,@join,@where);


/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END $$

DELIMITER ;