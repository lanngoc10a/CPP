#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "constants.h"
#include "Entity.h"
#include "Player.h"
#include "Enemy.h"
#include "Entity.h"
#include "Projectile.h"
using namespace std;

class Game {
public:
	Player* player;
	vector<Entity*> entities;
	vector<Enemy*> enemies;
	vector<Projectile*> projectiles;
	vector<Entity*> createdEntities;
	vector<Enemy*> createdEnemies;
	vector<Projectile*> createdProjectiles;
	SDL_Window* window;
	SDL_Renderer* renderer;
	bool gameNotOver = true;

	Game(SDL_Window* window, SDL_Renderer* renderer);
	void makeEnemy(int x, int y);
	void makeProjectile(float damage, float x, float y, float speedX, float speedY);
	void run();
	int drawImage(string name, float x, float y);
};