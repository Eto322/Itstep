using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Student
    {
        string _name;
        string _surname;
        string _patronymic;
        string _group;
        int _age;
        int[][] _marks = new int[3][];
        public Student() : this("-1", "-1", "-1", "-1", -1, -1, -1, -1) { }
        public Student(string name, string surname, string patronymic, string group, int age, int sizeProg, int sizeAdmin, int sizeDesign)
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _group = group;
            _age = age;
            _marks[0] = new int[sizeProg];
            _marks[1] = new int[sizeAdmin];
            _marks[2] = new int[sizeDesign];
        }

    
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        public string Patronymic
        {
            get => _patronymic;
            set => _patronymic = value;
        }
        public string Group
        {
            get => _group;
            set => _group = value;
        }
        public int Age
        {
            get => _age;
            set => _age = value;
        }
        public int AvarageProg(int[] prog)
        {
            int sum = 0;
            for (var i = 0; i < prog.Length; i++)
            {
                sum += prog[i];
            }

            return sum/prog.Length;
        }
        public int AvarageAdmin(int[] admin)
        {
            int sum = 0;
            for (var i = 0; i < admin.Length; i++)
            {
                sum += admin[i];
            }
            return sum / admin.Length;
        }
        public int AvarageDesign(int[] design)
        {
            int sum = 0;
            for (var i = 0; i < design.Length; i++)
            {
                sum += design[i];
            }
            return sum / design.Length;
        }
        public int this[int i, int j]
        {
            get => _marks[i][j];
            set => _marks[i][j] = value;
        }
        public override string ToString()//и правда заработало
        {
            return $"Name: {_name}\n" +
                $"Surname: {_surname}\n" +
                $"Patronymic: {_patronymic}\n" +
                $"Age: {_age}\n" +
                $"Group: {_group}\n" +
                $"Average programming score: {AvarageProg(_marks[0])}\n" +
                $"Average admin score: {AvarageAdmin(_marks[1])}\n" +
                $"Avarage design score: {AvarageDesign(_marks[2])}\n";
        }
    }
}