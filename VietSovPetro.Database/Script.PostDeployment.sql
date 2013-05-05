SET XACT_ABORT ON

BEGIN TRANSACTION
 
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
        ,N'Phòng Họp'
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
        ,N'King Size'
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
        ,N'King Size'
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
        ,N'Twin/Double'
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
        ,N'Restaurant'
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
    INSERT INTO [dbo].[RoomProperties] 
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
    )
    VALUES
    (
        '11111111-1111-1111-1111-111111111111'
        ,N'Số chỗ ngồi'
        ,'Detail'
		,N'chỗ'
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '22222222-2222-2222-2222-222222222222')
BEGIN
    INSERT INTO [dbo].[RoomProperties] 
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
    )
    VALUES
    (
        '22222222-2222-2222-2222-222222222222'
        ,N'Diện tích'
        ,'Detail'
		,N'm2'
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '33333333-3333-3333-3333-333333333333')
BEGIN
    INSERT INTO [dbo].[RoomProperties] 
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
    )
    VALUES
    (
        '33333333-3333-3333-3333-333333333333'
        ,N'Dài'
        ,'Detail'
		,N'm'
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '44444444-4444-4444-4444-444444444444')
BEGIN
    INSERT INTO [dbo].[RoomProperties] 
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
    )
    VALUES
    (
        '44444444-4444-4444-4444-444444444444'
        ,N'Rộng'
        ,'Detail'
		,N'm'
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '55555555-5555-5555-5555-555555555555')
BEGIN
    INSERT INTO [dbo].[RoomProperties] 
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
    )
    VALUES
    (
        '55555555-5555-5555-5555-555555555555'
        ,N'Giá Nửa Ngày (4h)'
        ,'Price'
		,N'Đ'
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '66666666-6666-6666-6666-666666666666')
BEGIN
    INSERT INTO [dbo].[RoomProperties] 
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
    )
    VALUES
    (
        '66666666-6666-6666-6666-666666666666'
        ,N'Giá Cả Ngày (8h)'
        ,'Price'
		,N'Đ'
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '77777777-7777-7777-7777-777777777777')
BEGIN
    INSERT INTO [dbo].[RoomProperties] 
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
    )
    VALUES
    (
        '77777777-7777-7777-7777-777777777777'
        ,N'Bao Gồm'
        ,'Property'
		,''
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[RoomProperties] WHERE [RoomPropertyID] = '88888888-8888-8888-8888-888888888888')
BEGIN
    INSERT INTO [dbo].[RoomProperties] 
    (
        [RoomPropertyID]
        ,[RoomPropertyName]
        ,[RoomPropertyType]
		,[Unit]
		,[OrderID]
    )
    VALUES
    (
        '88888888-8888-8888-8888-888888888888'
        ,N'Dịch vụ thêm'
        ,'Property'
		,''
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '11111111-1111-1111-1111-111111111111')
BEGIN
    INSERT INTO [dbo].[ArticleCategories] 
    (
        [ArticleCategoryID]
        ,[ArticleCategoryName]
        ,[ArticleCategoryType]
		,[LanguageCode]
		,[Description]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
    )
    VALUES
    (
        '11111111-1111-1111-1111-111111111111'
        ,N'Giới thiệu VietSovPetro'
        ,'Introduction'
		,'vi-VN'
		,N'Dùng cho trang giới thiệu'
        ,0
		,1
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '22222222-2222-2222-2222-222222222222')
BEGIN
    INSERT INTO [dbo].[ArticleCategories] 
    (
        [ArticleCategoryID]
        ,[ArticleCategoryName]
        ,[ArticleCategoryType]
		,[LanguageCode]
		,[Description]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
    )
    VALUES
    (
        '22222222-2222-2222-2222-222222222222'
        ,N'Hoạt động'
        ,'Activity'
		,'vi-VN'
		,N'Dùng cho trang hoạt động'
        ,0
		,1
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategories] WHERE [ArticleCategoryID] = '33333333-3333-3333-3333-333333333333')
BEGIN
    INSERT INTO [dbo].[ArticleCategories] 
    (
        [ArticleCategoryID]
        ,[ArticleCategoryName]
        ,[ArticleCategoryType]
		,[LanguageCode]
		,[Description]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
    )
    VALUES
    (
        '33333333-3333-3333-3333-333333333333'
        ,N'Tin tức'
        ,'News'
		,'vi-VN'
		,N'Dùng cho trang tin tức'
        ,0
		,1
		,0
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Articles] WHERE [ArticleID] = '11111111-1111-1111-1111-111111111111')
BEGIN
    INSERT INTO [dbo].[Articles] 
    (
        [ArticleID]
        ,[ActicleNumber]
        ,[Title]	  
		,[Description]
		,[Content]
		,[Author]	 
		,[ImageUrl]
		,[OrderID]	 
		,[LanguageCode]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[CreatedOn]
		,[CreatedBy]
		,[UpdatedOn]
		,[UpdatedBy]
    )
    VALUES
    (
        '11111111-1111-1111-1111-111111111111'
        ,1
        ,N'Giới thiệu chung về Liên doanh Việt Nga - Vietsovpetro'
		,''
		,N'<ul><li><p>Liên doanh Việt – Nga 
		Vietsovpetro được thành lập trên cơ sở các Hiệp định Việt Xô về hợp tác 
		thăm dò, khai thác dầu khí trên thềm lục địa Việt Nam ký ngày 03/07/1980
		 và Hiệp định liên Chính Phủ Việt Nam Liên Xô ký ngày 19/06/1981 về việc
		 thành lập Liên doanh dầu khí Việt Xô, Hiệp định liên Chính phủ giữa 
		CHXHCN Việt Nam và LB Nga về tiếp tục hợp tác trong lĩnh vực thăm dò địa
		 chất và khai thác dầu khí tại thềm lục địa Việt Nam ký ngày 27/12/2010.</p></li><li><p>Cho đến nay, Liên doanh Việt – 
		Nga Vietsovpetro là đơn vị lớn nhất trong lĩnh vực thăm dò và khai thác 
		dầu khí tại Việt Nam với trên 32 năm kinh nghiệm. Tổng sản lượng dầu 
		khai thác đạt trên 200 triệu tấn; tổng sản lượng khí đạt trên 25 tỷ m3; 
		tổng doanh thu từ bán dầu đạt 60 tỷ USD.</p></li></ul>'
        ,'admin'
		,''
		,0
		,'vi-VN'
		,0
		,1
		,0
		,''
		,'11111111-1111-1111-1111-111111111111'
		,''
		,'11111111-1111-1111-1111-111111111111'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Articles] WHERE [ArticleID] = '22222222-2222-2222-2222-222222222222')
