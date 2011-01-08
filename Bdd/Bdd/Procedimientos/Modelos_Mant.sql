DELIMITER $$

DROP PROCEDURE IF EXISTS `Modelos_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Modelos_Mant`(

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
select count(id) from modelos  where id=id into @conteo;

if @conteo =0 then

  INSERT INTO modelos(descripcion,habilitado,idderivada,usu,fmodif)

  VALUES(descripcion,habilitado,idderivada,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE modelos c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.idderivada= idderivada,
        c.usu=usu,
        c.fmodif=fmodif
  where e.id= id;

end if;


END $$

DELIMITER ;