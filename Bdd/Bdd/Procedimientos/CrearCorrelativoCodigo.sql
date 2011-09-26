DELIMITER $$

DROP FUNCTION IF EXISTS `CrearCorrelativoCodigo` $$
CREATE DEFINER=`root`@`localhost` FUNCTION `CrearCorrelativoCodigo`(iniciales nvarchar(2),sucursal int(11), usuario int(11)) RETURNS varchar(70) CHARSET utf8
BEGIN
set @correlativoc=0;
select CargarCorrelativoCodigo(iniciales) into @correlativoc;
return concat(upper(iniciales),"-",repeat("0",3-CHARACTER_LENGTH(sucursal)),upper(sucursal),"-", upper(year(now())),repeat("0",2-CHARACTER_LENGTH(upper(month(now())))) , upper(month(now())), repeat("0",2-CHARACTER_LENGTH(upper(day(now())))), upper(day(now())),"-",repeat("0",3-CHARACTER_LENGTH(usuario)),upper(usuario),"-", repeat("0",7-CHARACTER_LENGTH(@correlativoc)),upper(@correlativoc) );

END $$

DELIMITER ;