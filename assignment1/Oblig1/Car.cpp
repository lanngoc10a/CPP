#include "Car.h"

Car::Car() {

}

Car::Car(int X, int Y) {
	x = X;
	y = Y;
}

Car::Car(int X, int Y, int r, int g, int b) {
	x = X;
	y = Y;
	rgb[0] = r;
	rgb[1] = g;
	rgb[2] = b;
 }

int Car::getX() {
	return x;
}

int Car::getY() {
	return y;
}

void Car::setX(int X) {
	x = X;
}

void Car::setY(int Y) {
	y = Y;
}

int Car::getR() {
	return rgb[0];
}

int Car::getG() {
	return rgb[1];
}

int Car::getB() {
	return rgb[2];
}