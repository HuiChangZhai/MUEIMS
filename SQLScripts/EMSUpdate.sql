--For update of EMS Datebase
--update time #2014-03-09 10:53:14.480
ALTER TABLE Enterprise ALTER COLUMN EnterpriseBriefShort NVARCHAR(50)
ALTER TABLE Enterprise ALTER COLUMN EnterpriseBriefShort NTEXT

ALTER TABLE Enterprise ALTER COLUMN EnterpriseBrief NVARCHAR(50)
ALTER TABLE Enterprise ALTER COLUMN EnterpriseBrief NTEXT

ALTER TABLE EnterpriseCases ALTER COLUMN EnterpriseContent NVARCHAR(50)
ALTER TABLE EnterpriseCases ALTER COLUMN EnterpriseContent NTEXT

ALTER TABLE EnterpriseDynamic ALTER COLUMN EnterpriseDynamicContent NVARCHAR(50)
ALTER TABLE EnterpriseDynamic ALTER COLUMN EnterpriseDynamicContent NTEXT

ALTER TABLE MEnterprise ALTER COLUMN MEnterpriseBriefShort NVARCHAR(50)
ALTER TABLE MEnterprise ALTER COLUMN MEnterpriseBriefShort NTEXT

ALTER TABLE MEnterprise ALTER COLUMN MEnterpriseBrief NVARCHAR(50)
ALTER TABLE MEnterprise ALTER COLUMN MEnterpriseBrief NTEXT

ALTER TABLE MEnterpriseCases ALTER COLUMN MEnterpriseCasesTitle NVARCHAR(50)
ALTER TABLE MEnterpriseCases ALTER COLUMN MEnterpriseCasesTitle NTEXT

ALTER TABLE MEnterpriseCases ALTER COLUMN MEnterpriseCasesContent NVARCHAR(50)
ALTER TABLE MEnterpriseCases ALTER COLUMN MEnterpriseCasesContent NTEXT

ALTER TABLE MEnterpriseMessage ALTER COLUMN [Message] NVARCHAR(50)
ALTER TABLE MEnterpriseMessage ALTER COLUMN [Message] NTEXT
--update time #2014-03-15 12:32:42.793



--select GETDATE()