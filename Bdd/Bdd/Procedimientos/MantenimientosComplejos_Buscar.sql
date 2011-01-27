DELIMITER $$

DROP PROCEDURE IF EXISTS `MantenimientosComplejos_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `MantenimientosComplejos_Buscar`(

/*defiicion de parametros*/
id nvarchar(11),
identidades nvarchar(11),
entidadnombre nvarchar(120),
espersonanatural nvarchar(1),
usuario nvarchar(45),
contrasena nvarchar(30),
tabla nvarchar(25)
)
BEGIN
/*defiicion de consulta*/
set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by c.id ";
set @join = " ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from ", tabla,"  c ");


/*defiicion de filtros*/
if id<>"" then
  set @where= concat(@where, " and c.id = ", id, " ");
end if;

if identidades<>"" then
  set @where = concat(@where, " and c.identidades = ",identidades," ");
end if;

if usuario<>"" and contrasena<> "" then
  set @where = concat(@where, " and c.usuario = '",usuario,"' and contrasena = '",contrasena,"' ");
end if;


if entidadnombre<>"" and espersonanatural <>""  then
  set @where = concat(@where, " and   e.entidadnombre like'",entidadnombre, "%' ");
end if;

if espersonanatural <>"" then
  set @join= concat(@join, " inner join ventidades e on e.IdEntidad=c.identidades and espersonanatural = ",espersonanatural);
else
  set @join= concat(@join," inner join ventidades e on e.IdEntidad=c.identidades");
end if;

set @sql = concat(@campos,@from,@join,@where,@orden);

/*ejecucion de consulta*/
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;


END $$

DELIMITER ;