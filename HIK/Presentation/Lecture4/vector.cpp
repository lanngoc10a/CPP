//https://www.youtube.com/watch?v=whQQF4kVjPY
#include <iostream>
#include <vector>
using namespace std;

int main(){
    vector<int> vec= {1, 18, 19};
    vec[2] = 25;
    vec.push_back(5);
    vec.push_back(10);
    vec.push_back(14);

    for (int i=0; i< vec.size(); i++){
        cout << vec[i] << endl;
    };
    
}