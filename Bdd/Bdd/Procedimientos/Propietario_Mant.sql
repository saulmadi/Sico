DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`Propietario_Mant` $$
CREATE PROCEDURE `sico`.`Propietario_Mant` (

/*definicion de parametros*/

inout id int(11),
identidades int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from propietario m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO propietario(identidades,usu,fmodif)

  VALUES(identidades,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE propietario c set
        c.identidades=identidades,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;