BEGIN
    INSERT INTO [dbo].[Articles] 
    (
        [ArticleID]
        ,[ActicleNumber]
        ,[Title]	  
		,[Description]
		,[Content]
		,[Author]	 
		,[ImageUrl]
		,[OrderID]	 
		,[LanguageCode]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[CreatedOn]
		,[CreatedBy]
		,[UpdatedOn]
		,[UpdatedBy]
    )
    VALUES
    (
        '22222222-2222-2222-2222-222222222222'
        ,2
        ,N'Giới thiệu về khu nghỉ dưỡng Vietsovpetro'
		,''
		,N'<ul><li><p>Khu nghỉ dưỡng Vietsovpetro do 
		LDVN Vietsovpetro đầu tư xây dựng tại Hồ Tràm, xã Phước Thuận, Huyện 
		Xuyên Mộc, tỉnh Bà Rịa - Vũng Tàu. Khu nghỉ dưỡng nằm trong cụm du lịch 
		Hồ Tràm - Bình Châu, trong những năm tới sẽ là khu vực phát triển du 
		lịch sinh thái bậc nhất của tỉnh Bà Rịa – Vũng Tàu, với lợi thế về tài 
		nguyên rừng, bãi biển đẹp, suối khoáng nóng, cảnh quan thiên nhiên trong
		 lành, khung cảnh hoang sơ. Vị trí so với các khu vực lận cận rất thuận 
		lợi do có hệ trục giao thông hiện đại gồm quốc lộ 51, 55, 56, đường ven 
		biển TL 44A, đường cao tốc TP. Hồ Chí Minh – Biên Hòa – Vũng Tàu, các 
		bến tàu du lịch, hệ thống cảng biển hiện đại sẽ tạo cho khu vực nhiều 
		hướng đi đến khá thuận lợi : theo hướng từ miền Đông và miền Tây Nam Bộ,
		 TP. Hồ Chí Minh, Đồng Nai, Bình Dương – Vũng Tàu – Long Hải – Phước Hải
		 tới Hồ Tràm, và theo hướng miền Trung Hàm Tân (Bình Thuận) – Bình Châu –
		 Hồ Cốc – Hồ Tràm.</p></li><li><p>Bãi biển: đây là một trong những 
		khu vực có bãi biển đẹp của Bà Rịa – Vũng Tàu với bờ cát trắng trải dài,
		 nước biển trong xanh, xa xa có núi bao bọc, không khí trong lành. Có 
		khả năng khai thác du lịch tắm biển, các hoạt động vui chơi giải trí 
		biển trong suốt chiều dài gần 600m bờ biển. Khu nghỉ dưỡng Vietsovpetro 
		nằm tại khu vực Khu vực tiếp giáp đường giao thông ven biển: là một dãy 
		đất có vị trí giao thông đối ngoại thuận tiện cho các việc đi lại của du
		 khách. Trên một nửa diện tích cua khu nghỉ dưỡng được phủ kín rừng 
		dương trên 15 tuổi là vị trí lý tưởng cho các hoạt động pinic, dã ngoại,
		 teambuilding…</p></li><li><p>Khu nghỉ dưỡng Vietsovpetro là khu nghỉ dưỡng cao cấp tiêu chuẩn 5 sao với quy mô như sau:</p></li><li></li><li><p>Diện tích lập dự án 119.612 m2.</p></li><li><p>Tổng mức đầu tư của dự án gần 1.200 tỷ đồng.</p></li><li><p>Giai đoạn 1- Xây dựng các hạng 
		mục chủ yếu khu khách sạn 4 tầng với 184 phòng ngủ, các tiện ích công 
		cộng, Nhà hàng, Trung tâm hội nghị, hồ bơi…đã hoàn tất và đưa vào sử 
		dụng từ ngày 07.12.2012.</p></li><li><p>Giai đoạn 2– Xây dựng các hạng 
		mục bổ sung nhằm hoàn thiện khu nghỉ dưỡng theo tiêu chuẩn 5 sao, dự 
		kiến khởi công đầu năm 2013 và hoàn thành cả khu nghỉ dưỡng vào cuối năm
		 2013.</p></li></ul>'
        ,'admin'
		,''
		,0
		,'vi-VN'
		,0
		,1
		,0
		,''
		,'11111111-1111-1111-1111-111111111111'
		,''
		,'11111111-1111-1111-1111-111111111111'
    )
