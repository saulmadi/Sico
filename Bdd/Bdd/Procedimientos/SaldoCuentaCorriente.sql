DELIMITER $$

DROP PROCEDURE IF EXISTS `sico`.`SaldoCuentaCorriente` $$
CREATE PROCEDURE `sico`.`SaldoCuentaCorriente` (
id int(11),
idrubro int(11),
idcuentacorriente int(11)
)
BEGIN

select t.id, sum(case t.idtipomovimiento when 1 then t.monto when 2 then t.monto*-1 else 0 end)  saldo
from movimientoscuentacorriente t
where t.idrubro=idrubro and  t.idcuentacorriente=idcuentacorriente
group by t.idrubro,t.idcuentacorriente;



END $$

DELIMITER ;