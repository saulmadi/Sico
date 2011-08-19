DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`CuentaCorriente_Mant` $$
CREATE PROCEDURE `CuentaCorriente_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(70),
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


set @conteo =0;
select count(id) from cuentacorriente m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from cuentacorriente into @correlativo;

  select CrearCorrelativoCodigo("CC",idsucursal,elaboradopor,@correlativo) into codigo;

  INSERT INTO cuentacorriente(codigo,identidaddeudora,identidadbeneficiaria,estado,idsucursales,fecha,habilitado,usu,fmodif)

  VALUES(codigo,identidaddeudora,identidadbeneficiaria,estado,idsucursales,fecha,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE cuentacorriente c set
        c.identidaddeudora=identidaddeudora,
        c.identidadbeneficiaria=identidadbeneficiaria,
        c.estado=estado,
        c.idsucursales=idsucursales,
        c.fech=fecha,
        c.habilitado=habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;