#include <iostream>
#include <memory>
// &: addresse of, ID. pass by reference to reference //& changes number from 42 to 5
//*pointer: In C++ int* intPtr=nullptr; 

class OneNumber{
public:
    int x;
    explicit OneNumber(int i): x(i){
    }
};

void settoFive(OneNumber &value){
    value.x=5;
}

int main(){
    OneNumber number(42);
    auto number2 = std::make_shared<OneNumber>(21);
    auto a = std::make_shared<int>(10);
    (*a)+=10;
    std::cout <<"a="<<*a <<std::endl;
    auto b=a;
    (*b)+=10;
    std::cout <<"b="<<*a <<std::endl;
    std::cout <<"use_count="<<a.use_count()<<std::endl;
    b=nullptr;
    std::cout<<"use_count="<<a.use_count()<<std::endl;
    a=nullptr;
    //std::cout<<"use_count="<<a.use_count()<<std::endl;//nullpointer, not possible to reference it
    std::cout <<"a="<<*a <<std::endl;
    settoFive(number);
    settoFive(*number2);
    std::cout << "Value is: " << number2->x << std :: endl;
    return 0;
}

