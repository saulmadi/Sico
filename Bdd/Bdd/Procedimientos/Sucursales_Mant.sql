DELIMITER $$

DROP PROCEDURE IF EXISTS `Sucursales_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Sucursales_Mant`(

/*definicion de parametros*/

inout id int,
identidades int,
estado int(1),
idusuario int(11),
idmunicipio int(11),
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from sucursales c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO sucursales (identidades,estado,idusuario,idmunicipio,usu,fmodif)

  VALUES(identidades,estado,idusuario,idmunicipio,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE sucursales c set
        c.identidades= identidades,
        c.estado=estado,
        c.idusuario = idusuario,
        c.idmunicipio=idmunicipio,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;