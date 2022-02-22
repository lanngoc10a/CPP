#include "Car.h"

Car::Car() {

}

Car::Car(int X, int Y) {
	x = X;
	y = Y;
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
