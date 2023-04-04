/*
Exercise 1: Line 14
Exercise 2: Line 51
Exercise 3: Line 111
Exercise 4: Line 116
Exercise 5: Line 141
Exercise 6: Line 146
Exercise 7: Line 157
Exercise 8: Line 161
Exercise 9: Line 173
Exercise 10: Line 182
*/

/* Exercise 1 */
CREATE TABLE NhaCungCap(
	MaNhaCC CHAR(10) PRIMARY KEY,
	TenNhaCC NVARCHAR(100) NOT NULL UNIQUE,
	DiaChi CHAR(50) NOT NULL,
	SoDT CHAR(20) NOT NULL UNIQUE,
	MaSoThue INT NOT NULL UNIQUE
);

CREATE TABLE LoaiDichVu(
	MaLoaiDV CHAR(10) PRIMARY KEY,
	TenLoaiDV NVARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE MucPhi(
	MaMP CHAR(10) PRIMARY KEY,
	DonGia MONEY NOT NULL,
	MoTa NVARCHAR(100) NOT NULL
);

CREATE TABLE DongXe(
	DongXe CHAR(20) PRIMARY KEY,
	HangXe CHAR(20) NOT NULL,
	SoChoNgoi INT NOT NULL CHECK(SoChoNgoi > 0)
);

CREATE TABLE DangKyCungCap(
	MaDKCC CHAR(10) PRIMARY KEY,
	MaNhaCC CHAR(10) NOT NULL FOREIGN KEY REFERENCES NhaCungCap(MaNhaCC),
	MaLoaiDV CHAR(10) NOT NULL FOREIGN KEY REFERENCES LoaiDichVu(MaLoaiDV),
	DongXe CHAR(20) NOT NULL FOREIGN KEY REFERENCES DongXe(DongXe),
	MaMP CHAR(10) NOT NULL FOREIGN KEY REFERENCES MucPhi(MaMP),
	NgayBatDauCungCap DATE NOT NULL,
	NgayKetThucCungCap DATE NOT NULL,
	SoLuongXeDangKy INT NOT NULL CHECK(SoLuongXeDangKy > 0)
);

/* Exercise 2 */
INSERT INTO NhaCungCap(MaNhaCC, TenNhaCC, DiaChi, SoDT, MaSoThue) VALUES
('NCC001', N'Cty TNHH Toàn Pháp', 'Hai Chau', '4543525324', 568941),
('NCC002', N'Cty Cổ phần Đông Du', 'Lien Chau', '56623452', 456789),
('NCC003', N'Ông Nguyễn Văn A', 'Hoa Thuan', '43253523', 321456),
('NCC004', N'Cty Cổ phần Toàn Cầu Xanh', 'Hai Chau', '545677746', 513364),
('NCC005', N'Cty TNHH AMA', 'Thanh Khe', '65765373', '546546'),
('NCC006', N'Bà Trần Thị Bích Vân', 'Lien Chieu', '657436346', 524545),
('NCC007', N'Cty TNHH Phan Thành', 'Thanh Khe', '54565235', 113021),
('NCC008', N'Ông Phan Đình Nam', 'Hoa Thuan', '5436373', 121230),
('NCC009', N'Tập đoàn Đông Nam Á', 'Lien Chieu', '5325235', 533654),
('NCC010', N'Cty Cổ phần Rạng Đông', 'Lien Chieu', '4236265233', 187864);

INSERT INTO LoaiDichVu(MaLoaiDV, TenLoaiDV) VALUES
('DV01', N'Dịch vụ xe taxi'),
('DV02', N'Dịch vụ xe buýt công cộng theo tuyến cố định'),
('DV03', N'Dịch vụ xe cho thuê theo hợp đồng');

INSERT INTO MucPhi(MaMP, DonGia, MoTa) VALUES
('MP01', 10000, N'Áp dụng từ 1/2015'),
('MP02', 15000, N'Áp dụng từ 2/2015'),
('MP03', 20000, N'Áp dụng từ 1/2010'),
('MP04', 25000, N'Áp dụng từ 2/2011');

INSERT INTO DongXe(DongXe, HangXe, SoChoNgoi) VALUES
('Hiace', 'Toyota', 16),
('Vios', 'Toyota', 5),
('Escape', 'Ford', 5),
('Cerato', 'KIA', 7),
('Forte', 'KIA', 5),
('Starex', 'Huyndai', 7),
('Grand-i10', 'Huyndai', 7);

INSERT INTO DangKyCungCap(MaDKCC, MaNhaCC, MaLoaiDV, DongXe, MaMP, NgayBatDauCungCap, NgayKetThucCungCap, SoLuongXeDangKy) VALUES
('DK001', 'NCC001', 'DV01', 'Hiace', 'MP01', '2015-11-20', '2016-11-20', 4),
('DK002', 'NCC002', 'DV02', 'Vios', 'MP02', '2015-11-20', '2017-11-20', 3),
('DK003', 'NCC003', 'DV03', 'Escape', 'MP03', '2017-11-20', '2018-11-20', 5),
('DK004', 'NCC005', 'DV01', 'Cerato', 'MP04', '2015-11-20', '2019-11-20', 7),
('DK005', 'NCC002', 'DV02', 'Forte', 'MP03', '2019-11-20', '2020-11-20', 1),
('DK006', 'NCC004', 'DV03', 'Starex', 'MP04', '2016-11-10', '2021-11-20', 2),
('DK007', 'NCC005', 'DV01', 'Cerato', 'MP03', '2015-11-30', '2016-01-25', 8),
('DK008', 'NCC006', 'DV01', 'Vios', 'MP02', '2016-02-28', '2016-08-15', 9),
('DK009', 'NCC005', 'DV03', 'Grand-i10', 'MP02', '2016-04-27', '2017-04-30', 10),
('DK010', 'NCC006', 'DV01', 'Forte', 'MP02', '2015-11-21', '2016-02-22', 4),
('DK011', 'NCC007', 'DV01', 'Forte', 'MP01', '2016-12-25', '2017-02-20', 5),
('DK012', 'NCC007', 'DV03', 'Cerato', 'MP01', '2016-04-14', '2017-12-20', 6),
('DK013', 'NCC003', 'DV02', 'Cerato', 'MP01', '2015-12-21', '2016-12-21', 8),
('DK014', 'NCC008', 'DV02', 'Cerato', 'MP01', '2016-05-20', '2016-12-30', 1),
('DK015', 'NCC003', 'DV01', 'Hiace', 'MP02', '2018-04-24', '2019-11-20', 6),
('DK016', 'NCC001', 'DV03', 'Grand-i10', 'MP02', '2016-06-22', '2016-12-21', 8),
('DK017', 'NCC002', 'DV03', 'Cerato', 'MP03', '2016-09-30', '2019-09-30', 4),
('DK018', 'NCC008', 'DV03', 'Escape', 'MP04', '2017-12-13', '2018-09-30', 2),
('DK019', 'NCC003', 'DV03', 'Escape', 'MP03', '2016-01-24', '2016-12-30', 8),
('DK020', 'NCC002', 'DV03', 'Cerato', 'MP04', '2016-05-03', '2017-10-21', 7),
('DK021', 'NCC006', 'DV01', 'Forte', 'MP02', '2015-01-30', '2016-12-30', 9),
('DK022', 'NCC002', 'DV02', 'Cerato', 'MP04', '2016-07-25', '2017-12-30', 6),
('DK023', 'NCC002', 'DV01', 'Forte', 'MP03', '2017-11-30', '2018-05-20', 5),
('DK024', 'NCC003', 'DV03', 'Forte', 'MP04', '2017-12-23', '2019-11-30', 8),
('DK025', 'NCC003', 'DV03', 'Hiace', 'MP02', '2016-08-24', '2017-10-25', 1);

/* Exercise 3 */
SELECT DongXe, SoChoNgoi
FROM DongXe
WHERE SoChoNgoi > 5;

/* Exercise 4 */
SELECT *
FROM NhaCungCap
WHERE MaNhaCC IN (
	SELECT DISTINCT MaNhaCC
	FROM DangKyCungCap
	WHERE (DongXe IN (
		SELECT DongXe
		FROM DongXe
		WHERE HangXe = 'Toyota')
		AND MaMP IN (
		SELECT MaMP
		FROM MucPhi
		WHERE DonGia = 15000))
	OR (
		DongXe IN (
		SELECT DongXe
		FROM DongXe
		WHERE HangXe = 'KIA')
		AND MaMP IN (
		SELECT MaMP
		FROM MucPhi
		WHERE DonGia = 20000))
);

/* Exercise 5 */
SELECT *
FROM NhaCungCap
ORDER BY TenNhaCC, MaSoThue DESC;

/* Exercise 6 */
SELECT *
FROM NhaCungCap
JOIN (
	SELECT MaNhaCC, COUNT(MaDKCC) AS SoLanDangKy
	FROM DangKyCungCap
	WHERE NgayBatDauCungCap = '2015-11-20'
	GROUP BY MaNhaCC
) sl
	ON NhaCungCap.MaNhaCC = sl.MaNhaCC;

/* Exercise 7 */
SELECT DISTINCT HangXe
FROM DongXe;

/* Exercise 8 */
SELECT ncc.MaNhaCC, MaDKCC,TenNhaCC, DiaChi, MaSoThue, TenLoaiDV, DonGia, HangXe, NgayBatDauCungCap, NgayKetThucCungCap
FROM NhaCungCap ncc
LEFT JOIN DangKyCungCap dkcc
	ON dkcc.MaNhaCC = ncc.MaNhaCC
LEFT JOIN LoaiDichVu ldv
	ON dkcc.MaLoaiDV = ldv.MaLoaiDV
LEFT JOIN MucPhi mp
	ON dkcc.MaMP = mp.MaMP
LEFT JOIN DongXe dx
	ON dkcc.DongXe = dx.DongXe;

/* Exercise 9 */
SELECT *
FROM NhaCungCap
WHERE MaNhaCC IN (
	SELECT MaNhaCC
	FROM DangKyCungCap
	WHERE DongXe = 'Hiace' OR DongXe = 'Cerato'	
);

/* Exercise 10 */
SELECT ncc.MaNhaCC, TenNhaCC, DiaChi, SoDT, MaSoThue
FROM NhaCungCap ncc
LEFT JOIN DangKyCungCap dkcc
	ON ncc.MaNhaCC = dkcc.MaNhaCC
WHERE MaDKCC IS NULL;