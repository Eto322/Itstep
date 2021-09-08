#include <iostream>
#include <vector>

using namespace std;
class Student 
{
public:


    Student() :
        _first_name{ "-1" }, 
        _second_name{ "-1" },
        _course { -1 }
    {};
    
    
    Student(string first_name, string second_name, int course) :
        _first_name{ first_name },
        _second_name{ second_name },
        _course{ course }
    {};
   
    
    Student(const Student& copy) 
    {
        _course = copy._course;
       _second_name = copy._second_name;
        _first_name = copy._first_name;
    }

   

    string get_first_name() 
    {
        return _first_name;
    }

    string get_second_name()
    {
        return _second_name;
    }

    int get_course()
    {
        return _course;
    }

    void set_first_name(string first_name) 
    {
       _first_name = first_name;
    }

    void set_second_name(string second_name) 
    {
        _second_name = second_name;
    }

    void set_course(int course)
    {
        _course = course;
    }
    
     void fill_vec(vector<Student>& vec) 
    {
         Student arbitrary_data("a", "b", 3);
        vec.reserve(10);
        for (int i = 0; i < 10; i++) {
            vec.push_back(arbitrary_data);
        }
    }
    void show(vector<Student>& vec) 
    {
        for (int i = 0; i < vec.size(); i++) 
        {
            cout << vec[i] << endl;
        }
    }
    friend std::ostream& operator<<(std::ostream& out, const Student& student)
    {

        out << "Name: " << student._first_name << "\nSecond name: " << student._second_name << "\nCourse: " << student._course << endl;
        return out;

    }
    
   
   

protected:
    int _course;
    string _first_name;
    string _second_name;
   
};




void first_ex()
{
    vector<int> vec(10);

    for (int i = 0; i < vec.size(); i++) {
        vec[i] = pow(i,2);
    }
    for (auto data : vec) {
        cout << data << " ";
    }
    cout << endl;
}

void second_ex()
{
    const int n = 10;
    vector<vector<int> > vec(n);
    for (int i = 0; i < vec.size(); i++)
    {
        vec[i].resize(n);
    }
        
    

    for (int i = 1; i < vec.size(); i++)
    {
        for (int j = 1; j < vec.size(); j++)
        {
            vec[i][j] = i * j;
        }
            
    }
        

    for (int i = 1; i < vec.size(); i++) 
    {
        for (int j = 1; j < vec.size(); j++)
        {
            cout << vec[i][j] << "\t";
        }
            

        cout << endl;
    }
}

void third_ex()
{
    vector<Student>vec;
    Student data;
    data.fill_vec(vec);
    data.show(vec);
    
}

int main() 
{
    cout << "First ex" << endl;
    first_ex();
    cout << "Second ex" << endl;
    second_ex();
    cout << "Third ex" << endl;
    third_ex();
       
  
     
    
}
