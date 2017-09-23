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
-- Dumping data for table `auditlog`
--

LOCK TABLES `auditlog` WRITE;
/*!40000 ALTER TABLE `auditlog` DISABLE KEYS */;
INSERT INTO `auditlog` VALUES (1,'generalProfile',1,'Yoo','YaaA','2017-09-16 10:53:39',NULL,NULL),(2,'Profile',1,NULL,'First Name = Justin Henry; M.I. = C; Last Name = Lo; Birthdate = 1998-12-16; Residence = Damosa; Birth Place = Davao','2017-09-16 11:17:50',NULL,NULL),(3,'Profile',2,'First Name: Justin Henry; M.I.: C; Last Name: Lo; Birthdate: 1998-12-16; Residence: Damosa; Birth Place: Davao','First Name: Justin Henry; M.I.: C; Last Name: Lu; Birthdate: 1998-12-16; Residence: Damosa; Birth Place: Davao','2017-09-16 11:55:13',NULL,NULL),(4,'Profile',3,'First Name: Justin Henry; M.I.: C; Last Name: Lu; Birthdate: 1998-12-16; Residence: Damosa; Birth Place: Davao',NULL,'2017-09-16 11:55:39',NULL,NULL),(5,'Profile',1,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16','2017-09-17 05:29:22',NULL,NULL),(6,'Profile',1,NULL,'First Name: Rachel; M.I.: D; Last Name: Shwartz; Suffix: ; Birthdate: 2017-02-01','2017-09-17 06:12:50',NULL,NULL),(7,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 15:17:26',NULL,NULL),(8,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultze; Suffix: ; Birthdate: 2017-09-10','2017-09-19 15:21:02',NULL,NULL),(9,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 15:21:41',NULL,'2'),(10,'Profile',2,NULL,'First Name: Andreia; M.I.: Q; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:28:02',NULL,NULL),(11,'Profile',2,NULL,'First Name: Rachel; M.I.: D; Last Name: Shwart; Suffix: ; Birthdate: 2017-02-01','2017-09-19 17:37:33',NULL,'2'),(12,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 17:52:57',NULL,'2'),(13,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 17:53:10',NULL,'2'),(14,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:53:21',NULL,'2'),(15,'Profile',2,NULL,'First Name: Andreia; M.I.: Q; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:56:15',NULL,'2'),(16,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:58:23',NULL,'2'),(17,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 17:59:04',NULL,'2'),(18,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 18:10:00',NULL,'1'),(19,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 22:51:10',NULL,'2'),(20,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 22:51:35',NULL,'2'),(21,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-19 22:52:01',NULL,'2'),(22,'Profile',2,NULL,'First Name: Andreia; M.I.: Q; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 22:52:17',NULL,'2'),(23,'Profile',2,NULL,'First Name: Andrea; M.I.: C; Last Name: Gaultz; Suffix: ; Birthdate: 2017-09-10','2017-09-19 23:58:11',NULL,'1'),(24,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Greyrock','2017-09-20 09:24:05',NULL,'2'),(25,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:24:05',NULL,'2'),(26,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:40:16',NULL,'2'),(27,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:40:17',NULL,'2'),(28,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:42:03',NULL,'2'),(29,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:42:03',NULL,'2'),(30,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:43:08',NULL,'2'),(31,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 09:43:08',NULL,'2'),(32,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:33:39',NULL,'2'),(33,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:33:39',NULL,'2'),(34,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:35:52',NULL,'2'),(35,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:35:52',NULL,'2'),(36,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:38:25',NULL,'2'),(37,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:38:25',NULL,'2'),(38,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:41:25',NULL,'2'),(39,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:41:25',NULL,'2'),(40,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Postone','2017-09-20 11:42:47',NULL,'2'),(41,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 11:42:47',NULL,'2'),(42,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Postone','2017-09-20 13:50:05',NULL,'2'),(43,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 13:50:05',NULL,'2'),(44,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Postone','2017-09-20 13:53:18',NULL,'2'),(45,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 13:53:29',NULL,'2'),(46,'Profile',2,NULL,'First Name: Francis; M.I.: A; Last Name: Robins; Suffix: ; Birthdate: 2017-09-16; Residence: Bridgehaven; Birth Place: Postone','2017-09-20 13:56:35',NULL,'2'),(47,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 13:56:42',NULL,'2'),(48,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-20 14:02:19',NULL,'2'),(49,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 14:02:22',NULL,'2'),(50,'Profile',2,NULL,'First Name: Dina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 14:28:24',NULL,'2'),(51,'Profile',2,NULL,'First Name: Dinaa; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 14:36:55',NULL,'2'),(52,'Profile',2,NULL,'First Name: Dina; M.I.: Fitzgerald; Last Name: A; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:41:47',NULL,'2'),(53,'Profile',2,NULL,'First Name: Dina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:41:55',NULL,'2'),(54,'Profile',2,NULL,'First Name: Dinna; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:44:45',NULL,'2'),(55,'Profile',2,NULL,'First Name: Dina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:44:56',NULL,'2'),(56,'Profile',2,NULL,'First Name: Dinaq; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:52:49',NULL,'2'),(57,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-20 22:53:12',NULL,'2'),(58,'Application',2,'Name: Jim C Tang Jr; Sacrament TypeCase not found; Status: Approved','Name: Jim C Tang Jr; Sacrament TypeCase not found; Status: Pending','2017-09-21 06:16:49','',NULL),(59,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','2017-09-21 06:18:40','',NULL),(60,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','2017-09-21 06:22:28','',NULL),(61,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','2017-09-21 06:22:45','',NULL),(62,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','2017-09-21 06:23:43','',NULL),(63,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: 1; Status: Pending','Name: Jim C Tang Jr; Sacrament Type: 1; Status: Approved','2017-09-21 06:24:47','',NULL),(64,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Baptism; Status: Approved','Name: Jim C Tang Jr; Sacrament Type: Baptism; Status: Pending','2017-09-21 06:26:03','',NULL),(65,'Application',2,'Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Pending','Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Approved','2017-09-21 06:26:03','',NULL),(66,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Baptism; Status: Pending','Name: Jim C Tang Jr; Sacrament Type: Baptism; Status: Approved','2017-09-21 06:31:04','',NULL),(67,'Application',2,'Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Approved','Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Pending','2017-09-21 06:32:30','',NULL),(68,'Application',2,'Sacrament Type: Case not found; Status: Approved','Sacrament Type: Case not found; Status: Pending','2017-09-21 06:32:40',NULL,NULL),(69,'Application',2,'Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr; Sacrament Type: Case not found; Status: Pending','2017-09-21 08:19:14','Updated Requirements',NULL),(70,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Pending','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Pending','2017-09-21 08:22:14','Updated Requirements',NULL),(71,'Application',2,'Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Pending','Name: Nina A Fitzgerald ; Sacrament Type: Baptism; Status: Pending','2017-09-21 08:22:46','Updated Requirements',NULL),(72,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Pending','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:36:44','',NULL),(73,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:39:33','',NULL),(74,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:41:00','Updated Requirements',NULL),(75,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: 3; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: 3; Status: Approved','2017-09-21 08:42:17','Updated Requirements',NULL),(76,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:54:07','Updated Requirements',NULL),(77,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found; Status: Approved','2017-09-21 08:57:09','Updated Requirements',NULL),(78,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found 3; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Case not found 3; Status: Approved','2017-09-21 08:58:45','Updated Requirements',NULL),(79,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Pending','2017-09-21 09:02:01','',NULL),(80,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:23:19',NULL,'2'),(81,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:23:22',NULL,'2'),(82,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Pending','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:23:27','','2'),(83,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:23:29','','2'),(84,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:25:51',NULL,'2'),(85,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:26:01',NULL,'2'),(86,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:26:50','','2'),(87,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:26:51','','2'),(88,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:27:40',NULL,'2'),(89,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:27:56',NULL,'2'),(90,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:29:00','','2'),(91,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:29:01','','2'),(92,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:33:07',NULL,'2'),(93,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:34:06',NULL,'2'),(94,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:34:30',NULL,'2'),(95,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:37:53',NULL,'2'),(96,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:38:06',NULL,'2'),(97,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:40:46','','2'),(98,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 07:40:47','','2'),(99,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 07:41:58',NULL,'2'),(100,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 07:42:07',NULL,'2'),(101,'Profile',2,NULL,'First Name: Jim; M.I.: C; Last Name: Tang; Suffix: Jr; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Postonia','2017-09-22 08:07:11',NULL,'2'),(102,'Profile',2,NULL,'First Name: Nina; M.I.: A; Last Name: Fitzgerald; Suffix: ; Birthdate: 2017-09-10; Residence: Bridgehaven; Birth Place: Poston','2017-09-22 08:07:12',NULL,'2'),(103,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 08:07:33','','2'),(104,'Application',2,'Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','Name: Jim C Tang Jr & Nina A Fitzgerald ; Sacrament Type: Marriage; Status: Approved','2017-09-22 08:07:34','','2'),(105,'Profile',2,NULL,'First Name: Rachel; M.I.: D; Last Name: Shwartz; Suffix: ; Birthdate: 2017-02-01','2017-09-22 08:46:07',NULL,'2'),(106,'Application',2,'Name: Rachel D Shwartz ; Sacrament Type: Baptism; Status: Pending','Name: Rachel D Shwartz ; Sacrament Type: Baptism; Status: Pending','2017-09-22 08:46:07','','2'),(107,'Profile',2,NULL,'First Name: Andre; M.I.: Gaultz; Last Name: C; Suffix: ; Birthdate: 2017-09-10','2017-09-22 08:46:17',NULL,'2'),(108,'Application',2,'Name: Andre Gaultz C ; Sacrament Type: Confirmation; Status: Pending','Name: Andre Gaultz C ; Sacrament Type: Confirmation; Status: Pending','2017-09-22 08:46:17','','2'),(109,'Minister',1,NULL,'Name: Joseph A Numire; Birthdate: 1970-10-22; Ministry Type: Archbishop; Status: Active','2017-09-22 09:51:02',NULL,NULL),(110,'Minister',2,NULL,'Name: Joseph A Numirez; Birthdate: 1970-10-22; Ministry Type: Archbishop; Status: Active','2017-09-23 08:48:38',NULL,NULL),(111,'Minister',2,'Name: Joseph A Numirez; Birthdate: 1970-10-22; Ministry Type: Archbishop; Status: Active','Name: Joseph A Numire; Birthdate: 1970-10-22; Ministry Type: Archbishop; Status: Active','2017-09-23 08:49:53',NULL,NULL),(112,'Minister',1,NULL,'Name: Jonathan A Jostar Jr; Birthdate: 1880-11-14; Ministry Type: Priest; Status: Active','2017-09-23 08:52:02',NULL,NULL),(113,'Minister',3,'Name: Jonathan A Jostar Jr; Birthdate: 1880-11-14; Ministry Type: Priest; Status: Active',NULL,'2017-09-23 08:52:28',NULL,NULL);
/*!40000 ALTER TABLE `auditlog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `baptism`
--

LOCK TABLES `baptism` WRITE;
/*!40000 ALTER TABLE `baptism` DISABLE KEYS */;
INSERT INTO `baptism` VALUES (2,10,3,'110','55','336','2017-09-21','',2);
/*!40000 ALTER TABLE `baptism` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `bloodclaimant`
--

LOCK TABLES `bloodclaimant` WRITE;
/*!40000 ALTER TABLE `bloodclaimant` DISABLE KEYS */;
/*!40000 ALTER TABLE `bloodclaimant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `blooddonation`
--

LOCK TABLES `blooddonation` WRITE;
/*!40000 ALTER TABLE `blooddonation` DISABLE KEYS */;
/*!40000 ALTER TABLE `blooddonation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `blooddonationevent`
--

LOCK TABLES `blooddonationevent` WRITE;
/*!40000 ALTER TABLE `blooddonationevent` DISABLE KEYS */;
/*!40000 ALTER TABLE `blooddonationevent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `blooddonor`
--

LOCK TABLES `blooddonor` WRITE;
/*!40000 ALTER TABLE `blooddonor` DISABLE KEYS */;
/*!40000 ALTER TABLE `blooddonor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cashreleaseitem`
--

LOCK TABLES `cashreleaseitem` WRITE;
/*!40000 ALTER TABLE `cashreleaseitem` DISABLE KEYS */;
/*!40000 ALTER TABLE `cashreleaseitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `cashreleasevoucher`
--

LOCK TABLES `cashreleasevoucher` WRITE;
/*!40000 ALTER TABLE `cashreleasevoucher` DISABLE KEYS */;
/*!40000 ALTER TABLE `cashreleasevoucher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `confirmation`
--

LOCK TABLES `confirmation` WRITE;
/*!40000 ALTER TABLE `confirmation` DISABLE KEYS */;
INSERT INTO `confirmation` VALUES (1,12,3,NULL,NULL,NULL,'2017-09-09',''),(2,20,3,NULL,NULL,NULL,'2017-09-20','');
/*!40000 ALTER TABLE `confirmation` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

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
    CONCAT('Status: ', getStatus(NEW.status),
	CONCAT('Details: ', NEW.details)));
    
    INSERT INTO auditlog(tableName, operation, newRecord) VALUES (tableName, operation, newRecord);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Dumping data for table `marriage`
--

LOCK TABLES `marriage` WRITE;
/*!40000 ALTER TABLE `marriage` DISABLE KEYS */;
INSERT INTO `marriage` VALUES (1,13,4,NULL,NULL,NULL,'2017-09-09','2017-09-09',NULL,'',1,1);
/*!40000 ALTER TABLE `marriage` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `ministerschedule`
--

LOCK TABLES `ministerschedule` WRITE;
/*!40000 ALTER TABLE `ministerschedule` DISABLE KEYS */;
INSERT INTO `ministerschedule` VALUES (1,3,'SAD Consultation','Discuss about SAD.','2017-09-14 12:34:00','2017-09-14 13:34:00');
/*!40000 ALTER TABLE `ministerschedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `parent`
--

LOCK TABLES `parent` WRITE;
/*!40000 ALTER TABLE `parent` DISABLE KEYS */;
INSERT INTO `parent` VALUES (3,8,'Jumallia','Q','Aine','',NULL,1,'Vladasia',NULL),(4,8,'Sherylle','E','Seder','',NULL,2,'Vladasia',NULL),(5,9,'Sandor','F','Bayron','',NULL,1,'Coldstone',NULL),(6,9,'Sherylle','E','Sedderin','',NULL,2,'Addasia',NULL),(8,13,'Sherylle','E','Sedderin','',NULL,2,'Nelliston',NULL),(9,13,'Sherylle','E','Seder','',NULL,1,'Carlstone',NULL);
/*!40000 ALTER TABLE `parent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (1,10,1,200.00);
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `primaryincome`
--

LOCK TABLES `primaryincome` WRITE;
/*!40000 ALTER TABLE `primaryincome` DISABLE KEYS */;
INSERT INTO `primaryincome` VALUES (1,NULL,'1',1,'',NULL);
/*!40000 ALTER TABLE `primaryincome` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `sacramentincome`
--

LOCK TABLES `sacramentincome` WRITE;
/*!40000 ALTER TABLE `sacramentincome` DISABLE KEYS */;
INSERT INTO `sacramentincome` VALUES (10,10,200,''),(11,11,200,''),(12,15,500,''),(13,13,2000,''),(14,14,500,'New Parish Member'),(15,22,100,''),(16,20,100,''),(17,21,100,'');
/*!40000 ALTER TABLE `sacramentincome` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `schedule`
--

LOCK TABLES `schedule` WRITE;
/*!40000 ALTER TABLE `schedule` DISABLE KEYS */;
INSERT INTO `schedule` VALUES (1,'Random Event','','2017-09-12 06:59:00','2017-09-12 06:59:00'),(2,'Meeting','','2017-09-12 10:12:00','2017-09-12 11:12:00'),(3,'SAD Defense','SAD 2 Defense','2017-09-30 13:00:00','2017-09-30 14:30:00');
/*!40000 ALTER TABLE `schedule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `sponsor`
--

LOCK TABLES `sponsor` WRITE;
/*!40000 ALTER TABLE `sponsor` DISABLE KEYS */;
INSERT INTO `sponsor` VALUES (1,12,'Coretta','S','Sircy','',2,'Bathasia'),(2,12,'Augustus','E','Outman','Jr',1,'Quinnia'),(3,10,'Sergione','V','Negron','II',1,'Whittingham'),(4,10,'Sergione','V','Negron','II',1,'Whittingham'),(5,13,'Keith','C','Bambor','',1,'Northcoast'),(6,13,'Wen','A','Glasgow','',1,'Fallholt'),(7,20,'Clint','A','Reynolds','',1,'Old York'),(8,20,'Clint','A','Reynolds','',1,'Old York');
/*!40000 ALTER TABLE `sponsor` ENABLE KEYS */;
UNLOCK TABLES;

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
		WHEN status = 1 THEN 'Parish'
		WHEN status = 2 THEN 'Community'
		WHEN status = 3 THEN 'Postulancy'
		ELSE 'Case not found'
    END;
    
    RETURN book;

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

-- Dump completed on 2017-09-23 17:37:41
