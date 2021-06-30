/*В последующих заданиях обязательно должны быть реализованы следующие
методы:
- конструктор
- деструктор
- ввод с клавиатуры Read
- вывод на экран Display
Все разработанные классы не должны нарушать инкапсуляцию.
1. Комплексное число представляется парой действительных чисел (a, b),
где a - действительная часть, b - мнимая часть. Реализовать класс
Complex для работы с комплексными числами. Обязательные операции:
- сложение add: (a, b) + (c, d) = (a + c, b + d)
- вычитание sub: (a, b) - (c, d) = (a - c, b - d)
- умножение mul: (a, b) x (c, d) = (ac - bd, ad + bc)
- деление div: (a, b) / (c, d) = (ac + bd, bc - ad) / (c2 + d2
)
- сравнение equ: (a, b) = (c, d), если (a = c) и (b = d).
- сопряженное число conj conj(a, b) = (a, -b)
2. Создать класс Vector3D, задаваемый тройкой координат. Обязательно
должны быть реализованы: сложение и вычитание векторов, скалярное
произведение векторов, умножение на скаляр, сравнение векторов,
вычисление длины вектора, сравнение длины векторов.
3. Создать класс ModelWindow для работы с моделями экранных окон. В
качестве полей задаются: заголовок окна, координаты левого верхнего
угла, размер по горизонтали, размер по вертикали, цвет окна, состояние
“видимое/невидимое”, состояние “с рамкой/без рамки”. Координаты и
размеры указываются в целых числах. Реализовать операции:
передвижение окна по горизонтали, по вертикали; изменение высоты
и/или ширины окна, изменение цвета; изменение состояния, опрос
состояния*/
#include <iostream>
#include<math.h>
#include <string.h>
using namespace std;
class ModelWindow
{
public:
	ModelWindow();
	ModelWindow(char*, int,int ,int ,int ,char*, bool,bool);
	~ModelWindow();




	char* get_name();
	int get_x();
	int get_y();
	int get_horizontal();
	int get_vertical();
	char* get_color();
	bool get_vision();
	bool get_panel();

	void move_horizontal(int );
	void move_vertical(int );
	void change_height(int);
	void change_width(int);
	void change_color(char*);
	void change_name(char*);
	void change_panel();
	void change_vision();
	

	
private:
	char* _name;
	int _x;
	int _y;
	int _horizontal;
	int _vertical;
	char* _color;
	bool _vision;
	bool _panel;
};

ModelWindow::ModelWindow()
{
	*_name = '.';
	_x = 0;
	 _y=0;
	 _horizontal=0;
	 _vertical=0;
	 *_color='.';
	 _vision = false;;
	 _panel=false;
}

ModelWindow::ModelWindow(char* name, int x, int y, int horizntal, int vertical, char* color, bool vision, bool panel)
{
	_name = name;
	_x = x;
	_y = y;	
	_horizontal = horizntal;
	_vertical = vertical;
	_color = color;
	_vision = vision;
	_panel = panel;
}

ModelWindow::~ModelWindow()
{
	delete[]_name;
	delete[]_color;
}
char* ModelWindow::get_name()
{
	return _name;
}
int ModelWindow::get_x()
{
	return _x;
}
int ModelWindow::get_y()
{
	return _y;
}
int ModelWindow::get_horizontal()
{
	return _horizontal;
}
int ModelWindow::get_vertical()
{
	return _vertical;
}
char* ModelWindow::get_color()
{
	return _color;
}
void ModelWindow::move_horizontal(int tmp)
{
	_x += tmp;
}
void ModelWindow::move_vertical(int tmp)
{
	_y += tmp;
}
void ModelWindow::change_height(int tmp)
{
	_x += tmp;
	_vertical += tmp;

}
void ModelWindow::change_width(int tmp)
{
	_y += tmp;
	_horizontal += tmp;

}
void ModelWindow::change_color(char* tmp)
{
	
	_color = tmp;
}
void ModelWindow::change_name(char*tmp)
{
	
	_name = tmp;
}
void ModelWindow::change_panel()
{
	if (_panel == true)
	{
		_panel = false;
	}
	else
	{
		_panel = true;
	}
}
void ModelWindow::change_vision()
{
	if (_vision==true)
	{
		_vision = false;
	}
	else
	{
		_vision = true;
	}
}
bool ModelWindow::get_vision()
{
	return _vision;
}
bool ModelWindow::get_panel()
{
	return _panel;
}

