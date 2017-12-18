# WebAPI
This is simple Web Api using ADO.NET

Tables and stored procs in DB:

-----
USE [LibraryDB]
GO

/****** Object:  Table [dbo].[Authors]    Script Date: 18.12.2017 12:43:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Authors](
	[Id] [uniqueidentifier] NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Genre] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-----

USE [LibraryDB]
GO

/****** Object:  StoredProcedure [dbo].[spAddAuthor]    Script Date: 18.12.2017 12:44:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spAddAuthor]
@authorId uniqueidentifier,
@firstName nvarchar(50),
@lastName nvarchar(50),
@genre nvarchar(50),
@dateOfBirth datetime
AS

BEGIN
	INSERT INTO Authors	(Id, DateOfBirth, FirstName, Genre, LastName)
	VALUES	(@authorId, @dateOfBirth, @firstName, @genre, @lastName)
END
GO

---

USE [LibraryDB]
GO

/****** Object:  StoredProcedure [dbo].[spDeleteAuthor]    Script Date: 18.12.2017 12:45:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spDeleteAuthor]
@authorId uniqueidentifier

AS

BEGIN
	DELETE FROM Authors WHERE Id=@authorId
END
GO

---

USE [LibraryDB]
GO

/****** Object:  StoredProcedure [dbo].[spGetAuthor]    Script Date: 18.12.2017 12:45:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spGetAuthor]
(
	@authorId uniqueidentifier
)
AS

SET NOCOUNT ON

BEGIN
	SELECT * FROM Authors WHERE Id=@authorId	
END
GO

---

USE [LibraryDB]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateAuthor]    Script Date: 18.12.2017 12:46:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spUpdateAuthor]
@authorId uniqueidentifier,
@firstName nvarchar(50),
@lastName nvarchar(50),
@genre nvarchar(50),
@dateOfBirth datetime
AS

BEGIN
	UPDATE Authors
	SET FirstName=@firstName,
	LastName=@lastName,
	Genre=@genre,
	DateOfBirth=@dateOfBirth

	WHERE Id=@authorId
END
GO
