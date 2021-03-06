USE [Bookstore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT IF EXISTS [fk_order_OrderId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetail]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT IF EXISTS [fk_order_BookId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND type in (N'U'))
ALTER TABLE [dbo].[Book] DROP CONSTRAINT IF EXISTS [fk_book_AuthorId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND type in (N'U'))
ALTER TABLE [dbo].[Book] DROP CONSTRAINT IF EXISTS [DF__Book__IsActive__2A4B4B5E]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Author]') AND type in (N'U'))
ALTER TABLE [dbo].[Author] DROP CONSTRAINT IF EXISTS [DF__Author__IsActive__29572725]
GO
/****** Object:  Index [BookTitle]    Script Date: 9/23/2018 4:12:10 PM ******/
DROP INDEX IF EXISTS [BookTitle] ON [dbo].[Book]
GO
/****** Object:  Index [AuthorName]    Script Date: 9/23/2018 4:12:10 PM ******/
DROP INDEX IF EXISTS [AuthorName] ON [dbo].[Author]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 9/23/2018 4:12:10 PM ******/
DROP TABLE IF EXISTS [dbo].[OrderDetail]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 9/23/2018 4:12:10 PM ******/
DROP TABLE IF EXISTS [dbo].[Order]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 9/23/2018 4:12:10 PM ******/
DROP TABLE IF EXISTS [dbo].[Book]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 9/23/2018 4:12:10 PM ******/
DROP TABLE IF EXISTS [dbo].[Author]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 9/23/2018 4:12:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Author]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Author](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Book]    Script Date: 9/23/2018 4:12:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Price] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Order]    Script Date: 9/23/2018 4:12:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 9/23/2018 4:12:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[TotalPrice] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Author] ON 
GO
INSERT [dbo].[Author] ([AuthorId], [Name], [IsActive]) VALUES (1, N'Jack London', 1)
GO
INSERT [dbo].[Author] ([AuthorId], [Name], [IsActive]) VALUES (2, N'Charles Dickens', 1)
GO
INSERT [dbo].[Author] ([AuthorId], [Name], [IsActive]) VALUES (3, N'James Fenimore Cooper', 1)
GO
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([BookId], [AuthorId], [Title], [Price], [IsActive]) VALUES (1, 1, N'Call of the Wild', 20.0000, 1)
GO
INSERT [dbo].[Book] ([BookId], [AuthorId], [Title], [Price], [IsActive]) VALUES (2, 1, N'White Fang', 22.0000, 1)
GO
INSERT [dbo].[Book] ([BookId], [AuthorId], [Title], [Price], [IsActive]) VALUES (3, 2, N'Oliver Twist', 19.9500, 1)
GO
INSERT [dbo].[Book] ([BookId], [AuthorId], [Title], [Price], [IsActive]) VALUES (4, 2, N'Tale of Two Cites', 23.9500, 1)
GO
INSERT [dbo].[Book] ([BookId], [AuthorId], [Title], [Price], [IsActive]) VALUES (5, 3, N'The Last of the Mohicans', 24.9500, 1)
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 
GO
INSERT [dbo].[Order] ([OrderId], [Description], [OrderDate]) VALUES (1, N'John Doe order 1', CAST(N'2018-09-22T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 
GO
INSERT [dbo].[OrderDetail] ([OrderDetailId], [OrderId], [BookId], [Quantity], [UnitPrice], [TotalPrice]) VALUES (1, 1, 1, 2, 20.0000, 40.0000)
GO
INSERT [dbo].[OrderDetail] ([OrderDetailId], [OrderId], [BookId], [Quantity], [UnitPrice], [TotalPrice]) VALUES (2, 1, 3, 1, 19.9500, 19.9500)
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AuthorName]    Script Date: 9/23/2018 4:12:10 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Author]') AND name = N'AuthorName')
CREATE NONCLUSTERED INDEX [AuthorName] ON [dbo].[Author]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [BookTitle]    Script Date: 9/23/2018 4:12:10 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND name = N'BookTitle')
CREATE NONCLUSTERED INDEX [BookTitle] ON [dbo].[Book]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Author__IsActive__29572725]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Author] ADD  DEFAULT ((1)) FOR [IsActive]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Book__IsActive__2A4B4B5E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Book] ADD  DEFAULT ((1)) FOR [IsActive]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_book_AuthorId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [fk_book_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([AuthorId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_book_AuthorId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [fk_book_AuthorId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_order_BookId]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [fk_order_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_order_BookId]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [fk_order_BookId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_order_OrderId]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [fk_order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_order_OrderId]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [fk_order_OrderId]
GO
