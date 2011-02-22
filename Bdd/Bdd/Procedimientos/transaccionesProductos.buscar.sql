DELIMITER $$

DROP PROCEDURE IF EXISTS `TransaccionesProductos_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TransaccionesProductos_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
idproductos nvarchar(11),
idsucursales nvarchar(11),
descripcion nvarchar(45),
inventarioTotal nvarchar(1),
codigo nvarchar(45)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by descripcion ";
set @join = "join vproductos p on p.idproducto = i.idproductos";
set @sql="";
set @group = "";

set @campos= concat( @campos," * ");

set @from= concat(@from," from inventario i ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and i.id = ", id, " ");
end if;

/*defiicion de filtros*/
if idproductos<>"" then
  set @join= concat(@join, " and p.idproducto = ", idproductos, " ");
end if;

/*defiicion de filtros*/
if idsucursales<>"" then
  set @join= concat(@join, " and i.idsucursales = ", idsucursales, " ");
end if;

/*defiicion de filtros*/
if codigo<>"" then
  set @join= concat(@join, " and p.codigo = '", codigo, "'  ");
end if;

/*defiicion de filtros*/
if descripcion<>"" then
  set @join= concat(@join, " and p.descripcion like '", descripcion, "%'  ");
end if;


/*defiicion de filtros*/
if descripcion<>"" then
  set @join= concat(@join, " and p.descripcion like '", descripcion, "%'  ");
end if;

/*defiicion de filtros*/
if inventarioTotal<>"" then
    set @campos= "select i.id,i.usu,i.idsucursales,i.fmodif,idproductos, idproducto,codigo,descripcion, sum(cantidad) as cantidad,precioventa  ";
    set @group = "group by i.idproductos ";
end if;

set @sql = concat(@campos,@from,@join,@where,@group,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;