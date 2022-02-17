#include <iostream>
#include "framework.h"
#include "TrafficLight.h"
using namespace std;


void TrafficLight::makeLight(HDC hDC, HBRUSH rectBrush, HBRUSH cirBrush, int x, int y
	, int rectRGB[], int redCurrentRGB[], int yellowCurrentRGB[], int greenCurrentRGB[]) {
	// Create the rectangle
	rectBrush = CreateSolidBrush(RGB(rectRGB[0], rectRGB[1], rectRGB[2]));
	SelectObject(hDC, rectBrush);
	Rectangle(hDC, x + 25, y - 170, x - 40, y + 25);

	// Create red circle
	cirBrush = CreateSolidBrush(RGB(redCurrentRGB[0], redCurrentRGB[1], redCurrentRGB[2]));
	SelectObject(hDC, cirBrush);
	Ellipse(hDC, x + 18, y - 160, x - 32, y - 110);

	// Create yellow circle
	cirBrush = CreateSolidBrush(RGB(yellowCurrentRGB[0], yellowCurrentRGB[1], yellowCurrentRGB[2]));
	SelectObject(hDC, cirBrush);
	Ellipse(hDC, x + 18, y - 100, x - 32, y - 50);


	// Create green circle
	cirBrush = CreateSolidBrush(RGB(greenCurrentRGB[0], greenCurrentRGB[1], greenCurrentRGB[2]));
	SelectObject(hDC, cirBrush);
	Ellipse(hDC, x + 18, y - 40, x - 32, y + 10);
};

























	/*HDC hDC;

	int redRGB[3] = { 179,0,6 };

	// Rectangle
	int rectRGB[3] = { 0,0,0 };
	int rectX = 232;
	int rectY = 337;



	const int penSize = 5;

	TrafficLight(HDC newhdc) {
		hDC = newhdc;

	}

	void createTrafficLight() {
		HPEN hRectPen = CreatePen(PS_SOLID, penSize, RGB(rectRGB[0], rectRGB[1], rectRGB[2]));
		SelectObject(hDC, hRectPen);

		Rectangle(hDC, rectX + 25, rectY - 250, rectX - 40, rectY + 25);
	}

	/*
	hDC = BeginPaint(hwnd, &Ps);
	hRectPen = CreatePen(PS_SOLID, penSize, RGB(rectRed, rectGreen, rectBlue));
	SelectObject(hDC, hRectPen);

	rectBrush = CreateSolidBrush(RGB(rectBrushRed, rectBrushGreen, rectBrushBlue));
	SelectObject(hDC, rectBrush);
	Rectangle(hDC, rectX + 25, rectY - 170, rectX - 40, rectY + 25);*/
