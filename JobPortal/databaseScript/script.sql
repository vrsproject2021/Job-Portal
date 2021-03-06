USE [master]
GO
/****** Object:  Database [JobPortaldb]    Script Date: 14-01-2022 13:43:26 ******/
CREATE DATABASE [JobPortaldb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JobPortaldb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\JobPortaldb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JobPortaldb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\JobPortaldb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JobPortaldb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JobPortaldb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JobPortaldb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JobPortaldb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JobPortaldb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JobPortaldb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JobPortaldb] SET ARITHABORT OFF 
GO
ALTER DATABASE [JobPortaldb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JobPortaldb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JobPortaldb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JobPortaldb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JobPortaldb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JobPortaldb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JobPortaldb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JobPortaldb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JobPortaldb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JobPortaldb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JobPortaldb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JobPortaldb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JobPortaldb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JobPortaldb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JobPortaldb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JobPortaldb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JobPortaldb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JobPortaldb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JobPortaldb] SET  MULTI_USER 
GO
ALTER DATABASE [JobPortaldb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JobPortaldb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JobPortaldb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JobPortaldb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JobPortaldb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JobPortaldb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [JobPortaldb] SET QUERY_STORE = OFF
GO
USE [JobPortaldb]
GO
/****** Object:  Table [dbo].[business_stream]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[business_stream](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[business_stream_name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company_name] [varchar](100) NOT NULL,
	[profile_description] [varchar](1000) NOT NULL,
	[business_stream_id] [int] NOT NULL,
	[establishment_date] [date] NOT NULL,
	[company_website_url] [varchar](500) NOT NULL,
	[user_account_id] [int] NOT NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company_image]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company_image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company_id] [int] NOT NULL,
	[company_image] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_company_image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[job_location]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job_location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[street_address] [varchar](100) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[state] [varchar](50) NOT NULL,
	[country] [varchar](50) NOT NULL,
	[zip] [varchar](50) NOT NULL,
	[user_account_id] [int] NOT NULL,
 CONSTRAINT [PK_job_location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[job_post]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job_post](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[posted_by_id] [int] NOT NULL,
	[job_type_id] [int] NOT NULL,
	[company_id] [int] NOT NULL,
	[created_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[job_description] [varchar](500) NOT NULL,
	[job_location_id] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[min salary] [int] NOT NULL,
	[max salary] [int] NOT NULL,
 CONSTRAINT [PK_job_post] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[job_post_activity]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job_post_activity](
	[user_account_id] [int] NOT NULL,
	[job_post_id] [int] NOT NULL,
	[apply_date] [date] NOT NULL,
	[is_deleted] [bit] NOT NULL,
 CONSTRAINT [PK_job_post_activity] PRIMARY KEY CLUSTERED 
(
	[job_post_id] ASC,
	[user_account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[job_post_skill_set]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job_post_skill_set](
	[skill_set_id] [int] NOT NULL,
	[job_post_id] [int] NOT NULL,
	[skill_level] [int] NOT NULL,
 CONSTRAINT [PK_job_post_skill_set] PRIMARY KEY CLUSTERED 
(
	[skill_set_id] ASC,
	[job_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[job_type]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[job_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[job_type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_job_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seeker_education]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seeker_education](
	[user_account_id] [int] NOT NULL,
	[certificate_degree_name] [nvarchar](100) NOT NULL,
	[major] [nvarchar](100) NOT NULL,
	[university_institute_name] [nvarchar](100) NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NULL,
	[cgpa_percentage] [nchar](10) NULL,
 CONSTRAINT [PK_seeker_education] PRIMARY KEY CLUSTERED 
(
	[user_account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seeker_experience]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seeker_experience](
	[user_account_id] [int] NOT NULL,
	[company_name] [nvarchar](255) NOT NULL,
	[job_title] [nvarchar](255) NOT NULL,
	[job_description] [nvarchar](500) NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NULL,
	[job_location_country] [nvarchar](50) NOT NULL,
	[job_location_state] [nvarchar](50) NOT NULL,
	[job_location_city] [nvarchar](50) NULL,
	[currently_working] [bit] NOT NULL,
 CONSTRAINT [PK_seeker_experience] PRIMARY KEY CLUSTERED 
(
	[user_account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seeker_files]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seeker_files](
	[user_account_id] [int] NOT NULL,
	[linkedin_address] [nvarchar](200) NULL,
	[resume] [int] NULL,
	[image] [image] NULL,
 CONSTRAINT [PK_seeker_files] PRIMARY KEY CLUSTERED 
(
	[user_account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seeker_log]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seeker_log](
	[user_account_id] [int] NOT NULL,
	[last_login_date] [date] NOT NULL,
	[last_apply_date] [date] NULL,
 CONSTRAINT [PK_seeker_log] PRIMARY KEY CLUSTERED 
(
	[user_account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seeker_profile]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seeker_profile](
	[user_account_id] [int] NOT NULL,
	[first_name] [nvarchar](255) NOT NULL,
	[last_name] [nvarchar](255) NOT NULL,
	[gender] [nchar](10) NOT NULL,
	[date_of_birth] [date] NOT NULL,
 CONSTRAINT [PK_seeker_profile] PRIMARY KEY CLUSTERED 
(
	[user_account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seeker_skill]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seeker_skill](
	[user_account_id] [int] NOT NULL,
	[skill_set_id] [int] NOT NULL,
	[skill_level] [int] NOT NULL,
 CONSTRAINT [PK_seeker_skill] PRIMARY KEY CLUSTERED 
(
	[user_account_id] ASC,
	[skill_set_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[skill_set]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[skill_set](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[skill_name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_skill_set] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_account]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email_id] [nvarchar](250) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[phone_number] [nvarchar](15) NULL,
	[user_type] [varchar](30) NOT NULL,
 CONSTRAINT [PK_user_account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[business_stream] ON 

INSERT [dbo].[business_stream] ([id], [business_stream_name]) VALUES (1, N'Information technology')
INSERT [dbo].[business_stream] ([id], [business_stream_name]) VALUES (2, N'Construction')
SET IDENTITY_INSERT [dbo].[business_stream] OFF
GO
SET IDENTITY_INSERT [dbo].[company] ON 

INSERT [dbo].[company] ([id], [company_name], [profile_description], [business_stream_id], [establishment_date], [company_website_url], [user_account_id]) VALUES (1, N'NewTech', N'A new IT company', 1, CAST(N'2010-02-03' AS Date), N'NewTech.com', 3)
INSERT [dbo].[company] ([id], [company_name], [profile_description], [business_stream_id], [establishment_date], [company_website_url], [user_account_id]) VALUES (2, N'bourntec', N'adfafgdfgoiert', 1, CAST(N'2021-12-16' AS Date), N'https://www.tcs.com/', 4)
INSERT [dbo].[company] ([id], [company_name], [profile_description], [business_stream_id], [establishment_date], [company_website_url], [user_account_id]) VALUES (3, N'x.com', N'adfafgdfgoiert', 1, CAST(N'2021-12-03' AS Date), N'https://www.x.com/', 4)
SET IDENTITY_INSERT [dbo].[company] OFF
GO
SET IDENTITY_INSERT [dbo].[job_location] ON 

INSERT [dbo].[job_location] ([id], [street_address], [city], [state], [country], [zip], [user_account_id]) VALUES (1, N'big street', N'cochin', N'kerala', N'india', N'123456', 3)
INSERT [dbo].[job_location] ([id], [street_address], [city], [state], [country], [zip], [user_account_id]) VALUES (2, N'new street', N'Tvm', N'Kerala', N'india', N'234567', 3)
INSERT [dbo].[job_location] ([id], [street_address], [city], [state], [country], [zip], [user_account_id]) VALUES (3, N'adaafa', N'kottayam', N'kerala', N'India', N'345343', 4)
INSERT [dbo].[job_location] ([id], [street_address], [city], [state], [country], [zip], [user_account_id]) VALUES (4, N'south', N'Trivandrum', N'kerala', N'India', N'213489', 4)
INSERT [dbo].[job_location] ([id], [street_address], [city], [state], [country], [zip], [user_account_id]) VALUES (5, N'north', N'Alappuzha', N'kerala', N'India', N'213489', 4)
SET IDENTITY_INSERT [dbo].[job_location] OFF
GO
SET IDENTITY_INSERT [dbo].[job_post] ON 

INSERT [dbo].[job_post] ([id], [posted_by_id], [job_type_id], [company_id], [created_date], [end_date], [job_description], [job_location_id], [is_active], [min salary], [max salary]) VALUES (1, 3, 1, 1, CAST(N'2021-04-02' AS Date), CAST(N'2021-05-06' AS Date), N'an new IT job is available', 1, 1, 10000, 25000)
INSERT [dbo].[job_post] ([id], [posted_by_id], [job_type_id], [company_id], [created_date], [end_date], [job_description], [job_location_id], [is_active], [min salary], [max salary]) VALUES (3, 4, 1, 1, CAST(N'2021-12-16' AS Date), CAST(N'2021-12-30' AS Date), N'fasdfsdvdsfvlfkv', 4, 1, 10000, 50000)
INSERT [dbo].[job_post] ([id], [posted_by_id], [job_type_id], [company_id], [created_date], [end_date], [job_description], [job_location_id], [is_active], [min salary], [max salary]) VALUES (4, 4, 1, 1, CAST(N'2021-12-20' AS Date), CAST(N'2021-12-31' AS Date), N'adfasddsfcbcv', 4, 1, 30000, 40000)
INSERT [dbo].[job_post] ([id], [posted_by_id], [job_type_id], [company_id], [created_date], [end_date], [job_description], [job_location_id], [is_active], [min salary], [max salary]) VALUES (5, 4, 1, 1, CAST(N'2021-12-21' AS Date), CAST(N'2021-12-31' AS Date), N'something', 4, 1, 30000, 60000)
INSERT [dbo].[job_post] ([id], [posted_by_id], [job_type_id], [company_id], [created_date], [end_date], [job_description], [job_location_id], [is_active], [min salary], [max salary]) VALUES (6, 4, 1, 3, CAST(N'2021-12-22' AS Date), CAST(N'2021-12-31' AS Date), N'sfadddff', 4, 1, 30000, 35000)
INSERT [dbo].[job_post] ([id], [posted_by_id], [job_type_id], [company_id], [created_date], [end_date], [job_description], [job_location_id], [is_active], [min salary], [max salary]) VALUES (7, 4, 1, 1, CAST(N'2021-12-22' AS Date), CAST(N'2021-12-30' AS Date), N'dsafjkds', 4, 1, 1000000, 2000000)
INSERT [dbo].[job_post] ([id], [posted_by_id], [job_type_id], [company_id], [created_date], [end_date], [job_description], [job_location_id], [is_active], [min salary], [max salary]) VALUES (8, 4, 1, 1, CAST(N'2022-01-06' AS Date), CAST(N'2022-01-28' AS Date), N'dssadfsadfsadfas', 4, 1, 1000000, 2000000)
INSERT [dbo].[job_post] ([id], [posted_by_id], [job_type_id], [company_id], [created_date], [end_date], [job_description], [job_location_id], [is_active], [min salary], [max salary]) VALUES (9, 4, 1, 1, CAST(N'2022-01-06' AS Date), CAST(N'2022-01-23' AS Date), N'asdfasdf', 4, 1, 1000000, 2000000)
SET IDENTITY_INSERT [dbo].[job_post] OFF
GO
INSERT [dbo].[job_post_activity] ([user_account_id], [job_post_id], [apply_date], [is_deleted]) VALUES (2, 1, CAST(N'2021-05-04' AS Date), 0)
INSERT [dbo].[job_post_activity] ([user_account_id], [job_post_id], [apply_date], [is_deleted]) VALUES (5, 1, CAST(N'2021-12-21' AS Date), 1)
INSERT [dbo].[job_post_activity] ([user_account_id], [job_post_id], [apply_date], [is_deleted]) VALUES (8, 1, CAST(N'2022-01-07' AS Date), 0)
INSERT [dbo].[job_post_activity] ([user_account_id], [job_post_id], [apply_date], [is_deleted]) VALUES (8, 4, CAST(N'2022-01-07' AS Date), 0)
INSERT [dbo].[job_post_activity] ([user_account_id], [job_post_id], [apply_date], [is_deleted]) VALUES (5, 5, CAST(N'2021-12-21' AS Date), 1)
GO
INSERT [dbo].[job_post_skill_set] ([skill_set_id], [job_post_id], [skill_level]) VALUES (1, 1, 3)
INSERT [dbo].[job_post_skill_set] ([skill_set_id], [job_post_id], [skill_level]) VALUES (1, 4, 0)
INSERT [dbo].[job_post_skill_set] ([skill_set_id], [job_post_id], [skill_level]) VALUES (2, 6, 0)
INSERT [dbo].[job_post_skill_set] ([skill_set_id], [job_post_id], [skill_level]) VALUES (2, 8, 0)
INSERT [dbo].[job_post_skill_set] ([skill_set_id], [job_post_id], [skill_level]) VALUES (3, 9, 0)
INSERT [dbo].[job_post_skill_set] ([skill_set_id], [job_post_id], [skill_level]) VALUES (4, 5, 0)
INSERT [dbo].[job_post_skill_set] ([skill_set_id], [job_post_id], [skill_level]) VALUES (4, 7, 0)
GO
SET IDENTITY_INSERT [dbo].[job_type] ON 

INSERT [dbo].[job_type] ([id], [job_type]) VALUES (1, N'Full Time')
INSERT [dbo].[job_type] ([id], [job_type]) VALUES (2, N'Part Time')
INSERT [dbo].[job_type] ([id], [job_type]) VALUES (3, N'Contract')
INSERT [dbo].[job_type] ([id], [job_type]) VALUES (4, N'Temporary')
SET IDENTITY_INSERT [dbo].[job_type] OFF
GO
INSERT [dbo].[seeker_education] ([user_account_id], [certificate_degree_name], [major], [university_institute_name], [start_date], [end_date], [cgpa_percentage]) VALUES (5, N'BE', N'CSE', N'kerala', CAST(N'2018-08-03' AS Date), CAST(N'2021-04-30' AS Date), N'7.5       ')
INSERT [dbo].[seeker_education] ([user_account_id], [certificate_degree_name], [major], [university_institute_name], [start_date], [end_date], [cgpa_percentage]) VALUES (8, N'BE', N'CSE', N'Anna', CAST(N'2017-09-11' AS Date), CAST(N'2021-03-27' AS Date), N'7.5       ')
GO
INSERT [dbo].[seeker_experience] ([user_account_id], [company_name], [job_title], [job_description], [start_date], [end_date], [job_location_country], [job_location_state], [job_location_city], [currently_working]) VALUES (5, N'company', N'test engineer', N'sdfsdfs', CAST(N'2022-01-01' AS Date), CAST(N'2022-01-07' AS Date), N'India', N'kerala', N'trivandrum', 1)
INSERT [dbo].[seeker_experience] ([user_account_id], [company_name], [job_title], [job_description], [start_date], [end_date], [job_location_country], [job_location_state], [job_location_city], [currently_working]) VALUES (8, N'infosys', N'developer', N'adsfsadfasdfas', CAST(N'2019-03-08' AS Date), CAST(N'2021-12-17' AS Date), N'India', N'kerala', N'trivandrum', 1)
GO
INSERT [dbo].[seeker_profile] ([user_account_id], [first_name], [last_name], [gender], [date_of_birth]) VALUES (5, N'Subin', N'S', N'Male      ', CAST(N'1999-06-12' AS Date))
INSERT [dbo].[seeker_profile] ([user_account_id], [first_name], [last_name], [gender], [date_of_birth]) VALUES (8, N'Applicant', N'A', N'Female    ', CAST(N'2000-07-14' AS Date))
GO
SET IDENTITY_INSERT [dbo].[skill_set] ON 

INSERT [dbo].[skill_set] ([id], [skill_name]) VALUES (1, N'flutter')
INSERT [dbo].[skill_set] ([id], [skill_name]) VALUES (2, N'python developer')
INSERT [dbo].[skill_set] ([id], [skill_name]) VALUES (3, N'data engineer')
INSERT [dbo].[skill_set] ([id], [skill_name]) VALUES (4, N'full stack developer')
INSERT [dbo].[skill_set] ([id], [skill_name]) VALUES (5, N'SQL developer')
SET IDENTITY_INSERT [dbo].[skill_set] OFF
GO
SET IDENTITY_INSERT [dbo].[user_account] ON 

INSERT [dbo].[user_account] ([id], [email_id], [password], [phone_number], [user_type]) VALUES (1, N'admin@jp.com', N'adminpassword', N'0123456789', N'admin')
INSERT [dbo].[user_account] ([id], [email_id], [password], [phone_number], [user_type]) VALUES (2, N'jobseeker@jp.com', N'jobseekerpassword', N'0023456789', N'jobseeker')
INSERT [dbo].[user_account] ([id], [email_id], [password], [phone_number], [user_type]) VALUES (3, N'jobprovider@jp.com', N'jobproviderpassword', N'0123456780', N'jobprovider')
INSERT [dbo].[user_account] ([id], [email_id], [password], [phone_number], [user_type]) VALUES (4, N'company@gmail.com', N'PnBCm0ftpMvvltI9n6slSw==', N'9867554323', N'jobprovider')
INSERT [dbo].[user_account] ([id], [email_id], [password], [phone_number], [user_type]) VALUES (5, N'subin@gmail.com', N'AGmLRf/5zVielqyBMhTf8JB4yCH3OKOMF1UHvknYTvzlphTxyGtPX3uoM2XEtz140A==', N'3456219875', N'jobseeker')
INSERT [dbo].[user_account] ([id], [email_id], [password], [phone_number], [user_type]) VALUES (6, N'karthik@gmail.com', N'ABGpFVdnDxVJU6seHJUSL5Av20omA7LH5VNRCPGuzD6DnE+UdD0vyJI8Z2Kl7TJ+5Q==', N'7493740887', N'jobseeker')
INSERT [dbo].[user_account] ([id], [email_id], [password], [phone_number], [user_type]) VALUES (7, N'Admin@gmail.com', N'NKKQThSXM86X2NbcV6GFag==', N'+919497716416', N'Admin')
INSERT [dbo].[user_account] ([id], [email_id], [password], [phone_number], [user_type]) VALUES (8, N'Applicant@gmail.com', N'AFeJ3GsPUdGU5DiCB9vWteqzSbLuXYi0e8IszWkk87Xz2k5AqV2ES99bPqUyjZMoRA==', N'9867554323', N'jobseeker')
SET IDENTITY_INSERT [dbo].[user_account] OFF
GO
ALTER TABLE [dbo].[company]  WITH CHECK ADD  CONSTRAINT [FK_company_business_stream] FOREIGN KEY([business_stream_id])
REFERENCES [dbo].[business_stream] ([id])
GO
ALTER TABLE [dbo].[company] CHECK CONSTRAINT [FK_company_business_stream]
GO
ALTER TABLE [dbo].[company]  WITH CHECK ADD  CONSTRAINT [FK_company_user_account] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[user_account] ([id])
GO
ALTER TABLE [dbo].[company] CHECK CONSTRAINT [FK_company_user_account]
GO
ALTER TABLE [dbo].[company_image]  WITH CHECK ADD  CONSTRAINT [FK_company_image_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[company] ([id])
GO
ALTER TABLE [dbo].[company_image] CHECK CONSTRAINT [FK_company_image_company]
GO
ALTER TABLE [dbo].[job_location]  WITH CHECK ADD  CONSTRAINT [FK_job_location_user_account] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[user_account] ([id])
GO
ALTER TABLE [dbo].[job_location] CHECK CONSTRAINT [FK_job_location_user_account]
GO
ALTER TABLE [dbo].[job_post]  WITH CHECK ADD  CONSTRAINT [FK_job_post_company] FOREIGN KEY([company_id])
REFERENCES [dbo].[company] ([id])
GO
ALTER TABLE [dbo].[job_post] CHECK CONSTRAINT [FK_job_post_company]
GO
ALTER TABLE [dbo].[job_post]  WITH CHECK ADD  CONSTRAINT [FK_job_post_job_location] FOREIGN KEY([job_location_id])
REFERENCES [dbo].[job_location] ([id])
GO
ALTER TABLE [dbo].[job_post] CHECK CONSTRAINT [FK_job_post_job_location]
GO
ALTER TABLE [dbo].[job_post]  WITH CHECK ADD  CONSTRAINT [FK_job_post_job_type] FOREIGN KEY([job_type_id])
REFERENCES [dbo].[job_type] ([id])
GO
ALTER TABLE [dbo].[job_post] CHECK CONSTRAINT [FK_job_post_job_type]
GO
ALTER TABLE [dbo].[job_post]  WITH CHECK ADD  CONSTRAINT [FK_job_post_user_account] FOREIGN KEY([posted_by_id])
REFERENCES [dbo].[user_account] ([id])
GO
ALTER TABLE [dbo].[job_post] CHECK CONSTRAINT [FK_job_post_user_account]
GO
ALTER TABLE [dbo].[job_post_activity]  WITH CHECK ADD  CONSTRAINT [FK_job_post_activity_job_post] FOREIGN KEY([job_post_id])
REFERENCES [dbo].[job_post] ([id])
GO
ALTER TABLE [dbo].[job_post_activity] CHECK CONSTRAINT [FK_job_post_activity_job_post]
GO
ALTER TABLE [dbo].[job_post_activity]  WITH CHECK ADD  CONSTRAINT [FK_job_post_activity_user_account] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[user_account] ([id])
GO
ALTER TABLE [dbo].[job_post_activity] CHECK CONSTRAINT [FK_job_post_activity_user_account]
GO
ALTER TABLE [dbo].[job_post_skill_set]  WITH CHECK ADD  CONSTRAINT [FK_job_post_skill_set_job_post] FOREIGN KEY([job_post_id])
REFERENCES [dbo].[job_post] ([id])
GO
ALTER TABLE [dbo].[job_post_skill_set] CHECK CONSTRAINT [FK_job_post_skill_set_job_post]
GO
ALTER TABLE [dbo].[job_post_skill_set]  WITH CHECK ADD  CONSTRAINT [FK_job_post_skill_set_skill_set] FOREIGN KEY([skill_set_id])
REFERENCES [dbo].[skill_set] ([id])
GO
ALTER TABLE [dbo].[job_post_skill_set] CHECK CONSTRAINT [FK_job_post_skill_set_skill_set]
GO
ALTER TABLE [dbo].[seeker_education]  WITH CHECK ADD  CONSTRAINT [FK_seeker_education_seeker_profile] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[seeker_profile] ([user_account_id])
GO
ALTER TABLE [dbo].[seeker_education] CHECK CONSTRAINT [FK_seeker_education_seeker_profile]
GO
ALTER TABLE [dbo].[seeker_experience]  WITH CHECK ADD  CONSTRAINT [FK_seeker_experience_seeker_profile] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[seeker_profile] ([user_account_id])
GO
ALTER TABLE [dbo].[seeker_experience] CHECK CONSTRAINT [FK_seeker_experience_seeker_profile]
GO
ALTER TABLE [dbo].[seeker_files]  WITH CHECK ADD  CONSTRAINT [FK_seeker_files_seeker_profile] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[seeker_profile] ([user_account_id])
GO
ALTER TABLE [dbo].[seeker_files] CHECK CONSTRAINT [FK_seeker_files_seeker_profile]
GO
ALTER TABLE [dbo].[seeker_log]  WITH CHECK ADD  CONSTRAINT [FK_seeker_log_user_account] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[user_account] ([id])
GO
ALTER TABLE [dbo].[seeker_log] CHECK CONSTRAINT [FK_seeker_log_user_account]
GO
ALTER TABLE [dbo].[seeker_profile]  WITH CHECK ADD  CONSTRAINT [FK_seeker_profile_user_account] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[user_account] ([id])
GO
ALTER TABLE [dbo].[seeker_profile] CHECK CONSTRAINT [FK_seeker_profile_user_account]
GO
ALTER TABLE [dbo].[seeker_skill]  WITH CHECK ADD  CONSTRAINT [FK_seeker_skill_seeker_profile] FOREIGN KEY([user_account_id])
REFERENCES [dbo].[seeker_profile] ([user_account_id])
GO
ALTER TABLE [dbo].[seeker_skill] CHECK CONSTRAINT [FK_seeker_skill_seeker_profile]
GO
ALTER TABLE [dbo].[seeker_skill]  WITH CHECK ADD  CONSTRAINT [FK_seeker_skill_skill_set] FOREIGN KEY([skill_set_id])
REFERENCES [dbo].[skill_set] ([id])
GO
ALTER TABLE [dbo].[seeker_skill] CHECK CONSTRAINT [FK_seeker_skill_skill_set]
GO
/****** Object:  StoredProcedure [dbo].[add_job_post]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[add_job_post](
@posted_by_id INTEGER,
@job_type_id INTEGER,
@company_id INTEGER,
@created_date DATE,
@end_date DATE,
@job_description varchar(500),
@job_loaction_id INTEGER,
@is_active bit,
@min_salary INTEGER,
@max_salary INTEGER,
@skill_set_id INTEGER,
@skill_level INTEGER = 0)
AS
BEGIN
DECLARE @job_post_id  INT
	INSERT INTO job_post (posted_by_id,job_type_id,company_id,created_date,end_date,job_description,job_location_id,is_active,[min salary],[max salary])
	VALUES (@posted_by_id,@job_type_id,@company_id,@created_date,@end_date,@job_description,@job_loaction_id,@is_active,@min_salary,@max_salary)
	
	SET @job_post_id = SCOPE_IDENTITY()
	
	INSERT INTO job_post_skill_set
	VALUES (@skill_set_id,@job_post_id,@skill_level)
	
END
GO
/****** Object:  StoredProcedure [dbo].[add_seeker_skill]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[add_seeker_skill](
@user_id INTEGER = 0,
@skill_name VARCHAR(255),
@skill_level INTEGER)
AS
BEGIN
DECLARE @skill_id INT
	SET @skill_id =(SELECT id 
					FROM[dbo].[skill_set] 
					WHERE skill_name = @skill_name)
	IF (@skill_id is NULL)
		BEGIN
			select @skill_id
			INSERT INTO [dbo].[skill_set] (skill_name)
			VALUES(@skill_name)
			SET @skill_id =(SELECT id 
							FROM[dbo].[skill_set] 
							WHERE skill_name = @skill_name)
		END		
	IF @skill_id IS NOT null
		BEGIN
			INSERT INTO [dbo].[seeker_skill](user_account_id,skill_set_id,skill_level) 
			VALUES (@user_id,@skill_id,@skill_level)
		END
END
GO
/****** Object:  StoredProcedure [dbo].[delete_seeker_skill]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delete_seeker_skill](
@user_id INTEGER = 0,
@skill_name VARCHAR(255)
)
AS
BEGIN
		DECLARE @skill_id INT
		SET @skill_id =(SELECT id 
					FROM[dbo].[skill_set] 
					WHERE skill_name = @skill_name)
		DELETE FROM [dbo].[seeker_skill]
		WHERE skill_set_id = @skill_id AND user_account_id = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[get_applied_jobs]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_applied_jobs](@user_id INTEGER=0)
AS
BEGIN
		SELECT job_description,company_name,city,state,skill_level,skill_name,job_type,apply_date,job_post_activity.job_post_id
		FROM job_post_activity
		join job_post 
		on job_post_activity.job_post_id = job_post.id
		join company 
		on job_post.company_id = company.id
		join job_location
		on job_post.job_location_id = job_location.id
		join job_post_skill_set
		on job_post.id = job_post_skill_set.job_post_id
		join skill_set
		on job_post_skill_set.skill_set_id = skill_set.id
		join job_type
		on job_post.job_type_id =job_type.id
		where job_post_activity.user_account_id = @user_id AND job_post_activity.is_deleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[get_seeker_skills]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_seeker_skills](@user_id INTEGER=0)
AS
BEGIN
		SELECT skill_name,skill_level
		FROM seeker_profile
		join seeker_skill 
		on seeker_profile.user_account_id = seeker_skill.user_account_id
		join skill_set 
		on seeker_skill.skill_set_id = skill_set.id
		where seeker_profile.user_account_id = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[search_for_jobs]    Script Date: 14-01-2022 13:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[search_for_jobs](@skill_searched varchar(255),@location_searched varchar(255))
AS
BEGIN
		SELECT job_description,company_name,city,state,skill_level,skill_name,job_type,job_post.id
		FROM job_post
		join company 
		on job_post.company_id = company.id
		join job_location
		on job_post.job_location_id = job_location.id
		join job_post_skill_set
		on job_post.id = job_post_skill_set.job_post_id
		join skill_set
		on job_post_skill_set.skill_set_id = skill_set.id
		join job_type
		on job_post.job_type_id =job_type.id
		where  (job_location.country LIKE '%'+@location_searched+'%' 
		OR job_location.state LIKE '%@'+@location_searched+'%' 
		OR job_location.city LIKE '%'+@location_searched+'%') 
		AND skill_name LIKE '%'+@skill_searched+'%'
END
GO
USE [master]
GO
ALTER DATABASE [JobPortaldb] SET  READ_WRITE 
GO
