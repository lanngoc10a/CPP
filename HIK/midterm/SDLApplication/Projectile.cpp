#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "Projectile.h"
#include "constants.h"
#include "Entity.h"
#include "Game.h"
using namespace std;

Projectile::Projectile(Game* game, float damage, float x, float y, float speedX, float speedY) : Entity(game, "shot.bmp", 10, 20, 100, x, y, speedX, speedY, 1000) {
	this->damage = damage;
};

void Projectile::step(float time) {
	Entity::step(time);
	for (auto enemy : game->enemies) {
		if (Entity::overlap(enemy)) {
			isDestroyed = true;
			enemy->takeDamage(damage);
		}
	}
}