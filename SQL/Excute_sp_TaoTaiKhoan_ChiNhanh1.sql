USE QuanLyDungCuTheThao
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoTaiKhoan]
		@LGNAME = N'hlthanh',
		@PASS = N'shin123',
		@USERNAME = N'9',
		@ROLE = N'QLCHINHANH'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoTaiKhoan]
		@LGNAME = N'pbduy',
		@PASS = N'duy123',
		@USERNAME = N'1',
		@ROLE = N'GIAMDOC'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoTaiKhoan]
		@LGNAME = N'dtnhan',
		@PASS = N'nhan123',
		@USERNAME = N'5',
		@ROLE = N'NHANVIEN'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoTaiKhoan]
		@LGNAME = N'hddoanh',
		@PASS = N'doanh123',
		@USERNAME = N'3',
		@ROLE = N'NHANVIEN'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoTaiKhoan]
		@LGNAME = N'ndkhoa',
		@PASS = N'khoa123',
		@USERNAME = N'4',
		@ROLE = N'NHANVIEN'

SELECT	'Return Value' = @return_value

GO	
