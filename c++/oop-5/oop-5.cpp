/*—оздать класс окружностей на плоскости, описав в нЄм все необходимые свойства,
подобрав им пон€тные имена и правильные типы данных. ќписать в классе
конструктор, позвол€ющий при создании нового объекта €вно задать все его свойства,
а также конструктор, позвол€ющий задать свойства с клавиатуры. ≈сли это
необходимо, то проверить допустимость значений свойств. —оздать в классе метод,
вычисл€ющий площадь круга. —оздать в классе метод, вычисл€ющий рассто€ние
между центрами окружностей. —оздать в классе метод, сообщающий, касаютс€ ли
окружности. —оздать в классе метод, сообщающий, содержитс€ ли одна окружность
внутри другой.
»спользуйте константные методы.*/



#include <iostream>
#include <cmath>


using namespace std;

class Point
{
public:
	Point();
	Point(float x,float y):
		_x{ x },
		_y{ y } 
	{};
	float get_x() const;
	float get_y() const;
	~Point();

private:
	float _x;
	float _y;
};

class Circle
{
public:
	Circle();
	Circle(float radius,float x,float y):
		_radius{ radius },
		_centre{ x,y }
	{};
	float get_radius();
	Point get_centre();
	float find_area() const;
	float find_distance(Circle tmp) const ;
	bool is_touch(Circle tmp) const;
	bool is_inside(Circle tmp) const;

	~Circle();

private:
	float _radius;
	const Point _centre;
};


Circle::Circle()
{
	_radius = 0;
	
}

float Circle::get_radius()
{
	return _radius;
}

Point Circle::get_centre()
{
	 return _centre;
}

float Circle::find_area() const
{
	return 3.14f*pow(_radius,2);
}

float Circle::find_distance(Circle tmp) const
{	
	return sqrt(pow(_centre.get_x() - tmp.get_centre().get_x(), 2) + pow(_centre.get_y() - tmp.get_centre().get_y(), 2));//AB = sqrt((xb - xa)^2 + (yb - ya)^2)
}

bool Circle::is_touch(Circle tmp) const
{
	if (find_distance(tmp)==_radius*tmp.get_radius())
	{
		return true;
	}
	return false;
}

bool Circle::is_inside(Circle tmp) const
{	

	if (find_distance(tmp) == 0)
	{
		return true;
	}
	return false;
}




Circle::~Circle()
{
	
}

Point::Point()
{
	_x = -1;
	_y = -1;
}

float Point::get_x() const
{
	return _x;
}

float Point::get_y() const
{
	return _y;
}

Point::~Point()
{
}
Circle create_circle(string tmp)
{	cout << "Enter data for " << tmp << " circle " << endl;
	float x, y, radius=-1;
	cout << "Enter x" << endl;
	cin >> x;
	cout << "Enter y" << endl;
	cin >> y;
	while (radius<=0)
	{
		cout << "Enter radius(bigger then 0)" << endl;
		cin >> radius;
	}
	return Circle(radius, x, y);

}
int main()
{
	cout<< std::boolalpha;
	
	Circle tmp1 = create_circle("first");
	Circle tmp2 = create_circle("second");
	int k;
	while (true)
	{
		system("pause");
		system("cls");
		cout << "1.Find area" << endl;
		cout << "2.Find distance between circle 1 and circle 2" << endl;
		cout << "3.Does circles touch" << endl;
		cout << "4.Check one circle in other" << endl;
		cout << "5.Exit" << endl;
		cin >> k;

		switch (k)
		{
		case 1:
			cout << "Circle 1:" << tmp1.find_area() << endl;
			cout << "Circle 2:" << tmp2.find_area() << endl;
			break;
		case 2:
			cout << "Distance between 1 and 2 " << tmp1.find_distance(tmp2) << endl;;
			break;
		case 3:
			cout << tmp1.is_touch(tmp2) << endl;
			break;
		case 4:
			cout << tmp1.is_inside(tmp2) << endl;
			break;
		case 5:
			exit(0);
		default:
			break;
		}
	}
}