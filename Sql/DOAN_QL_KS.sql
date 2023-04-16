USE master
GO

IF DB_ID('QL_KS_TUAN_1') IS NOT NULL
   drop database QL_KS_TUAN_1
GO

/*=============================================================
================= TAO DATABASE (VIET) ===================
=============================================================*/
Declare @Primary_Path nvarchar(max), @Secon_Path nvarchar(max), @Log_Path nvarchar(max)
Select	@Primary_Path = N'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9) (1)\Sql\Primary file',
		@Secon_Path = N'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9) (1)\Sql\Secondary File',
		@Log_Path = N'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9) (1)\Sql\Log file'
DECLARE @SQL nvarchar(max);
SET @SQL = N'
CREATE DATABASE QL_KS_TUAN_1
ON PRIMARY
(
	NAME = QL_KS_TUAN_1_PRIMARY,
	FILENAME = ''' + @Primary_Path + '\QL_KS_TUAN_1_PRIMARY.mdf'',
	SIZE = 20 MB,
	MAXSIZE = 50 MB,
	FILEGROWTH = 10%
),
FILEGROUP FG1_QL_KS_TUAN_1
(
	NAME = QL_KS_TUAN_1_SECONDARY_1_1,
	FILENAME = ''' + @Secon_Path + '\QL_KS_TUAN_1_SECONDARY_1_1.ndf'',
	SIZE = 5 MB,
	MAXSIZE = 10 MB,
	FILEGROWTH = 10%
),
(
	NAME = QL_KS_TUAN_1_SECONDARY_1_2,
	FILENAME = ''' + @Secon_Path + '\QL_KS_TUAN_1_SECONDARY_1_2.ndf'',
	SIZE = 5 MB,
	MAXSIZE = 10 MB,
	FILEGROWTH = 10%
)
LOG ON
(
	NAME = QL_KS_TUAN_1_LOG,
	FILENAME = ''' + @Log_Path + '\QL_KS_TUAN_1_LOG.trn'',
	SIZE = 10 MB,
	MAXSIZE = 20 MB,
	FILEGROWTH = 10%
)' 
EXEC (@SQL)
GO

USE QL_KS_TUAN_1
GO

/*=============================================================
=================== TAO TABLE (TUNG, VIET) ====================
=============================================================*/
CREATE TABLE KHACHHANG (
   MA_KH                varchar(10)			not null,
   HOTEN_KH             nvarchar(50)		not null,
   PHAI					nvarchar(3)			not null,
   CCCD_KH              varchar(12)			not null,
   EMAIL				varchar(50)			null,
   SDT_KH               varchar(11)			not null,
   Constraint PK_KHACHHANG primary key (MA_KH)
)
ON [PRIMARY]
GO

CREATE TABLE NHANVIEN (
   MA_NV                varchar(10)			not null,
   HOTEN_NV             nvarchar(50)        not null,
   PHAI					nvarchar(3)			not null,
   DIACHI_NV            nvarchar(50)        null,
   CCCD_NV              varchar(12)         not null,
   CHUCVU_NV            nvarchar(20)        null,
   Constraint PK_NHANVIEN primary key (MA_NV)
)
ON [PRIMARY]
GO

CREATE TABLE PHONG (
   MA_P                 varchar(10)         not null,
   TEN_P				varchar(10)			not null,
   MA_NV                varchar(10)         not null,
   LOAI_P               nvarchar(10)        not null,
   GIA_P                float		        not null,
   TINHTRANG_P          nvarchar(20)        null,
   Constraint PK_PHONG primary key (MA_P)
)
ON [PRIMARY]
GO

CREATE TABLE THUE (
   MA_KH                varchar(10)			not null,
   MA_P                 varchar(10)			not null,
   NGAY_DEN				date			not null,
   NGAY_DI				date			not null,
   TINHTRANG_THUE		nvarchar(20)		null
   Constraint PK_THUE primary key (MA_KH, MA_P)
)
ON [FG1_QL_KS_TUAN_1]
GO

CREATE TABLE HOADON (
   MA_HD                varchar(10)			not null,
   MA_NV                varchar(10)			not null,
   MA_KH                varchar(10)			not null,
   MA_P					varchar(10)			not null,
   NGAY_HD              date				null,
   TONG_HD              float				null,
   Constraint PK_HOADON primary key (MA_HD, MA_NV, MA_KH)
)
ON [FG1_QL_KS_TUAN_1]
GO

/* TẠO THÊM 3 BẢNG LƯU TRỮ NGƯỜI DÙNG, QUYỀN, NHÓM QUYỀN (VIET)*/
CREATE TABLE NHOMNGUOIDUNG (
	MA_NHOMNGUOIDUNG	varchar(10)			not null,
	TEN_NHOM			nvarchar(50)		not null,
	GHICHU				nvarchar(50)		null,
	Constraint PK_NHOMNGUOIDUNG primary key (MA_NHOMNGUOIDUNG)
) 
ON [FG1_QL_KS_TUAN_1]
GO

CREATE TABLE NGUOIDUNGNHOMNGUOIDUNG (
	MA_NV				varchar(10)			not null,
	MA_NHOMNGUOIDUNG	varchar(10)			not null,
	GHICHU				nvarchar(50)		null,
	Constraint PK_NGUOIDUNGNHOMNGUOIDUNG primary key (MA_NV, MA_NHOMNGUOIDUNG)
) 
ON [FG1_QL_KS_TUAN_1]
GO

CREATE TABLE PHANQUYEN (
	MA_NHOMNGUOIDUNG	varchar(10)			not null,
	COQUYEN				nvarchar(100)		not null,
	Constraint PK_PHANQUYEN primary key (MA_NHOMNGUOIDUNG, COQUYEN)
) 
ON [FG1_QL_KS_TUAN_1]
GO

/*=============================================================
================== KHOA NGOAI (TUNG, VIET) ====================
=============================================================*/
ALTER TABLE PHONG
ADD Constraint FK_MA_NV_QLY_PHONG FOREIGN KEY (MA_NV) REFERENCES NHANVIEN (MA_NV)
GO

ALTER TABLE THUE
ADD Constraint FK_MA_KH_THUE_PHONG FOREIGN KEY (MA_KH) REFERENCES KHACHHANG (MA_KH),
	Constraint FK_MA_P_CO_PHONG FOREIGN KEY (MA_P) REFERENCES PHONG (MA_P)
GO

ALTER TABLE HOADON
ADD	Constraint FK_MA_KH_CO_HOADON FOREIGN KEY (MA_KH, MA_P) REFERENCES THUE (MA_KH, MA_P), 
	Constraint FK_MA_NV_LAP_HOADON FOREIGN KEY (MA_NV) REFERENCES NHANVIEN (MA_NV)	
GO

ALTER TABLE NGUOIDUNGNHOMNGUOIDUNG
ADD Constraint FK_MA_NHOMNGUOIDUNG FOREIGN KEY (MA_NHOMNGUOIDUNG) REFERENCES NHOMNGUOIDUNG (MA_NHOMNGUOIDUNG),
	Constraint FK_MA_NV FOREIGN KEY (MA_NV) REFERENCES NHANVIEN (MA_NV)
GO

ALTER TABLE PHANQUYEN
ADD Constraint FK_PHANQUYEN_NHOMNGUOIDUNG FOREIGN KEY (MA_NHOMNGUOIDUNG) REFERENCES NHOMNGUOIDUNG (MA_NHOMNGUOIDUNG)
GO

/*=============================================================
==================== RANG BUOC (CA NHOM) ======================
=============================================================*/
/*------ check ------*/
-- check tinh trang thue (Viet)
alter table thue
add constraint ck_tinhtrang_thue check(TINHTRANG_THUE in(N'Chưa vào ở', N'Đang ở', N'Đã ở xong'))
go

-- check tinh trang phong (Viet)
ALTER TABLE PHONG
add Constraint CK_TINHTRANG_P check(TINHTRANG_P in(N'Còn trống', N'Đã được đặt'))
GO

