DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`GenerarNumeroFactura` $$
CREATE PROCEDURE `sico`.`GenerarNumeroFactura` (
idfactura as int(11),
idsucursal as int(11)
)
BEGIN

  set @numerofactura =0;
  select numerofactura from sucursales into @numerofactura;
  update facturaencabezado f set
    t.numerofactura=@numerofactura +1
  where f.id=idfactura;

  update sucur


END $$

DELIMITER ;