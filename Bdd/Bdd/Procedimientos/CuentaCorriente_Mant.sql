DROP PROCEDURE IF EXISTS sico.CuentaCorriente_Mant;
CREATE PROCEDURE sico.`CuentaCorriente_Mant`(



INOUT id int(11),
INOUT codigo nvarchar(70),
identidaddeudora int(11),
identidadbeneficiaria int(11),
estado nvarchar(5),
idsucursales int(11),
fecha date,
habilitado int(1),
usu int(11),
fmodif datetime
)
BEGIN


SET @conteo =0;
SELECT count(id) FROM cuentacorriente m WHERE m.id=id INTO @conteo;
IF @conteo =0 THEN

    SELECT count(id) FROM cuentacorriente m
    WHERE m.identidadbeneficiaria = identidadbeneficiaria AND m.identidaddeudora = identidaddeudora INTO @conteo;

    IF @conteo >0 THEN
      SELECT id FROM cuentacorriente m
      WHERE m.identidadbeneficiaria = identidadbeneficiaria AND m.identidaddeudora = identidaddeudora INTO id;
    END IF;


END IF;

IF @conteo =0 THEN


  SELECT CrearCorrelativoCodigo("CC",idsucursal,elaboradopor) INTO codigo;

  INSERT INTO cuentacorriente(codigo,identidaddeudora,identidadbeneficiaria,estado,idsucursales,fecha,habilitado,usu,fmodif)

  VALUES(codigo,identidaddeudora,identidadbeneficiaria,estado,idsucursales,fecha,habilitado,usu,fmodif);

  SELECT last_insert_id() INTO id;

ELSE

  UPDATE cuentacorriente c SET
        c.identidaddeudora=identidaddeudora,
        c.identidadbeneficiaria=identidadbeneficiaria,
        c.estado=estado,
        c.idsucursales=idsucursales,
        c.fech=fecha,
        c.habilitado=habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  WHERE c.id= id;

END IF;

END;