#include "Field.h"
#include <iostream>

Field::Field(sf::Vector2f position)
{
	_position = position;
	
	
	if (!water_texture.loadFromFile("resourse/water.png"))
	{
		exit(-1);
	}

	if (!ship_texture.loadFromFile("resourse/ship.png"))
	{
		exit(-1);

	}

	if (!hit_texture.loadFromFile("resourse/fire.png"))
	{
		exit(-1);

	}

	if (!miss_texture.loadFromFile("resourse/miss.png"))
	{
		exit(-1);
	}



	miss_hit.setSize(sf::Vector2f(30.f, 30.f));
	miss_hit.setTexture(&miss_texture);


	ship_hit.setSize(sf::Vector2f(30.f, 30.f));
	ship_hit.setTexture(&hit_texture);

	
	ship.setSize(sf::Vector2f(30.f, 30.f));
	ship.setTexture(&ship_texture);


	grid.setOutlineColor(sf::Color::Black);
	grid.setTexture(&water_texture);
	grid.setOutlineThickness(1.f);
	grid.setSize(sf::Vector2f(30.f, 30.f));
}

sf::Vector2i Field::AI_ship_kill_unsure(sf::Vector2i position)
{
	int random = 4;//rand() % 4;
	int strnd = random;

	while (true)
	{
		switch (random)
		{
		case 0:
			if (position.x + 1 < 10)
			{
				if (!cells[position.x + 1][position.y].get_dead())
				{
					return  sf::Vector2i(position.x + 1, position.y);
				}
			}
			break;
		case 1:
			if (position.x - 1 >= 0)
			{
				if (!cells[position.x][position.y - 1].get_dead())
				{
					return  sf::Vector2i(position.x, position.y - 1);
				}
			}
			break;
		case 2:
			if (position.y - 1 >= 0)
			{
				if (!cells[position.x - 1][position.y].get_dead())
				{
					return  sf::Vector2i(position.x - 1, position.y);
				}
			}
			break;
		case 3:
			if (position.y + 1 < 10)
			{
				if (!cells[position.x][position.y + 1].get_dead())
				{
					return  sf::Vector2i(position.x, position.y + 1);
				}
			}
			break;
		}
		random++;
		if (random >= 4)
		{
			random = 0;
		}
		if (random == strnd)
		{
			break;
		}
	}


	return sf::Vector2i(-1, -1);



}

sf::Vector2i Field::Ai_ship_kill(sf::Vector2i position)
{
	for (int i = -1; i <= 1; i += 2)
	{
		if (position.y + i < 10 && position.y + i >= 0)
		{
			if (cells[position.x][position.y + i].get_dead() && cells[position.x][position.y + i].get_ship())
			{
				if (position.y - i >= 0 && position.y - i < 10)
				{
					if (!cells[position.x][position.y - i].get_dead())
					{
						return sf::Vector2i(position.x, position.y - i);
					}
				}
			}
		}
		if (position.x + i < 10 && position.x + i >= 0)
		{
			if (cells[position.x + i][position.y].get_dead() && cells[position.x + i][position.y].get_ship())
			{
				if (position.x - i >= 0 && position.x - i < 10)
				{
					if (!cells[position.x - i][position.y].get_dead())
					{
						return sf::Vector2i(position.x - i, position.y);
					}
				}
			}
		}
	}

	return sf::Vector2i(-1, -1);
}

bool Field::AI_turn()
{
	bool ship_found = false;
	bool unsure_found = false;


	std::vector<sf::Vector2i> possible_ship;

	possible_ship.clear();

	
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			if (cells[i][j].get_dead() && cells[i][j].get_ship() && !cells[i][j]._is_done)
			{

				sf::Vector2i pz = Ai_ship_kill(sf::Vector2i(i, j));
				if (pz.x != -1)
				{
					possible_ship.clear();
					possible_ship.push_back(pz);
					ship_found = true;
				}
				else if (!ship_found)
				{
					pz = AI_ship_kill_unsure(sf::Vector2i(i, j));

					if (pz.x != -1)
					{
						possible_ship.clear();
						possible_ship.push_back(pz);
						unsure_found = true;
					}
				}
			}

			if (!cells[i][j].get_dead() && !ship_found && !unsure_found)
			{
				possible_ship.push_back(sf::Vector2i(i, j));
			}
		}
	}

	if (possible_ship.size() != 0)
	{
		int rnd = rand() % possible_ship.size();

		int x = possible_ship[rnd].x;
		int y = possible_ship[rnd].y;

		cells[x][y].shoot();

		if (cells[x][y].get_ship())
		{
			if (ship_is_dead(sf::Vector2i(x, y)))
			{
				ship_reveal(sf::Vector2i(x, y));
			}

			win_check();
			return false;
		}

		win_check();
		return true;
	}

	win_check();
	return true;
}

