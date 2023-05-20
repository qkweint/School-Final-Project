-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: custom_db
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `customerID` int NOT NULL AUTO_INCREMENT,
  `customerName` varchar(45) DEFAULT NULL,
  `customerPassword` varchar(45) NOT NULL,
  PRIMARY KEY (`customerID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'Joedf',''),(2,'yoni',''),(3,'poob',''),(4,'ali','hello'),(5,'maximizi',''),(7,'Cranjis mcBasketball','dfasdf'),(8,'admin','admin');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gems`
--

DROP TABLE IF EXISTS `gems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gems` (
  `gemID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `weight` varchar(45) DEFAULT NULL,
  `price` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`gemID`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=104 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gems`
--

LOCK TABLES `gems` WRITE;
/*!40000 ALTER TABLE `gems` DISABLE KEYS */;
INSERT INTO `gems` VALUES (1,'ruby','2.5','400'),(2,'diamond','1.2','600'),(3,'emerald','3.4','500'),(4,'opal','1.3','700'),(5,'booby','0.2','100'),(6,'sapphire','1.5','200'),(7,'amethyst','0.7','50'),(8,'topaz','0.8','75'),(9,'aquamarine','1.0','125'),(10,'peridot','0.5','40'),(11,'apatite','1.2','60'),(12,'hemimorphite','2.8','300'),(13,'iolite','3.1','250'),(14,'kyanite','2.4','200'),(15,'maw-sit-sit','2.9','350'),(65,'garnet','0.8','95'),(66,'citrine','0.95','120'),(67,'spinel','1.1','195'),(68,'tanzanite','1.05','240'),(69,'tourmaline','0.85','160'),(70,'zircon','0.97','130'),(71,'moonstone','0.58','70'),(72,'morganite','0.95','220'),(73,'turquoise','0.88','120'),(74,'sodalite','1.25','140'),(75,'hematite','1.15','75'),(76,'azurite','0.68','100'),(77,'malachite','0.83','80'),(78,'obsidian','1.35','90'),(79,'pyrite','1.05','65'),(80,'jasper','0.95','55'),(81,'amber','0.87','210'),(82,'carnelian','0.72','95'),(83,'labradorite','0.8','135'),(84,'kunzite','1.15','250'),(85,'sunstone','1.05','170'),(86,'fluorite','0.98','120'),(87,'chrysocolla','0.85','90'),(88,'amazonite','0.92','85'),(89,'chalcedony','1.2','110'),(90,'serpentine','1.1','75'),(91,'rhodonite','0.75','80'),(92,'prehnite','0.68','100'),(93,'howlite','0.58','50'),(94,'lapis lazuli','0.88','130'),(95,'agate','0.95','70'),(96,'turritella agate','1.35','95'),(97,'dendritic agate','0.83','80'),(98,'charoite','1.05','220'),(99,'lepidolite','0.95','75'),(100,'kambaba jasper','1.2','95'),(101,'chrysoprase','0.72','110'),(102,'red jasper','1.15','80'),(103,'green aventurine','1.05','55');
/*!40000 ALTER TABLE `gems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `orderID` int NOT NULL AUTO_INCREMENT,
  `customerID` int DEFAULT NULL,
  `ringID` int DEFAULT NULL,
  PRIMARY KEY (`orderID`),
  KEY `cus_ord_idx` (`customerID`),
  KEY `rin_ord_idx` (`ringID`),
  CONSTRAINT `cus_ord` FOREIGN KEY (`customerID`) REFERENCES `customers` (`customerID`),
  CONSTRAINT `rin_ord` FOREIGN KEY (`ringID`) REFERENCES `rings` (`ringID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,1),(2,2,2),(3,3,3),(4,4,4),(5,5,5);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rings`
--

DROP TABLE IF EXISTS `rings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rings` (
  `ringID` int NOT NULL AUTO_INCREMENT,
  `metal` varchar(45) DEFAULT NULL,
  `gemID` int DEFAULT NULL,
  PRIMARY KEY (`ringID`),
  KEY `gem_rin_idx` (`gemID`),
  CONSTRAINT `gem_rin` FOREIGN KEY (`gemID`) REFERENCES `gems` (`gemID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rings`
--

LOCK TABLES `rings` WRITE;
/*!40000 ALTER TABLE `rings` DISABLE KEYS */;
INSERT INTO `rings` VALUES (1,'gold',1),(2,'silver',2),(3,'copper',2),(4,'silver',4),(5,'bronze',3),(6,'shwoop',5),(7,'bronze',4),(8,'unobtainium',103),(9,'bronze',8),(10,'brass',6),(11,'brass',6),(12,'gold',9),(13,'gold',9),(14,'gold',9),(15,'gold',8),(16,'cadmium',6),(17,'bronze',5),(18,'bronze',4);
/*!40000 ALTER TABLE `rings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-20  7:40:45
