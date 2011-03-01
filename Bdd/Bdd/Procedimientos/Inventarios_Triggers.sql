﻿DELIMITER $$

DROP PROCEDURE IF EXISTS `Inventarios_Triggers` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Inventarios_Triggers`(

idsucursales int,
idproductos int,
cantidad int,
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(0) from inventario m where m.idsucursales = idsucursales and m.idproductos = idproductos  into @conteo;

if @conteo =0 then

  INSERT INTO inventario(idsucursales,idproductos,cantidad,usu,fmodif)

  VALUES(idsucursales,idproductos,cantidad,usu,fmodif);


else

  UPDATE inventario c set
        c.cantidad=c.cantidad + cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.idsucursales=idsucursales and c.idproductos = idproductos;

end if;
END $$

DELIMITER ;