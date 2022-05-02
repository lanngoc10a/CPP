#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "constants.h"
#include "Entity.h"
using namespace std;

class Game;

class Projectile : public Entity {
protected:
	float damage;

public:
	Projectile(Game* game, float damage, float x, float y, float speedX, float speedY);
	void step(float time);
};