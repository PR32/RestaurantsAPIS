USE [master]
GO
/****** Object:  Database [RestaurantsAPI]    Script Date: 27-07-2022 16:34:16 ******/
CREATE DATABASE [RestaurantsAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RestaurantsAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RestaurantsAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RestaurantsAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RestaurantsAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RestaurantsAPI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantsAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantsAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestaurantsAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestaurantsAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RestaurantsAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestaurantsAPI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET RECOVERY FULL 
GO
ALTER DATABASE [RestaurantsAPI] SET  MULTI_USER 
GO
ALTER DATABASE [RestaurantsAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestaurantsAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RestaurantsAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RestaurantsAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RestaurantsAPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RestaurantsAPI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RestaurantsAPI', N'ON'
GO
ALTER DATABASE [RestaurantsAPI] SET QUERY_STORE = OFF
GO
USE [RestaurantsAPI]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](max) NULL,
	[Department] [nvarchar](max) NULL,
	[DateOfJoining] [nvarchar](max) NULL,
	[PhotoFileName] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurants]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurants](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[rating] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddDepartment]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddDepartment]  @Name nvarchar(max)
AS
BEGIN
	INSERT INTO Department 
	(DepartmentName)
	VALUES( @Name)

	select * from Department
END
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddEmployee]  
@Name nvarchar(max),
@DateOfJoining nvarchar(MAX),
@Department nvarchar(MAX),
@PhotoFileName nvarchar(max)
AS
BEGIN
	INSERT INTO Employee 
	(EmployeeName,DateOfJoining,PhotoFileName,Department)
	VALUES( @Name,@DateOfJoining,@PhotoFileName,@Department)

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDepartment]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeleteDepartment] 
@id int
AS
BEGIN
	Delete from Department where DepartmentId=@id

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeleteEmployee] 
@id int
AS
BEGIN
	Delete from Employee where EmployeeId=@id

END
GO
/****** Object:  StoredProcedure [dbo].[GetDepartment]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[GetDepartment]
AS
BEGIN
	SET NOCOUNT ON;

	select * from Department
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployee]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[GetEmployee]
AS
BEGIN
	SET NOCOUNT ON;

	select * from Employee
END
GO
/****** Object:  StoredProcedure [dbo].[GetRestaurants]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRestaurants]
AS
BEGIN
	SET NOCOUNT ON;

	select * from Restaurants
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDepartment]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[UpdateDepartment]  
@Id int,
@Name nvarchar(max)
AS
BEGIN
update Department set DepartmentName=@Name where DepartmentId=@Id

	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 27-07-2022 16:34:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployee]  
@EmployeeId int,
@Name nvarchar(max),
@DateOfJoining nvarchar(MAX),
@PhotoFileName nvarchar(max),
@Department nvarchar(max)
AS
BEGIN
update Employee set EmployeeName=@Name, DateOfJoining=@DateOfJoining ,
PhotoFileName=@PhotoFileName ,Department=@Department
where EmployeeId=@EmployeeId
END
GO
USE [master]
GO
ALTER DATABASE [RestaurantsAPI] SET  READ_WRITE 
GO
