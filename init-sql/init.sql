
CREATE DATABASE LoginDb;
GO
USE LoginDb;
GO
CREATE TABLE Logins (
    Id INT PRIMARY KEY IDENTITY,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    IsLoggedIn BIT NOT NULL DEFAULT 0
);
GO
INSERT INTO Logins (Email, Password, IsLoggedIn) VALUES
('admin@example.com', 'adminpass', 0),
('user1@example.com', 'userpass', 1);
GO
