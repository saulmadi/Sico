DELIMITER $$

DROP FUNCTION IF EXISTS `sico`.`CalcularSaldo` $$
CREATE FUNCTION `sico`.`CalcularSaldo` (
idrubro int(11),
identidad int(11)
) returns double
BEGIN
declare saldo double;

set saldo =0.00;

select  sum(case t.idtipomovimiento when 1 then t.monto when 2 then t.monto*-1 else 0 end)  saldo1
from movimientoscuentacorriente t
join cuentacorriente c on t.idcuentacorriente=c.id
where t.idrubro=idrubro and  c.identidaddeudora=identidad
group by t.idrubro,t.idcuentacorriente into saldo ;

return saldo;

END $$

DELIMITER ;