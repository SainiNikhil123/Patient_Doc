Create Database Hospital_Project

Use Hospital_Project


Create Table Department(Id INT NOT NULL PRIMARY KEY,
                        Department NVARCHAR(MAX) NOT NULL);


Create Table Doctors(Id INT NOT NULL PRIMARY KEY,
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

Alter Table Doctors ADD Rating INT NULL

Create Table Patient (Id INT NOT NULL PRIMARY KEY,
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

Create Table Designation(Id INT NOT NULL PRIMARY KEY,
                         Name NVARCHAR (MAX) NOT NULL
                         );

Create Table DoctorDesignation(DoctorId INT NOT NULL FOREIGN KEY REFERENCES Doctors(Id),
                               DesignationId INT NOT NULL FOREIGN KEY REFERENCES Designation(Id),
							   PRIMARY KEY (DoctorId, DesignationId));
                               
