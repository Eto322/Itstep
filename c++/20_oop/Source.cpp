#include <iostream>
#include <fstream>

#include <string>

using namespace std;


class Shape
{
public:

	virtual void show() = 0;
	virtual void load() = 0;
	virtual void save() = 0;
	void for_array()
	{
		return;
	}


protected:
	fstream file;
};


class Square :public Shape
{
public:
	Square(float x = -1, float y = -1, float lenght = -1) :
		_x{ x },
		_y{ y },
		_lenght{ lenght }
	{};
	void save() override
	{
		file.open("square.bin", fstream::out);
		file << _x << " " << _y << " " << _lenght;
		file.close();
	}

	void load() override
	{
		file.open("square.bin", fstream::in);
		if (!file)
		{
			exit(-1);
		}

		file >> _x >> _y >> _lenght;

		file.close();
	}

	void show() override
	{
		cout << " Square" << endl;
		cout << "X position " << _x << endl;
		cout << "Y position " << _y << endl;
		cout << "lenght " << _lenght << endl;
	}

private:

	float _x;
	float _y;
	float _lenght;
};

class Rectangle :public Shape
{
public:
	Rectangle(float x = -1, float y = -1, float vertical = -1, float horizontal = -1) :
		_x{ x },
		_y{ y },
		_vertical_lenght{ vertical },
		_horizontal_lenght{ horizontal }
	{};

	void save() override
	{
		file.open("rectangle.bin", fstream::out);
		file << _x << " " << _y << " " << _vertical_lenght << " " << _horizontal_lenght;
		file.close();
	}

	void load() override
	{
		file.open("rectangle.bin", fstream::in);
		if (!file)
		{
			exit(-1);
		}

		file >> _x >> _y >> _vertical_lenght >> _horizontal_lenght;

		file.close();
	}

	void show() override
	{
		cout << "Rectangle" << endl;
		cout << "X position " << _x << endl;
		cout << "Y position " << _y << endl;
		cout << "horizontal lenght " << _horizontal_lenght << endl;
		cout << "vertical lenght " << _vertical_lenght << endl;
	}

protected:

	float _x;
	float _y;
	float _vertical_lenght;
	float _horizontal_lenght;

};

class Circle :public Shape
{
public:
	Circle(float x = -1, float y = -1, float radius = -1) :
		_x{ x },
		_y{ y },
		_radius{ radius }
	{};

	void save() override
	{
		file.open("circle.bin", fstream::out);
		file << _x << " " << _y << " " << _radius;
		file.close();
	}

	void load() override
	{
		file.open("circle.bin", fstream::in);
		if (!file)
		{
			exit(-1);
		}

		file >> _x >> _y >> _radius;

		file.close();
	}

	void show() override
	{
		cout << "Circle" << endl;
		cout << "X position " << _x << endl;
		cout << "Y position " << _y << endl;
		cout << "radius  " << _radius << endl;

	}

private:

	float _x;
	float _y;
	float _radius;

};



class Elipse :public Rectangle
{
public:
	Elipse(float x = -1, float y = -1, float vertical = -1, float horizontal = -1) :
		Rectangle(x, y, vertical, horizontal)
	{};

	void save() override
	{
		file.open("elipse.bin", fstream::out);
		file << _x << " " << _y << " " << _vertical_lenght << " " << _horizontal_lenght;
		file.close();
	}

	void load() override
	{
		file.open("elipse.bin", fstream::in);
		if (!file)
		{
			exit(-1);
		}

		file >> _x >> _y >> _vertical_lenght >> _horizontal_lenght;

		file.close();
	}

	void show() override
	{
		cout << "Elipse" << endl;
		cout << "X position " << _x << endl;
		cout << "Y position " << _y << endl;
		cout << "horizontal lenght " << _horizontal_lenght << endl;
		cout << "vertical lenght " << _vertical_lenght << endl;
	}

};



int main()
{

	Shape** a = new Shape * [4];
	a[0] = new Square(1, 2, 3);
	a[1] = new Rectangle(1, 2, 3, 4);
	a[2] = new Circle(1, 2, 3);
	a[3] = new Elipse(1, 2, 3, 4);
	cout << "Save to file" << endl;
	a[0]->save();
	a[1]->save();
	a[2]->save();
	a[3]->save();
	cout << "Load from file" << endl;
	a[0]->load();
	a[1]->load();
	a[2]->load();
	a[3]->load();
	cout << "Show" << endl;
	a[0]->show();
	a[1]->show();
	a[2]->show();
	a[3]->show();

	for (int i = 0; i < 4; i++)
	{
		delete[] a[i];
	}
	delete[] a;

}
