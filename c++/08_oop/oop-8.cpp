/*оздать класс для работы с матрицами. Предусмотреть, как минимум, функции
для сложения матриц, умножения матриц, транспонирования матриц,
присваивания матриц друг другу, установка и получение произвольного
элемента матрицы. Необходимо перегрузить соответствующие операторы.
2. Создать классы Матрица и Вектор. Написать дружественную функцию, которая
будет принимать в качестве аргументов объекты вышеуказанных классов и
производить умножение вектора на матрицу.
Используйте дружественные функции.
Так же используйте глобальную перегрузку, чтобы можно было использовать
оператор, вроде:
MyClass A;
MyClass C=2+A;
Так же необходимо в каждом классе перегрузить операторы << и >>*/
#include <iostream>
#include <string>
#include <ctime>
using namespace std;

class Matrix
{
public:
	Matrix() = delete;
	Matrix(int size)
	{
		_size = size;
		_matrix = new int*[size];
		for (int i = 0; i <size; i++)
		{
			_matrix[i] = new int[size];
		}
	}
	
	void set_element(int, int, int);
	int& get_elemet(int ,int);
	int get_size();


	void fill_matrix(int , int);
	void transpose();
	
	friend ostream& operator<<(ostream& os, Matrix& Matrix);
	


	Matrix& operator=(Matrix&);
	Matrix& operator +(Matrix&);
	Matrix& operator -(Matrix&);
	Matrix& operator *(Matrix&);

	

	~Matrix();



private:
	int** _matrix;
	int _size;
	
};

class Vector
{
public:
	Vector() = delete;
	Vector(int size) :
		_size{ size },
		_arr{ new int[size] }
	{};
	~Vector();

	void fill_vector(int,int);
	friend ostream& operator<<(ostream& os, Vector& Vector);
	friend  void on_vector(Matrix&mat, Vector&vec);

private:
	int _size;
	int* _arr;
};

void on_vector(Matrix&mat,Vector&vec)
{
	for (int i = 0; i < mat.get_size(); i++)
	{
		for (int j = 0; j < mat.get_size(); j++)
		{
			mat.get_elemet(i, j) *= vec._arr[i];
		}
	}
	
}
Vector::~Vector()
{
	delete[] _arr;
}

void Vector::fill_vector(int min = 0,int max=10)
{
	for (int i = 0; i < _size; i++)
	{
		_arr[i]= rand() % (max - min) + min;
	}
}



void Matrix::set_element(int i, int j, int value)
{
	_matrix[i][j] = value;
}

int& Matrix::get_elemet(int i,int j)
{
	return _matrix[i][j];
}

int Matrix::get_size()
{
	return _size;
}

void Matrix::fill_matrix(int min=0, int max=10)
{
	for (int i = 0; i < _size; i++)
	{
		for (int j = 0; j < _size; j++)
		{
			_matrix[i][j] = rand() % (max - min) + min;
		}
	}
}

void Matrix::transpose()
{
	int** tmp = new int* [_size];
	for (int i = 0; i < _size; i++)
	{
		tmp[i] = new int[_size];
	}
	for (int i = 0; i < _size; i++)
	{
		for (int j = 0; j < _size; j++)
		{
			tmp[i][j] = _matrix[j][i];
		}
	}

	for (int i = 0; i < _size; i++)
	{
		delete[] _matrix[i];
	}
	delete[] _matrix;

	_matrix = tmp;


}

Matrix& Matrix::operator=(Matrix& tmp)
{
	for (int i = 0; i < _size; i++)
	{
		for (int j = 0; j < _size; j++)
		{
			_matrix[i][j] = tmp.get_elemet(i, j);
		}
	}

	return *this;
}

Matrix& Matrix::operator+(Matrix& tmp)
{
	for (int i = 0; i < _size; i++)
	{
		for (int j = 0; j < _size; j++)
		{
			_matrix[i][j] += tmp.get_elemet(i, j);
		}
	}

	return *this;
}

Matrix& Matrix::operator-(Matrix& tmp)
{
	for (int i = 0; i < _size; i++)
	{
		for (int j = 0; j < _size; j++)
		{
			_matrix[i][j] -= tmp.get_elemet(i, j);
		}
	}

	return *this;
}

Matrix& Matrix::operator*(Matrix& tmp)
{
	for (int i = 0; i < _size; i++)
	{
		for (int j = 0; j < _size; j++)
		{
			_matrix[i][j] *= tmp.get_elemet(i, j);
		}
	}

	return *this;
}

Matrix::~Matrix()
{
	for (int i = 0; i < _size; i++)
	{
		delete[] _matrix[i];
	}
	delete[] _matrix;
}

ostream& operator<<(ostream& os, Matrix& Matrix)
{
	for (int i = 0; i < Matrix._size; i++)
	{
		for (int j = 0; j < Matrix._size; j++)
		{
			os <<  Matrix._matrix[i][j] << " ";
		}
		os << endl;
	}
	os << endl;
	return os;
}


ostream& operator<<(ostream& os, Vector& Vector)
{
	for (int i = 0; i < Vector._size; i++)
	{
		os << Vector._arr[i] << " ";
	}
	os << endl;
	return os;
}





int main()
{
	srand(time(0));

	Matrix first(3);
	first.fill_matrix();
	Matrix second(3);
	second.fill_matrix();
	Vector third(3);
	third.fill_vector();
	int k;
	while (true)
	{	
		system("pause");
		system("cls");

		cout << "first" << endl << first;
		cout << "second" << endl << second;
		cout << "vector " << endl << third;


		cout << "1.add second to first" << endl;
		cout << "2.mul second on first" << endl;
		cout << "3.transport first" << endl;
		cout << "4.first=second" << endl;
		cout << "5.add vector to first matrix" << endl;
		cout << "6.exit" << endl;
		cin >> k;
		switch (k)
		{
		case 1:
			first + second;
			break;
		case 2:
			first * second;
			break;
		case 3:
			first.transpose();
			break;
		case 4:
			first = second;
			break;
		case 5:
			on_vector(first, third);
			break;
		case 6:
			exit(0);
		default:
			break;
		}

	}
	

}


