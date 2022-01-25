//
// Created by Kjetil Raaen on 24/01/2022.
//

#include "PlayerCharacter.h"
#include <iostream>
#include <vector>

PlayerCharacter::PlayerCharacter(std::string name, int hp) : m_name(name), m_hp(hp) {

}

const std::string &PlayerCharacter::getName() const {
    return m_name;
}

void PlayerCharacter::runTurn(std::vector<PlayerCharacter> &playerCharacters) {
    std::cout << m_name << "'s turn! You have " << m_hp << " HP." << std::endl;
    std::cout << "Who do you want to attack?" << std::endl;
    int playerNum = 0;
    for (const auto &player: playerCharacters) {
        std::cout << playerNum << ": " << player.m_name << std::endl;
        playerNum++;
    }
    int attackWho = -1;
    std::cin >> attackWho;
    if (attackWho < 0 || attackWho >= playerCharacters.size()) {
        std::cout << "Invalid target!" << std::endl;
        return;
    }

    std::cout << m_name << " is attacking " << playerCharacters.at(attackWho).m_name << std::endl;
    attack(playerCharacters.at(attackWho));
}

void PlayerCharacter::attack(PlayerCharacter &target) {
    target.m_hp -= 20;
}

bool PlayerCharacter::isDead() const { return m_hp <= 0; }
