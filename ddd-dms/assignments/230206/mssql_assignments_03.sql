/* Bai 1 */
CREATE TABLE KhachHang(
	SoChungMinhThu CHAR(20) PRIMARY KEY,
	TenKhachHang NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(30)
);

DROP TABLE KhachHang;

CREATE TABLE ThueBao(
	SoThueBao VARCHAR(20) PRIMARY KEY,
	LoaiThueBao NVARCHAR(20) NOT NULL,
	NgayDangKy DATE NOT NULL CHECK(NgayDangKy <= getDate()),
	SoChungMinhThu CHAR(20) FOREIGN KEY REFERENCES KhachHang(SoChungMinhThu)
);

/* Bai 3 */
INSERT INTO KhachHang(SoChungMinhThu, TenKhachHang, DiaChi) VALUES
('013568465', N'Lã Trọng Nghĩa', N'Hà Nội')

INSERT INTO KhachHang(SoChungMinhThu, TenKhachHang, DiaChi) VALUES
('123456789', N'Nguyễn Nguyệt Nga', N'Hà Nội')

INSERT INTO ThueBao(SoThueBao, LoaiThueBao, NgayDangKy, SoChungMinhThu) VALUES
('0123456789', N'Trả trước', '12-12-02', '123456789')

INSERT INTO ThueBao(SoThueBao, LoaiThueBao, NgayDangKy, SoChungMinhThu) VALUES
('0399308301', N'Trả trước', '2014-03-26', '013568465')

/* Bai 4 */
-- a)
SELECT *
FROM KhachHang;

-- b)
SELECT *
FROM ThueBao;

/* Bai 5 */
-- a)
SELECT tb.SoThueBao, tb.LoaiThueBao, tb.NgayDangKy, tb.SoChungMinhThu
FROM KhachHang kh
JOIN ThueBao tb
	ON kh.SoChungMinhThu = tb.SoChungMinhThu
WHERE SoThueBao = '0123456789';

-- b)
SELECT kh.SoChungMinhThu, kh.TenKhachHang, kh.DiaChi
FROM KhachHang kh
JOIN ThueBao tb
	ON kh.SoChungMinhThu = tb.SoChungMinhThu
WHERE kh.SoChungMinhThu = '123456789';

-- c)
SELECT tb.SoThueBao
FROM ThueBao tb
JOIN KhachHang kh
	ON tb.SoChungMinhThu = kh.SoChungMinhThu
WHERE tb.SoChungMinhThu = '123456789';

-- d)
SELECT SoThueBao
FROM ThueBao
WHERE NgayDangKy = '12-12-09';

-- e)
SELECT tb.SoThueBao, tb.LoaiThueBao, tb.NgayDangKy, tb.SoChungMinhThu
FROM ThueBao tb
JOIN KhachHang kh
	ON tb.SoChungMinhThu = kh.SoChungMinhThu
WHERE kh.DiaChi = N'Hà Nội';

/* Bai 6 */
-- a)
SELECT COUNT(*) AS TongSoKhachHang
FROM KhachHang;

-- b)
SELECT COUNT(*) AS TongSoThueBao
FROM ThueBao;

-- c)
SELECT COUNT(*) AS TongSoThueBao
FROM ThueBao
WHERE NgayDangKy = '12-12-09';

-- d)
SELECT *
FROM ThueBao tb
JOIN KhachHang kh
ON tb.SoChungMinhThu = kh.SoChungMinhThu;

/* Bai 8 */
-- b)
CREATE VIEW View_KhachHang AS
SELECT SoChungMinhThu, TenKhachHang, DiaChi
FROM KhachHang;

CREATE VIEW View_KhachHang_ThueBao AS
SELECT kh.SoChungMinhThu, kh.TenKhachHang, tb.SoThueBao
FROM KhachHang kh
JOIN ThueBao tb
	ON kh.SoChungMinhThu = tb.SoChungMinhThu;







