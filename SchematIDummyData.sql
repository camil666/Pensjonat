USE [master]
GO
/****** Object:  Database [DBPensjon]    Script Date: 09/23/2012 21:40:07 ******/
CREATE DATABASE [DBPensjon] ON  PRIMARY 
( NAME = N'DBPensjon', FILENAME = N'd:\SqlServer\x64\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DBPensjon.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBPensjon_log', FILENAME = N'd:\SqlServer\x64\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DBPensjon_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [DBPensjon] SET  ENABLE_BROKER
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
ALTER DATABASE [DBPensjon] SET  READ_WRITE
GO
ALTER DATABASE [DBPensjon] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DBPensjon] SET  MULTI_USER
GO
ALTER DATABASE [DBPensjon] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DBPensjon] SET DB_CHAINING OFF
GO
USE [DBPensjon]
GO
/****** Object:  Table [dbo].[TaskTypes]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaskTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_TaskType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MealPrices]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealPrices](
	[BreakfastPrice] [float] NOT NULL,
	[LunchPrice] [float] NOT NULL,
	[DinnerPrice] [float] NOT NULL,
	[ThreeMealsPrice] [float] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MealPrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealPlans]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MealPlans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleCount] [int] NOT NULL,
	[Breakfast] [bit] NOT NULL,
	[Lunch] [bit] NOT NULL,
	[Dinner] [bit] NOT NULL,
	[Vegetarian] [bit] NOT NULL,
	[Diet] [bit] NOT NULL,
	[ToRoom] [bit] NOT NULL,
	[AdditionalInfo] [varchar](50) NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_MealType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Guests]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Guests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[Street] [varchar](20) NOT NULL,
	[PostCode] [varchar](10) NOT NULL,
	[ApartmentNumber] [varchar](4) NOT NULL,
	[HouseNumber] [varchar](4) NOT NULL,
	[Town] [varchar](20) NOT NULL,
	[TelephoneNumber] [varchar](15) NOT NULL,
	[CountryId] [varchar](3) NOT NULL,
	[IdNumber] [varchar](20) NULL,
	[CompanyName] [varchar](50) NULL,
	[Email] [varchar](30) NULL,
	[IsVerified] [bit] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Features]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Features](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[Name] [varchar](50) NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceTypes]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Charge] [float] NULL,
 CONSTRAINT [PK_ServiceType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoomTypes]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [float] NOT NULL,
	[PricePerPerson] [float] NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Number] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[Vacancy] [bit] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuestId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[AdditionalInfo] [varchar](50) NULL,
	[IsVisit] [bit] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[TelephoneNumber] [varchar](15) NOT NULL,
	[Street] [varchar](20) NOT NULL,
	[PostCode] [varchar](10) NOT NULL,
	[ApartmentNumber] [varchar](4) NOT NULL,
	[HouseNumber] [varchar](4) NOT NULL,
	[Town] [varchar](20) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Password] [varchar](40) NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GuestId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Description] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsDone] [bit] NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeServices]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeServices](
	[Id] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomReservations]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomReservations](
	[ReservationId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RoomReservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomFeatures]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomFeatures](
	[RoomNumber] [int] NOT NULL,
	[FeatureId] [int] NOT NULL,
 CONSTRAINT [PK_RoomFeatures] PRIMARY KEY CLUSTERED 
(
	[RoomNumber] ASC,
	[FeatureId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Visits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[GuestId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[AdditionalInfo] [varchar](50) NULL,
	[Advance] [float] NULL,
	[Settled] [bit] NOT NULL,
 CONSTRAINT [PK_Visit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VisitMealPlans]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitMealPlans](
	[PlanId] [int] NOT NULL,
	[VisitId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_VisitMealPlans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 09/23/2012 21:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VisitId] [int] NOT NULL,
	[TypeId] [int] NULL,
	[Quantity] [bigint] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[AdditionalInfo] [varchar](50) NULL,
	[CustomName] [varchar](50) NULL,
	[CustomDescription] [varchar](50) NULL,
	[CustomCharge] [float] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Guests_IsVerified]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Guests] ADD  CONSTRAINT [DF_Guests_IsVerified]  DEFAULT ((0)) FOR [IsVerified]
GO
/****** Object:  Default [DF_Employee_role]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employee_role]  DEFAULT ((1)) FOR [RoleId]
GO
/****** Object:  ForeignKey [FK_Room_RoomType]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[RoomTypes] ([Id])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Room_RoomType]
GO
/****** Object:  ForeignKey [FK_Reservation_Guest]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Guest] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guests] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservation_Guest]
GO
/****** Object:  ForeignKey [FK_Employee_Role]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Employees]  WITH NOCHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employee_Role]
GO
/****** Object:  ForeignKey [FK_Discount_Guest]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Discounts]  WITH CHECK ADD  CONSTRAINT [FK_Discount_Guest] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guests] ([Id])
GO
ALTER TABLE [dbo].[Discounts] CHECK CONSTRAINT [FK_Discount_Guest]
GO
/****** Object:  ForeignKey [FK_Task_Employee]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Task_Employee]
GO
/****** Object:  ForeignKey [FK_Task_TaskType]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[TaskTypes] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Task_TaskType]
GO
/****** Object:  ForeignKey [FK_EmployeeService_Employee]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[EmployeeServices]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeService_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeeServices] CHECK CONSTRAINT [FK_EmployeeService_Employee]
GO
/****** Object:  ForeignKey [FK_EmployeeService_ServiceType]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[EmployeeServices]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeService_ServiceType] FOREIGN KEY([Id])
REFERENCES [dbo].[ServiceTypes] ([Id])
GO
ALTER TABLE [dbo].[EmployeeServices] CHECK CONSTRAINT [FK_EmployeeService_ServiceType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Reservation]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[RoomReservations]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservations] ([Id])
GO
ALTER TABLE [dbo].[RoomReservations] CHECK CONSTRAINT [FK_RoomReservation_Reservation]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Room]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[RoomReservations]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Number])
GO
ALTER TABLE [dbo].[RoomReservations] CHECK CONSTRAINT [FK_RoomReservation_Room]
GO
/****** Object:  ForeignKey [FK_RoomFeature_Feature]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[RoomFeatures]  WITH CHECK ADD  CONSTRAINT [FK_RoomFeature_Feature] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Features] ([Id])
GO
ALTER TABLE [dbo].[RoomFeatures] CHECK CONSTRAINT [FK_RoomFeature_Feature]
GO
/****** Object:  ForeignKey [FK_RoomFeature_Room]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[RoomFeatures]  WITH CHECK ADD  CONSTRAINT [FK_RoomFeature_Room] FOREIGN KEY([RoomNumber])
REFERENCES [dbo].[Rooms] ([Number])
GO
ALTER TABLE [dbo].[RoomFeatures] CHECK CONSTRAINT [FK_RoomFeature_Room]
GO
/****** Object:  ForeignKey [FK_Visit_Guest]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Guest] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guests] ([Id])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visit_Guest]
GO
/****** Object:  ForeignKey [FK_Visit_Room]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Number])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visit_Room]
GO
/****** Object:  ForeignKey [FK_Visit_Visit]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Visit] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Visits] ([Id])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visit_Visit]
GO
/****** Object:  ForeignKey [FK_VisitMealPlan_MealPlan]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[VisitMealPlans]  WITH CHECK ADD  CONSTRAINT [FK_VisitMealPlan_MealPlan] FOREIGN KEY([PlanId])
REFERENCES [dbo].[MealPlans] ([Id])
GO
ALTER TABLE [dbo].[VisitMealPlans] CHECK CONSTRAINT [FK_VisitMealPlan_MealPlan]
GO
/****** Object:  ForeignKey [FK_VisitMealPlan_Visit]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[VisitMealPlans]  WITH CHECK ADD  CONSTRAINT [FK_VisitMealPlan_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visits] ([Id])
GO
ALTER TABLE [dbo].[VisitMealPlans] CHECK CONSTRAINT [FK_VisitMealPlan_Visit]
GO
/****** Object:  ForeignKey [FK_Service_ServiceType]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Service_ServiceType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ServiceTypes] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Service_ServiceType]
GO
/****** Object:  ForeignKey [FK_Service_Visit]    Script Date: 09/23/2012 21:40:10 ******/
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Service_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visits] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Service_Visit]
GO

