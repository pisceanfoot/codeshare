CREATE TABLE [category] (
  [SysNo] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  [Name] NVARCHAR(100) NOT NULL COLLATE NOCASE, 
  [ParentSysNo] INTEGER, 
  [UserSysNo] INTEGER NOT NULL, 
  [ShareStatus] VARCHAR(50) NOT NULL);
