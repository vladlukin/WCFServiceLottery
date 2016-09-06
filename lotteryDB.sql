

USE [lotteryDB]
GO

/****** Object:  Table [dbo].[participantList]    Script Date: 02.09.2016 10:31:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[participantList](
	[idParticipant] [int] IDENTITY(1,1) NOT NULL,
	[nameParticipant] [varchar](100) NULL,
	[isWinner] [smallint] NOT NULL,
 CONSTRAINT [PK_participantList] PRIMARY KEY CLUSTERED 
(
	[idParticipant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[participantList] ADD  CONSTRAINT [DF_participantList_isWinner]  DEFAULT ((0)) FOR [isWinner]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'participantList', @level2type=N'COLUMN',@level2name=N'idParticipant'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'name of paricipant' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'participantList', @level2type=N'COLUMN',@level2name=N'nameParticipant'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'flag: participant is Winner
1 - winner
0 - not winner' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'participantList', @level2type=N'COLUMN',@level2name=N'isWinner'
GO

insert into participantList (nameParticipant) values ('Иванов');
insert into participantList (nameParticipant) values ('Петров');
insert into participantList (nameParticipant) values ('Агутин');
insert into participantList (nameParticipant) values ('Лещенко');
insert into participantList (nameParticipant) values ('Кобзон');
insert into participantList (nameParticipant) values ('Лепс');