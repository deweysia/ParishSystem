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
-- Table structure for table `blooddonation`
--

DROP TABLE IF EXISTS `blooddonation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `blooddonation` (
  `bloodDonationID` int(11) NOT NULL AUTO_INCREMENT,
  `profileID` int(11) NOT NULL,
  `bloodDonationEventID` int(11) NOT NULL,
  `donationID` int(11) NOT NULL,
  `bloodclaimant` int(11) DEFAULT NULL,
  PRIMARY KEY (`bloodDonationID`),
  KEY `fk_blooddonation_blooddonationevent1_idx` (`bloodDonationEventID`),
  KEY `fk_donor_idx` (`profileID`),
  KEY `fk_claimant_idx` (`bloodclaimant`),
  CONSTRAINT `fk_blooddonation_blooddonationevent1` FOREIGN KEY (`bloodDonationEventID`) REFERENCES `blooddonationevent` (`bloodDonationEventID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_claimant` FOREIGN KEY (`bloodclaimant`) REFERENCES `bloodclaimant` (`bloodclaimantID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_donor` FOREIGN KEY (`profileID`) REFERENCES `blooddonor` (`blooddonorID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blooddonation`
--

LOCK TABLES `blooddonation` WRITE;
/*!40000 ALTER TABLE `blooddonation` DISABLE KEYS */;
INSERT INTO `blooddonation` VALUES (1,1,1,1,NULL),(2,1,2,2,1),(3,1,3,3,NULL),(4,1,4,4,NULL),(5,2,1,5,NULL),(6,2,6,6,NULL),(7,3,4,7,NULL),(8,3,6,8,NULL),(9,3,7,9,NULL),(10,4,4,10,NULL),(11,4,2,11,NULL);
/*!40000 ALTER TABLE `blooddonation` ENABLE KEYS */;
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
