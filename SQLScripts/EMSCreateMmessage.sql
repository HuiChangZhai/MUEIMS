USE [EnterpriseInfoManagementSys]
GO
/*李云成于2014-03-09创建主网站的留言功能相关的表结构*/
/****** Object:  Table [dbo].[MEnterpriseMessage]    Script Date: 03/09/2014 12:08:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MEnterpriseMessage](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageEnterpriseName] [nvarchar](255) NULL,
	[MessageEnterpriseTel] [nvarchar](50) NULL,
	[MessageEnterpriseEmail] [nvarchar](50) NULL,
	[Message] [text] NULL,
	[MessageIsRead] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


