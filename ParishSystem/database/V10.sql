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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicant`
--

LOCK TABLES `applicant` WRITE;
/*!40000 ALTER TABLE `applicant` DISABLE KEYS */;
INSERT INTO `applicant` VALUES (1,1,1),(2,2,2),(3,3,3),(4,4,4),(5,5,5),(6,6,6),(7,7,7),(8,1,8),(9,2,9),(10,3,10),(11,4,11),(12,5,12),(13,6,13),(14,1,14),(15,2,14),(16,3,15),(17,4,15),(18,5,16),(19,6,16);
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
  `sacramentType` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `requirements` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`applicationID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application`
--

LOCK TABLES `application` WRITE;
/*!40000 ALTER TABLE `application` DISABLE KEYS */;
INSERT INTO `application` VALUES (1,'1','1',NULL),(2,'1','1',NULL),(3,'1','1',NULL),(4,'1','1',NULL),(5,'1','1',NULL),(6,'1','1',NULL),(7,'1','1',NULL),(8,'2','1',NULL),(9,'2','1',NULL),(10,'2','1',NULL),(11,'2','1',NULL),(12,'2','1',NULL),(13,'2','1',NULL),(14,'3','1',NULL),(15,'3','1',NULL),(16,'3','1',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `baptism`
--

LOCK TABLES `baptism` WRITE;
/*!40000 ALTER TABLE `baptism` DISABLE KEYS */;
INSERT INTO `baptism` VALUES (1,1,1,'7','1','1','2000-12-15 00:00:00',NULL,'1'),(2,2,1,'1','1','1','2000-12-16 00:00:00',NULL,'2'),(3,3,1,'2','1','1','2021-09-20 00:00:00',NULL,'3'),(4,4,1,'3','1','1','2021-09-20 00:00:00',NULL,'1'),(5,5,1,'4','1','1','2021-09-20 00:00:00',NULL,'2'),(6,6,1,'5','1','1','2021-09-20 00:00:00',NULL,'3'),(7,7,1,'6','1','1','2021-09-20 00:00:00',NULL,'1');
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
  KEY `bloodDonation_generalProfile_idx` (`profileID`),
  CONSTRAINT `bloodDonation_generalProfile` FOREIGN KEY (`profileID`) REFERENCES `generalprofile` (`profileID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_blooddonation_blooddonationevent1` FOREIGN KEY (`bloodDonationEventID`) REFERENCES `blooddonationevent` (`bloodDonationEventID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blooddonation`
--

LOCK TABLES `blooddonation` WRITE;
/*!40000 ALTER TABLE `blooddonation` DISABLE KEYS */;
INSERT INTO `blooddonation` VALUES (11,1,3,1),(12,1,3,1),(13,1,3,1),(14,1,3,1),(15,1,3,3),(16,1,3,1),(18,1,3,2),(19,1,3,1),(20,1,3,1),(21,1,2,3);
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blooddonationevent`
--

