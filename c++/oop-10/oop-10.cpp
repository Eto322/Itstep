

#include<iostream>

using namespace std;

template <class T>

class NotVector
{
public:
	NotVector():
		_array{ nullptr },
		_size{ 0 }
	{};
	NotVector(int size):
		_array{ new T[size] },
		_size{ size }
	{};
	
	NotVector(const NotVector& tmp)//copy construct
	{
		_size = tmp._size;
		_array = new T[_size];
		
	}

	void add_to_end(T);
	void del_element(int);
	int find_element(T);
	void bubble_sotr();
	
	
	void out_array();
	void operator+(NotVector&);
	T get_element(int);

	void fill_arr();
	int get_size();
	~NotVector();

private:
	T* _array;
	int _size;
};


int main()
{
	srand(time(0));

	



}

template<class T>
void NotVector<T>::add_to_end(T value)
{
	T* tmp = new T[_size + 1];
	for (int i = 0; i < _size; i++)
	{
		tmp[i] = _array[i];
	}
	tmp[_size] = value;
	_size++;
	delete[] _array;
	_array = tmp;

}

template<class T>
void NotVector<T>::del_element(int index)
{
	T* tmp = new T[_size - 1];
	int j=0;
	for (int i = 0; i < _size; i++)
	{
		if (i!=index)
		{
			tmp[j] = _array[i];
			j++;
		}
	}
	delete[] _array;
	_size--;
	_array = tmp;
}

template<class T>
int NotVector<T>::find_element(T value)
{
	for (int i = 0; i < _size; i++)
	{
		if (_array[i]==value)
		{
			return i;
		}
	}
	return -1;
}

template<class T>
void NotVector<T>::bubble_sotr()
{
	
	T tmp; 
	for (int i = 0; i < _size-1; i++)
	{
		for (int j = 0; j < _size-i-1; j++)
		{
			if (_array[j]>_array[j+1])
			{
				tmp = _array[j];
				_array[j] = _array[j + 1];
				_array[j + 1] = tmp;
			}
		}
	}
}

template<class T>
void NotVector<T>::out_array()
{
	for (int i = 0; i < _size; i++)
	{
		cout << _array[i] << " ";
	}
	cout << endl;
}

template<class T>
void NotVector<T>::operator+(NotVector&tmp)
{
	T*tmp1 = new T[tmp.get_size() + _size];
	for (int i = 0; i < _size; i++)
	{
		tmp1[i] = _array[i];

	}
	for (int i = 0; i < tmp.get_size(); i++)
	{
		tmp1[i+_size] = tmp.get_element(i);
	}
	_size += tmp.get_size();
	delete[] _array;
	_array = tmp1;

}

template<class T>
T NotVector<T>::get_element(int index)
{
	return _array[index];
}

template<class T>
void NotVector<T>::fill_arr()
{
	
	for (int i = 0; i < _size;i++)
	{
		_array[i] = rand() % 10;
	}
}



template<class T>
int NotVector<T>::get_size()
{
	return _size;
}

template<class T>
NotVector<T>::~NotVector()
{
	delete[] _array;
}