insert into [dbo].[MealPrices] (BreakfastPrice, LunchPrice, DinnerPrice, ThreeMealsPrice) values (30,40,50,100)

Insert into Dbo.Roles (Id, Name) Values (0, 'Administrator')
Insert into Dbo.Roles (Id, Name) Values (1, 'Receptionist')
Insert into Dbo.Roles (Id, Name) Values (2, 'Manager')
Insert into Dbo.Roles (Id, Name) Values (3, 'Employee')
Insert into Dbo.Roles (Id, Name) Values (4, 'Root')

Insert into dbo.Employees 
	(Username, 
	FirstName, 
	LastName, 
	TelephoneNumber, 
	Street, 
	PostCode, 
	ApartmentNumber, 
	HouseNumber, 
	Town, 
	Email, 
	Password, 
	RoleId)
Values ('root', 
'root','root', '782600660', 'Akademicka', '44-100', '16', 'b', 'Gliwice', 'root@pensjonat.pl', 'w', 4 )

Insert into dbo.Employees 
	(Username, 
	FirstName, 
	LastName, 
	TelephoneNumber, 
	Street, 
	PostCode, 
	ApartmentNumber, 
	HouseNumber, 
	Town, 
	Email, 
	Password, 
	RoleId)
Values ('Administrator', 
'Jan','Kowalski', '782600660', 'Akademicka', '44-100', '16', 'b', 'Gliwice', 'admin@pensjonat.pl', 'w', 0 )
Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Administrator2', 'Jan','Nowak', '782666666', 'Akademicka', '44-100', '16', 'b', 'Gliwice', 'admin2@pensjonat.pl', 'w', 0 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Pracownik', 'Joanna','Nowak', '782555555', 'Portowa', '44-100', '20', '4', '¯ory', 'pracownik@pensjonat.pl', 'w', 3 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Pracownik2', 'Anna','Nowak', '782555555', 'Alpejska', '44-100', '20', '4', 'Rybnik', 'pracownik2@pensjonat.pl', 'w', 3 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Pracownik3', 'Andrzej','Nowak', '782555555', 'Ma³opolska', '44-100', '20', '4', '¯ory', 'pracownik3@pensjonat.pl', 'w', 3 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Pracownik4', 'Krzysztof','Nowak', '782555555', 'Portowa', '44-100', '20', '4', 'Rudy', 'pracownik4@pensjonat.pl', 'w', 3 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Pracownik5', 'Antoni','Nowak', '782555555', 'Portowa', '44-100', '20', '4', 'Jastrzêbie', 'pracownik5@pensjonat.pl', 'w', 3 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Manager', 'Kamil','Nowak', '782555555', 'Portowa', '44-100', '20', '4', '¯ory', 'manager@pensjonat.pl', 'w', 2 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Manager2', 'Marcin','Nowak', '782555555', 'Alpejska', '44-100', '20', '4', 'Rybnik', 'manager2@pensjonat.pl', 'w', 2 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Recepcjonista', 'Kamil','Nowakowski', '782555555', 'Portowa', '44-100', '20', '4', '¯ory', 'recepcjonista@pensjonat.pl', 'w', 1 )

