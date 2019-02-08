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
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `application`
--

LOCK TABLES `application` WRITE;
/*!40000 ALTER TABLE `application` DISABLE KEYS */;
INSERT INTO `application` VALUES (10,1,2,'111'),(11,1,1,'111'),(12,2,1,'000'),(13,3,3,'000111'),(14,1,1,'000'),(15,2,1,'000'),(16,2,1,'000'),(17,2,1,'000'),(18,2,1,'000'),(19,2,1,'000'),(20,2,2,'000'),(21,1,1,'000'),(22,2,1,'111'),(23,1,1,'000'),(24,1,1,'000'),(25,1,1,'000'),(26,1,1,'000'),(27,2,1,'000'),(28,2,1,'000'),(29,2,1,'111'),(30,2,1,'000'),(31,1,2,'111'),(32,2,1,'000'),(33,3,1,'111111'),(34,3,2,'111111'),(35,1,2,'111'),(36,2,2,'111'),(37,1,2,'111'),(38,1,2,'111'),(39,2,2,'111'),(40,2,2,'111'),(41,2,1,'100'),(42,2,1,'011'),(43,2,1,'000'),(44,1,1,'111'),(45,1,3,'111'),(46,2,1,'111'),(47,1,1,'000');
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-08 21:03:00
