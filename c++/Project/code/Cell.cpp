#include "Cell.h"



Cell::Cell()
{
	
}




bool Cell::get_ship()
{
	return _is_ship;
}


void Cell::create_ship()
{
	_is_ship = true;
}

bool Cell::get_dead()
{
	return _is_dead;
}


void Cell::shoot()
{
	_is_dead = true;
}




Cell::~Cell()
{
}