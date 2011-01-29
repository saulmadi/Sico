DELIMITER $$

DROP FUNCTION IF EXISTS `CrearUsuario` $$
CREATE DEFINER=`root`@`localhost` FUNCTION `CrearUsuario`(nombreusuario nvarchar(45) ) RETURNS varchar(45) CHARSET utf8
BEGIN
set @conteo =0;

select count(*) from usuarios where usuario = nombreusuario  into @conteo;

if @conteo =0 then
  return nombreusuario;
else
  set @conteo=@conteo +1;
  return concat(nombreusuario,@conteo);
end if;

END $$

DELIMITER ;