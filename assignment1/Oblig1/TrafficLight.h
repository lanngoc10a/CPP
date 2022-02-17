#pragma once
#include <iostream>


using namespace std;

class TrafficLight
{

public:

	TrafficLight();
	void makeLight(HDC hDC, HBRUSH rectBrush, HBRUSH cirBrush, int x, int y
		, int rectRGB[], int redCurrentRGB[], int yellowCurrentRGB[], int greenCurrentRGB[]);

};

