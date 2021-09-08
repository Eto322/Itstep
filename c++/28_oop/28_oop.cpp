#include <iostream>
#include <map>
#include <string>
#include <fstream>


using namespace std;
class Dictionary
{
public:
    Dictionary()
    {
        ifstream database("dictionary.dat", ofstream::in);
        if (!database)
        {
            throw exception("unable to find file");
        }
       
        string word;
        while (database>>word)
        {   
            _dictionary[_index] = word;
            _index++;
        }
        database.close();
    }

    void add_word(string word)
    {
        _dictionary[_index] = word;
            _index++;
    }

    void delete_lase()
    {
        map<int, string>::iterator it = _dictionary.end();
        _dictionary.erase(it);
    }

    void show_all()
    {
        for (auto i = _dictionary.begin(); i != _dictionary.end(); ++i)
        {
            cout << "index " << i->first << " word " << i->second << endl;
        }
    }

    string search_word(int index)
    {
        return _dictionary[index];
    }
    ~Dictionary()
    {
        std::ofstream database;
        database.open("dictionary.dat");
        if (!database)
        {
            throw exception("unable to find file");
        }
        for (int i = 0; i < _index; i++)
        {
            database << _dictionary[i] << " ";
        }
        database.close();
    }

private:
    map<int, string> _dictionary;
    int _index = 0;
};



  
int main()
{

    int k;
    int index;
    string word;
    bool flag = true;
    try
    {
        Dictionary tmp;
        while (flag)
        {   
            cout << "1. Search word" << endl;
            cout << "2.Add word" << endl;
            cout << "3.show all words" << endl;
            cout << "4.exit" << endl;
            cin >> k;
            switch (k)
            {
            case 1:
                cout << "Enter index" << endl;
                cin >> index;
                cout << tmp.search_word(index) << endl;
                break;
            case 2:
                cout << "Enter word" << endl;
                cin >> word;
                tmp.add_word(word);
                break;
            case 3:
                tmp.show_all();
                break;
            case 4:
                flag = false;
                break;
            default:
                break;
            }

        }
    }
    catch (const std::exception& error)
    {
        cout<<error.what();
        exit(-1);
    }

}


    
