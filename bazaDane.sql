USE [DBPensjon]
GO
SET IDENTITY_INSERT [dbo].[RoomTypes] ON 

INSERT [dbo].[RoomTypes] ([Id], [Price], [PricePerPerson], [Name], [Description]) VALUES (2, 100, 50, N'Wygodny', N'fajny pokoik')
INSERT [dbo].[RoomTypes] ([Id], [Price], [PricePerPerson], [Name], [Description]) VALUES (6, 1001, 3, N'Niewygodny', N'taki niewygodny')
INSERT [dbo].[RoomTypes] ([Id], [Price], [PricePerPerson], [Name], [Description]) VALUES (7, 120, 30, N'Wygodny', N'ciekawy pokój')
SET IDENTITY_INSERT [dbo].[RoomTypes] OFF
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (201, 2, 3, 1, 1)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (202, 6, 5, 2, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (204, 2, 4, 4, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (206, 6, 4, 2, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (234, 2, 2, 2, 1)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (235, 2, 4, 2, 0)
INSERT [dbo].[Rooms] ([Number], [TypeId], [Capacity], [Floor], [Vacancy]) VALUES (432, 2, 2, 4, 0)
SET IDENTITY_INSERT [dbo].[Guests] ON 

INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Street], [PostCode], [ApartmentNumber], [HouseNumber], [Town], [TelephoneNumber], [CountryId], [IdNumber], [CompanyName], [Email], [IsVerified]) VALUES (6, N'Marcin', N'Koba', N'Małopolska', N'44-335', N'4', N'19', N'Jastrzebie', N'505797135', N'9', N'90032505897', N'FP', N'klouczers@gmail.com', 0)
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Street], [PostCode], [ApartmentNumber], [HouseNumber], [Town], [TelephoneNumber], [CountryId], [IdNumber], [CompanyName], [Email], [IsVerified]) VALUES (7, N'Marcin', N'Kobzara', N'Małopolska', N'44-335', N'4', N'19', N'Jastrzebie', N'505797135', N'9', N'90032505897', N'FP', N'klouczers@gmail.com', 1)
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Street], [PostCode], [ApartmentNumber], [HouseNumber], [Town], [TelephoneNumber], [CountryId], [IdNumber], [CompanyName], [Email], [IsVerified]) VALUES (8, N'Andrzej', N'Koba', N'Małopolska', N'44-335', N'31', N'10', N'Jastrzebie', N'813', N'31', N'0901441', N'WWW', N'and@wp.pl', 0)
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Street], [PostCode], [ApartmentNumber], [HouseNumber], [Town], [TelephoneNumber], [CountryId], [IdNumber], [CompanyName], [Email], [IsVerified]) VALUES (9, N'Adam', N'Koza', N'Malopolska', N'44-100', N'3', N'19', N'Jastrzebi', N'3103013', N'PL', N'9031203901', N'brak', N'wdkod@wp.pl', 1)
SET IDENTITY_INSERT [dbo].[Guests] OFF
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([Id], [GuestId], [StartDate], [EndDate], [AdditionalInfo]) VALUES (18, 6, CAST(0x27360B00 AS Date), CAST(0x2E360B00 AS Date), N'Nowa rezerwacja')
SET IDENTITY_INSERT [dbo].[Reservations] OFF
SET IDENTITY_INSERT [dbo].[Features] ON 

