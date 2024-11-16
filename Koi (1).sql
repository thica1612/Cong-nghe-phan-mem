USE master
GO

CREATE DATABASE KoiFarm
GO

USE KoiFarm
GO

CREATE TABLE Koi (
    koiID VARCHAR(30) PRIMARY KEY,
    koiName VARCHAR(50),
    koiOrigin VARCHAR(100),
    koiGender VARCHAR(50),
    koiYear INT,
    koiSize INT,
    koiPrice DECIMAL(10, 2),
	stock INT,
	koiImage VARCHAR(100),
	dailyfood DECIMAL(10,2),
	screeningrate DECIMAL(10,2)
);

INSERT INTO Koi (koiID, koiName, koiOrigin, koiGender, koiYear, koiSize, koiPrice, stock, koiImage, dailyfood, screeningrate)
VALUES 
('K001','Showa', 'Dainichi', 'Koi cái', 2020, 70, 650000, 10, '01', 3, 0.5),
('K002','Showa', 'Dainichi', 'Koi cái', 2018, 78, 700000, 5, '02', 5, 0.7),
('K003','Tancho', 'Dainichi', 'Koi cái', 2018, 80, 860000,7, '03', 5, 0.5),
('K004','Kohaku', 'Dainichi', 'Koi cái', 2017, 84, 350000,15, '04', 6, 0.6),
('K005','Kohaku', 'Dainichi', 'Koi cái', 2015, 94, 400000,14, '05', 7, 0.5),
('K006','Tancho', 'Dainichi', 'Koi cái', 2014, 91, 500000,7, '06', 6, 0.5),
('K007','Bekko', 'Dainichi', 'Koi cái', 2017, 86, 950000,6, '07', 5, 0.5),
('K008','Doitsu', 'Otsuka', 'Koi cái', 2016, 77, 600000,18, '08', 4, 0.7),
('K009','Goshiki', 'Oyaji', 'Koi cái', 2018, 67, 540000,20, '09', 3, 0.5);
GO

CREATE TABLE KoiSale (
    koiSaleID VARCHAR(30) PRIMARY KEY,
    koiSaleName VARCHAR(50),
    koiSaleOrigin VARCHAR(100),
    koiSaleGender VARCHAR(50),
    koiSaleYear INT,
    koiSaleSize INT,
    koiSalePrice DECIMAL(10, 2),
	koiSalePriceLater DECIMAL (10,2),
	discountPercent DECIMAL(10,2),
	startDate DATE,
	enddate DATE, 
	stockKoiSale INT,
	koiImageKoiSale VARCHAR(100),
	dailyfoodKoiSale DECIMAL(10,2),
	screeningrateKoiSale DECIMAL(10,2)
);

INSERT INTO KoiSale (koiSaleID, koiSaleName, koiSaleOrigin, koiSaleGender, koiSaleYear, koiSaleSize, koiSalePrice, koiSalePriceLater, discountPercent, startDate, endDate, stockKoiSale, koiImageKoiSale, dailyfoodKoiSale, screeningrateKoiSale)
VALUES 
('KS001', 'Goshiki', 'Dainichi', 'Koi cái', 2018, 72, 600000, 300000, 0.5, '2024-11-10', '2024-11-25', 1, '06', 3, 0.5),
('KS002', 'Showa', 'Dainichi', 'Koi cái', 2017, 80, 700000, 490000, 0.3, '2024-11-10', '2024-11-25', 1, '08', 4, 0.6),
('KS003', 'Tancho', 'Dainichi', 'Koi cái', 2016, 90, 750000, 450000, 0.4, '2024-11-10', '2024-11-25', 1, '02', 6, 0.7),
('KS004', 'Kohaku', 'Dainichi', 'Koi cái', 2019, 76, 900000, 630000, 0.3, '2024-11-10', '2024-11-25', 1, '01', 4, 0.7),
('KS005', 'Doitsu', 'Oyaji', 'Koi cái', 2016, 88, 800000, 640000, 0.2, '2024-11-10', '2024-11-25', 1, '03', 3, 0.7),
('KS006', 'Tancho', 'Dainichi', 'Koi cái', 2014, 91, 600000, 300000, 0.5, '2024-11-10', '2024-11-25', 1, '04', 6, 0.5),
('KS007', 'Bekko', 'Otsuka', 'Koi cái', 2015, 90, 700000, 350000, 0.5, '2024-11-10', '2024-11-25', 1, '07', 7, 0.6),
('KS008', 'Doitsu', 'Oyaji', 'Koi cái', 2017, 75, 900000, 630000, 0.3, '2024-11-10', '2024-11-25', 1, '09', 4, 0.8),
('KS009', 'Goshiki', 'Danichi', 'Koi cái', 2020, 70, 800000, 640000, 0.2, '2024-11-10', '2024-11-25', 1, '02', 3, 0.7);
GO