bool Field::player_shoot(sf::Vector2i clickpos)
{
	sf::Vector2i rClickPos = clickpos - sf::Vector2i((int)_position.x, (int)_position.y);
	rClickPos.x = (int)(floor((float)rClickPos.x / 30.f));
	rClickPos.y = (int)(floor((float)rClickPos.y / 30.f));

	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			if (i == (int)rClickPos.x && j == (int)rClickPos.y)
			{
				if (!cells[i][j].get_dead())
				{
					cells[i][j].shoot();

					if (cells[i][j].get_ship())
					{
						if (ship_is_dead(sf::Vector2i(i, j)))
						{
							ship_reveal(sf::Vector2i(i, j));
						}

						win_check();
						return false;
					}

					win_check();
					return true;
				}
				else
				{
					win_check();
					return false;
				}
			}
		}
	}

	win_check();
	return false;
}

void Field::ship_reveal(sf::Vector2i position)
{
	cells[position.x][position.y]._is_done = true;

	for (int i = -1; i < 2; i++)
	{
		for (int j = -1; j < 2; j++)
		{
			if (position.x + i < 10 && position.x + i >= 0 && position.y + j < 10 && position.y + j >= 0)
			{
				cells[position.x + i][position.y + j].shoot();

				if (!cells[position.x + i][position.y + j]._is_done && cells[position.x + i][position.y + j].get_ship())
				{
					ship_reveal(sf::Vector2i(position.x + i, position.y + j));
				}
			}
		}
	}

}

bool Field::ship_is_dead(sf::Vector2i position)
{
	checked_position.clear();

	return !check_neighbors(position);//if ship not fully destroyed false , if fully true
}

bool Field::check_neighbors(sf::Vector2i position)
{
	checked_position.push_back(position);

	for (int i = -1; i < 2; i++)
	{
		for (int j = -1; j < 2; j++)
		{
			if (position.x + i < 10 && position.x + i >= 0 && position.y + j < 10 && position.y + j >= 0)
			{
				if (!cells[position.x + i][position.y + j].get_dead() && cells[position.x + i][position.y + j].get_ship())
				{
					return true;
				}
			}
		}
	}

	bool done = false;
	bool result;

	for (int i = -1; i < 2; i++)
	{
		for (int j = -1; j < 2; j++)
		{
			if (position.x + i < 10 && position.x + i >= 0 && position.y + j < 10 && position.y + j >= 0)
			{
				if (cells[position.x + i][position.y + j].get_dead() && cells[position.x + i][position.y + j].get_ship())
				{
					bool cell_check = false;
					for (int k = 0; k < checked_position.size(); k++)
					{
						if (position.x + i == checked_position[k].x && position.y + j == checked_position[k].y)
						{
							cell_check = true;
						}
					}
					if (!cell_check)
					{
						result = check_neighbors(sf::Vector2i(position.x + i, position.y + j));
						done = true;
					}
				}
			}
		}
	}

	if (done)
	{
		return result;
	}

	return false;
}

void Field::field_player_draw(sf::RenderWindow& window)
{
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			grid.setPosition(sf::Vector2f((float)i * 30.f, (float)j * 30.f) + _position);
			window.draw(grid);

			if (cells[i][j].get_ship())
			{
				ship.setPosition(sf::Vector2f((float)i * 30.f, (float)j * 30.f) + _position);
				window.draw(ship);
			
				if (cells[i][j].get_dead())
				{
					ship_hit.setPosition(sf::Vector2f((float)i * 30.f, (float)j * 30.f) + _position);
					window.draw(ship_hit);
				}
			}
			else if (cells[i][j].get_dead())
			{
				miss_hit.setPosition(sf::Vector2f((float)i * 30.f, (float)j * 30.f) + _position);
				window.draw(miss_hit);
			}
		}
	}
}

