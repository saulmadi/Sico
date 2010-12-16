DELIMITER $$

DROP PROCEDURE IF EXISTS `PersonaJuridica_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PersonaJuridica_Mant`(

/*definicion de parametros*/

inout id int,
telefono int,
direccion varchar(150),
correo varchar (45),
rtn int(18),
nombre varchar(55),
razonsocial varchar(70),
usu int,
fmodif date,
inout Accion bool
)
BEGIN

call Entidades_Mant(id,telefono,direccion,correo,false,rtn,usu,fmodif);


set @conteo =0;
select count(PN.id) from personajuridica pn where pn.id=id into @conteo;

set @pj=0;
select count(pj.id) from personanatural pj where pj.id=id into @pj;

if @pj=0 then

if @conteo =0 then

  insert into personajuridica(id,razonsocial,usu,fmodif)
  values(id,razonsocial,usu,fmodif);

else

  update personajuridica PJ set
    pj.id=id,
    pj.razonsocial=razonsocial,
    pj.usu=usu,
    pj.fmodif=fmodif
  where pj.id=id;

end if;

select true into Accion;

end if;


END $$

DELIMITER ;