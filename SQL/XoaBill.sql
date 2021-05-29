use QuanLyDungCuTheThao;
go

create procedure sp_XoaBill (@ID int)
as
	begin
		declare @Result int;

		begin try
			delete from BillDetail where Bill = @ID;
			delete from Bill where ID = @ID;
			set @Result = 1
			SELECT	'Result' = @Result
		end try
			
		begin catch
			set @Result = 0
			SELECT	'Result' = @Result
		end catch
	end
go