#include <iostream>
#include <vector>
using namespace std;

class List {
    private:
    protected:
    public:
    List(){
        //constructor
    }
    ~List(){
        //destructor
    }


    vector<string> list;  //Vector is a sequential container to store elements and not index based. Array stores a fixed-size sequential collection of elements of the same type and it is index based
    string name;

    void print_menu();
    void print_list();
    void add_item();
    void delete_item();
};