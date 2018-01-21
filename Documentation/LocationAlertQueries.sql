USE [LocationAlertDB]
GO

ALTER TABLE LA.Preference DROP
	constraint FK_Preference_WeatherPreference,
	constraint FK_Preference_TrafficPreference,
	constraint FK_Preference_NewsPreference;
GO
ALTER TABLE LA.SubAlert DROP constraint FK_SubAlert_BaseAlert;
GO
ALTER TABLE LA.Alert DROP constraint FK_Alert_Client;
GO
ALTER TABLE LA.Region DROP constraint FK_Region_Client;
GO
ALTER TABLE LA.Client DROP constraint FK_Client_Preference;
GO
DROP TABLE LA.NewsPreference;
GO
DROP TABLE LA.TrafficPreference;
GO
DROP TABLE LA.WeatherPreference;
GO
DROP TABLE LA.Preference;
GO
DROP TABLE LA.BaseAlert;
GO
DROP TABLE LA.SubAlert;
GO
DROP TABLE LA.Alert;
GO
DROP TABLE LA.Region;
GO
DROP TABLE LA.Client;
GO
DROP SCHEMA LA;
GO

-- Schema Creation, Location Alert
CREATE SCHEMA LA;
GO

-- Client Table Creation
CREATE TABLE LA.Client(
	ClientID INT identity NOT NULL,
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

-- Region Table Creation
CREATE TABLE LA.Region(
	RegionID INT identity NOT NULL,
	ClientID INT,
	RegionName NVARCHAR(50),
	Longitude DECIMAL(9,6),
	Latitude DECIMAL(8,6),
	Radius BIGINT,
	DateModified DATETIME2
)
GO

-- Alert Table Creation
CREATE TABLE LA.Alert(
	AlertID INT NOT NULL,
	ClientID INT,
	AlertTypeID INT,
	AlertMessage NVARCHAR(512),
	DateIssued DATETIME2
)
GO

-- SubAlert Table Creation
CREATE TABLE LA.SubAlert(
	SubAlertID INT NOT NULL,
	SubAlertType NVARCHAR(50),
	BaseAlertID INT
)
GO

-- BaseAlert Table Creation
CREATE TABLE LA.BaseAlert(
	BaseAlertID INT NOT NULL,
	BaseAlertType NVARCHAR(50)
)
GO

-- Preference Table Creation
CREATE TABLE LA.Preference(
	PreferenceID INT NOT NULL,
	WeatherPreferenceID INT,
	TrafficPreferenceID INT,
	NewsPreferenceID INT,
	DateModified DATETIME2
)
GO

-- Weather Preference Table Creation
CREATE TABLE LA.WeatherPreference(
	WeatherPreferenceID INT NOT NULL
)
GO

-- Traffic Preference Table Creation
CREATE TABLE LA.TrafficPreference(
	TrafficPreferenceID INT NOT NULL
)
GO

-- News Preference Table Creation
CREATE TABLE LA.NewsPreference(
	NewsPreferenceID INT NOT NULL
)
GO

-- Primary Key Creation
ALTER TABLE LA.Client
	ADD constraint PK_Client_ClientID PRIMARY KEY (ClientID)
GO
ALTER TABLE LA.Region
	ADD constraint PK_Region_RegionID PRIMARY KEY (RegionID)
GO
ALTER TABLE LA.Alert
	ADD constraint PK_Alert_AlertID PRIMARY KEY (AlertID)
GO
ALTER TABLE LA.SubAlert
	ADD constraint PK_SubAlert_SubAlertID PRIMARY KEY (SubAlertID)
GO
ALTER TABLE LA.BaseAlert
	ADD constraint PK_BaseAlert_BaseAlertID PRIMARY KEY (BaseAlertID)
GO
ALTER TABLE LA.Preference
	ADD constraint PK_Preference_PreferenceID PRIMARY KEY (PreferenceID)
GO
ALTER TABLE LA.WeatherPreference
	ADD constraint PK_WeatherPreference_WeatherPreferenceID PRIMARY KEY (WeatherPreferenceID)
GO
ALTER TABLE LA.TrafficPreference
	ADD constraint PK_TrafficPreference_TrafficPreferenceID PRIMARY KEY (TrafficPreferenceID)
GO
ALTER TABLE LA.NewsPreference
	ADD constraint PK_NewsPreference_NewsPreferenceID PRIMARY KEY (NewsPreferenceID)
GO

-- Foreign Key Creation
ALTER TABLE LA.Client
	ADD constraint FK_Client_Preference FOREIGN KEY (PreferenceID) REFERENCES LA.Preference(PreferenceID)
GO
--Foreign key added 01/10/2018 for client
ALTER TABLE LA.Region
	ADD constraint FK_Region_Client FOREIGN KEY (ClientID) REFERENCES LA.Client(ClientID) on update cascade
GO
ALTER TABLE LA.Alert
	ADD constraint FK_Alert_Client FOREIGN KEY (ClientID) REFERENCES LA.Client(ClientID)
GO
ALTER TABLE LA.SubAlert
	ADD constraint FK_SubAlert_BaseAlert FOREIGN KEY (BaseAlertID) REFERENCES LA.BaseAlert(BaseAlertID)
GO
ALTER TABLE LA.Preference ADD
	constraint FK_Preference_WeatherPreference FOREIGN KEY (WeatherPreferenceID) REFERENCES LA.WeatherPreference(WeatherPreferenceID),
	constraint FK_Preference_TrafficPreference FOREIGN KEY (TrafficPreferenceID) REFERENCES LA.TrafficPreference(TrafficPreferenceID),
	constraint FK_Preference_NewsPreference FOREIGN KEY (NewsPreferenceID) REFERENCES LA.NewsPreference(NewsPreferenceID)
GO

ALTER TABLE LA.WeatherPreference ADD
	pushHours INT NOT NULL DEFAULT 1,
	pushMinutes INT NOT NULL DEFAULT 0,
	alwaysTemp BIT NOT NULL DEFAULT 0,
	tempMin INT Not NULL DEFAULT 0,
	tempMax INT Not NULL DEFAULT 10,
	alwaysRain BIT Not NULL DEFAULT 0,
	rainMin INT Not NULL DEFAULT 0,
	rainMax INT Not NULL DEFAULT 10,
	alwaysSnow BIT Not NULL DEFAULT 0,
	snowMin INT Not NULL DEFAULT 0,
	snowMax INT Not NULL DEFAULT 10,
	alwaysCloud BIT Not NULL DEFAULT 0,
	cloudMin INT Not NULL DEFAULT 0,
	cloudMax INT Not NULL DEFAULT 10,
	alwaysWind BIT Not NULL DEFAULT 0,
	windMin INT Not NULL DEFAULT 0,
	windMax INT Not NULL DEFAULT 10,
	alwaysHumidity BIT Not NULL DEFAULT 0,
	humidityMin INT Not NULL DEFAULT 0,
	humidityMax INT Not NULL DEFAULT 10

go