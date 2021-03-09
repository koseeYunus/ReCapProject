CREATE TABLE CarImages(
    Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    CarId int NOT NULL,
    ImagePath nvarchar(MAX),
    CarImageDate datetime,
    FOREIGN KEY (CarId) REFERENCES Cars(Id)
);

CREATE TABLE OperationClaims(
    Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Name varchar(250) NOT NULL,
);

CREATE TABLE UserOperationClaims(
    Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    UserId int NOT NULL,
    OperationClaimId int NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (OperationClaimId) REFERENCES OperationClaims(Id)
);