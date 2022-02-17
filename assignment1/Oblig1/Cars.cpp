#include "Cars.h"
#include "framework.h"

Cars::Cars() {
	cars[99];
	numberOfCars = 0;
}

void Cars::addCar(Car car) {
	cars[numberOfCars] = car;
	numberOfCars = numberOfCars + 1;
}

Car Cars::getCar(int index) {
	return cars[index];
}

int Cars::getNumberOfCars() {
	return numberOfCars;
}

void Cars::printCars(HBRUSH carBrush, HDC hDC) {
	SelectObject(hDC, carBrush);

	for (int i = 0; i < numberOfCars; i++) {
		Rectangle(hDC, getCar(i).getX() + 10,getCar(i).getY() - 10
			, getCar(i).getX() - 25, getCar(i).getY() + 25);
	}

	DeleteObject(carBrush);
}