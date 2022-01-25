#include <iostream>
#include "GameManager.h"

void GameManager::startGame() {
    //Should be asking players for this!
    playerCharacters.emplace_back("Gandalf", 50);
    playerCharacters.emplace_back("Saruman", 60);
    playerCharacters.emplace_back("Radagast", 70);
    while (playerCharacters.size() > 1)
        runTurn();
    std::cout << "Game over! " << playerCharacters.begin()->getName() << " won!" << std::endl;


}

void GameManager::runTurn() {
    for (auto iChar = std::begin(playerCharacters); iChar != std::end(playerCharacters);) {
        if (iChar->isDead()) {
            iChar = playerCharacters.erase(iChar);
            if (playerCharacters.size() <= 1)
                break;
        } else {
            iChar->runTurn(playerCharacters);
            iChar++;
        }
    }
}
