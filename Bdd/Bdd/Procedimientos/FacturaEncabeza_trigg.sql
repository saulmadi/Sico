DELIMITER $$

DROP trigger IF EXISTS `FacturaEncabezado_trigg` $$
CREATE TRIGGER FacturaEncabezado_trigg after update on facturaencabezado
  FOR EACH ROW BEGIN

      CALL GenerarNumeroFactura(new.id,new.idsucursales,new.estado);


  END$$

DELIMITER ;