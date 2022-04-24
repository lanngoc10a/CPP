#include <iostream>
class IInterfaceDemo {
public:
    virtual ~IInterfaceDemo() {}
    virtual void toImplement() = 0;
};
class Implementer : public IInterfaceDemo {
public:
    void toImplement() override {
        std::cout << "Implemented Method" << std::endl;
    }
};
int main() {
    Implementer implementer;
    implementer.toImplement();
    return 0;
}