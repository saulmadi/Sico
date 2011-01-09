DELIMITER $$

DROP PROCEDURE IF EXISTS `Marcas_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Marcas_Mant`(

/*definicion de parametros*/

inout id int,
descripcion nvarchar(45),
habilitado int,
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from Marcas m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO Marcas(descripcion,habilitado,usu,fmodif)

  VALUES(descripcion,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE Marcas c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;


END $$

DELIMITER ;