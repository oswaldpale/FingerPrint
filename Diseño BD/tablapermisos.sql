-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.20 - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL version:             7.0.0.4053
-- Date/time:                    2016-08-09 11:19:53
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET FOREIGN_KEY_CHECKS=0 */;

-- Dumping structure for table control_acceso.permisos
DROP TABLE IF EXISTS `permisos`;
CREATE TABLE IF NOT EXISTS `permisos` (
  `perm_id` int(11) NOT NULL,
  `tipe_id` int(11) NOT NULL,
  `perm_descripcion` varchar(50) DEFAULT NULL,
  `empl_idempleado` varchar(50) DEFAULT NULL,
  `perm_fechasolicitud` date DEFAULT NULL,
  `perm_tipo` set('HORA','DIA') DEFAULT NULL,
  `perm_estado` set('ACTIVO','INACTIVO') DEFAULT NULL,
  `perm_fechahora` date DEFAULT NULL,
  `perm_fechainicio` date DEFAULT NULL,
  `perm_fechafin` date DEFAULT NULL,
  `perm_horainicio` time DEFAULT NULL,
  `perm_horafin` time DEFAULT NULL,
  PRIMARY KEY (`perm_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40014 SET FOREIGN_KEY_CHECKS=1 */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
