CREATE TABLE [dbo].[Artisan](
	[idArtisan] [int] IDENTITY(1,1) NOT NULL,
	[Sigle] [nchar](10) NULL,
	[Nom] [nchar](10) NULL,
	[Prenom] [nchar](10) NULL,
	[Adresse] [nchar](20) NULL,
	[CodePostal] [int] NULL,
	[Telephone] [nchar](10) NULL,
	[Email] [nchar](20) NULL,
 CONSTRAINT [PK_Artisan] PRIMARY KEY CLUSTERED 
(
	[idArtisan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 11/02/2015 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[idClient] [int] IDENTITY(1,1) NOT NULL,
	[Sigle] [nchar](10) NULL,
	[Nom] [nchar](10) NULL,
	[Prenom] [nchar](10) NULL,
	[Adresse] [nchar](10) NULL,
	[CodePostal] [int] NULL,
	[Pays] [nchar](10) NULL,
	[Telephone] [nchar](10) NOT NULL,
	[Mail] [nchar](10) NULL,
	[DateEntree] [date] NOT NULL,
	[DateDerniereFacturation] [date] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Commentaire]    Script Date: 11/02/2015 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commentaire](
	[idCommenatire] [int] IDENTITY(1,1) NOT NULL,
	[Place] [int] NULL,
	[Commentaire] [nvarchar](100) NULL,
 CONSTRAINT [PK_Commentaire] PRIMARY KEY CLUSTERED 
(
	[idCommenatire] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tache]    Script Date: 11/02/2015 09:11:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tache](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NomTache] [nvarchar](max) NULL,
	[IdClient] [int] NULL,
	[IdArtisan] [int] NULL,
	[Statut] [nchar](10) NULL,
	[idCommentaire] [int] NULL,
 CONSTRAINT [PK_Tache] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