END


IF NOT EXISTS (SELECT 1 FROM [dbo].[Articles] WHERE [ArticleID] = '33333333-3333-3333-3333-333333333333')
BEGIN
    INSERT INTO [dbo].[Articles] 
    (
        [ArticleID]
        ,[ActicleNumber]
        ,[Title]	  
		,[Description]
		,[Content]
		,[Author]	 
		,[ImageUrl]
		,[OrderID]	 
		,[LanguageCode]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[CreatedOn]
		,[CreatedBy]
		,[UpdatedOn]
		,[UpdatedBy]
    )
    VALUES
    (
        '33333333-3333-3333-3333-333333333333'
        ,3
        ,N'Các sản phẩm và dịch vụ tại khu nghỉ dưỡng'
		,''
		,N'<ul><li><p>Phòng ngủ: 184 phòng trong đó gồm: 128 phòng Deluxe, 54 phòng Suite, 2 phòng Grand Suite, 2 phòng President.</p></li><li><p>Nhà hàng: phục vụ được trên 500 khách.</p></li><li><p>Hội trường: với sức chứa 600 người và các phòng họp chuyên dụng phục vụ cho các hội nghị tầm cỡ.</p></li><li><p>Hồ bơi: 3 hồ bơi lớn với diện tích gần 4500m2 và được bố trí hiệu ứng đèn lộng lẫy.</p></li><li><p>Khu thư viện với diện tích 150 m2.</p></li><li><p>Khu GYM với diện tích 150m2.</p></li><li><p>Khu Gift Shop: với tổng diện tích
		 gần 200m2 (dự kiến khai trương từ tháng 2 năm 2013) bao gồm các mặt 
		hàng chủ yếu như: Ngọc trai Hạ Long, áo quần và dụng cụ thể thao phục vụ
		 Golf, Tennis,…; các mặt hàng lưu niệm làm bằng đá quý và gỗ tự nhiên, 
		các mặt hàng rượu cao cấp nhập ngoại; các mặt hàng mỹ phẫm cao cấp.</p></li><li><p>Beauty Salon được trang bị các 
		thiết bị hiện đại và đội ngũ chăm sóc viên chuyên nghiệp giàu kinh 
		nghiệm thực hiện các dịch vụ chăm sóc da, làm đẹp và giúp phục hồi sức 
		khỏe cho khách hàng.</p></li><li><p>Dịch vụ tour du lịch tại khu vực 
		Hồ Tràm: du lịch trên du thuyền về thượng nguồn sông Ray và cửa biển Lộc
		 An: khám phá cảnh đẹp dọc theo sông Ray với sự đa dạng về phong cảnh: 
		rừng ngập mặn, dừa nước xen kẽ cảnh đẹp hoang sơ, tập kết vào những địa 
		điểm trên bờ để thưởng thức các món ăn dân dã do chính cư dân nơi đây 
		chế biến từ các thực phẩm tươi sống của địa phương. Chuyến tour này 
		ngoài thưởng thức ngoạn cảnh đẹp của thiên nhiên thì du lịch về cửa biển
		 Lộc An còn là tuyến du lịch về địa danh lịch sử nơi các tàu không số đã
		 tập kết về đây để cung cấp vũ khí cho chiến trường miền Nam trong cuộc 
		chiến tranh ác liệt chống Đế quốc Mỹ.</p></li><li><p>Dịch vụ lướt ván chuyên nghiệp có
		 sự tham gia của các nhà lướt ván chuyên nghiệp đến từ các nước (Châu 
		âu, SNG, Australia…) nhằm thu hút du khách trong nước và đặc biệt là du 
		khách Nga sang tránh mùa đông lạnh của nước Nga.</p></li><li><p>Khu nghỉ dưỡng có đội ngũ tour 
		guide chuyên nghiệp sẵn sàng tổ chức cho du khách Nga đi các tuyến du 
		lịch khắp mọi miền đất nước Việt Nam và các tour du lịch đến các nước 
		Châu Á như: Campuchia, Lào, Indonesia, Malaysia, Singapore, Hàn Quốc, 
		Nhật Bản…
		Dịch vụ Bay bằng kinh khí cầu từ khu nghỉ dưỡng VSP (dịch vụ độc quyền 
		tại khu vực phía Nam) dự kiến sẽ hợp tác khai thác thương mại sau 
		30/4/2013.</p></li><li><p>Các dịch vụ bổ sung và liên kết 
		với bên ngoài: có xe đưa đón khách lưu trú tại khu nghỉ dưỡng VSP đi tắm
		 suối khoáng tại Bình Châu, tham gia các dịch vụ shopping và Casino tại 
		khu phức hợp 5 sao MGM tại Hồ Tràm.</p></li></ul>'
        ,'admin'
		,''
		,0
		,'vi-VN'
		,0
		,1
		,0
		,''
		,'11111111-1111-1111-1111-111111111111'
		,''
		,'11111111-1111-1111-1111-111111111111'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Articles] WHERE [ArticleID] = '44444444-4444-4444-4444-444444444444')
