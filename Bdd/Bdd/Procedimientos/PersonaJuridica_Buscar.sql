DELIMITER $$

DROP PROCEDURE IF EXISTS `PersonaJuridica_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PersonaJuridica_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
razonsocial nvarchar(120),
razonsocialigual nvarchar(120),
rtn nvarchar(18)
)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by razonsocial ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from personasjuridicas ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and id = ", id, " ");
end if;

if razonsocial<>"" then
  set @where = concat(@where, " and razonsocial like '",razonsocial, "%' ");
end if;

if razonsocialigual<>"" then
  set @where = concat(@where, " and razonsocial = '",razonsocialigual, "' ");
end if;

if rtn<>"" then
  set @where = concat(@where, " and rtn = '",rtn,"' ");
end if;

set @sql = concat(@campos,@from,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$

DELIMITER ;