void Field::enemy_field_draw(sf::RenderWindow& window)
{
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			grid.setPosition(sf::Vector2f((float)i * 30.f, (float)j * 30.f) + _position);
			window.draw(grid);

			if (cells[i][j].get_ship())
			{
				
				ship.setPosition(sf::Vector2f((float)i * 30.f, (float)j * 30.f) + _position);
				ship.setFillColor(sf::Color(128, 128, 128, _enemy_transparent));
				window.draw(ship);
				ship.setFillColor(sf::Color(128, 128, 128));
				
				if (cells[i][j].get_dead())
				{
					ship_hit.setPosition(sf::Vector2f((float)i * 30.f, (float)j * 30.f) + _position);
					window.draw(ship_hit);
				}
			}
			else if (cells[i][j].get_dead())
			{
				miss_hit.setPosition(sf::Vector2f((float)i * 30.f, (float)j * 30.f) + _position);
				window.draw(miss_hit);
			}
		}
	}
}

void Field::ship_randomize()
{
	int _size = 4;
	int sizestep = 1;

	for (int i = 0; i < 10; i++)
	{
		sizestep--;
		std::vector<Ship> possible_shoot;

		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				for (int k = 0; k < 2; k++)
				{
					if (k == 0)
					{
						if (ship_check(sf::Vector2i(i, j), _size, false))
						{
							possible_shoot.push_back(Ship(_size, sf::Vector2i(i, j), false));
						}
					}
					else
					{
						if (ship_check(sf::Vector2i(i, j), _size, true))
						{
							
							possible_shoot.push_back(Ship(_size, sf::Vector2i(i, j), true));
						}
					}

				}
			}

		}
		if (possible_shoot.size() != 0)
		{
			int ran = rand() % possible_shoot.size();
			ship_add(possible_shoot[ran]);
		}
		if (sizestep == 0)
		{
			_size--;
			sizestep = 5 - _size;
		}
	}
}

void Field::win_check()
{
	bool lose = true;
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			if (cells[i][j].get_ship() && !cells[i][j].get_dead())
			{
				lose = false;
			}
		}
	}
	if (lose)
	{
		_lose = true;

		grid.setFillColor(sf::Color::Red);
	}
}

void Field::ship_add(Ship ship)
{
	for (int i = 0; i < ship._size; i++)
	{
		if (!ship._reverse_ship_flag)
		{
			cells[ship._position.x + i][ship._position.y].create_ship();
		}
		else
		{
			cells[ship._position.x][ship._position.y + i].create_ship();
		}
	}
}

bool Field::ship_check(sf::Vector2i position, int _size, bool reverse_flag)
{
	for (int i = 0; i < _size; i++)
	{
		if (!reverse_flag)
		{
			if (i + position.x >= 10)//check for out of range set
			{
				return false;
			}
			else//check for another ship
			{
				for (int j = -1; j <= 1; j++)
				{
					for (int k = -1; k <= 1; k++)
					{
						if (i + position.x + j < 10 && position.y + k < 10 && i + position.x + j >= 0 && position.y + k >= 0)
						{
							if (cells[i + position.x + j][position.y + k].get_ship())
							{
								return false;
							}
						}
					}
				}
			}
		}
		else
		{
			if (i + position.y >= 10)//check for out of range set
			{
				return false;
			}
			else//check for another ship
			{
				for (int j = -1; j <= 1; j++)
				{
					for (int k = -1; k <= 1; k++)
					{
						if (position.x + k < 10 && position.y + i + j < 10 && position.x + k >= 0 && position.y + i + j >= 0)
						{
							if (cells[position.x + k][position.y + i + j].get_ship())
							{
								return false;
							}
						}
					}
				}
			}
		}
	}
	return true;
}

sf::Vector2f Field::get_pos()
{
	return _position;
}

void Field::reveal_enemy()
{
	_enemy_transparent = 255;
}

bool Field::get_lose()
{
	return _lose;
}



Field::~Field()
{
}