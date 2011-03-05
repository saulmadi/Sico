DELIMITER $$

DROP FUNCTION IF EXISTS `sico`.`CrearCorrelativoCodigo` $$
CREATE FUNCTION `sico`.`CrearCorrelativoCodigo`(correlativo int,codigo nvarchar(70)) RETURNS nvarchar(70)
BEGIN

return concat(codigo,"-",repeat("0",6-CHARACTER_LENGTH(correlativo)),upper(correlativo));

END $$

DELIMITER ;