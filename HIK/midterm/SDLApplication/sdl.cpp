//#pragma once
//#include <iostream>
//#include <SDL.h>
//#include <string>
//#include <vector>
//#include "constants.h"
//#include "Entity.cpp"
//using namespace std;
//
//int drawImage(SDL_Window* window, SDL_Renderer* renderer, string name, float x, float y) {
//	// Last inn et bilde fra disk (NB: ren SDL støtter KUN BMP! Bruk SDL Image)
//	SDL_Surface* surface = SDL_LoadBMP((basePath + name).c_str());
//	// Sjekk for feil
//	if (surface == nullptr)
//	{
//		std::cerr << "Failed to load image: "
//			<< SDL_GetError() << std::endl;
//		SDL_DestroyRenderer(renderer); SDL_DestroyWindow(window); SDL_Quit(); // rydd opp
//		return EXIT_FAILURE;
//	}
//
//	// Konverter surface om til et HW Accelerated Texture, laster objektet opp på skjermkortet
//	SDL_Texture* drawable = SDL_CreateTextureFromSurface(renderer, surface);
//	// Sett opp et "koordinatsystem" for bildet
//	SDL_Rect coords;
//	coords.h = surface->h; // Samme bredde og høyde som surface
//	coords.w = surface->w;
//	coords.x = std::round(x); // Endre disse for å "flytte" bildet i vinduet/renderer
//	coords.y = std::round(y);
//
//	SDL_FreeSurface(surface); // Frigjør surface fra CPU-minnet
//		/* GAME LOOP START */
//		// Endre koordinatene ved brukerinput (coords.x, coords.y
//		// Legg til objektet i vinduets renderer
//	SDL_RenderCopy(renderer, drawable, nullptr, &coords);
//	// BLIT/rendre bildet
//	SDL_RenderPresent(renderer);
//}