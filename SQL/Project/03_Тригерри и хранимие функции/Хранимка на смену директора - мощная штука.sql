CREATE PROC ChangeDirector 
           @NWDirectorID int
AS 
BEGIN

IF (SELECT PositionID
       FROM Staff
	   WHERE StaffID=@NWDirectorID
	   )!=3
  BEGIN   
	   PRINT 'ERROR: SELECTED MEMBER NOT TEACHER'
	   RETURN(-1)
  END
ELSE
Declare @oldDirectorID int--если мы меняем директора то , старый директор становиться учитилем и становиться на временую замену предметов которые вел новый директор
Declare @oldDirectorTeacherID int
Declare @newDirectorTeacherID int
DECLARE @OldSalary int
Declare @NewSalary int -- для изменения зарплаты
BEGIN
  SET  @oldDirectorID =--Нашли ид роботника директора старого
  (SELECT StaffID
   FROM Staff
   WHERE PositionID=1)

    SET @oldDirectorTeacherID=--Нашли тичер айди старого директора
    (SELECT TeacherID
     FROM Teacher
	 WHERE StaffID=@oldDirectorID)

	 SET @newDirectorTeacherID=--нашли ид роботника нового директора
	 (SELECT TeacherID
	  FROM Teacher
	  WHERE StaffID=@NWDirectorID)

	  UPDATE TeacherSubject --поменяли предметы которые вел новый на старого директора
	   SET TeacherID=@oldDirectorTeacherID
	    WHERE TeacherID=@newDirectorTeacherID


	   UPDATE ClassroomTeacher --- поменяли классы если такие были
	    SET TeacherID=@oldDirectorTeacherID
	     WHERE TeacherID=@newDirectorTeacherID

   --МЕНЯЕМ ЗАРПЛАТЫ
	    SET @OldSalary=
		  (SELECT SalaryID
			 FROM Staff
			  WHERE PositionID=1)

		 SET @NewSalary=
		  (SELECT SalaryID
		    FROM Staff
			 WHERE StaffID=@NWDirectorID)

	       UPDATE Staff
	        SET SalaryID=@OldSalary-- 
	         WHERE StaffID=@NWDirectorID

	         UPDATE Staff
	          SET SalaryID=@NewSalary
	           WHERE PositionID=1;

                 UPDATE Staff --понизили старого директора до учителя
                   SET PositionID=3
                    WHERE PositionID=1;

                    UPDATE Staff--повысили 
                     SET PositionID=1
                      WHERE StaffID=@NWDirectorID
   RETURN(1)
   END
END


---Тестим
select*
from staff
WHERE StaffID=1 OR StaffID=5

SELECT ST.StaffID,ST.PositionID,SA.SalaryID,SA.Value,TECS.SubjectID,SUB.Name
FROM STAFF AS ST
JOIN Salary AS SA ON SA.SalaryID=ST.SalaryID
JOIN StaffPosition AS STP ON STP.PositionID=ST.PositionID
JOIN Teacher AS TEC ON TEC.StaffID=ST.StaffID
JOIN TeacherSubject AS TECS ON TECS.TeacherID=TEC.TeacherID
JOIN [Subject] AS SUB ON SUB.SubjectID=TECS.SubjectID
JOIN ClassroomTeacher AS CST ON CST.TeacherID=TEC.TeacherID
WHERE ST.StaffID=1 OR ST.StaffID=4




 EXEC ChangeDirector 10--ОШИБКА не являеться учителем 

 EXEC ChangeDirector 4--все ок


