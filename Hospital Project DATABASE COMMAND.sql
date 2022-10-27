create Table AppointmentTime (Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
                              Name NVARCHAR (MAX) NOT NULL);

Create Table Department (Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
                         Department NVARCHAR (MAX) NOT NULL);

Create Table Doctors (Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
                         DOCNAME NVARCHAR (MAX) NOT NULL,
						 DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department(Id),
						 Rating INT NULL );

Create Table Designation (Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
                         Name NVARCHAR (MAX) NOT NULL);

create table Appointment_Registration (Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
                                       PatientName NVARCHAR (MAX) NOT NULL,
									   PhoneNumber NVARCHAR (MAX) NOT NULL,
									   Address NVARCHAR(MAX) NOT NULL,
									   AppointmentDate DATE NOT NULL,
									   AppointmentTimes INT NOT NULL FOREIGN KEY REFERENCES AppointmentTime(Id),
									   DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department(Id),
									   DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
									   UserId NVARCHAR (450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id));

Create Table DoctorDesignation (DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
                                DesignationId INT NOT NULL FOREIGN KEY REFERENCES Designation(Id)
								PRIMARY KEY(DoctorId,DesignationId));

Create Table COMMENTS (Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
                       Comments NVARCHAR (MAX) NOT NULL);

Create Table Patient (Id INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                      AppointmentId INT NULL FOREIGN KEY REFERENCES Appointment_Registration(Id),
					  Name NVARCHAR (MAX) NOT NULL,
					  Address NVARCHAR (MAX) NOT NULL,
					  PhoneNumber NVARCHAR (MAX) NOT NULL,
					  DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department(Id),
					  DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
					  Status NVARCHAR (MAX) NOT NULL,
					  Refer INT NULL FOREIGN KEY REFERENCES Doctors(Id)
					  );

CREATE TABLE DoctorRatings( Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
                            DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
							PatientId INT NOT NULL FOREIGN KEY REFERENCES Patient(Id),
							Rating INT NOT NULL);

Create Table UserPatient(UserId NVARCHAR (450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id),
                         PatientId INT NOT NULL FOREIGN KEY REFERENCES Patient(Id),
				    	 PRIMARY KEY (UserId, PatientId));

Create Table PatientComment(CommentId INT NOT NULL FOREIGN KEY REFERENCES COMMENTS(Id),
                            PatientId INT NOT NULL FOREIGN KEY REFERENCES Patient(Id),
							   PRIMARY KEY (CommentId, PatientId));

INSERT INTO Department (Department) VALUES('Eye')
INSERT INTO Department (Department) VALUES('Lung')
INSERT INTO Department (Department) VALUES('Heart')

INSERT INTO Designation (Name) VALUES('Junior Doctor')
INSERT INTO Designation (Name) VALUES('Senior Doctor')
INSERT INTO Designation (Name) VALUES('Head Doctor')

INSERT INTO AppointmentTime (Name) VALUES('10:00AM - 10:30AM')
INSERT INTO AppointmentTime (Name) VALUES('10:30AM - 11:00AM')
INSERT INTO AppointmentTime (Name) VALUES('11:00AM - 11:30AM')
INSERT INTO AppointmentTime (Name) VALUES('11:30AM - 12:00')
INSERT INTO AppointmentTime (Name) VALUES('02:00PM - 02:30PM')
INSERT INTO AppointmentTime (Name) VALUES('02:30PM - 03:00PM')
INSERT INTO AppointmentTime (Name) VALUES('03:00PM - 03:30PM')
INSERT INTO AppointmentTime (Name) VALUES('03:30PM - 04:00PM')
INSERT INTO AppointmentTime (Name) VALUES('04:00PM - 04:30PM')
INSERT INTO AppointmentTime (Name) VALUES('04:30PM - 05:00PM')