CREATE TABLE KoiUser (
    userID UNIQUEIDENTIFIER PRIMARY KEY,
    userName VARCHAR(50),
    email VARCHAR(100),
    userPassword VARCHAR(50),
    phonenumber VARCHAR(20),
    userRole VARCHAR(50),
	userAddress	VARCHAR(300),
	pointBalance DECIMAL(10,2),
	dateJoined DATE
);
GO

INSERT INTO KoiUser (userID, userName, email, userPassword, phonenumber, userRole, userAddress, pointBalance, dateJoined)
VALUES
(NEWID(), 'Nguyen Thi Hoa ', 'nthoa@gmail.com', '123456', '0912345678', 'User', 'TP HCM', 25, '2024-01-15'),
(NEWID(), 'Le Van Nam', 'lvnam@gmail.com', 'levannam456', '0987654321', 'User', 'Dong Nai', 12, '2024-02-20'),
(NEWID(), 'Tran Thanh Nam', 'ttnam@gmail.com', 'tranthanhnam', '0909123456', 'User', 'Binh Duong', 14, '2024-03-02'),
(NEWID(), 'Pham Thi Lan', 'ptlan@gmail.com', 'ptlan123', '0912123456', 'User', 'TP HCM', 6, '2024-03-02'),
(NEWID(), 'Hoang Van Quy', 'hvquy@gmail.com', 'quy123', '0923456789', 'User', 'TP HCM', 5, '2024-06-22'),
(NEWID(), 'Nguyen Van Hung', 'nvh@gmail.com', 'nvhung', '0814536237', 'Staff', 'Long An', NULL,'2024-03-25'),
(NEWID(), 'Tran Thi Phuong', 'ttp@gmail.com', '987654', '0914567323', 'Staff', 'Ca Mau', NULL, '2024-02-05'),
(NEWID(), 'Nguyen Anh Huy', 'nahuy@gmail.com', 'nahuy789', '0372345429', 'Manager', 'TP HCM', NULL, '2024-01-01');
GO

CREATE TABLE Certification (
    CertificationID VARCHAR(10) PRIMARY KEY,
    KoiID VARCHAR(30) NOT NULL,
    OriginCertificate VARCHAR(100),
    HealthCertificate VARCHAR(100),
    CertificationDate DATE,
    FOREIGN KEY (KoiID) REFERENCES Koi(koiID)
);
GO

INSERT INTO Certification (CertificationID, KoiID, OriginCertificate, HealthCertificate, CertificationDate) VALUES
    ('CK01', 'K001', 'Japan Origin Cert #001', 'Health Cert #A01', '2023-10-01'),
    ('CK02', 'K002', 'Japan Origin Cert #002', 'Health Cert #A02', '2023-08-15'),
    ('CK03', 'K003', 'Japan Origin Cert #003', 'Health Cert #A03', '2022-09-20'),
	('CK04', 'K004', 'Japan Origin Cert #004', 'Health Cert #A04', '2023-11-10'),
	('CK05', 'K005', 'Japan Origin Cert #005', 'Health Cert #A05', '2021-10-10'),
    ('CK06', 'K006', 'Japan Origin Cert #006', 'Health Cert #A06', '2023-05-12'),
    ('CK07', 'K007', 'Japan Origin Cert #007', 'Health Cert #A07', '2020-12-15'),
    ('CK08', 'K008', 'Japan Origin Cert #008', 'Health Cert #A08', '2022-08-20'),
    ('CK09', 'K009', 'Japan Origin Cert #009', 'Health Cert #A09', '2022-07-07');
GO

CREATE TABLE CertificationKoiSale (
    CertificationKSID VARCHAR(10) PRIMARY KEY,
    KoiSaleID VARCHAR(30) NOT NULL,
    OriginCertificateKS VARCHAR(100),
    HealthCertificateKS VARCHAR(100),
    CertificationDateKS DATE,
    FOREIGN KEY (KoiSaleID) REFERENCES KoiSale(koiSaleID)
);
GO

