DELIMITER $$

DROP PROCEDURE IF EXISTS `Entidades_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Entidades_Mant`(

/*definicion de parametros*/

inout id int,
telefono int,
direccion varchar(150),
correo varchar (45),
espersonanatural bool,
rtn varchar(18),
entidadnombre varchar(120),
identificacion varchar(45),
tipoidentidad varchar(1),
telefono2 int,
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(e.id) from entidades E where E.id=id into @conteo;

if @conteo =0 then

  INSERT INTO entidades(telefono, direccion,correo,espersonanatural, RTN, usu,fmodif,entidadnombre,identificacion,tipoidentidad,telefono2)

  VALUES(telefono,direccion,correo,espersonanatural,rtn,usu,fmodif,entidadnombre,identificacion,tipoidentidad,telefono2);

  select last_insert_id() into id;

else

  UPDATE entidades e SET
        e.telefono=telefono,
        e.direccion=direccion,
        e.correo=correo,
        e.espersonanatural= espersonanatural,
        e.RTN= rtn,
        e.usu=usu,
        e.fmodif= fmodif,
        e.entidadnombre=entidadnombre,
        e.identificacion=identificacion,
        e.tipoidentidad=tipoidentidad,
        e.telefono2=telefono2
  where e.id= id;

end if;


END $$

DELIMITER ;