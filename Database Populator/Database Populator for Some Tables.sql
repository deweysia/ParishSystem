/* INSERTING BLOOD DONOR PROFILE */
INSERT into bloodDonor(profileID, bloodType) VALUES(1, "O");
INSERT into bloodDonor(profileID, bloodType) VALUES(2, "A");
INSERT into bloodDonor(profileID, bloodType) VALUES(3, "B");
INSERT into bloodDonor(profileID, bloodType) VALUES(4, "O");
INSERT into bloodDonor(profileID, bloodType) VALUES(5, "AB");


/* INSERTING BLOOD DONATION EVENTS TABLE */
INSERT into BloodDonationEvent(eventName, eventDate, eventStatus, eventVenue, eventDetails) VALUES("Blood Donation Event", "2017-12-1", "On Going", "4609 Green Hill Road", "no details");
INSERT into BloodDonationEvent(eventName, eventDate, eventStatus, eventVenue, eventDetails) VALUES("Blood Charity", "2013-05-0"3, "Finished, "367 Holden Street", "no details");
INSERT into BloodDonationEvent(eventName, eventDate, eventStatus, eventVenue, eventDetails) VALUES("Our Lady of Assumption Blood Donations", "2011-02-14", "Finished", "4166 Jenna Lane", "no details");
INSERT into BloodDonationEvent(eventName, eventDate, eventStatus, eventVenue, eventDetails) VALUES("Red Cross Blood Donation Event", "2017-11-26", "To Be Held", "Hall Place", "no details");
INSERT into BloodDonationEvent(eventName, eventDate, eventStatus, eventVenue, eventDetails) VALUES("Davao Doctors Hospital Blood Donations", "2012-11-30", "On Going", "Southside Lane", "no details");

/* INSERTING BLOOD DONATION */
INSERT into bloodDonation(bloodDonorID, donationEventID, donationAmount) VALUES(1, 1, 1);
INSERT into bloodDonation(bloodDonorID, donationEventID, donationAmount) VALUES(2, 2, 1);
INSERT into bloodDonation(bloodDonorID, donationEventID, donationAmount) VALUES(3, 3, 1);
INSERT into bloodDonation(bloodDonorID, donationEventID, donationAmount) VALUES(4, 4, 1);
INSERT into bloodDonation(bloodDonorID, donationEventID, donationAmount) VALUES(5, 5, 1);

/* INSERTING BLOOD EVENTS */
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2011-03-11", "Josh", "Figueroa", "Lintag", "Jr.", "1998-07-02", 0)
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2015-09-14", "Trent ", "Jacobs", "Evans", "", "1978-03-12", 0)
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2014-11-20", "Christopher", "Michaels", "Gardener", "Sr.", "1950-10-11", 0)
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2008-12-24", "Dexter", "Splatters", "Morgan", "", "1972-08-24", 0)
INSERT into BloodDonationRetrieval(claimDate, firstName, midName, lastName, suffix, birthdate, gender) VALUES("2017-07-06", "Alexander", "Slave", "Hamilton", "", "2002-04-13", 0)




/* ======================================================================================================= */ 
/*                                   		  NEW THINGS                                                   */
/* ======================================================================================================= */ 


/* INSERTING SPONSORS */
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender) VALUES(1, "James", "Sine", "Keeler", "Sr.", "Baptism", "Winston Salem, New York", "m");
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender) VALUES(1, "Randall ", "Worthy", "Villegas", "", "Marriage", "4976 Nixon Avenue Chattanooga", "m");
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender) VALUES(1, "Leah ", "Sancho", "Morales", "", "Confirmation", "Woodbridge Lane Detroit", "f");
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gende)  VALUES(1, "Alan", "Olson", "Sidney", "Jr.", "Baptism", "Ocala Street Orlando", "m");
INSERT INTO Sponsor(sacramentID, firstName, midName, lastName, suffix, sacramentType, residence, gender) VALUES(1, "Bobbie ", "Grants", "Thomason", "", "Marriage", "360 Mattson Street", "f");


/* INSERTING MINISTER */
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("Rico", "Gaskin", "Wade", "Sr.", "1960-06-01", "Priest", "Expired", "BRO3886", "2017-03-14");
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("Andrew", "Carver", "Pinson", "", "1972-01-05", "Priest", "Active", "LOL1421", "2020-08-19");
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("Luis", "Berry", "Torres", "Sr.", "1960-11-20", "Bishop", "Active", "NOP9264", "2018-10-10");
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("William", "McConnell", "Barnett", "", "1972-07-23", "Priest", "Expired", "HEL1263", "2010-08-12");
INSERT INTO Minister(firstName, midName, lastName, suffix, birthdate, ministryType, status, licenseNumber, expirationDate) VALUES("Bryan", "Lu", "Rooney", "", "1963-02-14", "Bishop", "Expired", "POS9271", "2014-04-15");


/* INSERTING SCHEDULE */
INSERT INTO Schedule("scheduleType, startDateTime, endDateTime, details, status, priority") VALUES("Appointment", "2017-03-14 08:40:00", "2017-03-14 09:40:00", "NO DETAILS", "TO BE HELD", "URGENT");
INSERT INTO Schedule("scheduleType, startDateTime, endDateTime, details, status, priority") VALUES("Event Meeting", "2017-08-24 10:30:00", "2017-08-24 12:30:00", "NO DETAILS", "TO BE HELD", "NORMAL");
INSERT INTO Schedule("scheduleType, startDateTime, endDateTime, details, status, priority") VALUES("Appointment", "2012-01-05 08:40:00", "2012-01-05 09:40:00", "NO DETAILS", "DONE", "NORMAL");
INSERT INTO Schedule("scheduleType, startDateTime, endDateTime, details, status, priority") VALUES("Sacrament Planning", "2015-05-10 07:40:00", "2015-05-10 10:40:00", "Marriage Sacrament Planning", "DONE", "URGENT");
INSERT INTO Schedule("scheduleType, startDateTime, endDateTime, details, status, priority") VALUES("Appointment", "2016-12-24 10:40:00", "2016-12-24 11:40:00", "Christmas Event Appointment", "APPOINTMENT CANCELLED", "NORMAL");





























