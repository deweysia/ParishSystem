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
INSERT INTO `minister` VALUES (3,'Boyle','A','Royce','II','1960-01-02',2,1,NULL,NULL),(4,'Joshua','F','Lintag','','2017-09-12',1,1,NULL,NULL),(5,'Joseph','A','Numirez','','1970-10-22',3,1,NULL,NULL),(6,'Bernardo','B','Spencer','','2017-09-29',1,1,NULL,NULL);
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
    
    
    INSERT INTO auditlog(tableName, operation, oldRecord, newRecord, userID) VALUES (tableName, operation, oldRecord, newRecord, @userID);
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
    
    
    INSERT INTO auditlog(tableName, operation, oldRecord, userID) VALUES (tableName, operation, oldRecord, @userID);
END */;;
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

-- Dump completed on 2019-02-08 21:03:01
