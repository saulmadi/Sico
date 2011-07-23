DELIMITER $$

DROP PROCEDURE IF EXISTS `TransaccionesTarjetaCredito_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `TransaccionesTarjetaCredito_Mant`(

/*definicion de parametros*/

inout id int(11),
idfacturaencabezado int(11),
numerotarjeta nvarchar(45),
codigoaprobacion nvarchar(45),
vencimiento int(4),
idtarjetacredito int(11),
idcontrolcaja int(11),
usu int(11),
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from transaccionestarjetacredito d where d.id=id into @conteo;

if @conteo =0 then

  INSERT INTO transaccionestarjetacredito(idfacturaencabezado,codigoaprobacion,vencimiento,idtarjetacredito,numerotarjeta,idcontrolcaja,usu,fmodif)

  VALUES(idfacturaencabezado,codigoaprobacion,vencimiento,idtarjetacredito,numerotarjeta,idcontrolcaja,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE transaccionestarjetacredito c set
        c.idfacturaencabezado= idfacturaencabezado,
        c.numerotarjeta =numerotarjeta,
        c.codigoaprobacion =codigoaprobacion,
        c.vencimiento =c.vencimiento,
        c.idtrajetacredito=idtrajetacredito,
        c.idcontrolcaja=idcontrolcaja,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;