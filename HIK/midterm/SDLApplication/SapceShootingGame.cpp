#pragma once
#include <iostream>
#include <SDL.h>
#include <string>
#include <vector>
#include "constants.h"
#include "Player.h"
#include "Enemy.h"
#include "Projectile.h"
#include "Game.h"
using namespace std;

// NB: Denne koden tar seg IKKE av feilhåndtering ved init.
int main(int argc, char* argv[])
{
	SDL_Init(SDL_INIT_VIDEO); // Init. SDL2
	SDL_Window* window = nullptr; // Pointer to Window
	// Lag et vindu med gitte settings
	// For alle mulige konfigurasjonsalternativer, se: http://goo.gl/8VDJN
	window = SDL_CreateWindow(
		"Space Shooter Game",
		// window title
		SDL_WINDOWPOS_UNDEFINED,
		// initial x position
		SDL_WINDOWPOS_UNDEFINED,
		// initial y position
		resX,
		// width, in pixels
		resY,
		// height, in pixels
		SDL_WINDOW_SHOWN | SDL_WINDOW_OPENGL // flags
	);
	// Sjekk om noe gikk galt
	if (window == nullptr)
	{
		std::cerr << "Failed to create window: "
			<< SDL_GetError() << std::endl;
		SDL_Quit(); // Rydd opp!
		return EXIT_FAILURE;
	}

	// NB: denne koden "bygger på" forrige eksempel!
	SDL_Renderer* renderer; // Pointer to window's renderer
	// Lag en renderer til det spesifikke vinduet. Setter Hardware accelerated flag.
	renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);
	// Sjekk om noe gikk galt
	if (renderer == nullptr)
	{
		std::cerr << "Failed to create renderer: "
			<< SDL_GetError() << std::endl;
		SDL_DestroyWindow(window); SDL_Quit(); // rydd opp
		return EXIT_FAILURE;
	}
	// Set renderens bakgrunnsfarge til svart
	SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);

	// Set window size
	SDL_SetWindowSize(window, resX, resY);
	//SDL_SetWindowFullscreen( window, 0);

	auto game = new Game(window, renderer);
	game->run();

	

	SDL_DestroyWindow(window);
	SDL_Quit();
	return EXIT_SUCCESS;
}



