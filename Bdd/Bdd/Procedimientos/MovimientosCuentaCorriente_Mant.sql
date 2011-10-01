DROP PROCEDURE IF EXISTS sico.MovimientoCuentaCorriente_Mant;
CREATE PROCEDURE sico.`MovimientoCuentaCorriente_Mant`(

INOUT id int(11),
idcuentacorriente int(11),
idtipomovimiento int(11),
monto decimal(18,2),
fechavencimiento date,
fecha date,
descripcion nvarchar(200),
idrubro int(11),
usu int(11),
fmodif datetime
)
BEGIN

DECLARE habil int(1) DEFAULT 0;
SET @conteo =0;
SELECT count(id) FROM movimientoscuentacorriente m WHERE m.id=id INTO @conteo;

SELECT c.habilitado FROM cuentacorriente c where c.id=idcuentacorriente INTO habil;
IF habil =1 THEN
  IF @conteo =0 THEN

    INSERT INTO movimientoscuentacorriente(idcuentacorriente,idtipomovimiento,monto,fechavencimiento,
                                           fecha, descripcion, idrubro,usu,fmodif)

    VALUES(idcuentacorriente,idtipomovimiento,monto,fechavencimiento,
                                           fecha, descripcion,idrubro,usu,fmodif);

    SELECT last_insert_id() INTO id;

  ELSE

    UPDATE movimientoscuentacorriente c SET
          c.idcuentacorriente=idcuentacorriente,
          c.idtipomovimiento=idtipomovimiento,
          c.monto=monto,
          c.fechavencimiento=fechavencimiento,
          c.fecha=fecha,
          c.descripcion=descripcion,
          c.idrubro=idrubro,
          c.usu=usu,
          c.fmodif=fmodif
    WHERE c.id= id;
   END IF;
else 
  set id=0;
END IF;
END;
