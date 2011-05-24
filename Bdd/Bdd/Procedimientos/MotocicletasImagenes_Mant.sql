DELIMITER $$

DROP PROCEDURE IF EXISTS `MotocicletasImagenes_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `MotocicletasImagenes_Mant`(

/*definicion de parametros*/

id int(11),
imagen longblob,
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from motocicletasimagenes c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO motocicletasimagenes (id,imagen,usu,fmodif)
  VALUES(id,imagen,usu,fmodif);


else

  UPDATE motocicletasimagenes c set
        c.imagen= imagen,
        c.usu=usu,
        c.fmodif = fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;