#include <iostream>
#include <string>
#include <ctime>

using namespace std;

template<class T>
struct Node 
{
	T value;
	int priority;

	void show();
	

	
};

template<class T>
class Priority_Queue 
{
public:
	Priority_Queue() : 
		_count { 0 }
	{};

	void clear()
	{
		_count = 0;
	}

	void show()
	{
		for (auto i = 0; i < _count; i++)
		{
			_arr[i].show();
		}
	}
	
	int get_count()
	{
		return _count;
	}

	bool is_full() 
	{
		return _count == 10;
	}

	bool is_empty()
	{
		return _count == 0;
	}

	void enqueue(T value, int priority)
	{
		if (!is_full()) {
			_arr[_count].value = value;
			_arr[_count].priority = priority;
			_count++;
		}
	}

	Node<T> dequeue() 
	{
		if (!is_empty()) {
			int tmp_i = 0;
			int tmp_priority = _arr[tmp_i].priority;

			for (auto i = 0; i < _count; i++) {
				if (tmp_priority < _arr[i].priority) {
					tmp_priority = _arr[i].priority;
					tmp_i = i;
				}
			}

			T tmp_value = _arr[tmp_i].value;

			for (auto i = tmp_i + 1; i < _count; i++) {
				_arr[i - 1] = _arr[i];
			}

			_count--;

			return { tmp_value, tmp_priority };
		}
		
		return  { NULL, -1 };
	}

	


	
	

private:
	Node<T> _arr[10];
	int _count;
};


void ex1()
{
	Priority_Queue<int> tmp;
	int k;
	int value, priority;
	while (true)
	{
		system("pause");
		system("cls");
		tmp.show();
		cout << endl;
		cout << "1.Add" << endl;
		cout << "2.Extract" << endl;
		cout << "3.Clear" << endl;
		cout << "4.Get_Count" << endl;
		cout << "5.exit" << endl;
		cin >> k;

		switch (k)
		{
		case 1:
			cout << "Enter value" << endl;
			cin >> value;
			cout << "enter priority" << endl;
			cin >> priority;
			tmp.enqueue(value, priority);
			break;
		case 2:
			tmp.dequeue().show();
			break;
		case 3:
			tmp.clear();
			break;
		case 4:
			cout << "Count: " << tmp.get_count() << endl;
			break;
		case 5:
			return;
		default:
			break;
		}
	}
}

void stat_priority(Node<string>*arr,int n)
{
	Node<string> tmp;
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = 0; j < n - i - 1; j++)
		{
			if (arr[j].priority < arr[j + 1].priority)
			{
				tmp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = tmp;
			}
		};
			
	};
		
}

void ex2()
{
	Priority_Queue<string> Printer;
	int k;
	int stat_count=0;
	int tmp_count;
	string in_string;
	int in_priority;
	Node<string> stat[50];
	Node<string> tmp;

	while (true)
	{
		system("pause");
		system("cls");
		cout << "1.Add new document on print" << endl;
		cout << "2.Print" << endl;
		cout << "3.Show waiting room" << endl;
		cout << "4.Get stat" << endl;
		cin >> k;
		cin.ignore();
		switch (k)
		{
		case 1:
			cout << "Enter name of document" << endl;
			getline(cin, in_string);
			cout << "Enter priority" << endl;
			cin >> in_priority;
			Printer.enqueue(in_string, in_priority);
			break;
		case 2:
			tmp_count = Printer.get_count();
			for (int i = 0; i <tmp_count; i++)
			{
				tmp = Printer.dequeue();
				tmp.show();
				stat[stat_count] = tmp;
				stat_count++;
			}
			break;
		case 3:
			Printer.show();
			break;
		case 4:
			cout << "Number of documents that print" << endl;
			cout << stat_count << endl;
			cout << "Documents that print (in priority order)" << endl;
			stat_priority(stat, stat_count);
			for (int i = 0; i < stat_count; i++)
			{
				stat[i].show();

			}
			break;

		default:
			break;
		}
	}
}
void main() {
	cout << "1.Ex1" << endl;
	cout << "2.Ex2" << endl;
	int k;
	cin >> k;
	if (k==1)
	{
		ex1();
	}
	else
	{
		ex2();
	}
}

template<>
void Node<int>::show()
{
	cout << "Value: " << value << endl;
	cout << "Priority: " << priority << endl;
}

template<>
void Node<string>::show()
{
	cout << "Name: " << value << endl;
	cout << "Priority: " << priority << endl;
}
