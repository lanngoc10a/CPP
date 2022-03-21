#pragma once
class Car
{
	int x;
	int y;
	int rgb[3];

public:
	Car();
	Car(int x, int y);
	Car(int x, int y, int r, int g, int b);
	int getX();
	int getY();
	int getR();
	int getG();
	int getB();
	void setX(int X);
	void setY(int Y);
	
};