-- check nam nu NHANVIEN KHACHHANG (Tin)
ALTER TABLE NHANVIEN
ADD Constraint CK_PHAI_NV check(PHAI like N'Nam' or PHAI like N'Nữ')
GO

-- check phai khach hang (Viet)
ALTER TABLE KHACHHANG
ADD Constraint CK_PHAI_KH check(PHAI like N'Nam' or PHAI like N'Nữ')
GO

-- check getdate() <= ngay den <= ngay di (Tin)
ALTER TABLE THUE
ADD Constraint CK_NGAY_THUE check(NGAY_DEN <= NGAY_DI and CAST(CURRENT_TIMESTAMP AS DATE) <= NGAY_DEN)
GO

-- check tong hoa don > 0 (Viet)
ALTER TABLE HOADON
ADD Constraint CK_TONG_HD check(TONG_HD >= 0)
GO

-- check loai phong (Viet)
ALTER TABLE PHONG
ADD Constraint CK_LOAI_P check(LOAI_P in(N'1 người', N'2 người', N'3 người', N'VIP'))
GO

-- check gia phong > 0 (Thinh)
ALTER TABLE PHONG
ADD Constraint CK_GIA_P check(GIA_P > 0)
GO

-- check email (Viet)
ALTER TABLE KHACHHANG
ADD Constraint CK_EMAIL check(email like '_%@__%.__%')
GO

-- check sdt cua khach hang phai tu 9 den 11 so (Tung)
ALTER TABLE KHACHHANG
ADD Constraint CK_SDT_KH check(DATALENGTH (SDT_KH) >=9 AND DATALENGTH (SDT_KH) <12 );
GO

/*------ UNIQUE ------*/
-- unique ten phong (Viet)
ALTER TABLE PHONG
ADD Constraint UNI_TEN_P unique(TEN_P)
GO

/*------ default ------*/
-- default tinh trang thue la 'chua vao o' (Viet)
alter table thue
add constraint df_ttthue
default N'Chưa vào ở' for TINHTRANG_THUE
GO

-- default tinh trang phong la 'con trong' (Thang)
ALTER TABLE PHONG
ADD Constraint DF_TTPHONG
default N'Còn trống' FOR TINHTRANG_P

-- default chuc vu 'nhan vien' (Viet)
ALTER TABLE NHANVIEN
ADD Constraint DF_CHUCVU default N'Nhân viên' for CHUCVU_NV
GO

-- default email 'khong co' (Viet)
ALTER TABLE KHACHHANG
ADD Constraint DF_EMAIL default N'Không có' for EMAIL
GO

-- default ngayden la getdate() (Viet)
ALTER TABLE THUE
ADD Constraint DF_NGAY_DEN default getdate() for NGAY_DEN
GO

-- default diachi_nv la 'khong co thong tin' (Viet)
ALTER TABLE NHANVIEN
ADD Constraint DF_DIACHI default N'Không có thông tin' for DIACHI_NV
GO

-- default ghichu la 'khong co ghi chu gi' (Viet)
ALTER TABLE NGUOIDUNGNHOMNGUOIDUNG
ADD Constraint DF_GHICHU_NGUOIDUNGNHOMNGUOIDUNG default N'Không có ghi chú gì' for GHICHU
GO

ALTER TABLE NHOMNGUOIDUNG
ADD Constraint DF_GHICHU_NHOMNGUOIDUNG default N'Không có ghi chú gì' for GHICHU
GO

/*=============================================================
==================== IMPORT DU LIEU (VIET) ====================
=============================================================*/
-- KHACHHANG
BULK INSERT KHACHHANG
FROM 'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9) (1)\Sql\Import data\Excel for bulk\KhachHang.csv'
with
	(
		CHECK_CONSTRAINTS,
		CODEPAGE=65001,
		fieldterminator=';',
		ROWTERMINATOR = '\n',
		firstrow=2
	)
GO
select * from KHACHHANG
GO

-- NHANVIEN
BULK INSERT NHANVIEN
FROM 'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9) (1)\Sql\Import data\Excel for bulk\NhanVien.csv'
with
	(
		CHECK_CONSTRAINTS,
		CODEPAGE=65001,
		fieldterminator=';',
		ROWTERMINATOR = '\n',
		firstrow=2
	)
GO
select * from NHANVIEN
GO

-- PHONG
BULK INSERT PHONG
FROM 'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9) (1)\Sql\Import data\Excel for bulk\Phong.csv'
with
	(
		CHECK_CONSTRAINTS,
		CODEPAGE=65001,
		fieldterminator=';',
		ROWTERMINATOR = '\n',
		firstrow=2
	)
GO
select * from PHONG
GO

-- THUE
BULK INSERT THUE
FROM 'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9) (1)\Sql\Import data\Excel for bulk\Thue.csv'
with
	(
		CHECK_CONSTRAINTS,
		CODEPAGE=65001,
		fieldterminator=';',
		ROWTERMINATOR = '\n',
		firstrow=2
	)
GO
select * from THUE
GO

-- HOADON
BULK INSERT HOADON
FROM 'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9) (1)\Sql\Import data\Excel for bulk\HoaDon.csv'
with
	(
		CHECK_CONSTRAINTS,
		CODEPAGE=65001,
		fieldterminator=';',
		ROWTERMINATOR = '\n',
		firstrow=2
	)
GO
select * from HOADON
GO

/*=============================================================
============= IMPORT BY OPENDATASOURCE (VIET) =================
=============================================================*/
sp_configure 'show advanced options', 1;
RECONFIGURE;
go

sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE;
go

EXEC master.dbo.sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'AllowInProcess', 1 
GO 

EXEC master.dbo.sp_MSset_oledb_prop N'Microsoft.ACE.OLEDB.12.0', N'DynamicParameters', 1 
GO

