DELIMITER $$

DROP PROCEDURE IF EXISTS `PersonaNatural_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PersonaNatural_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
nombrecompleto nvarchar(125),
identificacion nvarchar(45),
rtn nvarchar(18) 

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by NombreCompleto ";
set @sql="";

set @campos= concat( @campos," * ");


set @from= concat(@from," from personasnaturales ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if nombrecompleto<>"" then
  set @where = concat(@where, " and NombreCompleto like '",nombrecompleto, "%' ");
end if;

if identificacion<>"" then
  set @where = concat(@where, " and identificacion = '",identificacion,"' ");
end if;

if rtn<>"" then
  set @where = concat(@where, " and rtn = '",rtn,"´' ");
end if;



set @sql = concat(@campos,@from,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$

DELIMITER ;