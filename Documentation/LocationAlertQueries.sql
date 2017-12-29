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
