/*�������� ����� ������������� �������, � ������� ����������� �������� ������ ��
������� �������. ����������� ���������: [ ], =, +, -,++ (���������� �������� � �����
�������), -- (�������� �������� �� ����� �������)*/

#include<iostream>

using namespace std;

class NotVector
{
public:
	NotVector();
	NotVector(int*, int);
	int& operator[](int );
	
	NotVector& operator=(const NotVector&);
	NotVector& operator+(int);
	NotVector& operator-(int);
	NotVector& operator--(int);
	NotVector& operator++(int);
	
	void create_arr();
	void delete_arr();
	int get_size();
	int*get_array();
	~NotVector();

private:
	int* _array;
	int _size;
};

class Printer
{
public:
	Printer();
	~Printer();
	void NotVector_printer(NotVector& tmp)
	{
		for (int i = 0; i < tmp.get_size(); i++)
		{
			cout << tmp.get_array()[i] << " ";
		}
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

NotVector::NotVector()
{
	_array = nullptr;
	_size = 0;
}

NotVector::NotVector(int* tmp, int tmp_size)
{
	_size = tmp_size;
	_array = new int[_size];

	for (int i = 0; i < _size; i++)
	{
		_array[i] = tmp[i];
	}

}

int& NotVector::operator[](int i)
{
	if (i>=_size)
	{
		throw exception("Out of index");
	}
	return _array[i];
}

NotVector& NotVector::operator=(const NotVector& tmp)
{
	delete_arr();

	_size = tmp._size;
	_array = new int[_size];
	for (int i = 0; i < _size; i++)
	{
		_array[i] = tmp._array[i];
	}
	return *this;


}

NotVector& NotVector::operator+(int tmp)
{
	int* tmp_arr = new int[_size+tmp];
	for (int i = 0; i < _size; i++)
	{
		tmp_arr[i] = _array[i];
	}
	delete_arr();
	
	for (int i = _size; i <_size+tmp ; i++)
	{
		tmp_arr[i] = tmp;
	}
	_size+=tmp;
	_array = tmp_arr;
	return *this;

}

NotVector& NotVector::operator-(int tmp)
{	
	if (tmp>_size)
	{
		delete[] _array;
		_array = nullptr;
		_size = 0;
		return *this;
	}
	else
	{
		int* tmp_arr = new int[_size - tmp];
		for (int i = 0; i < _size-tmp; i++)
		{
			tmp_arr[i] = _array[i];
		}
		delete_arr();
		_size -= tmp;
		_array = tmp_arr;
		return *this;
	}

}

NotVector& NotVector::operator--(int)
{
	if (_size==1)
	{
		delete_arr();
		_size = 0;
		_array = nullptr;
		return *this;
	}
	else if (_array==nullptr)
	{
		return *this;
	}
	else
	{
		int* tmp_arr = new int[_size-1];
		
		for (int i = 0; i < _size-1; i++)
		{
			tmp_arr[i] = _array[i];
		}
		_size--;
		delete_arr();
		_array = tmp_arr;
		return *this;
	}
	
	
}



NotVector& NotVector::operator++(int)
{
	if (_array==nullptr)
	{
		_size = 1;
		_array = new int[_size];
		_array[0] = 0;
		return *this;
	}
	else
	{
		int* tmp_arr = new int[_size + 1];
		for (int i = 0; i < _size; i++)
		{
			tmp_arr[i] = _array[i];
		}
		delete_arr();

		
		_size++;
		_array = tmp_arr;
		return *this;


	}
}



void NotVector::create_arr()
{
	
	cout << "Enter size of  array" << endl;
	cin >> _size;
	_array = new int[_size];
	for (int i = 0; i < _size; i++)
	{
		cout << "Enter " << i << " element " << endl;
		cin >> _array[i];


	}
}

void NotVector::delete_arr()
{
	if (_array==nullptr)
	{

	}
	else
	{
		delete[] _array;
	}
}



int NotVector::get_size()
{
	return _size;
}

int* NotVector::get_array()
{
	return _array;
}

NotVector::~NotVector()
{
	delete[] _array;
}
void index_work(int& tmp)
{
	cout << "Select operation" << endl;
	cout << tmp << endl;
	cout << "1.+" << endl;
	cout << "2.-" << endl;
	cout << "3.set" << endl;
	int tmp1;
	int k;
	cin >> k;
	switch (k)
	{
	case 1:
		cout << "enter number to add" << endl;
		cin >> tmp1;
		tmp + tmp1;
		return;
	case 2:
		cout << "enter number to sub" << endl;
		cin >> tmp1;
		tmp - tmp1;
		return;
	case 3:
		cout << "enter number to set" << endl;
		cin >> tmp1;
		tmp =tmp1;
		return;
	default:
		break;
	}
}

int main()
{
	
	int k;
	int tmp;
	NotVector arr1;
	NotVector arr2;
	arr2.create_arr();
	Printer cmd;
	while (true)
	{


		system("cls");
		system("pause");
		cout << "Array 1: ";
		cmd.NotVector_printer(arr1);
		cout << "Array 2: ";
		cmd.NotVector_printer(arr2);
		


		cout << "1.+" << endl;
		cout << "2.-" << endl;
		cout << "3.++" << endl;
		cout << "4.--" << endl;
		cout << "5.[]" << endl;
		cout << "6.=" << endl;
		cin >> k;

		switch (k)
		{

		case 1:
			cout << "Enter number to add" << endl;
			cin >> tmp;
			arr1 + tmp;
			break;
		case 2:
			cout << "Enter number to sub" << endl;
			cin >> tmp;
			arr1 - tmp;
			break;
		case 3:
			arr1++;
			break;
		case 4: 
			arr1--;
			break;
		case 5:
			cout << "Enter index of array" << endl;
			cin >> tmp;
			index_work(arr1[tmp]);
			break;
		case 6:
			arr1 = arr2;
			break;

		default:
			break;
		}

	}
	
	

}