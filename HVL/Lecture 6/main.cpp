#include <iostream>
#include <SDL.h>

int main() {
    std::cout << "Hello, World!" << std::endl;

    SDL_Init(SDL_INIT_VIDEO); // Init. SDL2
    SDL_Window *window = SDL_CreateWindow(
            "Et awesome SDL2-vindu!",          //    window title
            SDL_WINDOWPOS_UNDEFINED,           //    initial x position
            SDL_WINDOWPOS_UNDEFINED,           //    initial y position
            800,                               //    width, in pixels
            600,                               //    height, in pixels
            SDL_WINDOW_SHOWN | SDL_WINDOW_OPENGL //    flags
    );
// Sjekk om noe gikk galt
    if (window == nullptr) {
        std::cerr << "Failed to create window: "
                  << SDL_GetError() << std::endl;
        SDL_Quit(); // Rydd opp!
        return EXIT_FAILURE;
    }
    SDL_Renderer *renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);
// Sjekk om noe gikk galt
    if (renderer == nullptr) {
        std::cerr << "Failed to create renderer: "
                  << SDL_GetError() << std::endl;
        SDL_DestroyWindow(window);
        SDL_Quit(); // rydd opp
        return EXIT_FAILURE;
    }

    // Set renderens bakgrunnsfarge til svart
    SDL_SetRenderDrawColor(renderer, 100, 100, 100, 255);
    SDL_RenderClear(renderer); // Nullstiller renderen

// Pause i 3 sekunder, lukk vinduet

// Last inn et bilde fra disk (NB: ren SDL støtter KUN BMP! Bruk SDL_Image)
    SDL_Surface *surface = SDL_LoadBMP("/Users/kjra001/CLionProjects/Forelesning_6/smiley.bmp");


    // Sjekk for feil
    if (surface == nullptr) {
        std::cerr << "Failed to load image: "
                  << SDL_GetError() << std::endl;
        SDL_DestroyRenderer(renderer);
        SDL_DestroyWindow(window);
        SDL_Quit(); // rydd opp
        return EXIT_FAILURE;
    }
    // Konverter surface om til et HW Accelerated Texture, laster objektet opp på skjermkortet
    SDL_Texture *drawable = SDL_CreateTextureFromSurface(renderer, surface);
    // Sett opp et "koordinatsystem" for bildet
    SDL_Rect coords;
    coords.h = surface->h / 2; // Samme bredde og høyde som surface
    coords.w = surface->w / 2;
    coords.x = 0; // Endre disse for å "flytte" bildet i vinduet/renderer
    coords.y = 0;

    SDL_FreeSurface(surface); // Frigjør surface fra CPU-minnet
    surface = nullptr;
    SDL_RenderCopy(renderer, drawable, nullptr, &coords);
    SDL_RenderPresent(renderer);
    SDL_RenderClear(renderer); // Tøm renderen for innhold

    bool gameNotOver = true;
// Variabler til å holde pekere til key states

    int numKeys; // Antall keys varierer fra system til system
    const Uint8 *keys = SDL_GetKeyboardState(&numKeys);
// Initialiser key state-pekeren

    while (gameNotOver) {
// Oppdater key state-arrayen
        SDL_PumpEvents();
        if (keys[SDL_SCANCODE_W] != 0)
            coords.y -= 1;
        if (keys[SDL_SCANCODE_A] != 0)
            coords.x -= 1;
        if (keys[SDL_SCANCODE_S] != 0)
            coords.y += 1;
        if (keys[SDL_SCANCODE_D] != 0)
            coords.x += 1;

// Sjekk om brukeren har trykket Escape
        if (keys[SDL_SCANCODE_ESCAPE] != 0) {
            gameNotOver = false; // Avslutt
        }

// Sjekk om brukeren har krysset ut (X) vinduet
        if (SDL_HasEvent(SDL_QUIT)) {
            gameNotOver = false; // Avslutt
        }
        SDL_RenderCopy(renderer, drawable, nullptr, &coords);
        SDL_RenderPresent(renderer);
        SDL_RenderClear(renderer); // Tøm renderen for innhold

    }

    SDL_DestroyWindow(window);
    SDL_Quit(); // Be SDL om å rydde opp
    return EXIT_SUCCESS;


    return 0;
}
