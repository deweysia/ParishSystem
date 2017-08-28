CREATE DATABASE  IF NOT EXISTS `sad2` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `sad2`;
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
-- Table structure for table `applicant`
--

DROP TABLE IF EXISTS `applicant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `applicant` (
  `applicantID` int(11) NOT NULL AUTO_INCREMENT,
  `profileID` int(11) NOT NULL,
  `applicationID` int(11) NOT NULL,
  PRIMARY KEY (`applicantID`),
  KEY `applicant_genprof_idx` (`profileID`),
  KEY `applicant_application_idx` (`applicationID`),
  CONSTRAINT `applicant_application` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `applicant_genprof` FOREIGN KEY (`profileID`) REFERENCES `generalprofile` (`profileID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicant`
--

LOCK TABLES `applicant` WRITE;
/*!40000 ALTER TABLE `applicant` DISABLE KEYS */;
INSERT INTO `applicant` VALUES (5,4,4),(6,5,5);
/*!40000 ALTER TABLE `applicant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `application`
--

DROP TABLE IF EXISTS `application`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `application` (
  `applicationID` int(11) NOT NULL AUTO_INCREMENT,
  `sacramentType` int(11) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `requirements` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`applicationID`),
  KEY `sacType_idx` (`sacramentType`),
  CONSTRAINT `sacType` FOREIGN KEY (`sacramentType`) REFERENCES `itemtype` (`itemTypeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application`
--

LOCK TABLES `application` WRITE;
/*!40000 ALTER TABLE `application` DISABLE KEYS */;
INSERT INTO `application` VALUES (4,1,'1','000000'),(5,2,'1','000');
/*!40000 ALTER TABLE `application` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `baptism`
--

DROP TABLE IF EXISTS `baptism`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `baptism` (
  `baptismID` int(11) NOT NULL AUTO_INCREMENT,
  `applicationID` int(11) NOT NULL,
  `ministerID` int(11) DEFAULT NULL,
  `recordNumber` varchar(45) DEFAULT NULL,
  `pageNumber` varchar(45) DEFAULT NULL,
  `registryNumber` varchar(45) DEFAULT NULL,
  `baptismDate` datetime DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `legitimacy` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`baptismID`),
  KEY `baptism_app_idx` (`applicationID`),
  KEY `baptism_minister_idx` (`ministerID`),
  CONSTRAINT `baptism_app` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `baptism_minister` FOREIGN KEY (`ministerID`) REFERENCES `minister` (`ministerID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `baptism`
--

LOCK TABLES `baptism` WRITE;
/*!40000 ALTER TABLE `baptism` DISABLE KEYS */;
/*!40000 ALTER TABLE `baptism` ENABLE KEYS */;
UNLOCK TABLES;

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
  `quantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`bloodDonationID`),
  KEY `fk_blooddonation_blooddonationevent1_idx` (`bloodDonationEventID`),
  KEY `fk_donor_idx` (`profileID`),
  CONSTRAINT `fk_blooddonation_blooddonationevent1` FOREIGN KEY (`bloodDonationEventID`) REFERENCES `blooddonationevent` (`bloodDonationEventID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_donor` FOREIGN KEY (`profileID`) REFERENCES `blooddonor` (`blooddonorID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blooddonation`
--

LOCK TABLES `blooddonation` WRITE;
/*!40000 ALTER TABLE `blooddonation` DISABLE KEYS */;
/*!40000 ALTER TABLE `blooddonation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blooddonationevent`
--

DROP TABLE IF EXISTS `blooddonationevent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `blooddonationevent` (
  `bloodDonationEventID` int(11) NOT NULL AUTO_INCREMENT,
  `eventName` varchar(45) DEFAULT NULL,
  `startDateTime` datetime DEFAULT NULL,
  `endDateTime` datetime DEFAULT NULL,
  `eventVenue` varchar(45) DEFAULT NULL,
  `eventDetails` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`bloodDonationEventID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blooddonationevent`
--

LOCK TABLES `blooddonationevent` WRITE;
/*!40000 ALTER TABLE `blooddonationevent` DISABLE KEYS */;
/*!40000 ALTER TABLE `blooddonationevent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `blooddonor`
--

DROP TABLE IF EXISTS `blooddonor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `blooddonor` (
  `blooddonorID` int(11) NOT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `midname` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `suffix` varchar(45) DEFAULT NULL,
  `bloodtype` int(11) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `contactnumber` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`blooddonorID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blooddonor`
--

LOCK TABLES `blooddonor` WRITE;
/*!40000 ALTER TABLE `blooddonor` DISABLE KEYS */;
/*!40000 ALTER TABLE `blooddonor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashreleaseitem`
--

DROP TABLE IF EXISTS `cashreleaseitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cashreleaseitem` (
  `cashReleaseID` int(11) NOT NULL AUTO_INCREMENT,
  `CashReleaseVoucherID` int(11) NOT NULL,
  `cashReleaseTypeID` int(11) NOT NULL,
  `releaseAmount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`cashReleaseID`),
  KEY `a_idx` (`cashReleaseTypeID`),
  KEY `b_idx` (`CashReleaseVoucherID`),
  CONSTRAINT `a` FOREIGN KEY (`cashReleaseTypeID`) REFERENCES `itemtype` (`itemTypeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `b` FOREIGN KEY (`CashReleaseVoucherID`) REFERENCES `cashreleasevoucher` (`CashReleaseVoucherID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashreleaseitem`
--

LOCK TABLES `cashreleaseitem` WRITE;
/*!40000 ALTER TABLE `cashreleaseitem` DISABLE KEYS */;
INSERT INTO `cashreleaseitem` VALUES (1,1,1,100.00),(2,5,1,30.00),(3,6,1,1.00),(4,7,1,1.00),(5,8,1,1.00),(6,9,1,1.00),(7,10,2,3.00),(8,10,1,4.00),(9,11,1,3.00),(10,11,2,3.00),(11,12,1,2.00),(12,13,1,200.50),(13,14,2,5.00),(14,14,2,5.00);
/*!40000 ALTER TABLE `cashreleaseitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashreleasetype`
--

DROP TABLE IF EXISTS `cashreleasetype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cashreleasetype` (
  `cashReleaseTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `cashReleaseType` varchar(45) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  `bookType` int(11) NOT NULL,
  `status` int(11) DEFAULT '1',
  PRIMARY KEY (`cashReleaseTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashreleasetype`
--

LOCK TABLES `cashreleasetype` WRITE;
/*!40000 ALTER TABLE `cashreleasetype` DISABLE KEYS */;
INSERT INTO `cashreleasetype` VALUES (1,'Candid','',1,1),(2,'Feeding Program','Food program ',1,1),(3,'ser','',2,1);
/*!40000 ALTER TABLE `cashreleasetype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashreleasevoucher`
--

DROP TABLE IF EXISTS `cashreleasevoucher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cashreleasevoucher` (
  `CashReleaseVoucherID` int(11) NOT NULL AUTO_INCREMENT,
  `cashReleaseDateTime` datetime NOT NULL,
  `remark` varchar(45) DEFAULT NULL,
  `checkNum` int(11) NOT NULL,
  `CVnum` int(11) NOT NULL,
  `bookType` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CashReleaseVoucherID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashreleasevoucher`
--

LOCK TABLES `cashreleasevoucher` WRITE;
/*!40000 ALTER TABLE `cashreleasevoucher` DISABLE KEYS */;
INSERT INTO `cashreleasevoucher` VALUES (1,'2017-08-15 03:30:11','',1,1,1,NULL),(5,'2017-08-15 03:46:12','',2,2,2,NULL),(6,'2017-08-15 03:51:55','',2,2,1,NULL),(7,'2017-08-15 03:55:41','',3,3,1,NULL),(8,'2017-08-15 03:55:52','',4,4,1,NULL),(9,'2017-08-15 03:55:59','',5,5,1,NULL),(10,'2017-08-15 03:58:16','',6,6,1,NULL),(11,'2017-08-15 04:00:37','qqq',7,7,1,NULL),(12,'2017-08-15 04:05:49','qqq',8,8,1,'qqqq'),(13,'2017-08-15 04:06:36','',9,9,1,''),(14,'2017-08-18 22:52:35','',10,10,1,'Justin');
/*!40000 ALTER TABLE `cashreleasevoucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `confirmation`
--

DROP TABLE IF EXISTS `confirmation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `confirmation` (
  `confirmationID` int(11) NOT NULL AUTO_INCREMENT,
  `applicationID` int(11) NOT NULL,
  `ministerID` int(11) DEFAULT NULL,
  `recordNumber` varchar(45) DEFAULT NULL,
  `pageNumber` varchar(45) DEFAULT NULL,
  `registryNumber` varchar(45) DEFAULT NULL,
  `confirmationDate` date DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`confirmationID`),
  KEY `confirmation_app_idx` (`applicationID`),
  KEY `confirmation_minister_idx` (`ministerID`),
  CONSTRAINT `confirmation_app` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `confirmation_minister` FOREIGN KEY (`ministerID`) REFERENCES `minister` (`ministerID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `confirmation`
--

LOCK TABLES `confirmation` WRITE;
/*!40000 ALTER TABLE `confirmation` DISABLE KEYS */;
/*!40000 ALTER TABLE `confirmation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `generalprofile`
--

DROP TABLE IF EXISTS `generalprofile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `generalprofile` (
  `profileID` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(45) DEFAULT NULL,
  `midName` varchar(45) DEFAULT NULL,
  `lastName` varchar(45) DEFAULT NULL,
  `suffix` varchar(5) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `gender` char(1) DEFAULT NULL,
  `birthplace` varchar(45) DEFAULT NULL,
  `residence` int(11) DEFAULT NULL,
  PRIMARY KEY (`profileID`),
  UNIQUE KEY `personName` (`firstName`,`midName`,`lastName`,`suffix`,`birthdate`,`gender`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `generalprofile`
--

LOCK TABLES `generalprofile` WRITE;
/*!40000 ALTER TABLE `generalprofile` DISABLE KEYS */;
INSERT INTO `generalprofile` VALUES (4,'q','q','q','q','2017-07-16','1',NULL,NULL),(5,'a','a','a','a','2017-07-12','1',NULL,NULL);
/*!40000 ALTER TABLE `generalprofile` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `item` (
  `itemID` int(11) NOT NULL AUTO_INCREMENT,
  `itemTypeID` int(11) NOT NULL,
  `primaryIncomeID` int(11) NOT NULL,
  `price` decimal(15,2) NOT NULL,
  `quantity` int(11) NOT NULL,
  PRIMARY KEY (`itemID`),
  UNIQUE KEY `itemID_UNIQUE` (`itemID`),
  KEY `item_itemType_idx` (`itemTypeID`),
  KEY `item_primaryIncome_idx` (`primaryIncomeID`),
  CONSTRAINT `item_itemType` FOREIGN KEY (`itemTypeID`) REFERENCES `itemtype` (`itemTypeID`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `item_primaryIncome` FOREIGN KEY (`primaryIncomeID`) REFERENCES `primaryincome` (`primaryIncomeID`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` VALUES (79,18,98,100.00,1),(80,19,100,200.00,1);
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemtype`
--

DROP TABLE IF EXISTS `itemtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemtype` (
  `itemTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `itemType` varchar(45) NOT NULL,
  `bookType` int(11) NOT NULL,
  `suggestedPrice` decimal(15,2) DEFAULT NULL,
  `status` int(11) NOT NULL,
  `details` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`itemTypeID`),
  UNIQUE KEY `itemTypeID_UNIQUE` (`itemTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemtype`
--

LOCK TABLES `itemtype` WRITE;
/*!40000 ALTER TABLE `itemtype` DISABLE KEYS */;
INSERT INTO `itemtype` VALUES (1,'Baptism',1,100.00,1,NULL),(2,'Confirmation',1,200.00,1,NULL),(3,'Marriage',1,300.00,1,NULL),(17,'Baptism Certificate',1,50.00,1,''),(18,'Confirmation Certificate',1,100.00,1,''),(19,'Marriage Certificate',1,200.00,1,''),(20,'bap',1,0.00,2,''),(21,'Fuel',2,50.00,1,'');
/*!40000 ALTER TABLE `itemtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marriage`
--

DROP TABLE IF EXISTS `marriage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `marriage` (
  `marriageID` int(11) NOT NULL AUTO_INCREMENT,
  `applicationID` int(11) NOT NULL,
  `ministerID` int(11) DEFAULT NULL,
  `recordNumber` varchar(45) DEFAULT NULL,
  `pageNumber` varchar(4) DEFAULT NULL,
  `registryNumber` varchar(45) DEFAULT NULL,
  `licenseDate` date DEFAULT NULL,
  `marriageDate` date DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `civilStatusGroom` int(11) DEFAULT NULL,
  `civilStatusBride` int(11) DEFAULT NULL,
  PRIMARY KEY (`marriageID`),
  KEY `marriage_minister_idx` (`ministerID`),
  KEY `marraige_application_idx` (`applicationID`),
  CONSTRAINT `marraige_application` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `marriage_minister` FOREIGN KEY (`ministerID`) REFERENCES `minister` (`ministerID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marriage`
--

LOCK TABLES `marriage` WRITE;
/*!40000 ALTER TABLE `marriage` DISABLE KEYS */;
/*!40000 ALTER TABLE `marriage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `minister`
--

DROP TABLE IF EXISTS `minister`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `minister` (
  `ministerID` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(45) DEFAULT NULL,
  `midName` varchar(45) DEFAULT NULL,
  `lastName` varchar(45) DEFAULT NULL,
  `suffix` varchar(10) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `ministryType` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `licenseNumber` varchar(45) DEFAULT NULL,
  `expirationDate` date DEFAULT NULL,
  PRIMARY KEY (`ministerID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `minister`
--

LOCK TABLES `minister` WRITE;
/*!40000 ALTER TABLE `minister` DISABLE KEYS */;
INSERT INTO `minister` VALUES (1,'1','1','1','1',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `minister` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ministerschedule`
--

DROP TABLE IF EXISTS `ministerschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ministerschedule` (
  `ministerScheduleID` int(11) NOT NULL AUTO_INCREMENT,
  `ministerID` int(11) DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  `details` varchar(45) DEFAULT NULL,
  `startDateTime` datetime DEFAULT NULL,
  `endDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ministerScheduleID`),
  KEY `ministerschedule_minister_idx` (`ministerID`),
  CONSTRAINT `ministerschedule_minister` FOREIGN KEY (`ministerID`) REFERENCES `minister` (`ministerID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ministerschedule`
--

LOCK TABLES `ministerschedule` WRITE;
/*!40000 ALTER TABLE `ministerschedule` DISABLE KEYS */;
/*!40000 ALTER TABLE `ministerschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parent`
--

DROP TABLE IF EXISTS `parent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parent` (
  `parentID` int(11) NOT NULL AUTO_INCREMENT,
  `profileID` int(11) DEFAULT NULL,
  `firstName` varchar(45) DEFAULT NULL,
  `midName` varchar(45) DEFAULT NULL,
  `lastName` varchar(45) DEFAULT NULL,
  `suffix` varchar(5) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `gender` char(1) DEFAULT NULL,
  `birthplace` varchar(45) DEFAULT NULL,
  `residence` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`parentID`),
  KEY `parent_genprof_idx` (`profileID`),
  CONSTRAINT `parent_genprof` FOREIGN KEY (`profileID`) REFERENCES `generalprofile` (`profileID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parent`
--

LOCK TABLES `parent` WRITE;
/*!40000 ALTER TABLE `parent` DISABLE KEYS */;
/*!40000 ALTER TABLE `parent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `payment` (
  `paymentID` int(11) NOT NULL AUTO_INCREMENT,
  `sacramentIncomeID` int(11) NOT NULL,
  `primaryIncomeID` int(11) NOT NULL,
  `amount` decimal(15,2) NOT NULL,
  PRIMARY KEY (`paymentID`),
  KEY `payment_sacramentIncome_idx` (`sacramentIncomeID`),
  KEY `payment_primaryIncome_idx` (`primaryIncomeID`),
  CONSTRAINT `payment_primaryIncome` FOREIGN KEY (`primaryIncomeID`) REFERENCES `primaryincome` (`primaryIncomeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `payment_sacramentIncome` FOREIGN KEY (`sacramentIncomeID`) REFERENCES `sacramentincome` (`sacramentIncomeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (34,7,100,290.00),(35,7,101,2.00),(36,7,102,3.00);
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `primaryincome`
--

DROP TABLE IF EXISTS `primaryincome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `primaryincome` (
  `primaryIncomeID` int(11) NOT NULL AUTO_INCREMENT,
  `sourceName` varchar(45) DEFAULT NULL,
  `bookType` varchar(45) NOT NULL,
  `ORnum` int(11) NOT NULL,
  `remarks` varchar(45) NOT NULL,
  `primaryIncomeDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`primaryIncomeID`),
  UNIQUE KEY `itemID_UNIQUE` (`primaryIncomeID`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `primaryincome`
--

LOCK TABLES `primaryincome` WRITE;
/*!40000 ALTER TABLE `primaryincome` DISABLE KEYS */;
INSERT INTO `primaryincome` VALUES (96,'','1',1,'','2017-08-26 06:23:52'),(97,'','1',2,'','2017-08-26 06:44:16'),(98,'','1',3,'','2017-08-26 06:44:52'),(99,'','1',4,'','2017-08-27 09:01:27'),(100,'','1',5,'','2017-08-27 02:33:19'),(101,'','1',6,'','2017-08-27 03:59:40'),(102,'','1',7,'','2017-08-27 04:10:26');
/*!40000 ALTER TABLE `primaryincome` ENABLE KEYS */;
UNLOCK TABLES;

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
  `remarks` varchar(45) NOT NULL,
  PRIMARY KEY (`sacramentIncomeID`),
  KEY `sacramentIncome_application_idx` (`applicationID`),
  CONSTRAINT `sacramentIncome_application` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sacramentincome`
--

LOCK TABLES `sacramentincome` WRITE;
/*!40000 ALTER TABLE `sacramentincome` DISABLE KEYS */;
INSERT INTO `sacramentincome` VALUES (6,4,100,''),(7,5,295,'');
/*!40000 ALTER TABLE `sacramentincome` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sponsor`
--

DROP TABLE IF EXISTS `sponsor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sponsor` (
  `sponsorID` int(11) NOT NULL AUTO_INCREMENT,
  `ApplicationID` int(11) DEFAULT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `midname` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `suffix` int(11) DEFAULT NULL,
  `gender` varchar(45) DEFAULT NULL,
  `residence` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`sponsorID`),
  KEY `ApplicationID_idx` (`ApplicationID`),
  CONSTRAINT `ApplicationID` FOREIGN KEY (`ApplicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sponsor`
--

LOCK TABLES `sponsor` WRITE;
/*!40000 ALTER TABLE `sponsor` DISABLE KEYS */;
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

-- Dump completed on 2017-08-28 11:24:42
