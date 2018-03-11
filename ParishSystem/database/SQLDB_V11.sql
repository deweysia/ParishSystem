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
-- Table `sad2`.`itemtype`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`itemtype` (
  `itemTypeID` INT(11) NOT NULL AUTO_INCREMENT,
  `itemType` VARCHAR(45) NOT NULL,
  `bookType` INT(11) NOT NULL,
  `suggestedPrice` DECIMAL(15,2) NULL DEFAULT NULL,
  `status` INT(11) NOT NULL,
  `details` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`itemTypeID`),
  UNIQUE INDEX `itemTypeID_UNIQUE` (`itemTypeID` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 33
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`application`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`application` (
  `applicationID` INT(11) NOT NULL AUTO_INCREMENT,
  `sacramentType` INT(11) NULL DEFAULT NULL,
  `status` VARCHAR(45) NULL DEFAULT NULL,
  `requirements` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`applicationID`),
  INDEX `sacType_idx` (`sacramentType` ASC),
  CONSTRAINT `sacType`
    FOREIGN KEY (`sacramentType`)
    REFERENCES `sad2`.`itemtype` (`itemTypeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 496
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
  `gender` CHAR(1) NULL DEFAULT NULL,
  `address` VARCHAR(45) NULL DEFAULT NULL,
  `birthplace` VARCHAR(45) NULL DEFAULT NULL,
  `contactNumber` VARCHAR(45) NULL DEFAULT NULL,
  `bloodType` VARCHAR(3) NULL DEFAULT NULL,
  `residence` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`profileID`),
  UNIQUE INDEX `personName` (`firstName` ASC, `midName` ASC, `lastName` ASC, `suffix` ASC, `birthdate` ASC, `gender` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 508
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
AUTO_INCREMENT = 499
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
  `ministryType` VARCHAR(45) NULL DEFAULT NULL,
  `status` VARCHAR(45) NULL DEFAULT NULL,
  `licenseNumber` VARCHAR(45) NULL DEFAULT NULL,
  `expirationDate` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`ministerID`))
ENGINE = InnoDB
AUTO_INCREMENT = 11
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
  `legitimacy` VARCHAR(45) NULL DEFAULT NULL,
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
AUTO_INCREMENT = 6
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
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`blooddonation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`blooddonation` (
  `bloodDonationID` INT(11) NOT NULL AUTO_INCREMENT,
  `profileID` INT(11) NOT NULL,
  `bloodDonationEventID` INT(11) NOT NULL,
  `quantity` INT(11) NULL DEFAULT NULL,
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
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`cashreleasevoucher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`cashreleasevoucher` (
  `CashReleaseVoucherID` INT(11) NOT NULL AUTO_INCREMENT,
  `cashReleaseDateTime` DATETIME NOT NULL,
  `remark` VARCHAR(45) NULL DEFAULT NULL,
  `checkNum` INT(11) NOT NULL,
  `CVnum` INT(11) NOT NULL,
  `bookType` INT(11) NOT NULL,
  `name` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`CashReleaseVoucherID`))
ENGINE = InnoDB
AUTO_INCREMENT = 14
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`cashreleaseitem`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`cashreleaseitem` (
  `cashReleaseID` INT(11) NOT NULL AUTO_INCREMENT,
  `CashReleaseVoucherID` INT(11) NOT NULL,
  `cashReleaseTypeID` INT(11) NOT NULL,
  `releaseAmount` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`cashReleaseID`),
  INDEX `a_idx` (`cashReleaseTypeID` ASC),
  INDEX `b_idx` (`CashReleaseVoucherID` ASC),
  CONSTRAINT `a`
    FOREIGN KEY (`cashReleaseTypeID`)
    REFERENCES `sad2`.`itemtype` (`itemTypeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `b`
    FOREIGN KEY (`CashReleaseVoucherID`)
    REFERENCES `sad2`.`cashreleasevoucher` (`CashReleaseVoucherID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`cashreleasetype`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`cashreleasetype` (
  `cashReleaseTypeID` INT(11) NOT NULL AUTO_INCREMENT,
  `cashReleaseType` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NULL DEFAULT NULL,
  `bookType` INT(11) NOT NULL,
  `status` INT(11) NULL DEFAULT '1',
  PRIMARY KEY (`cashReleaseTypeID`))
ENGINE = InnoDB
AUTO_INCREMENT = 13
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
-- Table `sad2`.`primaryincome`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`primaryincome` (
  `primaryIncomeID` INT(11) NOT NULL AUTO_INCREMENT,
  `sourceName` VARCHAR(45) NULL DEFAULT NULL,
  `bookType` VARCHAR(45) NOT NULL,
  `ORnum` INT(11) NOT NULL,
  `remarks` VARCHAR(45) NOT NULL,
  `primaryIncomeDateTime` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`primaryIncomeID`),
  UNIQUE INDEX `itemID_UNIQUE` (`primaryIncomeID` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 74
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`item` (
  `itemID` INT(11) NOT NULL AUTO_INCREMENT,
  `itemTypeID` INT(11) NOT NULL,
  `primaryIncomeID` INT(11) NOT NULL,
  `price` DECIMAL(15,2) NOT NULL,
  `quantity` INT(11) NOT NULL,
  PRIMARY KEY (`itemID`),
  UNIQUE INDEX `itemID_UNIQUE` (`itemID` ASC),
  INDEX `item_itemType_idx` (`itemTypeID` ASC),
  INDEX `item_primaryIncome_idx` (`primaryIncomeID` ASC),
  CONSTRAINT `item_itemType`
    FOREIGN KEY (`itemTypeID`)
    REFERENCES `sad2`.`itemtype` (`itemTypeID`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE,
  CONSTRAINT `item_primaryIncome`
    FOREIGN KEY (`primaryIncomeID`)
    REFERENCES `sad2`.`primaryincome` (`primaryIncomeID`)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 58
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
  `remarks` VARCHAR(45) NULL DEFAULT NULL,
  `civilStatusGroom` INT(11) NULL DEFAULT NULL,
  `civilStatusBride` INT(11) NULL DEFAULT NULL,
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
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`ministerschedule`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`ministerschedule` (
  `ministerScheduleID` INT(11) NOT NULL AUTO_INCREMENT,
  `ministerID` INT(11) NULL DEFAULT NULL,
  `title` VARCHAR(45) NULL DEFAULT NULL,
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
AUTO_INCREMENT = 3
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
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`sacramentincome`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`sacramentincome` (
  `sacramentIncomeID` INT(11) NOT NULL AUTO_INCREMENT,
  `applicationID` INT(11) NOT NULL,
  `price` DOUBLE NULL DEFAULT NULL,
  `remarks` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`sacramentIncomeID`),
  INDEX `sacramentIncome_application_idx` (`applicationID` ASC),
  CONSTRAINT `sacramentIncome_application`
    FOREIGN KEY (`applicationID`)
    REFERENCES `sad2`.`application` (`applicationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 493
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`payment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`payment` (
  `paymentID` INT(11) NOT NULL AUTO_INCREMENT,
  `sacramentIncomeID` INT(11) NOT NULL,
  `primaryIncomeID` INT(11) NOT NULL,
  `amount` DECIMAL(15,2) NOT NULL,
  PRIMARY KEY (`paymentID`),
  INDEX `payment_sacramentIncome_idx` (`sacramentIncomeID` ASC),
  INDEX `payment_primaryIncome_idx` (`primaryIncomeID` ASC),
  CONSTRAINT `payment_primaryIncome`
    FOREIGN KEY (`primaryIncomeID`)
    REFERENCES `sad2`.`primaryincome` (`primaryIncomeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `payment_sacramentIncome`
    FOREIGN KEY (`sacramentIncomeID`)
    REFERENCES `sad2`.`sacramentincome` (`sacramentIncomeID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 25
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`sponsor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`sponsor` (
  `sponsorID` INT(11) NOT NULL AUTO_INCREMENT,
  `ApplicationID` INT(11) NULL DEFAULT NULL,
  `firstname` VARCHAR(45) NULL DEFAULT NULL,
  `midname` VARCHAR(45) NULL DEFAULT NULL,
  `lastname` VARCHAR(45) NULL DEFAULT NULL,
  `suffix` VARCHAR(45) NULL DEFAULT NULL,
  `gender` VARCHAR(45) NULL DEFAULT NULL,
  `residence` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`sponsorID`),
  INDEX `ApplicationID_idx` (`ApplicationID` ASC),
  CONSTRAINT `ApplicationID`
    FOREIGN KEY (`ApplicationID`)
    REFERENCES `sad2`.`application` (`applicationID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 11
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`schedule`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sad2`.`schedule` (
  `scheduleID` INT(11) NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(45) NULL DEFAULT NULL,
  `details` VARCHAR(45) NULL DEFAULT NULL,
  `startDateTime` DATETIME NULL DEFAULT NULL,
  `endDateTime` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`scheduleID`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
