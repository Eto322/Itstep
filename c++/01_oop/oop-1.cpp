/*. Цифровой счетчик, это переменная с ограниченным диапазоном. Значение
которой сбрасывается, когда ее целочисленное значение достигает
определенного максимума (например, k принимает значения в диапазоне от
0..100). В качестве примера такого счетчика можно привести цифровые часы,
счетчик километража. Опишите класс такого счетчика. Обеспечьте возможность
установления максимального и минимального значений, увеличения счетчика
на 1, возвращения текущего значения.
2. Написать класс, описывающий группу студентов. Описание студента также
реализуется с помощью соответствующего класса*/

#include <iostream>
#include <string>


class Counter
{
public:
	Counter();
	Counter(int min, int max);
	int increment();
	void check();
	~Counter();

private:
		int _count;
		int _count_min;
		int _count_max;

};
class Student
{
public:
	Student();
	Student(std::string, std::string,  int);
	void Student_set();
	void student_out ();

	~Student();

private:
	std::string _name;
	std::string _surname;
	
	int _age;
};
class Group
{
public:
	Group();
	Group(std::string);
	void add_student();
	void out_students();
	~Group();

private:
	Student* _group;
	int _student_count;
	std::string _name;
};



void ex1();
void ex2();

int main()
{
	Counter tmp;
	int k = 0;
	while (true)
	{
		std::cout << "1.ex1" << std::endl;
		std::cout << "2.ex2" << std::endl;
		std::cout << "3.exit"<< std::endl;
		std::cin >> k;

		switch (k)
		{
		case 1:
			ex1();
			
			break;
		case 2:
			ex2();
			break;
		case 3:
			return 1;
		default:
			break;
		}
	}
}


Counter::Counter()
{
	_count = 0;
	_count_min = 0;
	_count_max = 100;
}
Counter::Counter(int min, int max)
{
	_count_min = min;
	_count = min;
	_count_max = max;
}
int Counter::increment()
{
	check();
	_count++;
	return _count;
}
void Counter::check()
{
	if (_count<_count_min||_count>=_count_max)
	{
		_count = _count_min;
		
	}
	
}
Counter::~Counter()
{
}

Group::Group()
{
	_group = nullptr;
	_student_count = 0;
}
Group::Group(std::string name)
{
	_name = name;
	std::cout << "Enter number of students" << std::endl;
	std::cin >> _student_count;
	
	_group = new Student[_student_count];
	for (int i = 0; i < _student_count; i++)
	{
		std::cout << "Student# " << i+1 << std::endl;
		_group[i].Student_set();
	}
}
void Group::add_student()
{


	Student* tmp = new Student[_student_count + 1];
	for (int i = 0; i < _student_count; i++)
	{
		tmp[i] = _group[i];

	}
	_student_count++;
	tmp[_student_count-1].Student_set();
	delete[] _group;
	_group = tmp;

}
void Group::out_students()
{
	if (_group == nullptr)
	{
		std::cout << "group is empty" << std::endl;
		return;
	}
	else
	{
		std::cout << "Group: " << _name << std::endl << std::endl;
		for (int i = 0; i < _student_count; i++)
		{
			std::cout << "student #" << i+1 << std::endl;
			_group[i].student_out();
		}
	}

}
Group::~Group()
{
	delete[] _group;

}

Student::Student()
{
	_name = '/';
	_surname = '/';
	_age = -1;
}
Student::Student(std::string name, std::string surname, int age)
{
	_name = name;
	_surname = surname;

	_age = age;

}
void Student::Student_set()
{
	std::cout << "name: ";
	std::cin >> _name;
	std::cout << "Surname: ";
	std::cin >> _surname;
	std::cout << "age: ";
	std::cin >> _age;
	std::cin.ignore();
}
void Student::student_out()
{
	std::cout << "name: " << _name << "\nsurname: " << _surname << "\nage: " << _age <<"\n"<< std::endl;
}
Student::~Student()
{
}

void ex1()
{
	char ch='0';
	int k;
	int k_1 = 0;
	int max, min;
	printf("1.default min(0) max(100)\n2.custom min max\n");
	std::cin >> k;
	if (k==1)
	{
		Counter tmp;
		while (ch != '1')
		{
			system("cls");
			std::cout << "Enter 1 to stop,Press Enter to continue" << std::endl;
			std::cout << "counter=" << tmp.increment()<< std::endl;
			ch=getchar();

		}

	}
	else
	{
		std::cout << "Enter min then enter mas" << std::endl;
		std::cin >> min >> max;
		std::cin.ignore();
		Counter tmp(min, max);
		while (ch != '1')
		{

			system("cls");
			std::cout << "Enter 1 to stop,Press Enter to continue" << std::endl;
			std::cout << "counter=" << tmp.increment() << std::endl;
			ch = getchar();

		}
	}
		
	
}

void ex2()
{
	std::string name;
	std::cout << "Enter group name" << std::endl;
	std::cin >> name;

	Group tmp(name);
	int k;
	while (true)
	{
		system("pause");
		system("cls");
		printf("1.add student\n2.show all students");
		std::cin >> k;
		switch (k)
		{
		case 1:
			tmp.add_student();
			break;
		case 2:
			tmp.out_students();
			break;
		default:
			break;
		}
	}
}

