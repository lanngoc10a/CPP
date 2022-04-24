#ifndef RPG22_PLAYERCHARACTER_H
#define RPG22_PLAYERCHARACTER_H


#include <string>

class PlayerCharacter {
private:
    std::string m_name;
    int m_hp;
public:

    const std::string &getName() const;

public:

    PlayerCharacter(std::string name, int hp);

    void runTurn(std::vector<PlayerCharacter> &playerCharacters);

    void attack(PlayerCharacter &target);

    bool isDead() const;
};


#endif //RPG22_PLAYERCHARACTER_H
