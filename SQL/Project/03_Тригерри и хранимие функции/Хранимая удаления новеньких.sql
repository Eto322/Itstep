-- удаления новеньких
CREATE PROC DeleteNewStudent
AS 
BEGIN
  DELETE FROM NewStudent
  WHERE StartDate < DATEADD(MONTH, -3, GETDATE())--прикольную функцию нашел, с помощью нее можно нормально отнять месяца
END


----проверка
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
 values(4,'NOT','OLD','2008-6-6',GETDATE())

INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
 values(4,'OLD','OLD','2008-6-6','1999-2-2')

SELECT*
FROM NewStudent

EXECUTE DeleteNewStudent

SELECT*
FROM NewStudent
