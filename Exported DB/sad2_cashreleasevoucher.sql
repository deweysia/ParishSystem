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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cashreleasevoucher`
--

LOCK TABLES `cashreleasevoucher` WRITE;
/*!40000 ALTER TABLE `cashreleasevoucher` DISABLE KEYS */;
INSERT INTO `cashreleasevoucher` VALUES (1,'2017-09-26 00:00:00','Nothing much',1001,101,1,'Cake'),(2,'2017-09-30 10:18:07','',1002,102,1,''),(3,'2017-09-30 10:23:51','',1003,103,1,''),(4,'2017-09-30 11:10:59','',1004,104,1,''),(5,'2019-01-26 11:53:41','',1005,105,1,'Steven Stapler'),(6,'2019-02-01 14:53:33','',1006,106,1,'');
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
    
    INSERT INTO auditlog(tableName, operation, newRecord, userID) VALUES (tableName, operation, newRecord, @userID);
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

-- Dump completed on 2019-02-08 21:02:58
