CREATE TABLE Course (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    HoleCount INT NOT NULL
);

INSERT INTO Course (Name, HoleCount)
VALUES 
    ('Hästhagen, Örebro', 18),
    ('Örnsköldsparken, Örebro', 9);