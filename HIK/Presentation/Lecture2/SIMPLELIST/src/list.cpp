#include "include/list.h"

void List::print_menu(){
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

void List::add_item(){
    cout << "\n\n\n\n\n\n\n\n\n\n\n\n";
    cout << "**** Add Item ********\n";
    cout << "Type in an item and press enter: ";

    string item;
    cin >> item;
    list.push_back(item);
    cout << "Successfully added " << item << " to the list \n\n\n\n\n";
    cin.clear(); //make sure nothing stuck in the console buffer
    print_menu();
}

void List::delete_item(){
    cout << "*****Delete Item******\n";
    cout << "Select an item index number to delete\n";
    if(list.size()){
        for (int i=0; i < (int)list.size(); i++){
            cout << i << ":" << list[i] << "\n";
        }
    }
    else {
        cout << "No items to delete. \n"; 
    }
    print_menu();
}

void List::print_list(){
    cout << "\n\n\n\n\n\n\n\n\n\n\n\n";
    cout << "******** Printing List ******";

    for (int list_index=0; list_index < (int)list.size(); list_index++){
        cout << " * " << list[list_index] << "\n";
    }

    cout << "M - Menu \n";
    char choice; 
    cin >> choice; // allow user to put sth in the choice character

    if( choice == 'M' ||  choice == 'm'){
        print_menu();
    }
    else{
        cout << "Invalid choice. Quitting.. \n";
    }
}