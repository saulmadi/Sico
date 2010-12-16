DELIMITER $$

DROP PROCEDURE IF EXISTS `Entidades_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Entidades_Mant`(

/*definicion de parametros*/

inout id int,
telefono int,
direccion varchar(150),
correo varchar (45),
espersonanatural bool,
rtn int(18),
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(e.id) from entidades E where E.id=id into @conteo;

if @conteo =0 then

  INSERT INTO entidades(telefono, direccion,correo,espersonanatural, RTN, usu,fmodif)

  VALUES(telefono,direccion,correo,espersonanatural,rtn,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE entidades e SET
        e.telefono=telefono,
        e.direccion=direccion,
        e.correo=correo,
        e.espersonanatural= espersonanatural,
        e.RTN= rtn,
        e.usu=usu,
        e.fmodif= fmodif
  where e.id= id;

end if;


END $$

DELIMITER ;