DELIMITER $$

DROP trigger IF EXISTS `DetalleCompra_trigg` $$
CREATE TRIGGER DetalleCompra_trigg after insert on detallecompras
  FOR EACH ROW BEGIN


    CALL Inventarios_Triggers(new.idsucursal,new.idproducto,new.cantidad,new.usu,new.fmodif);

    /*set @idpro=0;
    select idproveedor from compras c where c.id = new.idcompras into @idpro;

    CALL ProveedorProducto_Trigg(@idpro,new.idproducto,new.preciocompra );*/


    update productos p set preciocosto = new.preciocompra where p.id= new.idproducto;

  END$$

DELIMITER ;