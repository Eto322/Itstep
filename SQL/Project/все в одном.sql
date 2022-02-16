CREATE DATABASE SchoolProject
-- перед роботой хотел бы укзать , что я пытался не пользлваться нуллами если я не могу это как-то обойти(пример таблица  CLASS)
--у меня была такая логика что в зависимости от того на каком языке и как написан бекенд у нас может случиться проблема что на бек может
--прийти нулл там где его не ожидали ,и в итоге мы можем столкнуться с серьезними проблемами при роботе ,
-- тут есть два варианта или переписивать или вводить изменения в бекенд  ( что может повлиять за собой изменения всей логики программы--хотя я может и преувеличиваю ) 
-- или просто при дизайне бд не использовать НУЛЛ
-- Для демонстрации работы с нулами я использовал таблицу (Mark-тут лучше  или Specialization-- тут постольку по сколько ) где привел обоснования почему я считаю что там их надо использовать.
------------------------------------------------------------------------------Создания БД--------------------------------------------------------------------------------------------------------------------

CREATE TABLE Salary--таблица для зарпалаты, храним ИД зарплаты и саму сумму зарплаты.
--каждое значения не может быть НУЛЛ
(
	SalaryID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Value] INT NOT NULL

)

CREATE TABLE StaffPosition-- здесь мы храним Позиции наших роботников (зауч,директор  много робочий, учитель) 
--каждое значения не может быть НУЛЛ
( 
	PositionID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY, 
	[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Staff-- храним информацию о роботнике 
-- Salary уникальная поскольку я решил что для каждого работника должна быть своя ИД зарплаты,(уже не уникальная, потомучто она мешает роботе моего триггера для смены директора, и я витоге не могу нормально 
--поменять зарплату)
--каждое значения не может быть НУЛЛ
(
	StaffID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	SalaryID INT NOT NULL  FOREIGN KEY REFERENCES Salary(SalaryID), 
	PositionID INT  NOT NULL  FOREIGN KEY REFERENCES StaffPosition(PositionID), --ключ чтоб получить позицию
	FirstName NVARCHAR(100) NOT NULL, 
	SecondName NVARCHAR(100) NOT NULL, 
	BirthDate DATE NOT NULL, 
	StartWorkDate DATE NOT NULL

)
-- храним категории учителей
--каждое значения не может быть НУЛЛ
CREATE TABLE Category
(
	CategoryID INT NOT NULL IDENTITY(1,1) PRIMARY KEY , 
	[Name] NVARCHAR(100) NOT NULL UNIQUE--уникальная поскольку у нас только несколько категорий , и они не должны повторяться

)



-- таблица для учителей , состоит только из ключей, поскольку категория , вынесена в отдельную таблицу , имя, фамилия и.тд уже хранятася в таблице staff и здесь их хранить тоже не имеет смысла
-- поскольку они не имеют ни какого отношению к учиелю, учитель и какой он предмет он ведет тоже вынесены в отельную таблицу поскольку один учитель может вестни несколько предметов и наоборот , и соотвественно 
-- записивать их сюда было б нарушениям 3 норм формы, поскольку у нас бы дуюлировались записми учителей для каждого предмета

--каждое значения не может быть НУЛЛ
CREATE TABLE Teacher
(	TeacherID INT NOT NULL  IDENTITY(1,1) PRIMARY KEY ,
	StaffID INT NOT NULL UNIQUE FOREIGN KEY REFERENCES Staff(StaffID), --ключ для получения сведения о учители ( в таблице Staff)
	CategoryID INT NOT NULL  FOREIGN KEY REFERENCES Category(CategoryID) -- ключ для получения категории нашего учителя
)




--таблица для хранения прдемета который преподает преподаватель
--каждое значения не может быть НУЛЛ
CREATE TABLE [Subject]
(
	SubjectID INT NOT NULL IDENTITY(1,1) PRIMARY KEY , 
	[Name] NVARCHAR(100) NOT NULL UNIQUE,--Уникальный поскольку предметы не могут повторяться
)

--составная таблица, для получения предмета-учителя, надобность описал при создании таблици учителя. 
--каждое значения не может быть НУЛЛ
CREATE TABLE TeacherSubject
( 
	TeacherID INT NOT NULL  FOREIGN KEY REFERENCES Teacher(TeacherID),
	SubjectID INT NOT NULL  FOREIGN KEY REFERENCES [Subject](SubjectID),--ключ для предмета учителя
	
	
)

-- таблица со спецеализациями, короткое описания нулом быть не может , полное может , проблему с нуллом в полным можно было б решить с помощью пустой строки
-- исходя из моей логики пустая строка которая приходит на бек хуже чем нулл , поскольку при нуле он может сразу крашнуться , при пустой строке продолжить роботу,что как я подумал может обернуться проблемой 
-- в будущем
-- хотя я считаю что тут использования нулла или пустой строки не приципиально.Можно было б даже застваить всегда писать полное описания , но в этом может и не быть смыслаэ

--каждое значения кроме FullDescription  не может быть НУЛЛ
CREATE TABLE Specialization
( 
	SpecializationID INT NOT NULL IDENTITY(1,1) PRIMARY KEY , 
	[Description]  NVARCHAR(50)  NOT NULL  UNIQUE, 
	FullDescription NVARCHAR(MAX) NULL -- может быть нулом
)

-- Таблица класса, имеет номер и букву которые ограничине, также имеет SpecializationID для того чтоб определить спецеализацию класса 
-- У меня была логика , что если у всех классов должна быть спецеализация, и поэтому SpecializationID не может быть нулом, при другой логике , его можно сделать нуллом или добавить в таблицу ид спецеализаций 
-- поле которе будет писать что спецеализации нет (так и сделал, проблему с нулл значениями описал в начале роботы)
--каждое значения не может быть НУЛЛ
CREATE TABLE CLASS
(	
	ClassID INT NOT NULL IDENTITY(1,1) PRIMARY KEY , 
	SpecializationID INT NOT NULL FOREIGN KEY REFERENCES Specialization(SpecializationID), 
	ClassNumber INT NOT NULL,-- Номер класса может находиться в пределах от 1 до 11 
	ClasLetter NVARCHAR(1) NOT NULL, -- буква класса , только буква англ алфавита А-Z
	CHECK(ClassNumber BETWEEN 1 and 11   AND ClasLetter NOT LIKE '%[^A-Z]%')
)

-- таблица для студентов , имеет внешний ключ ClassID для доступа к классу студента
--каждое значения не может быть НУЛЛ
CREATE TABLE Student
(
	StudentID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	ClassID INT NOT NULL FOREIGN KEY REFERENCES Class(ClassID) , --ключ для доступа к студентам 
	FirstName NVARCHAR(100) NOT NULL, 
	SecondName NVARCHAR(100) NOT NULL, 
	BirthDate DATE NOT NULL, 
	StartDate DATE NOT NULL 


)

-- в таблице храниться информации о учитель-класс в которм он класный руководитель
-- сделал такую таблицу , поскольку в задание говориться что у класса один класный руководитель, а сколько у учителя может быть классов где он классный руководитель не указано
-- у меня в школе было что у  учителя могло быть несколько классов, поэтому я придерживался такой логике
--каждое значения не может быть НУЛЛ
CREATE TABLE ClassroomTeacher
(
	TeacherID INT NOT NULL FOREIGN KEY REFERENCES Teacher(TeacherID),--доступ к учителю
	ClassID INT NOT NULL FOREIGN KEY REFERENCES Class(ClassID) --ид класса где учитель руководитель
)

-- таблица в которой мы храним оценки
-- сама Мark может быть нулом ,поскольку у меня была логика , что в школе может проводиться условный директорский контроль , где все должны получить оценку, но студент не появился на нем.
-- Суть лежит в том что директору надо узнать средний бал по контролю , но если мы студенту за отсутсвия бы ставили 0 или 1 , то это бы влияло на средний бал при подсчете , хотя студент не писал саму роботу
-- поэтому если такой случай будет , мы можем легко поставить ему нулл что значит оценки нету.

--каждое значения кроме Mark не может быть НУЛЛ
CREATE TABLE Mark
(	
	MarkID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	MarkDate DATE NOT NULL,
	[Value] INT NULL
	CHECK([VALUE] BETWEEN 1 AND 12)-- Поверяем что оценка в пределах от 1 до 12 
	
)





--таблица в которай мы храним ИД студента который получил оценку , ИД предмета по которм он получил оценку , ИД самой оценки 
-- сделал в таком виде , поскольку руководствовался логикой что у нас может быть так что студент получит две или больше одинаковых оценок на одном занятии , и тогда мы можем получить то что у нас
--будет подряд идти несколько одинаковых записей.Что по сути правильно но выглядит не разборчливо , с помощью такой таблици мы отслеживаем ИД самой оценки и поэтому можем проследить что на самом деле
-- запись была уникальной

-- Я подумывал прям в эту табличку добавить нашу оценку , но пришел к выводу что это будет не удобно при роботе.Допустим мы хотим посчитать среднее значения всех оценок за определеный срок, 
--мы конечно сможем написать этот запрос , но по мне зачем нам думать о том что в таблички есть лишняя информация , если мы можем обратиться к другой табличке в которой ее соотвсественно нет

-- возможно такое мышления , может аукнуться определеными проблема где нам надо будет джойнить эту табличуку к табличке Мark чтоб допустим получить все оценки для одного студента , поскольку 
--в таблице Mark этой информации нет.Хотя мы всегда можем создать вьюшку с этим и не париться ни по одной из проблем
-- я в итоге сошелся на таком варианте

--каждое значения не может быть НУЛЛ
CREATE TABLE MarkSubjectStudent
(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Student(StudentID), 
	SubjectID INT NOT NULL FOREIGN KEY REFERENCES [Subject](SubjectID), 
	MarkID INT NOT NULL FOREIGN KEY REFERENCES Mark(MarkID), 
	 
)

--таблица для хранения новых студентов
CREATE TABLE NewStudent
( 
	
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Student(StudentID),
	ClassID INT NOT NULL FOREIGN KEY REFERENCES Class(ClassID) , --ключ для доступа к студентам 
	FirstName NVARCHAR(100) NOT NULL, 
	SecondName NVARCHAR(100) NOT NULL, 
	BirthDate DATE NOT NULL, 
	StartDate DATE NOT NULL 

)


-----------------------------------------------------------------------------------Заполняем БД----------------------------------------------------------------------------------------------------------------

--заполняем Спецеаллизацию наших классов (1-спецеализация отсутствует(если такая формулировка плохая, то можно просто назвать многонаправленая),2-Математика, 3-Английский)
INSERT INTO Specialization(Description)
VALUES ('Absent')

INSERT INTO Specialization(Description,FullDescription)
VALUES ('Mathematic','More time to study math')


INSERT INTO Specialization(Description,FullDescription)
VALUES ('English','More time to study English')

select*
from Specialization

--заполняем таблицк классов (2-класса с многонаправленой спецеализацией,1-математика,3-Английский)
INSERT INTO CLASS(SpecializationID,ClasLetter,ClassNumber)
VALUES(1,'A',11)

INSERT INTO CLASS(SpecializationID,ClasLetter,ClassNumber)
VALUES(1,'B',10)

INSERT INTO CLASS(SpecializationID,ClasLetter,ClassNumber)
VALUES(2,'C',8)


INSERT INTO CLASS(SpecializationID,ClasLetter,ClassNumber)
VALUES(3,'Z',9)

SELECT*
FROM CLASS

--добавим студентов (тут тригер пока не работает, чтоб заработал надо сначало его создать)
-- замечу , с датами не очень парился


--class 1
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(1,'Avril','Lavigne','2000-2-2','2005-5-6')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(1,'Thom','Yorke','2000-12-5','2005-5-9')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(1,'Jonny','Greenwood','2000-4-2','2005-7-8')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(1,'Colin','Greenwood','2000-8-6','2005-1-3')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(1,'Ed','OBrien','2000-4-5','2006-5-6')

select*
from Student
where ClassID=1

--class 2
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(2,'James ','Collins','2003-2-2','2007-5-6')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(2,'John','Helps','2003-12-5','2007-5-9')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(2,'Robin','Southby','2003-4-2','2007-7-8')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(2,'Jamie','Ward','2003-8-6','2007-1-3')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(2,'Matthew','Daly','2003-4-5','2008-5-6')

select*
from Student
where ClassID=2

--class 3
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(3,'Yegor','Letov','2004-5-5','2015-2-2')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(3,'Zemfira','Talgatovna','2004-12-5','2016-5-9')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(3,'Yuri',' Shevchuck','2003-4-2','2017-7-8')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(3,'Dmitri','Kuznecov','2003-8-6','2016-1-3')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(3,'Daria','Shihanova','2003-4-5','2015-5-6')

select*
from Student
where ClassID=3

--class 4
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(4,'Natasha','Ćmiel','2008-6-6','2018-2-2')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(4,'Lana','Rey','2008-12-5','2019-5-9')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(4,'Ville','Valo','2009-4-2','2018-7-8')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(4,'Lemmy','Kilmister','2008-8-6','2019-1-3')
INSERT INTO Student(ClassID,FirstName,SecondName,BirthDate,StartDate)
values(4,'Ruslana','Lijichko','2009-4-5','2018-5-6')

select*
from Student
where ClassID=4

select*
from Student

---заполним позиции наших роботнико (1- директор 2-зауч 3-учитель 4-разноробочий)

INSERT INTO StaffPosition([Name])
VALUES('Director')

INSERT INTO StaffPosition([Name])
VALUES('HeadTeacher')

INSERT INTO StaffPosition([Name])
VALUES('Teacher')

INSERT INTO StaffPosition([Name])
VALUES('Worker')

select*
from StaffPosition

--- заполним наши зарплаты (всего 10 , 1-директора ,2-3 - заучи 4-8-учителя,9-10 -разноробочие)

INSERT INTO Salary([Value])
VALUES (10000)

INSERT INTO Salary([Value])
VALUES (5252)

INSERT INTO Salary([Value])
VALUES (5522)

INSERT INTO Salary([Value])
VALUES (4444)

INSERT INTO Salary([Value])
VALUES (4555)

INSERT INTO Salary([Value])
VALUES (4321)

INSERT INTO Salary([Value])
VALUES (4222)

INSERT INTO Salary([Value])
VALUES (4677)

INSERT INTO Salary([Value])
VALUES (3900)

INSERT INTO Salary([Value])
VALUES (3800)

SELECT*
FROM Salary

---заполним наших работников
--директор
INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(1,1,'Kar','Karich','1999-2-3','2010-2-3')

--заучи
INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(2,2,'Sovunja','Sovushka','2010-2-3','2010-1-3')


INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(3,2,'Barash','Barashkovich','1994-2-3','2010-2-3')

--учителя
INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(4,3,'Yejik','Tymane','2003-2-3','2010-3-3')


INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(5,3,'Pin','Kod','2004-2-3','2010-4-3')


INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(6,3,'Krosh','Rabbit','1999-5-7','2010-5-3')


INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(7,3,'Kopatich','Kopaet','1999-5-8','2010-6-3')


INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(8,3,'Nusha','Nesvin','1999-3-2','2010-7-3')

--разно робочие
INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(9,4,'Losyah','Loskovich','1999-2-3','2010-8-3')


INSERT INTO Staff(SalaryID,PositionID,FirstName,SecondName,BirthDate,StartWorkDate)
VALUES(10,4,'AT','Vinta','1999-2-3','2010-8-4')

select*
from Staff

---Заполним Катаегории для учителей(1-вторая категория, 2-первая категория,3-высшая)
INSERT INTO Category([Name])
VALUES ('Second')

INSERT INTO Category([Name])
VALUES ('First')

INSERT INTO Category([Name])
VALUES ('High')

select*
from Category

---заполним наших учитилей (2-первой категории, 2-второй категории ,1-высшей, 1- высшей который еще при этом и директор)
select*
from Staff

INSERT INTO Teacher(StaffID,CategoryID)
VALUES (4,1)

INSERT INTO Teacher(StaffID,CategoryID)
VALUES (5,1)

INSERT INTO Teacher(StaffID,CategoryID)
VALUES (6,2)

INSERT INTO Teacher(StaffID,CategoryID)
VALUES (7,2)

INSERT INTO Teacher(StaffID,CategoryID)
VALUES (8,3)

INSERT INTO Teacher(StaffID,CategoryID)--директор
VALUES (1,1)

select*
from Teacher

---дадим учителям класс за который они отвечают(учитель под Ид 1 отвечает сразу за 1 и 2 класс, 2-за 3, 3-за 4, остальные не клас руководители)
Insert Into ClassroomTeacher(TeacherID,ClassID)
VALUES(1,1)
Insert Into ClassroomTeacher(TeacherID,ClassID)
VALUES(1,2)
Insert Into ClassroomTeacher(TeacherID,ClassID)
VALUES(2,3)
Insert Into ClassroomTeacher(TeacherID,ClassID)
VALUES(3,4)

SELECT*
FROM ClassroomTeacher



--- заполним предметы которые есть у нас в школе (1-математика , 2-англиский,3-биология,4-химия,5-Физика,6-Литература)
INSERT INTO [Subject]([Name])
VALUES ('Mathematic')

INSERT INTO [Subject]([Name])
VALUES ('English')

INSERT INTO [Subject]([Name])
VALUES ('Biology')

INSERT INTO [Subject]([Name])
VALUES ('Chemical')

INSERT INTO [Subject]([Name])
VALUES ('Physic')

INSERT INTO [Subject]([Name])
VALUES ('Literature')

SELECT*
FROM [Subject]--Ни понял почему но они как то не по очереди сюда залетели 


--Теперь присвоим учителям по предметам (1-Математика и физика, 2-биология и химия,3-Английский,4-Математика,5-Литература)

INSERT INTO TeacherSubject(TeacherID,SubjectID)
VALUES(1,1)
INSERT INTO TeacherSubject(TeacherID,SubjectID)
VALUES(1,5)
INSERT INTO TeacherSubject(TeacherID,SubjectID)
VALUES(2,3)
INSERT INTO TeacherSubject(TeacherID,SubjectID)
VALUES(2,4)

INSERT INTO TeacherSubject(TeacherID,SubjectID)
VALUES(3,2)
INSERT INTO TeacherSubject(TeacherID,SubjectID)
VALUES(4,1)
INSERT INTO TeacherSubject(TeacherID,SubjectID)
VALUES(5,6)



SELECT*
FROM TeacherSubject

---Теперь заполним несколько оценок(1-оценку оставил нулом для наглядности, 2-6,3-4,4-10,5-10)
INSERT INTO Mark([Value],MarkDate)
Values(NULL,'2020-03-04')

INSERT INTO Mark([Value],MarkDate)
Values(6,'2020-03-04')

INSERT INTO Mark([Value],MarkDate)
Values(4,'2020-03-04')

INSERT INTO Mark([Value],MarkDate)
Values(10,'2020-03-04')

INSERT INTO Mark([Value],MarkDate)
Values(10,'2020-03-04')

SELECT*
FROM Mark

--и напоследок раздадим эти оценки людям из класса 1 (1-нулл (отсутвовала) 2-2,3-3,4-4,5-5, ПО предмету математика 1)

SELECT*
FROM STUDENT
WHERE ClassID=1

INSERT INTO MarkSubjectStudent(StudentID,SubjectID,MarkID)
VALUES(1,1,1)

INSERT INTO MarkSubjectStudent(StudentID,SubjectID,MarkID)
VALUES(2,1,2)

INSERT INTO MarkSubjectStudent(StudentID,SubjectID,MarkID)
VALUES(3,1,3)

INSERT INTO MarkSubjectStudent(StudentID,SubjectID,MarkID)
VALUES(4,1,4)

INSERT INTO MarkSubjectStudent(StudentID,SubjectID,MarkID)
VALUES(5,1,5)

SELECT*
FROM MarkSubjectStudent

----------------------------------------------------------------------------------------3 Триггери и хранимки-------------------------------------------------------------------------------------------------------------------------
--Добавления новеньких в таблицу новенькие
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

-----проверка акредетации
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

INSERT INTO Teacher(StaffID)
VALUES(2)

select*
from teacher

---хранимая для удаления новеньких
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

---хранимая на смену директора
--при смене мы еще меняем две зарплаты, и отдаем (если такие есть) классы которые были у нового директора старому, и также с предметами которые он ведет
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








---------------------------------------------------------------------------------------4 Вьюшки-------------------------------------------------------------------------------------------------------------------------------------
---вьюшка для хранения количества студентов на спецеализации
CREATE VIEW ClassSpec
AS
SELECT SPEC.[Description],COUNT(st.StudentID) as 'number of students'
	FROM CLASS AS CS
	JOIN Student AS ST 
	 ON CS.ClassID=ST.ClassID
	  JOIN Specialization AS SPEC 
	   ON SPEC.SpecializationID=CS.SpecializationID
	GROUP BY SPEC.[Description]
	--создали вьюшку для просмотра количества студентов на определеной спецеализации


	

	select*
	from ClassSpec

---вьюшка для хранения роботник-зарплата
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

----------------------------------------------Конец-----------------------------------------------------------------------------------------------------------------------------------------------------------------