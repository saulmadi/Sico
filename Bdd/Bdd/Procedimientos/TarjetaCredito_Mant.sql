DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`TarjetaCredito_Mant` $$
CREATE PROCEDURE `sico`.`TarjetaCredito_Mant` (

/*definicion de parametros*/

inout id int(11),
descripcion nvarchar(45),
habilitado int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from tarjetacredito m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO tarjetacredito(descripcion,habilitado,usu,fmodif)

  VALUES(descripcion,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE tarjetacredito c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;