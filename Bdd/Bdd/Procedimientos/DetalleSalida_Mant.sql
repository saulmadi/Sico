DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`DetalleSalida_Mant` $$
CREATE PROCEDURE `sico`.`DetalleSalida_Mant` (
/*definicion de parametros*/

inout id int(11),
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