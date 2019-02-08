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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (2,'Meeting','','2017-09-12 10:12:00','2017-09-12 11:12:00'),(3,'SAD 2 Defense','SoftEng Defense','2017-09-30 13:30:00','2017-09-30 15:00:00'),(4,'Coding Session','Code for SAD 2. Defense approaching.','2017-09-26 09:00:00','2017-09-26 12:00:00'),(5,'RNR','CSSEC RNR','2017-10-14 07:00:00','2017-10-16 17:00:00'),(6,'Meeting with sir Justin','','2019-02-01 14:56:00','2019-02-01 15:56:00');
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

-- Dump completed on 2019-02-08 21:03:00
