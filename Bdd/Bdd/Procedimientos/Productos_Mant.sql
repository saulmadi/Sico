DELIMITER $$

DROP PROCEDURE IF EXISTS `Productos_Mant` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Productos_Mant`(

/*definicion de parametros*/

inout id int,
codigo nvarchar(45),
descripcion nvarchar(45),
preciocosto decimal(15,2),
precioventa decimal(15,2),
usu int,
fmodif datetime
)
BEGIN


set @conteo =0;
select count(c.id) from productos c where c.id=id into @conteo;

if @conteo =0 then

  INSERT INTO productos(codigo,descripcion,preciocosto,precioventa,usu,fmodif)

  VALUES(codigo,descripcion,preciocosto,precioventa,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE productos c set
        c.codigo=codigo,
        c.descripcion=descripcion,
        c.preciocosto=preciocosto,
        c.precioventa=precioventa,
        c.usu=usu,
        c.fmodif=fmodif
  where c.id= id;

end if;
END $$

DELIMITER ;