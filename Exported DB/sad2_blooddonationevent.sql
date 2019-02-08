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
-- Table structure for table `blooddonationevent`
--

DROP TABLE IF EXISTS `blooddonationevent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `blooddonationevent` (
  `bloodDonationEventID` int(11) NOT NULL AUTO_INCREMENT,
  `eventName` text,
  `startDateTime` datetime DEFAULT NULL,
  `endDateTime` datetime DEFAULT NULL,
  `eventVenue` text,
  `eventDetails` text,
  PRIMARY KEY (`bloodDonationEventID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blooddonationevent`
--

LOCK TABLES `blooddonationevent` WRITE;
/*!40000 ALTER TABLE `blooddonationevent` DISABLE KEYS */;
INSERT INTO `blooddonationevent` VALUES (1,'RED CROSS BLOOD DONATION EVENT','2017-09-29 10:00:19','2017-09-30 10:00:19','Toril, Davao City',''),(2,'Our Lady of Assumption Blood Donation Charity','2017-11-08 11:00:00','2017-11-10 10:00:00','Our Lady of Assumption Parish, Davao City',''),(3,'Davao Doctor\'s Hospital Blood Charity','2017-09-30 10:01:18','2017-09-30 10:01:18','Davao Doctor\'s Hospital',''),(4,'Ateneo De Davao Blood Donation Event','2018-02-10 10:01:49','2018-02-12 10:01:49','Ateneo De Davao Jacinto Campus',''),(5,'San Pedro Hospital Blood Donation ','2018-02-28 10:02:24','2018-03-01 10:02:24','San Pedro College',''),(6,'Acosta Clinic Blood Donaation','2017-12-13 10:03:16','2017-12-13 10:03:16','Acosta Clinic, Toril',''),(7,'Red Cross Blood Donation Charity 2018','2018-01-04 10:03:46','2018-01-05 10:03:46','Red Cross Building, Davao City',''),(9,'Blood Donation Camp 2013','2017-10-03 14:00:00','2017-10-03 17:00:00','Rotary Club of Indirapuram','Blood Donation Camp on 3 October 2017 at 2pm Organised by the Rotary Club of Indirapuram Parivar.'),(10,'qqq','2017-12-14 07:00:00','2017-12-14 22:00:00','qqq','');
/*!40000 ALTER TABLE `blooddonationevent` ENABLE KEYS */;
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
