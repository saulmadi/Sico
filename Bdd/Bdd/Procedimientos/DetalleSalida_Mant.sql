DELIMITER $$

DROP PROCEDURE IF EXISTS `DetalleSalida_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleSalida_Mant`(
/*definicion de parametros*/

inout id int(11),
idsucursal int(11),
idsalida int(11),
idproducto int(11),
cantidad int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detallesalida m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detallesalida(idsalida,idproducto,cantidad,usu,fmodif)

  VALUES(idsalida,idproducto,cantidad,usu,fmodif);

  /*CALL Inventarios_Triggers(idsucursal,idproducto,(cantidad * -1),usu,fmodif);*/


  select last_insert_id() into id;

else

  UPDATE detallesalida c set
        c.idsalida=idsalida,
        c.idproducto=idproducto,
        c.cantidad=cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;