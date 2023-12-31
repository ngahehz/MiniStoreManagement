USE [master]
GO
/****** Object:  Database [ministore]    Script Date: 23-Nov-23 8:09:09 AM ******/
CREATE DATABASE [ministore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ministore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.NGAHZ\MSSQL\DATA\ministore.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ministore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.NGAHZ\MSSQL\DATA\ministore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ministore] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ministore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ministore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ministore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ministore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ministore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ministore] SET ARITHABORT OFF 
GO
ALTER DATABASE [ministore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ministore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ministore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ministore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ministore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ministore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ministore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ministore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ministore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ministore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ministore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ministore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ministore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ministore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ministore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ministore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ministore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ministore] SET RECOVERY FULL 
GO
ALTER DATABASE [ministore] SET  MULTI_USER 
GO
ALTER DATABASE [ministore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ministore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ministore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ministore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ministore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ministore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ministore', N'ON'
GO
ALTER DATABASE [ministore] SET QUERY_STORE = ON
GO
ALTER DATABASE [ministore] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ministore]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[ID] [varchar](50) NOT NULL,
	[USERNAME] [varchar](50) NOT NULL,
	[PASSWORD] [varchar](50) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[ID] [varchar](50) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[STATE] [varchar](50) NULL,
 CONSTRAINT [PK__category__3214EC27B14667F7] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[consumer]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[consumer](
	[ID] [varchar](50) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[GENDER] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[CELL] [varchar](50) NOT NULL,
 CONSTRAINT [PK__consumer__3214EC27734777CE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[ID] [varchar](50) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[GENDER] [nvarchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[CELL] [varchar](50) NOT NULL,
	[IMG] [varchar](50) NULL,
	[STATE] [varchar](50) NULL,
 CONSTRAINT [PK__employee__3214EC27C14AFEAA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[ID] [varchar](50) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[CATEGORY_ID] [varchar](50) NULL,
	[PROMOTION_ID] [varchar](50) NULL,
	[PROVIDER_ID] [varchar](50) NOT NULL,
	[PRICE] [decimal](10, 0) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[IMG] [varchar](50) NULL,
	[STATE] [varchar](50) NULL,
 CONSTRAINT [PK__product__3214EC27D61BDD74] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promotion]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promotion](
	[ID] [varchar](50) NOT NULL,
	[DISCRIPTION] [ntext] NOT NULL,
	[PERCENT_DISCOUNT] [float] NOT NULL,
	[START_DATE] [date] NOT NULL,
	[END_DATE] [date] NOT NULL,
	[STATE] [varchar](50) NOT NULL,
 CONSTRAINT [PK__promotio__3214EC27941028B7] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provider]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provider](
	[ID] [varchar](50) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[CELL] [varchar](50) NOT NULL,
	[ADDRESS] [nvarchar](50) NOT NULL,
	[EMAIL] [nvarchar](50) NOT NULL,
	[STATE] [nvarchar](50) NULL,
 CONSTRAINT [PK__provider__3214EC2752EA2326] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchase_invoice]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchase_invoice](
	[ID] [varchar](50) NOT NULL,
	[EMPLOYEE_ID] [varchar](50) NOT NULL,
	[DATE] [date] NOT NULL,
	[TOTAL_PAYMENT] [decimal](10, 0) NOT NULL,
	[PROVIDER_ID] [varchar](50) NOT NULL,
	[STATE] [varchar](50) NOT NULL,
 CONSTRAINT [PK__purchase__3214EC27C9F30652] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchase_invoice_detail]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchase_invoice_detail](
	[INVOICE_ID] [varchar](50) NOT NULL,
	[PRODUCT_ID] [varchar](50) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[PRICE] [decimal](10, 0) NOT NULL,
	[EXP] [date] NOT NULL,
	[STATE] [varchar](50) NOT NULL,
 CONSTRAINT [PK__purchase__29C25E7E400E7C89] PRIMARY KEY CLUSTERED 
(
	[INVOICE_ID] ASC,
	[PRODUCT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sales_invoice]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales_invoice](
	[ID] [varchar](50) NOT NULL,
	[EMPLOYEE_ID] [varchar](50) NOT NULL,
	[DATE] [date] NOT NULL,
	[TOTAL_PAYMENT] [decimal](18, 0) NOT NULL,
	[CONSUMER_ID] [varchar](50) NULL,
	[VOUCHER_ID] [varchar](50) NULL,
	[STATE] [varchar](50) NOT NULL,
 CONSTRAINT [PK__sale_inv__3214EC27947CD19E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sales_invoice_detail]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales_invoice_detail](
	[INVOICE_ID] [varchar](50) NOT NULL,
	[PRODUCT_ID] [varchar](50) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[PRICE] [decimal](18, 0) NULL,
 CONSTRAINT [PK__sale_inv__29C25E7E43D1A3A9] PRIMARY KEY CLUSTERED 
(
	[INVOICE_ID] ASC,
	[PRODUCT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stockroom]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stockroom](
	[ID] [varchar](50) NOT NULL,
	[PRODUCT_ID] [varchar](50) NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[EXP] [date] NOT NULL,
 CONSTRAINT [PK_stockroom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[voucher]    Script Date: 23-Nov-23 8:09:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[voucher](
	[ID] [varchar](50) NOT NULL,
	[CODE] [nvarchar](50) NOT NULL,
	[DISCRIPTION] [ntext] NOT NULL,
	[DISCOUNT_AMOUNT] [decimal](10, 0) NULL,
	[MIN_INVOICE_VALUE] [decimal](10, 0) NULL,
	[PERCENT_DISCOUNT] [float] NULL,
	[MAX_DISCOUNT] [decimal](10, 0) NULL,
	[START_DATE] [date] NOT NULL,
	[END_DATE] [date] NOT NULL,
 CONSTRAINT [PK__voucher__3214EC27A52AF992] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[admin] ([ID], [USERNAME], [PASSWORD], [NAME]) VALUES (N'100', N'nga', N'ngane123', N'thanhnga')
INSERT [dbo].[admin] ([ID], [USERNAME], [PASSWORD], [NAME]) VALUES (N'101', N's', N'123', N's')
GO
INSERT [dbo].[category] ([ID], [NAME], [STATE]) VALUES (N'100', N'Food', N'0')
INSERT [dbo].[category] ([ID], [NAME], [STATE]) VALUES (N'101', N'Drink', N'0')
INSERT [dbo].[category] ([ID], [NAME], [STATE]) VALUES (N'102', N'For Life', N'0')
INSERT [dbo].[category] ([ID], [NAME], [STATE]) VALUES (N'103', N'For me2', N'1')
GO
INSERT [dbo].[consumer] ([ID], [NAME], [GENDER], [DOB], [CELL]) VALUES (N'10000', N'tèo', N'Nam', CAST(N'2010-01-27' AS Date), N'0902222222')
INSERT [dbo].[consumer] ([ID], [NAME], [GENDER], [DOB], [CELL]) VALUES (N'10001', N'hi', N'Nam', CAST(N'2010-01-27' AS Date), N'0902226562')
INSERT [dbo].[consumer] ([ID], [NAME], [GENDER], [DOB], [CELL]) VALUES (N'10002', N'e', N'Nam', CAST(N'2010-01-27' AS Date), N'0953223542')
INSERT [dbo].[consumer] ([ID], [NAME], [GENDER], [DOB], [CELL]) VALUES (N'10003', N'gdfh', N'Nam', CAST(N'2010-01-27' AS Date), N'902222222')
INSERT [dbo].[consumer] ([ID], [NAME], [GENDER], [DOB], [CELL]) VALUES (N'10004', N'dsg', N'Nam', CAST(N'2010-01-27' AS Date), N'902222222')
INSERT [dbo].[consumer] ([ID], [NAME], [GENDER], [DOB], [CELL]) VALUES (N'10005', N'fd', N'Nam', CAST(N'2010-01-27' AS Date), N'902222222')
GO
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10000', N'Lan', N'Nữ', CAST(N'2002-05-02' AS Date), N'0905224167', N'3.png', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10001', N'Xoài', N'Nam', CAST(N'2001-06-09' AS Date), N'0326554286', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10002', N'Cóc m', N'Nữ', CAST(N'2002-12-12' AS Date), N'0958625541', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10003', N'Mèo', N'Nữ', CAST(N'2000-07-22' AS Date), N'0944552168', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10004', N'Heo', N'Nam', CAST(N'2001-01-01' AS Date), N'0922555625', NULL, N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10005', N'Hehe', N'Nam', CAST(N'2005-08-09' AS Date), N'0655235641', N'4.png', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10006', N'ggg', N'Nam', CAST(N'2000-08-03' AS Date), N'0954331234', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10007', N'fs', N'Nam', CAST(N'2000-11-03' AS Date), N'0902556662', N'12.png', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10008', N'meoem', N'Nữ', CAST(N'2001-08-02' AS Date), N'0955642862', N'', N'1')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10009', N'Nguyễn Thị Huyền', N'Nữ', CAST(N'2003-11-03' AS Date), N'0934524463', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10010', N'Nguyễn B', N'Nam', CAST(N'2003-04-29' AS Date), N'091231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10011', N'Trần V', N'Nữ', CAST(N'2001-02-21' AS Date), N'0333123321', N'', N'1')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10012', N'ACB', N'Nam', CAST(N'2001-02-23' AS Date), N'091232313', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10013', N'Bùi Minh T', N'Nam', CAST(N'2008-11-12' AS Date), N'091232223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10014', N'Hoàng Ngọc Mai', N'Nữ', CAST(N'2001-12-22' AS Date), N'091231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10015', N'Trần B', N'Nam', CAST(N'2006-10-01' AS Date), N'091231223', N'', N'1')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10016', N'Truong Van Duong', N'Nam', CAST(N'2005-02-01' AS Date), N'091231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10017', N'Hà Thị Thảo', N'Nữ', CAST(N'2001-04-01' AS Date), N'091231223', N'4.png', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10018', N'Đặng Thị Thu', N'Nữ', CAST(N'2001-02-12' AS Date), N'091231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10019', N'Lâm Thị Tuyết', N'Nữ', CAST(N'2007-05-25' AS Date), N'091231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10020', N'Phan Van Khánh', N'Nam', CAST(N'2005-02-22' AS Date), N'091231251', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10021', N'Lê Van Ðức', N'Nam', CAST(N'2005-05-15' AS Date), N'0912312231', N'', N'1')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10022', N'Vu Thùy Lan', N'Nữ', CAST(N'2011-09-16' AS Date), N'091231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10023', N'Bùi Van An', N'Nam', CAST(N'2012-04-14' AS Date), N'094231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10024', N'Ngô Thị Ngọc', N'Nữ', CAST(N'2002-02-21' AS Date), N'091231223', N'', N'1')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10025', N'Lý Thu Huong', N'Nữ', CAST(N'2004-05-01' AS Date), N'091231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10026', N'Mai Van Tuấn', N'Nam', CAST(N'2003-04-01' AS Date), N'091231223', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10027', N'Huy', N'Nam', CAST(N'2002-06-28' AS Date), N'0123123123', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10028', N'He ne', N'Nam', CAST(N'2000-02-02' AS Date), N'0956332654', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10029', N'u la troi', N'Nam', CAST(N'2000-11-01' AS Date), N'0122346523', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10030', N'met l', N'Nam', CAST(N'2000-04-11' AS Date), N'0122554365', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10031', N'dsf', N'Nam', CAST(N'2004-11-11' AS Date), N'0302552135', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10032', N'fsdf', N'Nam', CAST(N'2000-02-02' AS Date), N'0302552135', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10033', N'm', N'Nam', CAST(N'2000-11-22' AS Date), N'0213226453', N'', N'0')
INSERT [dbo].[employee] ([ID], [NAME], [GENDER], [DOB], [CELL], [IMG], [STATE]) VALUES (N'10034', N'Bùi Minh Ngọc', N'Nam', CAST(N'2004-06-16' AS Date), N'0234234234', N'', N'0')
GO
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100000', N'sữa tắm con bò', N'100', NULL, N'10002', CAST(200000 AS Decimal(10, 0)), 8, N'', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100001', N'siêu super abc dè fhel fnsfsk skèn', N'101', NULL, N'10003', CAST(6421000 AS Decimal(10, 0)), 10, N'pro100001.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100002', N'CoCa Light', N'101', N'1000', N'10002', CAST(10000 AS Decimal(10, 0)), 21, N'pro100002.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100003', N'Soda Kem', N'101', N'1000', N'10002', CAST(12000 AS Decimal(10, 0)), 30, N'pro100003.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100004', N'Sting', N'101', N'1000', N'10002', CAST(12000 AS Decimal(10, 0)), 51, N'pro100004.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100005', N'Red Bull', N'101', N'1000', N'10002', CAST(15000 AS Decimal(10, 0)), 52, N'pro100005.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100006', N'7Up Lemon', N'101', N'1000', N'10002', CAST(10000 AS Decimal(10, 0)), 43, N'pro100006.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100007', N'Pepsi Lemon', N'101', N'1000', N'10002', CAST(10000 AS Decimal(10, 0)), 21, N'pro100007.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100008', N'Splash', N'101', N'1000', N'10002', CAST(10000 AS Decimal(10, 0)), 24, N'pro100008.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100009', N'Twister', N'101', N'1000', N'10002', CAST(12000 AS Decimal(10, 0)), 21, N'pro100009.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100010', N'Mirinda Cam', N'101', N'1000', N'10002', CAST(10000 AS Decimal(10, 0)), 40, N'pro100010.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100011', N'Mirinda Xaxi', N'101', N'1000', N'10002', CAST(10000 AS Decimal(10, 0)), 34, N'pro100011.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100012', N'7Up', N'101', N'1000', N'10002', CAST(10000 AS Decimal(10, 0)), 32, N'pro100012.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100013', N'Tresemme', N'102', N'1000', N'10003', CAST(250000 AS Decimal(10, 0)), 50, N'pro100013.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100014', N'Clear Men', N'102', N'1000', N'10003', CAST(250000 AS Decimal(10, 0)), 20, N'pro100014.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100015', N'Head&Shoulders', N'102', N'1000', N'10003', CAST(198000 AS Decimal(10, 0)), 30, N'pro100015.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100016', N'Pantene', N'102', N'1000', N'10003', CAST(170000 AS Decimal(10, 0)), 51, N'pro100016.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100017', N'Evile', N'102', N'1000', N'10003', CAST(120000 AS Decimal(10, 0)), 52, N'pro100017.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100018', N'Biomed', N'102', N'1000', N'10003', CAST(120000 AS Decimal(10, 0)), 43, N'pro100018.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100019', N'Halwon', N'102', N'1000', N'10003', CAST(90000 AS Decimal(10, 0)), 18, N'pro100019.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100020', N'Davids', N'102', N'1000', N'10003', CAST(180000 AS Decimal(10, 0)), 22, N'pro100020.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100021', N'CeraVe', N'102', N'1000', N'10003', CAST(120000 AS Decimal(10, 0)), 20, N'pro100021.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100022', N'innifree', N'102', N'1000', N'10003', CAST(150000 AS Decimal(10, 0)), 26, N'pro100022.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100023', N'Cosrx', N'102', N'1000', N'10003', CAST(170000 AS Decimal(10, 0)), 31, N'pro100023.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100024', N'Hảo Hảo', N'100', N'1000', N'10001', CAST(4000 AS Decimal(10, 0)), 44, N'', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100025', N'Hảo Hảo Tím', N'100', N'1000', N'10001', CAST(4000 AS Decimal(10, 0)), 20, N'pro100025.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100026', N'Hảo Hảo sườn heo', N'100', N'1000', N'10001', CAST(4000 AS Decimal(10, 0)), 30, N'pro100026.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100027', N'Omachi', N'100', N'1000', N'10001', CAST(8000 AS Decimal(10, 0)), 51, N'pro100027.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100028', N'Mì Tuong Ðen', N'100', N'1000', N'10001', CAST(12000 AS Decimal(10, 0)), 52, N'pro100028.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100029', N'Mì Kim Chi', N'100', N'1000', N'10001', CAST(12000 AS Decimal(10, 0)), 43, N'pro100029.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100030', N'Mì Lẩu Thái', N'100', N'1000', N'10001', CAST(12000 AS Decimal(10, 0)), 19, N'pro100030.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100031', N'Mì Gà Vàng', N'100', N'1000', N'10001', CAST(12000 AS Decimal(10, 0)), 24, N'pro100031.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100032', N'Tương Cà', N'100', N'1000', N'10001', CAST(15000 AS Decimal(10, 0)), 21, N'pro100032.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100033', N'Tương Ớt', N'100', N'1000', N'10001', CAST(15000 AS Decimal(10, 0)), 21, N'pro100033.jpg', N'1')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100034', N'meo', N'101', N'1002', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'', N'1')
GO
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'100', N'Giảm 30% cho sản phẩm ', 0.3, CAST(N'2023-10-15' AS Date), CAST(N'2023-10-31' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'1000', N'bài alo', 0.2, CAST(N'2023-10-03' AS Date), CAST(N'2023-10-11' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'1001', N'test
', 0.3, CAST(N'2023-11-09' AS Date), CAST(N'2023-11-24' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'1002', N'heheheh', 0.22, CAST(N'2023-06-27' AS Date), CAST(N'2023-06-30' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'101', N'Giảm 50% cho sản phẩm', 0.5, CAST(N'2023-10-10' AS Date), CAST(N'2023-10-31' AS Date), N'00')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'102', N'Giảm 10% cho sản phẩm ', 0.1, CAST(N'2023-10-01' AS Date), CAST(N'2023-10-31' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'103', N'GIảm 20% cho sản phẩm ', 0.2, CAST(N'2023-10-01' AS Date), CAST(N'2023-10-31' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'104', N'Giảm 15% cho sản phẩm', 0.15, CAST(N'2023-10-15' AS Date), CAST(N'2023-10-25' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'105', N'GIảm 5% cho sản phẩm dịch vụ', 0.5, CAST(N'2023-10-15' AS Date), CAST(N'2023-10-25' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'106', N'Giảm 10% cho sản phẩm ', 0.1, CAST(N'2023-10-15' AS Date), CAST(N'2023-10-31' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'107', N'Giảm 10% cho sản phẩm ', 0.1, CAST(N'2023-11-01' AS Date), CAST(N'2023-11-05' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'108', N'Giảm 15% cho sản phẩm', 0.15, CAST(N'2023-11-01' AS Date), CAST(N'2023-11-15' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'109', N'Giảm 50% cho sản phẩm', 0.5, CAST(N'2023-11-19' AS Date), CAST(N'2023-11-20' AS Date), N'0')
INSERT [dbo].[promotion] ([ID], [DISCRIPTION], [PERCENT_DISCOUNT], [START_DATE], [END_DATE], [STATE]) VALUES (N'110', N'Giảm 20% cho sản phẩm', 0.2, CAST(N'2023-11-01' AS Date), CAST(N'2023-11-30' AS Date), N'0')
GO
INSERT [dbo].[provider] ([ID], [NAME], [CELL], [ADDRESS], [EMAIL], [STATE]) VALUES (N'10001', N'Cty phân phối Thực Phẩm', N'0939123023', N'243 ACB ', N'acb@gmail.com', N'0')
INSERT [dbo].[provider] ([ID], [NAME], [CELL], [ADDRESS], [EMAIL], [STATE]) VALUES (N'10002', N'Cty phân phối nước giải khát', N'0939123453', N'23 BBB ', N'bbb@gmail.com', N'0')
INSERT [dbo].[provider] ([ID], [NAME], [CELL], [ADDRESS], [EMAIL], [STATE]) VALUES (N'10003', N'Cty phân phối hàng tiêu dùng ', N'0939333123', N'33 CCC', N'ccc@gmail.com', N'0')
INSERT [dbo].[provider] ([ID], [NAME], [CELL], [ADDRESS], [EMAIL], [STATE]) VALUES (N'10004', N'af', N'0902543134', N'f', N'oo', N'0')
GO
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100000', N'10023', CAST(N'2023-01-20' AS Date), CAST(1000000 AS Decimal(10, 0)), N'10003', N'0')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100001', N'10021', CAST(N'2023-01-21' AS Date), CAST(20000000 AS Decimal(10, 0)), N'10002', N'0')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100002', N'10030', CAST(N'2023-01-22' AS Date), CAST(2121 AS Decimal(10, 0)), N'10001', N'0')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100003', N'10028', CAST(N'2023-02-23' AS Date), CAST(12544554 AS Decimal(10, 0)), N'10002', N'0')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100004', N'10022', CAST(N'2023-11-20' AS Date), CAST(0 AS Decimal(10, 0)), N'10001', N'1')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100005', N'10022', CAST(N'2023-11-20' AS Date), CAST(0 AS Decimal(10, 0)), N'10001', N'0')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100006', N'10023', CAST(N'2023-11-20' AS Date), CAST(448491110 AS Decimal(10, 0)), N'10003', N'1')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100007', N'10022', CAST(N'2023-11-21' AS Date), CAST(0 AS Decimal(10, 0)), N'10004', N'0')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100008', N'10026', CAST(N'2023-11-22' AS Date), CAST(140 AS Decimal(10, 0)), N'10001', N'1')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100009', N'10021', CAST(N'2023-11-22' AS Date), CAST(22 AS Decimal(10, 0)), N'10001', N'1')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100010', N'10022', CAST(N'2023-11-22' AS Date), CAST(22 AS Decimal(10, 0)), N'10001', N'1')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100011', N'10018', CAST(N'2023-11-22' AS Date), CAST(113196 AS Decimal(10, 0)), N'10001', N'1')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100012', N'10019', CAST(N'2023-11-22' AS Date), CAST(621 AS Decimal(10, 0)), N'10002', N'1')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100013', N'10021', CAST(N'2023-11-22' AS Date), CAST(0 AS Decimal(10, 0)), N'10002', N'0')
INSERT [dbo].[purchase_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [PROVIDER_ID], [STATE]) VALUES (N'100014', N'10019', CAST(N'2023-11-23' AS Date), CAST(250000 AS Decimal(10, 0)), N'10001', N'1')
GO
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100004', N'100009', 1, CAST(20000000 AS Decimal(10, 0)), CAST(N'2023-12-07' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100004', N'100010', 3, CAST(2000056 AS Decimal(10, 0)), CAST(N'2023-12-07' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100004', N'100011', 6, CAST(545200 AS Decimal(10, 0)), CAST(N'2023-12-01' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100005', N'100003', 2, CAST(12000 AS Decimal(10, 0)), CAST(N'2023-11-23' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100006', N'100004', 2, CAST(1131 AS Decimal(10, 0)), CAST(N'2023-11-30' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100006', N'100010', 4, CAST(112122212 AS Decimal(10, 0)), CAST(N'2023-12-01' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100008', N'100001', 1, CAST(20 AS Decimal(10, 0)), CAST(N'2023-12-02' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100008', N'100003', 1, CAST(55 AS Decimal(10, 0)), CAST(N'2023-12-15' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100008', N'100005', 1, CAST(65 AS Decimal(10, 0)), CAST(N'2023-12-15' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100009', N'100001', 1, CAST(22 AS Decimal(10, 0)), CAST(N'2023-11-30' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100010', N'100002', 1, CAST(22 AS Decimal(10, 0)), CAST(N'2023-12-08' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100011', N'100000', 2, CAST(56565 AS Decimal(10, 0)), CAST(N'2023-12-02' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100011', N'100002', 1, CAST(66 AS Decimal(10, 0)), CAST(N'2023-12-01' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100012', N'100000', 1, CAST(565 AS Decimal(10, 0)), CAST(N'2023-12-08' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100012', N'100006', 1, CAST(56 AS Decimal(10, 0)), CAST(N'2023-11-25' AS Date), N'0')
INSERT [dbo].[purchase_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE], [EXP], [STATE]) VALUES (N'100014', N'100000', 2, CAST(125000 AS Decimal(10, 0)), CAST(N'2023-12-01' AS Date), N'0')
GO
INSERT [dbo].[sales_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [CONSUMER_ID], [VOUCHER_ID], [STATE]) VALUES (N'100000', N'10000', CAST(N'2022-02-02' AS Date), CAST(200000 AS Decimal(18, 0)), N'10000', NULL, N'1')
INSERT [dbo].[sales_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [CONSUMER_ID], [VOUCHER_ID], [STATE]) VALUES (N'100001', N'10001', CAST(N'2024-11-04' AS Date), CAST(13042000 AS Decimal(18, 0)), N'10001', NULL, N'1')
INSERT [dbo].[sales_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [CONSUMER_ID], [VOUCHER_ID], [STATE]) VALUES (N'100002', N'10021', CAST(N'2023-10-19' AS Date), CAST(740000 AS Decimal(18, 0)), N'10001', NULL, N'1')
INSERT [dbo].[sales_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [CONSUMER_ID], [VOUCHER_ID], [STATE]) VALUES (N'100003', N'10023', CAST(N'2023-11-19' AS Date), CAST(670000 AS Decimal(18, 0)), N'10002', N'101', N'1')
INSERT [dbo].[sales_invoice] ([ID], [EMPLOYEE_ID], [DATE], [TOTAL_PAYMENT], [CONSUMER_ID], [VOUCHER_ID], [STATE]) VALUES (N'100004', N'10022', CAST(N'2023-11-19' AS Date), CAST(0 AS Decimal(18, 0)), N'10003', N'102', N'0')
GO
INSERT [dbo].[sales_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE]) VALUES (N'100002', N'100021', 1, CAST(120000 AS Decimal(18, 0)))
INSERT [dbo].[sales_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE]) VALUES (N'100002', N'100022', 3, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[sales_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE]) VALUES (N'100002', N'100023', 1, CAST(170000 AS Decimal(18, 0)))
INSERT [dbo].[sales_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE]) VALUES (N'100003', N'100020', 2, CAST(180000 AS Decimal(18, 0)))
INSERT [dbo].[sales_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE]) VALUES (N'100003', N'100022', 1, CAST(150000 AS Decimal(18, 0)))
INSERT [dbo].[sales_invoice_detail] ([INVOICE_ID], [PRODUCT_ID], [QUANTITY], [PRICE]) VALUES (N'100003', N'100023', 1, CAST(170000 AS Decimal(18, 0)))
GO
INSERT [dbo].[stockroom] ([ID], [PRODUCT_ID], [QUANTITY], [EXP]) VALUES (N'100000', N'100002', 1, CAST(N'2023-12-08' AS Date))
INSERT [dbo].[stockroom] ([ID], [PRODUCT_ID], [QUANTITY], [EXP]) VALUES (N'100001', N'100002', 1, CAST(N'2023-12-01' AS Date))
INSERT [dbo].[stockroom] ([ID], [PRODUCT_ID], [QUANTITY], [EXP]) VALUES (N'100002', N'100000', 1, CAST(N'2023-12-08' AS Date))
INSERT [dbo].[stockroom] ([ID], [PRODUCT_ID], [QUANTITY], [EXP]) VALUES (N'100003', N'100006', 1, CAST(N'2023-11-25' AS Date))
INSERT [dbo].[stockroom] ([ID], [PRODUCT_ID], [QUANTITY], [EXP]) VALUES (N'100004', N'100000', 2, CAST(N'2023-12-01' AS Date))
GO
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'100', N'afgh', N'áp dụng cho háo đơn 5tr ', CAST(20000 AS Decimal(10, 0)), CAST(5000000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-10-24' AS Date), CAST(N'2023-10-25' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'101', N'MGG10', N'Áp dụng cho hóa đơn từ 100000 VND', CAST(10000 AS Decimal(10, 0)), CAST(100000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-10-01' AS Date), CAST(N'2023-11-30' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'102', N'MGG15', N'Áp dụng cho hóa đơn từ 150000 VND', CAST(15000 AS Decimal(10, 0)), CAST(150000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-10-01' AS Date), CAST(N'2023-10-31' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'103', N'MGG20', N'Áp dụng cho hóa đơn từ 200000 VND', CAST(20000 AS Decimal(10, 0)), CAST(200000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-10-01' AS Date), CAST(N'2023-10-31' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'104', N'MGG50', N'Áp dụng cho hóa đơn từ 500000 VND', CAST(50000 AS Decimal(10, 0)), CAST(500000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-10-01' AS Date), CAST(N'2023-10-31' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'105', N'NHAGIAO2', N'Áp dụng cho hóa đơn từ 300000 VND', CAST(30000 AS Decimal(10, 0)), CAST(300000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-11-19' AS Date), CAST(N'2023-11-20' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'106', N'PHUNU', N'Áp dụng cho hóa đơn từ 150000 VND', CAST(30000 AS Decimal(10, 0)), CAST(150000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-10-19' AS Date), CAST(N'2023-10-20' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'107', N'SALE10', N'Áp dụng cho hóa đơn từ 101000 VND', CAST(15000 AS Decimal(10, 0)), CAST(101000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-10-10' AS Date), CAST(N'2023-10-10' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'108', N'SALE11', N'Áp dụng cho hóa đơn từ 111000 VND', CAST(15000 AS Decimal(10, 0)), CAST(111000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-11-11' AS Date), CAST(N'2023-11-11' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'109', N'CUOITHANG', N'Áp dụng cho hóa đơn từ 100000 VND', CAST(15000 AS Decimal(10, 0)), CAST(100000 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-10-31' AS Date), CAST(N'2023-10-31' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'110', N'VC5', N'Áp dụng cho hóa đơn từ 80000 VND', NULL, NULL, 0.05, CAST(5000 AS Decimal(10, 0)), CAST(N'2023-11-01' AS Date), CAST(N'2023-11-15' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'111', N'VC10', N'Áp dụng cho hóa đơn từ 150000 VND', NULL, NULL, 0.05, CAST(10000 AS Decimal(10, 0)), CAST(N'2023-11-01' AS Date), CAST(N'2023-11-15' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'112', N'VC30', N'Áp dụng cho hóa đơn từ 300000 VND', NULL, NULL, 0.05, CAST(20000 AS Decimal(10, 0)), CAST(N'2023-11-01' AS Date), CAST(N'2023-11-15' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'113', N'GIUATHANG11', N'Áp dụng cho hóa đơn từ 500000 VND', NULL, NULL, 0.05, CAST(40000 AS Decimal(10, 0)), CAST(N'2023-11-16' AS Date), CAST(N'2023-11-16' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'114', N'NAM', N'Áp dụng cho hóa đơn từ 1000000 VND', NULL, NULL, 0.15, CAST(50000 AS Decimal(10, 0)), CAST(N'2023-11-19' AS Date), CAST(N'2023-11-19' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'115', N'HETTIEN', N'Áp dụng cho hóa đơn từ 100000 VND', NULL, NULL, 0.1, CAST(10000 AS Decimal(10, 0)), CAST(N'2023-11-30' AS Date), CAST(N'2023-11-30' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'116', N'SALE5', N'Áp dụng cho hóa đơn từ 50000 VND', NULL, NULL, 0.05, CAST(5000 AS Decimal(10, 0)), CAST(N'2023-11-21' AS Date), CAST(N'2023-11-29' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'117', N'SALE1', N'ÁP dụng cho hóa đơn từ 100000 VND', NULL, NULL, 0.1, CAST(8000 AS Decimal(10, 0)), CAST(N'2023-11-21' AS Date), CAST(N'2023-11-29' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'118', N'NHAGIAO1', N'Áp dụng cho hóa đơn từ 100000 VND', NULL, NULL, 0.1, CAST(15000 AS Decimal(10, 0)), CAST(N'2023-11-20' AS Date), CAST(N'2023-11-20' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'119', N'GIUAT10', N'Áp dụng cho hóa đơn từ 100000 VND', NULL, NULL, 0.15, CAST(15000 AS Decimal(10, 0)), CAST(N'2023-10-15' AS Date), CAST(N'2013-10-15' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'120', N'gdfgf', N'111', CAST(2000 AS Decimal(10, 0)), CAST(222 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-11-08' AS Date), CAST(N'2023-11-29' AS Date))
INSERT [dbo].[voucher] ([ID], [CODE], [DISCRIPTION], [DISCOUNT_AMOUNT], [MIN_INVOICE_VALUE], [PERCENT_DISCOUNT], [MAX_DISCOUNT], [START_DATE], [END_DATE]) VALUES (N'121', N'fg', N'fdg', CAST(44 AS Decimal(10, 0)), CAST(55 AS Decimal(10, 0)), NULL, NULL, CAST(N'2023-11-01' AS Date), CAST(N'2023-11-02' AS Date))
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK__product__CATEGOR__440B1D61] FOREIGN KEY([CATEGORY_ID])
REFERENCES [dbo].[category] ([ID])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK__product__CATEGOR__440B1D61]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK__product__PROMOTI__44FF419A] FOREIGN KEY([PROMOTION_ID])
REFERENCES [dbo].[promotion] ([ID])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK__product__PROMOTI__44FF419A]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK__product__PROVIDE__45F365D3] FOREIGN KEY([PROVIDER_ID])
REFERENCES [dbo].[provider] ([ID])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK__product__PROVIDE__45F365D3]
GO
ALTER TABLE [dbo].[purchase_invoice]  WITH CHECK ADD  CONSTRAINT [FK__purchase___EMPLO__4AB81AF0] FOREIGN KEY([EMPLOYEE_ID])
REFERENCES [dbo].[employee] ([ID])
GO
ALTER TABLE [dbo].[purchase_invoice] CHECK CONSTRAINT [FK__purchase___EMPLO__4AB81AF0]
GO
ALTER TABLE [dbo].[purchase_invoice]  WITH CHECK ADD  CONSTRAINT [FK__purchase___PROVI__4BAC3F29] FOREIGN KEY([PROVIDER_ID])
REFERENCES [dbo].[provider] ([ID])
GO
ALTER TABLE [dbo].[purchase_invoice] CHECK CONSTRAINT [FK__purchase___PROVI__4BAC3F29]
GO
ALTER TABLE [dbo].[purchase_invoice_detail]  WITH CHECK ADD  CONSTRAINT [FK__purchase___INVOI__4F7CD00D] FOREIGN KEY([INVOICE_ID])
REFERENCES [dbo].[purchase_invoice] ([ID])
GO
ALTER TABLE [dbo].[purchase_invoice_detail] CHECK CONSTRAINT [FK__purchase___INVOI__4F7CD00D]
GO
ALTER TABLE [dbo].[purchase_invoice_detail]  WITH CHECK ADD  CONSTRAINT [FK_purchase_invoice_detail_product] FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[product] ([ID])
GO
ALTER TABLE [dbo].[purchase_invoice_detail] CHECK CONSTRAINT [FK_purchase_invoice_detail_product]
GO
ALTER TABLE [dbo].[sales_invoice]  WITH CHECK ADD  CONSTRAINT [FK__sale_invo__CONSU__5441852A] FOREIGN KEY([CONSUMER_ID])
REFERENCES [dbo].[consumer] ([ID])
GO
ALTER TABLE [dbo].[sales_invoice] CHECK CONSTRAINT [FK__sale_invo__CONSU__5441852A]
GO
ALTER TABLE [dbo].[sales_invoice]  WITH CHECK ADD  CONSTRAINT [FK__sale_invo__EMPLO__534D60F1] FOREIGN KEY([EMPLOYEE_ID])
REFERENCES [dbo].[employee] ([ID])
GO
ALTER TABLE [dbo].[sales_invoice] CHECK CONSTRAINT [FK__sale_invo__EMPLO__534D60F1]
GO
ALTER TABLE [dbo].[sales_invoice]  WITH CHECK ADD  CONSTRAINT [FK_sale_invoice_voucher] FOREIGN KEY([VOUCHER_ID])
REFERENCES [dbo].[voucher] ([ID])
GO
ALTER TABLE [dbo].[sales_invoice] CHECK CONSTRAINT [FK_sale_invoice_voucher]
GO
ALTER TABLE [dbo].[sales_invoice_detail]  WITH CHECK ADD  CONSTRAINT [FK__sale_invo__INVOI__571DF1D5] FOREIGN KEY([INVOICE_ID])
REFERENCES [dbo].[sales_invoice] ([ID])
GO
ALTER TABLE [dbo].[sales_invoice_detail] CHECK CONSTRAINT [FK__sale_invo__INVOI__571DF1D5]
GO
ALTER TABLE [dbo].[sales_invoice_detail]  WITH CHECK ADD  CONSTRAINT [FK__sale_invo__PRODU__5812160E] FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[product] ([ID])
GO
ALTER TABLE [dbo].[sales_invoice_detail] CHECK CONSTRAINT [FK__sale_invo__PRODU__5812160E]
GO
ALTER TABLE [dbo].[stockroom]  WITH CHECK ADD  CONSTRAINT [FK_stockroom_product] FOREIGN KEY([PRODUCT_ID])
REFERENCES [dbo].[product] ([ID])
GO
ALTER TABLE [dbo].[stockroom] CHECK CONSTRAINT [FK_stockroom_product]
GO
USE [master]
GO
ALTER DATABASE [ministore] SET  READ_WRITE 
GO


///////////////////////////////////////////////////////////////
################################################################

GO
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100000', N'sữa tắm con bò', N'100', NULL, N'10002', CAST(0 AS Decimal(10, 0)), 0, N'', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100001', N'siêu super abc dè fhel fnsfsk skèn', N'101', NULL, N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100001.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100002', N'CoCa Light', N'101', NULL, N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100002.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100003', N'Soda Kem', N'101', NULL, N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100003.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100004', N'Sting', N'101', NULL, N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100004.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100005', N'Red Bull', N'101', NULL, N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100005.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100006', N'7Up Lemon', N'101', NULL, N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100006.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100007', N'Pepsi Lemon', N'101', NULL, N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100007.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100008', N'Splash', N'101', N'1000', N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100008.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100009', N'Twister', N'101', N'1000', N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100009.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100010', N'Mirinda Cam', N'101', N'1000', N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100010.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100011', N'Mirinda Xaxi', N'101', N'1000', N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100011.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100012', N'7Up', N'101', N'1000', N'10002', CAST(0 AS Decimal(10, 0)), 0, N'pro100012.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100013', N'Tresemme', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100013.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100014', N'Clear Men', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100014.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100015', N'Head&Shoulders', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100015.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100016', N'Pantene', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100016.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100017', N'Evile', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100017.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100018', N'Biomed', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100018.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100019', N'Halwon', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100019.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100020', N'Davids', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100020.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100021', N'CeraVe', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100021.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100022', N'innifree', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100022.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100023', N'Cosrx', N'102', N'1000', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'pro100023.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100024', N'Hảo Hảo', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100025', N'Hảo Hảo Tím', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100025.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100026', N'Hảo Hảo sườn heo', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100026.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100027', N'Omachi', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100027.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100028', N'Mì Tuong Ðen', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100028.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100029', N'Mì Kim Chi', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100029.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100030', N'Mì Lẩu Thái', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100030.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100031', N'Mì Gà Vàng', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100031.png', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100032', N'Tương Cà', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100032.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100033', N'Tương Ớt', N'100', N'1000', N'10001', CAST(0 AS Decimal(10, 0)), 0, N'pro100033.jpg', N'0')
INSERT [dbo].[product] ([ID], [NAME], [CATEGORY_ID], [PROMOTION_ID], [PROVIDER_ID], [PRICE], [QUANTITY], [IMG], [STATE]) VALUES (N'100034', N'meo', N'101', N'1002', N'10003', CAST(0 AS Decimal(10, 0)), 0, N'', N'1')
GO