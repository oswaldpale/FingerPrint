-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.20 - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL version:             7.0.0.4053
-- Date/time:                    2016-08-09 11:16:14
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET FOREIGN_KEY_CHECKS=0 */;

-- Dumping structure for table control_acceso.horarioempleado
DROP TABLE IF EXISTS `horarioempleado`;
CREATE TABLE IF NOT EXISTS `horarioempleado` (
  `hoem_id` int(11) NOT NULL,
  `hoem_estado` tinyint(4) DEFAULT NULL COMMENT 'toma el estado de 0 activo, -1 inactivo',
  `empl_idempleado` varchar(20) DEFAULT NULL,
  `peri_id` int(11) DEFAULT NULL,
  `hoem_vincularfestivos` tinyint(4) DEFAULT NULL,
  `hoem_tiempotarde` int(4) DEFAULT NULL,
  `hoem_tipohorario` set('FIJO','PERIODO') DEFAULT NULL,
  `hoem_fechainicio` date DEFAULT NULL,
  `hoem_fechafin` date DEFAULT NULL,
  `hoem_fechacreacion` date DEFAULT NULL,
  `hoem_fechainactivo` date DEFAULT NULL,
  PRIMARY KEY (`hoem_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40014 SET FOREIGN_KEY_CHECKS=1 */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
