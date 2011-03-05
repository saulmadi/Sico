DELIMITER $$

DROP PROCEDURE IF EXISTS `DetalleOrden_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DetalleOrden_Mant`(

/*definicion de parametros*/

inout id int,
idordencompra int,
idproducto int,
cantidad int,
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from detalleorden m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO detalleorden(idordencompra,idproducto,cantidad,usu,fmodif)

  VALUES(idordencompra,idproducto,cantidad,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE detalleorden c set
        c.idordencompra=idordencompra,
        c.idproducto=idproducto,
        c.cantidad=cantidad,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;