-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: sad2
-- ------------------------------------------------------
-- Server version	5.7.16-log

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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `applicant`
--

LOCK TABLES `applicant` WRITE;
/*!40000 ALTER TABLE `applicant` DISABLE KEYS */;
INSERT INTO `applicant` VALUES (9,8,10),(10,9,11),(11,9,15),(12,8,13),(13,9,13),(14,11,14),(15,12,22),(16,13,20),(17,14,21);
/*!40000 ALTER TABLE `applicant` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Applicant_BI BEFORE INSERT 
ON Applicant FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DEClARE operation INT;
    DECLARE newRecord TEXT;
    
	DECLARE person TEXT;
    DECLARE sacramentType TEXT;
    
    SELECT CONCAT_WS(' ', firstName, midName, lastName, suffix), 
    getSacrament(sacramentType) INTO person, sacramentType FROM GeneralProfile NATURAL JOIN Applicant NATURAL JOIN Application
    WHERE GeneralProfile.profileID = NEW.profileID;
    
    SET tableName = 'Applicant';
    SET operation = 1;
    SET newRecord = CONCAT_WS('; ', 
    CONCAT('Name:  ', person), 
    CONCAT('Sacrament Type: ', sacramentType));
    
    INSERT INTO auditlog(tableName, operation, newRecord, userID) VALUES (tableName, operation, newRecord, @userID);

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `application`
--

DROP TABLE IF EXISTS `application`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `application` (
  `applicationID` int(11) NOT NULL AUTO_INCREMENT,
  `sacramentType` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `requirements` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`applicationID`),
  KEY `sacType_idx` (`sacramentType`),
  CONSTRAINT `sacType` FOREIGN KEY (`sacramentType`) REFERENCES `itemtype` (`itemTypeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application`
--

LOCK TABLES `application` WRITE;
/*!40000 ALTER TABLE `application` DISABLE KEYS */;
INSERT INTO `application` VALUES (10,1,2,'111'),(11,1,1,'001'),(12,2,1,'000'),(13,3,2,'000111'),(14,1,1,'000'),(15,2,1,'000'),(16,2,1,'000'),(17,2,1,'000'),(18,2,1,'000'),(19,2,1,'000'),(20,2,2,'000'),(21,1,1,'000'),(22,2,1,'111');
/*!40000 ALTER TABLE `application` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Application_AU AFTER UPDATE
ON Application FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation TEXT;
    DECLARE newRecord TEXT;
	DECLARE oldRecord TEXT;
    
	DECLARE person TEXT;
    DECLARE details TEXT;
    DECLARE numRow INT;
    
	#Retrieve Groom Bride if Marriage, retrieve Person if Baptism or Confirmation
	DECLARE groom TEXT;
	DECLARE bride TEXT;
    
    
    SELECT 
    IF(NEW.requirements = OLD.requirements, '', 'Updated Requirements')
    INTO details 
    FROM GeneralProfile NATURAL JOIN Applicant NATURAL JOIN Application
    WHERE Application.applicationID = NEW.applicationID LIMIT 0,1;

	SET person = getApplicationPersons(New.applicationID);

    SET tableName = 'Application';
    SET operation = 2;
    SET newRecord = CONCAT_WS('; ', 
    CONCAT('Name: ', person), 
    CONCAT('Sacrament Type: ', getSacrament(NEW.sacramentType)), 
    CONCAT('Status: ', getApplicationStatus(NEW.status)));
    
    SET oldRecord = CONCAT_WS('; ', 
    CONCAT('Name: ', person), 
    CONCAT('Sacrament Type: ', getSacrament(OLD.sacramentType)), 
    CONCAT('Status: ', getApplicationStatus(OLD.status)));
    
    INSERT INTO auditlog(tableName, operation, oldRecord, newRecord, details, userID) VALUES ('Application', 2, oldRecord, newRecord, details, @userID);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `auditlog`
--

DROP TABLE IF EXISTS `auditlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `auditlog` (
  `auditLogID` int(11) NOT NULL AUTO_INCREMENT,
  `tableName` varchar(100) DEFAULT NULL,
  `operation` int(11) DEFAULT NULL,
  `oldRecord` text,
  `newRecord` text,
  `auditDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `details` varchar(45) DEFAULT NULL,
  `userID` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`auditLogID`)
) ENGINE=InnoDB AUTO_INCREMENT=137 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `auditlog`
--

LOCK TABLES `auditlog` WRITE;
/*!40000 ALTER TABLE `auditlog` DISABLE KEYS */;
INSERT INTO `auditlog` VALUES (1,'generalProfile',1,'Yoo','YaaA','2017-09-16 10:53:39',NULL,NULL),(2,'Profile',1,NULL,'First Name = Justin Henry; M.I. = C; Last Name = Lo; Birthdate = 1998-12-16; Residence = Damosa; Birth Place = Davao','2017-09-16 11:17:50',NULL,NULL),(3,'Profile',2,'First Name: Justin Henry; M.I.: C; Last Name: Lo; Birthdate: 1998-12-16; Residence: Damosa; Birth Place: Davao','First Name: Justin Henry; M.I.: C; Last Name: Lu; Birthdate: 1998-12-16; Residence: Damosa; Birth Place: Davao','2017-09-16 11:55:13',NULL,NULL),(4,'Profile',3,'First Name: Justin Henry; M.I.: C; Last Name: Lu; Birthdate: 1998-12-16; Residence: Damosa; Birth Place: Davao',NULL,'2017-09-16 11:55:39',NULL,NULL),(5,'Profile',1,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16','2017-09-17 05:29:22',NULL,NULL),(6,'Profile',1,NULL,'First Name: Rachel; M.I.: D; Last Name: Shwartz; Suffix: ; Birthdate: 2017-02-01','2017-09-17 06:12:50',NULL,NULL),(7,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 15:17:26',NULL,NULL),(8,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultze; Suffix: ; Birthdate: 2017-09-10','2017-09-19 15:21:02',NULL,NULL),(9,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 15:21:41',NULL,'2'),(10,'Profile',2,NULL,'First Name: Andreia; M.I.: Q; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:28:02',NULL,NULL),(11,'Profile',2,NULL,'First Name: Rachel; M.I.: D; Last Name: Shwart; Suffix: ; Birthdate: 2017-02-01','2017-09-19 17:37:33',NULL,'2'),(12,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 17:52:57',NULL,'2'),(13,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 17:53:10',NULL,'2'),(14,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:53:21',NULL,'2'),(15,'Profile',2,NULL,'First Name: Andreia; M.I.: Q; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:56:15',NULL,'2'),(16,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:58:23',NULL,'2'),(17,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:59:04',NULL,'2'),(18,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 18:10:00',NULL,'1'),(19,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 22:51:10',NULL,'2'),(20,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 22:51:35',NULL,'2'),(21,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 22:52:01',NULL,'2'),(22,'Profile',2,NULL,'First Name: Andreia; M.I.: Q; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 22:52:17',NULL,'2'),(23,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 23:58:11',NULL,'1'),(24,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Greyrock','2017-09-20 09:24:05',NULL,'2'),(25,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:24:05',NULL,'2'),(26,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:40:16',NULL,'2'),(27,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:40:17',NULL,'2'),(28,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:42:03',NULL,'2'),(29,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:42:03',NULL,'2'),(30,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:43:08',NULL,'2'),(31,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:43:08',NULL,'2'),(32,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:33:39',NULL,'2'),(33,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:33:39',NULL,'2'),(34,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:35:52',NULL,'2'),(35,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:35:52',NULL,'2'),(36,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:38:25',NULL,'2'),(37,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:38:25',NULL,'2'),(38,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:41:25',NULL,'2'),(39,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:41:25',NULL,'2'),(40,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Postone','2017-09-20 11:42:47',NULL,'2'),(41,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:42:47',NULL,'2'),(42,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Postone','2017-09-20 13:50:05',NULL,'2'),(43,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 13:50:05',NULL,'2'),(44,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Postone','2017-09-20 13:53:18',NULL,'2'),(45,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 13:53:29',NULL,'2'),(46,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Postone','2017-09-20 13:56:35',NULL,'2'),(47,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 13:56:42',NULL,'2'),(48,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-20 14:02:19',NULL,'2'),(49,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 14:02:22',NULL,'2'),(50,'Profile',2,NULL,'First Name: Dina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 14:28:24',NULL,'2'),(51,'Profile',2,NULL,'First Name: Dinaa; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 14:36:55',NULL,'2'),(52,'Profile',2,NULL,'First Name: Dina; M.I.: Fitzgerald; Last Name: A; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:41:47',NULL,'2'),(53,'Profile',2,NULL,'First Name: Dina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:41:55',NULL,'2'),(54,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:44:45',NULL,'2'),(55,'Profile',2,NULL,'First Name: Dina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:44:56',NULL,'2'),(56,'Profile',2,NULL,'First Name: Dinaq; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:52:49',NULL,'2'),(57,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:53:12',NULL,'2'),(58,'Application',2,'Name: Jim C Tang Jr; Sacrament TypeCase not found; Status: Approved','Name: Jim C Tang Jr; Sacrament TypeCase not found; Status: Pending','2017-09-21 06:16:49','',NULL),(59,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','2017-09-21 06:18:40','',NULL),(60,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','2017-09-21 06:22:28','',NULL),(61,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','2017-09-21 06:22:45','',NULL),(62,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','2017-09-21 06:23:43','',NULL),(63,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: 1; Status: Pending','Name: Jim C Tang Jr; Sacrament Type: 1; Status: Approved','2017-09-21 06:24:47','',NULL),(64,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Baptism; Status: Approved','Name: Jim C Tang Jr; Sacrament Type: Baptism; Status: Pending','2017-09-21 06:26:03','',NULL),(65,'Application',2,'Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Pending','Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Approved','2017-09-21 06:26:03','',NULL),(66,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Baptism; Status: Pending','Name: Jim C Tang Jr; Sacrament Type: Baptism; Status: Approved','2017-09-21 06:31:04','',NULL),(67,'Application',2,'Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Approved','Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Pending','2017-09-21 06:32:30','',NULL),(68,'Application',2,'Sacrament Type: Case not found; Status: Approved','Sacrament Type: Case not found; Status: Pending','2017-09-21 06:32:40',NULL,NULL),(69,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','2017-09-21 08:19:14','Updated Requirements',NULL),(70,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Pending','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Pending','2017-09-21 08:22:14','Updated Requirements',NULL),(71,'Application',2,'Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Pending','Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Pending','2017-09-21 08:22:46','Updated Requirements',NULL),(72,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Pending','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:36:44','',NULL),(73,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:39:33','',NULL),(74,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:41:00','Updated Requirements',NULL),(75,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: 3; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: 3; Status: Approved','2017-09-21 08:42:17','Updated Requirements',NULL),(76,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:54:07','Updated Requirements',NULL),(77,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:57:09','Updated Requirements',NULL),(78,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found 3; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found 3; Status: Approved','2017-09-21 08:58:45','Updated Requirements',NULL),(79,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Pending','2017-09-21 09:02:01','',NULL),(80,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:23:19',NULL,'2'),(81,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:23:22',NULL,'2'),(82,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Pending','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:23:27','','2'),(83,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:23:29','','2'),(84,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:25:51',NULL,'2'),(85,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:26:01',NULL,'2'),(86,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:26:50','','2'),(87,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:26:51','','2'),(88,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:27:40',NULL,'2'),(89,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:27:56',NULL,'2'),(90,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:29:00','','2'),(91,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:29:01','','2'),(92,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:33:07',NULL,'2'),(93,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:34:06',NULL,'2'),(94,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:34:30',NULL,'2'),(95,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:37:53',NULL,'2'),(96,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:38:06',NULL,'2'),(97,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:40:46','','2'),(98,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:40:47','','2'),(99,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:41:58',NULL,'2'),(100,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:42:07',NULL,'2'),(101,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 08:07:11',NULL,'2'),(102,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 08:07:12',NULL,'2'),(103,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 08:07:33','','2'),(104,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 08:07:34','','2'),(105,'Profile',2,NULL,'First Name: Rachel; M.I.: D; Last Name: Shwartz; Suffix: ; Birthdate: 2017-02-01','2017-09-22 08:46:07',NULL,'2'),(106,'Application',2,'Name: Rachel D Shwartz ; Sacrament Type: Baptism; Status: Pending','Name: Rachel D Shwartz ; Sacrament Type: Baptism; Status: Pending','2017-09-22 08:46:07','','2'),(107,'Profile',2,NULL,'First Name: Andre; M.I.: Gaultz; Last Name: C; Suffix: ; Birthdate: 2017-09-10','2017-09-22 08:46:17',NULL,'2'),(108,'Application',2,'Name: Andre Gaultz C ; Sacrament Type: Confirmation; Status: Pending','Name: Andre Gaultz C ; Sacrament Type: Confirmation; Status: Pending','2017-09-22 08:46:17','','2'),(109,'Minister',1,NULL,'Name: Joseph A Numire; Birthdate: 1970-10-22; Ministry Type: Archbishop; Status: Active','2017-09-22 09:51:02',NULL,NULL),(110,'Minister',2,NULL,'Name: Joseph A Numirez; Birthdate: 1970-10-22; Ministry Type: Archbishop; Status: Active','2017-09-23 08:48:38',NULL,NULL),(111,'Minister',2,'Name: Joseph A Numirez; Birthdate: 1970-10-22; Ministry Type: Archbishop; Status: Active','Name: Joseph A Numire; Birthdate: 1970-10-22; Ministry Type: Archbishop; Status: Active','2017-09-23 08:49:53',NULL,NULL),(112,'Minister',1,NULL,'Name: Jonathan A Jostar Jr; Birthdate: 1880-11-14; Ministry Type: Priest; Status: Active','2017-09-23 08:52:02',NULL,NULL),(113,'Minister',3,'Name: Jonathan A Jostar Jr; Birthdate: 1880-11-14; Ministry Type: Priest; Status: Active',NULL,'2017-09-23 08:52:28',NULL,NULL),(114,'Item Type',1,NULL,'Item Type: Death Certificate; Book Type: Case not found; Transaction Type: Cash Receipt; Suggested Price: 2500.00; Status: Active','2017-09-23 11:25:02',NULL,NULL),(115,'Item Type',2,'Item Type: Death Certificate; Book Type: Case not found; Transaction Type: Cash Receipt; Suggested Price: 2500.00','Item Type: Death Certificate; Book Type: Case not found; Transaction Type: Cash Receipt; Suggested Price: 2000.00','2017-09-23 19:54:45',NULL,NULL),(116,'Item Type',3,'Item Type: Death Certificate; Book Type: Case not found; Transaction Type: Cash Receipt; Suggested Price: 2000.00',NULL,'2017-09-23 19:57:20',NULL,NULL),(117,'Primary Income',3,NULL,'Source: George; Book Type: Case not found; OR Number: 2; Remarks: George\'s Payment','2017-09-23 21:10:59',NULL,NULL),(118,'Primary Income',3,'Source: George; Book Type: Parish; OR Number: 2; Remarks: George\'s Payment',NULL,'2017-09-23 21:14:22',NULL,NULL),(119,'Primary Income',3,NULL,'Source: George; Book Type: Parish; OR Number: 2; Remarks: Danielle\'s Baptism; Income Time: 2017-09-24 00:00:00','2017-09-23 21:18:35',NULL,NULL),(120,'Primary Income',3,NULL,'Source: Geralt; Book Type: Parish; OR Number: 3; Remarks: Hard Liquor','2017-09-23 21:20:38',NULL,NULL),(121,'Primary Income',3,NULL,'Source: Deralt; Book Type: Parish; OR Number: 4; Remarks: Soft Drink; Income Time: 2017-09-24 00:00:00','2017-09-23 21:21:21',NULL,NULL),(122,'Primary Income',2,NULL,'Source: Deralt; Book Type: Parish; OR Number: 4; Remarks: Hard Liquor; Income Time: 2017-09-24 00:00:00','2017-09-23 21:24:57',NULL,NULL),(123,'Primary Income',2,NULL,'Source: Deralt; Book Type: Parish; OR Number: 4; Remarks: Soft Liquor; Income Time: 2017-09-24 00:00:00','2017-09-23 21:26:25',NULL,NULL),(124,'Primary Income',2,'Source: Deralt; Book Type: Parish; OR Number: 4; Remarks: Soft Liquor; Income Time: 2017-09-24 00:00:00','Source: Deralte; Book Type: Parish; OR Number: 4; Remarks: Booze; Income Time: 2017-09-24 00:00:00','2017-09-23 21:28:00',NULL,NULL),(126,'Primary Income',1,NULL,'OR Number: 1; Payment Amount: 250.00','2017-09-23 21:43:15',NULL,NULL),(127,'Primary Income',1,NULL,'Payment Amount: 250.00','2017-09-23 21:47:51',NULL,NULL),(128,'Primary Income',1,NULL,'Payment Amount: 100.00','2017-09-23 21:55:33',NULL,NULL),(129,'Payment',1,NULL,'Payment Amount: 120.00','2017-09-23 22:00:18',NULL,NULL),(130,'Payment',1,NULL,'OR Number: -1; Payment Amount: 50.00','2017-09-23 22:01:14',NULL,NULL),(131,'Payment',1,NULL,'OR Number: 2; Payment Amount: 50.00','2017-09-24 06:27:26',NULL,NULL),(132,'Cash Release Voucher',3,'Title: SAD Defense; Details: SAD 2 Defense; Start Time: 2017-09-30 13:00:00; End Time: 2017-09-30 14:30:00','Title: SAD 2 Defense; Details: SoftEng Defense; Start Time: 2017-09-30 13:00:00; End Time: 2017-09-30 14:30:00','2017-09-24 06:48:03',NULL,NULL),(133,'Cash Release Voucher',1,NULL,'Title: Ohnana; Details: Whats my name; Start Time: 2017-09-12 10:12:00; End Time: 2017-09-12 11:12:00','2017-09-24 06:49:15',NULL,NULL),(134,'Cash Release Voucher',3,'Title: Ohnana; Details: Whats my name; Start Time: 2017-09-12 10:12:00; End Time: 2017-09-12 11:12:00',NULL,'2017-09-24 06:49:29',NULL,NULL),(135,'Appointment',1,NULL,'Title: Defense Payment; Details: Inquire and pay; Start Time: 2017-09-15 12:34:00; End Time: 2017-09-15 14:34:00; Minister: Boyle A Royce II','2017-09-24 07:01:07',NULL,NULL),(136,'Appointment',2,'Title: Defense Payment; Details: Inquire and pay; Start Time: 2017-09-15 12:34:00; End Time: 2017-09-15 14:34:00; Minister: Boyle A Royce II','Title: Defense Payments; Details: Inquire and Seek advice; Start Time: 2017-09-15 12:50:00; End Time: 2017-09-15 14:34:00; Minister: Joseph A Numire','2017-09-24 07:04:20',NULL,NULL);
/*!40000 ALTER TABLE `auditlog` ENABLE KEYS */;
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
  `baptismDate` date DEFAULT NULL,
  `remarks` text,
  `legitimacy` int(11) DEFAULT NULL,
  PRIMARY KEY (`baptismID`),
  KEY `baptism_app_idx` (`applicationID`),
  KEY `baptism_minister_idx` (`ministerID`),
  CONSTRAINT `baptism_app` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `baptism_minister` FOREIGN KEY (`ministerID`) REFERENCES `minister` (`ministerID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `baptism`
--

LOCK TABLES `baptism` WRITE;
/*!40000 ALTER TABLE `baptism` DISABLE KEYS */;
INSERT INTO `baptism` VALUES (2,10,3,'110','55','336','2017-09-21','',2);
/*!40000 ALTER TABLE `baptism` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bloodclaimant`
--

DROP TABLE IF EXISTS `bloodclaimant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bloodclaimant` (
  `bloodclaimantID` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` text,
  `midname` text,
  `lastname` text,
  `suffix` text,
  PRIMARY KEY (`bloodclaimantID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bloodclaimant`
--

LOCK TABLES `bloodclaimant` WRITE;
/*!40000 ALTER TABLE `bloodclaimant` DISABLE KEYS */;
/*!40000 ALTER TABLE `bloodclaimant` ENABLE KEYS */;
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
  `donationID` int(11) NOT NULL,
  `bloodclaimant` int(11) DEFAULT NULL,
  PRIMARY KEY (`bloodDonationID`),
  KEY `fk_blooddonation_blooddonationevent1_idx` (`bloodDonationEventID`),
  KEY `fk_donor_idx` (`profileID`),
  KEY `fk_claimant_idx` (`bloodclaimant`),
  CONSTRAINT `fk_blooddonation_blooddonationevent1` FOREIGN KEY (`bloodDonationEventID`) REFERENCES `blooddonationevent` (`bloodDonationEventID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_claimant` FOREIGN KEY (`bloodclaimant`) REFERENCES `bloodclaimant` (`bloodclaimantID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_donor` FOREIGN KEY (`profileID`) REFERENCES `blooddonor` (`blooddonorID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
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
  `eventName` text,
  `startDateTime` datetime DEFAULT NULL,
  `endDateTime` datetime DEFAULT NULL,
  `eventVenue` text,
  `eventDetails` text,
  PRIMARY KEY (`bloodDonationEventID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
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
  `blooddonorID` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` text,
  `midname` text,
  `lastname` text,
  `suffix` varchar(45) DEFAULT NULL,
  `bloodtype` int(11) DEFAULT NULL,
  `address` text,
  `contactnumber` text,
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashreleaseitem`
--

LOCK TABLES `cashreleaseitem` WRITE;
/*!40000 ALTER TABLE `cashreleaseitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `cashreleaseitem` ENABLE KEYS */;
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
  `name` text,
  PRIMARY KEY (`CashReleaseVoucherID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashreleasevoucher`
--

LOCK TABLES `cashreleasevoucher` WRITE;
/*!40000 ALTER TABLE `cashreleasevoucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `cashreleasevoucher` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER CashReleaseVoucher_AI AFTER INSERT
ON CashReleaseVoucher FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    
    
    SET tableName = 'Cash Release Voucher';
    SET operation = 1;
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Check Number: ', NEW.checkNum),
    CONCAT('Cash Voucher Number: ', NEW.CVnum),
    CONCAT('Name: ', NEW.name),
    CONCAT('Book Type: ', NEW.bookType),
    CONCAT('Cash Release Time: ', NEW.cashReleaseDateTime));
    
    INSERT INTO auditlog(tableName, operation, newRecord) VALUES (tableName, operation, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
  `remarks` text,
  PRIMARY KEY (`confirmationID`),
  KEY `confirmation_app_idx` (`applicationID`),
  KEY `confirmation_minister_idx` (`ministerID`),
  CONSTRAINT `confirmation_app` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `confirmation_minister` FOREIGN KEY (`ministerID`) REFERENCES `minister` (`ministerID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `confirmation`
--

LOCK TABLES `confirmation` WRITE;
/*!40000 ALTER TABLE `confirmation` DISABLE KEYS */;
INSERT INTO `confirmation` VALUES (1,12,3,NULL,NULL,NULL,'2017-09-09',''),(2,20,3,NULL,NULL,NULL,'2017-09-20','');
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
  `firstName` text,
  `midName` text,
  `lastName` text,
  `suffix` varchar(5) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `birthplace` text,
  `residence` text,
  PRIMARY KEY (`profileID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `generalprofile`
--

LOCK TABLES `generalprofile` WRITE;
/*!40000 ALTER TABLE `generalprofile` DISABLE KEYS */;
INSERT INTO `generalprofile` VALUES (7,'Dewey','L','Sia','','1998-09-26',1,NULL,NULL),(8,'Jim','C','Tang','Jr','2017-09-10',1,'Postonia','Bridgehaven'),(9,'Nina','A','Fitzgerald','','2017-09-10',2,'Poston','Bridgehaven'),(11,'Andreia','Q','Gaultz','','2017-09-10',2,NULL,NULL),(12,'Andre','Gaultz','C','','2017-09-10',2,NULL,NULL),(13,'Francis','A','Robins','','2017-09-16',1,'Postone','Bridgehaven'),(14,'Rachel','D','Shwartz','','2017-02-01',2,NULL,NULL);
/*!40000 ALTER TABLE `generalprofile` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER GeneralProfile_BI
BEFORE INSERT ON GeneralProfile FOR EACH ROW
BEGIN
	
    DECLARE tableName VARCHAR(100);
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    
    SET tableName = 'Profile';
    SET operation = 1;
    SET newRecord =  
    CONCAT_WS('; ', 
    CONCAT('First Name: ', NEW.firstName), 
    CONCAT('M.I.: ', NEW.midName), 
    CONCAT('Last Name: ', NEW.lastName), 
    CONCAT('Suffix: ', NEW.suffix), 
    CONCAT('Birthdate: ', NEW.birthDate),
    CONCAT('Residence: ', NEW.residence),
    CONCAT('Birth Place: ', NEW.birthplace));
    
    INSERT INTO auditlog(tableName, operation, newRecord, userID) VALUES (tableName, operation, newRecord, @userID);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER GeneralProfile_AU AFTER UPDATE 
ON GeneralProfile FOR EACH ROW
BEGIN
	DECLARE tableName VARCHAR(100);
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    DECLARE newRecord TEXT;
    
    SET tableName = 'Profile';
    SET operation = 2;
    SET newRecord =  
    CONCAT_WS('; ', 
    CONCAT('First Name: ', NEW.firstName), 
    CONCAT('M.I.: ', NEW.midName), 
    CONCAT('Last Name: ', NEW.lastName), 
    CONCAT('Suffix: ', NEW.suffix),
    CONCAT('Birthdate: ', NEW.birthDate),
    CONCAT('Residence: ', NEW.residence),
    CONCAT('Birth Place: ', NEW.birthplace));
    
    SET oldRecord = 
    CONCAT_WS('; ', 
    CONCAT('First Name: ', OLD.firstName), 
    CONCAT('M.I.: ', OLD.midName), 
    CONCAT('Last Name: ', OLD.lastName), 
    CONCAT('Suffix: ', OLD.suffix), 
    CONCAT('Birthdate: ', OLD.birthDate),
    CONCAT('Residence: ', OLD.residence),
    CONCAT('Birth Place: ', OLD.birthplace));
    
    INSERT INTO auditlog(tableName, operation, newRecord, userID) VALUES (tableName, operation, newRecord, @userID);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER GeneralProfile_BD BEFORE DELETE
ON GeneralProfile FOR EACH ROW
BEGIN
	DECLARE tableName VARCHAR(100);
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    
    SET tableName = 'Profile';
    SET operation = 3;
    SET oldRecord = 
    CONCAT_WS('; ', 
    CONCAT('First Name: ', OLD.firstName), 
    CONCAT('M.I.: ', OLD.midName), 
    CONCAT('Last Name: ', OLD.lastName), 
    CONCAT('Suffix: ', OLD.suffix), 
    CONCAT('Birthdate: ', OLD.birthDate),
    CONCAT('Residence: ', OLD.residence),
    CONCAT('Birth Place: ', OLD.birthplace));
    
    INSERT INTO auditlog(tableName, operation, newRecord, userID) VALUES (tableName, operation, newRecord, @userID);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
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
  `itemType` text NOT NULL,
  `bookType` int(11) NOT NULL,
  `suggestedPrice` decimal(15,2) DEFAULT NULL,
  `status` int(11) NOT NULL DEFAULT '1',
  `details` text,
  `cashreceipt_cashdisbursment` int(11) DEFAULT NULL,
  PRIMARY KEY (`itemTypeID`),
  UNIQUE KEY `itemTypeID_UNIQUE` (`itemTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemtype`
--

LOCK TABLES `itemtype` WRITE;
/*!40000 ALTER TABLE `itemtype` DISABLE KEYS */;
INSERT INTO `itemtype` VALUES (1,'Baptism',1,200.00,1,NULL,1),(2,'Confirmation',1,500.00,1,NULL,1),(3,'Marriage',1,2000.00,1,NULL,1);
/*!40000 ALTER TABLE `itemtype` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER ItemType_BI BEFORE INSERT 
ON ItemType FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    
    
    SET tableName = 'Item Type';
    SET operation = 1;
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Item Type: ', NEW.ItemType),
    CONCAT('Book Type: ', getBookType(NEW.bookType)),
    CONCAT('Transaction Type: ', getTransactionType(NEW.cashreceipt_cashdisbursment)),
    CONCAT('Suggested Price: ', NEW.suggestedPrice),
    CONCAT('Status: ', getStatus(NEW.status)),
	CONCAT('Details: ', NEW.details));
    
    INSERT INTO auditlog(tableName, operation, newRecord) VALUES (tableName, operation, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER ItemType_AU AFTER UPDATE
ON ItemType FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    DECLARE oldRecord TEXT;
    
    
    SET tableName = 'Item Type';
    SET operation = 2;
    
    SET oldRecord = CONCAT_WS('; ',
	CONCAT('Item Type: ', OLD.ItemType),
    CONCAT('Book Type: ', getBookType(OLD.bookType)),
    CONCAT('Transaction Type: ', getTransactionType(OLD.cashreceipt_cashdisbursment)),
    CONCAT('Suggested Price: ', OLD.suggestedPrice),
    CONCAT('Status: ', getStatus(OLD.status),
	CONCAT('Details: ', OLD.details)));
    
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Item Type: ', NEW.ItemType),
    CONCAT('Book Type: ', getBookType(NEW.bookType)),
    CONCAT('Transaction Type: ', getTransactionType(NEW.cashreceipt_cashdisbursment)),
    CONCAT('Suggested Price: ', NEW.suggestedPrice),
    CONCAT('Status: ', getStatus(NEW.status),
	CONCAT('Details: ', NEW.details)));
    
    
    
    INSERT INTO auditlog(tableName, operation, oldRecord, newRecord) VALUES (tableName, operation, oldRecord, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER ItemType_AD AFTER DELETE
ON ItemType FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    
    
    SET tableName = 'Item Type';
    SET operation = 3;
    
    SET oldRecord = CONCAT_WS('; ',
	CONCAT('Item Type: ', OLD.ItemType),
    CONCAT('Book Type: ', getBookType(OLD.bookType)),
    CONCAT('Transaction Type: ', getTransactionType(OLD.cashreceipt_cashdisbursment)),
    CONCAT('Suggested Price: ', OLD.suggestedPrice),
    CONCAT('Status: ', getStatus(OLD.status),
	CONCAT('Details: ', OLD.details)));
    
    INSERT INTO auditlog(tableName, operation, oldRecord) VALUES (tableName, operation, oldRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
  `status` int(11) DEFAULT NULL,
  `remarks` text,
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
INSERT INTO `marriage` VALUES (1,13,4,NULL,NULL,NULL,'2017-09-09','2017-09-09',NULL,'',1,1);
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
  `firstName` text,
  `midName` text,
  `lastName` text,
  `suffix` varchar(10) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `ministryType` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `licenseNumber` text,
  `expirationDate` date DEFAULT NULL,
  PRIMARY KEY (`ministerID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `minister`
--

LOCK TABLES `minister` WRITE;
/*!40000 ALTER TABLE `minister` DISABLE KEYS */;
INSERT INTO `minister` VALUES (3,'Boyle','A','Royce','II','1960-01-02',2,1,NULL,NULL),(4,'Joshua','F','Lintag','','2017-09-12',1,1,NULL,NULL),(5,'Joseph','A','Numire',NULL,'1970-10-22',3,1,NULL,NULL);
/*!40000 ALTER TABLE `minister` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Minister_BI BEFORE INSERT 
ON Minister FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    DECLARE person TEXT;
    
    SET tableName = 'Minister';
    SET operation = 1;
    SET person = CONCAT_WS(' ', NEW.firstName, NEW.midName, NEW.lastName, NEW.suffix);
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Name: ', person),
    CONCAT('Birthdate: ', NEW.birthdate),
    CONCAT('Ministry Type: ', getMinistryType(NEW.ministryType)),
    CONCAT('Status: ', getStatus(NEW.status)),
    CONCAT('License Number: ', NEW.licenseNumber));
    
    INSERT INTO auditlog(tableName, operation, newRecord) VALUES (tableName, operation, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Minister_AU AFTER UPDATE 
ON Minister FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    DECLARE oldRecord TEXT;
    DECLARE person TEXT;
    
    SET tableName = 'Minister';
    SET operation = 2;
    SET person = CONCAT_WS(' ', OLD.firstName, OLD.midName, OLD.lastName, OLD.suffix);
    
	SET oldRecord = CONCAT_WS('; ',
	CONCAT('Name: ', person),
    CONCAT('Birthdate: ', OLD.birthdate),
    CONCAT('Ministry Type: ', getMinistryType(OLD.ministryType)),
    CONCAT('Status: ', getStatus(OLD.status)),
    CONCAT('License Number: ', OLD.licenseNumber));
    
    SET person = CONCAT_WS(' ', NEW.firstName, NEW.midName, NEW.lastName, NEW.suffix);
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Name: ', person),
    CONCAT('Birthdate: ', NEW.birthdate),
    CONCAT('Ministry Type: ', getMinistryType(NEW.ministryType)),
    CONCAT('Status: ', getStatus(NEW.status)),
    CONCAT('License Number: ', NEW.licenseNumber));
    
    
    INSERT INTO auditlog(tableName, operation, oldRecord, newRecord) VALUES (tableName, operation, oldRecord, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Minister_AD AFTER DELETE 
ON Minister FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    DECLARE person TEXT;
    
    SET tableName = 'Minister';
    SET operation = 3;
    SET person = CONCAT_WS(' ', OLD.firstName, OLD.midName, OLD.lastName, OLD.suffix);
    
	SET oldRecord = CONCAT_WS('; ',
	CONCAT('Name: ', person),
    CONCAT('Birthdate: ', OLD.birthdate),
    CONCAT('Ministry Type: ', getMinistryType(OLD.ministryType)),
    CONCAT('Status: ', getStatus(OLD.status)),
    CONCAT('License Number: ', OLD.licenseNumber));
    
    
    INSERT INTO auditlog(tableName, operation, oldRecord) VALUES (tableName, operation, oldRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `ministerschedule`
--

DROP TABLE IF EXISTS `ministerschedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ministerschedule` (
  `ministerScheduleID` int(11) NOT NULL AUTO_INCREMENT,
  `ministerID` int(11) DEFAULT NULL,
  `title` text,
  `details` text,
  `startDateTime` datetime DEFAULT NULL,
  `endDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ministerScheduleID`),
  KEY `ministerschedule_minister_idx` (`ministerID`),
  CONSTRAINT `ministerschedule_minister` FOREIGN KEY (`ministerID`) REFERENCES `minister` (`ministerID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ministerschedule`
--

LOCK TABLES `ministerschedule` WRITE;
/*!40000 ALTER TABLE `ministerschedule` DISABLE KEYS */;
INSERT INTO `ministerschedule` VALUES (1,4,'SAD Meeting','Discuss about SAD.','2017-09-14 12:34:00','2017-09-14 13:34:00'),(2,5,'Defense Payments','Inquire and Seek advice','2017-09-15 12:50:00','2017-09-15 14:34:00');
/*!40000 ALTER TABLE `ministerschedule` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER MinisterSchedule_AI AFTER INSERT
ON MinisterSchedule FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    DECLARE minister TEXT;
    
    
    SET tableName = 'Appointment';
    SET operation = 1;
    
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Title: ', NEW.title),
    CONCAT('Details: ', NEW.details),
    CONCAT('Start Time: ', NEW.startDateTime),
    CONCAT('End Time: ', NEW.endDateTime),
    CONCAT('Minister: ', getMinister(NEW.ministerID)));
    
    INSERT INTO auditlog(tableName, operation, newRecord) VALUES (tableName, operation, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER MinisterSchedule_AU AFTER UPDATE
ON MinisterSchedule FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    DECLARE newRecord TEXT;
    DECLARE minister TEXT;
    
    
    SET tableName = 'Appointment';
    SET operation = 2;
    
    SET oldRecord = CONCAT_WS('; ',
	CONCAT('Title: ', OLD.title),
    CONCAT('Details: ', OLD.details),
    CONCAT('Start Time: ', OLD.startDateTime),
    CONCAT('End Time: ', OLD.endDateTime),
    CONCAT('Minister: ', getMinister(OLD.ministerID)));
    
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Title: ', NEW.title),
    CONCAT('Details: ', NEW.details),
    CONCAT('Start Time: ', NEW.startDateTime),
    CONCAT('End Time: ', NEW.endDateTime),
    CONCAT('Minister: ', getMinister(NEW.ministerID)));
    
    INSERT INTO auditlog(tableName, operation, oldRecord, newRecord) VALUES (tableName, operation, oldRecord, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER MinisterSchedule_AD AFTER DELETE
ON MinisterSchedule FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    DECLARE minister TEXT;
    
    
    SET tableName = 'Appointment';
    SET operation = 3;
    
    SET oldRecord = CONCAT_WS('; ',
	CONCAT('Title: ', OLD.title),
    CONCAT('Details: ', OLD.details),
    CONCAT('Start Time: ', OLD.startDateTime),
    CONCAT('End Time: ', OLD.endDateTime),
    CONCAT('Minister: ', getMinister(OLD.ministerID)));
    
    INSERT INTO auditlog(tableName, operation, oldRecord) VALUES (tableName, operation, oldRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parent`
--

LOCK TABLES `parent` WRITE;
/*!40000 ALTER TABLE `parent` DISABLE KEYS */;
INSERT INTO `parent` VALUES (3,8,'Jumallia','Q','Aine','',NULL,1,'Vladasia',NULL),(4,8,'Sherylle','E','Seder','',NULL,2,'Vladasia',NULL),(5,9,'Sandor','F','Bayron','',NULL,1,'Coldstone',NULL),(6,9,'Sherylle','E','Sedderin','',NULL,2,'Addasia',NULL),(8,13,'Sherylle','E','Sedderin','',NULL,2,'Nelliston',NULL),(9,13,'Sherylle','E','Seder','',NULL,1,'Carlstone',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (1,10,1,200.00),(5,12,4,120.00),(7,11,3,50.00);
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Payment_AI AFTER INSERT
ON Payment FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    DECLARE _ORnum INT;
    
    SELECT ORnum INTO _ORnum FROM primaryincome NATURAL JOIN payment WHERE paymentID = NEW.paymentID;
    
    SET tableName = 'Payment';
    SET operation = 1;
    SET newRecord = CONCAT_WS('; ',
	CONCAT('OR Number: ', _ORnum),
    CONCAT('Payment Amount: ', NEW.amount));
    
    INSERT INTO auditlog(tableName, operation, newRecord) VALUES (tableName, operation, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `primaryincome`
--

DROP TABLE IF EXISTS `primaryincome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `primaryincome` (
  `primaryIncomeID` int(11) NOT NULL AUTO_INCREMENT,
  `sourceName` text,
  `bookType` text NOT NULL,
  `ORnum` int(11) NOT NULL,
  `remarks` varchar(45) NOT NULL,
  `primaryIncomeDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`primaryIncomeID`),
  UNIQUE KEY `itemID_UNIQUE` (`primaryIncomeID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `primaryincome`
--

LOCK TABLES `primaryincome` WRITE;
/*!40000 ALTER TABLE `primaryincome` DISABLE KEYS */;
INSERT INTO `primaryincome` VALUES (1,NULL,'1',1,'',NULL),(3,'George','1',2,'Danielle\'s Baptism','2017-09-24 00:00:00'),(4,'Geralt','1',3,'Hard Liquor',NULL),(5,'Deralte','1',4,'Booze','2017-09-24 00:00:00');
/*!40000 ALTER TABLE `primaryincome` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER PrimaryIncome_BI BEFORE INSERT
ON PrimaryIncome FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    
    
    SET tableName = 'Primary Income';
    SET operation = 1;
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Source: ', NEW.sourceName),
    CONCAT('Book Type: ', getBookType(NEW.bookType)),
    CONCAT('OR Number: ', NEW.ORnum),
    CONCAT('Remarks: ', NEW.remarks),
    CONCAT('Income Time: ', NEW.primaryIncomeDateTime));
    
    INSERT INTO auditlog(tableName, operation, newRecord) VALUES (tableName, operation, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER PrimaryIncome_AU AFTER UPDATE
ON PrimaryIncome FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    DECLARE newRecord TEXT;
    
    
    SET tableName = 'Primary Income';
    SET operation = 2;
    SET oldRecord = CONCAT_WS('; ',
	CONCAT('Source: ', OLD.sourceName),
    CONCAT('Book Type: ', getBookType(OLD.bookType)),
    CONCAT('OR Number: ', OLD.ORnum),
    CONCAT('Remarks: ', OLD.remarks),
    CONCAT('Income Time: ', OLD.primaryIncomeDateTime));
    
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Source: ', NEW.sourceName),
    CONCAT('Book Type: ', getBookType(NEW.bookType)),
    CONCAT('OR Number: ', NEW.ORnum),
    CONCAT('Remarks: ', NEW.remarks),
    CONCAT('Income Time: ', NEW.primaryIncomeDateTime));
    
    INSERT INTO auditlog(tableName, operation, oldRecord, newRecord) VALUES (tableName, operation, oldRecord, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER PrimaryIncome_AD AFTER DELETE
ON PrimaryIncome FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    
    
    SET tableName = 'Primary Income';
    SET operation = 3;
    SET oldRecord = CONCAT_WS('; ',
	CONCAT('Source: ', OLD.sourceName),
    CONCAT('Book Type: ', getBookType(OLD.bookType)),
    CONCAT('OR Number: ', OLD.ORnum),
    CONCAT('Remarks: ', OLD.remarks),
    CONCAT('Income Time: ', OLD.primaryIncomeDateTime));
    
    INSERT INTO auditlog(tableName, operation, oldRecord) VALUES (tableName, operation, oldRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
  `remarks` text NOT NULL,
  PRIMARY KEY (`sacramentIncomeID`),
  KEY `sacramentIncome_application_idx` (`applicationID`),
  CONSTRAINT `sacramentIncome_application` FOREIGN KEY (`applicationID`) REFERENCES `application` (`applicationID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sacramentincome`
--

LOCK TABLES `sacramentincome` WRITE;
/*!40000 ALTER TABLE `sacramentincome` DISABLE KEYS */;
INSERT INTO `sacramentincome` VALUES (10,10,200,''),(11,11,200,''),(12,15,500,''),(13,13,2000,''),(14,14,500,'New Parish Member'),(15,22,100,''),(16,20,100,''),(17,21,100,'');
/*!40000 ALTER TABLE `sacramentincome` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule`
--

DROP TABLE IF EXISTS `schedule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `schedule` (
  `scheduleID` int(11) NOT NULL AUTO_INCREMENT,
  `title` text,
  `details` text,
  `startDateTime` datetime DEFAULT NULL,
  `endDateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`scheduleID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (1,'Random Event','','2017-09-12 06:59:00','2017-09-12 06:59:00'),(2,'Meeting','','2017-09-12 10:12:00','2017-09-12 11:12:00'),(3,'SAD 2 Defense','SoftEng Defense','2017-09-30 13:00:00','2017-09-30 14:30:00');
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Schedule_AI AFTER INSERT
ON Schedule FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE newRecord TEXT;
    
    SET tableName = 'Schedule';
    SET operation = 1;
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Title: ', NEW.title),
    CONCAT('Details: ', NEW.details),
    CONCAT('Start Time: ', NEW.startDateTime),
    CONCAT('End Time: ', NEW.endDateTime));
    
    INSERT INTO auditlog(tableName, operation, newRecord) VALUES (tableName, operation, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Schedule_AU AFTER UPDATE
ON Schedule FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    DECLARE newRecord TEXT;
    
    SET tableName = 'Schedule';
    SET operation = 2;
    SET oldRecord = CONCAT_WS('; ',
	CONCAT('Title: ', OLD.title),
    CONCAT('Details: ', OLD.details),
    CONCAT('Start Time: ', OLD.startDateTime),
    CONCAT('End Time: ', OLD.endDateTime));
    
    SET newRecord = CONCAT_WS('; ',
	CONCAT('Title: ', NEW.title),
    CONCAT('Details: ', NEW.details),
    CONCAT('Start Time: ', NEW.startDateTime),
    CONCAT('End Time: ', NEW.endDateTime));
    
    INSERT INTO auditlog(tableName, operation, oldRecord, newRecord) VALUES (tableName, operation, oldRecord, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER Schedule_AD AFTER DELETE
ON Schedule FOR EACH ROW
BEGIN
	DECLARE tableName TEXT;
    DECLARE operation INT;
    DECLARE oldRecord TEXT;
    
    SET tableName = 'Schedule';
    SET operation = 3;
    SET oldRecord = CONCAT_WS('; ',
	CONCAT('Title: ', OLD.title),
    CONCAT('Details: ', OLD.details),
    CONCAT('Start Time: ', OLD.startDateTime),
    CONCAT('End Time: ', OLD.endDateTime));
    
    INSERT INTO auditlog(tableName, operation, oldRecord) VALUES (tableName, operation, oldRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sponsor`
--

LOCK TABLES `sponsor` WRITE;
/*!40000 ALTER TABLE `sponsor` DISABLE KEYS */;
INSERT INTO `sponsor` VALUES (1,12,'Coretta','S','Sircy','',2,'Bathasia'),(2,12,'Augustus','E','Outman','Jr',1,'Quinnia'),(3,10,'Sergione','V','Negron','II',1,'Whittingham'),(4,10,'Sergione','V','Negron','II',1,'Whittingham'),(5,13,'Keith','C','Bambor','',1,'Northcoast'),(6,13,'Wen','A','Glasgow','',1,'Fallholt'),(7,20,'Clint','A','Reynolds','',1,'Old York'),(8,20,'Clint','A','Reynolds','',1,'Old York');
/*!40000 ALTER TABLE `sponsor` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Dewey','L','Sia','','dewey','KgjP1Cz3PfMbwaWu4W4Wmy51uvb2rbdh937d0D6m3ZaotEJF',1,-1,'-1'),(2,'Keating','A','John','','john','giclmh/nLTS6TsHaGQKLNI4wpyZBsvxzmnaCCgXWf1Eh3SgQ',1,-1,'4'),(3,'Doyle','B','McKenney','Jr','addu','deweyhaha',1,2,'4');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'sad2'
--

--
-- Dumping routines for database 'sad2'
--
/*!50003 DROP FUNCTION IF EXISTS `getApplicationPersons` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getApplicationPersons`(applicationID INT) RETURNS text CHARSET utf8
BEGIN
	DECLARE person TEXT;
    DECLARE numRow INT;
    
    DECLARE groom TEXT;
    DECLARE bride TEXT;
    
    SELECT COUNT(*) INTO numRow FROM Application NATURAL JOIN Applicant WHERE application.applicationID = applicationID; 
    
    IF numRow = 2 THEN 
        SELECT CONCAT_WS(' ', firstName, midName, lastName, suffix) INTO groom FROM GeneralProfile NATURAL JOIN Applicant NATURAL JOIN Application where application.applicationID = applicationID ORDER BY gender LIMIT 0,1;
        SELECT CONCAT_WS(' ', firstName, midName, lastName, suffix) INTO bride FROM GeneralProfile NATURAL JOIN Applicant NATURAL JOIN Application where application.applicationID = applicationID ORDER BY gender LIMIT 1,1;
		
        SET person = CONCAT_WS(' & ', groom, bride);
    ELSE
		SELECT CONCAT_WS(' ', firstName, midName, lastName, suffix) INTO person FROM GeneralProfile NATURAL JOIN Applicant NATURAL JOIN Application where application.applicationID = applicationID LIMIT 0,1;
    END IF;
    
    RETURN person;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `getApplicationStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getApplicationStatus`(applicationStatus INT) RETURNS text CHARSET utf8
BEGIN
	DECLARE applicationStat TEXT;
    
    SET applicationStat =
    CASE 
		WHEN applicationStatus = 1 THEN 'Pending'
		WHEN applicationStatus = 2 THEN 'Approved'
		WHEN applicationStatus = 3 THEN 'Final'
		WHEN applicationStatus = 4 THEN 'Revoked'
		ELSE 'Case not found'
    END;
    
    RETURN applicationStat;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `getBookType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getBookType`(bookType INT) RETURNS text CHARSET utf8
BEGIN
	DECLARE book TEXT;
    
    SET book =
    CASE 
		WHEN bookType = 1 THEN 'Parish'
		WHEN bookType = 2 THEN 'Community'
		WHEN bookType = 3 THEN 'Postulancy'
		ELSE 'Case not found'
    END;
    
    RETURN book;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `getMinister` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getMinister`(ministerID INT) RETURNS text CHARSET utf8
BEGIN
	DECLARE name TEXT;
    SELECT CONCAT_WS(' ', firstName, midName, lastName, suffix) INTO name FROM Minister WHERE Minister.ministerID = ministerID;
    
    RETURN name;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `getMinistryType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getMinistryType`(ministryType INT) RETURNS text CHARSET utf8
BEGIN
	DECLARE ministry TEXT;
    
    SET ministry =
    CASE 
		WHEN ministryType = 1 THEN 'Priest'
		WHEN ministryType = 2 THEN 'Monsignor'
		WHEN ministryType = 3 THEN 'Archbishop'
		ELSE 'Case not found'
    END;
    
    RETURN ministry;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `getSacrament` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getSacrament`(sacramentType INT) RETURNS text CHARSET utf8
BEGIN
	DECLARE sacrament TEXT;
    
    SET sacrament = 
	CASE 
		WHEN sacramentType = 1 THEN 'Baptism'
		WHEN sacramentType = 2 THEN 'Confirmation'
		WHEN sacramentType = 3 THEN 'Marriage'
		ELSE 'Case not found'
	END;
    
    RETURN sacrament;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `getStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getStatus`(status INT) RETURNS text CHARSET utf8
BEGIN
	DECLARE stat TEXT;
    
    SET stat =
    CASE 
		WHEN status = 1 THEN 'Active'
		WHEN status = 2 THEN 'Inactive'
		ELSE 'Case not found'
    END;
    
    RETURN stat;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP FUNCTION IF EXISTS `getTransactionType` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getTransactionType`(transactionType INT) RETURNS text CHARSET utf8
BEGIN
	DECLARE transaction TEXT;
    
    SET transaction =
    CASE 
		WHEN transactionType = 1 THEN 'Cash Receipt'
		WHEN transactionType = 2 THEN 'Cash Disbursement'
		ELSE 'Case not found'
    END;
    
    RETURN transaction;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-09-24 15:30:38
