DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`Departamentos_Mant`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE  `sico`.`Departamentos_Mant`(

/*definicion de parametros*/

inout id int,
departamento nvarchar(45),
habilitados bool,
usu int,
fmodif date
)
BEGIN


set @conteo =0;
select count(id) from departamentos  where id=id into @conteo;

if @conteo =0 then

  INSERT INTO departamentos(departamento,habilitados,usu,fmodif)

  VALUES(departamentos,habilitados,usu,fmodif);

  select last_insert_id() into id;

else

  UPDATE departamentos c set
        c.departamentos= departamentos,
        c.habilitados =habilitados,
        c.usu=usu,
        c.fmodif=fmodif
  where e.id= id;

end if;


END $$

DELIMITER ;