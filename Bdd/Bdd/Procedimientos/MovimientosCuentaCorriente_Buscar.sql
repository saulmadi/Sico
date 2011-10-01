DROP PROCEDURE IF EXISTS sico.MoviemientosCuentaCorriente_Buscar;
CREATE PROCEDURE sico.`MoviemientosCuentaCorriente_Buscar`(
   id                      nvarchar(11),
   identidadbenficiaria    nvarchar(11),
   identidaddeudora        nvarchar(11),
   idrubro nvarchar(1),
   propietario             int(1))
BEGIN
      DECLARE idpropietario   int(11) DEFAULT 0;
      SET @Campos = "select ";
      SET @from = " ";
      SET @where = " where 1=1 ";
      SET @orden = "order by id ";
      SET @sql = "";

      SET @campos = concat(@campos, " o.* ");

      SET @from = concat(@from, " from vmovimientoscuentacorriente o");


      IF propietario = 1
      THEN
         SELECT p.identidades
           FROM propietario p
           INTO idpropietario;

         SET @where =
                concat(@where,
                       " and o.identidadbeneficiaria = ",
                       idpropietario,
                       " ");
      ELSE
         SET @where =
                concat(@where,
                       " and o.identidadbenficiaria = ",
                       identidadbenficiaria,
                       " ");
      END IF;

      IF id <> ""
      THEN
         SET @where =
                concat(@where,
                       " and o.id = ",
                       id,
                       " ");
      END IF;

      IF identidaddeudora <> ""
      THEN
         SET @where =
                concat(@where,
                       " and o.identidaddeudora = ",
                       identidaddeudora,
                       " ");
      END IF;
      
      IF idrubro <> ""
      THEN
         SET @where =
                concat(@where,
                       " and o.idrubro = ",
                       idrubro,
                       " ");
      END IF;
        
      


      SET @sql =
             concat(@campos,
                    @from,
                    @where,
                    @orden);

PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
   END;
