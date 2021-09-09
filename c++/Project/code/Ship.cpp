#include "Ship.h"



Ship::Ship(int size, sf::Vector2i pos, bool reverse_flag):
_size { size },
_position { pos },
_reverse_ship_flag { reverse_flag }
{};



Ship::~Ship()
{
}