LOCK TABLES `blooddonationevent` WRITE;
/*!40000 ALTER TABLE `blooddonationevent` DISABLE KEYS */;
INSERT INTO `blooddonationevent` VALUES (1,'Blood Donation Eventddds','2018-01-01 00:00:00','2018-01-01 00:00:00','4609 Green Hill Roadddddddds',''),(2,'Blood Charity','2013-05-03 10:40:00','2013-05-05 10:30:00','367 Holden Street',''),(3,'Our Lady of Assumption Blood Donations','2011-02-14 08:40:00','2011-02-16 08:30:00','4166 Jenna Lane','Changed Venue'),(4,'Red Cross Blood Donation Event','2017-11-26 00:00:00','2017-11-28 00:00:00','Hall Place','asdfdv'),(5,'qwertyu','2017-08-01 10:54:58','2017-08-01 10:54:58','111','111'),(6,'serty','2017-08-01 10:56:54','2017-08-01 10:56:54','ertyu','ertyuwerty'),(7,'222','2017-08-01 00:00:00','2017-08-01 00:00:00','222222','sdf'),(8,'1111111222222','2017-08-02 00:00:00','2017-08-03 00:00:00','11111','1111111111122222');
/*!40000 ALTER TABLE `blooddonationevent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashrelease`
--

DROP TABLE IF EXISTS `cashrelease`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cashrelease` (
  `cashReleaseID` int(11) NOT NULL AUTO_INCREMENT,
  `cashReleaseTypeID` int(11) NOT NULL,
  `cashReleaseDateTime` datetime DEFAULT NULL,
  `remarks` varchar(150) DEFAULT NULL,
  `releaseAmount` double DEFAULT NULL,
  `checkNum` int(11) DEFAULT NULL,
  `CVnum` int(11) DEFAULT NULL,
  PRIMARY KEY (`cashReleaseID`),
  KEY `cashRel_cashRelType_idx` (`cashReleaseTypeID`),
  CONSTRAINT `cashRel_cashRelType` FOREIGN KEY (`cashReleaseTypeID`) REFERENCES `cashreleasetype` (`cashReleaseTypeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashrelease`
--

LOCK TABLES `cashrelease` WRITE;
/*!40000 ALTER TABLE `cashrelease` DISABLE KEYS */;
/*!40000 ALTER TABLE `cashrelease` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashreleasetype`
--

DROP TABLE IF EXISTS `cashreleasetype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cashreleasetype` (
  `cashReleaseTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `cashReleaseType` varchar(45) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `bookType` int(11) NOT NULL,
  PRIMARY KEY (`cashReleaseTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashreleasetype`
--

LOCK TABLES `cashreleasetype` WRITE;
/*!40000 ALTER TABLE `cashreleasetype` DISABLE KEYS */;
INSERT INTO `cashreleasetype` VALUES (1,'eeeeeeeddd','lol',2,3),(2,'1111','@@@@@@@@@',1,2),(3,'1111111','111111111',1,3),(4,'2222111','2222',1,2),(5,'3333','33333',2,2),(6,'123456','',1,1),(7,'qwe','qwer',2,1),(8,'zzzz','',2,2);
/*!40000 ALTER TABLE `cashreleasetype` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `confirmation`
--

LOCK TABLES `confirmation` WRITE;
/*!40000 ALTER TABLE `confirmation` DISABLE KEYS */;
INSERT INTO `confirmation` VALUES (1,8,1,'1','1','1','2008-04-01',NULL),(2,9,1,'2','1','1','2008-04-01',NULL),(3,10,1,'3','1','1','2008-04-01',NULL),(4,11,1,'4','1','1','2008-04-01',NULL),(5,12,1,'5','1','1','2008-04-01',NULL),(6,13,1,'6','1','1','2008-04-01',NULL);
/*!40000 ALTER TABLE `confirmation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `downpaymentprofile`
--

DROP TABLE IF EXISTS `downpaymentprofile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `downpaymentprofile` (
  `downpaymentprofileID` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `suffix` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `contactnumber` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`downpaymentprofileID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `downpaymentprofile`
--

LOCK TABLES `downpaymentprofile` WRITE;
/*!40000 ALTER TABLE `downpaymentprofile` DISABLE KEYS */;
INSERT INTO `downpaymentprofile` VALUES (1,'','','','','',''),(2,'','','','','',''),(3,'q','q','q','q','',''),(4,'q','q','q','q','1','1111111111'),(5,'Harvard','L','Mindoro','jr','','');
/*!40000 ALTER TABLE `downpaymentprofile` ENABLE KEYS */;
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
  `address` varchar(45) DEFAULT NULL,
  `birthplace` varchar(45) DEFAULT NULL,
  `contactNumber` varchar(45) DEFAULT NULL,
  `bloodType` varchar(3) DEFAULT NULL,
  `residence` int(11) DEFAULT NULL,
  PRIMARY KEY (`profileID`),
  UNIQUE KEY `personName` (`firstName`,`midName`,`lastName`,`suffix`,`birthdate`,`gender`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `generalprofile`
--

LOCK TABLES `generalprofile` WRITE;
/*!40000 ALTER TABLE `generalprofile` DISABLE KEYS */;
INSERT INTO `generalprofile` VALUES (1,'Dane Thompskonskiee','Me','Baltimoree','ee','0001-01-01','0','qqqq111111ee','','2221111111','7',NULL),(2,'Vladimir','C','Mcdowell','','2017-05-11','1','Ap #409-6482 Nec, Street','812-2009 Viverra. Road','0950317988','1',NULL),(3,'Sigourney','E','Thornton',NULL,'2017-07-28','1','Ap #222-923 Vestibulum Road','P.O. Box 277, 2688 Lorem Avenue','097-352-2071','O',NULL),(4,'Upton','B','Wise',NULL,'2016-10-20','1','322 Vulputate Rd.','2575 Phasellus Ave','090-868-7562','AB',NULL),(5,'Jermaine','G','Rollins',NULL,'2016-09-22','1','5389 Placerat, Road','P.O. Box 465, 494 Tincidunt Rd.','096-301-0412','B',NULL),(6,'Quinn','S','Mann',NULL,'2016-10-21','1','466-8180 Ipsum. Street','239-5039 Curabitur Av.','091-996-8967','A',NULL),(7,'Zahir','L','Jimenez',NULL,'2017-12-06','1','7184 Magna, Ave','696-3088 Nibh. Road','090-770-2255','AB',NULL),(8,'a','a','a','','0001-00-01','0','','','',NULL,NULL),(9,'b','b','b',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(10,'www','www','swww','www',NULL,NULL,'1111',NULL,'1111111111','1',NULL),(11,'q','q','qqq','',NULL,NULL,'',NULL,'0000000000','1',NULL),(12,'q','q','qqq','',NULL,NULL,'',NULL,'0000000000','1',NULL),(13,'www','ww','ww','www',NULL,NULL,'',NULL,'','1',NULL),(14,'www','ww','ww','www',NULL,NULL,'',NULL,'','4',NULL),(15,'www','ww','www','www',NULL,NULL,'',NULL,'','1',NULL),(16,'qq','qq','qqqq','qq',NULL,NULL,'',NULL,'','1',NULL),(17,'qq','qq','qqqq','qq',NULL,NULL,'',NULL,'','1',NULL),(18,'qq','qq','qqqq','qq',NULL,NULL,'',NULL,'','4',NULL),(19,'qq','qq','qq','qq',NULL,NULL,'',NULL,'','1',NULL),(20,'qqqq','qq','qqq','qq',NULL,NULL,'',NULL,'1111111111','1',NULL),(21,'www','www','www','ww',NULL,NULL,'',NULL,'','1',NULL),(22,'qqqq','qq','qqqq','qq',NULL,NULL,'qwert',NULL,'','5',NULL),(23,'qqqq','qqqq','qqqq','qqq',NULL,NULL,'',NULL,'','5',NULL);
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
  CONSTRAINT `item_itemType` FOREIGN KEY (`itemTypeID`) REFERENCES `itemtype` (`itemTypeID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `item_primaryIncome` FOREIGN KEY (`primaryIncomeID`) REFERENCES `primaryincome` (`primaryIncomeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` VALUES (1,1,1,1.00,1),(2,3,14,1.00,2),(3,3,15,1.00,1),(4,6,16,501.40,2),(5,2,17,3.00,2),(6,6,18,502.40,3),(7,4,18,102.00,4),(8,6,19,502.40,2),(9,3,21,2.00,3),(10,2,21,4.00,3),(11,1,21,3.21,3),(12,7,22,23.00,2),(13,6,23,501.40,2),(14,3,24,1.00,1),(15,2,24,3.00,1),(16,3,24,1.00,1),(17,2,24,4.00,1),(18,3,24,2.00,1),(19,1,25,3.21,1),(20,2,25,2.00,7);
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemtype`
--

LOCK TABLES `itemtype` WRITE;
/*!40000 ALTER TABLE `itemtype` DISABLE KEYS */;
INSERT INTO `itemtype` VALUES (1,'1111',1,1.21,1,'qwerty'),(2,'11111',1,2.00,1,'11111'),(3,'3333333333',1,0.00,1,'333'),(4,'444',3,100.00,1,''),(5,'12345678',1,6000000000.00,2,''),(6,'2131@@@@',3,500.40,1,''),(7,'asdasdadasd',2,22.00,1,''),(8,'uioyidy23r78',1,0.00,2,'asdasdasdadad');
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marriage`
--

LOCK TABLES `marriage` WRITE;
/*!40000 ALTER TABLE `marriage` DISABLE KEYS */;
INSERT INTO `marriage` VALUES (1,14,1,'1','1','1',NULL,'2000-01-01','1',NULL,1,1),(2,15,1,'2','1','1',NULL,'2000-01-01','1',NULL,1,1),(3,16,1,'3','1','1',NULL,'2000-01-01','1',NULL,1,1);
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
INSERT INTO `minister` VALUES (1,'Apolinario','Misero','Apollo','Jr',NULL,NULL,NULL,NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parent`
--

LOCK TABLES `parent` WRITE;
/*!40000 ALTER TABLE `parent` DISABLE KEYS */;
INSERT INTO `parent` VALUES (1,1,'Joshua','A','Baxter',NULL,NULL,'1','Davao','Davao'),(2,1,'Ururuk','B','boron',NULL,NULL,'2','Davao','Davao'),(4,2,'Denver','D','lithium',NULL,NULL,'2','Davao','Davao'),(5,3,'York','E','manganese',NULL,NULL,'1','Davao','Davao'),(6,3,'England','F','magnesium',NULL,NULL,'2','Davao','Davao'),(7,4,'UK','G','krypton',NULL,NULL,'1','Davao','Davao'),(8,4,'banjo','H','hydrogen',NULL,NULL,'2','Davao','Davao'),(9,5,'label','I','oxygen',NULL,NULL,'1','Davao','Davao'),(10,5,'cinder','J','sulfur',NULL,NULL,'2','Davao','Davao'),(11,6,'coconut','K','earth',NULL,NULL,'1','Davao','Davao'),(12,6,'glass','L','mars',NULL,NULL,'2','Davao','Davao'),(13,7,'tiles','M','jupiter',NULL,NULL,'1','Davao','Davao'),(14,7,'frame','N','saturn',NULL,NULL,'2','Davao','Davao'),(15,1,'Joshua','A','Baxter','',NULL,'M','Davao',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (1,1,26,200.00),(2,1,27,4.00);
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
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `primaryincome`
--

LOCK TABLES `primaryincome` WRITE;
/*!40000 ALTER TABLE `primaryincome` DISABLE KEYS */;
INSERT INTO `primaryincome` VALUES (1,'11','1',13400,'1',NULL),(2,'22','2',13401,'2',NULL),(3,'1','1',13401,'1',NULL),(4,'1','1',1,'1',NULL),(5,'1','1',1,'1',NULL),(6,'','1',13403,'','2017-08-05 02:08:25'),(7,'','1',13405,'','2017-08-05 02:13:00'),(8,'','1',13407,'','2017-08-05 02:18:18'),(9,'','1',13409,'','2017-08-05 02:20:24'),(10,'','1',13411,'','2017-08-05 02:21:21'),(11,'','1',13413,'','2017-08-05 02:22:16'),(12,'','1',13415,'','2017-08-05 02:25:13'),(13,'','1',13417,'','2017-08-05 02:27:38'),(14,'','1',13419,'','2017-08-05 02:28:55'),(15,'qqq','1',13421,'qqqq','2017-08-05 02:39:34'),(16,'wewe','3',1,'wer','2017-08-05 02:46:30'),(17,'','1',13422,'','2017-08-05 02:51:26'),(18,'','3',2,'','2017-08-05 02:52:02'),(19,'','3',3,'','2017-08-05 02:52:12'),(20,'','1',13423,'','2017-08-05 02:55:54'),(21,'','1',13424,'','2017-08-05 02:58:26'),(22,'','2',13402,'','2017-08-05 02:58:34'),(23,'','3',4,'','2017-08-05 02:58:41'),(24,'','1',13425,'','2017-08-05 10:10:10'),(25,'Bayantel','1',13426,'Bla Bla','2017-08-06 05:49:50'),(26,'qqqq','1',13427,'qqqq','2017-08-06 05:49:50'),(27,'','1',13428,'','2017-08-08 10:52:37'),(28,'','1',13429,'','2017-08-08 10:53:22');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sacramentincome`
--

LOCK TABLES `sacramentincome` WRITE;
/*!40000 ALTER TABLE `sacramentincome` DISABLE KEYS */;
INSERT INTO `sacramentincome` VALUES (1,1,1000,'hoe');
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sponsor`
--

LOCK TABLES `sponsor` WRITE;
/*!40000 ALTER TABLE `sponsor` DISABLE KEYS */;
INSERT INTO `sponsor` VALUES (1,14,'boron','A','anderson',NULL,'1','Davao'),(2,14,'carbon','B','random',NULL,'2','Davao'),(3,15,'lithium','C','burger',NULL,'1','Davao'),(4,15,'cesium','D','graham',NULL,'2','Davao'),(5,16,'manganese','E','mary',NULL,'1','Davao'),(6,16,'bernard','F','parker',NULL,'2','Davao'),(7,1,'xenon','G','lambert',NULL,'1','Davao'),(8,1,'germanium','H','somnus',NULL,'2','Davao'),(9,14,'krypton','I','iris',NULL,'1','Davao'),(10,14,'manganese','J','hera',NULL,'2','Davao'),(11,15,'lepton','K','artimes',NULL,'1','Davao'),(12,15,'tauon','L','dyonisius',NULL,'2','Davao');
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

-- Dump completed on 2017-08-09  1:02:09
