/*Создайте класс Date, который будет содержать информацию о дате (день,
месяц, год). С помощью механизма перегрузки операторов, определите
операцию разности двух дат (результат в виде количества дней между датами),
а также операцию увеличения даты на определенное количество дней.
2. Добавить в строковый класс функцию, которая создает строку, содержащую
пересечение двух строк, то есть общие символы для двух строк. Например,
результатом пересечения строк "sdqcg" "rgfas34" будет строка "sg". Для
реализации функции перегрузить оператор * (бинарное умножение)*/

#include<iostream>

using namespace std;

class NotString
{
public:
	NotString();
	~NotString();
	NotString(string in):
		_string{ in }
	{};
	string operator*(NotString);
	string get_string();

private:
	string _string;
};

NotString::NotString()
{
	_string = "/";
}

NotString::~NotString()
{
}

string NotString::operator*(NotString tmp)
{	
	
	string answer;
	bool flag = false;
		for (int i = 0; i < _string.length(); i++)
		{
			for (int j = 0; j < tmp.get_string().length(); j++)
			{
				if (_string[i] == tmp.get_string()[j])
				{
					answer += tmp.get_string()[i];
					flag = true;
				}
			}
		}
		
	
	if (flag)
	{
		return answer;
	}
	else
	{
		return "-0";
	}
	
}

string NotString::get_string()
{
	return _string;
}



class Date
{
public:
	Date();
	Date(int day ,int mounth,int year):
	_day{ day },
		_mounth{ mounth },
		_year { year }
	{}
	~Date();
	int get_day();
	int get_mounth();
	int get_year();
	bool operator >(Date);
	Date& operator++(int);
	int operator-(Date);
	int day_convertor();
	void check_day();
	bool check_leap();
	bool check_leap(int);
	int mounth_to_day(int,int);
	
private:
	 int _day;
	 int _mounth;
	 int _year;
};

Date::Date()
{
	_day = 0;
	_mounth = 0;
	_year = 0;

}



Date::~Date()
{
}

int Date::get_day()
{
	return _day;
}

int Date::get_mounth()
{
	return _mounth;
}

int Date::get_year()
{
	return _year;
}

bool Date::operator>(Date tmp)
{
	if (_year>tmp.get_year())
	{
		return true;
	}

	if (_mounth>tmp.get_mounth()&&_year==tmp.get_year())
	{
		return true;
	}

	if (_mounth == tmp.get_mounth() && _year == tmp.get_year() && _day>tmp.get_day())
	{
		return true;
	}

	return false;
}

Date& Date::operator++(int n)
{
	_day++;
	check_day();
	return *this;
}

int Date::operator-(Date tmp)
{	
	
	int tmp1 = day_convertor();
	int tmp2 = tmp.day_convertor();
	if (*this>tmp)
	{
		return tmp1 - tmp2;
	}
	else
	{
		return tmp2 - tmp1;
	}
	



	
}



int Date::day_convertor()
{
	int sum = 0;
	int leap_count=0;
	
	for (int i = 0; i < _year; i++)
	{
		if (check_leap())
		{
			leap_count++;
		}
	}
	
	sum+= leap_count * 366;
	sum += (_year-leap_count) * 365;

	for (int i = 1; i < _mounth; i++)
	{
		sum += mounth_to_day(i, _year);
	}

	
	


	return sum;
}


void Date::check_day()
{
	if (_mounth==1||_mounth==3 || _mounth == 5 || _mounth == 7 || _mounth == 8 || _mounth == 10 || _mounth == 12)
	{

		if (_day>31)
		{
			_day = 1;
			_mounth++;
		}
	
	}
	else if (_mounth == 4 || _mounth == 6 || _mounth == 9 || _mounth == 11)
	{
		if (_day>30)
		{
			_day = 1;
			_mounth++;
		}
	}
	else
	{
		if (check_leap())
		{
			if (_day>29)
			{
				_day = 1;
				_mounth++;
			}
			
		}
		else
		{
			if (_day>28)
			{
				_day = 1;
				_mounth++;
			}
		}
	}
	
	if (_mounth>12)
	{
		_mounth = 1;
		_year++;
	}
}

bool Date::check_leap()
{
	if (_year % 4 != 0 || _year % 100 == 0 && _year % 400 != 0)
	{
		return false;
	}
	else
	{
		return true;
	}
}

bool Date::check_leap(int tmp)
{
	if (tmp % 4 != 0 || (tmp % 100 == 0 && tmp % 400 != 0))
	{
		return false;
	}
	else
	{
		return true;
	}
	
}

int Date::mounth_to_day(int tmp, int tmp_year)
{
	if (tmp == 1 || tmp == 3 || tmp == 5 || tmp == 7 || tmp == 8 || tmp == 10 || tmp == 12)
	{
		

		return 31;

	}
	else if (tmp == 4 || tmp == 6 || tmp == 9 || tmp == 11)
	{
		
		return 30;
	}
	else
	{
		if (check_leap(tmp_year))
		{
			
			return 29;

		}
		else
		{
			
			return 28;
		}
	}

}



void date_ex()
{
	int year, mounth, day;
	cout << "Enter first Date(day,mount,year)" << endl;
	cin >> year >> mounth >> day;
	Date first(day, mounth, year);

	cout << "Enter second Date(day,mount,year)" << endl;
	cin >> year >> mounth >> day;
	Date second(day, mounth, year);

	int tmp;

	int k;
	while (true)
	{
		system("pause");
		system("cls");
		cout << "1.Find difference between two years" << endl;
		cout << "2.Add days to first year" << endl;
		cout << "3.exit" << endl;
		cin >> k;
		switch (k)
		{

		case 1:
			cout << first - second << " days" << endl;
			break;
		case 2:
			cout << "Enter number of days to add" << endl;
			cin >> tmp;
			for (int i = 0; i < tmp; i++)
			{
				first++;
			}
			cout << first.get_day() << "." << first.get_mounth() << "." << first.get_year() << endl;
			break;
		default:
			return;
			break;
		}
	}
}

void string_ex()
{
	string tmp;
	cout << "Enter first string" << endl;
	cin >> tmp;
	NotString first(tmp);

	cout << "Enter second string" << endl;
	cin >> tmp;
	NotString second(tmp);


	string answer = first * second;

	cout <<"Answer: " <<answer << endl;

}


int main()
{
	
	int k;
	while (true)
	{
		int k = 0;
		while (true)
		{	
			cout << "1.Date ex" << endl;
			cout << "2.string ex" << endl;
			cout << "3.exit" << endl;
			cin >> k;

			switch (k)
			{
			case 1:
				date_ex();

				break;
			case 2:
				string_ex();
				break;
			case 3:
				return 1;
			default:
				break;
			}
		}
	}
	
	
	

}