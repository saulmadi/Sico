﻿DROP VIEW IF EXISTS `vproductos`;
CREATE OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vproductos` AS select `productos`.`id` AS `idproducto`,`productos`.`codigo` AS `codigo`,`productos`.`descripcion` AS `descripcion`,`productos`.`precioventa` AS `precioventa`,`productos`.`usu` AS `usuario`,`productos`.`fmodif` AS `fmodifica` from `productos`;