USE [master]
GO

/****** Object:  Database [DBPensjon]    Script Date: 2012-09-16 15:31:41 ******/
CREATE DATABASE [DBPensjon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBPensjon', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DBPensjon.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBPensjon_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DBPensjon_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [DBPensjon] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBPensjon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DBPensjon] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DBPensjon] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DBPensjon] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DBPensjon] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DBPensjon] SET ARITHABORT OFF 
GO

ALTER DATABASE [DBPensjon] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [DBPensjon] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [DBPensjon] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DBPensjon] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DBPensjon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DBPensjon] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DBPensjon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DBPensjon] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DBPensjon] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DBPensjon] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DBPensjon] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DBPensjon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DBPensjon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DBPensjon] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DBPensjon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DBPensjon] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DBPensjon] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DBPensjon] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DBPensjon] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [DBPensjon] SET  MULTI_USER 
GO

ALTER DATABASE [DBPensjon] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DBPensjon] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DBPensjon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DBPensjon] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [DBPensjon] SET  READ_WRITE 
GO
