DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`ControlCajaFactura_Mant` $$
CREATE PROCEDURE `sico`.`ControlCajaFactura_Mant` (

/*definicion de parametros*/

inout id int(11),
idfacturaencabezado int(11),
idcontrolcaja int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from controlcajafactura m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO controlcajafactura(idfacturaencabezado,idcontrolcaja,usu,fmodif)

  VALUES(idfacturaencabezado,idcontrolcaja,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE controlcajafactura c set
        c.idfacturaencabezado=idfacturaencabezado,
        c.idcontrolcaja=idcontrolcaja,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;