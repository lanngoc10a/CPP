#include "TrafficLight.h"

TrafficLight::TrafficLight() {

}
TrafficLight::TrafficLight(int X, int Y,int light_enabled) {
	x = X;
	y = Y;

	if (light_enabled == 0) {
		setRed();
		loopingDown = true;
	}
	else if (light_enabled == 1) {
		setYellow();
	}
	else if (light_enabled == 2) {
		setGreen();
	}
	else {
		setRed();
	}
}

int TrafficLight::getX() {
	return x;
}

int TrafficLight::getY() {
	return y;
}

int *TrafficLight::getGreen() {
	return green;
}

int* TrafficLight::getYellow() {
	return yellow;
}

int* TrafficLight::getRed() {
	return red;
}

void TrafficLight::setGreen() {
	green[0] = 127;
	green[1] = 204;
	green[2] = 40;

	yellow[0] = 128;
	yellow[1] = 128;
	yellow[2] = 128;

	red[0] = 128;
	red[1] = 128;
	red[2] = 128;

	redEnabled = false;
	yellowEnabled = false;
	greenEnabled = true;

}

void TrafficLight::setYellow() {
	yellow[0] = 251;
	yellow[1] = 208;
	yellow[2] = 75;

	green[0] = 128;
	green[1] = 128;
	green[2] = 128;

	yellowEnabled = true;
}
void TrafficLight::setRed() {
	red[0] = 179;
	red[1] = 0;
	red[2] = 6;

	green[0] = 128;
	green[1] = 128;
	green[2] = 128;

	yellow[0] = 128;
	yellow[1] = 128;
	yellow[2] = 128;

	greenEnabled = false;
	yellowEnabled = false;
	redEnabled = true;
	
}

void TrafficLight::setLoopingDown(bool loop) {
	loopingDown = loop;
}

bool TrafficLight::getLoopingDown() {
	return loopingDown;
}
bool TrafficLight::getGreenEnabled() {
	return greenEnabled;
}
bool TrafficLight::getYellowEnabled() {
	return yellowEnabled;
}
bool TrafficLight::getRedEnabled() {
	return redEnabled;
}