
#pragma once
#include "Cell.h"
#include <vector>
#include <SFML\Graphics.hpp>
#include "Ship.h"

class Field
{

public:
	Field(sf::Vector2f _position);

	void ship_randomize();//randomize for enemy ship
	bool ship_check(sf::Vector2i,int,bool );
	bool ship_is_dead(sf::Vector2i );
	void ship_add(Ship );//add ship
	void ship_reveal(sf::Vector2i );//reveal ship

	void field_player_draw(sf::RenderWindow& );
	void enemy_field_draw(sf::RenderWindow&);
	bool player_shoot(sf::Vector2i );//shot from player
	bool check_neighbors(sf::Vector2i );
	
	
	bool AI_turn();
	sf::Vector2i Ai_ship_kill(sf::Vector2i );// if ai know positon of ship
	sf::Vector2i AI_ship_kill_unsure(sf::Vector2i );//if ai didint know positon

	sf::Vector2f get_pos();
	void win_check();
	void reveal_enemy();//reveal all enemy ship
	bool get_lose();
	

	~Field();
private:
	Cell cells[10][10];
	int _enemy_transparent = 0;
	bool _lose = false;

	sf::Texture water_texture;
	sf::Texture ship_texture;
	sf::Texture hit_texture;
	sf::Texture miss_texture;
	
	sf::RectangleShape miss_hit;
	sf::RectangleShape ship_hit;
	sf::RectangleShape ship;
	sf::RectangleShape grid;

	sf::Vector2f _position;



	std::vector<sf::Vector2i> checked_position;

};

