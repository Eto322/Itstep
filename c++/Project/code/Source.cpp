#include <SFML/Graphics.hpp>
#include "Field.h"
#include "Ship.h"

sf::RectangleShape ship_cell;

void draw_Ship(int, sf::Vector2f, bool, sf::RenderWindow&);
bool place_Ship(int, bool, sf::Vector2i, Field&);



int main()
{
	sf::RenderWindow window(sf::VideoMode(700, 400), "Sea Battle", sf::Style::Titlebar | sf::Style::Close);//creating window
	sf::Texture background_texture;
	sf::Sprite background;

	bool Ready_flag = false;
	
	

	if (!background_texture.loadFromFile("resourse/background.jpg"))
	{
		exit(-1);
	}
	background.setTexture(background_texture);
	
	srand(time(0));

	ship_cell.setFillColor(sf::Color(100, 100, 100, 100));
	ship_cell.setSize(sf::Vector2f(30.f, 30.f));

	Field field(sf::Vector2f(30, 30));
	Field field_enemy(sf::Vector2f(360, 30));

	//f.RandomizeShips();
	field_enemy.ship_randomize();//enemy randomize


	int size = 4;//ship size
	int ship_count = 1;// count of ship 
	bool Reverse_ship_flag = false;



	while (window.isOpen())//main loop
	{
		int x = sf::Mouse::getPosition(window).x - (sf::Mouse::getPosition(window).x % 30);
		int y = sf::Mouse::getPosition(window).y - (sf::Mouse::getPosition(window).y % 30);

		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
				window.close();
			if (event.type == sf::Event::MouseButtonReleased)
			{
				if (Ready_flag)
				{//play stage
					if (field_enemy.player_shoot(sf::Mouse::getPosition(window)))
					{
						while (true)
						{
							if (field.AI_turn())
							{
								break;
							}
						}
					}
				}
				else
				{
					//set stage
					if (place_Ship(size, Reverse_ship_flag, sf::Vector2i((x - field.get_pos().x) / 30, (y - field.get_pos().y) / 30), field))
					{
						
						ship_count--;

						if (ship_count == 0)
						{
							size--;
							ship_count = 5 - size;
						}
						if (size == 0)
						{
							Ready_flag = true;
						}
					}
				}
			}
			if (event.type == sf::Event::MouseWheelMoved)//ship reverse
			{
				Reverse_ship_flag = !Reverse_ship_flag;
			}
		}

		if (field.get_lose())
		{
			field_enemy.reveal_enemy();
		}

		window.clear(sf::Color::White);
		window.draw(background);
		

		field.field_player_draw(window);
		field_enemy.enemy_field_draw(window);

		draw_Ship(size, sf::Vector2f(x, y), Reverse_ship_flag, window);

		window.display();
	}

	return 0;
}

void draw_Ship(int size, sf::Vector2f pos, bool reverse_ship_flag, sf::RenderWindow& window)
{
	for (int i = 0; i < size; i++)
	{
		if (reverse_ship_flag)
		{
			ship_cell.setPosition(pos.x, pos.y + i * 30);
		}
		else
		{
			ship_cell.setPosition(pos.x + i * 30, pos.y);
		}
		window.draw(ship_cell);
	}
}

bool place_Ship(int size, bool reverse_ship_flag, sf::Vector2i position, Field& field)
{
	if (field.ship_check(position, size, reverse_ship_flag))
	{
		field.ship_add(Ship(size, position, reverse_ship_flag));
		return true;
	}
	return false;
}
