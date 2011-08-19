DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`Propietario_Buscar` $$
CREATE PROCEDURE `sico`.`Propietario_Buscar` (

/*defiicion de parametros*/
id nvarchar(11),
identidades nvarchar(11),
entidadnombre nvarchar(120)

)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " inner join ventidades e on e.IdEntidad=c.identidades ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from propietario c ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if identidades<>"" then
  set @where = concat(@where, " and c.identidades = ",identidades," ");
end if;

if entidadnombre<>""  then
  set @where = concat(@where, " and   e.entidadnombre like'",entidadnombre, "%' ");
end if;


set @sql = concat(@campos,@from,@join,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$

DELIMITER ;