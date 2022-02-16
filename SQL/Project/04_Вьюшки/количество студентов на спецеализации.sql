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