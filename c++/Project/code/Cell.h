#pragma once
#include <SFML\Graphics.hpp>

class Cell
{
public:
	Cell();

	bool _is_ship=false;
	bool _is_dead=false;
	bool _is_done=false;//ship fully destroyed

	bool get_ship();
	bool get_dead();

	void shoot();//_is_dead=true
	void create_ship();//create ship

	

	~Cell();
};

