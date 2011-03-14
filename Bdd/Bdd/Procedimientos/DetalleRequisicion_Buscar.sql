DELIMITER $$

DROP PROCEDURE IF EXISTS `DetalleRequisicion_Buscar` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleRequisicion_Buscar`(


id nvarchar(11),
idrequisicion nvarchar(11),
idproducto nvarchar(11)

)
BEGIN

set @Campos="select ";
set @from=" ";
set @where=" where 1=1 ";
set @orden= "order by id ";
set @join = "join vproductos p on d.idproducto=p.idproducto ";
set @sql="";

set @campos= concat( @campos," * ");

set @from= concat(@from," from detallerequisicion d ");



if id<>"" then
  set @where= concat(@where, " and d.id = ", id, " ");
end if;


if idrequisicion<>"" then
  set @where= concat(@where, " and d.idrequisicion = ", idrequisicion, " ");
end if;


if idproducto<>"" then
  set @where= concat(@where, " and d.idproducto = ", idproducto, " ");
end if;




set @sql = concat(@campos,@from,@join,@where,@orden);


PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;