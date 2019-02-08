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
-- Table structure for table `sponsor`
--

DROP TABLE IF EXISTS `sponsor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sponsor` (
  `sponsorID` int(11) NOT NULL AUTO_INCREMENT,
  `applicationID` int(11) DEFAULT NULL,
  `firstname` text,
  `midname` text,
  `lastname` text,
  `suffix` varchar(5) DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `residence` text,
  PRIMARY KEY (`sponsorID`),
  KEY `ApplicationID_idx` (`applicationID`),
  CONSTRAINT `ApplicationID` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sponsor`
--

LOCK TABLES `sponsor` WRITE;
/*!40000 ALTER TABLE `sponsor` DISABLE KEYS */;
INSERT INTO `sponsor` VALUES (1,12,'Coretta','S','Sircy','',2,'Bathasia'),(2,12,'Augustus','E','Outman','Jr',1,'Quinnia'),(3,10,'Sergione','V','Negron','II',1,'Whittingham'),(4,10,'Sergione','V','Negron','II',1,'Whittingham'),(5,13,'Keith','C','Bambor','',1,'Northcoast'),(6,13,'Wen','A','Glasgow','',1,'Fallholt'),(7,20,'Clint','A','Reynolds','',1,'Old York'),(8,20,'Clint','A','Reynolds','',1,'Old York'),(9,31,'William','Y','Lambert','',1,'Coldbank'),(10,31,'William','Y','Lambert','',1,'Coldbank'),(11,35,'Claudia ','C','Shearer','',2,'3577 Moonlight Drive'),(12,35,'Scott ','V','Lerner','',1,'3217 Harvest Lane'),(13,36,'Kathy ','T','Bryant','',2,'Eagle Street'),(14,36,'Kent ','J','Curry','',1,'Coffman Alley'),(15,37,'Cora ','C','Demaria','',2,'Neshkoro'),(16,37,'Henry ','S','Blagg','',1,'Bayside'),(17,38,'Cindy ','R','Hoggan','',2,'Waltham'),(18,38,'George ','T','Rhoades','',1,'Monroe'),(19,39,'Laura ','W','Farmer','',2,'Grand Island'),(20,39,'Marlon','T','Threatt','',1,'Grand Island'),(21,40,'Priscilla ','H','Gonzalez','',2,'Malibu'),(22,40,'Ernest','A','Pearson','',1,'Toledo'),(27,34,'Tanya','A','Jennings','',2,'Fogtown'),(28,34,'Derrick','B','Graham','',1,'Jancoast'),(29,45,'Justin','A','Lu','',1,'Cebu'),(30,45,'Justin','A','Lu','',1,'Cebu');
/*!40000 ALTER TABLE `sponsor` ENABLE KEYS */;
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
