DELIMITER $$

DROP PROCEDURE IF EXISTS `FacturaEncabezado_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `FacturaEncabezado_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(150),
idsucursales int(11),
numerofactura varchar(100),
idclientes int(11),
fecha date,
idtiposfacturas int(11),
total decimal(16,4),
isv decimal(16,4),
subtotal decimal(16,4),
descuentovalor decimal(16,4),
descuento int(11),
ventaexcenta int(1),
estado nvarchar(5),
motoproducto nvarchar(5),
elabora int(11),
factura int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from facturaencabezado m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from facturaencabezado into @correlativo;

  select CrearCorrelativoCodigo("FE",idsucursales,elabora,@correlativo) into codigo;



  INSERT INTO facturaencabezado(codigo,idsucursales,numerofactura,idclientes,fecha,idtiposfacturas,total,isv,subtotal,
              descuentovalor,descuento,ventaexenta,estado,motoproducto,elabora,factura,usu,fmodif)

  VALUES(codigo,idsucursales,numerofactura,idclientes,fecha,idtiposfacturas,total,isv,subtotal,
              descuentovalor,descuento,ventaexcenta,estado,motoproducto,elabora,factura,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE facturaencabezado c set
        c.idsucursales=idsucursales,
        c.numerofactura=numerofactura,
        c.idclientes=idclientes,
        c.fecha=fecha,
        c.idtiposfacturas=idtiposfacturas,
        c.total=total,
        c.isv=isv,
        c.subtotal=subtotal,
        c.descuentovalor=descuentovalor,
        c.descuento=descuento,
        c.ventaexenta=ventaexcenta,
        c.estado=estado,
        c.motoproducto=motoproducto,
        c.elabora=elabora,
        c.factura=factura,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;