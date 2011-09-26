DROP PROCEDURE IF EXISTS sico.AgregarCuentaPropietario;
CREATE PROCEDURE sico.`AgregarCuentaPropietario`(identidad           int(11),
                                          fechavencimiento    date,
                                          monto               decimal,
                                          descripcion         nvarchar(250),
                                          idrubro             int(11),
                                          idsucursal          int(11),
                                          usu                 int(11),
                                          INOUT idcuentacorriente int(11),
                                          INOUT codigoCuentaCorriente nvarchar(70),
                                          INOUT idmovimento int(11))
BEGIN
      DECLARE idpropietario           int(11) DEFAULT 0;
      SET codigoCuentaCorriente='';
      SET idcuentacorriente = 0;
      SET idmovimento=0;

      SELECT t.identidades
        FROM propietario t
        INTO idpropietario;

      IF idpropietario>0 THEN
        CALL CuentaCorriente_Mant( idcuentacorriente,                                                                                                     idcuentacorriente,
                                   codigoCuentaCorriente,
                                  identidad,
                                  idpropietario,
                                  'A',
                                  idsucursal,
                                  curdate(),
                                  1,
                                  usu,
                                  now());
                                  
        if idcuentacorriente>0 then

              call MovimientoCuentaCorriente_Mant( idmovimento,
                                                  idcuentacorriente,
                                                  1,
                                                  monto,
                                                  fechavencimiento,
                                                  fecha,
                                                  descripcion,
                                                  idrubro,
                                                  usu,
                                                  now());
        end if;

       END IF;
END;