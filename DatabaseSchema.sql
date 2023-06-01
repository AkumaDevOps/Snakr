CREATE DATABASE  IF NOT EXISTS `snakr-db` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `snakr-db`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: sv-snakr-westeu-dev-db.mysql.database.azure.com    Database: snakr-db
-- ------------------------------------------------------
-- Server version	5.7.42-log

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
-- Table structure for table `absences`
--

DROP TABLE IF EXISTS `absences`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `absences` (
  `IdMasterUsers` int(11) NOT NULL,
  `IdMasterGroups` int(11) NOT NULL,
  `IdUserGroupsMachinesReservations` int(11) NOT NULL,
  PRIMARY KEY (`IdMasterUsers`,`IdMasterGroups`,`IdUserGroupsMachinesReservations`),
  KEY `IdMasterGroups_FK_idx` (`IdMasterGroups`),
  KEY `IdUserGroupsMachinesReservations_FK_idx` (`IdUserGroupsMachinesReservations`),
  CONSTRAINT `Absences_IdMasterGroups_FK` FOREIGN KEY (`IdMasterGroups`) REFERENCES `mastergroups` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Absences_IdUserGroupsMachinesReservations_FK` FOREIGN KEY (`IdUserGroupsMachinesReservations`) REFERENCES `usergroupsmachinesreservations` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Absences_idMasterUsers_FK` FOREIGN KEY (`IdMasterUsers`) REFERENCES `masterusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `favouriteproducts`
--

DROP TABLE IF EXISTS `favouriteproducts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `favouriteproducts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdMasterProducts` int(11) NOT NULL,
  `IdMasterUsers` int(11) NOT NULL,
  `IdMasterGroups` int(11) NOT NULL,
  `SugarQuantity` int(11) DEFAULT NULL,
  `OrderNumber` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  KEY `IdProduct_FK_idx` (`IdMasterProducts`),
  KEY `IdMasterUsers_FK_idx` (`IdMasterUsers`),
  KEY `IdMasterGroups_FK_idx` (`IdMasterGroups`),
  CONSTRAINT `favouriteproducts_IdMasterGroups_FK` FOREIGN KEY (`IdMasterGroups`) REFERENCES `mastergroups` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `favouriteproducts_IdMasterProducts_FK` FOREIGN KEY (`IdMasterProducts`) REFERENCES `masterproducts` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `favouriteproducts_IdMasterUsers_FK` FOREIGN KEY (`IdMasterUsers`) REFERENCES `masterusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `masterbranches`
--

DROP TABLE IF EXISTS `masterbranches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `masterbranches` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `BranchName` varchar(50) NOT NULL,
  `Location` varchar(50) NOT NULL,
  `City` varchar(50) NOT NULL,
  `Country` varchar(50) NOT NULL,
  `PhoneNumber` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `mastergroups`
--

DROP TABLE IF EXISTS `mastergroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mastergroups` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdMasterBranches` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `MasterGroups_IdMasterBranch_FK_idx` (`IdMasterBranches`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `masterproducts`
--

DROP TABLE IF EXISTS `masterproducts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `masterproducts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Model` varchar(45) NOT NULL,
  `Brand` varchar(45) NOT NULL,
  `Description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `masterproviders`
--

DROP TABLE IF EXISTS `masterproviders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `masterproviders` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyNameS` varchar(10) NOT NULL,
  `CompanyNameL` varchar(100) DEFAULT NULL,
  `StreetAddress` varchar(100) DEFAULT NULL,
  `City` varchar(100) NOT NULL,
  `Country` varchar(100) NOT NULL,
  `PostalCode` varchar(10) DEFAULT NULL,
  `Phone` varchar(15) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `masterusers`
--

DROP TABLE IF EXISTS `masterusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `masterusers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `idMasterBranches` int(11) NOT NULL,
  `UserName` varchar(45) NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `LastName` varchar(45) NOT NULL,
  `Email` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `MasterUsers_IdMasterBranch_FK_idx` (`idMasterBranches`),
  CONSTRAINT `MasterUsers_IdMasterBranch_FK` FOREIGN KEY (`idMasterBranches`) REFERENCES `masterbranches` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `mastervendingmachines`
--

DROP TABLE IF EXISTS `mastervendingmachines`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mastervendingmachines` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `MachineName` varchar(45) NOT NULL,
  `Model` varchar(45) DEFAULT NULL,
  `Brand` varchar(45) NOT NULL,
  `Capacity` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `purchases`
--

DROP TABLE IF EXISTS `purchases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `purchases` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdMasterProducts` int(11) NOT NULL,
  `IdMasterProvider` int(11) NOT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `PriceUnit` float DEFAULT NULL,
  `PurchaseDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Purchases_IdProducts_FK_idx` (`IdMasterProducts`),
  KEY `Purchases_IdMasterProviders_FK_idx` (`IdMasterProvider`),
  CONSTRAINT `Purchases_IdMasterProducts_FK` FOREIGN KEY (`IdMasterProducts`) REFERENCES `masterproducts` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Purchases_IdMasterProviders_FK` FOREIGN KEY (`IdMasterProvider`) REFERENCES `masterproviders` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `requests`
--

DROP TABLE IF EXISTS `requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requests` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdMasterUser` int(11) NOT NULL,
  `IdMasterProducts` int(11) NOT NULL,
  `SugarQuantity` int(11) DEFAULT NULL,
  `Notes` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Requests_IdMasterUser_FK_idx` (`IdMasterUser`),
  KEY `Requests_IdMasterProducts_FK_idx` (`IdMasterProducts`),
  CONSTRAINT `Requests_IdMasterProducts_FK` FOREIGN KEY (`IdMasterProducts`) REFERENCES `masterproducts` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `Requests_IdMasterUser_FK` FOREIGN KEY (`IdMasterUser`) REFERENCES `masterusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usergrouppaymentproducts`
--

DROP TABLE IF EXISTS `usergrouppaymentproducts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usergrouppaymentproducts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdUserGroupPayments` int(11) NOT NULL,
  `IdMasterProducts` int(11) NOT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `PriceUnit` float DEFAULT NULL,
  `Currency` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `USerGroupPaymentProducts_IdUserGroupPayments_FK_idx` (`IdUserGroupPayments`),
  KEY `UserGroupPaymentProducts_IdMasterProducts_FK_idx` (`IdMasterProducts`),
  CONSTRAINT `UserGroupPaymentProducts_IdMasterProducts_FK` FOREIGN KEY (`IdMasterProducts`) REFERENCES `masterproducts` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `UserGroupPaymentProducts_IdUserGroupPayments_FK` FOREIGN KEY (`IdUserGroupPayments`) REFERENCES `usergrouppayments` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usergrouppayments`
--

DROP TABLE IF EXISTS `usergrouppayments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usergrouppayments` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdVendingMachinesBranches` int(11) NOT NULL,
  `IdMasterGroups` int(11) NOT NULL,
  `IdMasterUsers` int(11) NOT NULL,
  `NumberProducts` int(11) DEFAULT NULL,
  `TotalExpended` float DEFAULT NULL,
  `PaymentDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `UserGroupPayments_IdVendingMachinesBranches_FK_idx` (`IdVendingMachinesBranches`),
  KEY `UserGroupPayments_IdMasterGroups_FK_idx` (`IdMasterGroups`),
  KEY `UserGroupPayments_IdMasterUsers_FK_idx` (`IdMasterUsers`),
  CONSTRAINT `UserGroupPayments_IdMasterGroups_FK` FOREIGN KEY (`IdMasterGroups`) REFERENCES `mastergroups` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `UserGroupPayments_IdMasterUsers_FK` FOREIGN KEY (`IdMasterUsers`) REFERENCES `masterusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `UserGroupPayments_IdVendingMachinesBranches_FK` FOREIGN KEY (`IdVendingMachinesBranches`) REFERENCES `vendingmachinesbranches` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usergroups`
--

DROP TABLE IF EXISTS `usergroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usergroups` (
  `IdMasterUsers` int(11) NOT NULL,
  `IdMasterGroups` int(11) NOT NULL,
  PRIMARY KEY (`IdMasterUsers`,`IdMasterGroups`),
  KEY `UsersGroups_IdMasterGroups_FK_idx` (`IdMasterGroups`),
  CONSTRAINT `UsersGroups_IdMasterGroups_FK` FOREIGN KEY (`IdMasterGroups`) REFERENCES `mastergroups` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `UsersGroups_IdMasterUsers_FK` FOREIGN KEY (`IdMasterUsers`) REFERENCES `masterusers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usergroupsmachinesreservations`
--

DROP TABLE IF EXISTS `usergroupsmachinesreservations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usergroupsmachinesreservations` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdVendingMachinesBranches` int(11) NOT NULL,
  `IdMasterGroup` int(11) NOT NULL,
  `TimeReserve` datetime NOT NULL,
  `Minutes` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `UserGroupsMachinesReservations_IdVendingMachinesBranches_FK_idx` (`IdVendingMachinesBranches`),
  KEY `UserGroupsMachinesReservations_IdMasterGroups_FK_idx` (`IdMasterGroup`),
  CONSTRAINT `UserGroupsMachinesReservations_IdMasterGroups_FK` FOREIGN KEY (`IdMasterGroup`) REFERENCES `mastergroups` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `UserGroupsMachinesReservations_IdVendingMachinesBranches_FK` FOREIGN KEY (`IdVendingMachinesBranches`) REFERENCES `vendingmachinesbranches` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vendingmachinesbranches`
--

DROP TABLE IF EXISTS `vendingmachinesbranches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendingmachinesbranches` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdMasterVendingMachines` int(11) NOT NULL,
  `IdMasterBranches` int(11) NOT NULL,
  `BuildingName` varchar(45) DEFAULT NULL,
  `Floor` int(11) DEFAULT NULL,
  `Notes` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `VendingMachinesBranches_IdMasterVendingMachines_FK_idx` (`IdMasterVendingMachines`),
  KEY `VendingMachinesBranches_IdMasterBranches_idx` (`IdMasterBranches`),
  CONSTRAINT `VendingMachinesBranches_IdMasterBranches` FOREIGN KEY (`IdMasterBranches`) REFERENCES `masterbranches` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `VendingMachinesBranches_IdMasterVendingMachines_FK` FOREIGN KEY (`IdMasterVendingMachines`) REFERENCES `mastervendingmachines` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vendingmachinesbranchesproducts`
--

DROP TABLE IF EXISTS `vendingmachinesbranchesproducts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendingmachinesbranchesproducts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdVendingMachinesBranches` int(11) NOT NULL,
  `IdMasterProduct` int(11) NOT NULL,
  `AsociatedNumber` int(11) DEFAULT NULL,
  `Price` float DEFAULT NULL,
  `Currency` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `VendingMachinesBranches_IdVendingMachinesBranches_FK_idx` (`IdVendingMachinesBranches`),
  KEY `VendingMachinesBranchesProducts_IdMasterProduct_FK_idx` (`IdMasterProduct`),
  CONSTRAINT `VendingMachinesBranchesProducts_IdMasterProduct_FK` FOREIGN KEY (`IdMasterProduct`) REFERENCES `masterproducts` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `VendingMachinesBranchesProducts_IdVendingMachinesBranches_FK` FOREIGN KEY (`IdVendingMachinesBranches`) REFERENCES `vendingmachinesbranches` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vendingrefills`
--

DROP TABLE IF EXISTS `vendingrefills`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendingrefills` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdVendingMachinesBranches` int(11) NOT NULL,
  `IdProduct` int(11) NOT NULL,
  `IdEmployee` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `CodeNumberMachine` int(11) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `Notes` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdVendingMachinesBranches_FK_idx` (`IdVendingMachinesBranches`),
  KEY `IdProduct_FK_idx` (`IdProduct`),
  CONSTRAINT `VendingRefills_IdProduct_FK` FOREIGN KEY (`IdProduct`) REFERENCES `masterproducts` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `VendingRefills_IdVendingMachinesBranches_FK` FOREIGN KEY (`IdVendingMachinesBranches`) REFERENCES `vendingmachinesbranches` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-31 10:37:13
