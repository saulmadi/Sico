DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`ControlCaja_Mant` $$
CREATE PROCEDURE `sico`.`ControlCaja_Mant` (

/*definicion de parametros*/

inout id int(11),
idtransaccionescaja nvarchar(18),
idsucursales int(11),
monto decimal(18,2),
fecha datetime,
cajero int(11),
descripcion nvarchar(500),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from controlcaja m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO controlcaja(idtransaccionescaja,monto,fecha,cajero,idsucursales,descripcion,usu,fmodif)

  VALUES(idtransaccionescaja,monto,fecha,cajero,idsucursales,descripcion,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE controlcaja c set
        c.idtransaccionescaja=idtransaccionescaja,
        c.idsucursales=idsucursales,
        c.monto=monto,
        c.fecha=fecha,
        c.cajero=cajero,
        c.descripcion=descripcion,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;