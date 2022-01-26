 
#include <iostream>
using namespace std;

int main(int, char**) {
    char buffer[25]; 
    std::cout << "Enter a word: "; 
    std::cin >> buffer; 
    std::cout << buffer << "\n"; 
}

//What happens if you write a word longer than the buffer (25 characters)? 
//No problem, the program writes out all characters 