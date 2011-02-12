DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`ProductosImagenes_Mant` $$
CREATE PROCEDURE `sico`.`ProductosImagenes_Mant` (

/*definicion de parametros*/

id int,
imagen longblob,
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from productosimagenes c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO productosimagenes (id,imagen,usu,fmodif)
  VALUES(id,imagen,usu,fmodif);


else

  UPDATE productosimagenes c set
        c.imagen= imagen,
        c.usu=usu,
        c.fmodif = fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;