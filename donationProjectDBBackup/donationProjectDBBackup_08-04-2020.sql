-- MySQL dump 10.13  Distrib 8.0.17, for Linux (x86_64)
--
-- Host: localhost    Database: donationProjectDB
-- ------------------------------------------------------
-- Server version	8.0.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `donationProjectDB`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `donationProjectDB` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `donationProjectDB`;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20200407220933_initNewDatabase','3.1.3');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `city` (
  `cityId` int(11) NOT NULL AUTO_INCREMENT,
  `cityName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`cityId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,'Karachi'),(2,'Lahore'),(3,'Sargodha');
/*!40000 ALTER TABLE `city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cityArea`
--

DROP TABLE IF EXISTS `cityArea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cityArea` (
  `areaId` int(11) NOT NULL AUTO_INCREMENT,
  `cityId` int(11) DEFAULT NULL,
  `areaName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`areaId`),
  KEY `IX_cityArea_cityId` (`cityId`),
  CONSTRAINT `FK_cityArea_city_cityId` FOREIGN KEY (`cityId`) REFERENCES `city` (`cityId`) ON DELETE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cityArea`
--

LOCK TABLES `cityArea` WRITE;
/*!40000 ALTER TABLE `cityArea` DISABLE KEYS */;
INSERT INTO `cityArea` VALUES (1,1,'Saddar'),(2,1,'Baldia'),(3,1,'Surjani'),(4,1,'Safora'),(5,1,'Gulistan-e-Jauhar');
/*!40000 ALTER TABLE `cityArea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cnicPicRecord`
--

DROP TABLE IF EXISTS `cnicPicRecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cnicPicRecord` (
  `cnicPicRecordId` int(11) NOT NULL AUTO_INCREMENT,
  `userRecordId` int(11) NOT NULL,
  `userGuid` char(36) NOT NULL,
  `cnicFrontPicPath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `cnicBackPicPath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`cnicPicRecordId`),
  UNIQUE KEY `IX_cnicPicRecord_userRecordId` (`userRecordId`),
  CONSTRAINT `FK_cnicPicRecord_userRecord_userRecordId` FOREIGN KEY (`userRecordId`) REFERENCES `userRecord` (`userRecordId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cnicPicRecord`
--

LOCK TABLES `cnicPicRecord` WRITE;
/*!40000 ALTER TABLE `cnicPicRecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `cnicPicRecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `familyMembersRecords`
--

DROP TABLE IF EXISTS `familyMembersRecords`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `familyMembersRecords` (
  `familyMembersRecordId` int(11) NOT NULL AUTO_INCREMENT,
  `userRecordId` int(11) NOT NULL,
  `numberOfFamilyMembers` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`familyMembersRecordId`),
  UNIQUE KEY `IX_familyMembersRecords_userRecordId` (`userRecordId`),
  CONSTRAINT `FK_familyMembersRecords_userRecord_userRecordId` FOREIGN KEY (`userRecordId`) REFERENCES `userRecord` (`userRecordId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `familyMembersRecords`
--

LOCK TABLES `familyMembersRecords` WRITE;
/*!40000 ALTER TABLE `familyMembersRecords` DISABLE KEYS */;
/*!40000 ALTER TABLE `familyMembersRecords` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemCategory`
--

DROP TABLE IF EXISTS `itemCategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemCategory` (
  `itemCategoryId` int(11) NOT NULL AUTO_INCREMENT,
  `itemCategoryName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`itemCategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemCategory`
--

LOCK TABLES `itemCategory` WRITE;
/*!40000 ALTER TABLE `itemCategory` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemCategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemDetails`
--

DROP TABLE IF EXISTS `itemDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemDetails` (
  `itemDetailId` int(11) NOT NULL AUTO_INCREMENT,
  `itemCategoryId` int(11) DEFAULT NULL,
  `ownerId` int(11) NOT NULL,
  `itemName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `itemDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ammount` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`itemDetailId`),
  KEY `IX_itemDetails_itemCategoryId` (`itemCategoryId`),
  CONSTRAINT `FK_itemDetails_itemCategory_itemCategoryId` FOREIGN KEY (`itemCategoryId`) REFERENCES `itemCategory` (`itemCategoryId`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemDetails`
--

LOCK TABLES `itemDetails` WRITE;
/*!40000 ALTER TABLE `itemDetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemDonation`
--

DROP TABLE IF EXISTS `itemDonation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemDonation` (
  `itemDonationId` int(11) NOT NULL AUTO_INCREMENT,
  `donationDate` datetime(6) NOT NULL,
  `donationId` int(11) NOT NULL,
  `receiverId` int(11) NOT NULL,
  `itemId` int(11) NOT NULL,
  `ammount` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`itemDonationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemDonation`
--

LOCK TABLES `itemDonation` WRITE;
/*!40000 ALTER TABLE `itemDonation` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemDonation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moneyDonation`
--

DROP TABLE IF EXISTS `moneyDonation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `moneyDonation` (
  `moneyDonationId` int(11) NOT NULL AUTO_INCREMENT,
  `donationDate` datetime(6) NOT NULL,
  `donationId` int(11) NOT NULL,
  `receiverId` int(11) NOT NULL,
  `ammount` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`moneyDonationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moneyDonation`
--

LOCK TABLES `moneyDonation` WRITE;
/*!40000 ALTER TABLE `moneyDonation` DISABLE KEYS */;
/*!40000 ALTER TABLE `moneyDonation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizationData`
--

DROP TABLE IF EXISTS `organizationData`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organizationData` (
  `organizationId` int(11) NOT NULL AUTO_INCREMENT,
  `licenseNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `userGuid` char(36) NOT NULL,
  `organizationName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `aboutOrganization` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `organizationAddress` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `isActive` tinyint(1) NOT NULL,
  `areaId1` int(11) DEFAULT NULL,
  `cityId` int(11) NOT NULL,
  PRIMARY KEY (`organizationId`),
  KEY `IX_organizationData_areaId1` (`areaId1`),
  CONSTRAINT `FK_organizationData_cityArea_areaId1` FOREIGN KEY (`areaId1`) REFERENCES `cityArea` (`areaId`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizationData`
--

LOCK TABLES `organizationData` WRITE;
/*!40000 ALTER TABLE `organizationData` DISABLE KEYS */;
/*!40000 ALTER TABLE `organizationData` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `screenNameRecord`
--

DROP TABLE IF EXISTS `screenNameRecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `screenNameRecord` (
  `screenNameRecordId` int(11) NOT NULL AUTO_INCREMENT,
  `userGuid` char(36) NOT NULL,
  `username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `userPassword` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `userRecordId` int(11) NOT NULL,
  `isActive` tinyint(1) NOT NULL,
  PRIMARY KEY (`screenNameRecordId`),
  UNIQUE KEY `IX_screenNameRecord_userRecordId` (`userRecordId`),
  CONSTRAINT `FK_screenNameRecord_userRecord_userRecordId` FOREIGN KEY (`userRecordId`) REFERENCES `userRecord` (`userRecordId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `screenNameRecord`
--

LOCK TABLES `screenNameRecord` WRITE;
/*!40000 ALTER TABLE `screenNameRecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `screenNameRecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userRecord`
--

DROP TABLE IF EXISTS `userRecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userRecord` (
  `userRecordId` int(11) NOT NULL AUTO_INCREMENT,
  `userGuid` char(36) NOT NULL,
  `userFirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `userLastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `userCNIC` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `familyNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `userAddress` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `userAddressPerCNIC` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `emailAddress` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `cityId` int(11) NOT NULL,
  `areaId1` int(11) DEFAULT NULL,
  `isActive` tinyint(1) NOT NULL,
  `UserTypeid` int(11) DEFAULT NULL,
  PRIMARY KEY (`userRecordId`),
  KEY `IX_userRecord_UserTypeid` (`UserTypeid`),
  KEY `IX_userRecord_areaId1` (`areaId1`),
  CONSTRAINT `FK_userRecord_cityArea_areaId1` FOREIGN KEY (`areaId1`) REFERENCES `cityArea` (`areaId`) ON DELETE RESTRICT,
  CONSTRAINT `FK_userRecord_userType_UserTypeid` FOREIGN KEY (`UserTypeid`) REFERENCES `userType` (`id`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userRecord`
--

LOCK TABLES `userRecord` WRITE;
/*!40000 ALTER TABLE `userRecord` DISABLE KEYS */;
/*!40000 ALTER TABLE `userRecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userType`
--

DROP TABLE IF EXISTS `userType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userType` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `typeName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userType`
--

LOCK TABLES `userType` WRITE;
/*!40000 ALTER TABLE `userType` DISABLE KEYS */;
/*!40000 ALTER TABLE `userType` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-08  4:11:48
