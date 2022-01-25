
//https://www.youtube.com/watch?v=FbuuIgd4iLc

#include "include/list.h"

int main(int arg_count, char *args[]){
    if(arg_count>1){
        //string name(args[1]); //find a string datatype and string variable called name, in name we pass second argument
        //cout<< " Username " << args[1] <<endl;
        List simpleList;
        simpleList.name=string(args[1]);
        simpleList.print_menu();
    }
    else {
        cout << "Username not supplied.. existing the program" << endl;
    }
    return 0; 
}

