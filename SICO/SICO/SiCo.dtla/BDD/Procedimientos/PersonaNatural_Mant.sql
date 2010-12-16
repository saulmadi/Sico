DELIMITER $$

DROP PROCEDURE IF EXISTS `PersonaNatural_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PersonaNatural_Mant`(

/*definicion de parametros*/

inout id int,
telefono int,
direccion varchar(150),
correo varchar (45),
rtn int(18),
nombre varchar(55),
apellidos varchar(70),
identidad varchar(45),
tipoidentidad varchar(1),
usu int,
fmodif date,
inout Accion bool
)
BEGIN


/*Ingreso en las entidades*/
call Entidades_Mant(id,telefono,direccion,correo,true,rtn,usu,fmodif);


set @conteo =0;
select count(PN.id) from personanatural pn where pn.id=id into @conteo;

set @pj=0;
select count(pj.id) from personajuridica pj where pj.id=id into @pj;

if@pj=0 then
if @conteo =0 then

  INSERT INTO personanatural(id, nombre,apellidos,identidad,usu,fmodif,tipoidentidad)
  VALUES(id,nombre,apellidos,identidad,usu,fmodif,tipoidentidad);

else
  UPDATE personanatural pn SET
        pn.id=id,
        pn.nombre=nombre,
        pn.apellidos= apellidos,
        pn.identidad=identidad,
        pn.tipoidentidad=tipoidentidad,
        pn.usu=usu,
        pn.fmodif= fmodif
  where pn.id= id;

end if;

select true into Accion;

end if;


END $$

DELIMITER ;