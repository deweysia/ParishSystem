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
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `primaryincome`
--

LOCK TABLES `primaryincome` WRITE;
/*!40000 ALTER TABLE `primaryincome` DISABLE KEYS */;
INSERT INTO `primaryincome` VALUES (1,NULL,'1',1,'',NULL),(3,'George','1',2,'Danielle\'s Baptism','2017-09-24 00:00:00'),(4,'Geralt','1',3,'Hard Liquor',NULL),(5,'Deralte','1',4,'Booze','2017-09-24 00:00:00'),(6,NULL,'1',5,'',NULL),(7,NULL,'1',6,'',NULL),(8,NULL,'1',7,'',NULL),(9,NULL,'1',8,'',NULL),(10,NULL,'1',9,'',NULL),(11,NULL,'1',10,'',NULL),(12,NULL,'1',11,'awaiting requirements',NULL),(13,'Vicky Palmer','2',1,'','2017-09-29 10:10:20'),(14,'Doris Askew','1',12,'','2017-09-29 10:17:42'),(15,'','1',13,'','2017-09-29 10:18:43'),(16,'','1',14,'','2017-09-30 09:32:46'),(17,'','1',15,'','2017-09-30 09:40:06'),(18,'','1',16,'','2017-09-30 09:41:06'),(19,'','1',17,'','2017-09-30 09:41:44'),(20,'','1',18,'','2017-09-30 09:47:02'),(21,'','1',19,'','2017-09-30 09:52:00'),(22,'','1',20,'','2017-09-30 09:53:48'),(23,'','1',21,'','2017-09-30 09:55:09'),(24,'','1',22,'','2017-09-30 09:56:09'),(25,'','1',23,'','2017-09-30 09:56:18'),(26,'','1',24,'','2017-09-30 10:00:28'),(27,'Ricky','1',25,'Feeding program','2017-09-30 10:01:25'),(28,'','2',2,'','2017-09-30 10:17:41'),(29,NULL,'1',26,'Paid half',NULL),(30,NULL,'1',27,'',NULL),(31,NULL,'1',28,'',NULL),(32,NULL,'1',29,'',NULL),(33,'Dewey','1',30,'','2019-01-26 11:48:28'),(34,'','1',31,'','2019-02-01 02:51:36'),(35,'','1',32,'','2019-02-01 02:52:34');
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
