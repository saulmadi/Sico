DELIMITER $$

DROP PROCEDURE IF EXISTS `OrdenRequisicion_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `OrdenRequisicion_Mant`(

/*definicion de parametros*/

inout id int(11),
inout codigo nvarchar(70),
enviadopor int(11),
recibidopor int(11),
fechaemision date,
sucursalenvia int(11),
sucursalrecibe int(11),
estado nvarchar(11),
usu int(11),
fmodif datetime
)
BEGIN


set @conteo =0;
select count(id) from ordenesrequisicion m where m.id=id into @conteo;

if @conteo =0 then

  set @correlativo=0;

  select count(id)+1 from ordenesrequisicion into @correlativo;

  select CrearCorrelativoCodigo("OR",sucursalenvia,enviadopor,@correlativo) into codigo;

  INSERT INTO ordenesrequisicion(codigo,fechaemision,enviadopor,recibidopor,sucursalenvia,sucursalrecibe,estado,usu,fmodif)

  VALUES(codigo,fechaemision,enviadopor,recibidopor,sucursalenvia,sucursalrecibe,estado,usu,fmodif);

  select last_insert_id() into id;


else

  UPDATE ordenesrequisicion c set
        c.fechaemision=fechaemision,
        c.enviadopor=enviadopor,
        c.recibidopor=recibidopor,
        c.sucursalenvia=sucursalenvia,
        c.estado=estado,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;

END $$

DELIMITER ;