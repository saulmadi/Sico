DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`ObtnerCorrelativo` $$
CREATE PROCEDURE `sico`.`ObtnerCorrelativo` (

tabla nvarchar(50),
out correlativo int
)
BEGIN


set @correlativo= 0;
set @sql="select count(id) from ";
set @sql=concat(@sql, tabla," into @correlativo; ");

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

select @correlativo into correlativo;

END $$

DELIMITER ;