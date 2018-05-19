-- Adminer 4.2.5 MySQL dump

SET NAMES utf8;
SET time_zone = '+00:00';

DROP DATABASE IF EXISTS `stickynotes`;
CREATE DATABASE `stickynotes` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `stickynotes`;

DROP TABLE IF EXISTS `stickynote`;
CREATE TABLE `stickynote` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `scene` varchar(255) NOT NULL,
  `bugText` text NOT NULL,
  `x` float NOT NULL,
  `y` float NOT NULL,
  `z` float NOT NULL,
  `timeStamp` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;


-- 2018-05-17 22:09:14
