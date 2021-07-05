/*Cоздать класс DynamicArray, который позволяет работать с одномерным
динамическим массивом. Реализовать:
- конструктор копирования
- метод для добавления элемента в массив
- метод для удаления элемента из массива
- метод для поиска элемента в массиве
- метод для сортировки массива
- метод для вывода массива на экран
- метод, который принимает объект класса DynamicArray и добавляет к текущему
массиву элементы массива переданного объекта.
- конструктор, деструктор*/

#include<iostream>

using namespace std;



class NotVector
{
public:
	NotVector() :
		_array{ nullptr },
		_size{ 0 }
	{};
	NotVector(int size) :
		_array{ new int[size] },
		_size{ size }
	{};

	NotVector(const NotVector& tmp)//copy construct
	{
		
		_size = tmp._size;
		_array = new int [_size];
		for (int i = 0; i < tmp._size; i++)
		{
			this->_array[i] = tmp._array[i];

		}

	}

	void add_to_end(int);
	void del_element(int);
	int find_element(int);
	void bubble_sotr();


	void out_array();
	void operator+(NotVector&);
	int get_element(int);

	void fill_arr();
	int get_size();
	~NotVector();

private:
	int* _array;
	int _size;
};




void NotVector::add_to_end(int value)
{
	int* tmp = new int [_size + 1];
	for (int i = 0; i < _size; i++)
	{
		tmp[i] = _array[i];
	}
	tmp[_size] = value;
	_size++;
	delete[] _array;
	_array = tmp;

}


void NotVector::del_element(int index)
{
	int* tmp = new int [_size - 1];
	int j = 0;
	for (int i = 0; i < _size; i++)
	{
		if (i != index)
		{
			tmp[j] = _array[i];
			j++;
		}
	}
	delete[] _array;
	_size--;
	_array = tmp;
}


int NotVector::find_element(int value)
{
	for (int i = 0; i < _size; i++)
	{
		if (_array[i] == value)
		{
			return i;
		}
	}
	return -1;
}


void NotVector::bubble_sotr()
{

	int tmp;
	for (int i = 0; i < _size - 1; i++)
	{
		for (int j = 0; j < _size - i - 1; j++)
		{
			if (_array[j] > _array[j + 1])
			{
				tmp = _array[j];
				_array[j] = _array[j + 1];
				_array[j + 1] = tmp;
			}
		}
	}
}


void NotVector::out_array()
{
	for (int i = 0; i < _size; i++)
	{
		cout << _array[i] << " ";
	}
	cout << endl;
}


void NotVector::operator+(NotVector& tmp)
{
	int* tmp1 = new int[tmp.get_size() + _size];
	for (int i = 0; i < _size; i++)
	{
		tmp1[i] = _array[i];

	}
	for (int i = 0; i < tmp.get_size(); i++)
	{
		tmp1[i + _size] = tmp.get_element(i);
	}
	_size += tmp.get_size();
	delete[] _array;
	_array = tmp1;

}


int NotVector::get_element(int index)
{
	return _array[index];
}


void NotVector::fill_arr()
{

	for (int i = 0; i < _size; i++)
	{
		_array[i] = rand() % 10;
	}
}




int NotVector::get_size()
{
	return _size;
}


NotVector::~NotVector()
{
	delete[] _array;
}

int main()
{ 
	srand(time(0));

	int tmp;
	cout << "Enter size of first array" << endl;
	cin >> tmp;
	NotVector first(tmp);
	first.fill_arr();
	NotVector second(first);
	
	int k;

	while (true)
	{	
		system("pause");
		system("cls");

		cout << "Arr 1: ";
		first.out_array();
		cout << "Arr 2: ";
		second.out_array();
		cout << "1.add element to the end" << endl;
		cout << "2.delete element " << endl;
		cout << "3.find element" << endl;
		cout << "4.sort Arr" << endl;
		cout << "5.add second arr to first" << endl;
		cout << "6.exit" << endl;
		cin >> k;
		switch (k)
		{
		case 1:
			cout << "Enter element to add" << endl;
			cin >> tmp;
			first.add_to_end(tmp);
			break;
		case 2:
			cout << "Enter index of element to delete" << endl;
			cin >> tmp;
			first.del_element(tmp);
			break;
		case 3:
			cout << "Enter element to search" << endl;
			cin >> tmp;
			cout<<first.find_element(tmp);
			break;
		case 4:
			first.bubble_sotr();
			break;

		case 5:
			first + second;
		default:
			return 0;
			break;
		}
	}
}

