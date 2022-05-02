#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "constants.h"
#include "Enemy.h"
#include "Entity.h"
#include "Game.h"
using namespace std;

Enemy::Enemy(Game* game, float x, float y) : Entity(game, "leviathan.bmp", 10, 50, 100, x, y, 0,0,40) {
	desiredX = radius;
	desiredY = radius;
};

void Enemy::step(float time) {
	if (std::abs(x - desiredX) <= desiredRadius && std::abs(y - desiredY) <= desiredRadius) {
		desiredX = desiredX > resX / 2 ? radius : resX - radius;
		desiredY += radius * 2 + 20;
		//cout << "\ndesired x: " << desiredX << ", desiredY: " << desiredY << ", resX: " << resX;
	}
	float brakeFactor = 2.0;
	if (x < desiredX) accelerationX = (speedX < 0 ? brakeFactor : 1) * acceleration;
	if (x > desiredX) accelerationX = (speedX > 0 ? brakeFactor : 1) * -acceleration;
	if (y < desiredY) accelerationY = (speedY < 0 ? brakeFactor : 1) * acceleration;
	if (y > desiredY) accelerationY = (speedY > 0 ? brakeFactor : 1) * -acceleration;
	Entity::step(time);
	if (Entity::overlap(game->player)) {
		game->player->takeDamage(40);
		isDestroyed = true;
	}
}