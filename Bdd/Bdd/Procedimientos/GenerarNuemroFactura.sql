DELIMITER $$

DROP PROCEDURE IF EXISTS `GenerarNumeroFactura` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GenerarNumeroFactura`(
idfactura  int(11),
idsucursal  int(11),
estado nvarchar(1),
numerofactura int(11)

)
BEGIN

  if estado='F' or estado='f' and numerofactura=0 then
      set @numerofactura =0;
      select s.numerofactura from sucursales s where id =idsucursal into @numerofactura  ;

      update facturaencabezado f set
        f.numerofactura=@numerofactura +1
      where f.id=idfactura;

      update sucursales f set
        f.numerofactura=@numerofactura +1
      where f.id=idsucursal;

  else
    update facturaencabezado f set
      f.numerofactura=numerofactura
      where f.id=idfactura;

  end if;



END $$

DELIMITER ;