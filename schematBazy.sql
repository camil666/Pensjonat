USE [DBPensjon]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeServices]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Features]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Guests]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MealPlans]    Script Date: 2012-09-16 15:28:33 ******/
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
 CONSTRAINT [PK_MealType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 2012-09-16 15:28:33 ******/
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
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoomFeatures]    Script Date: 2012-09-16 15:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomFeatures](
	[RoomNumber] [int] NOT NULL,
	[FeatureId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomReservations]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomTypes]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Services]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceTypes]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 2012-09-16 15:28:33 ******/
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
	[TypeId] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaskTypes]    Script Date: 2012-09-16 15:28:33 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VisitMealPlans]    Script Date: 2012-09-16 15:28:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitMealPlans](
	[PlanId] [int] NOT NULL,
	[VisitId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Visits]    Script Date: 2012-09-16 15:28:33 ******/
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
 CONSTRAINT [PK_Visit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employee_role]  DEFAULT ((1)) FOR [RoleId]
GO
ALTER TABLE [dbo].[Guests] ADD  CONSTRAINT [DF_Guests_IsVerified]  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[Discounts]  WITH CHECK ADD  CONSTRAINT [FK_Discount_Guest] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guests] ([Id])
GO
ALTER TABLE [dbo].[Discounts] CHECK CONSTRAINT [FK_Discount_Guest]
GO
ALTER TABLE [dbo].[Employees]  WITH NOCHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[EmployeeServices]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeService_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeeServices] CHECK CONSTRAINT [FK_EmployeeService_Employee]
GO
ALTER TABLE [dbo].[EmployeeServices]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeService_ServiceType] FOREIGN KEY([Id])
REFERENCES [dbo].[ServiceTypes] ([Id])
GO
ALTER TABLE [dbo].[EmployeeServices] CHECK CONSTRAINT [FK_EmployeeService_ServiceType]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Guest] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guests] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservation_Guest]
GO
ALTER TABLE [dbo].[RoomFeatures]  WITH CHECK ADD  CONSTRAINT [FK_RoomFeature_Feature] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Features] ([Id])
GO
ALTER TABLE [dbo].[RoomFeatures] CHECK CONSTRAINT [FK_RoomFeature_Feature]
GO
ALTER TABLE [dbo].[RoomFeatures]  WITH CHECK ADD  CONSTRAINT [FK_RoomFeature_Room] FOREIGN KEY([RoomNumber])
REFERENCES [dbo].[Rooms] ([Number])
GO
ALTER TABLE [dbo].[RoomFeatures] CHECK CONSTRAINT [FK_RoomFeature_Room]
GO
ALTER TABLE [dbo].[RoomReservations]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Reservation] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservations] ([Id])
GO
ALTER TABLE [dbo].[RoomReservations] CHECK CONSTRAINT [FK_RoomReservation_Reservation]
GO
ALTER TABLE [dbo].[RoomReservations]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Number])
GO
ALTER TABLE [dbo].[RoomReservations] CHECK CONSTRAINT [FK_RoomReservation_Room]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[RoomTypes] ([Id])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Room_RoomType]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Service_ServiceType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ServiceTypes] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Service_ServiceType]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Service_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visits] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Service_Visit]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Task_Employee]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Task_TaskType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[TaskTypes] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Task_TaskType]
GO
ALTER TABLE [dbo].[VisitMealPlans]  WITH CHECK ADD  CONSTRAINT [FK_VisitMealPlan_MealPlan] FOREIGN KEY([PlanId])
REFERENCES [dbo].[MealPlans] ([Id])
GO
ALTER TABLE [dbo].[VisitMealPlans] CHECK CONSTRAINT [FK_VisitMealPlan_MealPlan]
GO
ALTER TABLE [dbo].[VisitMealPlans]  WITH CHECK ADD  CONSTRAINT [FK_VisitMealPlan_Visit] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visits] ([Id])
GO
ALTER TABLE [dbo].[VisitMealPlans] CHECK CONSTRAINT [FK_VisitMealPlan_Visit]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Guest] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guests] ([Id])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visit_Guest]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Number])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visit_Room]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Visit] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Visits] ([Id])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visit_Visit]
GO
