/* ======================================================================================================= */ 
/*                                   		  BLOOD DONATION TABLES YO                                     */
/* ======================================================================================================= */ 

 INSERTING BLOOD DONATION EVENTS TABLE 
INSERT into BloodDonationEvent(eventName, startDateTime, endDateTime, eventVenue, eventDetails) VALUES("Blood Donation Event", "2017-12-01 08:40:00", "2017-12-04 08:40:00",  "4609 Green Hill Road", "");
INSERT into BloodDonationEvent(eventName, startDateTime, endDateTime, eventVenue, eventDetails) VALUES("Blood Charity", "2013-05-03 10:40:00", "2013-05-05 10:30:00", "367 Holden Street", "");
INSERT into BloodDonationEvent(eventName, startDateTime, endDateTime, eventVenue, eventDetails) VALUES("Our Lady of Assumption Blood Donations", "2011-02-14 08:40:00", "2011-02-16 08:30:00", "4166 Jenna Lane", "Changed Venue");
INSERT into BloodDonationEvent(eventName, startDateTime, endDateTime, eventVenue, eventDetails) VALUES("Red Cross Blood Donation Event", "2017-11-26 09:00:00", "2017-11-28 10:10:00", "Hall Place", "");
INSERT into BloodDonationEvent(eventName, startDateTime, endDateTime, eventVenue, eventDetails) VALUES("Davao Doctors Hospital Blood Donations", "2012-11-30 09:40:00", "2012-11-31 08:30:00", "Southside Lane", "");

 INSERTING BLOOD DONATION 
INSERT into bloodDonation(generalProfile, donationEventID, donationDateTime) VALUES(1, 1, "2017-12-02 09:00:00");
INSERT into bloodDonation(generalProfile, donationEventID, donationDateTime) VALUES(2, 2, "2013-05-04 08:10:00");
INSERT into bloodDonation(generalProfile, donationEventID, donationDateTime) VALUES(3, 3, "2011-02-15  10:15:00");
INSERT into bloodDonation(generalProfile, donationEventID, donationDateTime) VALUES(4, 4, "2017-11-27 12:30:00");
INSERT into bloodDonation(generalProfile, donationEventID, donationDateTime) VALUES(5, 4, "2017-11-26 12:15:00");

/* INSERTING BLOOD EVENTS
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2011-03-11", "Josh", "Figueroa", "Lintag", "Jr.", "1998-07-02", 0);
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2015-09-14", "Trent ", "Jacobs", "Evans", "", "1978-03-12", 0);
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2014-11-20", "Christopher", "Michaels", "Gardener", "Sr.", "1950-10-11", 0);
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2008-12-24", "Dexter", "Splatters", "Morgan", "", "1972-08-24", 0);
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2017-07-06", "Alexander", "Slave", "Hamilton", "", "2002-04-13", 0);

 */


/* ======================================================================================================= */ 
/*                                   		  PREVIOUSLY ADDED                                             */
/* ======================================================================================================= */ 


/* INSERTING SCHEDULE */
INSERT INTO Schedule(scheduleType, startDateTime, endDateTime, details, status, priority) VALUES("Appointment", "2017-03-14 08:40:00", "2017-03-14 09:40:00", "NO DETAILS", "TO BE HELD", "URGENT");
INSERT INTO Schedule(scheduleType, startDateTime, endDateTime, details, status, priority) VALUES("Event Meeting", "2017-08-24 10:30:00", "2017-08-24 12:30:00", "NO DETAILS", "TO BE HELD", "NORMAL");
INSERT INTO Schedule(scheduleType, startDateTime, endDateTime, details, status, priority) VALUES("Appointment", "2012-01-05 08:40:00", "2012-01-05 09:40:00", "NO DETAILS", "DONE", "NORMAL");
INSERT INTO Schedule(scheduleType, startDateTime, endDateTime, details, status, priority) VALUES("Sacrament Planning", "2015-05-10 07:40:00", "2015-05-10 10:40:00", "Marriage Sacrament Planning", "DONE", "URGENT");
INSERT INTO Schedule(scheduleType, startDateTime, endDateTime, details, status, priority) VALUES("Appointment", "2016-12-24 10:40:00", "2016-12-24 11:40:00", "Christmas Event Appointment", "CANCELLED", "NORMAL");


/* INSERTING SPONSORS */
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender) VALUES(1, "James", "Sine", "Keeler", "Sr.", "Baptism", "Winston Salem, New York", "m");
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender) VALUES(1, "Randall ", "Worthy", "Villegas", "", "Marriage", "4976 Nixon Avenue Chattanooga", "m");
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender) VALUES(1, "Leah ", "Sancho", "Morales", "", "Confirmation", "Woodbridge Lane Detroit", "f");
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender)  VALUES(1, "Alan", "Olson", "Sidney", "Jr.", "Baptism", "Ocala Street Orlando", "m");
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender) VALUES(1, "Bobbie ", "Grants", "Thomason", "", "Marriage", "360 Mattson Street", "f");


/* INSERTING MINISTER */
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("Rico", "Gaskin", "Wade", "Sr.", "1960-06-01", "Priest", "Expired", "BRO3886", "2017-03-14");
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("Andrew", "Carver", "Pinson", "", "1972-01-05", "Priest", "Active", "LOL1421", "2020-08-19");
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("Luis", "Berry", "Torres", "Sr.", "1960-11-20", "Bishop", "Active", "NOP9264", "2018-10-10");
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("William", "McConnell", "Barnett", "", "1972-07-23", "Priest", "Expired", "HEL1263", "2010-08-12");
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("Bryan", "Lu", "Rooney", "", "1963-02-14", "Bishop", "Expired", "POS9271", "2014-04-15");


