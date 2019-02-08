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
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `generalprofile`
--

LOCK TABLES `generalprofile` WRITE;
/*!40000 ALTER TABLE `generalprofile` DISABLE KEYS */;
INSERT INTO `generalprofile` VALUES (7,'Dewey','L','Sia','','1998-09-26',1,'Miami','Crown Point'),(8,'Jim','C','Tang','Jr','2017-09-10',1,'Postonia','Bridgehaven'),(9,'Niña','A','Fitzgerald','','2017-09-10',2,'Poston','Bridgehaven'),(11,'Andreia','Q','Gaultz','','2017-09-10',2,'Garden City','Missoula'),(12,'Andre','C','Gaultz','','2017-09-10',2,'Concord','Seattle'),(13,'Francis','A','Robins','','2017-09-16',1,'Postone','Bridgehaven'),(14,'Rachelle','D','Shwartz','','2017-02-01',2,'Davao','Davao'),(15,'France','A','Saggat',NULL,'1997-08-21',1,'Bulmary','Woodsford'),(19,'Beatrice','A','Solberg','','2017-09-26',2,'Bridgeport','Jackson'),(20,'Malcolm','A','Peterson','','2017-09-11',1,'Ashton','Mount Pleasant'),(21,'Emmett','B','Mason','','2017-09-28',2,'Odessa','Boston'),(22,'Guy','J','Ingram','','2017-09-28',1,'Gensan','Davao'),(23,'Jun','B','Seba','','1974-02-07',1,'Manila','Cebu'),(24,'Jon','A','Marshall','','1975-09-06',2,NULL,NULL),(25,'Yuki','A','Kajiura','','1965-08-06',1,NULL,NULL),(26,'Christopher','C','Green','','1970-08-15',1,'Wildstone','Rockford'),(27,'Tina','M','Turner','','1969-08-04',2,'Merribourne','Southedge'),(28,'Sally','K','Jackson','','2017-09-01',1,NULL,NULL),(29,'Scott','V','Lerner','','2000-06-29',1,NULL,NULL),(30,'Patricia','F','Ford','','2010-12-15',2,NULL,NULL),(31,'Frank','J','Perry','','2017-09-06',1,NULL,NULL),(32,'Giuseppe','J','House','','2017-09-07',1,NULL,NULL),(33,'Tanya','C','Hernandez','','2014-06-19',1,NULL,NULL),(34,'Loren','C','Peebles','','1994-06-30',2,NULL,NULL),(35,'Sherry','I','Hunter','','2003-11-27',1,NULL,NULL),(36,'Sandra','E','Fairbanks','','2010-06-07',1,NULL,NULL),(37,'Leryc','V','Ibalio','','1998-06-17',1,NULL,NULL),(38,'Raul','W','Lumapase','','1989-02-08',1,'Davao',NULL),(39,'Bob','Builder','T','','1990-03-08',1,NULL,NULL),(40,'John','B','Smith','II','1990-06-07',1,NULL,NULL);
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
    CONCAT('Gender: ', getGender(NEW.gender)),
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
    CONCAT('Gender: ', getGender(NEW.gender)),
    CONCAT('Birthdate: ', NEW.birthDate),
    CONCAT('Residence: ', NEW.residence),
    CONCAT('Birth Place: ', NEW.birthplace));
    
    SET oldRecord = 
    CONCAT_WS('; ', 
    CONCAT('First Name: ', OLD.firstName), 
    CONCAT('M.I.: ', OLD.midName), 
    CONCAT('Last Name: ', OLD.lastName), 
    CONCAT('Suffix: ', OLD.suffix), 
    CONCAT('Gender: ', getGender(OLD.gender)),
    CONCAT('Birthdate: ', OLD.birthDate),
    CONCAT('Residence: ', OLD.residence),
    CONCAT('Birth Place: ', OLD.birthplace));
    
    INSERT INTO auditlog(tableName, operation, newRecord, oldRecord, userID) VALUES (tableName, operation, newRecord, oldRecord, @userID);
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
    CONCAT('Gender: ', getGender(OLD.gender)),
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-08 21:02:57
