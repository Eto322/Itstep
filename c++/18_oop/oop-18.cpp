#include<iostream>

using namespace std;

class  Transport
{
public:
	Transport(int speed, int price, int capacity) :
	_speed { speed },
	_price_per_hour { price },
	_capacity { capacity }
	{};

	void out_data(int time)
	{
		cout << "speed " << _speed << endl;
		cout << "Price per hour " << _price_per_hour  << endl;
		cout << "capacity " << _capacity << endl;
		cout << "Calculated Price " << (_price_per_hour * time) << endl;
		cout << endl;
	}
	

private:
	int _speed;
	int _price_per_hour;
	int _capacity;
};



class Bike:public Transport
{
public:
	Bike( int price, int capacity=2,int speed = 10 ) :
		Transport(speed, price, capacity)
	{};
	
	



};

class Carriage :public Transport
{
public:
	Carriage( int price, int capacity=5, int speed = 15) :
		Transport(speed, price, capacity)
	{};
};

class Wheel
{public:
	Wheel(int size) :
		_size{ size }
	{};

protected:
	int _size;
};

class Door
{
public:
	Door(int size):
	_size { size }
	{};

protected:
	int _size;
};

class Engine
{
public :
	Engine(int size):
		_size{ size }
	{};
protected:
	int _size;
};


class Automobile :public Transport,public Wheel,public Door,public Engine
{
public:
	Automobile(int wheel_size,int door_size,int engine_size, int price, int speed, int capacity = 4) :
		Transport(speed, price, capacity),
		Wheel(wheel_size),
		Door(door_size),
		Engine(engine_size)
	{};

	void info()
	{
		cout << "wheel size " << Wheel::_size << endl;
		cout << "door size " << Door::_size << endl;
		cout << "engine size " << Engine::_size << endl;
	}



};





int main()
{
	Automobile avto( 10,20,30, 50, 60 );
	Bike bike(15);
	Carriage carrige(10);
	cout << "First ex" << endl;
	cout << "avto" << endl;
	avto.out_data(10);
	cout << "bike" << endl;
	bike.out_data(40);
	cout << "carrige" << endl;
	carrige.out_data(25);
	cout << "Second ex" << endl;
	avto.info();
}