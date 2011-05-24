DELIMITER $$

DROP PROCEDURE IF EXISTS `FacturaDetalle_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `FacturaDetalle_Mant`(
/*definicion de parametros*/

inout id int(11),
idfacturaencabezado int(11),
idproductos int(11),
cantidad int(11),
precioventa decimal(18,2),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from facturadetalle m where m.id=id into @conteo;

if @conteo =0 then

  INSERT INTO facturadetalle(idfacturaencabezado,idproductos,cantidad,precioventa,usu,fmodif)

  VALUES(idfacturaencabezado,idproductos,cantidad,precioventa,usu,fmodif);


  select last_insert_id() into id;

else

  UPDATE facturadetalle c set
        c.idfacturaencabezado=idfacturaencabezado,
        c.idproductos=idproductos,
        c.cantidad=cantidad,
        c.precioventa=precioventa,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;