
--- Я вот не знаю , тут оно работает через раз , и почему я выяснить не смог , скорее всего я гдето допоустил ультра-глупую ошибку ((( ну что поделать
CREATE TRIGGER INSERTTEACHER
ON Teacher
INSTEAD OF INSERT
AS 
BEGIN
 IF (SELECT inserted.CategoryID
   FROM inserted)!=NULL
 BEGIN

   INSERT INTO Teacher(CategoryID,StaffID)
   SELECT inserted.CategoryID,inserted.StaffID
   FROM inserted
 END
ELSE 
BEGIN
    PRINT 'Error:cant Add Teacher without CatagoryID,Check category Table for more information'
END

END

----ТЕСТИМ



INSERT INTO Teacher(StaffID,CategoryID)
VALUES(11,NULL)

select*
from Teacher


