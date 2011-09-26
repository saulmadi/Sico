DELIMITER $$

DROP FUNCTION IF EXISTS `sico`.`CargarCorrelativoCodigo` $$
CREATE FUNCTION `sico`.`CargarCorrelativoCodigo` (

codigo nvarchar(4)

) RETURNS long

BEGIN

set  @correlativocodigo =0;

select count(*) from correlativocodigo t where upper(t.codigo)=upper(codigo) into @correlativo;

if @correlativo=0 then
    insert into correlativocodigo(codigo,correlativo) values(upper(codigo),1);
    return 1;
else
    select t.correlativo+1 from correlativocodigo t where upper(t.codigo)=upper(codigo) into @correlativo;

    update correlativocodigo t set
      t.correlativo=@correlativo
    where upper(t.codigo)=upper(codigo);
    return @correlativo;

end if;

return 0;



END $$

DELIMITER ;