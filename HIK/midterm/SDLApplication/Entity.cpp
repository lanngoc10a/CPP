#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "Entity.h"
#include "constants.h"
#include "Game.h"
using namespace std;

Entity::Entity(Game* game, string graphics, float mass, float radius, float hp,
	float x, float y, float speedX, float speedY, float maxSpeed, float accelerationX, float accelerationY,
	float xMin, float xMax, float yMin, float yMax, float friction) {
	this->game = game;
	this->graphics = graphics;
	this->x = x;
	this->y = y;
	this->speedX = speedX;
	this->speedY = speedY;
	this->accelerationX = accelerationX;
	this->accelerationY = accelerationY;
	this->maxSpeed = maxSpeed;
	this->hp = hp;
	this->mass = mass;
	this->radius = radius;
	this->xMin = xMin;
	this->xMax = xMax;
	this->yMin = yMin;
	this->yMax = yMax;
	this->friction = friction;
	//cout << "\nInit " << graphics << " x: " << x << ", y : " << y << ", speedX : " << speedX << ", speedY : " << speedY << ", accelerationX : " << accelerationX << ", accelerationY : " << accelerationY;
}

void Entity::step(float time) {
	//cout << "\nStep " << graphics << " x: " << x << ", y : " << y << ", speedX : " << speedX << ", speedY : " << speedY << ", accelerationX : " << accelerationX << ", accelerationY : " << accelerationY << ", maxSpeed: " << maxSpeed;
	//cout << "\nstep2: " << maxSpeed;
	speedX += accelerationX * timeStep;
	speedY += accelerationY * timeStep;
	float frictionFactor = friction == 0 ? 1 :  1 - (1 - friction) * timeStep;
	speedX *= frictionFactor;
	speedY *= frictionFactor;
	//cout << "\nStep2 " << graphics << " x: " << x << ", y : " << y << ", speedX : " << speedX << ", speedY : " << speedY << ", accelerationX : " << accelerationX << ", accelerationY : " << accelerationY;
	if (speedX > maxSpeed) speedX = maxSpeed;
	if (speedX < -maxSpeed) speedX = -maxSpeed;
	if (speedY > maxSpeed) speedY = maxSpeed;
	if (speedY < -maxSpeed) speedY = -maxSpeed;
	x += speedX * timeStep;
	y += speedY * timeStep;
	if (x < xMin) x = xMin;
	if (x > xMax) x = xMax;
	if (y < yMin) y = yMin;
	if (y > yMax) y = yMax;
	if (x < stageMinX) hp = 0;
	if (x > stageMaxX) hp = 0;
	if (y < stageMinY) hp = 0;
	if (y > stageMaxY) hp = 0;
	if (hp <= 0) isDestroyed = true;
}

void Entity::render() {
	//cout << "Render " << graphics  << ": " << x << ", " << y;
	game->drawImage(graphics, x-radius, y-radius);
}

void Entity::takeDamage(float damage) {
	hp -= damage;
}

bool Entity::overlap(Entity* other) {
	auto xDiff = other->x - x;
	auto yDiff = other->y - y;
	auto distance2 = xDiff * xDiff + yDiff * yDiff;
	auto rDiff = other->radius + radius;
	return distance2 < rDiff* rDiff;
}