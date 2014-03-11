alter table MEnterpriseCases add MEnterpriseCaseUrl NVARCHAR(255)
alter table MEnterpriseCases add MEnterpriseCaseShow bit default  0 not null
alter table MEnterpriseCases add EnterprisUrl NVARCHAR(50)