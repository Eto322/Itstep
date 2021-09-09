
#pragma once
#include <SFML\Graphics.hpp>


class Ship
{
public:
	int _size;
	sf::Vector2i _position;
	bool _reverse_ship_flag;

	Ship(int , sf::Vector2i , bool );
	~Ship();


};