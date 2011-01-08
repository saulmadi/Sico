DELIMITER $$

DROP PROCEDURE IF EXISTS `TiposMotocicletas_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TiposMotocicletas_Mant`(

/*definicion de parametros*/

inout id int,
descripcion nvarchar(45),
habilitado bool,
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from tiposmotocicletas  where id=id into @conteo;

if @conteo =0 then

  INSERT INTO tiposmotocicletas(descripcion,habilitado,usu,fmodif)

  VALUES(descripcion,habilitado,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE tiposmotocicletas c set
        c.descripcion= descripcion,
        c.habilitado =habilitado,
        c.usu=usu,
        c.fmodif=fmodif
  where e.id= id;

end if;


END $$

DELIMITER ;