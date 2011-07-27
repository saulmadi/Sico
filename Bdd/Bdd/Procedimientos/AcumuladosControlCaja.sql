DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`AcumuladosControlCaja` $$
CREATE PROCEDURE `sico`.`AcumuladosControlCaja` (

/*defiicion de parametros*/
id nvarchar(11),
idtransacciones nvarchar(150),
fecha nvarchar(200),
cajero nvarchar(11),
idsucursales nvarchar(11),
tipo nvarchar(1)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select c.id as id, sum(c.monto) as monto, t.descripcion as descripcion ";
set @from="  ";
set @where=" where 1=1 ";
set @sql="";
set @group=" group by idtransaccionescaja ";

set @from= concat(@from," from controlcaja c ");

set @join = (" join transaccionescaja t  on c.idtransaccionescaja=t.id");

/*defiicion de filtros*/

if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if cajero<>"" then
  set @where= concat(@where, " and c.cajero = ", cajero, " ");
end if;

if idtransacciones<>"" then
  set @where = concat(@where, " and c.idtransaccionescaja = ",idtransacciones, " ");
end if;

if fecha<>"" then
  set @join = concat(@join, " and ",fecha, " ");
end if;

if idsucursales<>"" then
  set @where = concat(@where, " and c.idsucursales = ",idsucursales, " ");
end if;

if tipo<>"" then
  set @where = concat(@where, " and t.tipo = '",tipo, "' ");
end if;


set @sql = concat(@campos,@from,@join,@where,@group);



/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;



END $$

DELIMITER ;