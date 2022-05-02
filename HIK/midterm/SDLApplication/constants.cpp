#pragma once
#include <string>
#include "constants.h"
using namespace std;

string basePath = "..\\";

int resX = 1080;
int resY = 720;
int borderLimit = 50;
int playerBottomArea = 900;
int playerSpeed = 4;
int playerAcceleration = 70;
float currentTime = 0;
int frameMilliSeconds = 16;
float timeStep = 1.0 / frameMilliSeconds;
float stageSize = 2000;
float stageMinX = -stageSize;
float stageMaxX = resX + stageSize;
float stageMinY = -stageSize;
float stageMaxY = resY + stageSize;
bool gameNotOver = true;