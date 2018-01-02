USE [LocationAlertDB]
GO

-- Schema Creation, Location Alert
CREATE SCHEMA LA
GO

--**NOT RUN YET
-- Client Table Creation
CREATE TABLE LA.Client(
	ClientID INT PRIMARY KEY,
	FirstName NVARCHAR(50),
	MiddleInit NCHAR(1),
	LastName NVARCHAR(50),
	Email NVARCHAR(255),
	PhoneNumber CHAR(10),
	PasswordHash CHAR(64),
	PasswordSalt NVARCHAR(20),
	PreferenceID INT,
	DateModified DATETIME2
)
GO

--**NOT RUN YET
-- Region Table Creation
CREATE TABLE LA.Region(
	RegionID INT PRIMARY KEY,
	ClientID INT,
	RegionName NVARCHAR(50),
	Longitude DECIMAL(9,6),
	Latitude DECIMAL(8,6),
	Radius BIGINT,
	DateModified DATETIME2
)
GO

--**NOT RUN YET
-- Alert Table Creation
CREATE TABLE LA.Alert(
	AlertID INT PRIMARY KEY,
	ClientID INT,
	AlertTypeID INT,
	AlertMessage NVARCHAR(512),
	DateIssued DATETIME2
)
GO

--**NOT RUN YET
-- SubAlert Table Creation
CREATE TABLE LA.SubAlert(
	SubAlertID INT PRIMARY KEY,
	SubAlertType NVARCHAR(50),
	BaseAlertID INT
)
GO

--**NOT RUN YET
-- BaseAlert Table Creation
CREATE TABLE LA.BaseAlert(
	BaseAlertID INT PRIMARY KEY,
	BaseAlertType NVARCHAR(50)
)
GO

--**NOT RUN YET
-- Preference Table Creation
CREATE TABLE LA.Preference(
	PreferenceID INT PRIMARY KEY,
	WeatherPreferenceID INT,
	TrafficPreferenceID INT,
	NewsPreferenceID INT,
	DateModified DATETIME2
)
GO

--**NOT RUN YET
-- Weather Preference Table Creation
CREATE TABLE LA.WeatherPreference(
	WeatherPreferenceID INT PRIMARY KEY
)
GO

--**NOT RUN YET
-- Traffic Preference Table Creation
CREATE TABLE LA.TrafficPreference(
	TrafficPreferenceID INT PRIMARY KEY
)
GO

--**NOT RUN YET
-- News Preference Table Creation
CREATE TABLE LA.NewsPreference(
	NewsPreferenceID INT PRIMARY KEY
)
GO

ALTER TABLE LA.Client
	ADD FOREIGN KEY (PreferenceID) REFERENCES LA.Preference(PreferenceID)
GO

ALTER TABLE LA.Region
	ADD FOREIGN KEY (ClientID) REFERENCES LA.Client(ClientID)
GO

ALTER TABLE LA.Alert
	ADD FOREIGN KEY (ClientID) REFERENCES LA.Client(ClientID)
GO

ALTER TABLE LA.SubAlert
	ADD FOREIGN KEY (BaseAlertID) REFERENCES LA.BaseAlert(BaseAlertID)
GO

ALTER TABLE LA.WeatherPreference
	ADD FOREIGN KEY (WeatherPreferenceID) REFERENCES LA.Preference(WeatherPreferenceID)
GO

ALTER TABLE LA.TrafficPreference
	ADD FOREIGN KEY (TrafficPreferenceID) REFERENCES LA.Preference(TrafficPreferenceID)
GO

ALTER TABLE LA.NewsPreference
	ADD FOREIGN KEY (NewsPreferenceID) REFERENCES LA.Preference(NewsPreferenceID)
GO
