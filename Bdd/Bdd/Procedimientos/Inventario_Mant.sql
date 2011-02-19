DELIMITER $$

DROP PROCEDURE IF EXISTS `Inventario_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Inventario_Mant`(

/*definicion de parametros*/

inout id int,
idsucursales int,
idproductos int,
cantidad int,
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from inventario m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO inventario(idsucursales,idproductos,cantidad,usu,fmodif)

  VALUES(idsucursales,idproductos,cantidad,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE inventario c set
        c.idsucursales=idsucursales,
        c.idproductos=idproductos,
        c.cantidad= cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;