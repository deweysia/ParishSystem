-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema sad2
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sad2
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sad2` DEFAULT CHARACTER SET utf8 ;
USE `sad2` ;

-- -----------------------------------------------------
-- Table `sad2`.`application`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`application` (
  `applicationID` INT(11) NOT NULL AUTO_INCREMENT,
  `sacramentType` INT NULL DEFAULT NULL,
  `status` INT NULL DEFAULT NULL,
  `requirements` VARCHAR(45) NULL,
  PRIMARY KEY (`applicationID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`generalprofile`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`generalprofile` (
  `profileID` INT(11) NOT NULL AUTO_INCREMENT,
  `firstName` VARCHAR(45) NULL DEFAULT NULL,
  `midName` VARCHAR(45) NULL DEFAULT NULL,
  `lastName` VARCHAR(45) NULL DEFAULT NULL,
  `suffix` VARCHAR(5) NULL DEFAULT NULL,
  `birthdate` DATE NULL DEFAULT NULL,
  `gender` INT NULL DEFAULT NULL,
  `address` VARCHAR(45) NULL DEFAULT NULL,
  `birthplace` VARCHAR(45) NULL DEFAULT NULL,
  `contactNumber` VARCHAR(45) NULL DEFAULT NULL,
  `bloodType` VARCHAR(3) NULL DEFAULT NULL,
  `civilStatus` INT NULL,
  PRIMARY KEY (`profileID`),
  UNIQUE INDEX `personName` (`firstName` ASC, `midName` ASC, `lastName` ASC, `suffix` ASC, `birthdate` ASC, `gender` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`applicant`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`applicant` (
  `applicantID` INT(11) NOT NULL AUTO_INCREMENT,
  `profileID` INT(11) NOT NULL,
  `applicationID` INT(11) NOT NULL,
  PRIMARY KEY (`applicantID`),
  INDEX `applicant_genprof_idx` (`profileID` ASC),
  INDEX `applicant_application_idx` (`applicationID` ASC),
  CONSTRAINT `applicant_application`
    FOREIGN KEY (`applicationID`)
    REFERENCES `sad2`.`application` (`applicationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `applicant_genprof`
    FOREIGN KEY (`profileID`)
    REFERENCES `sad2`.`generalprofile` (`profileID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`minister`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`minister` (
  `ministerID` INT(11) NOT NULL AUTO_INCREMENT,
  `firstName` VARCHAR(45) NULL DEFAULT NULL,
  `midName` VARCHAR(45) NULL DEFAULT NULL,
  `lastName` VARCHAR(45) NULL DEFAULT NULL,
  `suffix` VARCHAR(10) NULL DEFAULT NULL,
  `birthdate` DATE NULL DEFAULT NULL,
  `ministryType` INT NULL DEFAULT NULL,
  `status` INT NULL DEFAULT NULL,
  `licenseNumber` VARCHAR(45) NULL DEFAULT NULL,
  `expirationDate` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`ministerID`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`baptism`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`baptism` (
  `baptismID` INT(11) NOT NULL AUTO_INCREMENT,
  `applicationID` INT(11) NOT NULL,
  `ministerID` INT(11) NULL DEFAULT NULL,
  `recordNumber` VARCHAR(45) NULL DEFAULT NULL,
  `pageNumber` VARCHAR(45) NULL DEFAULT NULL,
  `registryNumber` VARCHAR(45) NULL DEFAULT NULL,
  `baptismDate` DATETIME NULL DEFAULT NULL,
  `remarks` VARCHAR(45) NULL DEFAULT NULL,
  `legitimacy` INT NULL,
  PRIMARY KEY (`baptismID`),
  INDEX `baptism_app_idx` (`applicationID` ASC),
  INDEX `baptism_minister_idx` (`ministerID` ASC),
  CONSTRAINT `baptism_app`
    FOREIGN KEY (`applicationID`)
    REFERENCES `sad2`.`application` (`applicationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `baptism_minister`
    FOREIGN KEY (`ministerID`)
    REFERENCES `sad2`.`minister` (`ministerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`blooddonationevent`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`blooddonationevent` (
  `bloodDonationEventID` INT(11) NOT NULL AUTO_INCREMENT,
  `eventName` VARCHAR(45) NULL DEFAULT NULL,
  `startDateTime` DATETIME NULL DEFAULT NULL,
  `endDateTime` DATETIME NULL DEFAULT NULL,
  `eventVenue` VARCHAR(45) NULL DEFAULT NULL,
  `eventDetails` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`bloodDonationEventID`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`blooddonation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`blooddonation` (
  `bloodDonationID` INT(11) NOT NULL AUTO_INCREMENT,
  `profileID` INT(11) NOT NULL,
  `bloodDonationEventID` INT(11) NOT NULL,
  `bloodDonationDateTime` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`bloodDonationID`),
  INDEX `fk_blooddonation_blooddonationevent1_idx` (`bloodDonationEventID` ASC),
  INDEX `bloodDonation_generalProfile_idx` (`profileID` ASC),
  CONSTRAINT `bloodDonation_generalProfile`
    FOREIGN KEY (`profileID`)
    REFERENCES `sad2`.`generalprofile` (`profileID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_blooddonation_blooddonationevent1`
    FOREIGN KEY (`bloodDonationEventID`)
    REFERENCES `sad2`.`blooddonationevent` (`bloodDonationEventID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`cashreleasetype`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`cashreleasetype` (
  `cashReleaseTypeID` INT(11) NOT NULL AUTO_INCREMENT,
  `cashReleaseType` VARCHAR(45) NULL DEFAULT NULL,
  `description` VARCHAR(45) NULL DEFAULT NULL,
  `bookType` VARCHAR(45) NULL,
  `status` INT NULL DEFAULT NULL,
  PRIMARY KEY (`cashReleaseTypeID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`cashrelease`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`cashrelease` (
  `cashReleaseID` INT(11) NOT NULL AUTO_INCREMENT,
  `cashReleaseTypeID` INT(11) NOT NULL,
  `cashReleaseDateTime` DATETIME NULL DEFAULT NULL,
  `remarks` VARCHAR(150) NULL DEFAULT NULL,
  `releaseAmount` DOUBLE NULL DEFAULT NULL,
  `checkNum` INT(11) NULL DEFAULT NULL,
  `CVnum` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`cashReleaseID`),
  INDEX `cashRel_cashRelType_idx` (`cashReleaseTypeID` ASC),
  CONSTRAINT `cashRel_cashRelType`
    FOREIGN KEY (`cashReleaseTypeID`)
    REFERENCES `sad2`.`cashreleasetype` (`cashReleaseTypeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`confirmation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`confirmation` (
  `confirmationID` INT(11) NOT NULL AUTO_INCREMENT,
  `applicationID` INT(11) NOT NULL,
  `ministerID` INT(11) NULL DEFAULT NULL,
  `recordNumber` VARCHAR(45) NULL DEFAULT NULL,
  `pageNumber` VARCHAR(45) NULL DEFAULT NULL,
  `registryNumber` VARCHAR(45) NULL DEFAULT NULL,
  `confirmationDate` DATE NULL DEFAULT NULL,
  `remarks` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`confirmationID`),
  INDEX `confirmation_app_idx` (`applicationID` ASC),
  INDEX `confirmation_minister_idx` (`ministerID` ASC),
  CONSTRAINT `confirmation_app`
    FOREIGN KEY (`applicationID`)
    REFERENCES `sad2`.`application` (`applicationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `confirmation_minister`
    FOREIGN KEY (`ministerID`)
    REFERENCES `sad2`.`minister` (`ministerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`itemtype`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`itemtype` (
  `itemTypeID` INT(11) NOT NULL AUTO_INCREMENT,
  `itemType` VARCHAR(45) NOT NULL,
  `bookType` VARCHAR(45) NOT NULL,
  `suggestedPrice` DOUBLE NOT NULL,
  `status` INT NOT NULL,
  PRIMARY KEY (`itemTypeID`),
  UNIQUE INDEX `itemTypeID_UNIQUE` (`itemTypeID` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`primaryincome`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`primaryincome` (
  `primaryIncomeID` INT(11) NOT NULL AUTO_INCREMENT,
  `sourceName` VARCHAR(45) NULL DEFAULT NULL,
  `bookType` INT NOT NULL,
  `ORnum` INT(11) NOT NULL,
  `remarks` VARCHAR(45) NOT NULL,
  `primaryIncomeDateTime` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`primaryIncomeID`),
  UNIQUE INDEX `itemID_UNIQUE` (`primaryIncomeID` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`item` (
  `itemID` INT(11) NOT NULL AUTO_INCREMENT,
  `itemTypeID` INT(11) NOT NULL,
  `primaryIncomeID` INT(11) NOT NULL,
  `price` DOUBLE NOT NULL,
  `quantity` INT(11) NOT NULL,
  PRIMARY KEY (`itemID`),
  UNIQUE INDEX `itemID_UNIQUE` (`itemID` ASC),
  INDEX `item_itemType_idx` (`itemTypeID` ASC),
  INDEX `item_primaryIncome_idx` (`primaryIncomeID` ASC),
  CONSTRAINT `item_itemType`
    FOREIGN KEY (`itemTypeID`)
    REFERENCES `sad2`.`itemtype` (`itemTypeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `item_primaryIncome`
    FOREIGN KEY (`primaryIncomeID`)
    REFERENCES `sad2`.`primaryincome` (`primaryIncomeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`marriage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`marriage` (
  `marriageID` INT(11) NOT NULL AUTO_INCREMENT,
  `applicationID` INT(11) NOT NULL,
  `ministerID` INT(11) NULL DEFAULT NULL,
  `recordNumber` VARCHAR(45) NULL DEFAULT NULL,
  `pageNumber` VARCHAR(4) NULL DEFAULT NULL,
  `registryNumber` VARCHAR(45) NULL DEFAULT NULL,
  `licenseDate` DATE NULL DEFAULT NULL,
  `marriageDate` DATE NULL DEFAULT NULL,
  `status` INT NULL DEFAULT NULL,
  `remarks` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`marriageID`),
  INDEX `marriage_minister_idx` (`ministerID` ASC),
  INDEX `marraige_application_idx` (`applicationID` ASC),
  CONSTRAINT `marraige_application`
    FOREIGN KEY (`applicationID`)
    REFERENCES `sad2`.`application` (`applicationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `marriage_minister`
    FOREIGN KEY (`ministerID`)
    REFERENCES `sad2`.`minister` (`ministerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`parent`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`parent` (
  `parentID` INT(11) NOT NULL AUTO_INCREMENT,
  `profileID` INT(11) NULL DEFAULT NULL,
  `firstName` VARCHAR(45) NULL DEFAULT NULL,
  `midName` VARCHAR(45) NULL DEFAULT NULL,
  `lastName` VARCHAR(45) NULL DEFAULT NULL,
  `suffix` VARCHAR(5) NULL DEFAULT NULL,
  `birthdate` DATE NULL DEFAULT NULL,
  `gender` CHAR(1) NULL DEFAULT NULL,
  `birthplace` VARCHAR(45) NULL DEFAULT NULL,
  `residence` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`parentID`),
  INDEX `parent_genprof_idx` (`profileID` ASC),
  CONSTRAINT `parent_genprof`
    FOREIGN KEY (`profileID`)
    REFERENCES `sad2`.`generalprofile` (`profileID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`sacramentincome`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`sacramentincome` (
  `sacramentIncomeID` INT(11) NOT NULL AUTO_INCREMENT,
  `itemTypeID` INT(11) NOT NULL,
  `applicationID` INT(11) NOT NULL,
  `price` DOUBLE NULL DEFAULT NULL,
  `remarks` VARCHAR(45) NOT NULL,
  `sacramentIncomeDateTime` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`sacramentIncomeID`),
  INDEX `sacramentIncome_ItemType_idx` (`itemTypeID` ASC),
  INDEX `sacramentIncome_application_idx` (`applicationID` ASC),
  CONSTRAINT `sacramentIncome_application`
    FOREIGN KEY (`applicationID`)
    REFERENCES `sad2`.`application` (`applicationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `sacramentIncome_itemType`
    FOREIGN KEY (`itemTypeID`)
    REFERENCES `sad2`.`itemtype` (`itemTypeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`payment` (
  `paymentID` INT(11) NOT NULL AUTO_INCREMENT,
  `sacramentIncomeID` INT(11) NOT NULL,
  `paymentAmount` DOUBLE NULL DEFAULT NULL,
  `ORnum` INT(11) NOT NULL,
  `remarks` VARCHAR(45) NULL DEFAULT NULL,
  `paymentDateTime` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`paymentID`),
  INDEX `payment_sacramentIncome_idx` (`sacramentIncomeID` ASC),
  CONSTRAINT `payment_sacramentIncome`
    FOREIGN KEY (`sacramentIncomeID`)
    REFERENCES `sad2`.`sacramentincome` (`sacramentIncomeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`ministerschedule`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`ministerschedule` (
  `ministerScheduleID` INT(11) NOT NULL AUTO_INCREMENT,
  `ministerID` INT(11) NULL,
  `title` VARCHAR(45) NULL,
  `details` VARCHAR(45) NULL DEFAULT NULL,
  `startDateTime` DATETIME NULL DEFAULT NULL,
  `endDateTime` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`ministerScheduleID`),
  INDEX `ministerschedule_minister_idx` (`ministerID` ASC),
  CONSTRAINT `ministerschedule_minister`
    FOREIGN KEY (`ministerID`)
    REFERENCES `sad2`.`minister` (`ministerID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`sponsor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`sponsor` (
  `sponsorID` INT(11) NOT NULL AUTO_INCREMENT,
  `applicationID` INT(11) NULL DEFAULT NULL,
  `firstName` VARCHAR(45) NULL DEFAULT NULL,
  `midName` VARCHAR(45) NULL DEFAULT NULL,
  `lastName` VARCHAR(45) NULL DEFAULT NULL,
  `suffix` VARCHAR(10) NULL,
  `gender` INT NULL DEFAULT NULL,
  `residence` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`sponsorID`),
  CONSTRAINT `sponsor_application`
    FOREIGN KEY (`applicationID`)
    REFERENCES `sad2`.`application` (`applicationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`user` (
  `userID` INT(11) NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NULL DEFAULT NULL,
  `password` VARCHAR(45) NULL DEFAULT NULL,
  `userType` VARCHAR(45) NULL DEFAULT NULL,
  `active` INT(1) NULL DEFAULT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE INDEX `userAccount` (`username` ASC, `password` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = '				';


-- -----------------------------------------------------
-- Table `sad2`.`schedule`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`schedule` (
  `scheduleID` INT(11) NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(45) NULL,
  `details` VARCHAR(45) NULL DEFAULT NULL,
  `startDateTime` DATETIME NULL DEFAULT NULL,
  `endDateTime` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`scheduleID`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