Insert into dbo.Employees (Username, FirstName, LastName, TelephoneNumber, Street, PostCode, ApartmentNumber, HouseNumber, Town, Email, Password, RoleId)
Values ('Recepcjonista2', 'Dawid','Nowak', '782555555', 'Alpejska', '44-100', '20', '4', 'Rybnik', 'recepcjonista2@pensjonat.pl', 'w', 1 )
-- ROOM TYPES
Insert into dbo.RoomTypes (Description, Name, Price, PricePerPerson)
Values ('opis opis opis opis opis opis ','Ma³y i wygodny','50', '25')

Insert into dbo.RoomTypes (Description, Name, Price, PricePerPerson)
Values ('opis opis opis opis opis opis ','Ma³y i niewygodny','30', '20')

Insert into dbo.RoomTypes (Description, Name, Price, PricePerPerson)
Values ('opis opis opis opis opis opis ','Œredni i wygodny','200', '135')

Insert into dbo.RoomTypes (Description, Name, Price, PricePerPerson)
Values ('opis opis opis opis opis opis ','Œredni i niewygodny','150', '100')

Insert into dbo.RoomTypes (Description, Name, Price, PricePerPerson)
Values ('opis opis opis opis opis opis ','Du¿y i wygodny','300', '180')

Insert into dbo.RoomTypes (Description, Name, Price, PricePerPerson)
Values ('opis opis opis opis opis opis ','Du¿y i niewygodny','200', '150')


