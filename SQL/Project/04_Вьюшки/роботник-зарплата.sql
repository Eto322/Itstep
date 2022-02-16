CREATE VIEW StaffSalary
AS
SELECT (ST.FirstName + ' ' + ST.SecondName) AS 'FULL NAME',
	S.[Value] AS 'SALARY' 
FROM Staff AS ST 
	JOIN Salary AS S 
	 ON S.SalaryID = ST.SalaryID
	-- создали вьюшку для роботник-зарплата

	select*
	from StaffSalary