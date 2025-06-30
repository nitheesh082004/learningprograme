DROP PROCEDURE IF EXISTS sp_GetEmployeeCountByDepartment;

DELIMITER //

CREATE PROCEDURE sp_GetEmployeeCountByDepartment (
    IN p_DepartmentID INT
)
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = p_DepartmentID;
END //

DELIMITER ;


CALL sp_GetEmployeeCountByDepartment(1);
