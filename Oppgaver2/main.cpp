
#include <iostream>
#include "GameManager.h"

int main()
{
    int NumberPlayer;
    std::cout << "Enter the number of players: ";
    std::cin  >> NumberPlayer;
    std::cout << std::endl << "Initializing " << NumberPlayer << " players. \n" << std::endl;

    int PlayerClassnr;
    std::cout << "Player Classes; 1-Wizard. 2-Troll. 3-Assassin ";
    std::cin  >> PlayerClassnr;
    std::cout << std::endl << "Pick player 1's class: " << PlayerClassnr << ". \n" << std::endl;

    GameManager game;
    game.startGame();
    return 0;
    
    // GameManager wiz; //parameter after the constructor

    // // auto a=std::make_shared<wiz>("Alice");
    // // std::cout<<"a's name is="<<a->name<<std::endl;
    // wiz.CastSpell();
    // wiz.Fight();
    // wiz.PrintStats();
    // wiz.Talk();
    // wiz.Talk();
    // return 0;
    //wiz.m:armor=10 //cannot access private member
}

// class GameManager {
// public:
//     std::string name;
//     std::shared_ptr<GameManager> type;
//     GameManager(std::string name): name(name){
//     }
//     ~GameManager(){
//         std::cout<<name<<" is gone!"<<std::endl;
//     }
   

//     void Fight();
//     void Talk();
//     void CastSpell();
//     void PrintStats();
//     private:
//     //Medlemsdata/hjelpefunk.
//     std::string m_name = "NoName";
//     int m_hitPoints = 0;
//     int m_magicPoints = 0;
//     int m_armor = 0;
// };

// void GameManager::Fight(){
//     cout << "Fighting!" << endl;
// }
// void GameManager::Talk(){
//     cout << "Talking." << endl;
// }
// void GameManager::CastSpell(){
//     cout << "Casting spell." << endl;
// }
// void GameManager::PrintStats(){
//     cout << "GameManager stats:"
//          << "\nName:\t" << m_name 
//          << "\n# hitpoints:\t" << m_hitPoints ;
// };