INSERT INTO CertificationKoiSale(CertificationKSID, KoiSaleID, OriginCertificateKS, HealthCertificateKS, CertificationDateKS) VALUES
    ('CKS01', 'KS001', 'Japan Origin Cert #110', 'Health Cert #B10', '2023-10-01'),
    ('CKS02', 'KS002', 'Japan Origin Cert #111', 'Health Cert #B11', '2023-08-15'),
    ('CKS03', 'KS003', 'Japan Origin Cert #112', 'Health Cert #B12', '2022-09-20'),
    ('CKS04', 'KS004', 'Japan Origin Cert #113', 'Health Cert #B13', '2023-11-10'),
    ('CKS05', 'KS005', 'Japan Origin Cert #114', 'Health Cert #B14', '2021-10-10'),
    ('CKS06', 'KS006', 'Japan Origin Cert #115', 'Health Cert #B15', '2023-05-12'),
    ('CKS07', 'KS007', 'Japan Origin Cert #116', 'Health Cert #B16', '2020-12-15'),
    ('CKS08', 'KS008', 'Japan Origin Cert #117', 'Health Cert #B17', '2022-08-20'),
    ('CKS09', 'KS009', 'Japan Origin Cert #118', 'Health Cert #B18', '2022-07-07');
GO
-----------------------------------------------------------
-- Bảng Order lưu thông tin về đơn hàng của khách hàng
CREATE TABLE KoiOrder (
    OrderID INT PRIMARY KEY,
    CustomerID UNIQUEIDENTIFIER NOT NULL,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    Status VARCHAR(20),
    FOREIGN KEY (CustomerID) REFERENCES KoiUser(userID)
);
GO

INSERT INTO KoiOrder (OrderID, CustomerID, OrderDate, TotalAmount, Status) VALUES
    (1, 'f7f7fe75-0e21-4b9f-9442-0bcf49a9b0ad', '2024-01-15', 1350000.00, 'Completed'),
    (2, 'a90c8168-eade-42d0-8bd4-f4fda98967a0', '2024-02-20', 1210000.00, 'Completed'),
    (3, 'ff398fd9-c5a7-4fea-a360-5ceffa6f4342', '2024-03-05', 1250000.00, 'Completed'),
	(4, '60872786-f0bd-455d-bd27-a1b845e5f564', '2024-03-02', 1450000.00, 'Completed'),
	(5, 'ca9a11d1-2199-48a5-ba90-ce826225ca5f', '2024-05-27', 600000.00, 'Completed'),
	(6, '763fa906-e5fd-468f-bed3-f1019c439df4', '2024-06-22', 540000.00, 'Completed');
GO

-- Bảng OrderDetail lưu chi tiết từng sản phẩm trong một đơn hàng
CREATE TABLE OrderDetail (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT NOT NULL,
    KoiID VARCHAR(30) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES KoiOrder(OrderID),
    FOREIGN KEY (KoiID) REFERENCES Koi(koiID)
);
GO

INSERT INTO OrderDetail (OrderDetailID, OrderID, KoiID, Quantity, UnitPrice)
VALUES
    (1, 1, 'K001', 1, 650000),
    (2, 2, 'K002', 1, 700000),
    (3, 3, 'K003', 1, 860000),
    (4, 4, 'K004', 2, 350000),
    (5, 4, 'K005', 1, 400000),
    (6, 5, 'K006', 2, 500000),
    (7, 5, 'K007', 1, 950000),
    (8, 6, 'K008', 1, 600000),
    (9, 6, 'K009', 1, 540000);
GO

-- Tạo bảng Consignment: Thông tin về các giao dịch ký gửi của khách hàng
CREATE TABLE Consignment (
    ConsignmentID INT PRIMARY KEY,
    ConsignmentType VARCHAR(10),  -- 'Offline' hoặc 'Online'
    RequestDate DATE,
    AgreedPrice DECIMAL(10, 2),
    ConsignmentStatus VARCHAR(10), -- 'Pending', 'Approved', hoặc 'Completed'
);
GO

INSERT INTO Consignment (ConsignmentID, ConsignmentType, RequestDate, AgreedPrice, ConsignmentStatus) VALUES
    (1, 'Online', '2024-09-15', 750000, 'Pending'),
    (2, 'Offline', '2024-10-05', 850000, 'Approved'),
    (3, 'Online', '2024-11-01', 900000, 'Pending'),
    (4, 'Offline', '2024-08-20', 680000, 'Completed'),
    (5, 'Online', '2024-07-15', 720000, 'Completed'),
    (6, 'Offline', '2024-10-10', 620000, 'Approved'),
    (7, 'Online', '2024-09-25', 500000, 'Pending'),
    (8, 'Offline', '2024-08-30', 790000, 'Completed'),
    (9, 'Online', '2024-10-22', 880000, 'Approved');
