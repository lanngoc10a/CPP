#include <iostream>
#include <memory>
// &: addresse of,  ID.  pass by reference to reference //& changes number from 42 to 5
//*pointer:In C++ int* intPtr=nullptr; 

class Person{
public:
    std::string name;
    std::shared_ptr<Person> spouse;
    Person(std::string name): name(name){
    }
    ~Person(){
        std::cout<<name<<" is gone!"<<std::endl;
    }
};


int main(){
    //Person*test=new Person("Alice");
    auto a=std::make_shared<Person>("Alice");
    auto b=std::make_shared<Person>("Bob");
    std::cout<<"a.use_count="<<a.use_count()<<" b.use_count="<<b.use_count()<<std::endl;
    //std::cout<<"a's name is="<<a->name<<std::endl;
    a->spouse=b;
    b->spouse=a;
    std::cout<<"a.use_count="<<a.use_count()<<" b.use_count="<<b.use_count()<<std::endl;
};

