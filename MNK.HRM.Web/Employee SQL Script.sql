

CREATE TABLE "Employee" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Employees" PRIMARY KEY AUTOINCREMENT,
    "Prefix" TEXT NULL,
    "FirstName" TEXT NULL,
    "LastName" TEXT NULL,
    "MiddleName" TEXT NULL,
    "Suffix" TEXT NULL,
    "EmployeeId" TEXT NULL,
    "DateOfBirth" TEXT NOT NULL,
    "AddressId" INTEGER NULL,
    "JobDetailId" INTEGER NULL,
    "ImmigrationId" INTEGER NULL,
    "DemographicId" INTEGER NULL,
    CONSTRAINT "FK_Employees_EmployeeAddress_AddressId" FOREIGN KEY ("AddressId") REFERENCES "EmployeeAddress" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Employees_EmployeeDemographic_DemographicId" FOREIGN KEY ("DemographicId") REFERENCES "EmployeeDemographic" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Employees_EmployeeImmigration_ImmigrationId" FOREIGN KEY ("ImmigrationId") REFERENCES "EmployeeImmigration" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Employees_EmployeeJobDetail_JobDetailId" FOREIGN KEY ("JobDetailId") REFERENCES "EmployeeJobDetail" ("Id") ON DELETE RESTRICT
);
INSERT INTO "Employee" VALUES (1, NULL, 'Nitin', 'Kunte', NULL, NULL, '1001', '1972-10-15', NULL, NULL, 1, NULL);
INSERT INTO "Employee" VALUES (2, '', 'Roger', 'Johnson', NULL, 'Jr.', '1004', '2008-11-07', NULL, NULL, NULL, NULL);
INSERT INTO "Employee" VALUES (3, '', 'Georgina', 'Young', NULL, '', '1005', '2018-11-01', NULL, NULL, NULL, NULL);
INSERT INTO "Employee" VALUES (4, 'Mr.', 'John', 'Caruso', NULL, '', '1006', '2018-11-02', NULL, NULL, NULL, NULL);
INSERT INTO "Employee" VALUES (5, 'Ms.', 'Monica', 'Amrutkar', NULL, NULL, '1009', '1984-02-02 00:00:00', 1, NULL, 2, 1);
INSERT INTO "Employee" VALUES (8, 'Ms.', 'Gautamee', 'Gadre', NULL, NULL, '1010', '1993-10-11 00:00:00', 4, 3, 5, 4);
INSERT INTO "Employee" VALUES (9, 'Mr.', 'Sumant', 'Bhat', NULL, NULL, '1011', '1984-10-25 00:00:00', 5, 4, 6, 5);
INSERT INTO "Employee" VALUES (11, 'Ms.', 'Poorva', 'Sowani', NULL, NULL, '1012', '1978-05-16 00:00:00', 8, 6, 9, 8);


CREATE INDEX "IX_Employees_AddressId" ON "Employee" ("AddressId");
CREATE INDEX "IX_Employees_DemographicId" ON "Employee" ("DemographicId");
CREATE INDEX "IX_Employees_ImmigrationId" ON "Employee" ("ImmigrationId");
CREATE INDEX "IX_Employees_JobDetailId" ON "Employee" ("JobDetailId");

CREATE TABLE "EmployeeAddress" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_EmployeeAddress" PRIMARY KEY AUTOINCREMENT,
    "Address1" TEXT NULL,
    "Address2" TEXT NULL,
    "City" TEXT NULL,
    "State" TEXT NULL,
    "ZipCode" TEXT NULL,
    "PhoneHome" TEXT NULL,
    "PhoneCell" TEXT NULL,
    "EmailPersonal" TEXT NULL,
    "EmailWork" TEXT NULL
);
INSERT INTO "EmployeeAddress" VALUES (1, '100 Main St', NULL, 'Irving', 'Texas', '75038', NULL, NULL, NULL, NULL);
INSERT INTO "EmployeeAddress" VALUES (2, '200 Main St', NULL, 'Irving', 'Texas', '75063', NULL, NULL, NULL, NULL);
INSERT INTO "EmployeeAddress" VALUES (3, '100 Main St', NULL, 'Irving', 'TX', '75063', NULL, '469-213-2233', NULL, 'monica@mnkinfotech.com');
INSERT INTO "EmployeeAddress" VALUES (4, '200 Main St', NULL, 'Irving', 'Texas', '75063', NULL, '469-568-5321', NULL, 'gautamee@mnkinfotech.com');
INSERT INTO "EmployeeAddress" VALUES (5, '2563 McArthur Dr', NULL, 'Irving', 'Texas', '75063', NULL, '972-465-8987', 'sumantbhat10@gmail.com', NULL);
INSERT INTO "EmployeeAddress" VALUES (6, '2563 McArthur Dr', NULL, 'Irving', 'Texas', '75063', NULL, '972-465-8987', 'sumantbhat10@gmail.com', NULL);
INSERT INTO "EmployeeAddress" VALUES (7, '323 Peach Tree', NULL, 'Atlanta', 'GA', '34055', NULL, '469-569-7894', NULL, 'poorva@mnkinfotech.com');
INSERT INTO "EmployeeAddress" VALUES (8, '323 Peach Tree', NULL, 'Atlanta', 'GA', '34055', NULL, '469-569-7894', NULL, 'poorva@mnkinfotech.com');


