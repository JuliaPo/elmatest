﻿CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [X] INT NOT NULL, 
    [Operation] NVARCHAR(50) NOT NULL, 
    [Y] INT NOT NULL, 
    [Result] FLOAT NOT NULL
)
