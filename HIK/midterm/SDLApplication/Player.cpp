#pragma once
#include <iostream>
#include <string>
#include <vector>
#include "Player.h"
#include "constants.h"
#include "Entity.h"
#include "Game.h"
using namespace std;

Player::Player(Game* game) : Entity(game, "viking.bmp", 1, 65, 100, resX / 2, resY - 100, 0, 0, 100, 0, 150, borderLimit, resX - borderLimit, resY - playerBottomArea, resY - borderLimit, 0.6) {

}

void Player::controls(float time) {
	// Oppdater key state-arrayen
	SDL_PumpEvents();
	int numKeys;
	const Uint8* keys = SDL_GetKeyboardState(&numKeys);

	// Escape/Avslutt
	if (keys[SDL_SCANCODE_ESCAPE] != 0 || SDL_HasEvent(SDL_QUIT)) {
		game->gameNotOver = false; // Avslutt
	}
	accelerationX = 0;
	accelerationY = 0;
	float brakeFactor = 2.0;
	if (keys[SDL_SCANCODE_W] != 0 || keys[SDL_SCANCODE_UP] != 0) {
		accelerationY = (speedY > 0 ? brakeFactor : 1) * -playerAcceleration;
	}
	if (keys[SDL_SCANCODE_A] != 0 || keys[SDL_SCANCODE_LEFT] != 0) {
		accelerationX = (speedX > 0 ? brakeFactor : 1) * -playerAcceleration;
	}
	if (keys[SDL_SCANCODE_S] != 0 || keys[SDL_SCANCODE_DOWN] != 0) {
		accelerationY = (speedY > 0 ? brakeFactor : 1) * playerAcceleration;
	}
	if (keys[SDL_SCANCODE_D] != 0 || keys[SDL_SCANCODE_RIGHT] != 0) {
		accelerationX = (speedX < 0 ? brakeFactor : 1) * playerAcceleration;
	}
	if (keys[SDL_SCANCODE_SPACE] != 0 && time > lastShotTime + reloadTime) {
		lastShotTime = time;
		shoot();
	}
	//cout << "\nControls " << graphics << " x: " << x << ", y : " << y << ", speedX : " << speedX << ", speedY : " << speedY << ", accelerationX : " << accelerationX << ", accelerationY : " << accelerationY;
}

void Player::shoot() {
	game->makeProjectile(1000, x, y, 0, -500);
}

void Player::step(float time) {
	controls(time);
	Entity::step(time);
}