DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`OrdenCompra_Mant` $$
CREATE PROCEDURE `sico`.`OrdenCompra_Mant` (

/*definicion de parametros*/

inout id int,
codigo nvarchar(50),
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

  INSERT INTO compras(codigo,idproveedor,fechaorden,idsucursal,elaboradopor,usu,fmodif)

  VALUES(codigo,idproveedor,fechaorden,idsucursal,elaboradopor,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE compras c set
        c.codigo=codigo,
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