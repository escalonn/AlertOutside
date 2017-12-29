-- Schema Creation, Location Alert
Create Schema LA;

--**NOT RUN YET
-- Client Table Creation
Create Table LA.Client(
    ClientID int PRIMARY KEY,
	NameID int,
    Email nvarchar(50),
    PhoneNumber nvarchar(9),
	PasswordHash nvarchar(50),
	PasswordSalt nvarchar(20),
	PreferenceID int,
	DateModified DateTime
);

--**NOT RUN YET
-- Name Table Creation
Create Table LA.Name(
    NameID int PRIMARY KEY,
    FirstName nvarchar(50),
	MiddleInit nvarchar(2),
	LastName nvarchar(50),
);


--**NOT RUN YET
-- Region Table Creation
Create Table LA.Region(
    RegionID int PRIMARY KEY,
	ClientID int,
    RegionName nvarchar(50),
	Longitude Decimal(9,6),
	Latitude Decimal(8,6),
	Radius bigint,
	DatModified DateTime
);

--**NOT RUN YET
-- Alert Table Creation
Create Table LA.Alert(
    AlertID int PRIMARY KEY,
	ClientID int,
    AlertTypeID int,
	AlertMessage nvarchar(50),
	DatIssued DateTime
);

--**NOT RUN YET
-- SubAlert Table Creation
Create Table LA.SubAlert(
    SubAlertID int PRIMARY KEY,
	SubAlertType nvarchar(50),
    BaseAlertID int,
);

--**NOT RUN YET
-- BaseAlert Table Creation
Create Table LA.BaseAlert(
    BaseAlertID int PRIMARY KEY,
	BaseAlertType nvarchar(50),
);

--**NOT RUN YET
-- Preference Table Creation
Create Table LA.Preference(
    PreferenceID int PRIMARY KEY,
	WeatherPreferenceID int,
	TrafficPreferenceID int,
	NewsPreferenceID int,
	DatModified DateTime
);

--**NOT RUN YET
-- Weather Preference Table Creation
Create Table LA.WeatherPreference(
    WeatherPreferenceID int PRIMARY KEY,
);

--**NOT RUN YET
-- Traffic Preference Table Creation
Create Table LA.WeatherPreference(
    TrafficPreferenceID int PRIMARY KEY,
);

--**NOT RUN YET
-- News Preference Table Creation
Create Table LA.WeatherPreference(
    NewsPreferenceID int PRIMARY KEY,
);
