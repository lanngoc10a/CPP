#pragma once
class TrafficLight
{
	int x;
	int y;
	int green[3] = { 0,0,0 };
	bool greenEnabled = false;
	
	int yellow[3] = { 0,0,0 };
	bool yellowEnabled = false;

	int red[3] = { 0,0,0 };
	bool redEnabled = false;

	bool loopingDown;

public:
	TrafficLight();
	TrafficLight(int x, int y, int light_enabled);

	int getX();
	int getY();

	int *getGreen();
	int *getYellow();
	int *getRed();

	void setGreen();
	void setYellow();
	void setRed();
	void setLoopingDown(bool loop);
	bool getLoopingDown();
	bool getGreenEnabled();
	bool getYellowEnabled();
	bool getRedEnabled();

};


