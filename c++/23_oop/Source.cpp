#include <iostream>
#include <fstream>
#include <string>
#include <math.h> 

namespace twoD
{
	class Point
	{
	public:
		Point(float x = 0, float y = 0) :
			_x{ x },
			_y{ y }
		{};

		Point(const Point& tmp)
		{
			this->_x = tmp._x;
			this->_y = tmp._y;
		}


		float get_x()
		{
			return _x;
		}
		float get_y()
		{
			return _y;
		}
		

		friend bool operator ==(const Point& tmp1,const  Point& tmp2);
		

	

	private:
		float _x;
		float _y;
	};
	
	
	bool operator==(const Point& tmp1, const Point& tmp2)
	{
		if (tmp1._x==tmp2._x&&tmp2._y==tmp1._y)
		{
			return true;
		}
		return false;
	}

}

namespace threeD
{
	class Point
	{
	public:
		Point(float x = 0, float y = 0, float z = 0) :
			_x{ x },
			_y{ y },
			_z{ z }
		{};

		Point(const Point& tmp)
		{
			this->_x = tmp._x;
			this->_y = tmp._y;
			this->_z = tmp._z;
		}


		float get_x()
		{
			return _x;
		}
		float get_y()
		{
			return _y;
		}
		float get_z()
		{
			return _z;
		}
		
		friend bool operator ==(const Point& tmp1, const  Point& tmp2);
		

		

	private:
		float _x;
		float _y;
		float _z;
	};

	bool operator==(const Point& tmp1, const Point& tmp2)
	{
		if (tmp1._x == tmp2._x && tmp2._y == tmp1._y && tmp1._z==tmp2._z)
		{
			return true;
		}
		return false;
	}
}


namespace decimalF
{
	class Fraction
	{
	public:
		Fraction(float numenator = 0, float denumenator = 1)
		{
			if (denumenator == 0)
			{
				throw std::invalid_argument("denumenator cant be  0");
			}
			_result = numenator / denumenator;
		}
		
		Fraction(const Fraction& tmp)
		{
			this->_result = tmp._result;
		}
		
		float get_result()
		{
			return _result;
		}
		
		float result_fraction(float value)
		{
			if (value == 0)
			{
				throw std::invalid_argument("value cant be 0");
			}
			return _result / value;
		}

		

		

	private:
		float _result;
	};

}

namespace simpleF
{
	class Fraction
	{
	public:
		Fraction(float numerator = 0, float denumenator = 1) 
		{
			if (denumenator == 0)
			{
				throw std::invalid_argument("denumenator cant be  0");
			}
			_numerator = numerator;
			_denumerator = denumenator;
		}
		
		Fraction(const Fraction& tmp)
		{
			this->_denumerator = tmp._denumerator;
			this->_numerator = tmp._numerator;
		}
		
		float get_numerator()
		{
			return _numerator;
		}
		
		float get_denumerator()
		{
			return _denumerator;
		}
		
		float get_result()
		{
			return this->_numerator / this->_denumerator;
		}

		

		

	private:
		float _numerator;
		float _denumerator;
	};

	
}





int main()
{
	int x, y, z;
	std::cout << "2D point\n enter value(default 0,0)" << std::endl;
	std::cin >> x >> y;
	twoD::Point a(x, y);

	std::cout << "Enter second 2D point" << std::endl;
	std::cin >> x >> y;
	twoD::Point b(x, y);
	

	std::cout << "First data\n x: " << a.get_x() << " y: " << a.get_y() << std::endl;
	std::cout << "Second data\n x: " << b.get_x() << " y: " << b.get_y() << std::endl;
	std::cout << "Is equal " << (a == b) << std::endl;


	std::cout << "3D point\n enter value(default 0,0,0)" << std::endl;
	std::cin >> x >> y >> z;
	threeD::Point c(x, y,z);

	std::cout << "Enter second 2D point" << std::endl;
	std::cin >> x >> y >> z;
	threeD::Point d(x, y, z);


	std::cout << "First data\n x: " << c.get_x() << " y: " << c.get_y() <<"z: "<<c.get_z()<< std::endl;
	std::cout << "Second data\n x: " << b.get_x() << " y: " << b.get_y() << "z: " << d.get_z() << std::endl;
	std::cout << "Is equal " << (c == d) << std::endl;

	std::cout << "Decimacl Fraction\n Enter numerator or denumenator(default 0,1)" << std::endl;
	std::cin >> x >> y;
	try
	{
		decimalF::Fraction e(x, y);
		std::cout << "Result " << e.get_result() << std::endl;
		std::cout << "Enter number to divide fraction " << std::endl;
		std::cin >> z;
		std::cout << e.result_fraction(z)<<std::endl;

	}
	catch (const std::invalid_argument&er)
	{
		std::cout << er.what() << std::endl;
	}

	std::cout << "Simple Fraction\n Enter numerator or denumenator(default 0,1)" << std::endl;
	std::cin >> x >> y;
	try
	{
		simpleF::Fraction f(x, y);
		std::cout << "Numerator " << f.get_numerator()<<" Denumerator " <<f.get_denumerator()<< std::endl;
		std::cout << "Result " << f.get_result() << std::endl;

	}
	catch (const std::invalid_argument& er)
	{
		std::cout << er.what() << std::endl;
	}
	
}