-- KHACHHANG
INSERT INTO KHACHHANG
SELECT *
FROM OPENDATASOURCE('Microsoft.ACE.OLEDB.12.0',
    N'Data Source=D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9)\Sql\Import data\Excel for opendatasource\DuLieu.xlsx;
	Extended Properties=Excel 12.0')...[KHACHHANG$]
GO
select * from KHACHHANG
go

-- NHANVIEN
INSERT INTO NHANVIEN
SELECT *
FROM OPENDATASOURCE('Microsoft.ACE.OLEDB.12.0',
    N'Data Source=D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9)\Sql\Import data\Excel for opendatasource\DuLieu.xlsx;
	Extended Properties=Excel 12.0')...[NHANVIEN$];
GO
select * from NHANVIEN
go

-- PHONG
INSERT INTO PHONG (MA_P, TEN_P, MA_NV, LOAI_P, GIA_P)
SELECT *
FROM OPENDATASOURCE('Microsoft.ACE.OLEDB.12.0',
    N'Data Source=D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9)\Sql\Import data\Excel for opendatasource\DuLieu.xlsx;
	Extended Properties=Excel 12.0')...[PHONG$]
GO
select * from PHONG
go

-- THUE
INSERT INTO THUE(MA_KH, MA_P, NGAY_DEN, NGAY_DI)
SELECT *
FROM OPENDATASOURCE('Microsoft.ACE.OLEDB.12.0',
    N'Data Source=D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9)\Sql\Import data\Excel for opendatasource\DuLieu.xlsx;
	Extended Properties=Excel 12.0')...[THUE$];
GO
select * from THUE
go

-- HOADON
INSERT INTO HOADON(MA_HD, MA_NV, MA_KH, MA_P)
SELECT *
FROM OPENDATASOURCE('Microsoft.ACE.OLEDB.12.0',
    N'Data Source=D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9)\Sql\Import data\Excel for opendatasource\DuLieu.xlsx;
	Extended Properties=Excel 12.0')...[HOADON$];
GO
select * from HOADON
go

/*=============================================================
==================== UPDATE DU LIEU (Viet)=====================
=============================================================*/
-- tinh ngay va tong hoa don
-- vi import du lieu trigger khong chay hang loat row duoc
create proc UPD_NG_TONG_HD
as
	begin
		declare @mahd varchar(10)
		declare cur_MA_HD CURSOR
		for select MA_HD from HOADON
			open cur_MA_HD
			while (1 = 1)
				begin
					fetch next from cur_MA_HD into @mahd
					if (@@FETCH_STATUS = 0)
						begin
							update HOADON SET NGAY_HD = NGAY_DI
							from THUE
							where THUE.MA_KH = HOADON.MA_KH and THUE.MA_P = HOADON.MA_P and MA_HD = @mahd

							update HOADON SET TONG_HD = (DATEDIFF(dd, NGAY_DEN, NGAY_DI) + 1) * GIA_P
							from THUE, PHONG
							where THUE.MA_KH = HOADON.MA_KH and THUE.MA_P = HOADON.MA_P and MA_HD = @mahd and HOADON.MA_P = PHONG.MA_P
						end
					else
						break
				end
			close cur_MA_HD
			deallocate cur_MA_HD
	end
go
exec UPD_NG_TONG_HD
go
select * from HOADON
go

/*=============================================================
========================== TRIGGER ============================
=============================================================*/
-- trigger them khach hang thue cung phong thi phai khac nhau khoang thoi gian o cua khach hang khac (Viet)
create proc ck_Trung_Thgian (@map varchar(10), @ngay_bd date, @ngay_kt date, @count int output)
as
	begin
		-- biến count output trả trá trị 0 và 1 ( =0 nếu không trùng thời gian và ngược lại)
		set @count = 0
		-- gán biến trigger truyền vào
		declare @ngay_bd_trig date, @ngay_kt_trig date, @map_trig varchar(10)
		select @ngay_bd_trig = @ngay_bd, @ngay_kt_trig = @ngay_kt, @map_trig = @map
		--print N'Nhập vào khách hàng thuê phòng mới có ngày bắt đầu và kết thúc: ' + convert(varchar,@ngay_bd_trig) + ' & ' +  convert(varchar,@ngay_kt_trig)
		--print N'======================================================================================='

		-- biến dùng để duyệt kiểm tra ngày bắt đầu và kết thúc
		declare @duyet date

		-- biến cursor duyệt
		declare @ngay_bd_cur date, @ngay_kt_cur date, @map_cur varchar(10)
		declare cur_NGAY CURSOR
		for select NGAY_DEN, NGAY_DI, MA_P from THUE where MA_P = @map_trig
			open cur_NGAY
			while (1 = 1)
				begin
					set @ngay_bd_trig = @ngay_bd
					set @ngay_kt_trig = @ngay_kt
					fetch next from cur_NGAY into @ngay_bd_cur, @ngay_kt_cur, @map_cur
					if (@@FETCH_STATUS = 0)
						begin
							--print N'Duyệt ngày thuê đang tồn tại có ngày bắt đầu và ngày kt: ' + convert(varchar,@ngay_bd_cur) + ', ' + convert(varchar,@ngay_kt_cur) 
							--print N'------------------------ SO SÁNH ------------------------'
							while( @ngay_kt_trig > = @ngay_bd_trig)
								begin
									set @duyet = @ngay_bd_cur
									while (@ngay_kt_cur >= @duyet)
										begin
											if (@ngay_bd_trig = @duyet or @ngay_kt_trig = @duyet)
												begin
													--print '' + convert(varchar,@ngay_bd_trig) + ' = ' + convert(varchar, @duyet) + ' VÀ ' + convert(varchar,@ngay_kt_trig) + ' = ' + convert(varchar, @duyet) + ' => +1'
													set @count = @count + 1
												end
											--else
											--	begin
											--		print '' + convert(varchar,@ngay_bd_trig) + ' = ' + convert(varchar, @duyet) + ' VÀ ' + convert(varchar,@ngay_kt_trig) + ' = ' + convert(varchar, @duyet) + ' => 0'
											--	end
											set @duyet = dateadd(day, 1, @duyet)
										end
									set @ngay_bd_trig = dateadd(day, 1, @ngay_bd_trig)
									set @ngay_kt_trig = dateadd(day, -1, @ngay_kt_trig)
									--print ''
								end
						end
					else
						begin
							--print N'Kết thúc'
							--print N'Không còn trường tin nào'
							break
						end
				end
			close cur_NGAY
			deallocate cur_NGAY
	end
go

create TRIGGER CK_TRUNG_THGIAN_trig
ON THUE
instead of insert
as
	begin
		declare @makh_trig varchar(10), @map_trig varchar(10), @ngay_bd_trig date, @ngay_kt_trig date
		select @makh_trig = inserted.MA_KH, @map_trig = inserted.MA_P, @ngay_bd_trig = inserted.NGAY_DEN, @ngay_kt_trig = inserted.NGAY_DI from inserted

		declare @count int
		exec ck_Trung_Thgian @map_trig, @ngay_bd_trig, @ngay_kt_trig, @count output

		if (@count) = 0
			begin
				if exists (select * from inserted)
					begin
						insert into THUE (MA_KH, MA_P, NGAY_DEN, NGAY_DI) 
						values (@makh_trig, @map_trig, @ngay_bd_trig, @ngay_kt_trig)
						print N'Thêm thành công'
					end
				--else
				--	begin
				--		update THUE set MA_P = @map_trig, NGAY_DEN = @ngay_bd_trig, NGAY_DI = @ngay_kt_trig from deleted
				--		where THUE.MA_KH = deleted.MA_KH and THUE.MA_P = deleted.MA_P
				--	end
			end
		else
			begin
				print N'Thêm thất bại'
			end
	end
go

-- trigger ngay lap hoa don = ngay di va tong hoa don (Viet)
create TRIGGER upd_NGAY_HD_TONG_HD 
ON HOADON 
after insert, update
As
Begin
	-- ngay hd
	update HOADON SET NGAY_HD = (select NGAY_DI from THUE, inserted	
								where THUE.MA_P = inserted.MA_P
										and inserted.MA_KH = THUE.MA_KH)
	FROM inserted
	WHERE hoadon.MA_HD = inserted.MA_HD

	-- tong hd
	update HOADON set TONG_HD = (select GIA_P * (datediff(dd, NGAY_DEN, NGAY_DI) + 1)
								from inserted, PHONG, THUE
								where inserted.MA_P = PHONG.MA_P
									and inserted.MA_KH = THUE.MA_KH
									and PHONG.MA_P = THUE.MA_P)
	from inserted
	where HOADON.MA_HD = inserted.MA_HD
end
GO

-- trigger xoa khachhang (Viet)
CREATE TRIGGER del_KHACHHANG
ON KHACHHANG
INSTEAD OF delete
As
Begin
	-- xoa hoadon
	delete HOADON where MA_KH in(select MA_KH 
								from deleted)
	-- xoa thue
	delete THUE where MA_KH in(select MA_KH 
								from deleted)
	-- xoa khachhang
	delete KHACHHANG where MA_KH in(select MA_KH 
									from deleted)
end
GO

-- trigger xoa phong (Viet)
CREATE TRIGGER del_PHONG
ON PHONG
INSTEAD OF delete
As
Begin
	-- xoa hoadon
	delete HOADON where MA_P in(select MA_P
								from deleted)
	-- xoa thue
	delete THUE where MA_P in(select MA_P 
							from deleted)
	-- xoa phong
	delete PHONG where MA_P in(select MA_P
								from deleted)
end
GO

/*=============================================================
================= Function, proc, cursor ======================
=============================================================*/
/*---- KHÁCH HÀNG (Tùng) ----*/
-- Kiểm tra mã khách hàng
CREATE PROC [dbo].[KiemTraMaKH]
@Makh nvarchar(20)
as
begin
    if exists (select * from KHACHHANG where MA_KH = @Makh)
        select 1 as code
    else select 0 as code
end
go
--Kiểm tra mã khách hàng CCCD KHACHHANG, SDT KHACHHANG,EMAIL KHACHHANG , Ten KHACHHANG

CREATE PROC CCCD
@cccd nvarchar(12)
as
begin
    if exists (select * from KHACHHANG where CCCD_KH = @cccd)
        select 1 as code
    else select 0 as code
end
go

CREATE PROC SDT
@sdt nvarchar(11)
as
begin
    if exists (select * from KHACHHANG where SDT_KH = @sdt)
        select 1 as code
    else select 0 as code
end
go


CREATE PROC EMAIL
@email nvarchar(50)
as
begin
    if exists (select * from KHACHHANG where EMAIL = @email)
        select 1 as code
    else select 0 as code
end
go

CREATE PROC TEN
@ten nvarchar(50)
as
begin
    if exists (select * from KHACHHANG where HOTEN_KH = @ten)
        select 1 as code
    else select 0 as code
end
go

-- Xuất Danh Sách khách hàng
Create Function XuatKhachHang()
Returns Table
As
	Return	( 
				Select * from KhachHang
			)
Go

create proc XuatKH
as 
begin
	select * from dbo.XuatKhachHang()
end
go

--Xuất khách hàng theo mã kh
Create Function XuatKhachHangTheoMa(@makh varchar(10))
Returns Table
As
	Return	( 
				Select * from KhachHang
				Where MA_KH = @makh
			)
Go

Create proc XuatKHtheoma @makh varchar(10)
as 
begin

		select * from dbo.XuatKhachHangTheoMa(@makh)
end
go


--Xuất khách hàng theo Ten kh
Create Function XuatKhachHangTheoTen(@tenkh nvarchar(50))
Returns Table
As
	Return	( 
				Select * from KhachHang
				Where HOTEN_KH = @tenkh
			)
Go

Create proc XuatKHTheoTen @tenkh nvarchar(50)
as 
begin
	select * from dbo.XuatKhachHangTheoTen(@tenkh)
end
go 

--Xuất khách hàng theo SDT kh
Create Function XuatKhachHangTheoSDT(@sdt varchar(11))
Returns Table
As
	Return	( 
				Select * from KhachHang
				Where SDT_KH = @sdt
			)
Go

Create proc XuatKhachHangtuSdt @sdt varchar(11)
as 
begin
	select * from dbo.XuatKhachHangTheoSDT(@sdt)
end
go

-- Thêm khách hàng
CREATE PROC [dbo].[ThemKhachHang]
@MA_KH              varchar(10),
@HOTEN_KH           nvarchar(50),
@PHAI				nvarchar(3),
@CCCD_KH            varchar(12),
@EMAIL				varchar(50),
@SDT_KH             varchar(11)
as
begin
	INSERT INTO KHACHHANG (MA_KH, HOTEN_KH, PHAI, CCCD_KH, EMAIL, SDT_KH)
	VALUES (@MA_KH ,@HOTEN_KH,@PHAI,@CCCD_KH,@EMAIL,@SDT_KH)
end
go


-- Xóa khách hàng
CREATE PROC [dbo].[XoaKhachHang]
@MA_KH   varchar(10)
as
begin
	delete from KHACHHANG
	where MA_KH = @MA_KH 
end
go

-- Sửa khách hàng
CREATE PROC [dbo].[SuaKhachHang]
@MA_KH              varchar(10),
@HOTEN_KH           nvarchar(50),
@PHAI				nvarchar(3),
@CCCD_KH            varchar(12),
@EMAIL				varchar(50),
@SDT_KH             varchar(11)
as
begin
				update KHACHHANG 
				set HOTEN_KH = @HOTEN_KH, PHAI = @PHAI, CCCD_KH =@CCCD_KH,EMAIL = @EMAIL, SDT_KH = @SDT_KH
				where MA_KH = @MA_KH
end
go

-- Tra cứu bằng CCCD KH (Thịnh)
Create Function XuatKhachHangTheoCCCD(@cccd varchar(20))
Returns Table
As
	Return	( 
				Select * from KHACHHANG
				Where CCCD_KH = @cccd
			)
Go

Create proc XuatKHtucccd @cccd varchar(20)
as 
begin
	select * from dbo.XuatKhachHangTheoCCCD(@cccd)
end
go

--exec XuatKHtucccd '072201030101'
/*---- NHÂN VIÊN (Thắng) ----*/
-- Xuất nhân viên
create function [dbo].[Func_NhanVien]()
returns table
as
	return select * from NHANVIEN
go

create  proc [dbo].[XuatNhanVien] --sử dụng read uncommitted 
as 
begin tran
	set transaction isolation 
	level read uncommitted
	select * from [dbo].[Func_NhanVien]()
commit tran
go
--drop proc dbo.XuatNhanVien
-- Kiểm tra mã nhân viên
create function [dbo].[Func_TraMaNhanVien](@Manv varchar(20))
returns  varchar
as
	begin
		if exists (select * from NHANVIEN where MA_NV = @Manv)
			return 1
		return 0
	end
go

CREATE PROC [dbo].[KiemTraMaNV]
@Manv nvarchar(20)
as
	if [dbo].[Func_TraMaNhanVien](@Manv) = 1
		select 1 as code
	else select 0 as code
go

-- Kiểm tra cccd nhân viên
create function [dbo].[Func_TrabangCCCDNhanVien](@Cccd varchar(20))
returns  varchar
as
	begin
		if exists (select * from NHANVIEN where CCCD_NV = @Cccd)
			return 1
		return 0
	end
go

CREATE PROC [dbo].[KiemTratheoCCCDNV]
@Cccd  varchar(20)
as
	if [dbo].[Func_TrabangCCCDNhanVien](@Cccd) = 1
		select 1 as code
	else select 0 as code
go

-- Kiểm tra ten nhân viên
create function [dbo].[Func_TrabangTenNhanVien](@ten nvarchar(20))
returns  nvarchar
as
	begin
		if exists (select * from NHANVIEN where HOTEN_NV like '%'+@ten+'%')
			return 1
		return 0
	end
go

CREATE PROC [dbo].[KiemTratheoTenNV]
@ten  nvarchar(20)
as
	if [dbo].[Func_TrabangTenNhanVien](@ten) = 1 
		select 1 as code
	else select 0 as code
go

 --drop PROC [dbo].[KiemTratheoTenNV]
-- Thêm nhân viên -- có giao tác 
create PROC [dbo].[ThemNhanVien]
@MA_NV                varchar(10),
@HOTEN_NV             nvarchar(50),
@PHAI					nvarchar(3),
@DIACHI_NV            nvarchar(50),
@CCCD_NV              varchar(12),
@CHUCVU_NV            nvarchar(20),
@MATKHAU				varchar(15)
as
begin
	--begin tran
	--set transaction isolation --giai quyet tat ca van de
	--level serializable
	INSERT INTO NHANVIEN(MA_NV, HOTEN_NV, PHAI, DIACHI_NV, CCCD_NV, CHUCVU_NV)
	VALUES (@MA_NV, @HOTEN_NV, @PHAI, @DIACHI_NV, @CCCD_NV, @CHUCVU_NV)
	insert into NGUOIDUNGNHOMNGUOIDUNG(MA_NV, MA_NHOMNGUOIDUNG)
	values (@MA_NV, 'NV')
	exec pr_TaoTK @MA_NV, @MATKHAU
	--commit tran
end
go

-- Thêm quản lý
CREATE PROC [dbo].[ThemQuanLy]
@MA_NV                varchar(10),
@HOTEN_NV             nvarchar(50),
@PHAI					nvarchar(3),
@DIACHI_NV            nvarchar(50),
@CCCD_NV              varchar(12),
@CHUCVU_NV            nvarchar(20),
@MATKHAU				varchar(15)
as
begin
	INSERT INTO NHANVIEN(MA_NV, HOTEN_NV, PHAI, DIACHI_NV, CCCD_NV, CHUCVU_NV)
	VALUES (@MA_NV, @HOTEN_NV, @PHAI, @DIACHI_NV, @CCCD_NV, @CHUCVU_NV)
	insert into NGUOIDUNGNHOMNGUOIDUNG(MA_NV, MA_NHOMNGUOIDUNG)
	values (@MA_NV, 'QL')
	exec pr_TaoTKQL @MA_NV, @MATKHAU
end
go

-- Xóa nhân viên
CREATE PROC [dbo].[XoaNhanVien]
@MA_NV  varchar(10)
as
begin
	delete from NGUOIDUNGNHOMNGUOIDUNG
	where MA_NV = @MA_NV 
	delete from NHANVIEN
	where MA_NV = @MA_NV 
	exec sp_dropuser @MA_NV
	exec sp_droplogin @MA_NV
	delete NGUOIDUNGNHOMNGUOIDUNG where MA_NV = @MA_NV
end
go

-- Sửa nhân viên -- sử dụng read uncommitted giải quyết mất dữ liệu khi cập nhật(giao tác)
CREATE PROC [dbo].[SuaNhanVien]
@MA_NV                varchar(10),
@HOTEN_NV             nvarchar(50),
@PHAI					nvarchar(3),
@DIACHI_NV            nvarchar(50),
@CCCD_NV              varchar(12),
@CHUCVU_NV            nvarchar(20)
as
	begin tran
		set transaction isolation 
		level read uncommitted
		update NHANVIEN 
		set HOTEN_NV = @HOTEN_NV, PHAI = @PHAI,DIACHI_NV = @DIACHI_NV ,CCCD_NV =@CCCD_NV,CHUCVU_NV = @CHUCVU_NV
		where MA_NV = @MA_NV
	commit tran
go

CREATE PROC [dbo].[SuaMatKhau]
@MA_NV                varchar(10),
@MATKHAUCU				varchar(15),
@MATKHAUMOI				varchar(15)
as
begin
	EXEC sp_password @MATKHAUCU, @MATKHAUMOI, @MA_NV
end
go

-- Tra cứu thông tin nhân viên (Thắng)
--Tra cứu theo tên nhân viên
CREATE FUNCTION [dbo].[fChuyenCoDauThanhKhongDau](@inputVar NVARCHAR(MAX) )
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END
go  

Create proc XuatNVTheoTen @tennv nvarchar(50)
as 
begin
	Select * from NHANVIEN
				Where [dbo].[fChuyenCoDauThanhKhongDau](HOTEN_NV) like ('%'+@tennv+'%')
end
go
-- Tra cứu bằng CCCD
Create Function XuatNhanVienTheoCCCD(@cccd varchar(20))
Returns Table
As
	Return	( 
				Select * from NhanVien
				Where CCCD_NV = @cccd
			)
Go

Create proc XuatNhanVientucccd @cccd varchar(20)
as 
begin
	select * from dbo.XuatNhanVienTheoCCCD(@cccd)
end
go

/*---- PHÒNG (Việt) ----*/
-- Tìm khách hàng chưa thuê phòng
create proc [dbo].[CheckKHChuaThue]
as
	begin
		select PHONG.* from PHONG left join THUE on PHONG.MA_P = thue.MA_P where MA_KH is null
	end
go

-- Tìm kiếm số ngày ở của khách hàng cao nhất theo mã phòng
create proc [dbo].[CheckMaxDate] (@map varchar(10))
as
	begin
		select HOTEN_KH, datediff(dd, NGAY_DEN, NGAY_DI) + 1 as N'Số ngày ở' from THUE right join KHACHHANG on THUE.MA_KH = KHACHHANG.MA_KH 
		where MA_P = @map and datediff(dd, NGAY_DEN, NGAY_DI) >= all (select datediff(dd, NGAY_DEN, NGAY_DI) from THUE where MA_P = @map)
	end
go

-- Kiểm tra nhập liệu khi thêm
create function [dbo].[CheckAllForInsert] (
@map varchar(10),
@tenp nvarchar(10),
@manv varchar(10),
@loaip nvarchar(20),
@giap float,
@tt nvarchar(20))
returns nvarchar(100)
as
	begin
		-- mã phòng
		if (@map = '')
			return N'Mã phòng không để trống'
		else if (left(@map,2) not in('PH', 'ph'))
			return N'Sai định dạng mã phòng'
		else if (@map in(select MA_P from PHONG))
			return N'Trùng mã phòng'
		-- tên phòng
		else if (@tenp = '')
			return N'Tên phòng không để trống'
		else if (left(@tenp,1) not in('A','a','B','b','C','c','D','d','E','e','F','f'))
			return N'Sai định dạng tên phòng'
		else if (@tenp in(select TEN_P from PHONG))
			return N'Trùng tên phòng'
		-- mã nhân viên
		else if (@manv = '')
			return N'Mã nhân viên không để trống'
		else if (left(@manv,2) not in('NV','nv'))
			return N'Sai định dạng mã nhân viên'
		else if (@manv not in (select MA_NV from NHANVIEN))
			return N'Không có nhân viên này'
		-- loại phòng
		else if (@loaip = '')
			return N'Loại phòng không để trống'
		else if (@loaip not in (N'VIP', N'1 người', N'2 người', N'3 người'))
			return N'Không có loại phòng này'
		-- giá phòng
		else if (@giap <= 0)
			return N'Giá phòng > 0'
		-- tình trạng
		else if (@tt not in (N'Còn trống', N'Đã được đặt', N''))
			return N'Sai định dạng tình trạng'
		return N'OK'
	end
go

-- Kiểm tra nhập liệu khi sửa
create function [dbo].[CheckAllForUpdate](
@map varchar(10),
@tenp nvarchar(10),
@manv varchar(10),
@loaip nvarchar(20),
@giap float,
@tt nvarchar(20))
returns nvarchar(100)
as
	begin
		-- mã phòng
		if (@map = '')
			return N'Mã phòng không để trống'
		else if (left(@map,2) not in('PH', 'ph'))
			return N'Sai định dạng mã phòng'
		else if (@map not in(select MA_P from PHONG))
			return N'Không có mã phòng này'
		-- tên phòng
		else if (@tenp = '')
			return N'Tên phòng không để trống'
		else if (left(@tenp,1) not in('A','a','B','b','C','c','D','d','E','e','F','f'))
			return N'Sai định dạng tên phòng'
		else if (@tenp in(select TEN_P from PHONG where TEN_P != @tenp))
			return N'Trùng tên phòng'
		-- mã nhân viên
		else if (@manv = '')
			return N'Mã nhân viên không để trống'
		else if (left(@manv,2) not in('NV','nv'))
			return N'Sai định dạng mã nhân viên'
		else if (@manv not in (select MA_NV from NHANVIEN))
			return N'Không có nhân viên này'
		-- loại phòng
		else if (@loaip = '')
			return N'Loại phòng không để trống'
		else if (@loaip not in (N'VIP', N'1 người', N'2 người', N'3 người'))
			return N'Không có loại phòng này'
		-- giá phòng
		else if (@giap <= 0)
			return N'Giá phòng > 0'
		-- tình trạng
		else if (@tt not in (N'Còn trống', N'Đã được đặt', N''))
			return N'Sai định dạng tình trạng'
		return N'OK'
	end
go

-- Lấy mã nhân viên theo tên
create function [dbo].[LayMaNV] (@ten nvarchar(50))
returns varchar(10)
as
	begin
		declare @mnv varchar(10)
		set @mnv = (select MA_NV from NhanVien where HOTEN_NV = @ten)
		return @mnv
	end
go

-- Xuất phòng và có tên nhân viên quản lý phòng
create function [dbo].[Func_XuatPhong]()
returns @a table (	MA_P varchar(10),
					TEN_P nvarchar(50),
					MA_NV varchar(10),
					HOTEN_NV nvarchar(50),
					LOAI_P nvarchar(20),
					GIA_P float,
					TINHTRANG_P nvarchar(20))
as
	begin
		insert into @a
			select PHONG.MA_P, TEN_P, NHANVIEN.MA_NV, HOTEN_NV, LOAI_P, GIA_P, TINHTRANG_P 
			from PHONG
			inner join NHANVIEN on phong.MA_NV = NHANVIEN.MA_NV
		return
	end
go

create proc [dbo].[XuatPhong]
as 
	begin
		select MA_P, TEN_P, HOTEN_NV, LOAI_P, GIA_P, TINHTRANG_P from dbo.Func_XuatPhong() order by TINHTRANG_P 
	end
go

-- Kiểm tra mã phòng
create function [dbo].[Func_KiemMaPhong](@Map_f varchar(20))
returns int
as
	begin
		if exists (select * from PHONG where MA_P = @Map_f)
			return 0
		return 1
	end
go

CREATE PROC [dbo].[KiemPhong]
@Map varchar(10)
as
	begin
		if (select dbo.Func_KiemMaPhong(@Map)) = 1
			select 1 as code
		else
			select 0 as code
	end
go

-- Thêm phòng
CREATE PROC [dbo].[ThemPhong1]
@MA_P                 varchar(10),
@TEN_P				  varchar(10),
@MA_NV                varchar(10),
@LOAI_P               nvarchar(10),
@GIA_P                float,
@TINHTRANG_P          nvarchar(20)
as
	begin
			INSERT INTO PHONG(MA_P, TEN_P, MA_NV, LOAI_P, GIA_P,TINHTRANG_P)
			VALUES (@MA_P, @TEN_P, @MA_NV, @LOAI_P,@GIA_P ,@TINHTRANG_P)
	end
go

CREATE PROC [dbo].[ThemPhong2]
@MA_P                 varchar(10),
@TEN_P				varchar(10),
@MA_NV                varchar(10),
@LOAI_P               nvarchar(10),
@GIA_P                float
as
	begin
			INSERT INTO PHONG(MA_P, TEN_P, MA_NV, LOAI_P, GIA_P)
			VALUES (@MA_P, @TEN_P, @MA_NV, @LOAI_P,@GIA_P)
	end
go

-- Xóa phòng
CREATE PROC [dbo].[XoaPhong]
@MA_P  varchar(10)
as
	begin
		delete from PHONG
		where MA_P = @MA_P
	end
go

-- Sửa phòng
CREATE PROC [dbo].[SuaPhong1]
@MA_P                 varchar(10),
@TEN_P				varchar(10),
@MA_NV                varchar(10),
@LOAI_P               nvarchar(10),
@GIA_P                float,
@TINHTRANG_P          nvarchar(20)
as
	begin
		update PHONG 
		set TEN_P = @TEN_P, MA_NV = @MA_NV,LOAI_P = @LOAI_P ,GIA_P =@GIA_P, TINHTRANG_P = @TINHTRANG_P
		where MA_P = @MA_P
	end
go

CREATE PROC [dbo].[SuaPhong2]
@MA_P                 varchar(10),
@TEN_P				varchar(10),
@MA_NV                varchar(10),
@LOAI_P               nvarchar(10),
@GIA_P                float
as
	begin
		update PHONG 
		set TEN_P = @TEN_P, MA_NV = @MA_NV,LOAI_P = @LOAI_P ,GIA_P =@GIA_P
		where MA_P = @MA_P
	end
go

-- Load cbo loại phòng
create function [dbo].[LoaiPhong_Function]()
returns @lb table (loaiphong nvarchar(20))
as
	begin
		insert into @lb
			select N'1 người'
		insert into @lb
			select N'2 người'
		insert into @lb
			select N'3 người'
		insert into @lb
			select N'VIP'
		return
	end
go

create PROC [dbo].[XuatLoaiPhong]
as
	begin
		Select * from dbo.LoaiPhong_Function()
	end
go

-- Load cbo mã nhân viên
create function [dbo].[LoaiMaNV_Function]()
returns table
as
	return (select MA_NV, HOTEN_NV from NhanVien)
go

create PROC [dbo].[XuatMaNV]
as
	begin
		Select * from dbo.LoaiMaNV_Function()
	end
go

---- lọc phòng theo loại (Tín)
--create function [dbo].[Func_XuatPhong2](@loai nvarchar(10))
--returns table
--as
--	return select MA_P, TEN_P, HOTEN_NV, LOAI_P, GIA_P, TINHTRANG_P from PHONG, NHANVIEN where LOAI_P like @loai and PHONG.MA_NV = NhanVien.MA_NV
--go

--create proc [dbo].[XuatPhong2] @loai nvarchar(10)
--as 
--	begin
--		select * from dbo.Func_XuatPhong2(@loai)
--	end
--go

-- Kiểm tra phòng có ai thuê không
create proc [dbo].[KiemTra_KH_Thue] (
@map varchar(10))
as
	begin
		if exists (select * from THUE where MA_P = @map)
			select 1 as code
		else select 0 as code
	end
go

-- Tìm kiếm theo mã phòng xuất ra các khách hàng đặt phòng
create proc [dbo].[TimKiem_KH_THUE_PHONG] (
@map varchar(10))
as
	begin
		select HOTEN_KH, thue.NGAY_DEN, thue.NGAY_DI , thue.sno as N'Số ngày ở'
		from KHACHHANG, (select MA_KH, NGAY_DEN, NGAY_DI, datediff(dd, NGAY_DEN, NGAY_DI) as sno 
						from THUE 
						where MA_P = @map) thue
		where KHACHHANG.MA_KH = thue.MA_KH
	end
go

---- Update tình trạng phòng
create proc [dbo].[Update_Tinh_Trang] (@count int output)
as
	begin
		update PHONG set TINHTRANG_P = N'Đã được đặt'
		where PHONG.MA_P in(select distinct MA_P from THUE) and TINHTRANG_P = N'Còn trống'

		update PHONG set TINHTRANG_P = N'Còn trống'
		where PHONG.MA_P not in(select distinct MA_P from THUE) and TINHTRANG_P = N'Đã được đặt'

		set @count = (select count(*) from PHONG where TINHTRANG_P = N'Còn trống')
	end
go

-- Function trả số lượng khách hàng đặt phòng
create function [dbo].[TinhSoLuongKHThuePhong] (@map varchar(10))
returns int
as
	begin
		declare @sl int
		set @sl = 0
		declare cur_Ma_P CURSOR
		for select MA_P from THUE where MA_P = @map
			open cur_Ma_P
			while ( 1 = 1 )
				begin
					fetch next from cur_Ma_P into @map
					if (@@FETCH_STATUS = 0)
						begin
							set @sl = @sl + 1
						end
					else
						break
				end
			close cur_Ma_P
			deallocate cur_Ma_P
		return @sl
	end
go

/*---- Tìm Kiếm Khác Hàng Có MÃ XXX Đang Thuê Phòng Nào  (Tùng) ----*/
--create Function Chon loc TenHK_MAKH_MAP_LOAIP
Create Function TenHK_MAKH_MAP_LOAIP()
Returns Table
As
	Return	( 
				select HOTEN_KH,K.MA_KH,P.MA_P,LOAI_P From ((KHACHHANG k Right join THUE t On k.MA_KH=t.MA_KH)  inner join PHONG  p On t.MA_P =p.MA_P)
			)
Go

-- Create Thủ Tục Chạy TenHK_MAKH_MAP_LOAIP
create Proc Xuat_TenHK_MAKH_MAP_LOAIP
As
Begin
	select * From dbo.TenHK_MAKH_MAP_LOAIP()
End
Go

--Tim Kiem
Create Proc IN_KH_THUE_PH @tenKH nvarchar(50)
As
Begin
	select HOTEN_KH,K.MA_KH,P.MA_P,LOAI_P 
	From ((KHACHHANG k Right join THUE t On k.MA_KH=t.MA_KH)  inner join PHONG  p On t.MA_P =p.MA_P)
	Where HOTEN_KH=@tenKH
End
Go

/*---- HÓA ĐƠN (Thịnh) ----*/
-- Xuất hóa đơn
create function [dbo].[Func_HoaDon]()
returns table
as
	return select MA_HD,MA_NV,k.MA_KH,HOTEN_KH,MA_P, TONG_HD,NGAY_HD from HOADON h LEFT JOIN KHACHHANG k on h.MA_KH = k.MA_KH
go

create proc [dbo].[XuatHoaDon]
as 
	begin
		select * from dbo.Func_HoaDon()
	end
go

-- Kiểm tra hóa đơn
CREATE PROC [dbo].[KiemHoaDon]
@Mahd nvarchar(20)
as
begin
    if exists (select * from HOADON where MA_HD = @Mahd)
        select 1 as code
    else select 0 as code
end
go

-- Thêm hóa đơn
create PROC [dbo].[ThemHoaDon]
@MA_HD              varchar(10),
@MA_NV              varchar(10),
@MA_KH              varchar(10),
@MA_P				varchar(10)
as
	begin
			INSERT INTO HOADON(MA_HD, MA_NV, MA_KH, MA_P)
			VALUES (@MA_HD, @MA_NV, @MA_KH, @MA_P)
	end
go

-- Xuất mã phòng theo thuê
create proc [dbo].[XuatMPT] @makh varchar(10)
as 
	begin
		select MA_P from THUE where MA_KH = @makh
	end
go

-- Xóa hóa đơn
CREATE PROC [dbo].[XoaHoaDon]
@MAHD  varchar(10)
as
	begin
		delete from HOADON
		where MA_HD = @MAHD
	end
go
/*---- Xuất Số Hóa Đơn Mà Khách Hàng Có (Tùng) ----*/

Create Proc InSoHoaDon_KH (@tenkh nvarchar(50))
As
	begin
			Select Count(MA_HD) as 'Số Hóa Đơn Mà Khách Có'  From KHACHHANG kh left join HOADON hd On kh.MA_KH = hd.MA_KH  where kh.HOTEN_KH=@tenkh Group by kh.HOTEN_KH
	end
go
Create Proc InHoaDon_KH (@tenkh nvarchar(50))
As
	begin
			Select MA_HD,MA_NV,kh.MA_KH,MA_P,NGAY_HD,TONG_HD 
			From HOADON hd left join KHACHHANG kh  On hd.MA_KH= kh.MA_KH  
			where kh.HOTEN_KH= @tenkh
	end
go

-- Xuất báo cáo hóa đơn cho khách hàng bằng thủ tục (Viet)
Create proc [dbo].[XuatHoaDon_ChoKH](
@makh varchar(10)
)
as
	begin
		select * From KHACHHANG inner join HOADON on HOADON.MA_KH = KHACHHANG.MA_KH
								inner join THUE on THUE.MA_KH = HOADON.MA_KH and THUE.MA_P = HOADON.MA_P
								inner join PHONG on PHONG.MA_P = HOADON.MA_P
								inner join NHANVIEN on NHANVIEN.MA_NV = HOADON.MA_NV
		where KHACHHANG.MA_KH = @makh
	end
go

--Xuat doanh thu theo ngay
CREATE PROC [dbo].[HDNgay]
@ngay date
as
	begin
		select * from HOADON
		where NGAY_HD = @ngay
	end
go

--Xuất phòng trong thuê(phòng còn chưa được thuê)
create function F_XuatTTPhongTrong()
returns table
as
	return(select * from PHONG
	where not EXISTS (select MA_P from THUE where PHONG.MA_P = THUE.MA_P group by MA_P))
go

create proc XuatTTPhongTrong
as 
begin
	select * from dbo.F_XuatTTPhongTrong()
end
go

/*---- Thuê (Tùng) ----*/
Create Function XuatThongTinThue()
Returns Table
As
	Return	( 
				Select * from THUE
			)
Go

create proc Xuat_ThongtinThue
as 
begin
	select * from dbo.XuatThongTinThue()
end
go

-- Thêm Thuê Phòng
CREATE PROC ThemThuePhong
@MA_KH              varchar(10),
@Ma_P				varchar(10),
@NGAY_DEN			date,
@NGAY_DI			date
as
begin
	set dateformat dmy
	INSERT INTO THUE (MA_KH,MA_P,NGAY_DEN,NGAY_DI)
	VALUES (@MA_KH ,@Ma_P,@NGAY_DEN,@NGAY_DI)
end
go

-- Xóa Thuê Phòng
CREATE PROC XoaThue
@MA_KH   varchar(10),
@MA_P    varchar(10)
as
begin
	delete from THUE
	where MA_KH = @MA_KH And MA_P =@MA_P
end
go


--Khách Hàng Có Bao Nhiu Phiếu Thuê
Create Proc InSoPhieuThue_KH (@tenkh nvarchar(50))
As
	begin
			Select Count(kh.MA_KH) as 'Số Phiếu Thuê Đơn Của Khách'  From KHACHHANG kh left join THUE t On kh.MA_KH = t.MA_KH  where kh.HOTEN_KH=@tenkh Group by kh.HOTEN_KH
	end
go

Create Proc InPhieuThue_KH (@tenkh nvarchar(50))
As
	begin
			Select kh.MA_KH,NGAY_DEN,NGAY_DI,TINHTRANG_THUE
			From KHACHHANG kh left join THUE t On kh.MA_KH = t.MA_KH  
			where kh.HOTEN_KH= @tenkh
	end
go
-- Sửa Thuê Phòng(Thịnh)
CREATE PROC SuaThuePhong
@MA_KH              varchar(10),
@Ma_P				varchar(10),
@Ma_PM				varchar(10),
@NGAY_DEN			date,
@NGAY_DI			date
as
begin
	update THUE 
	set MA_P = @Ma_PM, NGAY_DEN = @NGAY_DEN, NGAY_DI =@NGAY_DI
	where MA_KH = @MA_KH And MA_P =@Ma_P
end
go

-- Xuất thông tin nhân viên đang qly phòng (Thịnh)
create function f_XuatTTKHtheoPhong(@map varchar(10))
returns table
as
	return select NhanVien.MA_NV,HOTEN_NV,PHAI,DIACHI_NV,CHUCVU_NV from NhanVien,PHONG where NhanVien.MA_NV = PHONG.MA_NV and PHONG.MA_P = @map
go
create proc TTNVtheoMP @map varchar(10)
as
begin
	select * from f_XuatTTKHtheoPhong(@map)
end
go

--Cập nhật tình trạng thuê (Thịnh)
--(TINHTRANG_THUE in(N'Chưa vào ở', N'Đang ở', N'Đã ở xong'))
create proc CapNhatTTThue
as
begin
	declare cs_cnttt cursor
	for select NGAY_DEN,NGAY_DI,MA_KH, MA_P from THUE
	open cs_cnttt
	declare @ngayden date, @ngaydi date, @MA_KH varchar(10), @Ma_P varchar(10)
	fetch next from cs_cnttt into @ngayden, @ngaydi, @MA_KH, @Ma_P
	while(@@FETCH_STATUS = 0)
	begin
		if(@ngayden <= GETDATE() and GETDATE() <=  @ngaydi)
			update THUE set TINHTRANG_THUE =  N'Đang ở' where MA_P = @Ma_P and MA_KH = @MA_KH
		else if(GETDATE() < @ngayden)
			update THUE set TINHTRANG_THUE =  N'Chưa vào ở' where MA_P = @Ma_P and MA_KH = @MA_KH
		else 
			update THUE set TINHTRANG_THUE =  N'Đã ở xong' where MA_P = @Ma_P and MA_KH = @MA_KH
		fetch next from cs_cnttt into @ngayden, @ngaydi, @MA_KH, @Ma_P
	end
	close cs_cnttt
	deallocate cs_cnttt
end
go

/*=============================================================
======================== PHAN QUYEN (TIN) =====================
=============================================================*/
-- nhóm quyền quản lý + chỉnh sửa nhân viên
sp_addrole 'QuanLy'

grant all on PHONG to QuanLy with grant option
grant all on HOADON to QuanLy with grant option
grant all on KHACHHANG to QuanLy with grant option
grant all on NHANVIEN to QuanLy with grant option
grant all on THUE to QuanLy with grant option
go

EXEC sp_addrolemember N'db_owner', 'QuanLy'
exec sp_addrolemember N'db_accessadmin', 'QuanLy'
EXEC sp_addrolemember N'db_backupoperator', 'QuanLy'
EXEC sp_addrolemember N'db_datareader', 'QuanLy'
EXEC sp_addrolemember N'db_ddladmin', 'QuanLy'
EXEC sp_addrolemember N'db_owner', 'QuanLy'
EXEC sp_addrolemember N'db_securityadmin', 'QuanLy'
exec sp_addlogin 'NV1', 'NV2mkql'
exec sp_adduser 'NV1', 'NV1'
exec sp_addrolemember 'QuanLy', 'NV1'
go

EXEC sp_addsrvrolemember 'NV1','bulkadmin'
EXEC sp_addsrvrolemember 'NV1','dbcreator'
EXEC sp_addsrvrolemember 'NV1','diskadmin'
EXEC sp_addsrvrolemember 'NV1','processadmin'
EXEC sp_addsrvrolemember 'NV1','securityadmin'
EXEC sp_addsrvrolemember 'NV1','serveradmin'
EXEC sp_addsrvrolemember 'NV1','setupadmin'
EXEC sp_addsrvrolemember 'NV1','sysadmin'
go

-- nhóm quyền nhân viên
sp_addrole 'NhanVien'

grant all on PHONG to NhanVien with grant option
grant all on HOADON to NhanVien with grant option
grant all on KHACHHANG to NhanVien with grant option
grant all on THUE to NhanVien with grant option
go

EXEC sp_addrolemember N'db_datareader', 'NhanVien'
EXEC sp_addrolemember N'db_datawriter', 'NhanVien'
EXEC sp_addrolemember N'db_owner', 'NhanVien'
go

create proc pr_QuyenSV @tk varchar(10)
as
	begin
		EXEC sp_addsrvrolemember @tk,'bulkadmin'
		EXEC sp_addsrvrolemember @tk,'dbcreator'
		EXEC sp_addsrvrolemember @tk,'diskadmin'
		EXEC sp_addsrvrolemember @tk,'processadmin'
		EXEC sp_addsrvrolemember @tk,'securityadmin'
		EXEC sp_addsrvrolemember @tk,'serveradmin'
		EXEC sp_addsrvrolemember @tk,'setupadmin'
		EXEC sp_addsrvrolemember @tk,'sysadmin'
	end
go

create proc pr_TaoTK @tk varchar(10), @mk varchar(15)
as
	begin
		exec sp_addlogin @tk, @mk
		exec sp_adduser @tk, @tk
		exec sp_addrolemember 'NhanVien', @tk
	end
go

create proc pr_TaoTKQL @tk varchar(10), @mk varchar(15)
as
	begin
		exec sp_addlogin @tk, @mk
		exec sp_adduser @tk, @tk
		exec sp_addrolemember 'QuanLy', @tk
		exec pr_QuyenSV @tk
	end
go

insert into NHOMNGUOIDUNG
values
('QL',N'Quản Lý', N'Nhóm được toàn quyền trên tất cả CSDL'),
('NV',N'Nhân Viên', N'Nhóm được quyền toán quyền bảng HD, KH, P, THUE')
select * from NHOMNGUOIDUNG
go

insert into PHANQUYEN
values
('QL',N'Quản lý hoá đơn'),
('QL',N'Quản lý khách hàng'),
('QL',N'Quản lý nhân viên'),
('QL',N'Quản lý phòng'),
('QL',N'Quản lý thuê'),
('NV',N'Quản lý hoá đơn'),
('NV',N'Quản lý khách hàng'),
('NV',N'Quản lý phòng'),
('NV',N'Quản lý thuê')
select * from PHANQUYEN
go

insert into NGUOIDUNGNHOMNGUOIDUNG
values
('NV1', 'QL', null),
('NV2', 'NV', null),
('NV3', 'NV', null),
('NV4', 'NV', null),
('NV5', 'NV', null)
select * from NGUOIDUNGNHOMNGUOIDUNG
go

exec pr_TaoTK 'NV2', 'NV3mknv'
exec pr_TaoTK 'NV3', 'NV4mknv'
exec pr_TaoTK 'NV4', 'NV5mknv'
exec pr_TaoTK 'NV5', 'NV6mknv'
go

go
create function [dbo].[Func_TraQuanLy](@ma varchar(20))
returns  varchar
as
	begin
		if exists (select * from NGUOIDUNGNHOMNGUOIDUNG where MA_NV = @ma and MA_NHOMNGUOIDUNG = 'QL')
			return 1
		return 0
	end
go
CREATE PROC [dbo].[KiemTraMaQL]
@ma  varchar(20)
as
	if [dbo].[Func_TraQuanLy](@ma) = 1
		select 1 as code
	else select 0 as code
go

create proc [dbo].[NVsangQL] @ma varchar(20)
as
	exec sp_droprolemember 'NhanVien', @ma
	exec sp_addrolemember 'QuanLy', @ma
	update NHANVIEN
	set CHUCVU_NV = N'Quản Lí'
	where MA_NV = @ma
	update NGUOIDUNGNHOMNGUOIDUNG
	set MA_NHOMNGUOIDUNG = 'QL'
	where MA_NV = @ma
go

create proc [dbo].[QLsangNV] @ma varchar(20)
as
	exec sp_droprolemember 'QuanLy', @ma
	exec sp_addrolemember 'NhanVien', @ma
	update NHANVIEN
	set CHUCVU_NV = N'Nhân Viên'
	where MA_NV = @ma
	update NGUOIDUNGNHOMNGUOIDUNG
	set MA_NHOMNGUOIDUNG = 'NV'
	where MA_NV = @ma
go

create proc [dbo].[ThemNQuyen] @ma varchar(20), @quyen nvarchar(50)
as
	exec sp_addrolemember @quyen, @ma
go

create proc [dbo].[ThuHoiNQuyen] @ma varchar(20), @quyen nvarchar(50)
as
	exec sp_droprolemember @quyen, @ma
go

create proc [dbo].[ThemNQ] @ma varchar(20), @ten nvarchar(50)
as
	exec sp_addrole @ma
	insert into NHOMNGUOIDUNG(MA_NHOMNGUOIDUNG, TEN_NHOM)
	values
	(@ma,@ten)
go

create proc [dbo].[XoaNQ] @ma varchar(20)
as
	exec sp_droprole @ma
	delete NGUOIDUNGNHOMNGUOIDUNG where MA_NHOMNGUOIDUNG = @ma
	delete NHOMNGUOIDUNG where MA_NHOMNGUOIDUNG = @ma
go

/*=============================================================
=================== BACKUP & RESTORE (VIET) ===================
=============================================================*/
create proc backup_Full (@duongdan nvarchar(300), @ten_db nvarchar(100))
as
	begin
		backup database @ten_db
		to disk = @duongdan
		with init
	end
go

use master
go

create proc restore_Full (@duongdan nvarchar(300), @ten_db nvarchar(100))
as
	begin
		restore database @ten_db
		from disk = @duongdan
		with replace
	end
go

use QL_KS_TUAN_1
go

/*=============================================================
=================== BACKUP & RESTORE mã hóa(Thinh) ===================
=============================================================*/
USE master
GO

CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'demo'
go

CREATE CERTIFICATE QLKSCert
	WITH SUBJECT = 'QLKSCert Backup Certificate';
go

use QL_KS_TUAN_1
go

---- export the backup certificate to a file
--BACKUP CERTIFICATE QLKSCert TO FILE = N'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9)\Sql\Certificate\QLKSCert.cert'
--WITH PRIVATE KEY (
--		FILE =  N'D:\Nguyễn Phương Việt\2022-2023_Năm3-HK1\TH-HệquảntrịCSDL\Bao_Cao\DOAN_ThucHanhHQTCSDL_QLKhachSan (new) (9)\Sql\Certificate\QLKSCert.key',
--		ENCRYPTION BY PASSWORD = 'demo'
--			)
--go

create proc backup_Full_ENCRYPTION (@duongdan nvarchar(300), @ten_db nvarchar(100))
as
	begin
		-- backup the database with encryption
		BACKUP DATABASE @ten_db
		TO DISK = @duongdan 
		WITH ENCRYPTION (
				ALGORITHM = AES_256,
				SERVER CERTIFICATE = QLKSCert
				)
	end
go
--exec backup_Full_ENCRYPTION N'D:\test\QLKSFull.bak',QL_KS_TUAN_1
--go

create proc restore_Full_ENCRYPTION (@duongdan nvarchar(300), @ten_db nvarchar(100))
as
	begin
		restore database @ten_db
		from disk = @duongdan
		with replace
	end
go

--exec restore_Full_ENCRYPTION N'D:\test\QLKSFull.bak',QL_KS_TUAN_1