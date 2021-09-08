#include <iostream>
#include <string>

using namespace std;



class MyExpection :public exception
{
public:
	MyExpection(const char* massage) :
		exception{ massage }
	{};

	MyExpection(const char* massage, int date_state) :
		exception { massage },
		_date_state { date_state }
	{};

	int get_data()
	{
		return _date_state;
	}
	const char* what() const noexcept
	{
		cout << exception::what();
		if (_date_state)
		{
			cout << "Date: " << _date_state;
		}
		return"";
		
	}

private:
	int _date_state=NULL;
};

template<class T>
class Stack
{
public:
	void push(T);
	T pop();
	T peek();
	void fill();
	void clear();
	bool is_empty();
	bool is_full();
	int get_count();

private:
	T _arr[50];
	int _ptr = -1;
};



template<class T>
void Stack<T>::push(T value)
{
	if (!is_full())
	{
		cout << "push" << endl;
		_arr[++_ptr] = value;

	}
	else
	{
		throw MyExpection ("stack if full");
	}
}



template<>
void Stack<char>::push(char value)
{
	if (!is_full())
	{
		cout << "push" << endl;
		_arr[++_ptr] = value;

	}
	else
	{
		throw MyExpection("stack if full");
	}

}


template<class T>
T Stack<T>::pop()
{
	if (!is_empty())
	{
		cout << "pop" << endl;
		return _arr[_ptr--];
	}
	throw  MyExpection ("empty stack");
	
	
}



template<>
char Stack<char>::pop()
{
	if (!is_empty())
	{
		cout << "pop" << endl;
		return _arr[_ptr--];
	}
	throw  MyExpection ("empty stack");


}

template<class T>
T Stack<T>::peek()
{
	if (!is_empty())
	{
		cout << "peek" << endl;
		return _arr[_ptr];
	}
	throw exception("empty stack");
	
}

template<class T>
void Stack<T>::fill()
{
	for (int i = 0; i < 50; i++)
	{
		_arr[i] = i;
		_ptr++;
	}
}

template<class T>
void Stack<T>::clear()
{
	cout << "Stack cleared" << endl;
	_ptr = -1;
}

template<class T>
bool Stack<T>::is_empty()
{
	return _ptr == -1;
}

template<class T>
bool Stack<T>::is_full()
{
	return _ptr == 50 - 1;
}

template<class T>
int Stack<T>::get_count()
{
	return _ptr + 1;
}


double gerone_tringle(int a, int b, int c)
{
	if (a <= 0 || b <= 0 || c <= 0)
	{
		throw MyExpection ("the sides must be positive");
	}
	double p = (double)(a + b + c) / 2;
	return sqrt(p * (p - a) * (p - b) * (p - c));
}

int time_convertor(int hours, int minutes)
{
	if (hours<0||minutes<0)
	{
		throw MyExpection ("hours and minutes cannot be negative ");
	}
	return (hours * 3600) + (minutes * 60);
}


int palindrome(string value)
{
	if (size_t error = value.find_first_of("0123456789") ==true)
	{
		
		throw MyExpection ("word has a number or space value in ascii = ",value[error]);
	}
	for (int i = 0; i < value.length()/2; i++)
	{
		if (value[i]!=value[value.length()-i-1])
		{
				return false;
		}
	}
	return true;

	
}

int main()
{

	
	Stack <int>a;
	try
	{
		cout << "First.Ex" << endl;
		
		cout << "pop from empty stack" << endl;
		a.pop();
		
	}
	catch (const  MyExpection &er)
	{
		er.what();
	}
	
	
	
	try
	{
		cout << "pop form full stack" << endl;
		a.fill();
		a.pop();
		cout << "push to not full stack" << endl;
		a.push(1);
		cout << "push to full stack" << endl;
		a.push(2);
	}
	catch (const  MyExpection& er)
	{
		er.what();
	}
	

	

	
	try
	{
		cout << "Second ex" << endl;
		cout << "gerone tringel (3,4,5)" << endl;
		cout << gerone_tringle(3, 4, 5);
		cout << endl << "gerone tringel (-3,4,5)" << endl;
		cout << gerone_tringle(-3, 4, 5);

	}
	catch (const  MyExpection& er)
	{
		er.what();
	}


	try
	{
		
		cout << "Time convertor(1,58)" << endl;
		cout << time_convertor(1, 58);
		cout << endl << "Time convertor(-1,58)" << endl;
		cout << time_convertor(-1, 58);

	}
	catch (const  MyExpection& er)
	{
		er.what();
	}


	try
	{
	
		cout << "palindrome(pop)" << endl;
		cout << palindrome("asa") << endl;
		cout << "palindrome(a0a)" << endl;
		cout << palindrome("a0a") << endl;

	}
	catch (const  MyExpection& er)
	{
		er.what();
	}

	
}