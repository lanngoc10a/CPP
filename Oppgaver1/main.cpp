#include <iostream>
int main() {
    int firstnr;
    std::cout << "Enter the first number: ";
    std::cin  >> firstnr;
    std::cout << std::endl << "You entered " << firstnr << ". \n" << std::endl;

    int secondnr;
    std::cout << "Enter the second number: ";
    std::cin  >> secondnr;
    std::cout << std::endl << "You entered " << secondnr << ". \n" << std::endl;

    int action;
    std::cout << "Enter an acction: (1-Addition, 2- Substraction, 3-Divison, 4-Multiplication, 5-Exit) ";
    std::cin  >> action;

    //int resultat;

    switch (action) {
        case 1:
        std::cout << "Result: " << firstnr + secondnr << std::endl;
        break;

        case 2:
        std::cout << "Result: " << firstnr - secondnr << std::endl;
        break;

        case 3:
            if(secondnr==0){
                std::cout << "Division by 0" << ". \n" << std::endl;
            }
            else{
                std::cout << "Result: " << firstnr / secondnr << std::endl;
            }
            break;

        case 4:
        std::cout << "Result: " << firstnr * secondnr << std::endl;
        break;

        case 5:
        std::cout << "Bye Bye: " << std::endl;
        break;

        default:
        std::cout << "\nIncorrect operation!  Try again: " << ". \n" << std::endl;

    return 0;
    }
}