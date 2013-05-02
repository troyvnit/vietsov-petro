﻿SET XACT_ABORT ON

BEGIN TRANSACTION
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomTypes] WHERE [RoomTypeID] = '11111111-1111-1111-1111-111111111111')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomTypeID]
        ,[RoomTypeName]
        ,[RoomGroup]
        ,[LanguageCode]
		,[Description]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[IsDeal]
    )
    VALUES
    (
        '11111111-1111-1111-1111-111111111111'
        ,'Phòng Họp'
        ,'Meeting Room'
        ,'vi-VN'
		,NULL
		,0
		,1
		,0
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomTypes] WHERE [RoomTypeID] = '22222222-2222-2222-2222-222222222222')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomTypeID]
        ,[RoomTypeName]
        ,[RoomGroup]
        ,[LanguageCode]
		,[Description]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[IsDeal]
    )
    VALUES
    (
        '22222222-2222-2222-2222-222222222222'
        ,'King Size'
        ,'Room And Price'
        ,'vi-VN'
		,NULL
		,0
		,1
		,0
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomTypes] WHERE [RoomTypeID] = '33333333-3333-3333-3333-333333333333')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomTypeID]
        ,[RoomTypeName]
        ,[RoomGroup]
        ,[LanguageCode]
		,[Description]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[IsDeal]
    )
    VALUES
    (
        '33333333-3333-3333-3333-333333333333'
        ,'King Size'
        ,'Room And Price'
        ,'vi-VN'
		,NULL
		,0
		,1
		,0
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomTypes] WHERE [RoomTypeID] = '44444444-4444-4444-4444-444444444444')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomTypeID]
        ,[RoomTypeName]
        ,[RoomGroup]
        ,[LanguageCode]
		,[Description]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[IsDeal]
    )
    VALUES
    (
        '44444444-4444-4444-4444-444444444444'
        ,'Twin/Double'
        ,'Room And Price'
        ,'vi-VN'
		,NULL
		,0
		,1
		,0
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomTypes] WHERE [RoomTypeID] = '55555555-5555-5555-5555-555555555555')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomTypeID]
        ,[RoomTypeName]
        ,[RoomGroup]
        ,[LanguageCode]
		,[Description]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[IsDeal]
    )
    VALUES
    (
        '55555555-5555-5555-5555-555555555555'
        ,'Restaurant'
        ,'Restaurant'
        ,'vi-VN'
		,NULL
		,0
		,1
		,0
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '11111111-1111-1111-1111-111111111111')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
        ,[LanguageCode]
    )
    VALUES
    (
        '11111111-1111-1111-1111-111111111111'
        ,'Số chỗ ngồi'
        ,'Detail'
		,'chỗ'
		,0
        ,'vi-VN'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '22222222-2222-2222-2222-222222222222')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
        ,[LanguageCode]
    )
    VALUES
    (
        '22222222-2222-2222-2222-222222222222'
        ,'Diện tích'
        ,'Detail'
		,'m2'
		,0
        ,'vi-VN'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '33333333-3333-3333-3333-333333333333')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
        ,[LanguageCode]
    )
    VALUES
    (
        '33333333-3333-3333-3333-333333333333'
        ,'Dài'
        ,'Detail'
		,'m'
		,0
        ,'vi-VN'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '44444444-4444-4444-4444-444444444444')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
        ,[LanguageCode]
    )
    VALUES
    (
        '44444444-4444-4444-4444-444444444444'
        ,'Rộng'
        ,'Detail'
		,'m'
		,0
        ,'vi-VN'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '55555555-5555-5555-5555-555555555555')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
        ,[LanguageCode]
    )
    VALUES
    (
        '55555555-5555-5555-5555-555555555555'
        ,'Giá Nửa Ngày (4h)'
        ,'Price'
		,'Đ'
		,0
        ,'vi-VN'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '66666666-6666-6666-6666-666666666666')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
        ,[LanguageCode]
    )
    VALUES
    (
        '66666666-6666-6666-6666-666666666666'
        ,'Giá Cả Ngày (8h)'
        ,'Price'
		,'Đ'
		,0
        ,'vi-VN'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '77777777-7777-7777-7777-777777777777')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
        ,[LanguageCode]
    )
    VALUES
    (
        '77777777-7777-7777-7777-777777777777'
        ,'Bao Gồm'
        ,'Property'
		,''
		,0
        ,'vi-VN'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '88888888-8888-8888-8888-888888888888')
BEGIN
    INSERT INTO [dbo].[RoomTypes]
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
        ,[LanguageCode]
    )
    VALUES
    (
        '88888888-8888-8888-8888-888888888888'
        ,'Dịch vụ thêm'
        ,'Property'
		,''
		,0
        ,'vi-VN'
    )
END
GO
