/*Создать класс Triangle для представления треугольника. Поля данных должны
включать углы и стороны. Требуется реализовать операции:
- получения и изменения полей данных
- вычисления площади (формула Герона, например)
- вычисления периметра
- вычисления высот
- определение вида треугольника (равносторонний, равнобедренный или
прямоугольный).
2. Создать класс Point для работы с точками на плоскости. Координаты точки -
декартовы. Обязательно должны быть реализованы:
- перемещение точки по оси X
- перемещение точки по оси Y
- определение расстояния до начала координат
- расстояния между двумя точками
- преобразование в полярные координаты
- сравнение на совпадение и несовпадение*/

#include<iostream>
#include<cmath>

using namespace std;

class Tringle
{
public:
	Tringle() = delete;
	Tringle(int A, int B, int C, float a, float b, float c) :
		_A_angel{ A },
		_B_angel{ B },
		_C_angel{ C },
		_a{ a },
		_b{ b },
		_c{ c }
	{};
	
	int get_A_angel();
	int get_B_angel();
	int get_C_angel();
	int get_a();
	int get_b();
	int get_c();

	float find_area();
	int find_peremiter();
	float find_height();

	string find_type();

	


private:
	int _A_angel;
	int _B_angel;
	int _C_angel;
	float _a;
	float _b;
	float _c;

};



int Tringle::get_A_angel()
{
	return this-> _A_angel;
}

int Tringle::get_B_angel()
{
	return this->_B_angel;
}

int Tringle::get_C_angel()
{
	return this->_C_angel;
}

int Tringle::get_a()
{
	return this->_a;
}

int Tringle::get_b()
{
	return this->_b;
}

int Tringle::get_c()
{
	return this->_c;
}

float Tringle::find_area()//S = sqrt p * (p − a) * (p − b) * (p − c)
{						//p = (a + b + c) : 2
	int p;
	p = this->_a + this->_b + this->_c;



	return sqrt(p*(p- this->_a)*(p- this->_b)*(p- this->_c));
}

int Tringle::find_peremiter()
{
	return this->_a+ this->_b+ this->_c;
}

float Tringle::find_height()
{
	return (this->find_area()*2)/_a;
}

string Tringle::find_type()
{
	if (_a==_b&&_a!=_c)
	{
		return "isosceles";
	}
	else if (_a == _b && _a == _c)
	{
		return "equilateral";
	}
	else if (_A_angel==90||_B_angel==90||_C_angel==90)
	{
		return "right";
	}
	else
	{
		return "arbitrary";
	}
	
	
}


class Point
{
public:
	Point()=delete;
	Point(float x,float y):
		_x{ x }, 
		_y {y }
	{};

	float get_x();
	float get_y();

	float move_x(float);
	float move_y(float);
	float start_cordinat();
	float find_distance(Point);
	float in_polar();
	bool is_equal(Point);
	

private:
	float _x;
	float _y;
};



float Point::get_x()
{
	return this->_x;
}

float Point::get_y()
{
	return this->_y;
}

float Point::move_x(float x)
{
	return this->_x+x;
}

float Point::move_y(float y)
{
	return this->_y+y;
}

float Point::start_cordinat()
{
	return sqrt((pow(0-this->_x,2))+(pow(0-this->_y,2)));
}

float Point::find_distance(Point tmp)
{	
	return sqrt((pow(tmp.get_x() - this->_x, 2)) + (pow(tmp.get_y() - this->_y, 2)));
}

float Point::in_polar()
{
	return sqrt(pow(this->_x,2)+pow(this->_y,2));
}

bool Point::is_equal(Point tmp)
{
	if (this->_x==tmp.get_x()&&this->_y==tmp.get_y())
	{
		return true;
	}
	else
	{
		return false;
	}
}

class Printer
{
public:
	Printer();
	~Printer();
	void Tringle_printer(Tringle);
	void Point_printer(Point, Point);
private:

};

Printer::Printer()
{
}

Printer::~Printer()
{
}

void Printer::Tringle_printer(Tringle tmp)
{
	cout << "Tringle" << endl;
	cout << "Angels" << endl;
	cout << "A: " << tmp.get_A_angel() << " B: " << tmp.get_B_angel() << " C: " << tmp.get_C_angel() << endl;
	cout << "Sides" << endl;
	cout << "a: " << tmp.get_a() << " b: " << tmp.get_b() << "  c: " << tmp.get_c() << endl;
	cout << "Area: " << tmp.find_area() << endl;
	cout << "Preimiter: " << tmp.find_peremiter() << endl;
	cout << "Height: " << tmp.find_height() << endl;
	cout << "Type: " << tmp.find_type() << endl;
	
}

void Printer::Point_printer(Point first , Point second)
{
	cout << "First Point" << endl;
	cout << "X: " << first.get_x() << "Y: " << first.get_y();
	cout << "Polar: " << first.in_polar() << endl;
	cout << "Start cordinat distance" << first.start_cordinat() << endl << endl;

	cout << "Second Point" << endl;
	cout << "X: " << second.get_x() << "Y: " << second.get_y();
	cout << "Polar: " << second.in_polar() << endl;
	cout << "Start cordinat distance: " << second.start_cordinat() << endl << endl;

	cout << "Distance between points: " << first.find_distance(second) << endl;
	cout << "Point equal: " << first.is_equal(second) << endl;
}


int main()
{
	Printer cmd;
	int k;
	int A, B, C;
	int a, b, c;
	cout << boolalpha;
	cout << "Tringle Ex" << endl;
	cout << "Enter 3 angel for Tringle" << endl;
	cin >> A >> B >> C;
	cout << "Enter 3 sides for Tringle" << endl;
	cin >> a >> b >> c;
	Tringle Tringel_tmp(A, B, C, a, b, c);
	cmd.Tringle_printer(Tringel_tmp);
	system("pause");
	system("cls");

	cout << "Point ex" << endl;
	cout << "Enter x then y(point 1)" << endl;
	cin >> A >> B;
	Point first(A, B);
	cout << "Enter x then y (point 2)" << endl;
	cin >> A >> B;
	Point second(A, B);
	cmd.Point_printer(first, second);

}

