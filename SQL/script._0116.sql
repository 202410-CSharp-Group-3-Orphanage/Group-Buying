USE [GroupBuying]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 2025/1/15 下午 04:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[GroupBuyingId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Role_Rel]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Role_Rel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Employee_Role_Rel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionId] [int] NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[EncryptedPassword] [varchar](256) NOT NULL,
	[Name] [nvarchar](5) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Functions]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Functions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupBuyings]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupBuyings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[MinimumGroupSize] [int] NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupBuyings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[EncryptedPassword] [varchar](256) NOT NULL,
	[Name] [nvarchar](5) NOT NULL,
	[Gender] [tinyint] NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [char](10) NOT NULL,
	[Birthday] [datetime] NULL,
	[Status] [smallint] NOT NULL,
	[IsConfirmed] [bit] NOT NULL,
	[ConfirmCode] [varchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[GroupBuyingId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ShippingMethod] [smallint] NOT NULL,
	[ShippingAddress] [nvarchar](150) NULL,
	[Status] [smallint] NOT NULL,
	[PaymentStatus] [smallint] NOT NULL,
	[DeliveryStatus] [smallint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Path] [nvarchar](500) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShopId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [int] NOT NULL,
	[Info] [nvarchar](3000) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role_Function_Rel]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_Function_Rel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FunctionId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Role_Function_Rel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shops]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[EncryptedPassword] [varchar](256) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IdentityCard] [char](10) NULL,
	[Avatar] [nvarchar](500) NULL,
	[Address] [nvarchar](150) NULL,
	[Status] [smallint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Shops] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishes]    Script Date: 2025/1/15 下午 04:14:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Wishes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 
