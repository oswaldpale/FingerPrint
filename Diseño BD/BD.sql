-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.1.40-community - MySQL Community Server (GPL)
-- SO del servidor:              Win32
-- HeidiSQL Versión:             9.1.0.4867
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Volcando estructura de base de datos para control_acceso
CREATE DATABASE IF NOT EXISTS `control_acceso` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `control_acceso`;


-- Volcando estructura para tabla control_acceso.circulacion
CREATE TABLE IF NOT EXISTS `circulacion` (
  `circu_idusuario` varchar(25) DEFAULT NULL,
  `circu_fecha` date DEFAULT NULL,
  `circu_horaentrada` time DEFAULT NULL,
  `circu_horasalida` time DEFAULT NULL,
  `circu_id` int(11) NOT NULL,
  PRIMARY KEY (`circu_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.circulacion: ~10 rows (aproximadamente)
/*!40000 ALTER TABLE `circulacion` DISABLE KEYS */;
INSERT INTO `circulacion` (`circu_idusuario`, `circu_fecha`, `circu_horaentrada`, `circu_horasalida`, `circu_id`) VALUES
	('95110500018', '2016-02-04', '08:00:25', '11:01:00', 1),
	('95110500018', '2016-02-08', '11:03:50', '11:05:51', 2),
	('1117513159', '2016-02-08', '11:05:19', '11:09:56', 3),
	('1117513159', '2016-02-08', '11:09:49', '18:58:54', 4),
	('1117506429', '2016-02-08', '18:57:14', '18:57:32', 5),
	('1117513159', '2016-02-16', '09:38:04', '09:38:23', 6),
	('1032443283', '2016-02-16', '09:42:53', '09:43:24', 7),
	('1012383111', '2016-02-16', '17:10:30', '17:44:54', 8),
	('1117513159', '2016-02-16', '17:44:56', '17:10:21', 9),
	('1006518030', '2016-02-17', '17:10:34', '17:10:47', 10);
/*!40000 ALTER TABLE `circulacion` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.control_registro
CREATE TABLE IF NOT EXISTS `control_registro` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `abreviatura` varchar(5) DEFAULT NULL,
  `acumulado` int(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.control_registro: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `control_registro` DISABLE KEYS */;
INSERT INTO `control_registro` (`id`, `nombre`, `abreviatura`, `acumulado`) VALUES
	(1, 'INCIDENCIA', 'INC', 1),
	(2, 'PERMISO', 'PER', 1);
/*!40000 ALTER TABLE `control_registro` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.diasfestivos
CREATE TABLE IF NOT EXISTS `diasfestivos` (
  `dife_Id` int(11) NOT NULL,
  `dife_fecha` date DEFAULT NULL,
  `dife_nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`dife_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.diasfestivos: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `diasfestivos` DISABLE KEYS */;
INSERT INTO `diasfestivos` (`dife_Id`, `dife_fecha`, `dife_nombre`) VALUES
	(1, '2016-01-01', 'Año Nuevo'),
	(2, '2016-01-11', 'Reyes magos'),
	(3, '2016-03-21', 'Día de San José'),
	(4, '2016-03-24', 'Jueves Santo'),
	(5, '2016-03-25', 'Viernes Santo'),
	(6, '2016-05-09', 'La Ascensión del Señor'),
	(7, '2016-05-30', 'Corpus Christi'),
	(8, '2016-06-06', 'El Sagrado Corazón de Jesús');
/*!40000 ALTER TABLE `diasfestivos` ENABLE KEYS */;


-- Volcando estructura para vista control_acceso.empleado
-- Creando tabla temporal para superar errores de dependencia de VIEW
CREATE TABLE `empleado` (
	`Cod_empleado` VARCHAR(20) NOT NULL COLLATE 'latin1_swedish_ci',
	`Identificacion` VARCHAR(40) NULL COLLATE 'latin1_swedish_ci',
	`Nombres` VARCHAR(60) NULL COLLATE 'latin1_swedish_ci',
	`Apellido1` VARCHAR(50) NULL COLLATE 'latin1_swedish_ci',
	`Apellido2` VARCHAR(50) NULL COLLATE 'latin1_swedish_ci',
	`cod_tipo` VARCHAR(10) NULL COLLATE 'latin1_swedish_ci',
	`Eliminado` TINYINT(1) NOT NULL,
	`FOTO` VARCHAR(50) NULL COLLATE 'latin1_swedish_ci'
) ENGINE=MyISAM;


-- Volcando estructura para tabla control_acceso.horario
CREATE TABLE IF NOT EXISTS `horario` (
  `hora_id` int(11) NOT NULL,
  `hora_nombre` varchar(50) DEFAULT NULL,
  `hora_inicio` time DEFAULT NULL,
  `hora_fin` time DEFAULT NULL,
  `hora_tiempotarde` int(11) DEFAULT NULL,
  PRIMARY KEY (`hora_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Horario del Empleado.';

-- Volcando datos para la tabla control_acceso.horario: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `horario` DISABLE KEYS */;
INSERT INTO `horario` (`hora_id`, `hora_nombre`, `hora_inicio`, `hora_fin`, `hora_tiempotarde`) VALUES
	(1, 'JORNADA MAÑANA', '08:00:00', '12:00:00', 10),
	(2, 'JORNADA TARDE', '14:00:00', '18:00:00', 10),
	(3, 'NOCHE', '19:00:00', '20:00:00', 0);
/*!40000 ALTER TABLE `horario` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.horarioempleado
CREATE TABLE IF NOT EXISTS `horarioempleado` (
  `hoem_id` int(11) NOT NULL,
  `hoem_estado` tinyint(4) DEFAULT NULL COMMENT 'toma el estado de 0 activo, -1 inactivo',
  `empl_idempleado` varchar(20) DEFAULT NULL,
  `peri_id` int(11) DEFAULT NULL,
  `hoem_vincularfestivos` tinyint(4) DEFAULT NULL,
  `hoem_tiempotarde` int(4) DEFAULT NULL,
  `hoem_tipohorario` set('fijo','periodo') DEFAULT NULL,
  `hoem_fechainicio` date DEFAULT NULL,
  `hoem_fechafin` date DEFAULT NULL,
  PRIMARY KEY (`hoem_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.horarioempleado: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `horarioempleado` DISABLE KEYS */;
/*!40000 ALTER TABLE `horarioempleado` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.horariosemanal
CREATE TABLE IF NOT EXISTS `horariosemanal` (
  `peri_id` int(11) NOT NULL,
  `hose_diasemanaid` int(10) DEFAULT NULL,
  `hose_horaid` int(10) DEFAULT NULL,
  `hose_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.horariosemanal: ~12 rows (aproximadamente)
/*!40000 ALTER TABLE `horariosemanal` DISABLE KEYS */;
INSERT INTO `horariosemanal` (`peri_id`, `hose_diasemanaid`, `hose_horaid`, `hose_id`) VALUES
	(1, 1, 1, 11),
	(1, 2, 2, 13),
	(1, 6, 1, 17),
	(1, 6, 2, 18),
	(1, 1, 2, 19),
	(1, 2, 3, 20),
	(1, 5, 1, 21),
	(1, 5, 2, 22),
	(1, 3, 1, 23),
	(1, 3, 2, 24),
	(1, 4, 1, 25),
	(1, 4, 2, 26);
/*!40000 ALTER TABLE `horariosemanal` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.huella
CREATE TABLE IF NOT EXISTS `huella` (
  `huell_id` int(25) NOT NULL AUTO_INCREMENT,
  `huell_identificacion` varchar(40) DEFAULT NULL,
  `huell_huella` blob,
  `huell_dedo` set('Primario','Secundario') DEFAULT NULL,
  PRIMARY KEY (`huell_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.huella: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `huella` DISABLE KEYS */;
INSERT INTO `huella` (`huell_id`, `huell_identificacion`, `huell_huella`, `huell_dedo`) VALUES
	(13, '1117513159', _binary 0x00F88101C82AE3735CC0413709AB71F08E1455921BF8D3B8D81B907F08C15813D46A7C9163CB1AB4D76540CBB15377C9F29C5898F79902C2F9D92A14434228A2F752EDBF14B63EE13F5733E781650B3CE133B747F3FF7869568CFE610D6923C0B2CDDC245855EF19A746C026660EA46052EE90AAAB105F10EA094E1845E24E6BFC1300645B9ED5C48F651F258863B61E72E5CCEAA9ED39605ACB49559700898D9CD29B40FFAB7DAEAA525209E8BE0EB3D0900D3D5672F16CFD8624FB75BBF3ACC93D7F97E679E9D6264DC97368488F43499518C9317118DEDC9DF4DD8D24000C7B55883A84FE5301EF7CB1FBBEF5C4971E986090FCB3A9A2FB3853157BCC913D35644A7393FE6543905F509DA71DFD97178143BC9A4EAFE067F332A27062E8914B7945B735B4D43BA07D06D34ACD92A281629B08010B643E64DEC18A9728550784A0E3796B389F62D85860F84A9D22B2B18B9C926754F89A0E1482F43E49AE85E5CFF2CBC67AB3C5F80B7C74779C579030697AD2564A6BC138E0C9E8BF0114B3B76068A9706F00F87D01C82AE3735CC0413709AB71F089145592B70C8B8C27768AB82D1C136247E3C83A81B8BCB79FF59CC3A12465075ECBF160F2E7352AF56EDC7C1E749077F4849D3EA1BD658EA503D924BB8E7FA43FD78C405828D6FDE2BD48EFB0B5B11F9AC5DFDFCFF31D02DC070E7A4000E043A37D91199C5D9C74A20EEB2042A7252D7CBA274AD75F1DEE946915A80E1ACF42FA65D3DB25BC504184FA4A016B4B42A96C5796BB8A139B2A8DD1A21BD9C1C76C898892E4A5BCA26FDAD460344C53C9215F53B908235177D4B45939EE82B9C91A646E22F046EB1BF241B86C25C5CF6E9570487592C8660B89DA3592FF8BEDE932F54556A1BEB3B01E6839FEC3C198E78D232B7E5C30E845ECE1295687904463ED44B5F19F4395F7A15062E33309CB09FC6E4302431791DF945176509E1654C99511BD18DCCF266708AC90F991945D54EC804B896274B2E5F1A34A678B7A9D7CCCFCBEDE41F379A809C4883C0EB9B2C8B51886EC618E4BCD48C17C8D82EACA5C20BEAD2053B0B8AACF2DDD0362A0B20C3CDD6F00F87E01C82AE3735CC0413709AB7130F41455926FE47AA2D5D6BB6DBE7733B8F28579F703A07DC4E5F352EE2FA578D07649CABC0A133FFFF2674CD6C80A2FB1E5A21BE32B1D6FD297F4C537FEB64816FACD99B1DAF3F6B1FF815E741F614FA34516410474316F9ACC07B21B4B5B2ED6BA4A4CADD079EA8213BC7BE9295C3D43AE6D4880BD8D18E04AF0039074F42E28F61A04C1EEF0153FF1926C9A8D6F1DC7B2381402C40EFC3195FF00F3AF15272871D8E1F4388A7BF4F486F72F761F98A2037F3779DC64E82265FADFFB966CC978D805706A3778A6AFDF5D25489630BA73A9E93DF5672DDE29F9D6EB7DBD0033F9BDED3282D63D1AA4EA3D896E20282D156ABA34EF64E8A6E9D0B68EC3DE8A523BD71A5B20493E8E6CE59385E1E3CF8F81F2C3559CAE232C0E09B7885205E73747DAFA05FC308DDCDA1CF80FC853C340A7DFDD986F35BF71004318086E44D52A9A75F4B0FEA3FE5F643A270E621AE77AA304344BF3FD50FD19A5E706F8D5A1BE6A35F69B089A51E8E2C4679E81A6A05EB0F1136F00E85E01C82AE3735CC0413709AB71B0F914559200DF5DD1EA80F7410F0B2B2EA4FAA6B228EBF569270938399A3F7336EFA13FEFF493DD50948AE77435FA6DA79F4580AF2E0F25C806448500DC8B6540DF7D34AA383BCA484B1B983CE28E6CB40A655CE1FCEC7E948C1DA03A2B2893E108F33BE2107032AD19453C2495F2774B8CE1875585AF32107E15A7C0DAA1C92C08E9D73328BF856591D2C1FA0E077AD74801817CF3EBF685C7986A17FD5E2D64EA024B542D860D81A8338B1122F8DDBF2CE5B0826DFDD7B3A5E876C0DFF215CC7CA807BEEE4DAD8D32F5AAA05282770AA617FD27E439B1FCBC9B2FEE71BDCF5F1B54FDE25B07CB3E2408149F7F8EDD2702D55B9590536EA0961E7CBB5B0BF8C31EB2CE3822E1FC9DC202FD555B0A8FDA3321B526D861EF5CDA0A8E69609AD3575276ED420316A3AF0A2FF7E8A65A208A9995BD9E0804E13E563BC3FF6469D953922A8ABC96633825A873F704E451D9027DE66FEA5534ADEA5544ADEA5544ADEA5554ADEA5554ADEA5564ADEA5564ADEA5574ADEA5574ADEA5590ADEA5590ADEA55000000000A00000A616E0F00A0780615F8630801000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 'Primario');
/*!40000 ALTER TABLE `huella` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.incidencia
CREATE TABLE IF NOT EXISTS `incidencia` (
  `inci_id` int(11) NOT NULL,
  `empl_id` varchar(30) DEFAULT NULL,
  `inci_codigo` int(11) NOT NULL,
  `inci_asunto` date NOT NULL,
  `inci_descripcion` varchar(100) NOT NULL,
  `inci_fechainicio` date NOT NULL,
  `circu_id` int(11) NOT NULL,
  `inci_estado` tinyint(4) NOT NULL,
  `inci_fechafin` date NOT NULL,
  `inci_horainicio` time NOT NULL,
  `inci_horafin` time NOT NULL,
  PRIMARY KEY (`inci_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.incidencia: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `incidencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `incidencia` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.periodo
CREATE TABLE IF NOT EXISTS `periodo` (
  `peri_id` int(11) NOT NULL,
  `peri_totalhoras` double DEFAULT NULL,
  `peri_descripcion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`peri_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.periodo: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `periodo` DISABLE KEYS */;
INSERT INTO `periodo` (`peri_id`, `peri_totalhoras`, `peri_descripcion`) VALUES
	(1, 12, 'HORARIO LABORAL');
/*!40000 ALTER TABLE `periodo` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.permisos
CREATE TABLE IF NOT EXISTS `permisos` (
  `perm_id` int(11) NOT NULL,
  `perm_codigo` varchar(20) DEFAULT NULL,
  `tipe_id` int(11) NOT NULL,
  `perm_nombre` varchar(20) DEFAULT NULL,
  `perm_descripcion` varchar(50) DEFAULT NULL,
  `perm_fechasolicitud` date DEFAULT NULL,
  `perm_cancelado` tinyint(4) DEFAULT NULL,
  `perm_fechainicio` date DEFAULT NULL,
  `perm_fechafin` date DEFAULT NULL,
  `perm_horainicio` time DEFAULT NULL,
  `perm_horafin` time DEFAULT NULL,
  PRIMARY KEY (`perm_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.permisos: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `permisos` DISABLE KEYS */;
/*!40000 ALTER TABLE `permisos` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.semana
CREATE TABLE IF NOT EXISTS `semana` (
  `sema_id` int(11) NOT NULL,
  `sema_dia` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`sema_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.semana: ~7 rows (aproximadamente)
/*!40000 ALTER TABLE `semana` DISABLE KEYS */;
INSERT INTO `semana` (`sema_id`, `sema_dia`) VALUES
	(1, 'Lunes'),
	(2, 'Martes'),
	(3, 'Miercoles'),
	(4, 'Jueves'),
	(5, 'Viernes'),
	(6, 'Sabado'),
	(7, 'Domingo');
/*!40000 ALTER TABLE `semana` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.tipo_permiso
CREATE TABLE IF NOT EXISTS `tipo_permiso` (
  `tipe_id` int(11) NOT NULL,
  `tipe_descripcion` varchar(50) DEFAULT NULL,
  `tipe_estado` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`tipe_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.tipo_permiso: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `tipo_permiso` DISABLE KEYS */;
INSERT INTO `tipo_permiso` (`tipe_id`, `tipe_descripcion`, `tipe_estado`) VALUES
	(1, 'Vacaciones', 1);
/*!40000 ALTER TABLE `tipo_permiso` ENABLE KEYS */;


-- Volcando estructura para tabla control_acceso.visitante
CREATE TABLE IF NOT EXISTS `visitante` (
  `visi_identificacion` int(20) NOT NULL,
  `visi_nombre` varchar(30) DEFAULT NULL,
  `visi_apellido1` varchar(20) DEFAULT NULL,
  `visi_apellido2` varchar(20) DEFAULT NULL,
  `visi_foto` blob,
  `visi_observacion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`visi_identificacion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla control_acceso.visitante: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `visitante` DISABLE KEYS */;
INSERT INTO `visitante` (`visi_identificacion`, `visi_nombre`, `visi_apellido1`, `visi_apellido2`, `visi_foto`, `visi_observacion`) VALUES
	(11153934, 'PERALTA', 'PARRAE', 'CALOS', _binary 0x20, 'AN'),
	(1117513159, 'OSWALDO', 'PAMO', 'LEAL', NULL, NULL);
/*!40000 ALTER TABLE `visitante` ENABLE KEYS */;


-- Volcando estructura para vista control_acceso.empleado
-- Eliminando tabla temporal y crear estructura final de VIEW
DROP TABLE IF EXISTS `empleado`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` VIEW `empleado` AS select `e`.`Cod_empleado` AS `Cod_empleado`,`e`.`Identificacion` AS `Identificacion`,`e`.`Nombres` AS `Nombres`,`e`.`Apellido1` AS `Apellido1`,`e`.`Apellido2` AS `Apellido2`,`e`.`cod_tipo` AS `cod_tipo`,`e`.`Eliminado` AS `Eliminado`,`e`.`FOTO` AS `FOTO` from `sigc972008`.`empleado` `e` ;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
