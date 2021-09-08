#include <iostream>
#include <memory>

template <class T>
class Unique_pointer {
public:
    Unique_pointer(T* value) 
    {
        _value = value;
        
    }

	Unique_pointer(const Unique_pointer& object) = delete;
	
  
    T* get_value()
    {
       
        return _value;
    }

    void relese()
    {
        std::cout << " Unique_pointer Relesed" << std::endl;
        delete _value;
        _value = nullptr;
    }

    void reset(T* value)
    {
        std::cout << "Unique_pointer Reseted" << std::endl;
        relese();
        _value = value;
    }

    void swap(Unique_pointer& other)
    {
        T* tmp;
        tmp = _value;
        _value = other.get_value();
        other._value = tmp;
    }

    Unique_pointer& operator=(const Unique_pointer& copy) = delete;


    ~Unique_pointer() {
        delete _value;
       
    }
private:
    T* _value=nullptr;
};

template<class T>
class Shared_pointer
{


public:
	Shared_pointer() :
		_value{ nullptr }, 
		_owners{ new int(0) } 
	{};

	Shared_pointer(T* value) : 
		_value{ value }, 
		_owners{ new int(1) }
	{};

	
	Shared_pointer(const Shared_pointer& obj) 
	{
		_value = obj._value; 
		_owners = obj._owners;
		if (obj._value!=nullptr)
		{
			(*this->_owners)++; 
		}
	}



	

	

	int *get_count()
	{
		return _owners; 
	}

	T* get_value()
	{
		return _value;
	}
	
	void reset()
	{
		(*this->_owners)--;
		if (*_owners == 0)
		{
			if (_value != nullptr)
			{
				delete _value;
			}

			delete _owners;
		}
	}
	
	~Shared_pointer() 
	{
		reset();
	}

private:
	T* _value = nullptr;
	int* _owners = nullptr;
	
};




int main()
{
   Unique_pointer<int> a(new int(1));
    Unique_pointer<int> b(new int(2));

	std::cout << "Unique_pointer" << std::endl;
	std::cout << "A=1 B=2" << std::endl;
    std::cout <<"A " << *a.get_value() << std::endl;
    std::cout <<"B" << *b.get_value() << std::endl;
	std::cout << "A Swap with B" << std::endl;
    a.swap(b);
	std::cout << "A " << *a.get_value() << std::endl;
	std::cout << "B" << *b.get_value() << std::endl;
    a.relese();
	
    b.reset(new int (20));
	std::cout << "A(relesed) B reset =20" << std::endl;
    std::cout << "B" << *b.get_value() << std::endl;
    
    Shared_pointer<int> c(new int(2));
    Shared_pointer<int> d(c);
   
	
	std::cout << " Shared_pointer" << std::endl;
	std::cout << "C=2" << std::endl;
	std::cout << "C " << *c.get_value() << " Owners count " << *c.get_count() << std::endl;
	
	std::cout << "D(C)" << std::endl;
	std::cout << "C " << *c.get_value() << " Owners count " << *c.get_count() << std::endl;
	std::cout << "D " << *d.get_value() << " Owners count " << *d.get_count() << std::endl;
	std::cout << "C reset" << std::endl;
	c.reset();
	std::cout << "D " << *d.get_value() << " Owners count " << *d.get_count() << std::endl;
	





   
 



}