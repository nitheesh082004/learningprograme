DELIMITER //

CREATE PROCEDURE sp_InsertEmployeeWithID (
    IN p_EmployeeID INT,
    IN p_FirstName VARCHAR(50),
    IN p_LastName VARCHAR(50),
    IN p_DepartmentID INT,
    IN p_Salary DECIMAL(10,2),
    IN p_JoinDate DATE
)
BEGIN
    INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (p_EmployeeID, p_FirstName, p_LastName, p_DepartmentID, p_Salary, p_JoinDate);
END //

DELIMITER ;
