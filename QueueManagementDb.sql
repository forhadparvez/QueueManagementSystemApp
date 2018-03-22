USE [QueueManagementDb]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 3/22/2018 3:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[PhoneNo] [nvarchar](20) NULL,
	[Age] [nvarchar](3) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[sp_PatientDelete]    Script Date: 3/22/2018 3:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>

--  sp_PatientInsert 'Forhad', '017000001', '22'

-- =============================================
CREATE PROCEDURE [dbo].[sp_PatientDelete]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.Patients
	WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[sp_PatientGetAll]    Script Date: 3/22/2018 3:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>

--  sp_PatientInsert 'Forhad', '017000001', '22'

-- =============================================
CREATE PROCEDURE [dbo].[sp_PatientGetAll]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Patients

END

GO
/****** Object:  StoredProcedure [dbo].[sp_PatientGetByPhoneNo]    Script Date: 3/22/2018 3:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>

--  sp_PatientInsert 'Forhad', '017000001', '22'

-- =============================================
CREATE PROCEDURE [dbo].[sp_PatientGetByPhoneNo]
	-- Add the parameters for the stored procedure here
	@PhoneNo nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Patients 
	WHERE PhoneNo=@PhoneNo

END

GO
/****** Object:  StoredProcedure [dbo].[sp_PatientInsert]    Script Date: 3/22/2018 3:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>

--  sp_PatientInsert 'Forhad', '017000001', '22'

-- =============================================
CREATE PROCEDURE [dbo].[sp_PatientInsert]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(255),
	@PhoneNo nvarchar(20),
	@Age nvarchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Patients(Name, PhoneNo, Age)
	VALUES(@Name, @PhoneNo, @Age)


	SELECT SCOPE_IDENTITY() AS Id
END

GO
/****** Object:  StoredProcedure [dbo].[sp_PatientUpdate]    Script Date: 3/22/2018 3:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>

--  sp_PatientInsert 'Forhad', '017000001', '22'

-- =============================================
CREATE PROCEDURE [dbo].[sp_PatientUpdate]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name nvarchar(255),
	@PhoneNo nvarchar(20),
	@Age nvarchar(3)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Patients 
	SET Name=@Name, PhoneNo=@PhoneNo, Age=@Age
	WHERE Id=@Id

END

GO
