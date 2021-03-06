USE [YOURDATABASE]
GO
/****** Object:  Table [dbo].[Absen]    Script Date: 07/11/2021 19:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absen](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[kehadiran] [varchar](10) NOT NULL,
	[tanggal] [date] NOT NULL,
	[nama_siswa] [varchar](100) NULL,
 CONSTRAINT [PK_Absen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guru]    Script Date: 07/11/2021 19:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guru](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nip] [bigint] NOT NULL,
	[nama] [varchar](100) NOT NULL,
	[alamat] [varchar](300) NOT NULL,
	[no_hp] [bigint] NOT NULL,
	[instansi_nama] [varchar](100) NOT NULL,
	[foto_guru] [image] NOT NULL,
 CONSTRAINT [PK_Guru] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instansi]    Script Date: 07/11/2021 19:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instansi](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](100) NOT NULL,
	[alamat] [varchar](300) NOT NULL,
	[foto_instansi] [image] NOT NULL,
 CONSTRAINT [PK_Instansi] PRIMARY KEY CLUSTERED 
(
	[nama] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 07/11/2021 19:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](100) NOT NULL,
	[username] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[role] [varchar](20) NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siswa]    Script Date: 07/11/2021 19:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siswa](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nis] [bigint] NOT NULL,
	[nama] [varchar](100) NOT NULL,
	[kelas] [varchar](20) NOT NULL,
	[alamat] [varchar](300) NOT NULL,
	[no_hp] [bigint] NOT NULL,
	[instansi_nama] [varchar](100) NOT NULL,
	[foto_siswa] [image] NOT NULL,
 CONSTRAINT [PK_Siswa] PRIMARY KEY CLUSTERED 
(
	[nama] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Absen] ADD  CONSTRAINT [DF_Absen_tanggal]  DEFAULT (getdate()) FOR [tanggal]
GO
ALTER TABLE [dbo].[Absen] ADD  CONSTRAINT [DF_Absen_siswa_id]  DEFAULT ((0)) FOR [nama_siswa]
GO
ALTER TABLE [dbo].[Guru] ADD  CONSTRAINT [DF_Guru_instansi_nama]  DEFAULT ('Tidak Ada') FOR [instansi_nama]
GO
ALTER TABLE [dbo].[Login] ADD  CONSTRAINT [DF_Login_status]  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Siswa] ADD  CONSTRAINT [DF_Siswa_instansi_nama]  DEFAULT ('Tidak Ada') FOR [instansi_nama]
GO
ALTER TABLE [dbo].[Absen]  WITH CHECK ADD  CONSTRAINT [FK_Absen_Siswa] FOREIGN KEY([nama_siswa])
REFERENCES [dbo].[Siswa] ([nama])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Absen] CHECK CONSTRAINT [FK_Absen_Siswa]
GO
ALTER TABLE [dbo].[Guru]  WITH CHECK ADD  CONSTRAINT [FK_Guru_Instansi] FOREIGN KEY([instansi_nama])
REFERENCES [dbo].[Instansi] ([nama])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[Guru] CHECK CONSTRAINT [FK_Guru_Instansi]
GO
ALTER TABLE [dbo].[Siswa]  WITH CHECK ADD  CONSTRAINT [FK_Siswa_Instansi] FOREIGN KEY([instansi_nama])
REFERENCES [dbo].[Instansi] ([nama])
ON UPDATE CASCADE
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[Siswa] CHECK CONSTRAINT [FK_Siswa_Instansi]
GO
