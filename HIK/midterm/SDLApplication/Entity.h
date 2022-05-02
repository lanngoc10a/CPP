#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "constants.h"
using namespace std;

class Game;

class Entity {
protected:
	Game* game;
	float x, y, speedX, speedY, accelerationX, accelerationY, maxSpeed, xMin, xMax, yMin, yMax, mass, radius, hp, friction;
	string graphics;

public:
	bool isDestroyed = false;

	Entity(Game* game, string graphics, float mass = 1, float radius = 10, float hp = 100,
		float x = 0, float y = 0, float speedX = 0, float speedY = 0, float maxSpeed = 100, float accelerationX = 0, float accelerationY = 0,
		float xMin = stageMinX, float xMax = stageMaxX, float yMin = stageMinY, float yMax = stageMaxY, float friction = 0);
	virtual void step(float time);
	void render();
	void takeDamage(float damage);
	bool overlap(Entity* other);
};