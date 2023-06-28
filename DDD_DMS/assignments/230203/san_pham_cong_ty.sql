/* Bai 1 + Bai 2 */
CREATE TABLE Hang(
	MaSoHang INT PRIMARY KEY,
	TenHang CHAR(50) NOT NULL,
	DiaChi CHAR(10) NOT NULL,
	DienThoai CHAR(20) NOT NULL UNIQUE
);

CREATE TABLE SanPham(
	MaSoSanPham INT PRIMARY KEY,
	TenSanPham NVARCHAR(50) NOT NULL UNIQUE,
	MaSoHang INT FOREIGN KEY REFERENCES Hang(MaSoHang),
	MoTaSanPham NVARCHAR(100) NOT NULL,
	DonVi NVARCHAR(20) NOT NULL DEFAULT N'Chiếc',
	Gia MONEY NOT NULL,
	SoLuongHienCo INT NOT NULL CHECK(SoLuongHienCo >= 0)
);

/* Bai 3 */
INSERT INTO Hang(MaSoHang, TenHang, DiaChi, DienThoai) VALUES
(123, 'Asus', 'USA', '983232'),
(456, 'Nokia', 'FIN', '324233'),
(789, 'Samsung', 'KR', '434342');

INSERT INTO SanPham(MaSoSanPham, TenSanPham, MaSoHang, MoTaSanPham, Gia, SoLuongHienCo) VALUES
(1, N'Máy tính T450', 123, N'Máy nhập cũ', 1000, 10),
(2, N'Điện thoại Nokia 5670', 456, N'Điện thoại đang hot', 200, 200),
(3, N'Máy in Samsung 450', 789, N'Máy in đang loại bình', 100, 10);

/* Bai 4 */
-- a)
SELECT *
FROM Hang;

-- b)
SELECT *
FROM SanPham;

/* Bai 5 */
-- a) 
SELECT *
FROM Hang
ORDER BY TenHang DESC;

-- b)
SELECT *
FROM SanPham
ORDER BY Gia DESC;

-- c)
SELECT *
FROM Hang
WHERE TenHang = 'Asus';

-- d)
SELECT *
FROM SanPham
WHERE SoLuongHienCo < 11;

-- e)
SELECT *
FROM SanPham
WHERE MaSoHang = (
	SELECT MaSoHang
	FROM Hang
	WHERE TenHang = 'Asus'
);

/* Bai 6 */
-- a)
SELECT COUNT(*) AS TongSoHang
FROM Hang;

-- b)
SELECT COUNT(*) AS TongSoSanPham
FROM SanPham;

-- c)
SELECT msh.MaSoHang, msh.TongSoLoaiSanPham, h.TenHang
FROM (SELECT MaSoHang, COUNT(TenSanPham) AS TongSoLoaiSanPham
FROM SanPham
GROUP BY MaSoHang) AS msh
JOIN Hang h
	ON msh.MaSoHang = h.MaSoHang;

-- d)
SELECT SUM(SoLuongHienCo) AS TongSoDauSanPham
FROM SanPham;