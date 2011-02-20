DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`TransaccionesProductos_Buscar` $$
CREATE PROCEDURE `sico`.`TransaccionesProductos_Buscar` (

/*defiicion de parametros*/
id nvarchar(11),
idproductos nvarchar(11),
idsucursales nvarchar(11),
descripcion nvarchar(45),
codigo nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @join = "join inventario i on p.idproductos = i.idproductos";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from vproductos p ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and i.id = ", id, " ");
end if;

/*defiicion de filtros*/
if idproductos>"" then
  set @join= concat(@join, " and p.idproductos = ", idproductos, " ");
end if;

/*defiicion de filtros*/
if idsucursales>"" then
  set @join= concat(@join, " and i.idsucursales = ", idsucursal, " ");
end if;

/*defiicion de filtros*/
if codigo>"" then
  set @join= concat(@join, " and p.codigo = '", codigo, "'  ");
end if;

/*defiicion de filtros*/
if descripcion>"" then
  set @join= concat(@join, " and p.descripcion like '", descripcion, "%'  ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;