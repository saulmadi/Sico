DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`MovimientoCuentaCorriente_Mant` $$
CREATE PROCEDURE `sico`.`MovimientoCuentaCorriente_Mant` (

inout id int(11),
idcuentacorriente nvarchar(18),
idtipomovimiento int(11),
monto decimal(18,2),
fechavencimiento date,
fecha datetime,
descripcion nvarchar(500),
idrubro int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from movimientoscuentacorriente m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO movimientoscuentacorriente(idcuentacorriente,idtipomovimiento,monto,fechavencimiento,
                                         fecha, descripcion, idrubro,usu,fmodif)

  VALUES(idcuentacorriente,idtipomovimiento,monto,fechavencimiento,
                                         fecha, descripcion,idrubro,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE movimientoscuentacorriente c set
        c.idcuentacorriente=idcuentacorriente,
        c.idtipomovimiento=idtipomovimiento,
        c.monto=monto,
        c.fechavencimiento=fechavencimiento,
        c.fecha=fecha,
        c.descripcion=descripcion,
        c.idrubro=idrubro,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;
end if;
END $$

DELIMITER ;