DELIMITER $$

DROP PROCEDURE IF EXISTS `OrdenCompra_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenCompra_Mant`(

/*definicion de parametros*/

inout id int,
inout codigo nvarchar(70),
idsucursal int,
idproveedor int,
fechaorden date,
elaboradopor int,
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from ordenescompras m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from ordenescompras into @correlativo;

  select CrearCorrelativoCodigo("oc",idsucursal,elaboradopor,@correlativo) into codigo;

  INSERT INTO ordenescompras(codigo,idproveedor,fechaorden,idsucursal,elaboradopor,usu,fmodif)

  VALUES(codigo,idproveedor,fechaorden,idsucursal,elaboradopor,usu,fmodif);

  select last_insert_id() into id;


else

  UPDATE ordenescompras c set
        c.idsucursal=idsucursal,
        c.idproveedor=idproveedor,
        c.fechaorden=fechaorden,
        c.elaboradopor=elaboradopor,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;