class Vector3D
{
public:
	Vector3D(): 
		_x{ 0 }, 
		_y{ 0 },
		_z{ 0 }
	{};

	Vector3D(float x,float y, float z) :
		_x{ x },
		_y{ y },
		_z{ z }
	{};

	float get_x();
	float get_y();
	float get_z();


	Vector3D& add(Vector3D);
	Vector3D& sub(Vector3D);
	float dot(Vector3D);
	bool equ(Vector3D);
	bool equ(float);

	float find_long(Vector3D);

	~Vector3D();

private:
	float _x;
	float _y;
	float _z;
};



float Vector3D::get_x()
{
	return _x;
}

float Vector3D::get_y()
{
	return _y;
}

float Vector3D::get_z()
{
	return _z;
}

Vector3D& Vector3D::add(Vector3D tmp)//(ax + bx, ay + by, az + bz).
{
	int x = _x + tmp.get_x();
	int y = _y + tmp.get_y();
	int z = _z + tmp.get_z();
	Vector3D tmp1 (x, y, z);
	return tmp1;
}

Vector3D& Vector3D::sub(Vector3D tmp)//c – a = (cx – ax, cy – ay, cz – az).
{
	int x = _x - tmp.get_x();
	int y = _y - tmp.get_y();
	int z = _z - tmp.get_z();
	Vector3D tmp1(x, y, z);
	return tmp1;
}

float Vector3D::dot(Vector3D tmp)// axbx + ayby + azbz;
{
	int x = _x * tmp.get_x();
	int y = _y * tmp.get_y();
	int z = _z * tmp.get_z();
	return x + y + z;
}

bool Vector3D::equ(Vector3D tmp)
{
	if (_x==tmp.get_x()&&_y==tmp.get_y()&&_z==tmp.get_z())
	{
		return true;
	}
	return false;
}

bool Vector3D::equ(float tmp)
{
	if (find_long(*this)==tmp)
	{
		return true;
	}
	return false;
}

float Vector3D::find_long(Vector3D tmp)//|a| = sqrt(ax2 + ay2 + az2)
{
	float x = _x * _x;
	float y = _y * _y;
	float z = _z * _z;
	float answer=sqrt(x+y+z);
	return answer;

}

Vector3D::~Vector3D()
{
}

class Complex
{
public:
	Complex();
	Complex(int, int);
	~Complex();
	
	void add(Complex&);
	void sub(Complex&);
	void mul(Complex&);
	void div(Complex&);
	bool equ(Complex&);
	void conj();
	
	int* get_a();
	int* get_b();

private:
	int* _a;
	int* _b;
};



class Printer
{
public:
	Printer();
	~Printer();
	void complex_printer(Complex&tmp)
	{
		cout << "a:" << *tmp.get_a() << "\nb:" <<*tmp.get_b() << endl;
	}
	
	
	void Vector3d_printer(Vector3D&tmp)
	{
		cout << "x: " << tmp.get_x() << "\ny: " << tmp.get_y() << "\nz: " << tmp.get_z() << endl;
		cout << "long: " << tmp.find_long(tmp) << endl;
	}

