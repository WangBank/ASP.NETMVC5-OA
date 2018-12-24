
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/24/2018 10:24:04
-- Generated from EDMX file: E:\Projects\ASP.NET-MVC-OA-master\Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------



-- Creating table 'WF_TempSet'
CREATE TABLE [dbo].[WF_TempSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TempName] nvarchar(32)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [TempForm] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(64)  NULL,
    [Deflag] smallint  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [ActityType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'WF_ItemSet'
CREATE TABLE [dbo].[WF_ItemSet] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ItemName] nvarchar(32)  NOT NULL,
    [StartBy] int  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [Level] smallint  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(max)  NULL,
    [Deflag] smallint  NOT NULL,
    [WFItemID] nvarchar(max)  NOT NULL,
    [WF_TempID] int  NOT NULL
);
GO

-- Creating table 'FileInfoSet'
CREATE TABLE [dbo].[FileInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(32)  NOT NULL,
    [FileType] nvarchar(32)  NULL,
    [FilePath] nvarchar(32)  NULL,
    [FileSize] nvarchar(32)  NULL,
    [Remark] nvarchar(64)  NULL,
    [Deflag] smallint  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'WF_StepSet'
CREATE TABLE [dbo].[WF_StepSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StepName] nvarchar(32)  NOT NULL,
    [ProcessBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [ProcessTime] datetime  NOT NULL,
    [ProcessResult] nvarchar(max)  NOT NULL,
    [ProcessCommit] nvarchar(max)  NOT NULL,
    [Status] smallint  NOT NULL,
    [IsStartStep] bit  NOT NULL,
    [IsEndStep] bit  NOT NULL,
    [ParentStepID] int  NULL,
    [WF_ItemID] int  NOT NULL
);
GO



-- Creating table 'WF_ItemFileInfo'
CREATE TABLE [dbo].[WF_ItemFileInfo] (
    [WF_Item_ID] int  NOT NULL,
    [FileInfo_Id] int  NOT NULL
);
GO

-- Creating primary key on [ID] in table 'WF_TempSet'
ALTER TABLE [dbo].[WF_TempSet]
ADD CONSTRAINT [PK_WF_TempSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WF_ItemSet'
ALTER TABLE [dbo].[WF_ItemSet]
ADD CONSTRAINT [PK_WF_ItemSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'FileInfoSet'
ALTER TABLE [dbo].[FileInfoSet]
ADD CONSTRAINT [PK_FileInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WF_StepSet'
ALTER TABLE [dbo].[WF_StepSet]
ADD CONSTRAINT [PK_WF_StepSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO


-- Creating primary key on [WF_Item_ID], [FileInfo_Id] in table 'WF_ItemFileInfo'
ALTER TABLE [dbo].[WF_ItemFileInfo]
ADD CONSTRAINT [PK_WF_ItemFileInfo]
    PRIMARY KEY CLUSTERED ([WF_Item_ID], [FileInfo_Id] ASC);
GO


-- Creating foreign key on [WF_Item_ID] in table 'WF_ItemFileInfo'
ALTER TABLE [dbo].[WF_ItemFileInfo]
ADD CONSTRAINT [FK_WF_ItemFileInfo_WF_Item]
    FOREIGN KEY ([WF_Item_ID])
    REFERENCES [dbo].[WF_ItemSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FileInfo_Id] in table 'WF_ItemFileInfo'
ALTER TABLE [dbo].[WF_ItemFileInfo]
ADD CONSTRAINT [FK_WF_ItemFileInfo_FileInfo]
    FOREIGN KEY ([FileInfo_Id])
    REFERENCES [dbo].[FileInfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WF_ItemFileInfo_FileInfo'
CREATE INDEX [IX_FK_WF_ItemFileInfo_FileInfo]
ON [dbo].[WF_ItemFileInfo]
    ([FileInfo_Id]);
GO

-- Creating foreign key on [WF_TempID] in table 'WF_ItemSet'
ALTER TABLE [dbo].[WF_ItemSet]
ADD CONSTRAINT [FK_WF_TempWF_Item]
    FOREIGN KEY ([WF_TempID])
    REFERENCES [dbo].[WF_TempSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WF_TempWF_Item'
CREATE INDEX [IX_FK_WF_TempWF_Item]
ON [dbo].[WF_ItemSet]
    ([WF_TempID]);
GO

-- Creating foreign key on [WF_ItemID] in table 'WF_StepSet'
ALTER TABLE [dbo].[WF_StepSet]
ADD CONSTRAINT [FK_WF_ItemWF_Step]
    FOREIGN KEY ([WF_ItemID])
    REFERENCES [dbo].[WF_ItemSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WF_ItemWF_Step'
CREATE INDEX [IX_FK_WF_ItemWF_Step]
ON [dbo].[WF_StepSet]
    ([WF_ItemID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------