Create Database Hospital_Project

Use Hospital_Project


Create Table Department(Id INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                        Department NVARCHAR(MAX) NOT NULL);


Create Table Doctors(Id INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                     DOCNAME NVARCHAR (MAX) NOT NULL,
					 DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department(Id));

Create Table Appointment_Registration(Id INT NOT NULL PRIMARY KEY, 
                                      PatientName NVARCHAR (MAX) NOT NULL,
									  PhoneNumber NVARCHAR (MAX) NOT NULL,
									  Address NVARCHAR (MAX) NOT NULL,
									  DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department(Id),
									  DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
									  AppointmentDate DATE NOT NULL,
									  AppointmentTime TIME NOT NULL);

Create Table AppointmentTime (Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
                               Name NVARCHAR (MAX) NOT NULL);
ALTER TABLE Patient ADD Status NVARCHAR (MAX) NULL

ALTER TABLE COMMENTS DROP COLUMN status

ALTER TABLE Patient ALTER COLUMN AppointmentId INT NOT NULL 

ALTER TABLE Appointment_Registration ADD UserId NVARCHAR (450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id)

Create Table Patient (Id INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                      AppointmentId INT NOT NULL FOREIGN KEY REFERENCES Department(Id),
					  Name NVARCHAR (MAX) NOT NULL,
					  Address NVARCHAR (MAX) NOT NULL,
					  PhoneNumber NVARCHAR (MAX) NOT NULL,
					  DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Department(Id),
					  DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
					  PatientStatus NVARCHAR (MAX) NOT NULL,
					  Comments NVARCHAR (MAX) NOT NULL,
					  Refer INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id)
					  );

Create Table Designation(Id INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                         Name NVARCHAR (MAX) NOT NULL
                         );

Create Table DoctorDesignation(DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
                               DesignationId INT NOT NULL FOREIGN KEY REFERENCES Designation(Id),
							   PRIMARY KEY (DoctorId, DesignationId));

Create Table UserPatient(UserId NVARCHAR (450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(Id),
                               PatientId INT NOT NULL FOREIGN KEY REFERENCES Patient(Id),
							   PRIMARY KEY (UserId, PatientId));

INSERT INTO Department (Department) VALUES('Eye')
INSERT INTO Department (Department) VALUES('Lung')
INSERT INTO Department (Department) VALUES('Heart')
       
SELECT * FROM Department

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

select * From AspNetUsers