CREATE TABLE "EmployeeDemographic" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_EmployeeDemographic" PRIMARY KEY AUTOINCREMENT,
    "Gender" TEXT NOT NULL,
    "MaritalStatus" TEXT NULL,
    "Ethnicity" TEXT NOT NULL,
    "Race" TEXT NOT NULL
);
INSERT INTO "EmployeeDemographic" VALUES (1, 'F', 'M', 'Indian', 'Asian');
INSERT INTO "EmployeeDemographic" VALUES (2, 'F', 'S', 'Indian', 'Asian');
INSERT INTO "EmployeeDemographic" VALUES (3, 'F', 'M', 'Indian', 'Asian');
INSERT INTO "EmployeeDemographic" VALUES (4, 'F', 'S', 'Indian', 'Asian');
INSERT INTO "EmployeeDemographic" VALUES (5, 'M', 'Single', 'Asian', 'Indian');
INSERT INTO "EmployeeDemographic" VALUES (6, 'M', 'Single', 'Not Hispanic', 'Asian');
INSERT INTO "EmployeeDemographic" VALUES (7, 'F', 'Married', 'Not Hispanic', 'Asian');
INSERT INTO "EmployeeDemographic" VALUES (8, 'F', 'Married', 'Not Hispanic', 'Asian');


CREATE TABLE "EmployeeImmigration" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_EmployeeImmigration" PRIMARY KEY AUTOINCREMENT,
    "WorkAuthorizationType" TEXT NOT NULL,
    "DateOfExpiry" TEXT NULL,
    "JobTitle" TEXT NOT NULL
);
INSERT INTO "EmployeeImmigration" VALUES (1, 'Citizen', '2100-01-01', 'CIO');
INSERT INTO "EmployeeImmigration" VALUES (2, 'H1B', '2019-12-20 00:00:00', 'Software Developer');
INSERT INTO "EmployeeImmigration" VALUES (3, 'GC', '2025-10-23 00:00:00', 'Recruiter');
INSERT INTO "EmployeeImmigration" VALUES (4, 'H1B', '2021-12-15 00:00:00', 'Software Developer');
INSERT INTO "EmployeeImmigration" VALUES (5, 'GC', '2025-10-23 00:00:00', 'Recruiter');
INSERT INTO "EmployeeImmigration" VALUES (6, 'OPT- EAD', '2019-10-25 00:00:00', 'Developer');
INSERT INTO "EmployeeImmigration" VALUES (7, 'EAD', '2019-10-25 00:00:00', 'Developer');
INSERT INTO "EmployeeImmigration" VALUES (8, 'H1B', '2019-06-19 00:00:00', 'Project Manager');
INSERT INTO "EmployeeImmigration" VALUES (9, 'H1B', '2019-06-19 00:00:00', 'Project Manager');


CREATE TABLE "EmployeeJobDetail" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_EmployeeJobDetail" PRIMARY KEY AUTOINCREMENT,
    "DateStarted" TEXT NOT NULL,
    "DateTerminated" TEXT NULL,
    "PayRate" TEXT NOT NULL,
    "PayRateType" TEXT NOT NULL,
    "IsEligibleForVacation" INTEGER NOT NULL,
    "JobType" TEXT NOT NULL,
    "JobTitle" TEXT NULL
);
INSERT INTO "EmployeeJobDetail" VALUES (1, '2016-07-12 00:00:00', NULL, '35.0', 'Hourly', 1, 'Full Time', 'Software Developer');
INSERT INTO "EmployeeJobDetail" VALUES (2, '0001-01-01 00:00:00', NULL, '10.0', 'Hourly', 0, 'Full Time', 'Recruiter');
INSERT INTO "EmployeeJobDetail" VALUES (3, '2018-01-01 00:00:00', NULL, '10.0', 'Hourly', 0, 'Full Time', 'Recruiter');
INSERT INTO "EmployeeJobDetail" VALUES (4, '2017-11-11 00:00:00', NULL, '15.0', 'Hourly', 1, 'Full Time', 'Developer');
INSERT INTO "EmployeeJobDetail" VALUES (5, '2017-11-11 00:00:00', NULL, '15.0', 'Hourly', 1, 'Full Time', 'Developer');
INSERT INTO "EmployeeJobDetail" VALUES (6, '2014-06-20 00:00:00', NULL, '34.0', 'Hourly', 1, 'Full Time', 'Project Manager');
