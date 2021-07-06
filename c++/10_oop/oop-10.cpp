#include <iostream>
#include <string>
#include <ctime>
using namespace std;


template<class T>

class Stack
{
public:
	void push(T);
	T pop();
	T peek();
	void clear();
	bool is_empty();
	bool is_full();
	int get_count();
	
private:
	T _arr[50];
	int _ptr=-1;
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
		cout << "cannot push stack full" << endl;
	}
}



template<>
void Stack<char>::push(char value)
{
	if (!is_full())
	{
		
		_arr[++_ptr] = value;

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
	cout << "cannot pop stack is empty" << endl;
	return -1;
}



template<>
char Stack<char>::pop()
{
	if (!is_empty())
	{
		
		return _arr[_ptr--];
	}
	
}

template<class T>
T Stack<T>::peek()
{
	if (!is_empty())
	{
		cout << "peek" << endl;
		return _arr[_ptr];
	}
	cout << "cannot peek ,stack empty" << endl;
	return -1;
}

template<class T>
void Stack<T>::clear()
{	cout<<"Stack cleared"<<endl;
	_ptr = -1;
}

template<class T>
bool Stack<T>::is_empty()
{
	return _ptr==-1;
}

template<class T>
bool Stack<T>::is_full()
{
	return _ptr==50-1;
}

template<class T>
int Stack<T>::get_count()
{
	return _ptr+1;
}



void ex1()
{
	Stack<int> tmp;
	int k;
	int value;
	while (true)
	{	

		system("pause");
		system("cls");
		
		cout << "1.push number" << endl;
		cout << "2.pop last" << endl;
		cout << "3.get count" << endl;
		cout << "4.clear stack" << endl;
		cout << "5.peek on last" << endl;
		cout << "6. exit" << endl;
		cin >> k;

		switch (k)
		{
		case 1:
			cout << "Enter value" << endl;
			cin >> value;
			tmp.push(value);
			break;
		case 2:
			tmp.pop();
			break;
		case 3:
			cout <<"count: "<< tmp.get_count() << endl;
			break;
		case 4:
			tmp.clear();
			break;
		case 5:
			cout << tmp.peek() << endl;
			break;
		case 6:
			return;
			break;
		default:
			break;
		}

	}
}
void ex2()
{
	Stack<char> tmp;
	string word;
	cout << "Enter word" << endl;
	getline(cin, word);
	for (int i = 0; i < word.length(); i++)
	{
		tmp.push(word[i]);
	}

	for (int i = 0; i < word.length(); i++)
	{
		cout << tmp.pop();
	}
}
void ex3()
{
	Stack<char> tmp;
	string word;
	cout << "Enter brackets" << endl;
	getline(cin, word);

	for (int i = 0; i < word.length(); i++)
	{
		tmp.push(word[i]);
	}
	int counter = 0;
	char bracket;
	for (int i = 0; i < word.length(); i++)
	{
		bracket = tmp.pop();
		if (bracket ==')')
		{
			counter++;
		}
		if (bracket =='(')
		{
			counter--;
			if (counter<0)
			{
				cout << "not ok" << endl;
				return;
			}
		}
	}

	if (counter==0)
	{
		cout << "ok" << endl;
	}
	else
	{
		cout << "not ok" << endl;
	}

}


int main()
{
	cout << "EX 1" << endl;
	ex1();
	cin.ignore();
	cout << "EX 2" << endl;
	ex2();
	cout << endl;
	cout << "EX 3" << endl;
	ex3();
}