/*Inserting APPOINTMENT */

INSERT INTO Appointment(profileID, ministerID, scheduleID) VALUES(1, 1, 1);
INSERT INTO Appointment(profileID, ministerID, scheduleID) VALUES(2, 1, 2);
INSERT INTO Appointment(profileID, ministerID, scheduleID) VALUES(3, 3, 3);
INSERT INTO Appointment(profileID, ministerID, scheduleID) VALUES(4, 2, 4);
INSERT INTO Appointment(profileID, ministerID, scheduleID) VALUES(5, 2, 5);





/* ======================================================================================================= */ 
/*                                   		  NEW THINGS     JULY 13th                                     */
/* ======================================================================================================= */ 

/* INSERTING APPLICATION */
INSERT INTO Application(applicationType, status) VALUES("M","Approved"); 	
INSERT INTO Application(applicationType, status) VALUES("C","Pending");           
INSERT INTO Application(applicationType, status) VALUES("C","Pending");           
INSERT INTO Application(applicationType, status) VALUES("B","Rejected");          
INSERT INTO Application(applicationType, status) VALUES("M","Cancelled");         
INSERT INTO Application(applicationType, status) VALUES("B","Pending"); 
INSERT INTO Application(applicationType, status) VALUES("B","Approved"); 
INSERT INTO Application(applicationType, status) VALUES("C","Approved"); 
INSERT INTO Application(applicationType, status) VALUES("B","Cancelled"); 
INSERT INTO Application(applicationType, status) VALUES("M","Approved");         
INSERT INTO Application(applicationType, status) VALUES("C","Approved"); 


/* INSERTING APPLICANT */
INSERT INTO Applicant(profileID, applicationID) VALUES(1,2);
INSERT INTO Applicant(profileID, applicationID) VALUES(2,1);
INSERT INTO Applicant(profileID, applicationID) VALUES(3,1);
INSERT INTO Applicant(profileID, applicationID) VALUES(4,3);
INSERT INTO Applicant(profileID, applicationID) VALUES(3,5);
INSERT INTO Applicant(profileID, applicationID) VALUES(6,5);
INSERT INTO Applicant(profileID, applicationID) VALUES(7,4);
INSERT INTO Applicant(profileID, applicationID) VALUES(2,5);
INSERT INTO Applicant(profileID, applicationID) VALUES(3,6);
INSERT INTO Applicant(profileID, applicationID) VALUES(5,10);
INSERT INTO Applicant(profileID, applicationID) VALUES(1,10);
INSERT INTO Applicant(profileID, applicationID) VALUES(6,7);
INSERT INTO Applicant(profileID, applicationID) VALUES(1,8);
INSERT INTO Applicant(profileID, applicationID) VALUES(4,9);




 



/* INSERTING BAPTISM */
INSERT INTO Baptism(applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, baptismDate) VALUES(4, 2, "BP31", "B003", "PAGE21", "Incomplete Requirements", "2017-07-16");
INSERT INTO Baptism(applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, baptismDate) VALUES(6, 2, "BP47", "B005", "PAGE30", "Waiting for approval", "2017-12-24");
INSERT INTO Baptism(applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, baptismDate) VALUES(7, 3, "BP120", "B030", "PAGE22", "", "2012-05-10");
INSERT INTO Baptism(applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, baptismDate) VALUES(8, 3, "BP99", "B010", "PAGE21", "", "2017-05-25");


/* INSERTING CONFIRMATION */

INSERT INTO Confirmation(applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, confirmationDate) VALUES(2, 1, "CM15", "C003", "PAGE2", "", "2017-07-30");
INSERT INTO Confirmation(applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, confirmationDate) VALUES(3, 2, "CM61", "C032", "PAGE51", "Waiting for approval", "207-11-01");
INSERT INTO Confirmation(applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, confirmationDate) VALUES(8, 3, "CM17", "C012", "PAGE22", "", "2017-10-18");
INSERT INTO Confirmation(applicationID, ministerID, registryNumber, recordNumber, pageNumber, remarks, confirmationDate) VALUES(11, 4, "CM381", "C003", "PAGE10", "", "2006-06-01");


/* INSERTING MARRIAGE */ /*yawa this*/
INSERT INTO Marriage(applicationID, ministerID, registryNumber, recordNumber, pageNumber, licenseDate, remarks, marriageDate, status) VALUES(1, 4, "MR10", "M103", "PAGE90", "2017-08-01", "", "2017-10-18", "active");
INSERT INTO Marriage(applicationID, ministerID, registryNumber, recordNumber, pageNumber, licenseDate, remarks, marriageDate, status) VALUES(5, 2, "MR31", "M050", "PAGE21", "2004-04-10", "", "2004-04-11", "Groom Widowed");
INSERT INTO Marriage(applicationID, ministerID, registryNumber, recordNumber, pageNumber, licenseDate, remarks, marriageDate, status) VALUES(10, 3, "MR92", "M006", "PAGE12", "2009-01-12", "", "2009-02-14", "active");

















