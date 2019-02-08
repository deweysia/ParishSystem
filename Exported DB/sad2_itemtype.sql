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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemtype`
--

LOCK TABLES `itemtype` WRITE;
/*!40000 ALTER TABLE `itemtype` DISABLE KEYS */;
INSERT INTO `itemtype` VALUES (1,'Baptism',1,200.00,1,NULL,1),(2,'Confirmation',1,500.00,1,NULL,1),(3,'Marriage',1,2000.00,1,NULL,1),(4,'Donation',1,0.00,1,'',1),(5,'Parish Card',2,50.00,1,NULL,1),(6,'Certificates',1,100.00,1,'',1),(7,'Food',2,500.00,1,'',1),(8,'Office Supplies',1,0.00,1,'',2),(9,'Electricity ',1,0.00,1,'',2),(10,'Water',1,0.00,1,'',2),(11,'Food',1,0.00,1,'',2),(12,'GKK',1,0.00,1,'',2),(13,'Gasoline',1,100.00,1,'',2);
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-08 21:02:59
