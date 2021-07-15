#include <iostream>

using namespace std;

class Printer;

struct Node {
	Node* next = nullptr;
	Node* prev = nullptr;
	int value;
	Node(int value = 0) : 
		value{ value } 
	{}
};

class List {
public:
	List() :
		_phead{ nullptr },
		_ptail{ nullptr }
	{}

	

	void add_head(int value)
	{
		if (_phead)
		{
			Node* tmp = new Node(value);

			tmp->next = _phead;
			_phead->prev = tmp;
			_phead = tmp;
		}
		else
		{
			_phead = new Node(value);
			_ptail = _phead;
		}
	}

	void add_tail(int value)
	{
		if (_ptail)
		{
			Node* tmp = new Node(value);

			tmp->prev = _ptail;
			_ptail->next = tmp;
			_ptail = tmp;
		}
		else
		{
			_phead = new Node(value);
			_ptail = _phead;
		}
	}



	

	void insert(int value, int index) {
		Node* new_node = new Node(value);
		if (index == 0)
		{
			new_node->next = _phead;
			_phead->prev = new_node;
			_phead = new_node;
		}
		else 
		{
			Node* tmp = _phead;
			for (auto i = 0; i < index - 1; i++) {
				tmp = tmp->next;
			}

			new_node->next = tmp->next;
			tmp->next->prev = new_node;
			tmp->next = new_node;
			new_node->prev = tmp;
		}
	}

	const int get_count()
	{
		int count = 0;
		Node* tmp = _phead;
		while (tmp)
		{
			count++;
			tmp = tmp->next;
		}
		return count;
	}

	

	Node* Get_node(int index)
	{

		if (get_count()-1>=index)
		{
			Node* tmp = _phead;

			for (int i = 0; i < index; i++)
			{
				tmp = tmp->next;
			}
			return tmp;
		}
		else
		{
			
			
			return nullptr ;
		}
		
	}

	void clear()
	{
		Node* ptr = _phead;
		while (_phead)
		{	
			_phead = _phead->next;
			delete ptr;
			ptr = _phead;
		}
		_ptail = nullptr;
	}

	int del(int index = 0)
	{
		int value;
		if (get_count() - 1 >= index)
		{
			if (get_count()==1&& index == 0)
			{
				Node* tmp = _phead;
				_phead = nullptr;
				
				value = tmp->value;
				delete tmp;
				return value;
			}

			if (index==0)
			{
				Node* tmp = _phead;
				_phead = _phead->next;
				_phead->prev = nullptr;
				value = tmp->value;
				delete tmp;
				return value;

			}
			else if(get_count()-1==index)
			{
				Node* tmp = _ptail;
				_ptail = _ptail->prev;
				_ptail->next = nullptr;
				value = tmp->value;
				delete tmp;
				return value;
			}
			else
			{
				Node* tmp = _phead;
				for (int i = 0; i < index; i++)
				{
					tmp = tmp->next;
				}
				tmp->prev->next = tmp->next;
				tmp->next->prev = tmp->prev;
				value = tmp->value;
				delete tmp;
				return value;
			}
			
		}
		else
		{
			return -1;
		}
	}

	List(const List& ls)
	{

		Node* tmp_ls = ls._phead;
		
		this->add_head(ls._phead->value);
		tmp_ls=tmp_ls->next;
		while (tmp_ls)
		{
			this->add_tail(tmp_ls->value);
			tmp_ls = tmp_ls->next;
		}
		
	}


	~List() {
		clear();
	}

	friend Printer;
private:
	Node* _phead;
	Node* _ptail;
};

class List_stack
{
public:
	
	
	void Push(int value)
	{
		_ls.add_head(value);
		_count++;
	}

	int Pop()
	{
		if (_count>0)
		{
			_count--;
		}
		return _ls.del();
		
	}

	void clear()
	{
		_ls.clear();
		_count = 0;
	}

	bool is_empty()
	{
		if (_ls.get_count()>0)
		{
			return true;
		}
		return false;
	}
	int get_count()
	{
		return _count;
	}

	friend Printer;
	

private:
	int _count = 0;
	List _ls;
};


class Printer {
public:

	static void print_list(List &ls)
	{
		Node* tmp = ls._phead;
		int count = 0;
		while (tmp)
		{
			cout << "Node " << count++ << endl;
			cout << tmp->value << endl;
			tmp = tmp->next;
		}
	}

	static void print_list_pos(List& ls, int index)
	{
		if (ls.get_count() - 1 >= index)
		{
			Node* tmp = ls._phead;
			for (int i = 0; i < index; i++)
			{
				tmp = tmp->next;
			}
			cout << "Node " << index << endl;
			cout << tmp->value << endl;
		}
		else
		{
			cout << "idex out of range" << endl;
		}
	}

	static void print_stack(List_stack& ls)
	{
		Node* tmp = ls._ls._phead;
		int count = 0;
		while (tmp)
		{
			cout << "Node " << count++ << endl;
			cout << tmp->value << endl;
			tmp = tmp->next;
		}
	}
};

void ex1()
{
	
	int k;
	int index;
	int value;
	List ls;
	Printer cmd;
	while (true)
	{
		system("pause");
		system("cls");
		cout << "List" << endl;
		cout << "1.add to head" << endl;
		cout << "2.add to tail" << endl;
		cout << "3.del element" << endl;
		cout << "4.del element(0 index)" << endl;
		cout << "5.clear" << endl;
		cout << "6.out element" << endl;
		cout << "7.out all" << endl;
		cout << "8.get count" << endl;
		cin >> k;

		switch (k)
		{
		case 1:
			cout << "enter value to add " << endl;
			cin >> value;
			ls.add_head(value);
			break;
		case 2:
			cout << "enter value to add " << endl;
			cin >> value;
			ls.add_tail(value);
			break;
		case 3:
			cout << "enter idex to delete" << endl;
			cin >> index;
			ls.del(index);
			break;
		case 4:
			ls.del();
			break;
		case 5:
			ls.clear();
			break;
		case 6:
			cout << "enter index to out" << endl;
			cin >> index;
			cmd.print_list_pos(ls, index);
			break;
		case 7:
			cmd.print_list(ls);
			break;
		case 8:
			cout << ls.get_count();
			break;

		default:
			break;
		}
		

	}
}
void ex2()
{
	int k;
	int value;
	List_stack ls;
	Printer cmd;
	while (true)
	{
		system("pause");
		system("cls");
		cout << "Stack_list" << endl;
		cout << "1.push" << endl;
		cout << "2.pop" << endl;
		cout << "3.is_empty" << endl;
		cout << "4.get_count" << endl;
		cout << "5.clear" << endl;
		cout << "6.out stack" << endl;
		cin >> k;

		switch (k)
		{
		case 1:
			cout << "enter value to add " << endl;
			cin >> value;
			ls.Push(value);
			break;
		case 2:
			cout<<ls.Pop();
			break;
		case 3:
			cout << ls.is_empty();
			break;
		case 4:
			cout << ls.get_count();
			break;
		case 5:
			ls.clear();
			break;
		case 6:
			
			cmd.print_stack(ls);
			break;
		

		default:
			break;
		}


	}

}
void main() {
	
	cout << "Select ex" << endl;
	cout << "1.ex1\n" << "2.ex2\n" << endl;
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