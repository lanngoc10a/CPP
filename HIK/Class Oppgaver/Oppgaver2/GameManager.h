
#ifndef GAMEMANAGER_H
#define GAMEMANAGER_H


#include <vector>
#include "PlayerCharacter.h"

class GameManager {

public:
    void startGame();

    std::vector<PlayerCharacter> playerCharacters;

    void runTurn();
};


#endif //RPG22_GAMEMANAGER_H
