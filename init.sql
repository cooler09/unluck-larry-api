CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Questions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Questions" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NULL
);

CREATE TABLE "Answers" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Answers" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NULL,
    "QuestionId" INTEGER NULL,
    CONSTRAINT "FK_Answers_Questions_QuestionId" FOREIGN KEY ("QuestionId") REFERENCES "Questions" ("Id") ON DELETE RESTRICT
);

CREATE INDEX "IX_Answers_QuestionId" ON "Answers" ("QuestionId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180623063530_Init', '2.1.1-rtm-30846');

ALTER TABLE "Questions" ADD "GroupName" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180623193740_GroupName', '2.1.1-rtm-30846');

