#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "constants.h"
#include "Entity.h"
using namespace std;

class Game;

class Enemy : public Entity {
protected:
	float desiredX, desiredY;
	float acceleration = 40;
	float desiredRadius = 15;

public:
	Enemy(Game* game, float x, float y);
	void step(float time);
};