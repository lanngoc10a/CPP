#include <iostream>

int main() {
    //int a = 42;
    //int a(42);
    std::string helloString("Hello world!");
    std::string newString = helloString.substr(2,8);
    //(cannot write)? std::string newString {helloString.substr(2,8)};
    std::cout << newString << std::endl;
}

// int main() {
    // double a = 3.125325;
    // int b = 42;
    // double c = 1.1e+6;
    // std::cout << "a=" << a << " b=" << b << " c=" << c << std::endl;
    // std::cout.precision(3); //3 all, not 3 digits
    // std::cout << "a=" << a << " b=" << b << " c=" << c << std::endl;
    // std::cout << std::fixed;
    // std::cout << "a=" << a << " b=" << b << " c=" << c << std::endl;
    // std::cout << std::scientific;
    // std::cout << "a=" << a << " b=" << b << " c=" << c << std::endl;
    // std::cout << "Hello, world!\n" << std::endl;
// }
// int main() {
//     int age;
//     std::cout << "Write your age: ";
//     std::cin  >> age;
//     std::cout << std::endl << "Ah -you are " << age << " years old." << std::endl;
//     return 0;
// }
