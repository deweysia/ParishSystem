-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: sad2
-- ------------------------------------------------------
-- Server version	5.7.13-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `userID` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` text,
  `midname` text,
  `lastname` text,
  `suffix` varchar(45) DEFAULT NULL,
  `username` varchar(45) NOT NULL,
  `pass` longtext NOT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  `addedBy` int(11) DEFAULT NULL,
  `privileges` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Dewey','L','Sia','','dewey','4c+SKaAbfsUkjwgOvCdw+6DGwbKHRlWHZxlRB6eUNdvaByDu',1,-1,'4'),(2,'Keating','A','John','','john','giclmh/nLTS6TsHaGQKLNI4wpyZBsvxzmnaCCgXWf1Eh3SgQ',1,-1,'4'),(4,'Holly','M','Blue','','hollyblue','QOxAMZON/XI9fEypGyIJtR7ccouMZwdxoCbAa5f+I8q8oa7F',1,2,'2'),(5,'Sheila','B','Sheng','','ateneo98','xr/ePNlzUqh7VHbtcd1ENooIn4y+ou/Km5SLCdl7pAmnrBi6',1,2,'1'),(6,'Justin','C','Lo','','jhclo','iUIMMgl2yD9htcsOOrA7TYxszFEbpOq81EbDrEwJ0Knpk64J',1,2,'4'),(7,'Leryc','V','Ibalio','','jlvibalio','Efdt+qucmS0wPIq6mEUHfAADFt+tdn6ZmCYrwDaTev3AAYEr',1,6,'2');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-08 21:02:57
