DELIMITER $$

DROP PROCEDURE IF EXISTS `Proveedores_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proveedores_Mant`(

/*definicion de parametros*/

inout id int,
identidades int,
idcontacto int,
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(c.id) from proveedores c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO proveedores(identidades,idcontacto,usu,fmodif)

  VALUES(identidades,idcontacto,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE proveedores c set
        c.identidades= identidades,
        c.idcontacto=idcontacto,
        c.usu=usu,
        c.fmodif=fmodif
  where e.id= id;

end if;


END $$

DELIMITER ;