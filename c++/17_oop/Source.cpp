#include <iostream>

using namespace std;

class Student
{
public:
	Student() :
		_name{ " " },
		_surname{ " " },
		_group_number { -1 }
	{};
	Student(string in_name, string in_surname, int in_group_number) :
		_name{ in_name },
		_surname{ in_surname },
		_group_number{ in_group_number }
	{};
	void set_name(string name)
	{
		_name = name;
	}
	void set_surname(string surname)
	{
		_surname = surname;
	}
	void set_number(int number)
	{
		_group_number = number;
	}
	
	void out()
	{	cout<<"Student" << endl;
		cout << "name: " << _name << endl;
		cout << "surname: " << _surname << endl;
		cout << "group number: " << _group_number << endl;
	}
	
	

protected:
	string _name;
	string _surname;
	int _group_number;
};

class Aspirant : public Student
{
public:
	Aspirant(string in_name, string in_surname, int in_group_number,string in_work_name,int in_work_number):
		
		Student{ in_name, in_surname, in_group_number },
		_work_number { in_work_number },
		_work_name { in_work_name }

	{};

	void out()
	{
		cout << "Aspirant" << endl;
		Student::out();
		cout << "work name " << _work_name << endl;
		cout << "work number " << _work_number << endl;
	}
private:
	string _work_name;
	int _work_number;
};

class Passport
{
public:

	Passport(string in_name, string in_surname, int in_passport_number,int in_year,int in_mounth,int in_day):

	_name { in_name },
	_surname { in_surname },
	_passport_number { in_passport_number },
	_expired_year { in_year },
	_expired_mounth { in_mounth },
	_expired_day { in_day }

	{};
	void out()
	{
		cout << "Passport " << endl;
		cout << "name " << _name << endl;
		cout << "surname " << _surname << endl;
		cout << "passport_number " << _passport_number << endl;
		cout << "passport expired " << _expired_year << "-" << _expired_mounth << "-" << _expired_day << endl;

	}
	

protected:
	string _name;
	string _surname;
	int _passport_number;
	int _expired_year;
	int _expired_mounth;
	int _expired_day;

};

class  ForeignPassport : public Passport
{
public:
	ForeignPassport(string in_name, string in_surname, int in_passport_number, int in_year, int in_mounth, int in_day,
		int in_foreign_number, int in_foreign_year, int in_foreign_mounth, int in_foreign_day) :
	
	Passport {  in_name,  in_surname,  in_passport_number, in_year,  in_mounth,  in_day },
	_foreign_number { in_foreign_number },
	_foreign_expired_year { in_foreign_year },
	_foreign_expired_mounth { in_foreign_mounth },
	_foreign_expired_day {in_foreign_day }

	{};

	void out()
	{
		cout << "Foreign" << endl;
		Passport::out();
		cout << "Foreign number " << _foreign_number << endl;
		cout << "Foreign expired " << _foreign_expired_year << "-" << _foreign_expired_mounth << "-" << _foreign_expired_day << endl;
	}
private:
	int _foreign_number;
	int _foreign_expired_year;
	int _foreign_expired_mounth;
	int _foreign_expired_day;
};

class Student_array
{
public:
	Student_array() :
		_arr{ nullptr },
		_size{ 0 }
	{};

	void add(string name, string surname, int group)
	{
		if (_arr == nullptr)
		{
			_size++;
			_arr = new Student[_size];
			_arr[0].set_name(name);
			_arr[0].set_number(group);
			_arr[0].set_surname(surname);

		}
		else
		{
			Student* tmp = new Student[_size+1];
			for (int i = 0; i < _size; i++)
			{
				tmp[i] = _arr[i];
			}
			tmp[_size].set_name(name);
			tmp[_size].set_number(group);
			tmp[_size].set_surname(surname);
			_size++;
			delete[] _arr;
			_arr = tmp;
			
		}
	}

	
	void del()
	{
		if (_arr == nullptr)
		{
			return;

		}
		else
		{
			Student* tmp = new Student[--_size];
			for (int i = 0; i < _size; i++)
			{
				tmp[i] = _arr[i];
			}
			delete[] _arr;
			_arr = tmp;
			
		}
	}

	void del(int index)
	{
		
		if (_arr == nullptr)
		{
			return;

		}
		else
		{
			Student* tmp = new Student[--_size];
			for (int i = 0; i < index; i++)
			{
				
				tmp[i] = _arr[i];
						
			}

			for (int i = index+1; i < _size+1; i++)
			{
				tmp[i - 1] = _arr[i];
			}
			delete[] _arr;
			_arr = tmp;

		}
	}

	void out()
	{
		for (int i = 0; i < _size; i++)
		{
			
			_arr[i].out();
		}
	}
	~Student_array()
	{
		delete[] _arr;
	}

private:
	int _size;
	Student* _arr;
};




 

int main()
{	//First EX
	Student a("a", "b", 134);
	Aspirant b("a", "b", 134, "asd", 789);

	a.out();
	cout << endl;
	b.out();
	cout << endl;
	
	//Second EX
	Passport c("a", "b", 567, 2001, 12, 12);
	ForeignPassport d("a", "b", 567, 2001, 12, 12, 765, 1002, 21, 21);
	c.out();
	cout << endl;
	d.out();
	cout << endl;

	//Third EX
	Student_array ab;
	ab.add("1", "1", 111);
	ab.add("2", "2", 222);
	ab.add("3", "3", 333);
	ab.add("4", "4", 444);
	ab.out();
	cout << endl;
	ab.del(3);
	ab.out();
	cout << endl;
	


}

