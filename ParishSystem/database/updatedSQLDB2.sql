SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `sad2` DEFAULT CHARACTER SET utf8 ;
USE `sad2` ;

-- -----------------------------------------------------
-- Table `sad2`.`generalprofile`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`generalprofile` (
  `profileID` INT(11) NOT NULL AUTO_INCREMENT ,
  `firstName` VARCHAR(45) NULL DEFAULT NULL ,
  `midName` VARCHAR(45) NULL DEFAULT NULL ,
  `lastName` VARCHAR(45) NULL DEFAULT NULL ,
  `suffix` VARCHAR(5) NULL DEFAULT NULL ,
  `birthdate` DATE NULL DEFAULT NULL ,
  `gender` CHAR(1) NULL DEFAULT NULL ,
  `address` VARCHAR(45) NULL DEFAULT NULL ,
  `birthplace` VARCHAR(45) NULL DEFAULT NULL ,
  `contactNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `bloodType` VARCHAR(3) NULL DEFAULT NULL ,
  PRIMARY KEY (`profileID`) ,
  UNIQUE INDEX `personName` (`firstName` ASC, `midName` ASC, `lastName` ASC, `suffix` ASC, `birthdate` ASC, `gender` ASC) )
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`application`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`application` (
  `applicationID` INT(11) NOT NULL AUTO_INCREMENT ,
  `profileID` INT(11) NOT NULL ,
  `applicationType` VARCHAR(45) NULL DEFAULT NULL ,
  `status` VARCHAR(45) NULL DEFAULT NULL ,
  INDEX `app_genprof_idx` (`profileID` ASC) ,
  PRIMARY KEY (`applicationID`) ,
  CONSTRAINT `app_genprof`
    FOREIGN KEY (`profileID` )
    REFERENCES `sad2`.`generalprofile` (`profileID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`requirement`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`requirement` (
  `requirementID` INT(11) NOT NULL AUTO_INCREMENT ,
  `requirementName` VARCHAR(45) NULL DEFAULT NULL ,
  `sacramentType` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`requirementID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`application_requirement`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`application_requirement` (
  `applicationID` INT(11) NOT NULL ,
  `requirementID` INT(11) NOT NULL ,
  PRIMARY KEY (`applicationID`, `requirementID`) ,
  INDEX `appReq_app_idx` (`requirementID` ASC) ,
  CONSTRAINT `appReq_app`
    FOREIGN KEY (`applicationID` )
    REFERENCES `sad2`.`application` (`applicationID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `appReq_req`
    FOREIGN KEY (`requirementID` )
    REFERENCES `sad2`.`requirement` (`requirementID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`minister`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`minister` (
  `ministerID` INT(11) NOT NULL AUTO_INCREMENT ,
  `firstName` VARCHAR(45) NULL DEFAULT NULL ,
  `midName` VARCHAR(45) NULL DEFAULT NULL ,
  `lastName` VARCHAR(45) NULL DEFAULT NULL ,
  `suffix` VARCHAR(10) NULL DEFAULT NULL ,
  `birthdate` DATE NULL DEFAULT NULL ,
  `ministryType` VARCHAR(45) NULL DEFAULT NULL ,
  `status` VARCHAR(45) NULL DEFAULT NULL ,
  `licenseNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `expirationDate` DATE NULL DEFAULT NULL ,
  PRIMARY KEY (`ministerID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`schedule`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`schedule` (
  `scheduleID` INT(11) NOT NULL AUTO_INCREMENT ,
  `scheduleType` VARCHAR(45) NULL DEFAULT NULL ,
  `startDateTime` DATETIME NULL DEFAULT NULL ,
  `endDateTime` DATETIME NULL DEFAULT NULL ,
  `details` VARCHAR(45) NULL DEFAULT NULL ,
  `status` VARCHAR(45) NULL DEFAULT NULL ,
  `priority` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`scheduleID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`appointment`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`appointment` (
  `appointmentID` INT(11) NOT NULL AUTO_INCREMENT ,
  `profileID` INT(11) NOT NULL ,
  `ministerID` INT(11) NULL DEFAULT NULL ,
  `scheduleID` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`appointmentID`) ,
  INDEX `app_gen_idx` (`profileID` ASC) ,
  INDEX `app_sched_idx` (`scheduleID` ASC) ,
  INDEX `app_min_idx` (`ministerID` ASC) ,
  CONSTRAINT `app_gen`
    FOREIGN KEY (`profileID` )
    REFERENCES `sad2`.`generalprofile` (`profileID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `app_min`
    FOREIGN KEY (`ministerID` )
    REFERENCES `sad2`.`minister` (`ministerID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `app_sched`
    FOREIGN KEY (`scheduleID` )
    REFERENCES `sad2`.`schedule` (`scheduleID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`baptism`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`baptism` (
  `baptismID` INT(11) NOT NULL AUTO_INCREMENT ,
  `applicationID` INT(11) NOT NULL ,
  `ministerID` INT(11) NULL DEFAULT NULL ,
  `recordNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `pageNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `registryNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `legitimacy` VARCHAR(20) NULL DEFAULT NULL ,
  `baptismDate` DATETIME NULL DEFAULT NULL ,
  `remarks` VARCHAR(45) NULL ,
  PRIMARY KEY (`baptismID`) ,
  INDEX `baptism_app_idx` (`applicationID` ASC) ,
  INDEX `baptism_minister_idx` (`ministerID` ASC) ,
  CONSTRAINT `baptism_app`
    FOREIGN KEY (`applicationID` )
    REFERENCES `sad2`.`application` (`applicationID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `baptism_minister`
    FOREIGN KEY (`ministerID` )
    REFERENCES `sad2`.`minister` (`ministerID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`blooddonationevent`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`blooddonationevent` (
  `bloodDonationEventID` INT(11) NOT NULL AUTO_INCREMENT ,
  `eventName` VARCHAR(45) NULL DEFAULT NULL ,
  `eventDateTime` DATETIME NULL DEFAULT NULL ,
  `eventStatus` VARCHAR(10) NULL DEFAULT NULL ,
  `eventVenue` VARCHAR(45) NULL DEFAULT NULL ,
  `eventDetails` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`bloodDonationEventID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`blooddonation`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`blooddonation` (
  `bloodDonationID` INT(11) NOT NULL AUTO_INCREMENT ,
  `profileID` INT(11) NOT NULL ,
  `bloodDonationEventID` INT(11) NOT NULL ,
  `donationAmount` INT NULL ,
  `bloodDonationDateTime` DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (`bloodDonationID`) ,
  INDEX `fk_blooddonation_blooddonationevent1_idx` (`bloodDonationEventID` ASC) ,
  INDEX `bloodDonation_bloodDonor_idx` (`profileID` ASC) ,
  CONSTRAINT `bloodDonation_bloodDonor`
    FOREIGN KEY (`profileID` )
    REFERENCES `sad2`.`generalprofile` (`profileID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_blooddonation_blooddonationevent1`
    FOREIGN KEY (`bloodDonationEventID` )
    REFERENCES `sad2`.`blooddonationevent` (`bloodDonationEventID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`blooddonationretrieval`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`blooddonationretrieval` (
  `bloodDonationID` INT(11) NOT NULL ,
  `claimDate` DATETIME NULL DEFAULT NULL ,
  `firstName` VARCHAR(45) NULL DEFAULT NULL ,
  `midName` VARCHAR(45) NULL DEFAULT NULL ,
  `lastName` VARCHAR(45) NULL DEFAULT NULL ,
  `suffix` VARCHAR(5) NULL DEFAULT NULL ,
  `birthdate` DATE NULL DEFAULT NULL ,
  `gender` CHAR(1) NULL DEFAULT NULL ,
  PRIMARY KEY (`bloodDonationID`) ,
  CONSTRAINT `bdretrieve_bd`
    FOREIGN KEY (`bloodDonationID` )
    REFERENCES `sad2`.`blooddonation` (`bloodDonationID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`cashreleasetype`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`cashreleasetype` (
  `cashReleaseTypeID` INT(11) NOT NULL AUTO_INCREMENT ,
  `cashReleaseType` VARCHAR(45) NULL DEFAULT NULL ,
  `description` VARCHAR(45) NULL DEFAULT NULL ,
  `active` BIT(1) NULL DEFAULT NULL ,
  PRIMARY KEY (`cashReleaseTypeID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`cashrelease`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`cashrelease` (
  `cashReleaseID` INT(11) NOT NULL AUTO_INCREMENT ,
  `cashReleaseTypeID` INT(11) NOT NULL ,
  `cashReleaseDateTime` DATETIME NULL DEFAULT NULL ,
  `remarks` VARCHAR(150) NULL DEFAULT NULL ,
  `releaseAmount` DOUBLE NULL DEFAULT NULL ,
  `checkNum` INT(11) NULL DEFAULT NULL ,
  `CVnum` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`cashReleaseID`) ,
  INDEX `cashRel_cashRelType_idx` (`cashReleaseTypeID` ASC) ,
  CONSTRAINT `cashRel_cashRelType`
    FOREIGN KEY (`cashReleaseTypeID` )
    REFERENCES `sad2`.`cashreleasetype` (`cashReleaseTypeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`confirmation`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`confirmation` (
  `confirmationID` INT(11) NOT NULL AUTO_INCREMENT ,
  `applicationID` INT(11) NOT NULL ,
  `ministerID` INT(11) NULL DEFAULT NULL ,
  `recordNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `pageNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `registryNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `confirmationDate` DATE NULL DEFAULT NULL ,
  `remarks` VARCHAR(45) NULL ,
  PRIMARY KEY (`confirmationID`) ,
  INDEX `confirmation_app_idx` (`applicationID` ASC) ,
  INDEX `confirmation_minister_idx` (`ministerID` ASC) ,
  CONSTRAINT `confirmation_app`
    FOREIGN KEY (`applicationID` )
    REFERENCES `sad2`.`application` (`applicationID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `confirmation_minister`
    FOREIGN KEY (`ministerID` )
    REFERENCES `sad2`.`minister` (`ministerID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`income`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`income` (
  `incomeID` INT(11) NOT NULL AUTO_INCREMENT ,
  `sourceID` INT(11) NULL DEFAULT NULL ,
  `bookType` VARCHAR(45) NOT NULL ,
  `remarks` VARCHAR(45) NULL DEFAULT NULL ,
  `incomeDateTime` DATETIME NOT NULL ,
  PRIMARY KEY (`incomeID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`incomesource`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`incomesource` (
  `incomeSourceID` INT(11) NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`incomeSourceID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`invoice`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`invoice` (
  `invoiceID` INT(11) NOT NULL AUTO_INCREMENT ,
  `incomeID` INT(11) NOT NULL ,
  `ORnum` INT(11) NULL DEFAULT NULL ,
  `paymentAmount` DOUBLE NOT NULL ,
  `invoiceDateTime` DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (`invoiceID`) ,
  INDEX `invoice_income_idx` (`incomeID` ASC) ,
  CONSTRAINT `invoice_income`
    FOREIGN KEY (`incomeID` )
    REFERENCES `sad2`.`income` (`incomeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`itemtype`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`itemtype` (
  `itemTypeID` INT(11) NOT NULL AUTO_INCREMENT ,
  `itemType` VARCHAR(45) NOT NULL ,
  `bookType` VARCHAR(45) NOT NULL ,
  `monthAdded` DATETIME NOT NULL ,
  `suggestedPrice` DOUBLE NOT NULL ,
  `status` VARCHAR(30) NOT NULL ,
  PRIMARY KEY (`itemTypeID`) ,
  UNIQUE INDEX `itemTypeID_UNIQUE` (`itemTypeID` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`item`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`item` (
  `itemID` INT(11) NOT NULL AUTO_INCREMENT ,
  `itemTypeID` INT(11) NOT NULL ,
  `incomeID` INT(11) NOT NULL ,
  `price` DOUBLE NOT NULL ,
  `quantity` INT(11) NOT NULL ,
  PRIMARY KEY (`itemID`) ,
  UNIQUE INDEX `itemID_UNIQUE` (`itemID` ASC) ,
  INDEX `item_itemType_idx` (`itemTypeID` ASC) ,
  INDEX `item_income_idx` (`incomeID` ASC) ,
  CONSTRAINT `item_income`
    FOREIGN KEY (`incomeID` )
    REFERENCES `sad2`.`income` (`incomeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `item_itemType`
    FOREIGN KEY (`itemTypeID` )
    REFERENCES `sad2`.`itemtype` (`itemTypeID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`marriage`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`marriage` (
  `marriageID` INT(11) NOT NULL AUTO_INCREMENT ,
  `applicationID` INT(11) NOT NULL ,
  `groomID` INT(11) NULL DEFAULT NULL ,
  `brideID` INT(11) NULL DEFAULT NULL ,
  `ministerID` INT(11) NULL DEFAULT NULL ,
  `recordNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `pageNumber` VARCHAR(4) NULL DEFAULT NULL ,
  `registryNumber` VARCHAR(45) NULL DEFAULT NULL ,
  `licenseDate` DATE NULL DEFAULT NULL ,
  `marriageDate` DATE NULL DEFAULT NULL ,
  `status` VARCHAR(45) NULL DEFAULT NULL ,
  `remarks` VARCHAR(45) NULL ,
  PRIMARY KEY (`marriageID`) ,
  UNIQUE INDEX `marriagePair` (`groomID` ASC, `brideID` ASC) ,
  INDEX `marriage_minister_idx` (`ministerID` ASC) ,
  CONSTRAINT `marriage_minister`
    FOREIGN KEY (`ministerID` )
    REFERENCES `sad2`.`minister` (`ministerID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`parent`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`parent` (
  `parentID` INT(11) NOT NULL AUTO_INCREMENT ,
  `profileID` INT(11) NULL DEFAULT NULL ,
  `firstName` VARCHAR(45) NULL DEFAULT NULL ,
  `midName` VARCHAR(45) NULL DEFAULT NULL ,
  `lastName` VARCHAR(45) NULL DEFAULT NULL ,
  `suffix` VARCHAR(5) NULL DEFAULT NULL ,
  `birthdate` DATE NULL DEFAULT NULL ,
  `gender` CHAR(1) NULL DEFAULT NULL ,
  `birthplace` VARCHAR(45) NULL DEFAULT NULL ,
  `residence` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`parentID`) ,
  INDEX `parent_genprof_idx` (`profileID` ASC) ,
  CONSTRAINT `parent_genprof`
    FOREIGN KEY (`profileID` )
    REFERENCES `sad2`.`generalprofile` (`profileID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`sponsor`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`sponsor` (
  `sponsorID` INT(11) NOT NULL AUTO_INCREMENT ,
  `sacramentID` INT(11) NULL DEFAULT NULL ,
  `firstName` VARCHAR(45) NULL DEFAULT NULL ,
  `midName` VARCHAR(45) NULL DEFAULT NULL ,
  `lastName` VARCHAR(45) NULL DEFAULT NULL ,
  `suffix` VARCHAR(10) NULL DEFAULT NULL ,
  `gender` CHAR(1) NULL DEFAULT NULL ,
  `sacramentType` VARCHAR(45) NULL DEFAULT NULL ,
  `residence` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`sponsorID`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `sad2`.`user`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `sad2`.`user` (
  `userID` INT(11) NOT NULL AUTO_INCREMENT ,
  `username` VARCHAR(45) NULL DEFAULT NULL ,
  `password` VARCHAR(45) NULL DEFAULT NULL ,
  `userType` VARCHAR(45) NULL DEFAULT NULL ,
  `active` INT(1) NULL DEFAULT NULL ,
  PRIMARY KEY (`userID`) ,
  UNIQUE INDEX `userAccount` (`username` ASC, `password` ASC) )
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8
COMMENT = '				';

USE `sad2` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
