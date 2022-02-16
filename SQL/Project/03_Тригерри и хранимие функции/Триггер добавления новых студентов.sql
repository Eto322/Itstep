CREATE TRIGGER NWADD
ON Student  
AFTER INSERT  
AS 
BEGIN 
 DECLARE @NWID  INT 
  SET @NWID = (SELECT MAX(StudentID) FROM Student)-- Нашли последний ИД и вставили сюда
   INSERT INTO dbo.NewStudent
	 SELECT*
	 FROM Student
	 WHERE StudentID=@NWID
END

---проверка
select *
from NewStudent



INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(4,'New','Stud','2008-6-6','2018-2-2')

select *
from NewStudent
