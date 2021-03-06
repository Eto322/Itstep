USE [master]
GO
/****** Object:  Database [PROJECT_SCHOOL]    Script Date: 2/6/2022 1:30:51 PM ******/
CREATE DATABASE [PROJECT_SCHOOL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PROJECT_SCHOOL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PROJECT_SCHOOL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PROJECT_SCHOOL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PROJECT_SCHOOL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PROJECT_SCHOOL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PROJECT_SCHOOL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PROJECT_SCHOOL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET ARITHABORT OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET RECOVERY FULL 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET  MULTI_USER 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PROJECT_SCHOOL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PROJECT_SCHOOL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PROJECT_SCHOOL', N'ON'
GO
ALTER DATABASE [PROJECT_SCHOOL] SET QUERY_STORE = OFF
GO
USE [PROJECT_SCHOOL]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLASS]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLASS](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[SpecializationID] [int] NOT NULL,
	[ClassNumber] [int] NOT NULL,
	[ClasLetter] [nvarchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassroomTeacher]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassroomTeacher](
	[TeacherID] [int] NOT NULL,
	[ClassID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[MarkID] [int] IDENTITY(1,1) NOT NULL,
	[MarkDate] [date] NOT NULL,
	[Value] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MarkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarkSubjectStudent]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarkSubjectStudent](
	[StudentID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[MarkID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewStudent]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewStudent](
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[SecondName] [nvarchar](100) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[StartDate] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[SalaryID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[SpecializationID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[FullDescription] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SpecializationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[SalaryID] [int] NOT NULL,
	[PositionID] [int] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[SecondName] [nvarchar](100) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[StartWorkDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffPosition]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffPosition](
	[PositionID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[SecondName] [nvarchar](100) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[StartDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NOT NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubject](
	[TeacherID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CLASS]  WITH CHECK ADD FOREIGN KEY([SpecializationID])
REFERENCES [dbo].[Specialization] ([SpecializationID])
GO
ALTER TABLE [dbo].[ClassroomTeacher]  WITH CHECK ADD FOREIGN KEY([ClassID])
REFERENCES [dbo].[CLASS] ([ClassID])
GO
ALTER TABLE [dbo].[ClassroomTeacher]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[MarkSubjectStudent]  WITH CHECK ADD FOREIGN KEY([MarkID])
REFERENCES [dbo].[Mark] ([MarkID])
GO
ALTER TABLE [dbo].[MarkSubjectStudent]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[MarkSubjectStudent]  WITH CHECK ADD FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[NewStudent]  WITH CHECK ADD FOREIGN KEY([ClassID])
REFERENCES [dbo].[CLASS] ([ClassID])
GO
ALTER TABLE [dbo].[NewStudent]  WITH CHECK ADD FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([PositionID])
REFERENCES [dbo].[StaffPosition] ([PositionID])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([SalaryID])
REFERENCES [dbo].[Salary] ([SalaryID])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([ClassID])
REFERENCES [dbo].[CLASS] ([ClassID])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[CLASS]  WITH CHECK ADD CHECK  (([ClassNumber]>=(1) AND [ClassNumber]<=(11) AND NOT [ClasLetter] like '%[^A-Z]%'))
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD CHECK  (([VALUE]>=(1) AND [VALUE]<=(12)))
GO
/****** Object:  StoredProcedure [dbo].[ChangeDirector]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ChangeDirector] 
           @NWDirectorID int
AS 
BEGIN

IF (SELECT PositionID
       FROM Staff
	   WHERE StaffID=@NWDirectorID
	   )!=3
  BEGIN   
	   PRINT 'ERROR: SELECTED MEMBER NOT TEACHER'
	   RETURN(-1)
  END
ELSE
Declare @oldDirectorID int--если мы меняем директора то , старый директор становиться учитилем и становиться на временую замену предметов которые вел новый директор
Declare @oldDirectorTeacherID int
Declare @newDirectorTeacherID int
DECLARE @OldSalary int
Declare @NewSalary int -- для изменения зарплаты
BEGIN
  SET  @oldDirectorID =--Нашли ид роботника директора старого
  (SELECT StaffID
   FROM Staff
   WHERE PositionID=1)

    SET @oldDirectorTeacherID=--Нашли тичер айди старого директора
    (SELECT TeacherID
     FROM Teacher
	 WHERE StaffID=@oldDirectorID)

	 SET @newDirectorTeacherID=--нашли ид роботника нового директора
	 (SELECT TeacherID
	  FROM Teacher
	  WHERE StaffID=@NWDirectorID)

	  UPDATE TeacherSubject --поменяли предметы которые вел новый на старого директора
	   SET TeacherID=@oldDirectorTeacherID
	    WHERE TeacherID=@newDirectorTeacherID


	   UPDATE ClassroomTeacher --- поменяли классы если такие были
	    SET TeacherID=@oldDirectorTeacherID
	     WHERE TeacherID=@newDirectorTeacherID

   --МЕНЯЕМ ЗАРПЛАТЫ
	    SET @OldSalary=
		  (SELECT SalaryID
			 FROM Staff
			  WHERE PositionID=1)

		 SET @NewSalary=
		  (SELECT SalaryID
		    FROM Staff
			 WHERE StaffID=@NWDirectorID)

	       UPDATE Staff
	        SET SalaryID=@OldSalary-- 
	         WHERE StaffID=@NWDirectorID

	         UPDATE Staff
	          SET SalaryID=@NewSalary
	           WHERE PositionID=1;

                 UPDATE Staff --понизили старого директора до учителя
                   SET PositionID=3
                    WHERE PositionID=1;

                    UPDATE Staff--повысили 
                     SET PositionID=1
                      WHERE StaffID=@NWDirectorID
   RETURN(1)
   END
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteNewStudent]    Script Date: 2/6/2022 1:30:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteNewStudent]
AS 
BEGIN
  DELETE FROM NewStudent
  WHERE StartDate < DATEADD(MONTH, -3, GETDATE())--прикольную функцию нашел, с помощью нее можно нормально отнять месяца
END
GO
USE [master]
GO
ALTER DATABASE [PROJECT_SCHOOL] SET  READ_WRITE 
GO
