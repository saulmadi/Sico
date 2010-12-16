DELIMITER $$

DROP PROCEDURE IF EXISTS `clientes_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `clientes_Mant`(

/*definicion de parametros*/

inout id int,
identidades int,
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(c.id) from clientes c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO clientes(identidades,usu,fmodif)

  VALUES(identidades,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE clientes c set
        c.identidades= identidades,
        c.usu=usu,
        c.fmodif=fmodif
  where e.id= id;

end if;


END $$

DELIMITER ;