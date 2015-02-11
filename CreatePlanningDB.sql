
CREATE TABLE [dbo].[Artisan](
	[idArtisan] [int] NOT NULL,
	[Sigle] [nchar](10) NULL,
	[Nom] [nchar](10) NULL,
	[Prenom] [nchar](10) NULL,
	[Adresse] [nchar](10) NULL,
	[CodePostal] [int] NULL,
	[Telephone] [nchar](10) NULL,
	[Email] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Artisan] PRIMARY KEY CLUSTERED 
(
	[idArtisan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 19/11/2014 16:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[idClient] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Facture]    Script Date: 19/11/2014 16:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facture](
	[idFacture] [int] NOT NULL,
	[DateFacturation] [date] NULL,
	[Total] [real] NULL,
	[TVA] [real] NULL,
	[IdClient] [int] NULL,
 CONSTRAINT [PK_Facture] PRIMARY KEY CLUSTERED 
(
	[idFacture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 19/11/2014 16:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[id] [int] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Support]    Script Date: 19/11/2014 16:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Support](
	[IdSupport] [int] NOT NULL,
	[IdClient] [int] NULL,
	[DateOuverture] [nchar](10) NULL,
	[DateCloture] [nchar](10) NULL,
	[NbMessages] [nchar](10) NULL,
 CONSTRAINT [PK_Support] PRIMARY KEY CLUSTERED 
(
	[IdSupport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tache]    Script Date: 19/11/2014 16:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tache](
	[id] [int] NOT NULL,
	[NomTache] [nchar](10) NULL,
	[IdClient] [int] NULL,
	[Statut] [nchar](10) NULL,
	[Commentaires] [nvarchar](100) NULL,
 CONSTRAINT [PK_Tache] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
