
//https://www.youtube.com/watch?v=FbuuIgd4iLc
#include <iostream>
#include <vector>
using namespace std; //no need for std in std:cout

void print_menu(string name);
void print_list();
void add_item();
void delete_item();

vector<string> list;  //Vector is a sequential container to store elements and not index based. Array stores a fixed-size sequential collection of elements of the same type and it is index based
string name;

int main(int arg_count, char *args[]){
    if(arg_count>1){
        //string name(args[1]); //find a string datatype and string variable called name, in name we pass second argument
        //cout<< " Username " << args[1] <<endl;
        name=string(args[1]);
        print_menu(name);
    }
    else {
        cout << "Username not supplied.. existing the program" << endl;
    }
    return 0; 
}

void print_menu(string name){
    int choice;
    cout << "********************\n";
    cout << "1-Print List.\n";
    cout << "2-Add to List.\n";
    cout << "3-Delete from List.\n";
    cout << "4-Quit.\n";
    cout << "Enter your choice and press return: ";

    cin >> choice;

    if( choice == 4){
        exit(0); //terminal the status sucessfully and exist
    }
    else if (choice ==1){
        print_list();
    }
    else if (choice ==2){
        add_item();
    }
    else if (choice ==3){
        delete_item();
    }
    else {
        cout << "Sorry choice not implemented yet";
    }
}

void add_item(){
    cout << "\n\n\n\n\n\n\n\n\n\n\n\n";
    cout << "**** Add Item ********\n";
    cout << "Type in an item and press enter: ";

    string item;
    cin >> item;
    list.push_back(item);
    cout << "Successfully added " << item << " to the list \n\n\n\n\n";
    cin.clear(); //make sure nothing stuck in the console buffer
    print_menu(name);
}

void delete_item(){
    cout << "*****Delete Item******\n";
    cout << "Select an item index number to delete\n";
    if(list.size()){
        for (int i=0; i < list.size(); i++){
            cout << i << ":" << list[i] << "\n";
        }
    }
    else {
        cout << "No items to delete. \n"; 
    }
    print_menu(name);
}

void print_list(){
    cout << "\n\n\n\n\n\n\n\n\n\n\n\n";
    cout << "******** Printing List ******";

    for (int list_index=0; list_index < list.size(); list_index++){
        cout << " * " << list[list_index] << "\n";
    }

    cout << "M - Menu \n";
    char choice; 
    cin >> choice; // allow user to put sth in the choice character

    if( choice == 'M' ||  choice == 'm'){
        print_menu(name);
    }
    else{
        cout << "Invalid choice. Quitting.. \n";
    }
}