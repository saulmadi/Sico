DROP PROCEDURE IF EXISTS sico.AgregarCuentaPropietario;
CREATE PROCEDURE sico.`AgregarCuentaPropietario`(identidad           int(11),
                                          fechavencimiento    date,
                                          monto               decimal(18,2),
                                          descripcion         nvarchar(200),
                                          idrubro             int(11),
                                          idsucursal          int(11),
                                          idtipomonto         int(11),
                                          usu                 int(11),
                                          INOUT idcuentacorriente int(11),
                                          INOUT codigoCuentaCorriente nvarchar(70),
                                          INOUT idmovimento int(11))
BEGIN
      DECLARE idpropietario           int(11) DEFAULT 0;
      DECLARE esnatural           int(1) DEFAULT 0;
      SET codigoCuentaCorriente='';
      SET idcuentacorriente = 0;
      SET idmovimento=0;

      SELECT t.identidades
        FROM propietario t
        INTO idpropietario;

      SELECT e.espersonanatural
      FROM entidades e
      WHERE e.id = identidad INTO  esnatural;

      IF esnatural=1 THEN

        IF idpropietario>0 THEN
          SELECT id FROM cuentacorriente cuenta
            WHERE cuenta.identidaddeudora=identidad AND cuenta.identidadbeneficiaria= idpropietario
            INTO idcuentacorriente;

          IF idcuentacorriente=0 THEN
            CALL CuentaCorriente_Mant(idcuentacorriente,
                                      codigoCuentaCorriente,
                                      identidad,
                                      idpropietario,
                                      'A',
                                      idsucursal,
                                      curdate(),
                                      1,
                                       usu,
                                      now());
        END IF;

          IF idcuentacorriente>0 THEN

              CALL MovimientoCuentaCorriente_Mant(idmovimento,
                                                  idcuentacorriente,
                                                  idtipomonto,
                                                  monto,
                                                  fechavencimiento,
                                                  curdate(),
                                                  descripcion,
                                                  idrubro,
                                                  usu,
                                                  now());
        END IF;

        END IF;

      END IF;
END;