GO
INSERT [dbo].[Carts] ([Id], [MemberId], [GroupBuyingId], [Quantity], [CreatedAt], [UpdatedAt]) VALUES (8, 1, 10007, 60, CAST(N'2025-01-15T15:16:46.993' AS DateTime), CAST(N'2025-01-15T15:16:46.993' AS DateTime))
GO
INSERT [dbo].[Carts] ([Id], [MemberId], [GroupBuyingId], [Quantity], [CreatedAt], [UpdatedAt]) VALUES (12, 1, 10006, 9, CAST(N'2025-01-15T15:21:45.010' AS DateTime), CAST(N'2025-01-15T15:21:45.010' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (1, N'3C', 1, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (2, N'周邊', 2, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (3, N'筆電', 3, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (4, N'通訊', 4, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (5, N'數位', 5, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (6, N'家電', 6, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (7, N'日用', 7, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (8, N'母嬰', 8, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (9, N'食品', 9, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10, N'生活', 10, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (11, N'居家', 11, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (12, N'休閒', 12, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (13, N'保健', 13, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (14, N'美妝', 14, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (15, N'時尚', 15, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (16, N'書店', 16, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (17, N'其他', 17, 1, CAST(N'2025-01-15T02:26:13.373' AS DateTime), CAST(N'2025-01-15T02:26:13.373' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([Id], [PositionId], [Account], [EncryptedPassword], [Name], [CreatedAt], [UpdatedAt]) VALUES (2, 0, N'employee001', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'管理員1', CAST(N'2025-01-14T23:51:23.147' AS DateTime), CAST(N'2025-01-14T23:51:23.147' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[GroupBuyings] ON 
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (1, 1, 35000, 30, N'歡迎參加 Apple iPhone 16 Pro 團購專案！全新登場的 iPhone 16 Pro 結合極致設計與尖端科技，讓你以超值價格入手最新旗艦手機。趕緊把握機會，與親友一起享受團購優惠！

注意事項：
團購價格為特惠價，恕不另行議價。
請確認產品規格後再下單，商品一經售出，非瑕疵問題恕不退換。
若有任何問題，請隨時聯絡我們的客服團隊。', CAST(N'2025-01-15T11:40:33.733' AS DateTime), CAST(N'2025-01-14T11:40:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:40:33.733' AS DateTime), CAST(N'2025-01-15T12:28:37.767' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (2, 2, 33000, 15, N'科技玩家的福音來了！GIGABYTE GeForce RTX 4080 SUPER WINDFORCE V2 顯示卡，搭載最新 NVIDIA Ampere 架構，帶來震撼的遊戲效能與視覺體驗。現在加入團購，即可用更優惠的價格入手這款頂級顯示卡！

注意事項：
團購價格為特惠價，恕不另行議價。
請確認產品規格與需求後再下單，商品一經售出，非瑕疵問題恕不退換。
若有任何問題，請隨時聯絡我們的客服團隊。
趕快加入團購，一起升級你的遊戲與創作體驗，用最強顯示卡開啟全新境界！', CAST(N'2025-01-15T11:42:57.293' AS DateTime), CAST(N'2025-01-14T11:42:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:42:57.293' AS DateTime), CAST(N'2025-01-15T12:28:37.880' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (3, 5, 70000, 50, N'想要將頂級家庭影院搬回家？現在加入團購，讓 Philips 77型 4K 120Hz OLED Google TV 智慧聯網顯示器 成為你的影音娛樂核心！以優惠價格入手，享受震撼的畫質與智慧功能。
注意事項：
團購價格為特惠價，恕不另行議價。
請確認產品規格與需求後再下單，商品一經售出，非瑕疵問題恕不退換。
本團購商品為大型家電，需確認收貨地點可支持配送服務。
若有任何問題，請隨時聯絡我們的客服團隊。
加入團購，即刻升級你的家庭娛樂體驗！讓 Philips 77型 OLED 智慧顯示器帶你感受無與倫比的影音震撼！', CAST(N'2025-01-15T11:44:05.703' AS DateTime), CAST(N'2025-01-14T11:43:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:44:05.703' AS DateTime), CAST(N'2025-01-15T12:28:37.887' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (4, 9, 220, 100, N'快來參加 灣仔碼頭手工水餃（高麗菜口味）團購，將這份經典美味帶回家！純手工製作，選用新鮮高麗菜與優質豬肉，皮薄餡多，鮮美多汁，是全家人都愛的日常美食！
注意事項：
團購價格為特惠價，恕不另行議價。
請確認商品數量後下單，商品一經售出，非瑕疵問題恕不退換。
本商品為冷凍配送，請確認配送地址可接收冷凍包裹。
若有任何問題，請隨時聯絡我們的客服團隊。
快快加入團購，一起囤好吃的灣仔碼頭手工水餃！在家也能輕鬆享受經典的中式手工美味！
', CAST(N'2025-01-15T11:45:18.707' AS DateTime), CAST(N'2025-01-14T11:44:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:45:18.707' AS DateTime), CAST(N'2025-01-15T12:28:37.887' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (17, 1, 35000, 30, N'歡迎參加 Apple iPhone 16 Pro 團購專案！全新登場的 iPhone 16 Pro 結合極致設計與尖端科技，讓你以超值價格入手最新旗艦手機。趕緊把握機會，與親友一起享受團購優惠！

注意事項：
團購價格為特惠價，恕不另行議價。
請確認產品規格後再下單，商品一經售出，非瑕疵問題恕不退換。
若有任何問題，請隨時聯絡我們的客服團隊。', CAST(N'2025-01-15T11:40:33.733' AS DateTime), CAST(N'2025-01-14T11:40:00.000' AS DateTime), 1, CAST(N'2025-01-15T11:40:33.733' AS DateTime), CAST(N'2025-01-15T11:40:33.733' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (18, 2, 33000, 15, N'科技玩家的福音來了！GIGABYTE GeForce RTX 4080 SUPER WINDFORCE V2 顯示卡，搭載最新 NVIDIA Ampere 架構，帶來震撼的遊戲效能與視覺體驗。現在加入團購，即可用更優惠的價格入手這款頂級顯示卡！

注意事項：
團購價格為特惠價，恕不另行議價。
請確認產品規格與需求後再下單，商品一經售出，非瑕疵問題恕不退換。
若有任何問題，請隨時聯絡我們的客服團隊。
趕快加入團購，一起升級你的遊戲與創作體驗，用最強顯示卡開啟全新境界！', CAST(N'2025-01-15T11:42:57.293' AS DateTime), CAST(N'2025-01-14T11:42:00.000' AS DateTime), 1, CAST(N'2025-01-15T11:42:57.293' AS DateTime), CAST(N'2025-01-15T11:42:57.293' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (19, 5, 70000, 50, N'想要將頂級家庭影院搬回家？現在加入團購，讓 Philips 77型 4K 120Hz OLED Google TV 智慧聯網顯示器 成為你的影音娛樂核心！以優惠價格入手，享受震撼的畫質與智慧功能。
注意事項：
團購價格為特惠價，恕不另行議價。
請確認產品規格與需求後再下單，商品一經售出，非瑕疵問題恕不退換。
本團購商品為大型家電，需確認收貨地點可支持配送服務。
若有任何問題，請隨時聯絡我們的客服團隊。
加入團購，即刻升級你的家庭娛樂體驗！讓 Philips 77型 OLED 智慧顯示器帶你感受無與倫比的影音震撼！', CAST(N'2025-01-15T11:44:05.703' AS DateTime), CAST(N'2025-01-14T11:43:00.000' AS DateTime), 1, CAST(N'2025-01-15T11:44:05.703' AS DateTime), CAST(N'2025-01-15T11:44:05.703' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (20, 9, 220, 100, N'快來參加 灣仔碼頭手工水餃（高麗菜口味）團購，將這份經典美味帶回家！純手工製作，選用新鮮高麗菜與優質豬肉，皮薄餡多，鮮美多汁，是全家人都愛的日常美食！
注意事項：
團購價格為特惠價，恕不另行議價。
請確認商品數量後下單，商品一經售出，非瑕疵問題恕不退換。
本商品為冷凍配送，請確認配送地址可接收冷凍包裹。
若有任何問題，請隨時聯絡我們的客服團隊。
快快加入團購，一起囤好吃的灣仔碼頭手工水餃！在家也能輕鬆享受經典的中式手工美味！
', CAST(N'2025-01-15T11:45:18.707' AS DateTime), CAST(N'2025-01-14T11:44:00.000' AS DateTime), 1, CAST(N'2025-01-15T11:45:18.707' AS DateTime), CAST(N'2025-01-15T11:45:18.707' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (5000, 5012, 499, 20, N'美國CARSON夾式彎彎閱讀書燈，輕巧便攜，LED燈光柔和護眼，適合夜間閱讀或旅行攜帶。高品質材質製成，使用便利耐用。授權中國大陸生產，品質有保障，快來團購！', CAST(N'2025-01-15T11:14:59.850' AS DateTime), CAST(N'2025-01-14T11:14:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:14:59.850' AS DateTime), CAST(N'2025-01-15T12:49:18.840' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (5001, 5013, 199, 30, N'趕快來買！', CAST(N'2025-01-15T11:30:13.710' AS DateTime), CAST(N'2025-01-14T00:30:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:30:13.710' AS DateTime), CAST(N'2025-01-15T12:49:18.977' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (5002, 5014, 2999, 40, N'快來買', CAST(N'2025-01-15T11:30:34.567' AS DateTime), CAST(N'2025-01-14T00:30:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:30:34.567' AS DateTime), CAST(N'2025-01-15T12:49:18.987' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (5003, 5000, 199, 99, N'乖乖桶水果軟糖，閃亮外型，內藏多種水果風味，香甜Q彈，陪伴童年回憶。素食適用（含牛來源明膠），品質安心。快來團購分享這份甜蜜！', CAST(N'2025-01-15T11:45:54.923' AS DateTime), CAST(N'2025-01-14T16:50:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:45:54.923' AS DateTime), CAST(N'2025-01-15T12:49:18.993' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (5004, 5004, 350, 20, N'好玩快來買', CAST(N'2025-01-15T11:56:06.803' AS DateTime), CAST(N'2025-01-14T02:55:00.000' AS DateTime), 0, CAST(N'2025-01-15T11:56:06.803' AS DateTime), CAST(N'2025-01-15T12:49:19.000' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (5005, 5012, 499, 20, N'美國CARSON夾式彎彎閱讀書燈，輕巧便攜，LED燈光柔和護眼，適合夜間閱讀或旅行攜帶。高品質材質製成，使用便利耐用。授權中國大陸生產，品質有保障，快來團購！', CAST(N'2025-01-15T13:13:07.947' AS DateTime), CAST(N'2025-01-14T15:12:00.000' AS DateTime), 1, CAST(N'2025-01-15T13:13:07.947' AS DateTime), CAST(N'2025-01-15T13:13:07.947' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (5008, 5014, 2999, 40, N'快來買', CAST(N'2025-01-15T13:29:16.097' AS DateTime), CAST(N'2025-01-14T14:29:00.000' AS DateTime), 1, CAST(N'2025-01-15T13:29:16.097' AS DateTime), CAST(N'2025-01-15T13:29:16.097' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10000, 10000, 180, 30, N'產品一經購買，無法退換貨，請確認需求後再下單。', CAST(N'2025-01-15T12:52:24.907' AS DateTime), CAST(N'2025-01-14T12:52:00.000' AS DateTime), 0, CAST(N'2025-01-15T12:52:24.907' AS DateTime), CAST(N'2025-01-15T13:27:18.880' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10001, 10001, 370, 50, N'產品一經購買，無法退換貨，請確認需求後再下單。', CAST(N'2025-01-15T12:52:58.687' AS DateTime), CAST(N'2025-01-14T12:52:00.000' AS DateTime), 0, CAST(N'2025-01-15T12:52:58.687' AS DateTime), CAST(N'2025-01-15T13:27:18.950' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10002, 10005, 750, 20, N'產品一經購買，無法退換貨，請確認需求後再下單。', CAST(N'2025-01-15T12:55:24.823' AS DateTime), CAST(N'2025-01-14T12:55:00.000' AS DateTime), 0, CAST(N'2025-01-15T12:55:24.823' AS DateTime), CAST(N'2025-01-15T13:27:18.957' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10003, 10006, 1050, 40, N'產品一經購買，無法退換貨，請確認需求後再下單。', CAST(N'2025-01-15T12:55:40.857' AS DateTime), CAST(N'2025-01-14T12:55:00.000' AS DateTime), 0, CAST(N'2025-01-15T12:55:40.857' AS DateTime), CAST(N'2025-01-15T13:27:18.963' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10004, 10010, 750, 20, N'產品一經購買，無法退換貨，請確認需求後再下單。', CAST(N'2025-01-15T12:56:28.107' AS DateTime), CAST(N'2025-01-14T12:56:00.000' AS DateTime), 0, CAST(N'2025-01-15T12:56:28.107' AS DateTime), CAST(N'2025-01-15T13:27:18.967' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10005, 10011, 1100, 50, N'產品一經購買，無法退換貨，請確認需求後再下單。', CAST(N'2025-01-15T12:56:41.887' AS DateTime), CAST(N'2025-01-14T12:56:00.000' AS DateTime), 0, CAST(N'2025-01-15T12:56:41.887' AS DateTime), CAST(N'2025-01-15T13:27:19.003' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10006, 10010, 750, 20, N'產品一經購買，無法退換貨，請確認需求後再下單。', CAST(N'2025-01-15T13:30:41.703' AS DateTime), CAST(N'2025-01-14T12:52:00.000' AS DateTime), 1, CAST(N'2025-01-15T13:30:41.703' AS DateTime), CAST(N'2025-01-15T13:30:41.703' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10007, 10011, 1100, 50, N'產品一經購買，無法退換貨，請確認需求後再下單。', CAST(N'2025-01-15T13:32:00.837' AS DateTime), CAST(N'2025-01-14T12:56:00.000' AS DateTime), 1, CAST(N'2025-01-15T13:32:00.837' AS DateTime), CAST(N'2025-01-15T13:32:00.837' AS DateTime))
GO
INSERT [dbo].[GroupBuyings] ([Id], [ProductId], [Price], [MinimumGroupSize], [Description], [StartDate], [EndDate], [Enabled], [CreatedAt], [UpdatedAt]) VALUES (10008, 14, 400000, 10, N'精品愛好者看過來！Hermès 愛馬仕 Mini Lindy 這款經典包型，以其獨特設計與頂級工藝成為萬眾矚目的夢幻逸品。本次團購限量推出 18 大象灰 / W 刻 / 金釦 款式，讓你輕鬆擁有這份低調奢華的象徵。
注意事項：
團購價格為特惠價，產品為正品來源，請安心購買。
商品屬精品配件，請確認訂購需求，售出後恕不接受退換貨。
團購商品包含 Hermès 專屬防塵袋與包裝，配送時將確保完整性。
若有任何問題，請隨時聯絡我們的客服團隊。', CAST(N'2025-01-15T13:49:13.620' AS DateTime), CAST(N'2025-01-14T13:49:00.000' AS DateTime), 1, CAST(N'2025-01-15T13:49:13.620' AS DateTime), CAST(N'2025-01-15T13:49:13.620' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[GroupBuyings] OFF
GO
SET IDENTITY_INSERT [dbo].[Members] ON 
GO
INSERT [dbo].[Members] ([Id], [Account], [EncryptedPassword], [Name], [Gender], [Email], [Phone], [Birthday], [Status], [IsConfirmed], [ConfirmCode], [CreatedAt], [UpdatedAt]) VALUES (1, N'keith1728', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'李巖康', 1, N'mcadams3835@yasshoo.com', N'0936481183', CAST(N'1989-07-11T00:00:00.000' AS DateTime), 1, 1, NULL, CAST(N'2025-01-15T00:23:03.920' AS DateTime), CAST(N'2025-01-15T00:23:03.920' AS DateTime))
GO
INSERT [dbo].[Members] ([Id], [Account], [EncryptedPassword], [Name], [Gender], [Email], [Phone], [Birthday], [Status], [IsConfirmed], [ConfirmCode], [CreatedAt], [UpdatedAt]) VALUES (3, N'lautner9973', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'盧姣雁', 1, N'lautner9973@grsgr.com', N'0913166888', CAST(N'1994-07-19T00:00:00.000' AS DateTime), 0, 1, NULL, CAST(N'2025-01-15T12:16:48.323' AS DateTime), CAST(N'2025-01-15T12:16:48.323' AS DateTime))
GO
INSERT [dbo].[Members] ([Id], [Account], [EncryptedPassword], [Name], [Gender], [Email], [Phone], [Birthday], [Status], [IsConfirmed], [ConfirmCode], [CreatedAt], [UpdatedAt]) VALUES (5000, N'user5001', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'魏逸靖', 1, N'dennis2741@gmmmail.commm', N'0986154901', CAST(N'1990-11-11T00:00:00.000' AS DateTime), 0, 1, NULL, CAST(N'2025-01-15T10:54:56.220' AS DateTime), CAST(N'2025-01-15T10:54:56.220' AS DateTime))
GO
INSERT [dbo].[Members] ([Id], [Account], [EncryptedPassword], [Name], [Gender], [Email], [Phone], [Birthday], [Status], [IsConfirmed], [ConfirmCode], [CreatedAt], [UpdatedAt]) VALUES (5001, N'user5002', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'湯棟鑫', 1, N'louis8315@gmmmail.commm', N'0935888099', CAST(N'2001-01-05T00:00:00.000' AS DateTime), 0, 1, NULL, CAST(N'2025-01-15T10:55:59.897' AS DateTime), CAST(N'2025-01-15T10:55:59.897' AS DateTime))
GO
INSERT [dbo].[Members] ([Id], [Account], [EncryptedPassword], [Name], [Gender], [Email], [Phone], [Birthday], [Status], [IsConfirmed], [ConfirmCode], [CreatedAt], [UpdatedAt]) VALUES (5002, N'user5003', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'賴沚芊', 0, N'laiball@yahoooo.commm', N'0915961795', CAST(N'2000-06-12T00:00:00.000' AS DateTime), 0, 1, NULL, CAST(N'2025-01-15T10:57:26.127' AS DateTime), CAST(N'2025-01-15T10:57:26.127' AS DateTime))
GO
INSERT [dbo].[Members] ([Id], [Account], [EncryptedPassword], [Name], [Gender], [Email], [Phone], [Birthday], [Status], [IsConfirmed], [ConfirmCode], [CreatedAt], [UpdatedAt]) VALUES (10000, N'Ema0301', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'簡爾琴', 0, N'Ema0301@Kmail.com', N'0930156279', CAST(N'2012-02-24T00:00:00.000' AS DateTime), 1, 1, N'033c340967da419c9e8f27c1db6db9e1', CAST(N'2025-01-15T11:28:25.677' AS DateTime), CAST(N'2025-01-15T11:28:25.677' AS DateTime))
GO
INSERT [dbo].[Members] ([Id], [Account], [EncryptedPassword], [Name], [Gender], [Email], [Phone], [Birthday], [Status], [IsConfirmed], [ConfirmCode], [CreatedAt], [UpdatedAt]) VALUES (10001, N'Jack0514', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'田昱樂', 1, N'Jack0514@Kmail.com', N'0927873860', CAST(N'1990-06-19T00:00:00.000' AS DateTime), 1, 1, N'fe4eb7715a5a499b8f5b73fed2329359', CAST(N'2025-01-15T11:31:10.133' AS DateTime), CAST(N'2025-01-15T11:31:10.133' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Members] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (1, 3, 4, 220, 15, 1, NULL, 0, 0, 0, CAST(N'2025-01-15T12:19:05.517' AS DateTime), CAST(N'2025-01-15T12:28:37.890' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (2, 3, 3, 70000, 29, 1, NULL, 0, 0, 0, CAST(N'2025-01-15T12:19:05.570' AS DateTime), CAST(N'2025-01-15T12:28:37.887' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (3, 3, 1, 35000, 41, 1, NULL, 5, 0, 0, CAST(N'2025-01-15T12:19:05.580' AS DateTime), CAST(N'2025-01-15T12:28:37.880' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (4, 3, 2, 33000, 23, 1, NULL, 5, 0, 0, CAST(N'2025-01-15T12:19:05.593' AS DateTime), CAST(N'2025-01-15T12:28:37.887' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (5000, 5002, 5000, 499, 2, 1, NULL, 5, 0, 0, CAST(N'2025-01-15T11:28:00.837' AS DateTime), CAST(N'2025-01-15T12:49:18.977' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (5001, 5000, 5000, 499, 30, 1, NULL, 5, 0, 0, CAST(N'2025-01-15T11:28:45.953' AS DateTime), CAST(N'2025-01-15T12:49:18.977' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (5003, 5000, 5002, 2999, 3, 1, NULL, 0, 0, 0, CAST(N'2025-01-15T11:31:41.617' AS DateTime), CAST(N'2025-01-15T11:32:05.137' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (10000, 10000, 10005, 1100, 50, 1, NULL, 5, 0, 0, CAST(N'2025-01-15T13:12:55.473' AS DateTime), CAST(N'2025-01-15T13:27:19.007' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (10001, 10001, 10004, 750, 20, 1, NULL, 5, 0, 0, CAST(N'2025-01-15T13:18:42.120' AS DateTime), CAST(N'2025-01-15T13:27:19.003' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (10002, 1, 19, 70000, 7, 1, NULL, 1, 0, 0, CAST(N'2025-01-15T13:45:29.663' AS DateTime), CAST(N'2025-01-15T13:45:29.663' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (10003, 1, 5008, 2999, 34, 1, NULL, 1, 0, 0, CAST(N'2025-01-15T13:50:12.493' AS DateTime), CAST(N'2025-01-15T13:50:12.493' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (10004, 1, 10008, 400000, 10, 1, NULL, 1, 0, 0, CAST(N'2025-01-15T13:50:12.517' AS DateTime), CAST(N'2025-01-15T13:50:12.517' AS DateTime))
GO
INSERT [dbo].[Orders] ([Id], [MemberId], [GroupBuyingId], [Price], [Quantity], [ShippingMethod], [ShippingAddress], [Status], [PaymentStatus], [DeliveryStatus], [CreatedAt], [UpdatedAt]) VALUES (10005, 10000, 20, 220, 100, 1, NULL, 1, 0, 0, CAST(N'2025-01-15T15:18:54.133' AS DateTime), CAST(N'2025-01-15T15:18:54.133' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (1, 1, N'6592a319eec04f9abff5972ca4172b50.png', CAST(N'2025-01-14T23:51:23.147' AS DateTime), CAST(N'2025-01-14T23:51:23.147' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (2, 1, N'77672760405a46e6867abf326464cb1a.png', CAST(N'2025-01-14T23:51:23.147' AS DateTime), CAST(N'2025-01-14T23:51:23.147' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (3, 1, N'd815938d309f4051b8c6f190fb054433.png', CAST(N'2025-01-14T23:51:23.147' AS DateTime), CAST(N'2025-01-14T23:51:23.147' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (4, 1, N'696d51167b8048aa8e6d65fb72f8cff1.png', CAST(N'2025-01-14T23:51:23.147' AS DateTime), CAST(N'2025-01-14T23:51:23.147' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5, 2, N'78e177b4ea264998866d651f9d0f83db.png', CAST(N'2025-01-14T23:55:58.453' AS DateTime), CAST(N'2025-01-14T23:55:58.453' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (6, 2, N'984e9eb71e964dbd8651d10a2b3c3ece.png', CAST(N'2025-01-14T23:55:58.453' AS DateTime), CAST(N'2025-01-14T23:55:58.453' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (7, 2, N'475663900d114299a1351c9e9d968c93.png', CAST(N'2025-01-14T23:55:58.453' AS DateTime), CAST(N'2025-01-14T23:55:58.453' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (8, 3, N'2368f5d8a515469ab964889052fbecf3.jpg', CAST(N'2025-01-14T23:59:56.470' AS DateTime), CAST(N'2025-01-14T23:59:56.470' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (9, 3, N'10ebdb0a1e984f0693082d4a42c8fde9.png', CAST(N'2025-01-14T23:59:56.470' AS DateTime), CAST(N'2025-01-14T23:59:56.470' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10, 4, N'39bef1e68a8349dbaba526ca53266854.jpg', CAST(N'2025-01-15T00:03:01.973' AS DateTime), CAST(N'2025-01-15T00:03:01.973' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (11, 4, N'4a184025f2814c5fb1e1651653a8c72f.png', CAST(N'2025-01-15T00:03:01.973' AS DateTime), CAST(N'2025-01-15T00:03:01.973' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (12, 4, N'77b64ec5a395403cac17dad15495a637.png', CAST(N'2025-01-15T00:03:01.973' AS DateTime), CAST(N'2025-01-15T00:03:01.973' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (13, 4, N'a9995a2f4c7f4cbbb553f36ecf4268dc.png', CAST(N'2025-01-15T00:03:01.973' AS DateTime), CAST(N'2025-01-15T00:03:01.973' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (14, 5, N'fdf4b53250b340d88be600c1beb28c8c.png', CAST(N'2025-01-15T10:32:59.227' AS DateTime), CAST(N'2025-01-15T10:32:59.227' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (15, 5, N'59d36cdecb604add80620262b1fd0f69.png', CAST(N'2025-01-15T10:32:59.227' AS DateTime), CAST(N'2025-01-15T10:32:59.227' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (16, 5, N'92d15d6379d74e6183859da7e1147534.png', CAST(N'2025-01-15T10:32:59.227' AS DateTime), CAST(N'2025-01-15T10:32:59.227' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (17, 5, N'5e2b902b54ff46f480e0a1b17521dff1.png', CAST(N'2025-01-15T10:32:59.227' AS DateTime), CAST(N'2025-01-15T10:32:59.227' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (18, 5, N'93556dd7c3304d2fbc944380fc1a3f86.png', CAST(N'2025-01-15T10:32:59.227' AS DateTime), CAST(N'2025-01-15T10:32:59.227' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (19, 5, N'989629350338425984309e5a59cca621.png', CAST(N'2025-01-15T10:32:59.227' AS DateTime), CAST(N'2025-01-15T10:32:59.227' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (20, 6, N'9e8f0bc3c49f42ddb6c3b70bb3c25db2.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (21, 6, N'9683504b2d2949fcb23e55b84496b489.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (22, 6, N'febb3ba307934038885d8441be475553.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (23, 6, N'47f173e361394b698213893653588f05.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (24, 6, N'8caa76cc185647e3acc7c2a6bbd308fb.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (25, 6, N'4475717a6efb43dba166c84dfcee8f4c.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (26, 6, N'7b35b6dd51474848af125123c10aa5ed.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (27, 6, N'62bd8459173f45fab060b9d26f4756c8.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (28, 6, N'40517aeefc9649c4a0c8cded742c45a4.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (29, 6, N'60d5dab4af3044689710ebc7cc5882cd.jpg', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (30, 7, N'7b7eb0cbbad74b9baf8c1458d9a438e3.jpg', CAST(N'2025-01-15T10:57:34.853' AS DateTime), CAST(N'2025-01-15T10:57:34.853' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (31, 7, N'8ad14129138a4dd385468b61e6666c76.jpg', CAST(N'2025-01-15T10:57:34.853' AS DateTime), CAST(N'2025-01-15T10:57:34.853' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (32, 7, N'a7d9cd706c2c4f7c9879a64882e39c3f.jpg', CAST(N'2025-01-15T10:57:34.853' AS DateTime), CAST(N'2025-01-15T10:57:34.853' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (33, 7, N'd72da374abfc4da9879f5bf449bb118c.jpg', CAST(N'2025-01-15T10:57:34.853' AS DateTime), CAST(N'2025-01-15T10:57:34.853' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (34, 7, N'b9db90ff47114f2c9c45b086080726a2.jpg', CAST(N'2025-01-15T10:57:34.853' AS DateTime), CAST(N'2025-01-15T10:57:34.853' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (35, 7, N'a818146b6c1046469aae2a7ffb35e44f.png', CAST(N'2025-01-15T10:57:34.853' AS DateTime), CAST(N'2025-01-15T10:57:34.853' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (36, 8, N'79b18697d1a9424b8a110653a3ce188c.jpg', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (37, 8, N'd2045eccdc3345a1b34e636838eb3eef.jpg', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (38, 8, N'0b185c1a9bd847edb236f997d7eb460a.jpg', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (39, 8, N'c4de200b8f3d4ceb92e10fb27b32fc52.jpg', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (40, 8, N'3d8042a8a63148f58cae30a1a5adc9b0.jpg', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (41, 8, N'765eeef7e2cf4055acd8243e8b6efd4f.jpg', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (42, 8, N'e614d1a75267485a971a69a81eded6e0.jpg', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (43, 8, N'cd750f3618ff42bea883bc6d81b1f4b1.png', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (44, 8, N'0055f0d924274be496e212ff0d09acf2.png', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (45, 8, N'ba9791b8320e40838fb1f89835340654.png', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (46, 9, N'032692775f8442bd9f7d577a38c9e385.jpg', CAST(N'2025-01-15T11:04:28.323' AS DateTime), CAST(N'2025-01-15T11:04:28.323' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (47, 9, N'd7d18350af7b4153aec924489bc47418.jpg', CAST(N'2025-01-15T11:04:28.323' AS DateTime), CAST(N'2025-01-15T11:04:28.323' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (48, 9, N'cc1ccb25d61e461490098cdd115c6c9d.jpg', CAST(N'2025-01-15T11:04:28.323' AS DateTime), CAST(N'2025-01-15T11:04:28.323' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (49, 9, N'bd096b9637ce46b7a9b366da3e6a88a6.jpg', CAST(N'2025-01-15T11:04:28.323' AS DateTime), CAST(N'2025-01-15T11:04:28.323' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (50, 9, N'5564219d3f554851a2afe6ed72ed1383.jpg', CAST(N'2025-01-15T11:04:28.323' AS DateTime), CAST(N'2025-01-15T11:04:28.323' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (51, 9, N'660159e10a6b4d48af2d4be1e5941c88.jpg', CAST(N'2025-01-15T11:04:28.323' AS DateTime), CAST(N'2025-01-15T11:04:28.323' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (52, 10, N'6b990c048598461bb97ef6fd26a7760f.jpg', CAST(N'2025-01-15T11:05:58.367' AS DateTime), CAST(N'2025-01-15T11:05:58.367' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (53, 10, N'3a68c4e802a84efd9d1acaa001364d16.jpg', CAST(N'2025-01-15T11:05:58.367' AS DateTime), CAST(N'2025-01-15T11:05:58.367' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (54, 10, N'd46f11153c0b42bdb1ba82883b334759.webp', CAST(N'2025-01-15T11:05:58.367' AS DateTime), CAST(N'2025-01-15T11:05:58.367' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (55, 11, N'fd39e3c9334546e19316aba61e7860ad.jpg', CAST(N'2025-01-15T11:11:39.637' AS DateTime), CAST(N'2025-01-15T11:11:39.637' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (56, 11, N'047aa02bfd64415a9714403eb2089857.jpg', CAST(N'2025-01-15T11:11:39.637' AS DateTime), CAST(N'2025-01-15T11:11:39.637' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (57, 11, N'dd68a74266ac45849906c664a162c4cd.jpg', CAST(N'2025-01-15T11:11:39.637' AS DateTime), CAST(N'2025-01-15T11:11:39.637' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (58, 11, N'3c2d7aeac65f476daf6697f6988a8642.png', CAST(N'2025-01-15T11:11:39.637' AS DateTime), CAST(N'2025-01-15T11:11:39.637' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (59, 12, N'a0bb82e08b7a4e0d8f9bc62c116276e8.jpg', CAST(N'2025-01-15T11:13:00.513' AS DateTime), CAST(N'2025-01-15T11:13:00.513' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (60, 12, N'de4cc2d05c62499d998eacd369dfe182.jpg', CAST(N'2025-01-15T11:13:00.513' AS DateTime), CAST(N'2025-01-15T11:13:00.513' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (61, 12, N'c2f7a9d7124b47adb2eba1a7a06e49b7.jpg', CAST(N'2025-01-15T11:13:00.513' AS DateTime), CAST(N'2025-01-15T11:13:00.513' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (62, 12, N'92b2b501075d4192b13dd635f1f38a75.jpg', CAST(N'2025-01-15T11:13:00.513' AS DateTime), CAST(N'2025-01-15T11:13:00.513' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (63, 12, N'e1941bb52ae24d22bc3450251d4eb84a.png', CAST(N'2025-01-15T11:13:00.513' AS DateTime), CAST(N'2025-01-15T11:13:00.513' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (64, 13, N'6c75a835bd3948b4ad8d9c4842b6e81b.jpg', CAST(N'2025-01-15T11:16:42.433' AS DateTime), CAST(N'2025-01-15T11:16:42.433' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (65, 13, N'6dcb535ee50f4ed498eb436ed37c36dd.png', CAST(N'2025-01-15T11:16:42.433' AS DateTime), CAST(N'2025-01-15T11:16:42.433' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (66, 14, N'33efbb888b9f4c539da8a6d7796f7d9b.jpg', CAST(N'2025-01-15T11:26:10.133' AS DateTime), CAST(N'2025-01-15T11:26:10.133' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (67, 14, N'f1d4efc1874a4b61a37aa55d50a2693f.jpg', CAST(N'2025-01-15T11:26:10.133' AS DateTime), CAST(N'2025-01-15T11:26:10.133' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (68, 14, N'd762c3da0ec94c379e4564d2a9b4fad7.jpg', CAST(N'2025-01-15T11:26:10.133' AS DateTime), CAST(N'2025-01-15T11:26:10.133' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (69, 14, N'a8fc249cf9a74534b84c1c1fbf219d66.jpg', CAST(N'2025-01-15T11:26:10.133' AS DateTime), CAST(N'2025-01-15T11:26:10.133' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (70, 14, N'4db2d2afee994604b03037561126e3d6.jpg', CAST(N'2025-01-15T11:26:10.133' AS DateTime), CAST(N'2025-01-15T11:26:10.133' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (71, 14, N'190a35aa17fd433496835701e3574450.jpg', CAST(N'2025-01-15T11:26:10.133' AS DateTime), CAST(N'2025-01-15T11:26:10.133' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (72, 15, N'365e83575f8a4773a7cf880b723aad14.jpg', CAST(N'2025-01-15T11:27:27.463' AS DateTime), CAST(N'2025-01-15T11:27:27.463' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (73, 15, N'561d63fbd47a4dc29cbd01259d6ba300.jpg', CAST(N'2025-01-15T11:27:27.463' AS DateTime), CAST(N'2025-01-15T11:27:27.463' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (74, 15, N'dd6c19a1826244b794f9a549a30457f5.jpg', CAST(N'2025-01-15T11:27:27.463' AS DateTime), CAST(N'2025-01-15T11:27:27.463' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (75, 15, N'0afcea5c5f85439ab8a952073c702b71.jpg', CAST(N'2025-01-15T11:27:27.463' AS DateTime), CAST(N'2025-01-15T11:27:27.463' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (76, 15, N'b3a72216dc3d48ad8d0158385bc1b9de.jpg', CAST(N'2025-01-15T11:27:27.463' AS DateTime), CAST(N'2025-01-15T11:27:27.463' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5000, 5000, N'093a6649b837422db3b52393cbd893c7.png', CAST(N'2025-01-15T10:17:25.690' AS DateTime), CAST(N'2025-01-15T10:17:25.690' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5001, 5001, N'4c9cc0282f85475ca771dd18f52c433a.png', CAST(N'2025-01-15T10:18:40.030' AS DateTime), CAST(N'2025-01-15T10:18:40.030' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5002, 5002, N'87c2d9f9511f4819863959a76126b0c1.png', CAST(N'2025-01-15T10:19:41.643' AS DateTime), CAST(N'2025-01-15T10:19:41.643' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5003, 5003, N'ef373d391b9a4d2ab6ae4d9e6732e480.png', CAST(N'2025-01-15T10:22:05.297' AS DateTime), CAST(N'2025-01-15T10:22:05.297' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5004, 5004, N'25d6b0b2266040f3bda49758a7286e7b.png', CAST(N'2025-01-15T10:24:20.760' AS DateTime), CAST(N'2025-01-15T10:24:20.760' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5005, 5005, N'13b9609b67fc44a1bd6fd0fcaf925272.png', CAST(N'2025-01-15T10:26:39.603' AS DateTime), CAST(N'2025-01-15T10:26:39.603' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5006, 5006, N'dfc3bc15d37a406b91c9446300815444.png', CAST(N'2025-01-15T10:29:15.713' AS DateTime), CAST(N'2025-01-15T10:29:15.713' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5007, 5007, N'5a6a4f42ba9548b39b34b003c34d8622.png', CAST(N'2025-01-15T10:30:44.597' AS DateTime), CAST(N'2025-01-15T10:30:44.597' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5008, 5008, N'ec0d050db13d4bec9b8b8a977cdc7e12.png', CAST(N'2025-01-15T10:31:39.277' AS DateTime), CAST(N'2025-01-15T10:31:39.277' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5009, 5009, N'1774e706eb09460e92f027c7a2ce1f08.png', CAST(N'2025-01-15T10:32:38.560' AS DateTime), CAST(N'2025-01-15T10:32:38.560' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5010, 5010, N'daa7ea351d71439bb012b80d9a1e55f0.png', CAST(N'2025-01-15T10:37:35.163' AS DateTime), CAST(N'2025-01-15T10:37:35.163' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5011, 5010, N'8d5db5515eb94f26b95b459f1699234b.png', CAST(N'2025-01-15T10:37:35.163' AS DateTime), CAST(N'2025-01-15T10:37:35.163' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5012, 5010, N'c4e8dee79d334ba9aff749952c3d64db.png', CAST(N'2025-01-15T10:37:35.163' AS DateTime), CAST(N'2025-01-15T10:37:35.163' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5013, 5011, N'a171f37fc34041299b1bfd5c11a9a18a.png', CAST(N'2025-01-15T10:39:09.060' AS DateTime), CAST(N'2025-01-15T10:39:09.060' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5014, 5011, N'15287540281349489c948cf74e710e83.png', CAST(N'2025-01-15T10:39:09.060' AS DateTime), CAST(N'2025-01-15T10:39:09.060' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5015, 5011, N'4f1858ae465d48fd997101b35860204b.png', CAST(N'2025-01-15T10:39:09.060' AS DateTime), CAST(N'2025-01-15T10:39:09.060' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5016, 5012, N'ab3286e17f4f43ff8c2baeddfc521389.png', CAST(N'2025-01-15T10:48:40.793' AS DateTime), CAST(N'2025-01-15T10:48:40.793' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5017, 5012, N'd3f8eddebe8747679dfed801d1fd7a88.png', CAST(N'2025-01-15T10:48:40.793' AS DateTime), CAST(N'2025-01-15T10:48:40.793' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5020, 5014, N'f0c61d530a124fffa9b9e5e18bb5a1d7.png', CAST(N'2025-01-15T10:52:21.120' AS DateTime), CAST(N'2025-01-15T10:52:21.120' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5021, 5013, N'e5ce047931df49339a07af99a255acaa.png', CAST(N'2025-01-15T11:26:43.823' AS DateTime), CAST(N'2025-01-15T11:26:43.823' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (5022, 5013, N'874c156b8099452db215f08d11017e52.png', CAST(N'2025-01-15T11:26:43.823' AS DateTime), CAST(N'2025-01-15T11:26:43.823' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10000, 10000, N'430b06263e644689b3b60ca0a67e611d.png', CAST(N'2025-01-15T10:18:34.563' AS DateTime), CAST(N'2025-01-15T10:18:34.563' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10001, 10000, N'280bd094fe0e4a02ae91ec24829bf25f.png', CAST(N'2025-01-15T10:18:34.563' AS DateTime), CAST(N'2025-01-15T10:18:34.563' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10002, 10000, N'ba0472b635274b0cba96e3e12722f524.png', CAST(N'2025-01-15T10:18:34.563' AS DateTime), CAST(N'2025-01-15T10:18:34.563' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10003, 10000, N'00cfb52b30e34b9c82e4b1c5ff5b4e31.png', CAST(N'2025-01-15T10:18:34.563' AS DateTime), CAST(N'2025-01-15T10:18:34.563' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10004, 10001, N'0250c022dc434dc6b3ca12603b087d6c.png', CAST(N'2025-01-15T10:22:36.527' AS DateTime), CAST(N'2025-01-15T10:22:36.527' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10005, 10002, N'e3120c11238a438896c6586c0a884dde.png', CAST(N'2025-01-15T10:33:53.293' AS DateTime), CAST(N'2025-01-15T10:33:53.293' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10006, 10003, N'1f29ec19e5df4a32a93270a42487345e.png', CAST(N'2025-01-15T10:37:23.153' AS DateTime), CAST(N'2025-01-15T10:37:23.153' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10007, 10004, N'c1eb4c1a00e84139b7934a6c7feb1d4c.png', CAST(N'2025-01-15T10:38:54.963' AS DateTime), CAST(N'2025-01-15T10:38:54.963' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10008, 10004, N'71b39cb9f21b470797d90e407497298c.png', CAST(N'2025-01-15T10:38:54.963' AS DateTime), CAST(N'2025-01-15T10:38:54.963' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10009, 10004, N'ded12dbfc7f4445980ce7bc5b59ede30.png', CAST(N'2025-01-15T10:38:54.963' AS DateTime), CAST(N'2025-01-15T10:38:54.963' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10010, 10005, N'f4ab995ca17f4b629d0a791dec489b86.png', CAST(N'2025-01-15T10:55:55.580' AS DateTime), CAST(N'2025-01-15T10:55:55.580' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10011, 10006, N'c47bfe30e5e84e7e9c79a29327675e48.png', CAST(N'2025-01-15T10:57:45.203' AS DateTime), CAST(N'2025-01-15T10:57:45.203' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10012, 10007, N'dfe7b0bda16740b4abf001ad54a4a130.png', CAST(N'2025-01-15T10:59:02.040' AS DateTime), CAST(N'2025-01-15T10:59:02.040' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10013, 10008, N'0da625688b8d4a91b1078ad5aa834770.png', CAST(N'2025-01-15T11:01:20.497' AS DateTime), CAST(N'2025-01-15T11:01:20.497' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10014, 10009, N'41532b24077f4326aa9da8784b9b3055.png', CAST(N'2025-01-15T11:05:27.083' AS DateTime), CAST(N'2025-01-15T11:05:27.083' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10015, 10010, N'adfc23abbdeb4c0aa4ce8a137f62e328.png', CAST(N'2025-01-15T11:10:49.233' AS DateTime), CAST(N'2025-01-15T11:10:49.233' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10016, 10011, N'3b49bdbda3b3421fafa76c5dd75c3773.png', CAST(N'2025-01-15T11:12:29.210' AS DateTime), CAST(N'2025-01-15T11:12:29.210' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10017, 10012, N'bd5cd10323f947ec8bf72cc4985a8a62.png', CAST(N'2025-01-15T11:13:49.513' AS DateTime), CAST(N'2025-01-15T11:13:49.513' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10018, 10013, N'1f742bb359654ee885e40bea93c67ec2.png', CAST(N'2025-01-15T11:16:12.070' AS DateTime), CAST(N'2025-01-15T11:16:12.070' AS DateTime))
GO
INSERT [dbo].[ProductImages] ([Id], [ProductId], [Path], [CreatedAt], [UpdatedAt]) VALUES (10019, 10014, N'5ce02613bf39422a9fa165e5613429dd.png', CAST(N'2025-01-15T11:17:12.907' AS DateTime), CAST(N'2025-01-15T11:17:12.907' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (1, 1, 1, N'Apple iPhone 16 Pro 128G', 35769, N'驚豔的鈦金屬設計。iPhone 16 Pro 採用堅固又輕盈的鈦金屬設計，配備更大的 6.3 吋超 Retina XDR 顯示器，以及最新一代超瓷晶盾，材質堅硬程度是任何智慧型手機玻璃的 2 倍，耐用不在話下。
相機控制一把罩。相機控制讓你更輕鬆快速地取用縮放或景深等相機工具，秒拍完美大作。
非凡照片。有了更先進的 4800 萬像素超廣角相機，無論拍攝細膩的微距或壯闊的廣角照片，驚豔細節再上新境界。想從更遠處拍攝更銳利的影像？5 倍望遠相機讓你輕鬆完成。
Pro 影片。4800 萬像素 Fusion 相機支援 4K 120 fps 杜比視界，拍攝影片再上新境界；錄音室等級四麥克風，實現更佳的錄音品質。把 Pro 工作室放進你口袋。
攝影風格。最新一代攝影風格給你比以往更大的創作靈活度，讓每一張照片都更有你的風格。歸功於先進的影像管線，你可隨時撤回，在各個風格中變來換去。
A18 Pro 的強悍威力。A18 Pro 晶片，驅動相機控制等先進的照片和影片功能，並為 3A 遊戲帶來卓越出色的繪圖處理表現。
電池續航力突飛猛進。iPhone 16 Pro 帶來驚人的能源效率表現，影片播放時間最長可達 27 小時。
你可透過 USB-C 充電，也能貼上 MagSafe 充電器來體驗更快捷的無線充電。
自訂你的 iPhone。有了 iOS 18，主畫面圖像的色調由你隨心調整。重新設計的照片 app 讓你更快找出你喜愛的照片。你還可為 iMessage 訊息中的任何單字、短句或表情符號添加有趣的動畫效果。
至關重要的安全功能。有了車禍偵測功能，iPhone 可偵測嚴重車禍，並在你無法求救時為你撥打求救電話。', CAST(N'2025-01-14T23:51:23.147' AS DateTime), CAST(N'2025-01-14T23:51:23.147' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (2, 1, 2, N'GIGABYTE 技嘉 GeForce RTX 4080 SUPER WINDFORCE V2 16G顯示卡', 35030, N'全新NVIDIA Ada Lovelace架構SM:最高2倍效能與電源效率
第四代Tensor核心:最高2倍AI效能表現
第三代RT核心:最高2倍光線追蹤效能表現
採用 GeForce RTX™ 4080 SUPER繪圖晶片
內建16GB GDDR6X 256位元記憶體
技嘉風之力散熱系統
雙BIOS模式
金屬背板造型設計', CAST(N'2025-01-14T23:55:58.453' AS DateTime), CAST(N'2025-01-14T23:55:58.453' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (3, 1, 2, N'SONY 索尼 WH-1000XM5 主動式降噪旗艦 藍芽耳機(頂級降噪 極真音質 配戴舒適)', 9900, N'HD 降噪處理器 QN1 和 V1 整合處理器，打造無干擾的聆聽體驗
全自動個人降噪最佳化功能與氣壓優化技術
30mm 特殊設計驅動單體創造超凡音質
2x2 波束成形麥克風和 AI 減噪系統實現卓越的無噪音通話
超舒適輕量的「柔軟貼合皮革」', CAST(N'2025-01-14T23:59:56.470' AS DateTime), CAST(N'2025-01-14T23:59:56.470' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (4, 1, 6, N'LG 樂金 19公斤+16公斤◆WashTower AI智控洗乾衣機(WD-S1916B)', 89900, N'※洗衣行程：6項 (標準、被子、柔洗/羊毛、高溫去污、快洗、雲端客製)
※乾衣行程：6項 (標準、被子、柔洗/羊毛、輕拍除塵、少量快乾、雲端客製)
※脫水轉速：1100/1000/800/600/400
※洗衣溫度(℃)：冷水/30/40/50/65
※筒內燈設計
※預約時間、剩餘時間、錯誤訊息顯示
※預約定時：3-19 小時
※兒童鎖 / 門鎖 控制安全系統設計
※洗衣機保養：筒槽殺菌
※乾衣機保養：自動／手動冷凝器雙重清潔、筒槽清潔
        
※輸入電源：110V/60HZ        
※注意事項：請勿使用一條延長線接2台裝置        
***多台廢四機回收、拆卸費用依現場水電報價為主***
為維護修費者保固協議，安裝類商品下訂後約配，約配時間不得超過七天。約定安裝的時間超過工班聯繫七天後，廠商有權取消訂單。


※以上規格資料若有任何錯誤，以原廠所公佈資料為準
※其他規格請參閱商品介紹說明', CAST(N'2025-01-15T00:03:01.973' AS DateTime), CAST(N'2025-01-15T00:03:01.973' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5, 1, 6, N'Philips 飛利浦 77型4K 120Hz OLED Google TV 智慧聯網顯示器(77OLED789)', 77777, N'款式平面

類型OLED

解析度4K

尺寸77型

適用於HDMIHDMI2.0HDMI2.1USB2.0其他

功能WIFI傳輸智慧聯網語音聲控藍芽遙控場景模式android tvDisney+NetflixYouTube愛奇藝手機平板鏡射杜比音效

螢幕更新率120Hz

保固期3年保固期

原廠三年保固，商業/公共場所用途一年保固(內容以原廠規定為主)

商品規格請輸入規格

認證字號商檢字號：R33037

NCC字號：CCAH22Y10070T4', CAST(N'2025-01-15T10:32:59.227' AS DateTime), CAST(N'2025-01-15T10:32:59.227' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (6, 2, 7, N'舒潔 棉柔舒適抽取衛生紙100抽x72包', 1069, N'商品特色
．全新升級水波立體壓紋，一擦即淨，柔韌不易破
．紙質棉柔舒適，不易起屑、不易飛紙灰，潔淨又安心
．100%原生紙漿，快速分散，安心丟馬桶
商品規格
商品品名：【舒潔】棉柔舒適抽取衛生紙
商品重(容)量/規格：110抽x12包x6串/箱
類型：2層衛生紙
保存期限：5年
產地：台灣
商品尺寸：18mmx19mm', CAST(N'2025-01-15T10:54:50.577' AS DateTime), CAST(N'2025-01-15T10:54:50.577' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (7, 2, 7, N'韓國HAPPYCALL 鈦電漿IH耐蝕不沾鍋30cm雙鍋組(30cm深炒鍋/平底鍋/鍋蓋 電磁爐適用雙鍋款)', 2380, N'	
● 品名/ 型號
【套組】HAPPYCALL 鈦電漿深炒鍋 30cm*1 + HAPPYCALL鈦電漿平底鍋30cm*1 + HAPPYCALL 氣壓閥玻璃蓋 30cm*1

● 明細/材質/包裝
鍋體
不鏽鋼、鋁、鈦
內部塗層：鈦
手把:電木
外部：高密度陶瓷

玻璃蓋
材質：強化玻璃
把手：電木

● 規格 / 尺寸
深炒鍋 / 直徑約30cm / 約1.2kg
平底鍋 / 直徑約30cm / 約1.1kg
玻璃蓋 / 直徑約30cm

● 產地 / 製造商
韓國 / (株)HAPPYCALL', CAST(N'2025-01-15T10:57:34.853' AS DateTime), CAST(N'2025-01-15T10:57:34.853' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (8, 2, 9, N'Nespresso Ispirazione Firenze義式經典阿佩奇歐咖啡膠囊(10顆/條', 190, N'義式經典阿佩奇歐是以帶有麥芽香味的哥斯大黎加阿拉比卡咖啡豆為基底，在短時間深度烘焙後會轉變為可可般的香氣，成就這款咖啡的極致口感；極細緻研磨與調配的份量，讓這款咖啡的口感變得極為滑順、香醇，如同文藝復興時期的佛羅倫斯一般，散發迷人魅力。於 1993 年推出，時至今日仍是一款屢獲消費者青睞的咖啡。

萃集南北義之大成，融合北義淺焙風味與南義深焙口感，打造出義式經典阿佩奇歐向這座咖啡文化城市致敬。短時間的深度烘焙處理方式，讓固有的麥芽香氣，在經過烘焙後將轉化成鮮明可可香，為這款咖啡賦予高貴氣息。

義式經典阿佩奇歐口感醇厚綿密，帶有鮮明的烘焙與可可香味。咖啡油脂為這款咖啡更添絲絨般的滑順質地，令人難以抗拒。堪稱咖啡藝術的顛峰之作。

', CAST(N'2025-01-15T11:00:48.770' AS DateTime), CAST(N'2025-01-15T11:00:48.770' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (9, 2, 9, N'灣仔碼頭 手工水餃(高麗菜)', 248, N'1.商品組合/規格：灣仔碼頭手工水餃(40入裝)
2.商品品名：灣仔碼頭手工水餃
3.商品重(容)量：20~40入裝
4.內容物成分(如含有豬、牛成分請加註國別)：高麗菜豬肉—高麗菜、小麥粉、水、豬肉、豬背脂、洋蔥、醬油[水、鹽、非基因改造黃豆、小麥、砂糖、酒精、焦糖色素、轉化液糖(蔗糖、水)、調味劑(琥珀酸二鈉)、檸檬酸鈉、糊精、甜味劑(甘草萃)、調味劑(DL-蘋果酸)]、麻油、調味料(鹽、味精、糖、馬鈴薯澱粉、白胡椒粉)、木薯澱粉、鹽、白砂糖 韭菜豬肉—小麥粉、韭菜、水、豬肉、豬背脂、高麗菜、醬料{醬油[水、鹽、非基因改造黃豆、小麥、砂糖、焦糖色素、酒精、轉化液糖(蔗糖、水)、調味劑(琥珀酸二鈉)、檸檬酸鈉、糊精、甜味劑(甘草萃)、調味劑(DL-蘋果酸)]、魚露(鯷魚、水、鹽、砂糖)}、蛋液、麻油、調味料(鹽、味精、糖、馬鈴薯澱粉、白胡椒粉)、木薯澱粉、鹽 玉米豬肉—小麥粉、玉米粒、水、豬肉、高麗菜、豬背脂、洋蔥 、紅蘿蔔、醬油[水、鹽、非基因改造黃豆、小麥、砂糖、酒精、焦糖色素、轉化液糖(蔗糖、水)、調味劑(琥珀酸二鈉)、檸檬酸鈉、糊精、甜味劑(甘草萃)、調味劑(DL-蘋果酸)]、調味料(鹽、味精、糖、馬鈴薯澱粉、白胡椒粉)、麻油、木薯澱粉、鹽
5.食品添加物名稱：以實際包裝為主
6.原產地(國)：台灣
7.製造廠商或國內負責廠商名稱：台灣通用磨坊股份有限公司
8.製造廠商或國內負責廠商地址：220 新北市板橋區中山路一段156號8樓
9.製造廠商或國內負責廠商電話：0800-056-118', CAST(N'2025-01-15T11:04:28.323' AS DateTime), CAST(N'2025-01-15T11:04:28.323' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10, 2, 13, N'萊萃美 Omega-3 魚油軟膠囊(200錠/瓶)', 1374, N'1.商品組合：Nature Made Omega-3 魚油軟膠囊
2.商品規格：200錠/瓶
3.商品品名：Nature Made Omega-3 魚油軟膠囊
4.商品重(容)量：200錠/瓶
5.內容物名稱(成分)：魚油(鯷魚、沙丁魚、鯖魚)、混合濃縮生育醇(抗氧化劑)
膠囊殼：明膠(豬來源)，甘油，水
6.食品添加物名稱：詳見產品包裝
7.原產地(國)：美國
8.製造廠商或國內負責廠商名稱：好市多股份有限公司
9.製造廠商或國內負責廠商地址：高雄市中華五路656號
10.製造廠商或國內負責廠商電話：449-9909(手機撥打請加02)
11.以消費者收受日算起，至少距有效日期前?日以上：詳見產品包裝
12.食品業者登錄字號：E-196972798-00000-9
13.投保產品責任險字號：詳見產品包裝
', CAST(N'2025-01-15T11:05:58.367' AS DateTime), CAST(N'2025-01-15T11:05:58.367' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (11, 3, 15, N'CHANEL 香奈兒 經典菱格粒紋牛皮仿舊金鍊雙層手提/斜背包(黑色AS3982C-BLK-GPN)', 229330, N'．商品品牌：CHANEL
．商品材質：小牛皮
．商品產地：ITALY
．商品尺寸：約 長19cm X 高 13cm X 寬6cm｜提把長約5cm｜鍊帶長約115cm
．內層格式：轉釦開口；內貼袋X1
．商品配件：原廠包裝盒｜原廠防塵套
', CAST(N'2025-01-15T11:11:39.637' AS DateTime), CAST(N'2025-01-15T11:11:39.637' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (12, 3, 15, N'PRADA 普拉達 Prada 銀色三角牌LOGO再生尼龍皮革邊飾斜背包(黑)', 53804, N'品牌：PRADA
外材質：再生尼龍/Saffiano皮革
內材質：再生尼龍
商品來源：歐洲平行輸入
尺寸：底長28.5x上長27x寬6x高24x斜背長85-132(可調) cm
規格：拉鍊內袋x1 拉鍊外袋x1
開口方式：拉鍊式
底珠：無
可否放A4：否
配件：防塵袋', CAST(N'2025-01-15T11:13:00.513' AS DateTime), CAST(N'2025-01-15T11:13:00.513' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (13, 3, 15, N'Louis Vuitton 路易威登 Victorine錢包', 26666, N'．商品材質：牛皮
．商品產地：(依品牌吊卡、內裡產地標標示實際產地為主)
．商品尺寸：

約長12X寬2.5X高9.5(以實際出貨為主)', CAST(N'2025-01-15T11:16:42.433' AS DateTime), CAST(N'2025-01-15T11:16:42.433' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (14, 3, 15, N'Hermes 愛馬仕 Mini Lindy 19cm TC牛皮轉釦寬編織背帶兩用包(18大象灰/W刻/金釦)', 449820, N'品牌：Hermes愛馬仕
商品型號：LDMINI-AL-TC-W-G
商品材質：牛皮
商品尺寸：約長19cm 寬 12 高 10cm
商品來源：100% HERMES專櫃全新真品
商品配件：原廠紙盒&防塵套&購買影本
商品配送：親送
商品圖檔顏色因電腦螢幕設定差異會略有不同，以實際商品顏色為準，請見諒。
', CAST(N'2025-01-15T11:26:10.133' AS DateTime), CAST(N'2025-01-15T11:26:10.133' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (15, 3, 15, N'BURBERRY 巴寶莉 BURBERRY Lola經典立體金字LOGO小羊皮格紋縫線拼棉織布磁扣鏈袋斜背包(小/奶茶)', 74439, N'品牌：BURBERRY
材質：小羊皮/棉織布
商品來源：歐洲平行輸入
尺寸：底長23x底寬5x側高13x背帶長107 cm
規格：功能內帶x1
配件：原廠防塵袋', CAST(N'2025-01-15T11:27:27.463' AS DateTime), CAST(N'2025-01-15T11:27:27.463' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5000, 5000, 9, N'乖乖桶 水果軟糖', 289, N'閃亮亮的乖乖桶，讓你成為最耀眼的一顆星！
陪小朋友一起長大的乖乖軟糖
素食(含明膠，牛來源)
成分：
葡萄糖漿、砂糖、水、明膠(牛來源)、甜味劑(D-山梨醇)、檸檬酸、乳酸、香料(草莓香料、蘋果香料、鳳梨香料、橘子香料、葡萄香料、檸檬香料)、著色劑(食用黃色四號、食用黃色五號、食用紅色四十號、食用藍色一號)。
本產品生產製程廠房，其設備或生產管線有處理：牛奶及其產品', CAST(N'2025-01-15T10:17:25.690' AS DateTime), CAST(N'2025-01-15T10:17:25.690' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5001, 5000, 9, N'新貴派-Mini迷你花生', 135, N'台灣最受歡迎餅乾
mini版 一口入好吃不留痕跡
辦公室必備!! 小資新貴午茶首選
*過敏原註記：本產品含牛奶、堅果種子類製品及大豆製品，對特殊過敏體質者可能導致產生過敏症狀。 本產品製造廠房，其設備有處理 芒果、蛋、堅果類、芝麻、含麩質之穀物及其製品。', CAST(N'2025-01-15T10:18:40.030' AS DateTime), CAST(N'2025-01-15T10:18:40.030' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5002, 5000, 9, N'義美 美味原味蘇打餅', 59, N'義美品牌，安心指標！
提供您品嚐蘇打餅乾單純的美味、清爽又無負擔
外盒設計亮眼、內為獨立小包裝', CAST(N'2025-01-15T10:19:41.643' AS DateTime), CAST(N'2025-01-15T10:19:41.643' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5003, 5000, 10, N'【桌遊】誰是牛頭王25週年版 TAKE 6!25th Anniversary中文版', 501, N'玩家們一致推薦！絕對讓你感到刺激、出乎意料！
可以2人就開戰，也可以10人一起同樂！歡迎挑戰∼
25週年版新增七種進階規則！使用進階規則僅適用2-8人。', CAST(N'2025-01-15T10:22:05.297' AS DateTime), CAST(N'2025-01-15T10:22:05.297' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5004, 5000, 10, N'【桌上遊戲】浮言浪語 Fluxx中文版', 416, N'朝令夕改，瞬息萬變！
每張新規則都會改變遊戲的玩法！
行動牌讓你撼動大局！
【遊戲配件】
100張紙牌
1份說明書
內含規則說明書（中文）', CAST(N'2025-01-15T10:24:20.760' AS DateTime), CAST(N'2025-01-15T10:24:20.760' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5005, 5001, 10, N'【桌上遊戲】矮人礦坑Saboteur-中文版 本月主打星', 586, N'玩家一致推薦的聚會遊戲！
是朋友？是敵人？這遊戲裡得要下點心機多點觀察力，才能致勝喔?
適用年齡：8歲以上', CAST(N'2025-01-15T10:26:39.603' AS DateTime), CAST(N'2025-01-15T10:26:39.603' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5006, 5001, 16, N'黃仁勳傳：輝達創辦人如何打造全球最搶手的晶片', 395, N'＜內容簡介＞

 ☆ 全球 第一本黃仁勳授權採訪傳記
 ☆ 搶先英文版上市，收錄全球獨家繁中版作者序

 台灣出生、最受推崇的矽谷科技公司執行長
 1993年，黃仁勳與友人在矽谷一間連鎖餐廳創立輝達，擔任執行長；三十多年後，輝達躋身全球市值最高的公司之一，與蘋果匹敵，黃仁勳成為科技業任期最長的執行長，還曾是張忠謀欽點的台積電接班人選之一。

 引爆新工業革命的AI先驅
 輝達一鳴驚人的關鍵就在執行長黃仁勳的遠見卓識。十多年前，他看到一些科技研發結果的潛力，放膽把整間公司押注在AI上。本書作者獲得前所未有的機會，貼身採訪黃仁勳，以及輝達的共同創辦人、高階主管、投資人、現任與前任員工、黃仁勳的友人與競爭對手，詳實記錄這間公司崛起的經過，並描繪黃仁勳的專注、執著、強大的感召力，以及強悍的領導風格。如今，黃仁勳已是矽谷最有影響力的人。沒有黃仁勳，輝達無法達到如今的地位；沒有黃仁勳，AI的發展將延遲十年。

 《黃仁勳傳》細數輝達如何從一間生產電路板配件的公司，成為價值數億美元超級電腦的供應商，站上科技霸主地位。本書描述固執的企業家不顧華爾街的質疑，堅持提升運算能力，終於登上全球富豪榜的故事。這也是電腦架構改革的故事，描述一小撮叛逆的工程師如何發動這場變革。更重要的是，這也是關於AI未來的故事，也就是黃仁勳所說的「下一次工業革命」──創新晶片技術將帶來超擬真的虛擬化身、自主移動機器人、自駕車，以及隨需生成的新型電影、藝術與書籍。

 想要了解黃仁勳矛盾的人格特質與過人的洞察力、想要了解輝達與眾不同的企業精神與商業優勢、想要了解AI的軟體與硬體如何結合並創造出驚人的運算能力，這本書滿載最完整的資訊與解答。', CAST(N'2025-01-15T10:29:15.713' AS DateTime), CAST(N'2025-01-15T10:29:15.713' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5007, 5001, 16, N'拓樸學超入門 ：從克萊茵瓶到宇宙的形狀', 253, N'解釋超導體、量子力學
	2016年諾貝爾物理學獎，就是以拓樸概念解開物質的奧秘！
	馬克杯和甜甜圈竟然是相同的形狀？
	如何一筆畫完成柯尼斯堡七橋？
	映射、流形與扭結
	從曲面幾何猜想宇宙形狀
	解開百年大謎——龐加萊猜想！
	這些都可以用拓樸學一一解密！

', CAST(N'2025-01-15T10:30:44.597' AS DateTime), CAST(N'2025-01-15T10:30:44.597' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5008, 5001, 16, N'基礎線性代數（5版）', 470, N'本書內容編排偏向矩陣及向量空間、線性轉換，在理論上力求精簡、簡明易懂，每章之例題、習題具啟發性，並精選了基本的證明問題，易於讓讀者能融會貫通。書後並後附有習題詳解，不但能讓您在短期內學好基礎，也能提升您對線性代數的興趣。
本書適用於大專、技術學院、大學之電子、電機、工業管理、工業工程、資訊、企管等系之「線性代數」和「管理數學」課程使用。 ', CAST(N'2025-01-15T10:31:39.277' AS DateTime), CAST(N'2025-01-15T10:31:39.277' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5009, 5001, 16, N'第一次學工程數學就上手（1）微積分與微分方程式（4版）', 225, N'＜內容簡介＞
◎◎◎    SOP閃通教材   ◎◎◎
老師在解題時，會把題目的標準解題流程（SOP）記在頭腦裡，
依此標準解題流程（SOP）解給學生看，可是並不是每個學生
看完老師教的標準解題流程（SOP）後，就能記住此標準解題流程（SOP）。
本書是將每個題型的標準解題流程（SOP）寫下來，
學生只要將題目的數值代入標準解題流程(SOP)內，
就可以把該題目解答出來。
等學生學會了後，此SOP就可以丟掉了。', CAST(N'2025-01-15T10:32:38.560' AS DateTime), CAST(N'2025-01-15T10:32:38.560' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5010, 5002, 11, N'100%精梳棉兩用被床包組', 1412, N'▼商品內容
被套內綁繩：四角，可以綁棉被胎固定使用，使被胎不易滑動
隱密式床包收縮鬆緊帶：有【床頭床尾ㄇ字型車工、採用直徑1.5cm高彈力鬆緊帶】
可承受之床墊厚度：35±2 公分【市售獨立筒床墊皆可適用】
產地：台灣

▼清潔方式
可水洗 (水溫請勿超過30度C) / 可乾洗 / 不可漂白 / 不可烘乾
使用大型洗衣袋清洗，可保持色澤鮮明，更不易造成勾紗等現象
深色商品初次下水清洗會有量染料溶解於水中屬正常情形，請勿與淺色衣物一同清洗
', CAST(N'2025-01-15T10:37:35.163' AS DateTime), CAST(N'2025-01-15T10:37:35.163' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5011, 5002, 11, N'人體工學網椅', 8600, N'椅子整體尺寸：W66 x D66 x H 111-121 cm 
椅座尺寸： 47.5 cm 
椅背高度： 50 cm 
椅座可調整高度： 上下10 cm 無段 
頭枕調整高度：上下調整10 cm、並有前後角度調整 
椅座扶手調整高度： 上下調整10 cm 每1cm 1段 
後躺仰角度：背部傾仰27度，共有4段 
適用於：身高155~170cm / 體重120kg以下 
', CAST(N'2025-01-15T10:39:09.060' AS DateTime), CAST(N'2025-01-15T10:39:09.060' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5012, 5002, 11, N'夾式彎彎閱讀書燈', 600, N'品 牌：美國 CARSON
材 質：LED、樹脂、鐵、泡棉
尺 寸：長 10 x 寬 4.3 x 高 2 cm
產 地：授權中國大陸生產', CAST(N'2025-01-15T10:48:40.793' AS DateTime), CAST(N'2025-01-15T10:48:40.793' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5013, 5002, 11, N'木紋自黏壁紙', 269, N'產地：中國
尺寸：45cm X 200cm 
材質：PVC 
【注意事項】 
1. 網頁展示圖片顏色，因拍攝角度與個人電腦螢幕設定關係，會跟實品略有差異，實際顏色以出貨實品為主。 
2. 請注意!!如壁面原本水泥漆施工不佳或老化粉化，當貼上再撕下時可能導致剝落沾黏，可能無法再黏緊，貼前請留意。 
3. 本商品背膠非弱黏性設計，不可以重覆黏貼使用。', CAST(N'2025-01-15T10:49:47.387' AS DateTime), CAST(N'2025-01-15T11:26:43.817' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (5014, 5002, 11, N'犬用心臟護理狗飼料', 3250, N'【原料】


高品質蛋白質及細心挑選的原料來源


全穀粒玉米、豬肉脂肪、黃豆蛋白萃取物、雞肉副產品粉、雞肝香料、乳酸、乾燥蛋製品、纖維素粉、檸檬酸鉀、磷酸二鈣、碳酸鈣、天然香料、氯化膽鹼、黃豆油、左旋離胺酸、維生素 (維生素E添加劑、抗壞血酸多聚磷酸酯(維生素C 來源)、菸鹼酸添加劑、維生素B1、維生素A添加劑、泛酸鈣、維生素B12添加劑、維生素B6、核黃素添加劑、生物素、葉酸、維生素D3添加劑)、牛磺酸、礦物質 (硫酸亞鐵、氧化鋅、硫酸銅、氧化錳、碘酸鈣、亞硒酸鈉)、DL-蛋胺酸、氧化鎂、左旋肉酸素、添加綜合維生素E類以保鮮、天然香料、左旋色胺酸、β-胡蘿蔔素', CAST(N'2025-01-15T10:52:21.120' AS DateTime), CAST(N'2025-01-15T10:52:21.120' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10000, 10000, 9, N'凍乾草莓 牛軋糖烘焙原料草莓脆', 195, N'一年四季，享受莓好甜蜜 
冷凍乾燥．非油炸果乾，天然少負擔
「甜心草莓」為酸甜酥脆的凍乾果乾， 
無添加香料/色素/防腐劑/甜味劑
採用太空食品「冷凍．真空乾燥技術」，
保留草莓的天然纖維、營養及風味，
並可長時間常溫保存，隨時享受草莓風味！', CAST(N'2025-01-15T10:18:34.563' AS DateTime), CAST(N'2025-01-15T10:18:34.563' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10001, 10000, 9, N'瑞幸咖啡法國進口意式濃縮膠囊咖啡10顆/盒', 386, N'Luckin(瑞幸) 咖啡膠囊(每盒10顆)

成份：百分之百（100%）咖啡豆

原廠註冊地：法國', CAST(N'2025-01-15T10:22:36.527' AS DateTime), CAST(N'2025-01-15T10:22:36.527' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10002, 10000, 9, N'天天Bites綜合堅果禮盒(22包/盒)', 399, N'【翠菓子 天天Bites綜合堅果禮盒】

 
 -原味吃的到新鮮 走過50年的營養美味-

 
★杏仁、核桃、蔓越莓乾、葡萄乾、南瓜籽、黃豆、黑豆  營養滿分!!

 
★用心挑選原料與果物

 
★顆粒飽滿 果實散發淡淡清香

 
★小包裝攜帶便利', CAST(N'2025-01-15T10:33:53.293' AS DateTime), CAST(N'2025-01-15T10:33:53.293' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10003, 10000, 9, N'澎湖名產奶油花生酥 200g 全素', 115, N'★澎湖老店直送，遊客必買的名產

 
★堅持傳統手工製作，不添加防腐劑

 
★採用澎湖當地品質最好的花生

 
★香脆可口，營養豐富', CAST(N'2025-01-15T10:37:23.153' AS DateTime), CAST(N'2025-01-15T10:37:23.153' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10004, 10000, 9, N'鳳梨酥禮盒 10入', 409, N'台中必買伴手禮~鳳梨酥，外酥內軟，台中人從小吃到大的好滋味，令人念念不忘的傳統美食。

 
 

 
口味：鳳梨諧音〝旺來〞為饋贈客戶親友最佳禮品，皮酥餡軟有鳳梨香甜口感', CAST(N'2025-01-15T10:38:54.963' AS DateTime), CAST(N'2025-01-15T10:38:54.963' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10005, 10001, 14, N'口袋雙色修容打亮盤 7g 國際航空版', 799, N'口袋雙色修容打亮盤 7g

造山小金盒，天才修容組合
生薑高光 X OMEGA 兩大修容天花板正式聯姻', CAST(N'2025-01-15T10:55:55.580' AS DateTime), CAST(N'2025-01-15T10:55:55.580' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10006, 10001, 14, N'設計師微霧唇膏3g (國際航空版)', 1050, N'中文品名：TOM FORD Lip Color Matte 設計師微霧唇膏#100 100(3g)-國際航空版
規格：3g', CAST(N'2025-01-15T10:57:45.203' AS DateTime), CAST(N'2025-01-15T10:57:45.203' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10007, 10001, 14, N'透氣定妝蜜粉 05水蜜桃膚', 400, N'透氣定妝蜜粉 05水蜜桃膚 

含天然礦物複合物：粉末如空氣般輕薄細膩，親膚性佳，使用更服貼，妝效更自然。
透氣超微粒子：可吸附多餘油脂，令肌膚呈現陶瓷般細膩光滑的零毛孔美肌，輕盈透氣不堵塞毛孔。
定妝超持久：附著力強，定妝效果一整天；無添加刺激性香味。', CAST(N'2025-01-15T10:59:02.040' AS DateTime), CAST(N'2025-01-15T10:59:02.040' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10008, 10001, 14, N'裸光蜜粉餅(小白餅) 10g 國際航空版', 789, N'【NARS】裸光蜜粉餅(小白餅) 10g

 
 

 
✨無重力輕盈底妝，完美柔焦，超持久定妝

 
 

 
✨細緻粉質轉化透明妝感

 
 

 
✨獨家控光科技如美肌濾鏡底妝

 
 

 
✨隱藏細紋、皺紋、毛孔', CAST(N'2025-01-15T11:01:20.497' AS DateTime), CAST(N'2025-01-15T11:01:20.497' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10009, 10001, 14, N'超強防水眼線筆(黑)*3+專用附蓋削筆器 8mm', 629, N'眼線筆：
1.兩分鐘立即形成防水 
2.防水不易暈染，卸妝容易
3.氣密筆蓋防止油分揮發
4.筆身不會吸油分，品質安定
5.德國原裝進口，買假一賠二
 
 

 
 削筆器：
 1.適用8mm直徑之口紅筆，刀片鋒利不易生鏽。
 2.盒蓋設計，乾淨好清潔，削完後即可放於包包內。
 3.德國原裝進口，買假一賠二', CAST(N'2025-01-15T11:05:27.083' AS DateTime), CAST(N'2025-01-15T11:05:27.083' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10010, 10002, 8, N'學習小馬桶-粉紅', 799, N'●寶寶自主學習小馬桶的外觀和感覺就和大人的一樣

 
●有助於寶寶舒適和自信地使用，進而輕鬆的轉換到使用真正的馬桶

 
●按壓把手有擬真的沖水聲

 
●可掀起的座墊和內置的面紙盒

 
●內含可拆卸且易清潔的便盆，媽媽整理好輕鬆，防滑底座設計', CAST(N'2025-01-15T11:10:49.233' AS DateTime), CAST(N'2025-01-15T11:10:49.233' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10011, 10002, 8, N'瞬吸舒爽紙尿褲 M(尿布箱購66片x3包)', 1122, N'經皮膚科醫學測試 有助維護皮膚狀態，幫助預防紅屁屁*

 
*經第三方醫學機構於皮膚科醫生盲性控制下之觀察性試驗

 
妙而舒 源自日本肌研究精神，專為台灣寶寶設計

 
隨寶寶漸漸長大，尿量變多同時活動力大增

 
★　立體瞬吸設計，能持續吸收整晚12小時大尿量，同時不殘留濕氣，小屁屁全天乾爽好舒適！

 
★　透氣大版型＆彈力腰圍合身設計，能柔軟貼附寶寶身形，左滾右趴也合身不漏！

 
★　尿布外層柔軟升級，親膚觸感減少勒痕產生，腿庫寶也好動不擔心！', CAST(N'2025-01-15T11:12:29.210' AS DateTime), CAST(N'2025-01-15T11:12:29.210' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10012, 10002, 8, N'金學兒樂HMO成長配方3-7歲1600gx1罐', 999, N'【神經鞘磷脂EX+S-HMO 串聯學習，加速統合學習力】1,2

 
掌握3歲前寶寶學習發展黃金期，瑞士研究發現提升學習力3

 
【600位兒科醫師推薦】4

 
全台600位兒科醫師推薦S-26金幼兒樂為寶寶學習力首選品牌

 
【萬名爸媽票選推薦 No.1幼兒配方】5

 
媽媽：“寶寶每個成長階段都在前段班”

 
本產品為3-7歲配方產品 *商品一經拆封，將無法進行退貨', CAST(N'2025-01-15T11:13:49.513' AS DateTime), CAST(N'2025-01-15T11:13:49.513' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10013, 10002, 8, N'5in1多功能學步車', 3105, N'【產品特點】
●品質優良、安全有保障
●讓寶寶能舒適安全學走路
●輕鬆拆卸功能，多功能使用cp值高', CAST(N'2025-01-15T11:16:12.070' AS DateTime), CAST(N'2025-01-15T11:16:12.070' AS DateTime))
GO
INSERT [dbo].[Products] ([Id], [ShopId], [CategoryId], [Name], [Price], [Info], [CreatedAt], [UpdatedAt]) VALUES (10014, 10002, 8, N'兒童耐磨防水鞋套', 309, N'1.長拉鏈鞋套65度大開口拉鏈，穿脫方便。

2.升級的防水鬆緊束口，無縫一體成型的設計，拒絕雨水進入。

3.防滑耐磨鞋底，適用多種濕滑地面。

4.卡通印花圖案，萌趣可愛。', CAST(N'2025-01-15T11:17:12.907' AS DateTime), CAST(N'2025-01-15T11:17:12.907' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Shops] ON 
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (1, N'shop001', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'鴻昌電子有限公司', N'T103133361', N'd73c9e43d0864dbb91ca0a5f542fbc5b.jpg', N'屏東縣內埔鄉華光巷86號', 0, CAST(N'2025-01-14T23:36:27.800' AS DateTime), CAST(N'2025-01-14T23:36:27.800' AS DateTime))
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (2, N'shop002', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'好便宜百貨商城', N'B235043295', N'15696a2aa1884671bff8fb287e730987.png', N'彰化縣鹿港鎮南橋巷83號7樓之9', 1, CAST(N'2025-01-15T10:50:07.770' AS DateTime), CAST(N'2025-01-15T10:50:07.770' AS DateTime))
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (3, N'shop003', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'Modern Trunk', N'G179482828', N'849fed057ceb4f3db43aac9f2feecb4d.png', N'臺北市萬華區漢口街２段85號', 1, CAST(N'2025-01-15T11:10:26.840' AS DateTime), CAST(N'2025-01-15T11:10:26.840' AS DateTime))
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (5000, N'shop5001', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'小華生活小舖', N'U252405688', N'9c65f41e528c41a780af24cad16deec8.png', N'新竹縣竹東鎮竹榮街33號之5', 1, CAST(N'2025-01-15T10:11:41.447' AS DateTime), CAST(N'2025-01-15T10:11:41.447' AS DateTime))
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (5001, N'shop5002', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'城品書局', N'D284421087', N'60ace2b0f79f472293af8d35482daefd.png', N'臺南市中西區康樂街15號', 1, CAST(N'2025-01-15T10:25:53.107' AS DateTime), CAST(N'2025-01-15T10:25:53.107' AS DateTime))
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (5002, N'shop5003', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'吾蔭涼品', N'X187364439', N'9c7ab126635d4ad98878e64a7cc3d079.png', N'桃園市中壢區大同路和平巷90號2樓', 1, CAST(N'2025-01-15T10:34:01.537' AS DateTime), CAST(N'2025-01-15T10:34:01.537' AS DateTime))
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (10000, N'orzorz002061', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'寶寶柑仔小鋪', N'P214769599', N'f259e1244ba34003af342037bbb0464b.png', N'新竹市北區經國路１段29號之20', 1, CAST(N'2025-01-15T10:09:15.490' AS DateTime), CAST(N'2025-01-15T10:09:15.490' AS DateTime))
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (10001, N'suke', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'森助玩妝', N'E260833899', N'2baf58ca58d040519a63d02685bc462d.png', N'雲林縣斗六市農場路28號之17', 1, CAST(N'2025-01-15T10:54:33.547' AS DateTime), CAST(N'2025-01-15T10:54:33.547' AS DateTime))
GO
INSERT [dbo].[Shops] ([Id], [Account], [EncryptedPassword], [Name], [IdentityCard], [Avatar], [Address], [Status], [CreatedAt], [UpdatedAt]) VALUES (10002, N'litter', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'禾子好物', N'Y265019090', N'73c8cdb5b8f14e72b9a9ac52ef9bee34.png', N'臺中市豐原區大仁街2號8樓之10', 1, CAST(N'2025-01-15T11:08:26.547' AS DateTime), CAST(N'2025-01-15T11:08:26.547' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Shops] OFF
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_GroupBuyings] FOREIGN KEY([GroupBuyingId])
REFERENCES [dbo].[GroupBuyings] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_GroupBuyings]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Members]
GO
ALTER TABLE [dbo].[Employee_Role_Rel]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role_Rel_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Employee_Role_Rel] CHECK CONSTRAINT [FK_Employee_Role_Rel_Employees]
GO
ALTER TABLE [dbo].[Employee_Role_Rel]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role_Rel_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Employee_Role_Rel] CHECK CONSTRAINT [FK_Employee_Role_Rel_Roles]
GO
ALTER TABLE [dbo].[GroupBuyings]  WITH CHECK ADD  CONSTRAINT [FK_GroupBuyings_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[GroupBuyings] CHECK CONSTRAINT [FK_GroupBuyings_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_GroupBuyings] FOREIGN KEY([GroupBuyingId])
REFERENCES [dbo].[GroupBuyings] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_GroupBuyings]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Members]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Shops] FOREIGN KEY([ShopId])
REFERENCES [dbo].[Shops] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Shops]
GO
ALTER TABLE [dbo].[Role_Function_Rel]  WITH CHECK ADD  CONSTRAINT [FK_Role_Function_Rel_Functions] FOREIGN KEY([FunctionId])
REFERENCES [dbo].[Functions] ([Id])
GO
ALTER TABLE [dbo].[Role_Function_Rel] CHECK CONSTRAINT [FK_Role_Function_Rel_Functions]
GO
ALTER TABLE [dbo].[Role_Function_Rel]  WITH CHECK ADD  CONSTRAINT [FK_Role_Function_Rel_Roles] FOREIGN KEY([Id])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Role_Function_Rel] CHECK CONSTRAINT [FK_Role_Function_Rel_Roles]
GO
ALTER TABLE [dbo].[Wishes]  WITH CHECK ADD  CONSTRAINT [FK_Wishes_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Wishes] CHECK CONSTRAINT [FK_Wishes_Members]
GO
ALTER TABLE [dbo].[Wishes]  WITH CHECK ADD  CONSTRAINT [FK_Wishes_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Wishes] CHECK CONSTRAINT [FK_Wishes_Products]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'數量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Carts', @level2type=N'COLUMN',@level2name=N'Quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分類名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顯示順序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'DisplayOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否啟用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'Enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加密後密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'EncryptedPassword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employees', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'功能名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Functions', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'團購價格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupBuyings', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小成團人數' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupBuyings', @level2type=N'COLUMN',@level2name=N'MinimumGroupSize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'團購說明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupBuyings', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'開始時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupBuyings', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'結束時間' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupBuyings', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否上架' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupBuyings', @level2type=N'COLUMN',@level2name=N'Enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加密後密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'EncryptedPassword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性別(0:女,1:男)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'電子信箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手機號碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'狀態(0:停用,1:啟用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否通過驗證' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'IsConfirmed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'驗證碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Members', @level2type=N'COLUMN',@level2name=N'ConfirmCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成交價格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'數量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'Quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'運送方式(1:到店取)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'ShippingMethod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'運送地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'ShippingAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'訂單狀態(0: 取消, 1: 參與中, 2: 成立, 3: 運送中, 4: 到貨, 5: 已取貨, 6: 未取貨)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款狀態(0:未付款,1:已付款)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'PaymentStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'運送狀態(0: 未出貨, 1: 已送達)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Orders', @level2type=N'COLUMN',@level2name=N'DeliveryStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'圖片路徑' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductImages', @level2type=N'COLUMN',@level2name=N'Path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原價' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品資訊' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'Info'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帳號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shops', @level2type=N'COLUMN',@level2name=N'Account'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'加密後密碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shops', @level2type=N'COLUMN',@level2name=N'EncryptedPassword'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商店名稱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shops', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身分證字號' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shops', @level2type=N'COLUMN',@level2name=N'IdentityCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'頭像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shops', @level2type=N'COLUMN',@level2name=N'Avatar'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商店地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shops', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'狀態(0:停用,1:啟用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shops', @level2type=N'COLUMN',@level2name=N'Status'
GO
