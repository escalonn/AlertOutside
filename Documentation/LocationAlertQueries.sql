USE [LocationAlertDB]
GO

ALTER TABLE LA.Preference DROP
	CONSTRAINT FK_Preference_WeatherPreference,
	CONSTRAINT FK_Preference_TrafficPreference,
	CONSTRAINT FK_Preference_NewsPreference;
GO
ALTER TABLE LA.SubAlert DROP CONSTRAINT FK_SubAlert_BaseAlert;
GO
ALTER TABLE LA.Alert DROP CONSTRAINT FK_Alert_Client;
GO
ALTER TABLE LA.Region DROP CONSTRAINT FK_Region_Client;
GO
ALTER TABLE LA.Client DROP CONSTRAINT FK_Client_Preference;
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
	ClientID INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50),
	MiddleInit NCHAR(1),
	LastName NVARCHAR(50),
	Email NVARCHAR(255) NOT NULL,
	PhoneNumber CHAR(10),
	PasswordHash CHAR(64),
	PasswordSalt NVARCHAR(20),
	PreferenceID INT NOT NULL,
	DateModified DATETIME2
)
GO

-- Region Table Creation
CREATE TABLE LA.Region(
	RegionID INT IDENTITY NOT NULL,
	ClientID INT,
	RegionName NVARCHAR(50),
	Longitude DECIMAL(9,6) NOT NULL,
	Latitude DECIMAL(8,6) NOT NULL,
	Radius BIGINT NOT NULL,
	DateModified DATETIME2
)
GO

-- Alert Table Creation
CREATE TABLE LA.Alert(
	AlertID INT IDENTITY NOT NULL,
	ClientID INT,
	AlertTypeID INT,
	AlertMessage NVARCHAR(512),
	DateIssued DATETIME2
)
GO

-- SubAlert Table Creation
CREATE TABLE LA.SubAlert(
	SubAlertID INT IDENTITY NOT NULL,
	SubAlertType NVARCHAR(50),
	BaseAlertID INT
)
GO

-- BaseAlert Table Creation
CREATE TABLE LA.BaseAlert(
	BaseAlertID INT IDENTITY NOT NULL,
	BaseAlertType NVARCHAR(50)
)
GO

-- Preference Table Creation
CREATE TABLE LA.Preference(
	PreferenceID INT IDENTITY NOT NULL,
	WeatherPreferenceID INT NOT NULL,
	TrafficPreferenceID INT,
	NewsPreferenceID INT,
	DateModified DATETIME2
)
GO

-- Weather Preference Table Creation
CREATE TABLE LA.WeatherPreference(
	WeatherPreferenceID INT IDENTITY NOT NULL,
	PushHours INT NOT NULL DEFAULT 1,
	PushMinutes INT NOT NULL DEFAULT 0,
	AlwaysTemp BIT NOT NULL DEFAULT 0,
	TempMin INT NOT NULL DEFAULT 0,
	TempMax INT NOT NULL DEFAULT 10,
	AlwaysRain BIT NOT NULL DEFAULT 0,
	RainMin INT NOT NULL DEFAULT 0,
	RainMax INT NOT NULL DEFAULT 10,
	AlwaysSnow BIT NOT NULL DEFAULT 0,
	SnowMin INT NOT NULL DEFAULT 0,
	SnowMax INT NOT NULL DEFAULT 10,
	AlwaysCloud BIT NOT NULL DEFAULT 0,
	CloudMin INT NOT NULL DEFAULT 0,
	CloudMax INT NOT NULL DEFAULT 10,
	AlwaysWind BIT NOT NULL DEFAULT 0,
	WindMin INT NOT NULL DEFAULT 0,
	WindMax INT NOT NULL DEFAULT 10,
	AlwaysHumidity BIT NOT NULL DEFAULT 0,
	HumidityMin INT NOT NULL DEFAULT 0,
	HumidityMax INT NOT NULL DEFAULT 10
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
ALTER TABLE LA.Client ADD
	CONSTRAINT PK_Client_ClientID PRIMARY KEY (ClientID)
GO
ALTER TABLE LA.Region ADD
	CONSTRAINT PK_Region_RegionID PRIMARY KEY (RegionID)
GO
ALTER TABLE LA.Alert ADD
	CONSTRAINT PK_Alert_AlertID PRIMARY KEY (AlertID)
GO
ALTER TABLE LA.SubAlert ADD
	CONSTRAINT PK_SubAlert_SubAlertID PRIMARY KEY (SubAlertID)
GO
ALTER TABLE LA.BaseAlert ADD
	CONSTRAINT PK_BaseAlert_BaseAlertID PRIMARY KEY (BaseAlertID)
GO
ALTER TABLE LA.Preference ADD
	CONSTRAINT PK_Preference_PreferenceID PRIMARY KEY (PreferenceID)
GO
ALTER TABLE LA.WeatherPreference ADD
	CONSTRAINT PK_WeatherPreference_WeatherPreferenceID PRIMARY KEY (WeatherPreferenceID)
GO
ALTER TABLE LA.TrafficPreference ADD
	CONSTRAINT PK_TrafficPreference_TrafficPreferenceID PRIMARY KEY (TrafficPreferenceID)
GO
ALTER TABLE LA.NewsPreference ADD
	CONSTRAINT PK_NewsPreference_NewsPreferenceID PRIMARY KEY (NewsPreferenceID)
GO

-- Foreign Key Creation
ALTER TABLE LA.Client ADD
	CONSTRAINT FK_Client_Preference FOREIGN KEY (PreferenceID) REFERENCES LA.Preference(PreferenceID)
GO
ALTER TABLE LA.Region ADD
	CONSTRAINT FK_Region_Client FOREIGN KEY (ClientID) REFERENCES LA.Client(ClientID) on update cascade
GO
ALTER TABLE LA.Alert ADD
	CONSTRAINT FK_Alert_Client FOREIGN KEY (ClientID) REFERENCES LA.Client(ClientID)
GO
ALTER TABLE LA.SubAlert ADD
	CONSTRAINT FK_SubAlert_BaseAlert FOREIGN KEY (BaseAlertID) REFERENCES LA.BaseAlert(BaseAlertID)
GO
ALTER TABLE LA.Preference ADD
	CONSTRAINT FK_Preference_WeatherPreference FOREIGN KEY (WeatherPreferenceID) REFERENCES LA.WeatherPreference(WeatherPreferenceID),
	CONSTRAINT FK_Preference_TrafficPreference FOREIGN KEY (TrafficPreferenceID) REFERENCES LA.TrafficPreference(TrafficPreferenceID),
	CONSTRAINT FK_Preference_NewsPreference FOREIGN KEY (NewsPreferenceID) REFERENCES LA.NewsPreference(NewsPreferenceID)
GO
