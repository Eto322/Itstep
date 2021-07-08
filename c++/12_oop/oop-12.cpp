

#include<iostream>
#include<ctime>

using namespace std;





template<class T>
class Circular_queue
{
public:
	Circular_queue(int in_size = 10) :
		_size{ in_size },
		_arr{ new T[_size] },
		_count{ 0 }
	{};

	bool is_full();
	bool is_empty();
	void clear();
	void Enqueue(T);
	T Dequeue();
	int get_count();
	void show();

	~Circular_queue()
	{
		delete[] _arr;
	}
private:
	int _size;
	T* _arr;
	int _count;
};






template<class T>
bool Circular_queue<T>::is_full()
{
	return _count == _size;
}

template<class T>
bool Circular_queue<T>::is_empty()
{
	return _count == 0;
}

template<class T>
void Circular_queue<T>::clear()
{
	_count = 0;
}

template<class T>
void Circular_queue<T>::Enqueue(T value)
{
	if (!is_full())
	{
		_arr[_count++] = value;
	}

}


template<class T>
T Circular_queue<T>::Dequeue()
{
	if (!is_empty())
	{
		T first = _arr[0];

		for (int i = 1; i < _count; i++)
		{
			_arr[i - 1] = _arr[i];
		}

		_arr[_count-1] = first;

		return first;
	}
	
}

template<class T>
int Circular_queue<T>::get_count()
{
	return _count;
}

template<class T>
void Circular_queue<T>::show()
{
	for (int i = 0; i < _count; i++)
	{
		cout << _arr[i] << " ";
	}
}

class Slot_machine
{
public:
	Slot_machine();
	void roll();
	void fill();
	string is_win();
	void money_calculation();
	void show_slot();
	int get_money();
	~Slot_machine();

private:
	Circular_queue<string> slot_1;
	Circular_queue<string> slot_2;
	Circular_queue<string> slot_3;
	
	string **_slot;
	int money;
};




Slot_machine::Slot_machine()
{
	money = 1000;
	
	for (int i = 0; i < 10; i++)
	{
		if (i<=4)
		{
			slot_1.Enqueue("berry");
			slot_2.Enqueue("berry");
			slot_3.Enqueue("berry");
		}

		if (i>4&&i<=7)
		{
			slot_1.Enqueue("fruits");
			slot_2.Enqueue("fruits");
			slot_3.Enqueue("fruits");
		}

		if (i>7&&i<9)
		{
			slot_1.Enqueue("bell");
			slot_2.Enqueue("bell");
			slot_3.Enqueue("bell");
		}

		if (i==9)
		{
			slot_1.Enqueue("seven");
			slot_2.Enqueue("seven");
			slot_3.Enqueue("seven");
		}
	}

	_slot = new string * [3];
	for (int i = 0; i < 3; i++)
	{
		_slot[i] = new string[3];
	}
	

}

void Slot_machine::roll()
{
	
		for (int i = 0; i < rand()%9; i++)
		{
			slot_1.Dequeue();
		}

		for (int i = 0; i < rand()%7; i++)
		{
			slot_2.Dequeue();
		}

		for (int i = 0; i < rand()%10; i++)
		{
			slot_3.Dequeue();
		}

	
}

void Slot_machine::fill()
{

	for (int i = 0; i < 3; i++)
	{
		roll();
		_slot[0][i] = slot_1.Dequeue();
	}

	for (int i = 0; i < 3; i++)
	{
		roll();
		_slot[1][i] = slot_2.Dequeue();
	}

	for (int i = 0; i < 3; i++)
	{
		roll();
		_slot[2][i] = slot_3.Dequeue();
	}


}

string Slot_machine::is_win()
{
	if (_slot[0][0]==_slot[0][1]&&_slot[0][0]==_slot[0][2])//-first line
	{
		return _slot[0][0];
	}

	if (_slot[1][0] == _slot[1][1] && _slot[1][0] == _slot[1][2])//-second line
	{
		return _slot[1][0];
	}

	if (_slot[2][0] == _slot[2][1] && _slot[2][0] == _slot[2][2])//-third line
	{
		return _slot[2][0];
	}

	if (_slot[0][0] == _slot[1][0] && _slot[0][0] == _slot[2][0])//first collum
	{
		return _slot[0][0];
	}

	if (_slot[0][1] == _slot[1][1] && _slot[0][1] == _slot[2][1])//second collum
	{
		return _slot[0][1];
	}

	if (_slot[0][2] == _slot[1][2] && _slot[0][2] == _slot[2][2])//third collum
	{
		return _slot[0][0];
	}

	if (_slot[0][0] == _slot[1][1] && _slot[0][0] == _slot[2][2])//first  oblique line
	{
		return _slot[0][0];
	}

	if (_slot[0][2] == _slot[1][1] && _slot[0][2] == _slot[2][0])//first  oblique line
	{
		return _slot[0][0];
	}

	return "lose";
	
}

void Slot_machine::money_calculation()
{
	if (is_win()=="berry")
	{
		money += 10;
	}
	if (is_win()=="fruits")
	{
		money += 20;
	}
	if (is_win()=="bell")
	{
		money += 50;
	}
	if (is_win()=="seven")
	{

		money += 100;
	}

	if (is_win()=="lose")
	{
		money -= 60;
	}
}

void Slot_machine::show_slot()
{
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			cout << _slot[i][j] << " ";
		}
		cout << endl;
	}
}

int Slot_machine::get_money()
{
	return money;
}

Slot_machine::~Slot_machine()
{
	for (int i = 0; i < 3; i++)
	{
		delete[] _slot[i];
	}

	delete[] _slot;
}

void kazinich()
{
	Slot_machine tmp;
	char k='0';
	while (k!='1'&&tmp.get_money()>0)
	{
		system("cls");
		cout << "KAZINICH Y ALEJIKA" << endl;
		tmp.show_slot();
		cout << endl;
		cout << "Money : " << tmp.get_money() << endl;
		cout << "Press enter to roll(enter 1 to exit)" << endl;
		k = cin.get();
		tmp.fill();
		tmp.money_calculation();
		
		
	}

	cout << "your win is " << tmp.get_money();

}

void ex1()
{
	Circular_queue<int> tmp;
	int k;
	int value;
	while (true)
	{
		system("pause");
		system("cls");
		tmp.show();
		cout << endl;
		cout << "1.add" << endl;
		cout << "2.dequeue " << endl;
		cout << "3.get count" << endl;
		cout << "4.clear" << endl;
		cin >> k;
		switch (k)
		{
		case 1:
			cout << "Enter value" << endl;
			cin >> value;
			tmp.Enqueue(value);
			break;
		case 2:
			cout << tmp.Dequeue() << " Dequeue" << endl;
			break;
		case 3:
			cout << "Count" << tmp.get_count() << endl;
			break;
		case 4:
			tmp.clear();
			break;
		default:
			break;
		}
	}
}
int main()
{
	srand(time(0));

	int k;
	cout << "select ex " << endl;
	cout << "1.ex1\n" << "2.Kazinich" << endl;
	
	cin >> k;

	if (k==1)
	{
		ex1();
	}

	if (k==2)
	{
		kazinich();
	}
	

}


