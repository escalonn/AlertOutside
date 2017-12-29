-- Schema Creation, Location Alert
Create Schema LA;

--**NOT RUN YET
-- Client Table Creation
Create Table LA.Client(
    ClientID int PRIMARY KEY,
	FirstName nvarchar(50),
	MiddleInit nvarchar(2),
	LastName nvarchar(50),
    Email nvarchar(50),
    PhoneNumber nvarchar(9),
	PasswordHash nvarchar(50),
	PasswordSalt nvarchar(20),
	PreferenceID int,
	DateModified DateTime
);

ALTER TABLE LA.Client
ADD FOREIGN KEY (PreferenceID) REFERENCES LA.Preference(PreferenceID);

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

ALTER TABLE LA.Region
ADD FOREIGN KEY (ClientID) REFERENCES LA.Client(ClientID);

--**NOT RUN YET
-- Alert Table Creation
Create Table LA.Alert(
    AlertID int PRIMARY KEY,
	ClientID int,
    AlertTypeID int,
	AlertMessage nvarchar(50),
	DatIssued DateTime
);

ALTER TABLE LA.Alert
ADD FOREIGN KEY (ClientID) REFERENCES LA.Client(ClientID);

--**NOT RUN YET
-- SubAlert Table Creation
Create Table LA.SubAlert(
    SubAlertID int PRIMARY KEY,
	SubAlertType nvarchar(50),
    BaseAlertID int,
);

ALTER TABLE LA.SubAlert
ADD FOREIGN KEY (BaseAlertID) REFERENCES LA.BaseAlert(BaseAlertID);

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

ALTER TABLE LA.WeatherPreference
ADD FOREIGN KEY (WeatherPreferenceID) REFERENCES LA.Preference(WeatherPreferenceID);

--**NOT RUN YET
-- Traffic Preference Table Creation
Create Table LA.TrafficPreference(
    TrafficPreferenceID int PRIMARY KEY,
);

ALTER TABLE LA.TrafficPreference
ADD FOREIGN KEY (TrafficPreferenceID) REFERENCES LA.Preference(TrafficPreferenceID);

--**NOT RUN YET
-- News Preference Table Creation
Create Table LA.NewsPreference(
    NewsPreferenceID int PRIMARY KEY,
);

ALTER TABLE LA.NewsPreference
ADD FOREIGN KEY (NewsPreferenceID) REFERENCES LA.Preference(NewsPreferenceID);