	void Vector3d_printer(Vector3D& tmp1, Vector3D& tmp2)
	{
		system("cls");
		cout << "Vector 1" << endl;
		this->Vector3d_printer(tmp1);

		cout << "Vector 2" << endl;
		this->Vector3d_printer(tmp2);

		cout << "Sum Vector " << endl;
		this->Vector3d_printer(tmp1.add(tmp2));

		cout << "Sub Vector " << endl;
		this->Vector3d_printer(tmp1.sub(tmp2));

		cout << "dot: " << tmp1.dot(tmp2) << endl;
		
		cout << "Equ vectors " << tmp1.equ(tmp2)<<endl;

		cout << "Equ longs " << tmp1.equ(tmp2.find_long(tmp2));




	}

	void Window_printer(ModelWindow& tmp)
	{
		cout << "Name: " << tmp.get_name() << endl;
		cout << "x: " << tmp.get_x() << endl;
		cout << "y: " << tmp.get_y() << endl;
		cout << "Color: " << tmp.get_color() << endl;
		cout << "Horizontal: " << tmp.get_horizontal() << endl;
		cout << "Vertical: " << tmp.get_vertical() << endl;
		cout << "Panel vision:  " << tmp.get_panel() << endl;
		cout << "Window vision: " << tmp.get_vision() << endl;
		cout << endl;
	
	}

private:

};

Printer::Printer()
{
}

Printer::~Printer()
{
}



Complex::Complex():_a(0),_b(0)
{
}
Complex::Complex(int a,int b):_a(new int (a)),_b(new int (b))
{
}
Complex::~Complex()
{
	delete _a;
	
	delete _b;
	
}

void Complex::add(Complex&tmp)//(a, b) + (c, d) = (a + c, b + d)
{
	*_a+= *tmp.get_a();
	*_b+= *tmp.get_b();

}

void Complex::sub(Complex& tmp)//(a, b) - (c, d) = (a - c, b - d)
{
	*_a -= *tmp.get_a();
	*_b -= *tmp.get_b();
}

void Complex::mul(Complex&tmp)//(a, b) x (c, d) = (ac - bd, ad + bc)
{
	int tmp_1 = *_a * *tmp.get_a();
	int tmp_2 = *_b * *tmp.get_b();

	*_a = tmp_1 - tmp_2;

	tmp_1 = *_a * *tmp.get_b();
	tmp_2 = *_b * *tmp.get_a();
	*_b = tmp_1 - tmp_2;
}

void Complex::div(Complex& tmp)//(ac + bd, bc - ad) / (c2 + d2)
{
	int tmp_1 = *_a * *tmp.get_a();
	int tmp_2 = *_b * *tmp.get_b();

	*_a = tmp_1 + tmp_2;
	
	tmp_1 = *_a * *tmp.get_b();
	tmp_2 = *_b * *tmp.get_a();
	*_b = tmp_2 - tmp_1;

	*_a /= (*tmp.get_a() * 2 + *tmp.get_b()*2);
	*_b /= (*tmp.get_a() * 2 + *tmp.get_b() * 2);

}

bool Complex::equ(Complex& tmp)//(a, b) = (c, d), если (a = c) и (b = d).
{
	if (*_a==*tmp.get_a()&&*_b==*tmp.get_b())
	{
		return true;
	}
	else
	{
		return false;
	}
}

void Complex::conj()
{
	*_b = -*_b;
}




int* Complex::get_a()
{
	return _a;
}

int* Complex::get_b()
{
	return _b;
}
void complex_ex()
{
	int tmp1;
	int tmp2;
	Printer cmd;
	cout << "Enter first complex number(a and b)" << endl;
	cin >> tmp1 >> tmp2;
	Complex first(tmp1, tmp2);
	
	cout << "Enter second complex number(a and b)" << endl;
	cin >> tmp1 >> tmp2;
	Complex second(tmp1, tmp2);

	
	int k;
	while (true)
	{
		system("cls");
		system("pause");

		cout << "First" << endl;
		cmd.complex_printer(first);
		cout << "Second" << endl;
		cmd.complex_printer(second);
		cout << "Is equal :" << first.equ(second) << endl;


		cout << "1.Add to first second" << endl;
		cout << "2.Sub from first second" << endl;
		cout << "3.Mul first on second" << endl;
		cout << "4.div first on second" << endl;
		cout << "5.conj first " << endl;
		cout << "6.exit" << endl;
		cin >> k;


		switch (k)
		{

		case 1:
			first.add(second);
			break;
		case 2:
			first.sub(second);
			break;
		case 3:
			first.mul(second);
			break;
		case 4:
			first.div(second);
			break;
		case 5:
			first.conj();
			break;
		default:
			return;
			break;
		}

	}

	
}

