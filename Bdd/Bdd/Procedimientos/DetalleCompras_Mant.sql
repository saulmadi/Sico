DELIMITER $$

DROP PROCEDURE IF EXISTS `DetalleCompras_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleCompras_Mant`(

/*definicion de parametros*/

inout id int,
idcompras int,
idproducto int,
cantidad int,
preciocompra decimal(16,2),
idsucursal int,
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detallecompras m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detallecompras(idcompras,idproducto,cantidad,preciocompra,idsucursal,usu,fmodif)

  VALUES(idcompras,idproducto,cantidad,preciocompra,idsucursal,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE detallecompras c set
        c.idcompras=idcompras,
        c.idproducto=idproducto,
        c.cantidad=cantidad,
        c.preciocompra=preciocompra,
        c.idsucursal=idsucursal,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;