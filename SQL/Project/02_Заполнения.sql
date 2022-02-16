
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
--Заполним 11-А

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