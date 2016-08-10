-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.20 - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL version:             7.0.0.4053
-- Date/time:                    2016-08-09 11:23:48
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET FOREIGN_KEY_CHECKS=0 */;

-- Dumping structure for function control_acceso.calcularhorasperiodo
DROP FUNCTION IF EXISTS `calcularhorasperiodo`;
DELIMITER //
CREATE DEFINER=`root`@`localhost` FUNCTION `calcularhorasperiodo`(id_periodo int) RETURNS text CHARSET latin1
BEGIN
 DECLARE TOTALHORAS int;

  SELECT sum(h.hora_tiempotarde) AS totalhoras INTO TOTALHORAS FROM horariosemanal hs INNER JOIN horario h 
						ON hs.hose_horaid = h.hora_id WHERE hs.peri_id = id_periodo;
  RETURN TOTALHORAS;
END//
DELIMITER ;
/*!40014 SET FOREIGN_KEY_CHECKS=1 */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
