CREATE TABLE [dbo].[Materias](
	[MateriaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreMateria] [nvarchar](255) NOT NULL,
	[Activa] [bit] NOT NULL,
	[CarreraId] [int] NOT NULL,
 CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED 
(
	[MateriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Materias]  WITH CHECK ADD  CONSTRAINT [FK_Materias_Carreras_CarreraId] FOREIGN KEY([CarreraId])
REFERENCES [dbo].[Carreras] ([CarreraId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Materias] CHECK CONSTRAINT [FK_Materias_Carreras_CarreraId]
GO


