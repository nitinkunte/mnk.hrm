

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


CREATE TABLE "EmployeeDemographic" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_EmployeeDemographic" PRIMARY KEY AUTOINCREMENT,
    "Gender" TEXT NOT NULL,
    "MaritalStatus" TEXT NULL,
    "Ethnicity" TEXT NOT NULL,
    "Race" TEXT NOT NULL
);


CREATE TABLE "EmployeeImmigration" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_EmployeeImmigration" PRIMARY KEY AUTOINCREMENT,
    "WorkAuthorizationType" TEXT NOT NULL,
    "DateOfExpiry" TEXT NULL,
    "JobTitle" TEXT NOT NULL
);


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


CREATE TABLE "Employees" (
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


CREATE INDEX "IX_Employees_AddressId" ON "Employees" ("AddressId");
CREATE INDEX "IX_Employees_DemographicId" ON "Employees" ("DemographicId");
CREATE INDEX "IX_Employees_ImmigrationId" ON "Employees" ("ImmigrationId");
CREATE INDEX "IX_Employees_JobDetailId" ON "Employees" ("JobDetailId");