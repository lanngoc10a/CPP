#include <iostream>
#include <SDL.h>
#include <string>
using namespace std;

string basePath = "C:\\Users\\...\\CPP\\SDLApplication\\SDLApplication\\";
string previousImage = "";

int drawImage(SDL_Window* window, SDL_Renderer* renderer, string name) {
	if (name == previousImage) return 0;
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
	coords.x = 0; // Endre disse for å "flytte" bildet i vinduet/renderer
	coords.y = 0;

	SDL_FreeSurface(surface); // Frigjør surface fra CPU-minnet
		/* GAME LOOP START */
		// Endre koordinatene ved brukerinput (coords.x, coords.y
		// Legg til objektet i vinduets renderer
	SDL_RenderCopy(renderer, drawable, nullptr, &coords);
	// BLIT/rendre bildet
	SDL_RenderPresent(renderer);
}

// NB: Denne koden tar seg IKKE av feilhåndtering ved init.
int main(int argc, char* argv[])
{
	SDL_Init(SDL_INIT_VIDEO); // Init. SDL2
	SDL_Window* window = nullptr; // Pointer to Window
	// Lag et vindu med gitte settings
	// For alle mulige konfigurasjonsalternativer, se: http://goo.gl/8VDJN
	window = SDL_CreateWindow(
		"Pilretninger",
		// window title
		SDL_WINDOWPOS_UNDEFINED,
		// initial x position
		SDL_WINDOWPOS_UNDEFINED,
		// initial y position
		550,
		// width, in pixels
		400,
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

	bool gameNotOver = true;
	int numKeys;
	const Uint8* keys = SDL_GetKeyboardState(&numKeys);

	while (gameNotOver) {
		string file = "default.bmp";
		// Oppdater key state-arrayen
		SDL_PumpEvents();
		if (keys[SDL_SCANCODE_W] != 0 || keys[SDL_SCANCODE_UP] != 0)
			file = "up.bmp";
		if (keys[SDL_SCANCODE_A] != 0 || keys[SDL_SCANCODE_LEFT] != 0)
			file = "left.bmp";
		if (keys[SDL_SCANCODE_S] != 0 || keys[SDL_SCANCODE_DOWN] != 0)
			file = "down.bmp";
		if (keys[SDL_SCANCODE_D] != 0 || keys[SDL_SCANCODE_RIGHT] != 0)
			file = "right.bmp";

		// Escape/Avslutt
		if (keys[SDL_SCANCODE_ESCAPE] != 0 || SDL_HasEvent(SDL_QUIT)) {
			gameNotOver = false; // Avslutt
		}

		SDL_RenderClear(renderer);
		drawImage(window, renderer, file);
		SDL_Delay(16);
	}

	SDL_DestroyWindow(window);
	SDL_Quit();
	return EXIT_SUCCESS;
}