--ROOM FEATURES

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Telewizor 14 cali')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Telewizor 21 cali')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Telewizor 28 cali')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Telewizor 32 cali')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Telewizor 37 cali')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Telewizor 42 cali')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Telewizor 47 cali')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Telewizor 52 cali')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Blueray')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Dvd')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Prysznic')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Wanna')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Jaccuzzi')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Wodne £ó¿ka')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Ma³¿eñskie £ó¿ka')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Pojedyñcze £ó¿ka')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Zas³ony')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Rolety')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Dywan')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Panele')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Obrazy na œcianach')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Stó³ okr¹g³y 4os')

Insert into dbo.Features (Description, Name)
Values ('opis opis opis opis opis opis ','Stó³ bankietowy 10os')

--Rooms

INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (1, 1, 4, 0, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (101, 1, 2, 1, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (102, 2, 2, 1, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (103, 5, 6, 1, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (201, 3, 5, 2, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (202, 4, 4, 2, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (301, 6, 10, 3, 0)


--Room Features

INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (1, 1)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (1, 11)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (1, 16)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (1, 19)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 1)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 2)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 11)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 12)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 18)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 19)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 20)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 21)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (101, 22)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (102, 1)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (102, 16)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (102, 17)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (102, 19)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 7)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 8)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 9)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 10)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 11)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 12)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 13)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 14)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 15)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 17)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 18)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 19)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 20)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 21)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (103, 23)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 4)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 5)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 6)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 10)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 11)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 12)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 15)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 16)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 17)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 20)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 21)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 22)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 2)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 10)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 11)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 12)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 15)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 16)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 19)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 21)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 22)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (301, 1)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (301, 2)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (301, 10)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (301, 12)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (301, 16)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (301, 19)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (301, 23)

--tasks types

insert into TaskTypes (Description, Name) Values ('opis opis opis opis opis','Sprz¹tanie')
insert into TaskTypes (Description, Name) Values ('opis opis opis opis opis','Mycie')
insert into TaskTypes (Description, Name) Values ('opis opis opis opis opis','Odkurzanie')
insert into TaskTypes (Description, Name) Values ('opis opis opis opis opis','Pranie')
insert into TaskTypes (Description, Name) Values ('opis opis opis opis opis','Wycieranie kurzy')
insert into TaskTypes (Description, Name) Values ('opis opis opis opis opis','Zamiatanie')
insert into TaskTypes (Description, Name) Values ('opis opis opis opis opis','Mycie naczyñ')

-- guests

INSERT INTO [DBPensjon].[dbo].[Guests]
           ([FirstName]
           ,[LastName]
           ,[Street]
           ,[PostCode]
           ,[ApartmentNumber]
           ,[HouseNumber]
           ,[Town]
           ,[TelephoneNumber]
           ,[CountryId]
           ,[IdNumber]
           ,[CompanyName]
           ,[Email]
           ,[IsVerified])
     VALUES
           ('Marcin'
           ,'Koba'
           ,'Zielona'
           ,'44-100'
           ,'5'
           ,'12'
           ,'Gliwice'
           ,'123456789'
           ,'48'
           ,'20491042104'
           ,'polsl'
           ,'marcin@polsl.pl',
           0)


