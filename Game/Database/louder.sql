USE [master]
GO
/****** Object:  Database [Louder]    Script Date: 04/16/2018 20:11:23 ******/
CREATE DATABASE [Louder] ON  PRIMARY 
( NAME = N'Louder', FILENAME = N'D:\Software Engineering\Final Project\Source\Database\Louder.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Louder_log', FILENAME = N'D:\Software Engineering\Final Project\Source\Database\Louder_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Louder] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Louder].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Louder] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Louder] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Louder] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Louder] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Louder] SET ARITHABORT OFF
GO
ALTER DATABASE [Louder] SET AUTO_CLOSE ON
GO
ALTER DATABASE [Louder] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Louder] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Louder] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Louder] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Louder] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Louder] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Louder] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Louder] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Louder] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Louder] SET  ENABLE_BROKER
GO
ALTER DATABASE [Louder] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Louder] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Louder] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Louder] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Louder] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Louder] SET READ_COMMITTED_SNAPSHOT ON
GO
ALTER DATABASE [Louder] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Louder] SET  READ_WRITE
GO
ALTER DATABASE [Louder] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Louder] SET  MULTI_USER
GO
ALTER DATABASE [Louder] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Louder] SET DB_CHAINING OFF
GO
USE [Louder]
GO
/****** Object:  Table [dbo].[Themes]    Script Date: 04/16/2018 20:11:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Themes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Themes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Themes] ON
INSERT [dbo].[Themes] ([Id], [Name]) VALUES (1, N'Animal')
SET IDENTITY_INSERT [dbo].[Themes] OFF
/****** Object:  Table [dbo].[PlayHistories]    Script Date: 04/16/2018 20:11:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayHistories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PlayHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 04/16/2018 20:11:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201804161255452_init', N'Game.Migrations.Configuration', 0x1F8B0800000000000400ED5ADD6EDB3614BE1FB0771074B50DA995B4375D60B7489DA4331627419476BB0B68E9D82146519A480536863DD92EF6487B851D4A944451B22D3B3F288AA24061513CDF393C7FFA78DAFFFEF977F87E1931E7015241633E728F0687AE033C8843CA17233793F3576FDDF7EFBEFF6E7816464BE773B9EF8DDA87925C8CDC7B299363CF13C13D44440C221AA4B188E77210C49147C2D87B7D78F8B37774E40142B888E538C39B8C4B1A41FE808FE3980790C88CB0691C02137A1DDFF839AA73492210090960E47EC49F837C9BEB9C304AD0021FD8DC7508E7B12412ED3BFE24C09769CC177E820B84DDAE12C07D73C20468BB8FEBED7D8F70F85A1DC1AB054BA82013328E76043C7AA37DE2D9E27B79D6AD7C865E3B43EFCA953A75EEB9917BCDC8EA178A6AD295EBD8FA8EC72C557B4DDF0E0C890347AD1F54D1C724517F0E9C71C66496C288432653C20E9CEB6CC668F02BAC6EE33F808F78C69869175A86EF1A0BB8749DC609A4727503736DED24741DAF29E7D982959821531C62C2E59BD7AE7389CAC98C411576E3C03E1E0B3E0287944808AF899490728501B9E35ADA2D5DA728556A53BF6F31953B146E06F103B4619BCD26C4D0ABC3BA31D8B7982ED033CCF9DE6F01B674A9BF4B6DD848B017BACE942C2F802FE4FDC8C59FAE734E9710962BDA824F9C62EB44219966FB46EF731C9059C648EF4AAD05BEC5D1D275C6178C8AFBDFE2347CE27076340598534E8BFEFDCCAAF091673CA0E445B4F9093096433FB3A24944164F5D761D5AC40590944395111FE29801E1DB1BF82579A08BDCE716A46EB837C0F2B7E29E260529316AF34E6F3A4FE3E826668D422FDEDDF9719606CA01F19A0DB7245D80ECD7574E84887586B41A8BB6A579BA331E3ADB0C2B22D33C188608BB0B4DB09FA01923F7A796DF362097273290B59F9AA08783C1917D6EE384ED868A8C52128A7D431F7E8A0FA7B38E8E8A54513755A1F3C7365EC1F9205B4C8A82709DDAF9DAFC06D36A39A289951FB50B44FB608BB86A6B5DD2666C2C08C367354E3B498D6DEB12D9FE38F4489FCAFECA746F079432550C94D27FF627A879CA8E62A9B2A3BE6878C54DA3BC91786BAE24C32949126C4CC61545AF387E713F19BFF27727F05181E105A283C757D6569A30BBB0555A6F51355A7A4E532191949219512D6C1C46AD6DBA16D62457A9A42BDDDBE12A53AF9452BF0BC9EEBB840D51FBEF1C8F14E1673D3F1D1851DE289D5F1109A64907CB18C72C8BF83AA6B249BA20F8A67CB1D21F41B37B13422FB531869EE502DBCD5ECBCF56C2DBC1EB155A5D3D7BC6B4B30BF488E61AB9E78963C1E34DF962E58B8941D107F70C81D1E7778FC326E1E70946838C9B308D173B14A941B81BA56AACF747B338B50968BDDAA10954CCB9D107AAD5FE489A1A379C5F2CED805113DF064EBDFCF265D1FC52376BA34D4BB65441B9AD7FAA2BBE6179691DEF68BBA6578914185D85A25C5329DFC32ECDAAF6B46B678B903F8479513913A12E4AD525A9CF696D4AD6CE851633B3B754995831348B890D352BDA3E416ED1A4628BEBE0D91F68A82892BF1212A281DA30F0FF64634631F7EB0D53C2E91C842CA6272EB2B8B7D630FACB190C7B4284ACFF74F8C5A740543976EB9C67C7E1AA39A10DF1B77CF4843637F329E7B35F87A3CD49297F2069704FD21F22B2FCD1447A9A69E8D7E1B08E91E40E7EEB33767C145CE768F15188F6F8F051608D11E1E390EC31E08C6E2BF03648FDBD3332A635629AF0109623F7AF5CE8D899FC7E57CA1D3857297E4E8E9D43E7EFFD0AE611633E8354ED367A5B33A7D97B3E88F50AA92A27C2F0F32F648A04A04534AF538A699910D6B0BECD7EFA3401E5CE0ACF7E730A097055DDED03F6D1B689F055D0564BDAE6801D679DED3150DF91E66ADB40B3604AF84D9DC518EE2259AD89689F99E7FA9167978235633E1BD94CB98D33D12E1DD5FBAE33BCC4D4B4E1176352D26F46DA10DC30FF7D92D1689B68630A1BFFA1034B48D0450DA1EE0E1C8246F2567B267C1E97556459546EB19AEE1424414E474E5249E72490F83A0021F24FCC67C232F5918D66104EF85526934CE291219AB18633542D6ED29FCF7F9B360FAF92FC1F779EE208682655B4F48A7FC8280B2BBBCF3B58E51A0855E49A96A8584A454F16AB0AE932E63D81B4FBAADE740B51C2104C5C719F3CC03EB67D1270010B12ACCAFBD27A90ED8168BA7D784AC9222591D018B53C3E620E87D1F2DDFF4DD663F5D7240000, N'6.2.0-61023')
/****** Object:  Table [dbo].[Vocabularies]    Script Date: 04/16/2018 20:11:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vocabularies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EnglishWord] [nvarchar](max) NULL,
	[Definition] [nvarchar](max) NULL,
	[Pronunciation] [nvarchar](max) NULL,
	[Spelling] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[IsLearned] [bit] NOT NULL,
	[Theme_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Vocabularies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Theme_Id] ON [dbo].[Vocabularies] 
(
	[Theme_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Vocabularies] ON
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (3, N'cat', N'con mèo', N'/Audios/Vocabulary Pronunciations/cat.mp3', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (4, N'cow', N'con bò', N'/Audios/Vocabulary Pronunciations/cow.mp3', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (5, N'dog', N'con chó', N'/Audios/Vocabulary Pronunciations/dog.mp3', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (6, N'elephant', NULL, N'/Audios/Vocabulary Pronunciations/elephant.mp3', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (8, N'horse', NULL, N'/Audios/Vocabulary Pronunciations/horse.mp3', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (9, N'lion', NULL, N'/Audios/Vocabulary Pronunciations/lion.mp3', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (10, N'monkey', NULL, N'/Audios/Vocabulary Pronunciations/monkey', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (11, N'mouse', NULL, N'/Audios/Vocabulary Pronunciations/mouse.mp3', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (12, N'panda', NULL, N'/Audios/Vocabulary Pronunciations/panda.mp3', NULL, NULL, 0, 1)
INSERT [dbo].[Vocabularies] ([Id], [EnglishWord], [Definition], [Pronunciation], [Spelling], [Image], [IsLearned], [Theme_Id]) VALUES (13, N'rabbit', NULL, N'/Audios/Vocabulary Pronunciations/rabbit.mp3', NULL, NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[Vocabularies] OFF
/****** Object:  ForeignKey [FK_dbo.Vocabularies_dbo.Themes_Theme_Id]    Script Date: 04/16/2018 20:11:24 ******/
ALTER TABLE [dbo].[Vocabularies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vocabularies_dbo.Themes_Theme_Id] FOREIGN KEY([Theme_Id])
REFERENCES [dbo].[Themes] ([Id])
GO
ALTER TABLE [dbo].[Vocabularies] CHECK CONSTRAINT [FK_dbo.Vocabularies_dbo.Themes_Theme_Id]
GO
