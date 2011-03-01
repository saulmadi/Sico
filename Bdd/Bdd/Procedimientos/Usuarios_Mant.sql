DELIMITER $$

DROP PROCEDURE IF EXISTS `Usuarios_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Usuarios_Mant`(

/*definicion de parametros*/

inout id int,
identidades int,
contrasena nvarchar(8000),
usuario nvarchar(45),
estado int(1),
idrol int,
idsucursales int,
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from usuarios c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO usuarios (identidades,contrasena,usuario,idrol,estado,idsucursales,usu,fmodif)

  VALUES(identidades,contrasena,usuario,idrol,estado,idsucursales,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE usuarios c set
        c.identidades= identidades,
        c.contrasena=contrasena,
        c.usuario = usuario,
        c.idrol=idrol,
        c.idsucursales=idsucursales,
        c.usu=usu,
        c.fmodif=fmodif,
        c.estado=estado

  where c.id= id;

end if;
END $$

DELIMITER ;