DELIMITER $$

DROP PROCEDURE IF EXISTS `OrdenSalida_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenSalida_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(70),
enviadopor int(11),
recibidopor int(11),
fechaemision date,
sucursalenvia int(11),
sucursalrecibe int(11),
estado nvarchar(11),
requisicion int(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from ordenessalida m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from ordenessalida into @correlativo;

  select CrearCorrelativoCodigo("OS",sucursalenvia,enviadopor,@correlativo) into codigo;

  INSERT INTO ordenessalida(codigo,fechaemision,enviadopor,recibidopor,sucursalenvia,sucursalrecibe,estado,requisicion,usu,fmodif)

  VALUES(codigo,fechaemision,enviadopor,recibidopor,sucursalenvia,sucursalrecibe,estado,requisicion,usu,fmodif);

  select last_insert_id() into id;


else

  UPDATE ordenessalida c set
        c.fechaemision=fechaemision,
        c.enviadopor=enviadopor,
        c.recibidopor=recibidopor,
        c.sucursalenvia=sucursalenvia,
        c.estado=estado,
        c.requicion=requisicion,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;