GO

-- Tạo bảng Feedback
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY,
    CustomerID UNIQUEIDENTIFIER NOT NULL,
    KoiID VARCHAR(30) NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comments TEXT,
    FeedbackDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES KoiUser(userID),
    FOREIGN KEY (KoiID) REFERENCES Koi(koiID)
);
GO

INSERT INTO Feedback (FeedbackID, CustomerID, KoiID, Rating, Comments, FeedbackDate) VALUES
    (1, '763fa906-e5fd-468f-bed3-f1019c439df4', 'K001', 5, 'Great fish, very healthy!', '2024-09-12'),
    (2, 'ca9a11d1-2199-48a5-ba90-ce826225ca5f', 'K002', 4, 'Beautiful Koi but a bit pricey.', '2024-08-15'),
    (3, 'ea53ba2f-7bfb-4e47-85b1-e7ef2b8c8f49', 'K003', 5, 'Very satisfied with the quality!', '2024-07-25'),
    (4, 'a90c8168-eade-42d0-8bd4-f4fda98967a0', 'K004', 3, 'Fish was nice but smaller than expected.', '2024-06-18'),
    (5, 'ff398fd9-c5a7-4fea-a360-5ceffa6f4342', 'K005', 4, 'Good fish, decent service.', '2024-05-10');
GO

-- Tạo bảng Promotion
CREATE TABLE Promotion (
    PromotionID INT PRIMARY KEY,
    PromotionName VARCHAR(100),
    DiscountPercentage DECIMAL(5, 2),
    StartDate DATE,
    EndDate DATE
);
GO

INSERT INTO Promotion (PromotionID, PromotionName, DiscountPercentage, StartDate, EndDate) VALUES
    (1, 'Spring Sale', 10.00, '2024-03-01', '2024-03-31'),
    (2, 'Summer Special', 15.00, '2024-06-01', '2024-06-30'),
    (3, 'Fall Discounts', 20.00, '2024-09-01', '2024-09-30'),
    (4, 'Winter Fest', 25.00, '2024-12-01', '2024-12-31');
GO

-- Tạo bảng TransactionHistory: Lịch sử giao dịch của người dùng (gửi tiền, mua hàng, hoàn trả,...)
CREATE TABLE TransactionHistory (
    TransactionID INT PRIMARY KEY,
    CustomerID UNIQUEIDENTIFIER NOT NULL,
    TransactionDate DATE,
    TransactionType VARCHAR(20), -- 'Purchase', 'Consignment', hoặc 'Deposit'
    Amount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES KoiUser(userID)
);
GO

INSERT INTO TransactionHistory (TransactionID, CustomerID, TransactionDate, TransactionType, Amount) VALUES
    (1, '8bcf45e1-1fbe-4fd9-99fb-467e142181ef', '2024-01-15', 'Purchase', 1500000.00),
    (2, '2d880348-f135-490d-bf2d-78afe5de2e5c', '2024-02-20', 'Purchase', 2000000.00),
    (3, 'a90c8168-eade-42d0-8bd4-f4fda98967a0', '2024-03-05', 'Purchase', 1800000.00),
    (4, '9e1bd26f-c2ad-4639-9e22-b6d29069f701', '2024-05-27', 'Consignment', 3000000.00),
    (5, '420e8ee0-330a-491f-896e-de527e818039', '2024-06-22', 'Deposit', 1000000.00);
GO

-- Tạo bảng DashboardData
CREATE TABLE DashboardData (
    ReportID INT PRIMARY KEY,
    MetricName VARCHAR(100),
    MetricValue DECIMAL(15, 2),
    ReportDate DATE
);
GO

INSERT INTO DashboardData (ReportID, MetricName, MetricValue, ReportDate) VALUES
    (1, 'Total Sales', 50000000.00, '2024-10-31'),
    (2, 'Number of Orders', 150, '2024-10-31'),
    (3, 'Active Promotions', 4, '2024-10-31'),
    (4, 'Total Consignments', 20, '2024-10-31'),
    (5, 'New Customers', 30, '2024-10-31');
GO
