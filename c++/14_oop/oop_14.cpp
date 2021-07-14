#include <iostream>

using std::cout;
using std::cin;
using std::endl;

struct Node {
	Node* next = nullptr;
	int value;
	Node(int value = 0) :
		value{ value } 
	{};
};


class List {
public:
	List() :
		_head{ nullptr },
		_tail{ nullptr } 
	{};

	~List() {
		while (_head != nullptr) 
		{
			Node* tmp = _head;
			_head = _head->next;
			delete tmp;
		}
	}
	void add(int value) 
	{
		Node* tmp = new Node(value);
		if (_head == nullptr) 
		{
			_head = _tail = tmp;
		}
		else 
		{
			_tail->next = tmp;
			_tail = tmp;
		}
	}

	int remove(int index) 
	{
		int value;
		if (this->count_index() < index)
		{
			return-1;
		}

		if (index == 0) 
		{
			Node* tmp = _head;
			value = _head->value;
			_head = _head->next;
			delete tmp;
			return value;
		}
		else 
		{
			Node* tmp = _head;
			for (auto i = 0; i < index - 1; i++) {
				tmp = tmp->next;
			}
			Node* tmp_remove = tmp->next;
			tmp->next = tmp_remove->next;
			value = tmp_remove->value;
			delete tmp_remove;
			return value;
		}
	}

	void insert(int value, int index) {
		if (this->count_index()<index)
		{
			return;
		}
		
		Node* new_node = new Node(value);
		if (index == 0) {
			new_node->next = _head;
			_head = new_node;
		}
		else {
			Node* tmp = _head;
			for (auto i = 0; i < index - 1; i++) 
			{
				tmp = tmp->next;
			}
			new_node->next = tmp->next;
			tmp->next = new_node;
		}
	}

	

	int find_index(int value) 
	{
		Node* tmp = _head;
		int i= 0;
		while (tmp != nullptr) 
		{
			if (tmp->value == value) 
			{
				return i;
			}
			tmp = tmp->next;
			i++;
		}
		return -1;
	}

	void out_list()
	{
		Node* tmp = _head;
		int i=0;
		while (tmp!=nullptr)
		{
			cout << "Node#" << i++ << endl;
			cout << tmp->value;
			cout << endl;
			tmp = tmp->next;

		}
	}

	int count_index()
	{
		Node* tmp = _head;
		int i = -1;
		
		while (tmp!=nullptr)
		{
			
			i++;
			tmp = tmp->next;
		}
		return i;
	}

	

private:
	Node* _head;
	Node* _tail;
};

class Queue_list
{
public:


	void clear()
	{
		for (int i = 0; i <_count; i++)
		{
			_ls.remove(0);
			
		}
		_count = 0;
	}
	void Enqueue(int value)
	{
		_ls.add(value);
		_count++;
	}
	int Dequeue()
	{
		int value;
		value=_ls.remove(_count-1);
		_count--;
		return value;
	}
	int get_count()
	{
		return _count;
	}
	void show()
	{	
		_ls.out_list();
		
	}

private:
	List _ls;
	int _count=0;
};

void ex2()
{
	int k;
	int value;
	int index;
	Queue_list ls;
	while (true)
	{
		system("pause");
		system("cls");
		cout << "Queue List" << endl;
		cout << "1.Enqueue" << endl;
		cout << "2.Dequeue " << endl;
		cout << "3.get count" << endl;
		cout << "4.clear" << endl;
		cout << "5.show queue" << endl;
		cin >> k;

		switch (k)
		{
		case 1:
			cout << "Enter value" << endl;
			cin >> value;
			ls.Enqueue(value);
			break;
		case 2:
			
			cout << ls.Dequeue() << endl;

			break;
		case 3:
		
			cout << ls.get_count() << endl;
			break;
		case 4:
			ls.clear();
			break;

		case 5:
			ls.show();
			break;

		default:
			break;
		}


	}
}

void ex1()
{
	int k;
	List ls;
	int value;
	int index;
	while (true)
	{
		system("pause");
		system("cls");
		cout << "List" << endl;
		cout << "1.add" << endl;
		cout << "2.insert " << endl;
		cout << "3.remove" << endl;
		cout << "4.search elment" << endl;
		cout << "5.out list" << endl;
		cin >> k;

		switch (k)
		{
		case 1:
			cout << "Enter value" << endl;
			cin >> value;
			ls.add(value);
			break;
		case 2:
			cout << "Enter value" << endl;
			cin >> value;
			cout << "Enter index" << endl;
			cin >> index;
		
			ls.insert(value, index);
			break;
		case 3:
			cout << "Enter index" << endl;
			cin >> index;
			cout<<ls.remove(index);
			
			break;
		case 4:
			cout << "Enter value to search" << endl;
			cin >> value;
			cout << ls.find_index(value) << endl;
			break;

		case 5:
			ls.out_list();
			break;

		default:
			break;
		}


	}
	

}

int main()
{
	cout << "select ex " << endl;
	cout << "1.Ex1\n2.Ex2" << endl;
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