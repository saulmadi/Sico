DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`DetalleCompras_Mant` $$
CREATE PROCEDURE `sico`.`DetalleCompras_Mant` (

/*definicion de parametros*/

inout id int,
idcompras int,
idproducto int,
cantidad int,
preciocompra decimal(10,2),
idsucursal int,
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detallecompras m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detallecompras(idcompras,idproducto,cantidad,preciocompra,idsucursal,usu,fmodif)

  VALUES(idcompras,idproductos,cantidad,preciocompra,idsucursal,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE detallecompras c set
        c.idcompras=idcompras,
        c.idproductos=idproductos,
        c.cantidad=cantidad,
        c.preciocompra=preciocompra,
        c.idsucursal=idsucursal,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;