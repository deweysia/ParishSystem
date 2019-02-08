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
-- Table structure for table `sacramentincome`
--

DROP TABLE IF EXISTS `sacramentincome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sacramentincome` (
  `sacramentIncomeID` int(11) NOT NULL AUTO_INCREMENT,
  `applicationID` int(11) NOT NULL,
  `price` double DEFAULT NULL,
  `remarks` text,
  PRIMARY KEY (`sacramentIncomeID`),
  KEY `sacramentIncome_application_idx` (`applicationID`),
  CONSTRAINT `sacramentIncome_application` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sacramentincome`
--

LOCK TABLES `sacramentincome` WRITE;
/*!40000 ALTER TABLE `sacramentincome` DISABLE KEYS */;
INSERT INTO `sacramentincome` VALUES (10,10,200,''),(11,11,200,''),(12,15,500,''),(13,13,2000,''),(14,14,500,'New Parish Member'),(15,22,100,''),(16,20,100,''),(17,21,100,''),(18,23,0,''),(19,24,0,''),(20,25,0,''),(21,26,0,'New born'),(22,28,500,'New born baby'),(23,29,500,''),(24,30,500,''),(25,31,200,'Japanese record producer, DJ, composer and arranger who recorded under the stage name Nujabes'),(26,32,800,'American hip hop producer and rapper from Cincinnati, Ohio'),(27,33,20000,'Couple\'s donation went toward their wedding.'),(28,34,2000,''),(29,35,200,''),(30,36,500,''),(31,37,200,''),(32,38,200,''),(33,39,500,''),(34,40,500,''),(35,41,500,''),(36,42,500,'awaiting requirements'),(37,43,500,''),(38,44,0,'Free application'),(39,45,200,''),(40,46,500,'Builds.'),(41,47,200,'');
/*!40000 ALTER TABLE `sacramentincome` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-08 21:02:58
