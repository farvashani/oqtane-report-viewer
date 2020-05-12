/*  
Create TresReportViewer table
*/

CREATE TABLE [dbo].[TresReportViewer](
	[ReportViewerId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_TresReportViewer] PRIMARY KEY CLUSTERED 
  (
	[ReportViewerId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[TresReportViewer]  WITH CHECK ADD  CONSTRAINT [FK_TresReportViewer_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO