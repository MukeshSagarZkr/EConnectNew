USE [EConnect]
GO
ALTER TABLE [dbo].[QuoteProducts] DROP CONSTRAINT [fk_QuoteProducts_QuoteDetailID]
GO
ALTER TABLE [dbo].[QuoteProducts] DROP CONSTRAINT [fk_QuoteProducts_LeadID]
GO
ALTER TABLE [dbo].[QuoteDetail] DROP CONSTRAINT [fk_QuoteDetail_LeadID]
GO
ALTER TABLE [dbo].[Login] DROP CONSTRAINT [FK_Login_Company]
GO
ALTER TABLE [dbo].[LeadAddress] DROP CONSTRAINT [fk_LeadAddress_LeadID]
GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_Contact_Company]
GO
ALTER TABLE [dbo].[Login] DROP CONSTRAINT [DF__Login__IsProcess__5165187F]
GO
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [DF__Contact__IsProce__5070F446]
GO
/****** Object:  Index [IX_Contact]    Script Date: 9/18/2024 7:36:12 AM ******/
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [IX_Contact]
GO
/****** Object:  Table [dbo].[ReferalSource]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReferalSource]') AND type in (N'U'))
DROP TABLE [dbo].[ReferalSource]
GO
/****** Object:  Table [dbo].[QuoteProducts]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuoteProducts]') AND type in (N'U'))
DROP TABLE [dbo].[QuoteProducts]
GO
/****** Object:  Table [dbo].[QuoteDetail]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[QuoteDetail]') AND type in (N'U'))
DROP TABLE [dbo].[QuoteDetail]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Login]') AND type in (N'U'))
DROP TABLE [dbo].[Login]
GO
/****** Object:  Table [dbo].[LeadType]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeadType]') AND type in (N'U'))
DROP TABLE [dbo].[LeadType]
GO
/****** Object:  Table [dbo].[LeadStatus]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeadStatus]') AND type in (N'U'))
DROP TABLE [dbo].[LeadStatus]
GO
/****** Object:  Table [dbo].[LeadMaster]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeadMaster]') AND type in (N'U'))
DROP TABLE [dbo].[LeadMaster]
GO
/****** Object:  Table [dbo].[LeadAddress]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeadAddress]') AND type in (N'U'))
DROP TABLE [dbo].[LeadAddress]
GO
/****** Object:  Table [dbo].[FormFields]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormFields]') AND type in (N'U'))
DROP TABLE [dbo].[FormFields]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventType]') AND type in (N'U'))
DROP TABLE [dbo].[EventType]
GO
/****** Object:  Table [dbo].[ContactPreference]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactPreference]') AND type in (N'U'))
DROP TABLE [dbo].[ContactPreference]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
DROP TABLE [dbo].[Contact]
GO
/****** Object:  Table [dbo].[CompanyType]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyType]') AND type in (N'U'))
DROP TABLE [dbo].[CompanyType]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 9/18/2024 7:36:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Company]') AND type in (N'U'))
DROP TABLE [dbo].[Company]
GO
USE [master]
GO
/****** Object:  Database [EConnect]    Script Date: 9/18/2024 7:36:12 AM ******/
DROP DATABASE [EConnect]
GO
/****** Object:  Database [EConnect]    Script Date: 9/18/2024 7:36:12 AM ******/
CREATE DATABASE [EConnect]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EConnect', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL2022\MSSQL\DATA\EConnect.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EConnect_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQL2022\MSSQL\DATA\EConnect_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EConnect] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EConnect].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EConnect] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EConnect] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EConnect] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EConnect] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EConnect] SET ARITHABORT OFF 
GO
ALTER DATABASE [EConnect] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EConnect] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EConnect] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EConnect] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EConnect] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EConnect] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EConnect] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EConnect] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EConnect] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EConnect] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EConnect] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EConnect] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EConnect] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EConnect] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EConnect] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EConnect] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EConnect] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EConnect] SET RECOVERY FULL 
GO
ALTER DATABASE [EConnect] SET  MULTI_USER 
GO
ALTER DATABASE [EConnect] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EConnect] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EConnect] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EConnect] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EConnect] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EConnect] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EConnect', N'ON'
GO
ALTER DATABASE [EConnect] SET QUERY_STORE = ON
GO
ALTER DATABASE [EConnect] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EConnect]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyShortName] [varchar](30) NULL,
	[CompanyFullName] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [char](4) NULL,
 CONSTRAINT [pk_Company_CompanyID] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyType]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyType](
	[CompanyTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyType] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_CompanyType_ID] PRIMARY KEY CLUSTERED 
