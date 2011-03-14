DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`DetalleRequisicion_Mant` $$
CREATE PROCEDURE `sico`.`DetalleRequisicion_Mant` (

/*definicion de parametros*/

inout id int(11),
idrequisicion int(11),
idproducto int(11),
cantidad int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detallerequisicion m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detallerequisicion(idrequisicion,idproducto,cantidad,usu,fmodif)

  VALUES(idrequisicion,idproducto,cantidad,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE detallerequisicion c set
        c.idrequisicion=idrequisicion,
        c.idproducto=idproducto,
        c.cantidad=cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;