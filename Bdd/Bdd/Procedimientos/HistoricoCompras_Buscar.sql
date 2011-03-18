DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`HistoricoCompras_Buscar` $$
CREATE PROCEDURE `sico`.`HistoricoCompras_Buscar` (

id nvarchar(11),
idproducto nvarchar(11),
fechacompra nvarchar(150)
)
BEGIN

set @Campos="select c.id, v.descripcion as proveedor, fechacompra,facturacompra,cantidad, preciocompra ";
set @from=" ";
set @where=" where 1=1 and ";
set @join = "";
set @orden= "order by c.fechacompra desc ";
set @sql="";





set @from= concat(@from," from compras c ");


if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;


if idproducto<>"" then
  set @join= concat(@join, " inner join detallecompras d on d.idcompras=c.id and d.idproducto = ", idproducto, " ");
else
  set @join= concat(@join, " inner join detallecompras d on d.idcompras=c.id  ");
end if;

if fechacompra<>"" then
  set @where= concat(@where,fechacompra,"  " );
end if;

set @join= concat(@join, " inner join vproveedores v on c.idproveedor = v.idproveedor ");

set @sql = concat(@campos,@from,@join,@where,@orden);

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;