void Vector_ex()
{
	float tmp1;
	float tmp2;
	float tmp3;
	Printer cmd;
	cout << "Enter first Vector number(x,y,z)" << endl;
	cin >> tmp1 >> tmp2 >> tmp3;
	Vector3D first(tmp1, tmp2,tmp3);

	cout << "Enter second Vector number(x,y,z)" << endl;
	cin >> tmp1 >> tmp2 >> tmp3;
	Vector3D second(tmp1, tmp2, tmp3);

	cmd.Vector3d_printer(first, second);
	cout << endl;
}

void Window_ex()
{
	Printer cmd;
	char name[20];
	char color[20];
	int x;
	int y;
	int horizontal;
	int vertical;
	

	cout << "Enter name" << endl;
	cin >> name;
	cout << "Enter x" << endl;
	cin >> x;
	cout << "Enter y" << endl;
	cin >> y;
	cout << "Enter horizontal" << endl;
	cin >> horizontal;
	cout << "Enter verticazl" << endl;
	cin >> vertical;
	cout << "Enter color" << endl;
	cin >> color;
	ModelWindow window(name, x, y, horizontal, vertical, color, true, true);

	int k;
	int tmp;
	while (true)
	{
		system("pause");
		system("cls");
		cmd.Window_printer(window);
		cout << "1.Move Horizontaly" << endl;
		cout << "2.Move vertical" << endl;
		cout << "3.Change width" << endl;
		cout << "4.Change height" << endl;
		cout << "5.Change name" << endl;
		cout << "6.Change color" << endl;
		cout << "7.change vision " << endl;
		cout << "8.change panel vision" << endl;
		cout << "9.exit" << endl;
		cin >> k;
		switch (k)
			{
			case 1:
				cout << "Enter number to move(enter with minus for  backward move) " << endl;
				cin >> tmp;
				window.move_horizontal(tmp);
				break;
			case 2:
				cout << "Enter number to move(enter with minus for  backward move)" << endl;
				cin >> tmp;
				window.move_vertical(tmp);
				break;
			case 3:
				cout << "Enter number to change (enter with minus for  backward change)" << endl;
				cin >> tmp;
				window.change_width(tmp);
				break;
			case 4:
				cout << "Enter number to change (enter with minus for  backward change)" << endl;
				cin >> tmp;
				window.change_height(tmp);
				break;
			case 5:
				cout << "Enter new name" << endl;
				cin >> name;
				window.change_name(name);
				break;
			case 6:
				cout << "Enter new color" << endl;
				cin >> color;
				window.change_color(color);
				break;
			case 7:
				window.change_vision();
				break;
			case 8:
				window.change_panel();
				break;
			case 9:
				return;
			default:
				break;
			}
		
	}

}
int main()
{
	cout << boolalpha;
	int k;
	while (true)
	{
		cout << "1.Complex" << endl;
		cout << "2.3DVector" << endl;
		cout << "3.Window" << endl;
		cout << "4.exit" << endl;
		cin >> k;
		switch (k)
		{
		case 1:
			complex_ex();
			break;
		case 2:
			Vector_ex();
			break;
		case 3:
			Window_ex();
			break;
		case 4:
			return 0;

		default:
			break;
		}
	}
	
	
	
	
	
}

