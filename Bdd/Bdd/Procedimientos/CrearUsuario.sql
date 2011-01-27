DELIMITER $$

DROP FUNCTION IF EXISTS `sico`.`CrearUsuario` $$
CREATE FUNCTION `sico`.`CrearUsuario` (nombreusuario nvarchar(45) ) RETURNS nvarchar(45)
BEGIN
set @conteo =0;

select count(*) from usuarios into @conteo;

if @conteo =0 then
  return nombreusuario;
else
  set @conteo=@conteo +1;
  return concat(nombreusuario,@conteo);
end if;

END $$

DELIMITER ;