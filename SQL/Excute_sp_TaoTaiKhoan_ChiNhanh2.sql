USE QLDungCuTheThao
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoTaiKhoan]
		@LGNAME = N'pqtrung',
		@PASS = N'trung123',
		@USERNAME = N'10',
		@ROLE = N'QLCHINHANH'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoTaiKhoan]
		@LGNAME = N'phviet',
		@PASS = N'viet123',
		@USERNAME = N'2',
		@ROLE = N'GIAMDOC'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_TaoTaiKhoan]
		@LGNAME = N'hmkhoi',
		@PASS = N'khoi123',
		@USERNAME = N'7',
		@ROLE = N'NHANVIEN'

SELECT	'Return Value' = @return_value

GO
