#include <iostream>
#include <string>
#include <memory>
// &: addresse of,  ID.  pass by reference to reference //& changes number from 42 to 5
//*pointer:In C++ int* intPtr=nullptr; 
//https://www.youtube.com/watch?v=qUDAkDvoLas

class Dog{
    std::string name;
public:
    Dog(std::string name): name(name){std::cout<<"Dog is created: "<< name << std::endl;}
    Dog(){ std::cout << "Nameless dog created." << std::endl; name = "nameless";}
    ~Dog(){ std::cout << "dog is destroyed: " << name << std::endl;}
    void bark() { std::cout << " Dog " << name << " rules!" << std::endl; }
};

void foo(){
    std::shared_ptr<Dog> p(new Dog("Gunner"));
    {
        std::shared_ptr<Dog> p2=p; //
        p2->bark(); 
        std::cout<<p.use_count();
    }
    p->bark();
};

int main(){
    foo();
    // Dog* d=new Dog("Tank");
    std::shared_ptr<Dog> p = std::make_shared<Dog>("Tank");
    (*p).bark();

    // auto a=std::make_shared<Person>("Alice");
    // auto b=std::make_shared<Person>("Bob");
    // std::cout<<"a.use_count="<<a.use_count()<<" b.use_count="<<b.use_count()<<std::endl;
    // //std::cout<<"a's name is="<<a->name<<std::endl;
    // a->spouse=b;
    // b->spouse=a;
    // std::cout<<"a.use_count="<<a.use_count()<<" b.use_count="<<b.use_count()<<std::endl;
};

