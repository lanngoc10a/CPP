#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "constants.h"
#include "Entity.h"
using namespace std;

class Game;

class Player : public Entity {
protected:
	float reloadTime = 0.4;
	float lastShotTime = -reloadTime;

public:
	Player(Game* game);
	void controls(float time);
	void shoot();
	void step(float time);
};