INSERT [dbo].[Features] ([Id], [Name], [Description]) VALUES (1, N'ficzerek', N'taki sobie dupiaty ficzer')
INSERT [dbo].[Features] ([Id], [Name], [Description]) VALUES (2, N'ficzerek2', N'taki sobie dupiaty ficzer2')
INSERT [dbo].[Features] ([Id], [Name], [Description]) VALUES (3, N'Telewizor', N'32 calowy telewizor')
INSERT [dbo].[Features] ([Id], [Name], [Description]) VALUES (4, N'ficzerek', N'ficzur')
INSERT [dbo].[Features] ([Id], [Name], [Description]) VALUES (5, N'er', N'12345')
INSERT [dbo].[Features] ([Id], [Name], [Description]) VALUES (6, N'1234', N'1234')
INSERT [dbo].[Features] ([Id], [Name], [Description]) VALUES (7, N'', N'')
SET IDENTITY_INSERT [dbo].[Features] OFF
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (201, 1)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (204, 1)
INSERT [dbo].[RoomFeatures] ([RoomNumber], [FeatureId]) VALUES (202, 2)
INSERT [dbo].[Roles] ([Name], [Id]) VALUES (N'Admin', 1)
INSERT [dbo].[Roles] ([Name], [Id]) VALUES (N'Receptionist', 2)
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [Username], [FirstName], [LastName], [TelephoneNumber], [Street], [PostCode], [ApartmentNumber], [HouseNumber], [Town], [Email], [Password], [RoleId]) VALUES (3, N'marcys', N'Marcin', N'Koba', N'782520529', N'Malopolska', N'44-335', N'3', N'19', N'Jastrzebie', N'klocz@kof.pl', N'12345', 2)
INSERT [dbo].[Employees] ([Id], [Username], [FirstName], [LastName], [TelephoneNumber], [Street], [PostCode], [ApartmentNumber], [HouseNumber], [Town], [Email], [Password], [RoleId]) VALUES (4, N'oskar', N'Kamil', N'Socha', N'31913001', N'Stalmacha', N'3424-24', N'31', N'13', N'Gliwice', N'4024@kfo.pl', N'12345', 1)
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[TaskTypes] ON 

INSERT [dbo].[TaskTypes] ([Id], [Name], [Description]) VALUES (1, N'Sprzątanie', NULL)
INSERT [dbo].[TaskTypes] ([Id], [Name], [Description]) VALUES (2, N'Gotowanie', NULL)
INSERT [dbo].[TaskTypes] ([Id], [Name], [Description]) VALUES (3, N'Masaż', NULL)
SET IDENTITY_INSERT [dbo].[TaskTypes] OFF
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([Id], [EmployeeId], [Description], [Name], [StartDate], [EndDate], [IsDone], [TypeId]) VALUES (2, 4, N'Posprzątać pokoje.', NULL, CAST(0x00009CF100000000 AS DateTime), NULL, 0, 1)
INSERT [dbo].[Tasks] ([Id], [EmployeeId], [Description], [Name], [StartDate], [EndDate], [IsDone], [TypeId]) VALUES (3, 4, N'Ugotować zupę', NULL, CAST(0x00009CF100000000 AS DateTime), NULL, 0, 2)
INSERT [dbo].[Tasks] ([Id], [EmployeeId], [Description], [Name], [StartDate], [EndDate], [IsDone], [TypeId]) VALUES (4, 4, N'Ugotować kawał mięsa.', NULL, CAST(0x00009CF100000000 AS DateTime), NULL, 1, 2)
SET IDENTITY_INSERT [dbo].[Tasks] OFF
SET IDENTITY_INSERT [dbo].[RoomReservations] ON 

INSERT [dbo].[RoomReservations] ([ReservationId], [RoomId], [StartDate], [EndDate], [Id]) VALUES (18, 201, CAST(0x27360B00 AS Date), CAST(0x2E360B00 AS Date), 6)
INSERT [dbo].[RoomReservations] ([ReservationId], [RoomId], [StartDate], [EndDate], [Id]) VALUES (18, 204, CAST(0x27360B00 AS Date), CAST(0x2E360B00 AS Date), 7)
INSERT [dbo].[RoomReservations] ([ReservationId], [RoomId], [StartDate], [EndDate], [Id]) VALUES (18, 234, CAST(0x27360B00 AS Date), CAST(0x2E360B00 AS Date), 8)
SET IDENTITY_INSERT [dbo].[RoomReservations] OFF
