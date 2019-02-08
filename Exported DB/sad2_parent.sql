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
-- Table structure for table `parent`
--

DROP TABLE IF EXISTS `parent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parent` (
  `parentID` int(11) NOT NULL AUTO_INCREMENT,
  `profileID` int(11) DEFAULT NULL,
  `firstName` text,
  `midName` text,
  `lastName` text,
  `suffix` varchar(5) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `birthplace` text,
  `residence` text,
  PRIMARY KEY (`parentID`),
  KEY `parent_genprof_idx` (`profileID`),
  CONSTRAINT `parent_genprof` FOREIGN KEY (`profileID`) REFERENCES `generalprofile` (`profileID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parent`
--

LOCK TABLES `parent` WRITE;
/*!40000 ALTER TABLE `parent` DISABLE KEYS */;
INSERT INTO `parent` VALUES (3,8,'Jumallia','Q','Aine','',NULL,1,'Vladasia',NULL),(4,8,'Sheryl','E','Sedder','',NULL,2,'Vladasia',NULL),(5,9,'Sherylle','E','Seder','',NULL,1,'Coldstone',NULL),(6,9,'Sherylle','E','Sedderin','',NULL,2,'Addasia',NULL),(8,13,'Sherylle','E','Sedderin','',NULL,2,'Nelliston',NULL),(9,13,'Sherylle','E','Seder','',NULL,1,'Carlstone',NULL),(10,23,'Yvonne','E','Gomez','',NULL,2,'Springlea',NULL),(11,23,'Bret','E','Ellis','',NULL,1,'Pinelyn',NULL),(13,28,'Cynthia','K','Khun','',NULL,2,'2013 Rocket Drive',NULL),(14,28,'David ','D','Moulton','',NULL,1,'300 Atha Drive',NULL),(15,29,'Sharon ','L','Deckard','',NULL,2,'3595 Marion Street',NULL),(16,29,'Gary ','M','Wang','',NULL,1,'630 Matthews Street',NULL),(17,30,'Bessie ','J','Kramer','',NULL,2,'Southfield',NULL),(18,30,'George ','M','Sadler','',NULL,1,'Everett',NULL),(19,31,'Glena','M','Shearer','',NULL,2,'Madisonville',NULL),(20,31,'Gary','M','Wang','Jr',NULL,1,'Kent',NULL),(21,32,'Renee ','W','Noel','',NULL,2,'New York',NULL),(22,32,'Howard ','D','Lopez','',NULL,1,'Nashville',NULL),(23,33,'Zola','A','Aaron','',NULL,2,'Memphis',NULL),(24,33,'Allen ','M','Johanson','',NULL,1,'Louisville',NULL),(26,26,'Ralph','R','Franklin','Jr',NULL,1,'',NULL),(27,26,'Cynthia','A','Moore','',NULL,2,'',NULL),(28,27,'Keith','A','Cooper','',NULL,1,'',NULL),(29,27,'Ida','R','Robertson','',NULL,2,'',NULL),(30,38,'Anne','A','Rodrigues','',NULL,2,'Davao',NULL),(31,38,'Wilson','A','Babusha','',NULL,1,'Davao',NULL);
/*!40000 ALTER TABLE `parent` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-08 21:02:59
