CREATE DATABASE IF NOT EXISTS ProductsAPI;
USE ProductsAPI;


CREATE TABLE IF NOT EXISTS Roles ( 
	Id VARCHAR(20) PRIMARY KEY,
    Name TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Users (
	Id CHAR(36) PRIMARY KEY,
    Username TEXT NOT NULL, 
    FullName TEXT NOT NULL,
    Email TEXT NOT NULL,
    Password TEXT NOT NULL,
    DateOfBirth DATE NOT NULL,
	RoleId CHAR(36) NOT NULL DEFAULT 'Normal-User',
    FOREIGN KEY(RoleId) REFERENCES Roles(Id)
);

CREATE TABLE IF NOT EXISTS Products (
	Id CHAR(36) PRIMARY KEY,
    Name TEXT NOT NULL,
    Description TEXT NOT NULL,
    Stock INT NOT NULL,
    Price DECIMAL(8,4) NOT NULL,
    PictureUrl TEXT NOT NULL,
    InsertTimeStamp DATETIME DEFAULT NOW(),
    UserId CHAR(36) NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT CHK_PRODS CHECK (Stock > 0 AND Price > 0)
);


INSERT INTO Roles VALUES ('ADMIN-USER', 'Admin');
INSERT INTO Roles VALUES ('NORMAL-USER',  'Normal');

DROP PROCEDURE IF EXISTS sp_get_products_by_user;

DELIMITER $$
CREATE PROCEDURE sp_get_products_by_user 
(
_userId CHAR(36)
)
BEGIN
SELECT p.Id,
p.Name,
p.Description,
p.Stock,
p.Price,
p.PictureUrl
FROM (SELECT * FROM Products WHERE UserId = _userId) p
JOIN Users u
ON u.Id = p.UserId;
END$$
DELIMITER ;sp_insert_usersp_insert_user