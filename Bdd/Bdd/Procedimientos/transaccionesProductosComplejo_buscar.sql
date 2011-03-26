DELIMITER $$

DROP PROCEDURE IF EXISTS `TransaccionesProductosComplejo_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TransaccionesProductosComplejo_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
idproductos nvarchar(11),
idsucursales nvarchar(11),
tabla nvarchar(500),
campos nvarchar(500),
parametro nvarchar(500)

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

set @campos= concat( @campos," ",campos," ");

set @from= concat(@from," from inventario i ");

set @join=concat(@join," ",tabla," ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and t.id = ", id, " ");
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
if parametro<>"" then
  set @where= concat(@where," and ",parametro ,"   ");
end if;






set @sql = concat(@campos,@from,@join,@where,@group,@orden);


/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;