(
	[CompanyTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[CompanyName] [varchar](200) NULL,
	[Address1] [nvarchar](200) NULL,
	[Address2] [nvarchar](255) NULL,
	[City] [nvarchar](60) NULL,
	[State] [nvarchar](60) NULL,
	[Zip] [nvarchar](30) NULL,
	[Country] [varchar](100) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[Fax] [nvarchar](30) NULL,
	[Email] [nvarchar](100) NULL,
	[ContactPref] [tinyint] NULL,
	[ReferSource] [varchar](300) NULL,
	[ReferSourceOthers] [varchar](50) NULL,
	[ProductVersionID] [varchar](200) NULL,
	[Comments] [text] NULL,
	[MailingList] [bit] NULL,
	[ContactType] [bit] NULL,
	[CreatedDt] [datetime] NULL,
	[SupportPlan] [varchar](50) NULL,
	[SupportExpDt] [varchar](50) NULL,
	[EWRExpDt] [varchar](50) NULL,
	[ProductName] [varchar](50) NULL,
	[ProductDesc] [varchar](100) NULL,
	[UnlockCode] [varchar](50) NULL,
	[Status] [char](1) NULL,
	[ReasonType] [varchar](50) NULL,
	[ReasonDesc] [varchar](max) NULL,
	[CallBackDate] [datetime] NULL,
	[CallBackTime] [varchar](1000) NULL,
	[WebSite] [varchar](200) NULL,
	[CompanyType] [varchar](100) NULL,
	[NoRooms] [numeric](18, 0) NULL,
	[PurchaseDt] [varchar](50) NULL,
	[Testimonial] [text] NULL,
	[DisplayTestimonial] [bit] NULL,
	[Objections] [varchar](1000) NULL,
	[Province] [varchar](250) NULL,
	[Role1] [varchar](100) NULL,
	[Role2] [varchar](100) NULL,
	[DateRequested] [datetime] NULL,
	[Cellphone] [varchar](60) NULL,
	[TypeofLead] [tinyint] NULL,
	[BudgetNotes] [text] NULL,
	[EventNotes] [text] NULL,
	[Customerneeds] [text] NULL,
	[ContractDt] [datetime] NULL,
	[POSId] [varchar](20) NULL,
	[LeadConversionDate] [date] NULL,
	[GuestId] [int] NOT NULL,
	[ProductVersion] [varchar](100) NULL,
	[MonthlyPrice] [varchar](100) NULL,
	[YearlyPrice] [varchar](100) NULL,
	[Discount] [varchar](100) NULL,
	[Tax] [varchar](100) NULL,
	[AdditionalPurchase] [varchar](100) NULL,
	[SetupTotal] [varchar](100) NULL,
	[RecurringTotal] [varchar](100) NULL,
	[BillingContacts] [varchar](50) NULL,
	[Email2] [nvarchar](100) NULL,
	[SalesId] [varchar](50) NULL,
	[DemoDt] [varchar](50) NULL,
	[FreetrialDt] [varchar](50) NULL,
	[ValidationStatus] [varchar](50) NOT NULL,
	[ValidatedUser] [varchar](100) NOT NULL,
	[CountryCode] [varchar](30) NOT NULL,
	[DonationId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [char](4) NULL,
 CONSTRAINT [PK_Contact_Pid_CId] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC,
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactPreference]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactPreference](
	[ContactPreferenceID] [int] IDENTITY(1,1) NOT NULL,
	[ContactPrference] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_ContactPreference_ContactPreferenceID] PRIMARY KEY CLUSTERED 
(
	[ContactPreferenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[EventTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EventType] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_EventType_EventTypeID] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormFields]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormFields](
	[FieldID] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](100) NOT NULL,
	[ScreenName] [nvarchar](100) NOT NULL,
	[FieldType] [nvarchar](50) NOT NULL,
	[FieldDataType] [nvarchar](50) NOT NULL,
	[DefaultValue] [nvarchar](255) NULL,
	[Options] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[FieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeadAddress]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadAddress](
	[LeadAddressID] [int] IDENTITY(1,1) NOT NULL,
	[LeadAddress] [varchar](50) NULL,
	[LeadID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_LeadAddress_LeadAddressID] PRIMARY KEY CLUSTERED 
(
	[LeadAddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeadMaster]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadMaster](
	[LeadID] [int] IDENTITY(1,1) NOT NULL,
	[ContactNumber] [varchar](50) NULL,
	[AssignedLeadID] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Title] [varchar](50) NULL,
	[OrganisationName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[CountryCode] [int] NULL,
	[BusinessPhone] [varchar](50) NULL,
	[CellPhone] [varchar](50) NULL,
	[HomePhone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[CompanyType] [int] NULL,
	[ReferralSources] [int] NULL,
	[Others] [varchar](100) NULL,
	[NoOfRooms] [int] NULL,
	[IsChangeToCustomer] [bit] NULL,
	[IsSendEmail] [bit] NULL,
	[BillingContacts] [varchar](100) NULL,
	[Email2] [varchar](100) NULL,
	[WebSite] [varchar](100) NULL,
	[Comments] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_LeadMaster] PRIMARY KEY CLUSTERED 
(
	[LeadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeadStatus]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadStatus](
	[LeadStatusID] [int] IDENTITY(1,1) NOT NULL,
	[LeadStatus] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_LeadStatus_LeadStatusID] PRIMARY KEY CLUSTERED 
(
	[LeadStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeadType]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadType](
	[LeadTypeID] [int] IDENTITY(1,1) NOT NULL,
	[LeadType] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_LeadType_LeadTypeID] PRIMARY KEY CLUSTERED 
(
	[LeadTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Login] [nvarchar](255) NULL,
	[Password] [nvarchar](50) NULL,
	[LoginType] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[ShortName] [varchar](50) NULL,
	[ExpiryDate] [smalldatetime] NULL,
	[Demo] [bit] NULL,
	[NewProcess] [nvarchar](500) NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsProcessed] [char](4) NULL,
 CONSTRAINT [PK_Login_LoginID_PropertID] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC,
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuoteDetail]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuoteDetail](
	[QuoteDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ProductVersion] [varchar](50) NULL,
	[MonthlyPrice] [decimal](9, 2) NULL,
	[YearlyPrice] [decimal](9, 2) NULL,
	[Tax] [decimal](9, 2) NULL,
	[Discount] [decimal](9, 2) NULL,
	[SetupTotal] [decimal](9, 2) NULL,
	[RecurringTotal] [decimal](9, 2) NULL,
	[LeadID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_QuoteDetail_QuoteDetailID] PRIMARY KEY CLUSTERED 
(
	[QuoteDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuoteProducts]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuoteProducts](
	[QuoteProductID] [int] IDENTITY(1,1) NOT NULL,
	[Product] [varchar](100) NULL,
	[Price] [decimal](9, 2) NULL,
	[QuoteDetailID] [int] NULL,
	[LeadID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReferalSource]    Script Date: 9/18/2024 7:36:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferalSource](
	[ReferalSourceID] [int] IDENTITY(1,1) NOT NULL,
	[ReferalSource] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[IsProcessed] [bit] NULL,
 CONSTRAINT [pk_ReferalSource_ID] PRIMARY KEY CLUSTERED 
(
	[ReferalSourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyShortName], [CompanyFullName], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (1, N'Newman', N'Newman International Academy', 1, 0, 99999, CAST(N'2024-09-14T15:08:45.490' AS DateTime), 99999, CAST(N'2024-09-14T15:08:45.490' AS DateTime), N'INC ')
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[LeadStatus] ON 

INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (1, N'Dead Lead', 1, 0, 99999, CAST(N'2024-09-15T22:55:32.867' AS DateTime), 99999, CAST(N'2024-09-15T22:55:32.867' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (2, N'Active Lead', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (3, N'Waiting for Response', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (4, N'Hot', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (5, N'Customer', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (6, N'On Boarding', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (7, N'In Free Trials', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.630' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (8, N'Demo Completed', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.633' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.633' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (9, N'Qualified', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.633' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.633' AS DateTime), 0)
INSERT [dbo].[LeadStatus] ([LeadStatusID], [LeadStatus], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (10, N'Pre Qualify', 1, 0, 99999, CAST(N'2024-09-15T22:57:23.633' AS DateTime), 99999, CAST(N'2024-09-15T22:57:23.633' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[LeadStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([LoginId], [CompanyId], [Login], [Password], [LoginType], [EmailAddress], [ShortName], [ExpiryDate], [Demo], [NewProcess], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [IsActive], [IsDeleted], [IsProcessed]) VALUES (1, 1, N'SuperAdmin', N'SuperAdmin', N'Admin', N'superadmin@gracesoft.com', N'Newman', CAST(N'2050-12-31T00:00:00' AS SmallDateTime), 1, N'N/A', 99999, CAST(N'2024-09-14T15:14:07.950' AS DateTime), 99999, CAST(N'2024-09-14T15:14:07.950' AS DateTime), 1, 0, N'INC ')
SET IDENTITY_INSERT [dbo].[Login] OFF
GO
SET IDENTITY_INSERT [dbo].[ReferalSource] ON 

INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (1, N'Booking.com', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.220' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.220' AS DateTime), 0)
INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (2, N'Expedia', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.273' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.273' AS DateTime), 0)
INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (3, N'Website', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.290' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.290' AS DateTime), 0)
INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (4, N'Phone Reservation', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.290' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.290' AS DateTime), 0)
INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (5, N'Walk In Guest', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.300' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.300' AS DateTime), 0)
INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (6, N'Colonel Male', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.300' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.300' AS DateTime), 0)
INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (7, N'Chamber of Commerce', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.303' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.303' AS DateTime), 0)
INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (8, N'AirBnB', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.303' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.303' AS DateTime), 0)
INSERT [dbo].[ReferalSource] ([ReferalSourceID], [ReferalSource], [IsActive], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [IsProcessed]) VALUES (9, N'Google', 1, 0, 99999, CAST(N'2024-09-15T22:28:23.307' AS DateTime), 99999, CAST(N'2024-09-15T22:28:23.307' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[ReferalSource] OFF
GO
/****** Object:  Index [IX_Contact]    Script Date: 9/18/2024 7:36:12 AM ******/
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [IX_Contact] UNIQUE NONCLUSTERED 
(
	[CompanyId] ASC,
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contact] ADD  DEFAULT ('INC') FOR [IsProcessed]
GO
ALTER TABLE [dbo].[Login] ADD  DEFAULT ('INC') FOR [IsProcessed]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_Company]
GO
ALTER TABLE [dbo].[LeadAddress]  WITH CHECK ADD  CONSTRAINT [fk_LeadAddress_LeadID] FOREIGN KEY([LeadID])
REFERENCES [dbo].[LeadMaster] ([LeadID])
GO
ALTER TABLE [dbo].[LeadAddress] CHECK CONSTRAINT [fk_LeadAddress_LeadID]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Company]
GO
ALTER TABLE [dbo].[QuoteDetail]  WITH CHECK ADD  CONSTRAINT [fk_QuoteDetail_LeadID] FOREIGN KEY([LeadID])
REFERENCES [dbo].[LeadMaster] ([LeadID])
GO
ALTER TABLE [dbo].[QuoteDetail] CHECK CONSTRAINT [fk_QuoteDetail_LeadID]
GO
ALTER TABLE [dbo].[QuoteProducts]  WITH CHECK ADD  CONSTRAINT [fk_QuoteProducts_LeadID] FOREIGN KEY([LeadID])
REFERENCES [dbo].[LeadMaster] ([LeadID])
GO
ALTER TABLE [dbo].[QuoteProducts] CHECK CONSTRAINT [fk_QuoteProducts_LeadID]
GO
ALTER TABLE [dbo].[QuoteProducts]  WITH CHECK ADD  CONSTRAINT [fk_QuoteProducts_QuoteDetailID] FOREIGN KEY([QuoteDetailID])
REFERENCES [dbo].[QuoteDetail] ([QuoteDetailID])
GO
ALTER TABLE [dbo].[QuoteProducts] CHECK CONSTRAINT [fk_QuoteProducts_QuoteDetailID]
GO
USE [master]
GO
ALTER DATABASE [EConnect] SET  READ_WRITE 
GO
