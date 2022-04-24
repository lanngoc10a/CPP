#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "constants.h"
#include "Game.h"
#include "Entity.h"
#include "Player.h"
#include "Enemy.h"
#include "Projectile.h"
using namespace std;

Game::Game(SDL_Window* window, SDL_Renderer* renderer) {
	this->window = window;
	this->renderer = renderer;
	player = new Player(this);
	entities.push_back(player);
}

void Game::makeEnemy(int x, int y) {
	auto enemy = new Enemy(this, x, y);
	createdEntities.push_back(enemy);
	createdEnemies.push_back(enemy);
}

void Game::makeProjectile(float damage, float x, float y, float speedX, float speedY) {
	auto projectile = new Projectile(this, damage, x, y, speedX, speedY);
	createdEntities.push_back(projectile);
	createdProjectiles.push_back(projectile);
}

int Game::drawImage(string name, float x, float y) {
	// Last inn et bilde fra disk (NB: ren SDL støtter KUN BMP! Bruk SDL Image)
	SDL_Surface* surface = SDL_LoadBMP((basePath + name).c_str());
	// Sjekk for feil
	if (surface == nullptr)
	{
		std::cerr << "Failed to load image: "
			<< SDL_GetError() << std::endl;
		SDL_DestroyRenderer(renderer); SDL_DestroyWindow(window); SDL_Quit(); // rydd opp
		return EXIT_FAILURE;
	}

	// Konverter surface om til et HW Accelerated Texture, laster objektet opp på skjermkortet
	SDL_Texture* drawable = SDL_CreateTextureFromSurface(renderer, surface);
	// Sett opp et "koordinatsystem" for bildet
	SDL_Rect coords;
	coords.h = surface->h; // Samme bredde og høyde som surface
	coords.w = surface->w;
	coords.x = std::round(x); // Endre disse for å "flytte" bildet i vinduet/renderer
	coords.y = std::round(y);

	SDL_FreeSurface(surface); // Frigjør surface fra CPU-minnet
		/* GAME LOOP START */
		// Endre koordinatene ved brukerinput (coords.x, coords.y
		// Legg til objektet i vinduets renderer
	SDL_RenderCopy(renderer, drawable, nullptr, &coords);
	// BLIT/rendre bildet
	SDL_RenderPresent(renderer);
}

void Game::run() {
	float lastSpawnTime = 0;
	float spawnTime = 5;
	while (gameNotOver) {
		SDL_RenderClear(renderer);
		if (currentTime >= lastSpawnTime + spawnTime) {
			lastSpawnTime = currentTime;
			makeEnemy(-100, -100);
		}
		for (auto entity : createdEntities) {
			entities.push_back(entity);
		}
		for (auto entity : createdEnemies) {
			enemies.push_back(entity);
		}
		for (auto entity : createdProjectiles) {
			projectiles.push_back(entity);
		}
		createdEntities.clear();
		createdEnemies.clear();
		createdProjectiles.clear();
		for (auto entity : entities) {
			entity->step(currentTime);
		}
		vector<Entity*> destroyedEntities;
		for (auto entity : entities) {
			if (entity->isDestroyed) destroyedEntities.push_back(entity);
		}

		if (player->isDestroyed) gameNotOver = false;

		for (auto entity : destroyedEntities) {
			//cout << "Destroy: " << entity;
			entities.erase(std::remove(entities.begin(), entities.end(), entity), entities.end());
			enemies.erase(std::remove(enemies.begin(), enemies.end(), entity), enemies.end());
			projectiles.erase(std::remove(projectiles.begin(), projectiles.end(), entity), projectiles.end());
		}
		for (auto entity : enemies) {
			entity->render();
		}
		for (auto entity : projectiles) {
			entity->render();
		}
		player->render();

		SDL_Delay(frameMilliSeconds);
		currentTime += timeStep;
		spawnTime *= 0.999;
		if (spawnTime < 1.5) spawnTime = 1.5;
		//cout << "time: " << currentTime;
	}
}