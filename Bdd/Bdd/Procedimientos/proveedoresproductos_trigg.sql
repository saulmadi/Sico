DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`ProveedorProducto_Trigg` $$
CREATE PROCEDURE `sico`.`ProveedorProducto_Trigg` (

/*definicion de parametros*/


idproveedores int,
idproducto int,
preciocompra decimal(10,2)

)
BEGIN


set @conteo =0;
select count(id) from proveedorproducto m where m.productos_id = idproveedores and m.prodcutos_id=idproducto  ;

if @conteo =0 then

  INSERT INTO proveedorproducto(proveedores_id,productos_id,preciocompra)

  VALUES(idproveedores,idproducto,preciocompra);



else

  UPDATE proveedorproducto m set
      m.preciocompra=preciocompra
  where  m.productos_id = idproveedores and m.prodcutos_id=idproducto  ;

end if;

END $$

DELIMITER ;