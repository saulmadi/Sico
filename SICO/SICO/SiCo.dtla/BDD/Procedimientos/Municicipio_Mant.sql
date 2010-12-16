DELIMITER $$

DROP PROCEDURE IF EXISTS `Municipios_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Municipios_Mant`(

/*definicion de parametros*/

inout id int,
descripcion nvarchar(45),
habilitado bool,
idderivada int,
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from municipios  where id=id into @conteo;

if @conteo =0 then

  INSERT INTO municipios(descripcion,habilitado,idderivada,usu,fmodif)

  VALUES(descripcion,habilitado,idderivada,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE municipios c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.idderivada= idderivada,
        c.usu=usu,
        c.fmodif=fmodif
  where e.id= id;

end if;


END $$

DELIMITER ;