BEGIN
    INSERT INTO [dbo].[Articles] 
    (
        [ArticleID]
        ,[ActicleNumber]
        ,[Title]	  
		,[Description]
		,[Content]
		,[Author]	 
		,[ImageUrl]
		,[OrderID]	 
		,[LanguageCode]
		,[IsDeleted]
		,[IsPublished]
		,[IsNew]
		,[CreatedOn]
		,[CreatedBy]
		,[UpdatedOn]
		,[UpdatedBy]
    )
    VALUES
    (
        '44444444-4444-4444-4444-444444444444'
        ,3
        ,N'Những lợi thế'
		,''
		,N'<ul><li><p>Khu nghỉ dưỡng Vietsovpetro nằm ở
		 một vị trí địa lý rất thuận lợi: ngay khu vực ngã 3 qua cầu Sông Ray, 
		địa điểm dễ tìm, nằm trên trục đường ven biển đẹp và thuận lợi cho du 
		khách; gần các tổ hợp du lịch cao cấp khác. Khu nghỉ dưỡng Vietsovpetro 
		khi hoàn thiện cả 2 giai đoạn sẽ đạt tiêu chuẩn 5 sao có đầy đủ các dịch
		 vụ cao cấp để phục vụ du khách.</p></li><li><p>Với trung tâm hội nghị và tổ hợp 
		nhà hàng, hồ bơi lớn, Khu nghỉ dưỡng Vietsovpetro là nơi lý tưởng để tổ 
		chức các hội nghị, sự kiện cho Ngành Dầu khí và các tập đoàn, đơn vị 
		kinh tế ở khu vực phía Nam; đội ngũ tổ chức sự kiện của khu nghỉ dưỡng 
		chuyên nghiệp và có mối liên hệ chặt chẽ với các công ty tổ chức sự kiện
		 lớn trong cả nước đủ năng lực để tổ chức các hội nghị tầm cỡ quốc gia 
		và quốc tế.</p></li><li><p>Khu nghỉ dưỡng có bãi biển dài 
		trên 600m có trang bị bến du thuyền phục vụ cho những du khách ưa thích 
		du thuyền và các dịch vụ lướt sóng.</p></li><li><p>Đội ngũ nhân viên resort và bộ phận phụ trách lữ hành chuyên nghiệp có thể đáp ứng nhu cầu đa dạng của du khách.</p></li></ul>'
        ,'admin'
		,''
		,0
		,'vi-VN'
		,0
		,1
		,0
		,''
		,'11111111-1111-1111-1111-111111111111'
		,''
		,'11111111-1111-1111-1111-111111111111'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategoryArticles] WHERE [ArticleCategory_ArticleCategoryID] = '11111111-1111-1111-1111-111111111111' AND [Article_ArticleID] = '11111111-1111-1111-1111-111111111111')
