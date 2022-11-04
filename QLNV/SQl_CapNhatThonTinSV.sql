-- tạo một procedure để thêm mới một sinh viên bảng tblSinhVien
exec ThemMoiSV 'Hoang Van Tuan' , 'CN3' ,'Chính Quy' , '2002-12-31' ,'Bắc Ninh' ,1 ,'0987654321'
CREATE PROCEDURE ThemMoiSV

	@fldHoTen nvarchar(30),
	@fldMaLop nvarchar(10),
	@fldHeDaoTao nvarchar(30),
	@fldNgaySinh date,
	@fldDiaChi nvarchar(150),
	@fldGioiTinh tinyint,
	@fldSDT varchar(30)
AS
BEGIN
	insert into tblSinhVien
	(
	fldMaSV , fldHoTen, fldMaLop , fldHeDaoTao , fldNgaySinh , fldDiaChi , fldGioiTinh, fldSDT
	)Values(
		'B1031'+CAST(next value for sinhvienSeq as varchar(30)),
		
	@fldHoTen,
	@fldMaLop ,
	@fldHeDaoTao ,
	@fldNgaySinh ,
	@fldDiaChi ,
	@fldGioiTinh ,
	@fldSDT 
	);-- ket thuc them moi
	-- kiem tra
	IF @@ROWCOUNT > 0  begin return 1 end 
	else begin return 0 end;
END
	

select * from tblSinhVien

create sequence sinhvienSeq 
start with 14124
increment by 1;
select next value for sinhvienSeq


--- Cập nhật 

 create procedure updateSV	 
	 @fldMaSV varchar(30),
	 @fldHoTen nvarchar(30),
	@fldMaLop nvarchar(10),
	@fldHeDaoTao nvarchar(30),
	@fldNgaySinh date,
	@fldDiaChi nvarchar(150),
	@fldGioiTinh tinyint,
	@fldSDT varchar(30)
	--Kết thúc tham số truyền vào 
AS

BEGIN
	UPDATE tblSinhVien
	SET 
	 fldHoTen = @fldHoTen ,
	 fldMaLop = @fldMaLop ,
	 fldHeDaoTao = @fldHeDaoTao ,
	 fldNgaySinh = @fldNgaySinh ,
	 fldDiaChi = @fldDiaChi,
	 fldGioiTinh = @fldGioiTinh ,
	 fldSDT = @fldSDT
	 WHERE fldMaSV = @fldMaSV;
	IF @@ROWCOUNT > 0  begin return 1 end 
	else begin return 0 end;

END

exec updateSV 'B103114125' ,N'Hoàng Văn Tuấn ' , 'CN4' ,N'Chính Quy' , '2002-12-31' ,N'Bắc Ninh' ,1 ,'0981154321'


--- Tạo một hàm để hiển thị thông tin chi tiết của một sinh viên 

create PROCEDURE selectSinhVien  @fldMaSV varchar(30)
AS

BEGIN
	SELECT 
	fldHoTen, convert( varchar(10), fldNgaySinh, 103) as ngaysinh,
	case 
		when fldGioiTinh = 1 then 'Nam' else N'Nữ'
		end as fldGioiTinh, fldDiaChi , fldSDT

	FROM tblSinhVien
	WHERE fldMaSV = @fldMaSV;
END
GO;
--test
exec selectSinhVien 'B103114125'


