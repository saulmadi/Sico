DELIMITER $$

DROP PROCEDURE IF EXISTS `Motocicletas_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Motocicletas_Mant`(

/*definicion de parametros*/

inout id int(11),
motor nvarchar(45),
chasis nvarchar(45),
idmarcas int(11),
idmodelos int(11),
idtiposmotocicletas int(11),
idsucursales int(11),
cilindraje int(11),
anio int (4),
precioventa decimal(15,2) ,
precioingreso decimal (15,2),
fechaingreso date,
estado nvarchar(5),
hp int(11),
idproveedor int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from motocicletas c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO motocicletas(motor,chasis,idmarca,idmodelos,idtiposmotocicletas,idsucursales,cilindraje
                           ,anio,precioventa,precioingreso,estado,hp,idproveedor,usu,fmodif)

  VALUES(motor,chasis,idmarca,idmodelos,idtiposmotocicletas,idsucursales,cilindraje
                           ,anio,precioventa,precioingreso,estado,hp,idproveedor,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE motocicletas c set
        c.motor=motor,
        c.chasis=chasis,
        c.idmarcas=idmarcas,
        c.idmodelos=idmodelos,
        c.idtiposmotocicletas=idtiposmotocicletas,
        c.idsucursales=idsucursales,
        c.cilindraje=cilindraje,
        c.anio=anio,
        c.precioventa=precioventa,
        c.precioingreso=precioingreso,
        c.estado=estado,
        c.hp=hp,
        c.usu=usu,
        c.idproveedor=idproveedor,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;