BEGIN
    INSERT INTO [dbo].[ArticleCategoryArticles] 
    (
        [Article_ArticleID]
        ,[ArticleCategory_ArticleCategoryID]
    )
    VALUES
    (
        '11111111-1111-1111-1111-111111111111'
		,'11111111-1111-1111-1111-111111111111'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategoryArticles] WHERE [ArticleCategory_ArticleCategoryID] = '11111111-1111-1111-1111-111111111111' AND [Article_ArticleID] = '22222222-2222-2222-2222-222222222222')
BEGIN
    INSERT INTO [dbo].[ArticleCategoryArticles] 
    (
        [Article_ArticleID]
        ,[ArticleCategory_ArticleCategoryID]
    )
    VALUES
    (
        '22222222-2222-2222-2222-222222222222'
		,'11111111-1111-1111-1111-111111111111'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategoryArticles] WHERE [ArticleCategory_ArticleCategoryID] = '11111111-1111-1111-1111-111111111111' AND [Article_ArticleID] = '33333333-3333-3333-3333-333333333333')
BEGIN
    INSERT INTO [dbo].[ArticleCategoryArticles] 
    (
        [Article_ArticleID]
        ,[ArticleCategory_ArticleCategoryID]
    )
    VALUES
    (
        '33333333-3333-3333-3333-333333333333'
		,'11111111-1111-1111-1111-111111111111'
    )
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[ArticleCategoryArticles] WHERE [ArticleCategory_ArticleCategoryID] = '11111111-1111-1111-1111-111111111111' AND [Article_ArticleID] = '44444444-4444-4444-4444-444444444444')
BEGIN
    INSERT INTO [dbo].[ArticleCategoryArticles] 
    (
        [Article_ArticleID]
        ,[ArticleCategory_ArticleCategoryID]
    )
    VALUES
    (
        '44444444-4444-4444-4444-444444444444'
		,'11111111-1111-1111-1111-111111111111'
    )
END