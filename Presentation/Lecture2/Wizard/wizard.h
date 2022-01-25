//wizard.h

#include <string>
using std::string;

class Wizard {
    public:
    //Medlemsfunksjoner. (prototyper)
    void Fight();
    void Talk();
    void CastSpell();
    void PrintStats();
    private:
    //Medlemsdata/hjelpefunk.
    std::string m_name = "NoName";
    int m_hitPoints = 0;
    int m_magicPoints = 0;
    int m_armor = 0;
};