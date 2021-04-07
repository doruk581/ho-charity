IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210330185417_CharityOrganization')
BEGIN
    CREATE TABLE [CharityOrganizations] (
        [Id] uniqueidentifier NOT NULL,
        [OrganizationName] nvarchar(max) NOT NULL,
        [OrganizationAuthorizedPersonEmail] nvarchar(max) NOT NULL,
        [OrganizationAuthorizedPersonPhoneNumber] nvarchar(max) NULL,
        [Address] nvarchar(max) NOT NULL,
        [Iban] nvarchar(max) NOT NULL,
        [IsActive] bit NOT NULL,
        [OrganizationAuthorizedPersonName] nvarchar(max) NULL,
        [OrganizationAuthorizedPersonSurname] nvarchar(max) NULL,
        [TaxOffice] nvarchar(max) NULL,
        [TaxNumber] nvarchar(max) NULL,
        [SubMerchantKey] nvarchar(max) NULL,
        [MerchantId] nvarchar(max) NULL,
        CONSTRAINT [PK_CharityOrganizations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210330185417_CharityOrganization')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210330185417_CharityOrganization', N'5.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210403220207_EntityUpdated')
BEGIN
    ALTER TABLE [CharityOrganizations] ADD [OrganizationAuthorizedPersonIdentityNumber] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210403220207_EntityUpdated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210403220207_EntityUpdated', N'5.0.2');
END;
GO

COMMIT;
GO

