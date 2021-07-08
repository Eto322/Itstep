

#include<iostream>


using namespace std;
template<class T>
class Queue
{
public:
	Queue(int in_size=10):
		_size{ in_size },
		_arr{ new T [_size] },
		_count{ 0 }
	{};
	
	bool is_full();
	bool is_empty();
	void clear();
	void Enqueue(T);
	T Dequeue();
	int get_count();
	void show();

	~Queue()
	{
		delete[] _arr;
	}
private:
	int _size;
	T*_arr;
	int _count;
};






template<class T>
bool Queue<T>::is_full()
{
	return _count==_size;
}

template<class T>
bool Queue<T>::is_empty()
{
	return _count==0;
}

template<class T>
void Queue<T>::clear()
{
	_count = 0;
}

template<class T>
void Queue<T>::Enqueue(T value)
{
	if (!is_full())
	{
		_arr[_count++] = value;
	}
	
}
	

template<class T>
T Queue<T>::Dequeue()
{
	if (!is_empty())
	{
		T first = _arr[0];

		for (int i = 1; i < _count; i++)
		{
			_arr[i - 1] = _arr[i];
		}
		
		_count--;
		
		return first;
	}
	return 1;
}

template<class T>
int Queue<T>::get_count()
{
	return _count;
}

template<class T>
void Queue<T>::show()
{
	for (int i = 0; i < _count; i++)
	{
		cout << _arr[i] << " ";
	}
}


int main()
{
	Queue<int> tmp;
	int k;
	int value;
	while (true)
	{	
		system("pause");
		system("cls");
		tmp.show();
		cout << endl;
		cout << "1.add" << endl;
		cout << "2.remove " << endl;
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
			cout << tmp.Dequeue() << " out" << endl;
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
