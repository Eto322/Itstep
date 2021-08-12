#include <iostream>
#include <fstream>
#include <string>
using namespace std;

class File
{
public:
	File(string path)
	{
		file.open(path);
		if (!file)
		{
			cout << "Unable to find file" << endl;
			exit(-1);
		}
	}

	virtual void  show()
	{
		string line;
		while (getline(file,line))
		{
			cout << line << endl;;
		}
		file.seekg(0);
	}
	
	~File()
	{
		file.close();
	}

protected:
	ifstream file;
};

class File_ASCII : public File
{public:
	File_ASCII(string path) :
		File(path)
	{};
	void show() override
	{
		int x;
		string line;
		while (getline(file, line))
		{
			for (int i = 0; i < line.length(); i++)
			{
				x = line.at(i);
				cout << x<<" ";
			}
			cout << endl;
		}
		file.seekg(0);
	}

	~File_ASCII()
	{

	}
};

class File_Binary :public File
{public:
	File_Binary(string path):
		File { path }
	{};

	void show()override
	{
		bool flag = false;
		int x;
		
		string line;
		while (getline(file, line))
		{
			for (int i = 0; i < line.length(); i++)
			{	
				int* binary;
				x = line.at(i);
				binary = int_in_binary(x);
				for (int j = 9-1; j >=0; j--)
				{
					if (binary[j]==1||flag==true)
					{
						cout << binary[j];
						flag = true;
					}
					
				}
				flag = false;
				cout << " ";
				delete[]binary;
			}
			cout << endl;
		}
		file.seekg(0);
	}

	int* int_in_binary(int value)
	{
		int* binary = new int[9]{};
		int index = 0;
		while (value>0)
		{
			binary[index] = value % 2;
			value = value / 2;
			index++;
		}
		return binary;
	}

	~File_Binary()
	{

	}
};


int main()
{
	string path;
	cout << "enter file destenation" << endl;
	cin >> path;

	File** f = new File * [3];
	f[0] = new File(path);
	f[1] = new File_ASCII(path);
	f[2] = new File_Binary(path);
	
	
	cout << "1.read" << endl;
	f[0]->show();

	cout << "2.ASCII" << endl;
	f[1]->show();

	cout << "3.Binary " << endl;
	f[2]->show();
	
}
	