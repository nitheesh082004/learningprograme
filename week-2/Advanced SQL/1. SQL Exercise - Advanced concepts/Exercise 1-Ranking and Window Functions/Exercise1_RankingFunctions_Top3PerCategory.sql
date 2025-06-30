CREATE DATABASE OnlineRetailStore;
USE OnlineRetailStore;
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(100),
    Price DECIMAL(10, 2)
);
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1000.00),
(2, 'Phone', 'Electronics', 800.00),
(3, 'Camera', 'Electronics', 800.00),
(4, 'Headphones', 'Electronics', 200.00),
(5, 'Blender', 'Home Kitchen', 150.00),
(6, 'Toaster', 'Home Kitchen', 90.00),
(7, 'Microwave', 'Home Kitchen', 150.00);

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS PriceRank,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRank
    FROM Products
) AS Ranked
WHERE RowNum <= 3;

