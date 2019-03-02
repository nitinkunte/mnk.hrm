CREATE TABLE "Users" (
 Id varchar (128) NOT NULL,
 Email varchar (256) DEFAULT NULL,
 EmailConfirmed tinyint (1) NOT NULL,
 PasswordHash longtext, "PasswordSalt" blob, "Username" varchar NOT NULL DEFAULT '',

 PRIMARY KEY (Id));

