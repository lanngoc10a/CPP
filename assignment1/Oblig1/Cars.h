#pragma once
#include "Car.h"
#include "framework.h"

class Cars {

	

public:
	Car cars[100];
	int numberOfCars;
	Cars();
	void addCar(Car car);
	Car getCar(int index);
	int getNumberOfCars();
	void printCars(HBRUSH carBrush, HDC hDC);
};

