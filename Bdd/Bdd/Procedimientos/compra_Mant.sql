DELIMITER $$

DROP PROCEDURE IF EXISTS `Compras_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Compras_Mant`(

/*definicion de parametros*/

inout id int(11),
facturacompra nvarchar(18),
idsucursal int(11),
idproveedor int(11),
fechacompra date,
totalcompra decimal(16,4),
estado nvarchar(3),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from compras m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO compras(facturacompra,idproveedor,fechacompra,idsucursal,totalcompra,usu,fmodif,estado)

  VALUES(facturacompra,idproveedor,fechacompra,idsucursal,totalcompra,usu,fmodif,estado);

  select last_insert_id() into id;

else

  UPDATE compras c set
        c.facturacompra=facturacompra,
        c.idsucursal=idsucursal,
        c.idproveedor=idproveedor,
        c.fechacompra=fechacompra,
        c.totalcompra=totalcompra,
        c.estado=estado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;