INSERT INTO [DBPensjon].[dbo].[Guests]
           ([FirstName]
           ,[LastName]
           ,[Street]
           ,[PostCode]
           ,[ApartmentNumber]
           ,[HouseNumber]
           ,[Town]
           ,[TelephoneNumber]
           ,[CountryId]
           ,[IdNumber]
           ,[CompanyName]
           ,[Email]
           ,[IsVerified])
     VALUES
           ('Andrzej'
           ,'Kowalski'
           ,'Zielona'
           ,'44-100'
           ,'5'
           ,'12'
           ,'Gliwice'
           ,'123456789'
           ,'48'
           ,'20491042104'
           ,'polsl'
           ,'Andrzej@polsl.pl',
           0)

INSERT INTO [DBPensjon].[dbo].[Guests]
           ([FirstName]
           ,[LastName]
           ,[Street]
           ,[PostCode]
           ,[ApartmentNumber]
           ,[HouseNumber]
           ,[Town]
           ,[TelephoneNumber]
           ,[CountryId]
           ,[IdNumber]
           ,[CompanyName]
           ,[Email]
           ,[IsVerified])
     VALUES
           ('Jacek'
           ,'Kowalski'
           ,'Zielona'
           ,'44-100'
           ,'5'
           ,'12'
           ,'Gliwice'
           ,'123456789'
           ,'48'
           ,'20491042104'
           ,'polsl'
           ,'jacek@polsl.pl',
           0)

INSERT INTO [DBPensjon].[dbo].[Guests]
           ([FirstName]
           ,[LastName]
           ,[Street]
           ,[PostCode]
           ,[ApartmentNumber]
           ,[HouseNumber]
           ,[Town]
           ,[TelephoneNumber]
           ,[CountryId]
           ,[IdNumber]
           ,[CompanyName]
           ,[Email]
           ,[IsVerified])
     VALUES
           ('B³a¿ej'
           ,'Kowalski'
           ,'Zielona'
           ,'44-100'
           ,'5'
           ,'12'
           ,'Gliwice'
           ,'123456789'
           ,'48'
           ,'20491042104'
           ,'polsl'
           ,'blazej@polsl.pl',
           0)








INSERT INTO [DBPensjon].[dbo].[Guests]
           ([FirstName]
           ,[LastName]
           ,[Street]
           ,[PostCode]
           ,[ApartmentNumber]
           ,[HouseNumber]
           ,[Town]
           ,[TelephoneNumber]
           ,[CountryId]
           ,[IdNumber]
           ,[CompanyName]
           ,[Email]
           ,[IsVerified])
     VALUES
           ('Anna'
           ,'Dyzma'
           ,'Zielona'
           ,'44-100'
           ,'5'
           ,'12'
           ,'Gliwice'
           ,'123456789'
           ,'48'
           ,'20491042104'
           ,'uœ'
           ,'anna@us.pl',
           0)



INSERT INTO [DBPensjon].[dbo].[Guests]
           ([FirstName]
           ,[LastName]
           ,[Street]
           ,[PostCode]
           ,[ApartmentNumber]
           ,[HouseNumber]
           ,[Town]
           ,[TelephoneNumber]
           ,[CountryId]
           ,[IdNumber]
           ,[CompanyName]
           ,[Email]
           ,[IsVerified])
     VALUES
           ('Nikodem'
           ,'Dyzma'
           ,'Zielona'
           ,'44-100'
           ,'5'
           ,'12'
           ,'Gliwice'
           ,'123456789'
           ,'48'
           ,'20491042104'
           ,'uœ'
           ,'nikodem@us.pl',
           0)
           
-- service types
insert into ServiceTypes (Name, Description, Charge) values ('Masa¿','opis', 400)
insert into ServiceTypes (Name, Description, Charge) values ('Budzenie','opis', 30)
insert into ServiceTypes (Name, Description, Charge) values ('Sprzeda¿ biletów','opis', 30)
insert into ServiceTypes (Name, Description, Charge) values ('Opieka nad dzieæmi','opis', 300)
insert into ServiceTypes (Name, Description, Charge) values ('Zamawianie taksówek','opis', 15)
           