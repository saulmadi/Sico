DELIMITER $$

DROP trigger IF EXISTS `DetalleCompra_trigg` $$
CREATE TRIGGER DetalleCompra_trigg after insert on detallecompras
  FOR EACH ROW BEGIN
    CALL Inventarios_Triggers(new.idsucursal,new.idproducto,new.cantidad,new.usu,new.fmodif);
  END$$

DELIMITER ;