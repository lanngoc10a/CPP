// Oblig1.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "Oblig1.h"
#include "Car.h"
#include "TrafficLight.h"
#include <iostream>
#include <queue>
#include <cstring>
#include <atlstr.h>

using namespace std;

#define TrafficLights    1
#define SpawnCars   2
#define MoveCars	3
#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

Car carsHorizontal[1000];
Car carsVertical[1000];
Car carsHorizontalEast[1000];
Car carsVerticalSouth[1000];

TrafficLight lights[4];

queue<Car> queueHorizontal;
queue<Car> queueVertical;
queue<Car> queueHorizontalEast;
queue<Car> queueVerticalSouth;

int numberOfCarsHorizontal;
int numberOfCarsVertical;
int numberOfCarsHorizontalEast;
int numberOfCarsVerticalSouth;

int spawnVerticalCarProbability;
int spawnHorizontalCarProbability;

int wait;

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_OBLIG1, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_OBLIG1));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}

//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//

ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_OBLIG1));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_OBLIG1);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//

const wchar_t g_szClassName[] = L"myWindowClass";


// Step 4: the Window Procedure
LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	HDC hDC;			// handle to the device context (permission to draw)
	PAINTSTRUCT Ps;		// a variable that you need

	HBRUSH cirBrush;
	HBRUSH carVerticalBrush;
	HBRUSH carHorizontalBrush;

	// Rectangle
	int rectRGB[3] = { 0,0,0 };

	// Static colors
	static int grayRGB[3] = { 128, 128, 128 };
	static int redRGB[3] = { 179,0,6 };
	static int yellowRGB[3] = { 251,208,75 };
	static int greenRGB[3] = { 127, 204, 40 };
	static int carRGB[3] = { 251,208,75 };

	int road_horizontal_positionX = 300;
	int road_horizontal_positionY = 350;

	int road_vertical_positionX = 500;
	int road_vertical_positionY = 150;

	// Probability text
	int probabilityText_1X = 50;
	int probabilityText_1Y = 200;
	int probabilityText_2X = 50;
	int probabilityText_2Y = 230;

	TCHAR text[256];
	swprintf_s(text, 256, L"Horizontal Car Spawn Probability: %d", spawnHorizontalCarProbability);
	swprintf_s(text, 256, L"Vertical Car Spawn Probability: %d", spawnVerticalCarProbability);

	switch (msg)
	{

	case WM_CREATE:

		SetTimer(hwnd, TrafficLights, 2000, NULL);
		SetTimer(hwnd, MoveCars, 50, NULL);
		SetTimer(hwnd, SpawnCars, 1000, NULL);

		numberOfCarsHorizontal = 0;
		numberOfCarsVertical = 0;
		numberOfCarsHorizontalEast = 0;
		numberOfCarsVerticalSouth = 0;

		spawnVerticalCarProbability = 40;
		spawnHorizontalCarProbability = 40;

		lights[0] = TrafficLight(435, 200, 0);
		lights[1] = TrafficLight(320, 550, 2);
		lights[2] = TrafficLight(760, 250, 2);
		lights[3] = TrafficLight(620, 580, 0);

		
		for (int i = 0; i < 5; i++) {
			carsVertical[numberOfCarsVertical] = Car(507, 0);
			numberOfCarsVertical++;
			carsHorizontal[numberOfCarsHorizontal] = Car(0, 345);
			numberOfCarsHorizontal++;
			carsVerticalSouth[numberOfCarsVerticalSouth] = Car(540, 700);
			numberOfCarsVerticalSouth++;
			carsHorizontalEast[numberOfCarsHorizontalEast] = Car(1000, 340);
			numberOfCarsHorizontalEast++;
		}
		
		return 0;
	
	case WM_PAINT:
	{
		hDC = BeginPaint(hwnd, &Ps);

		HBRUSH roadBrush = CreateSolidBrush(RGB(grayRGB[0], grayRGB[1], grayRGB[2]));
		HBRUSH centerLineBrush = CreateSolidBrush(RGB(yellowRGB[0], yellowRGB[1], yellowRGB[2]));
		HBRUSH rectBrush = CreateSolidBrush(RGB(rectRGB[0], rectRGB[1], rectRGB[2]));

		HGDIOBJ horg = SelectObject(hDC, rectBrush);

		for (int i = 0; i < 4; i++) {
			SelectObject(hDC, rectBrush);
			Rectangle(hDC, lights[i].getX() + 25, lights[i].getY() - 170,
				lights[i].getX() - 40, lights[i].getY() + 25);

			int* currentRed = lights[i].getRed();

			cirBrush = CreateSolidBrush(RGB(currentRed[0],
				currentRed[1], currentRed[2]));
			SelectObject(hDC, cirBrush);
			Ellipse(hDC, lights[i].getX() + 18, lights[i].getY() - 160
				, lights[i].getX() - 32, lights[i].getY() - 110);
			DeleteObject(cirBrush);

			int* currentYellow = lights[i].getYellow();

			cirBrush = CreateSolidBrush(RGB(currentYellow[0],
				currentYellow[1], currentYellow[2]));
			SelectObject(hDC, cirBrush);
			Ellipse(hDC, lights[i].getX() + 18, lights[i].getY() - 100
				, lights[i].getX() - 32, lights[i].getY() - 50);
			DeleteObject(cirBrush);

			int* currentGreen = lights[i].getGreen();

			cirBrush = CreateSolidBrush(RGB(currentGreen[0],
				currentGreen[1], currentGreen[2]));
			SelectObject(hDC, cirBrush);
			Ellipse(hDC, lights[i].getX() + 18, lights[i].getY() - 40
				, lights[i].getX() - 32, lights[i].getY() + 10);
			DeleteObject(cirBrush);
		}

		/*
			Roads
		*/

		SelectObject(hDC, roadBrush);

		//Horizontal road
		Rectangle(hDC, road_horizontal_positionX + 1000, road_horizontal_positionY - 70
			, road_horizontal_positionX - 300, road_horizontal_positionY + 25);

		// Vertical road
		Rectangle(hDC, road_vertical_positionX + 70, road_vertical_positionY - 150
			, road_vertical_positionX - 25, road_vertical_positionY + 600);

		/*
			Center lane lines
		*/

		SelectObject(hDC, centerLineBrush);
		Rectangle(hDC, road_horizontal_positionX + 1000, road_horizontal_positionY - 20
			, road_horizontal_positionX - 300, road_horizontal_positionY - 25);

		Rectangle(hDC, road_vertical_positionX + 20, road_vertical_positionY - 150
			, road_vertical_positionX + 25, road_vertical_positionY + 600);
		DeleteObject(centerLineBrush);

		/*
			Intersection square
		*/

		SelectObject(hDC, roadBrush);
		Rectangle(hDC, road_vertical_positionX + 70, road_horizontal_positionY - 70
			, road_vertical_positionX - 25, road_horizontal_positionY + 25);
		DeleteObject(roadBrush);

		/*
			Probability text
		*/

		SelectObject(hDC, rectBrush);
		text[256];
		swprintf_s(text, 256, L"Horizontal Car Spawn Probability: %d", spawnHorizontalCarProbability);	// Horizontal car spawn text
		TextOut(hDC, probabilityText_1X, probabilityText_1Y, text, wcslen(text));
		swprintf_s(text, 256, L"Vertical Car Spawn Probability: %d", spawnVerticalCarProbability);	// Vertical car spawn text
		TextOut(hDC, probabilityText_2X, probabilityText_2Y, text, wcslen(text));

		swprintf_s(text, 256, L"Number of cars: %d", (numberOfCarsHorizontal 
			+ numberOfCarsVertical + numberOfCarsVerticalSouth + numberOfCarsHorizontalEast - 20));	// Horizontal car spawn text
		TextOut(hDC, 50, 400, text, wcslen(text));

		/*
			Cars
		*/

		for (int i = 5; i < numberOfCarsHorizontal; i++) {

			carHorizontalBrush = CreateSolidBrush(RGB(carsHorizontal[i].getR()
				, carsHorizontal[i].getG(), carsHorizontal[i].getB()));
			SelectObject(hDC, carHorizontalBrush);

			if (carsHorizontal[i].getX() < 1300) {
				Rectangle(hDC, carsHorizontal[i].getX() + 10
					, carsHorizontal[i].getY() - 5
					, carsHorizontal[i].getX() - 25
					, carsHorizontal[i].getY() + 20);
			}

			DeleteObject(carHorizontalBrush);
		}

		for (int i = 5; i < numberOfCarsHorizontalEast; i++) {

			carHorizontalBrush = CreateSolidBrush(RGB(carsHorizontalEast[i].getR()
				, carsHorizontalEast[i].getG(), carsHorizontalEast[i].getB()));
			SelectObject(hDC, carHorizontalBrush);

			if (carsHorizontalEast[i].getX() < 1300) {
				Rectangle(hDC, carsHorizontalEast[i].getX() + 10
					, carsHorizontalEast[i].getY() - 5
					, carsHorizontalEast[i].getX() - 25
					, carsHorizontalEast[i].getY() + 20);
			}

			DeleteObject(carHorizontalBrush);
		}

		for (int i = 5; i < numberOfCarsVertical; i++) {

			carVerticalBrush = CreateSolidBrush(RGB(carsVertical[i].getR(), 
				carsVertical[i].getG(), carsVertical[i].getB()));

			SelectObject(hDC, carVerticalBrush);

			if (carsVertical[i].getY() < 800) {
				Rectangle(hDC, carsVertical[i].getX() + 5
					, carsVertical[i].getY() - 10
					, carsVertical[i].getX() - 20
					, carsVertical[i].getY() + 25);
			}

			DeleteObject(carVerticalBrush);
		}

		for (int i = 5; i < numberOfCarsVerticalSouth; i++) {

			carVerticalBrush = CreateSolidBrush(RGB(carsVerticalSouth[i].getR(),
				carsVerticalSouth[i].getG(), carsVerticalSouth[i].getB()));

			SelectObject(hDC, carVerticalBrush);

			if (carsVerticalSouth[i].getY() > 0)
				Rectangle(hDC, carsVerticalSouth[i].getX() + 5
					, carsVerticalSouth[i].getY() - 10
					, carsVerticalSouth[i].getX() - 20
					, carsVerticalSouth[i].getY() + 25);
			

			DeleteObject(carVerticalBrush);
		}
		
		SelectObject(hDC, horg);
		
		DeleteObject(roadBrush);
		DeleteObject(centerLineBrush);
		DeleteObject(rectBrush);
		DeleteObject(cirBrush);

		EndPaint(hwnd, &Ps);

		return 0;
	}

	case WM_TIMER:

		switch (wParam)
		{
		case TrafficLights:

			for (int i = 0; i < 4; i++) {
				if (lights[i].getRedEnabled() == true 
					&& lights[i].getYellowEnabled() == false) {
					lights[i].setYellow();
					lights[i].setLoopingDown(true);
				}
				else if (lights[i].getLoopingDown() == true && lights[i].getYellowEnabled() == true
					&& lights[i].getGreenEnabled() == false) {
					lights[i].setGreen();
				}
				else if (lights[i].getRedEnabled() == false  && lights[i].getYellowEnabled() == false
					&& lights[i].getGreenEnabled() == true) {
					lights[i].setYellow();
					lights[i].setLoopingDown(false);
				}
				else if (lights[i].getRedEnabled() == false
					&& lights[i].getYellowEnabled() == true ) {
					lights[i].setRed();	
				}
			}

			return 0;

		case MoveCars:

			for (int i = 0; i < numberOfCarsHorizontal; i++) {

				if (carsHorizontal[i].getX() == 456 - (queueHorizontal.size() * 48)
					&& (lights[1].getRedEnabled() == true || lights[1].getYellowEnabled())) {
						
						queueHorizontal.push(carsHorizontal[i]);
				}
				else {
					if (!queueHorizontal.empty() && carsHorizontal[i].getX() > 550) {
						queueHorizontal.pop();
					}
					carsHorizontal[i].setX(carsHorizontal[i].getX() + 6);
				}
			}

			for (int i = 0; i < numberOfCarsHorizontalEast; i++) {

				if (carsHorizontalEast[i].getX() == 606 + (queueHorizontalEast.size() * 48)
					&& (lights[1].getRedEnabled() == true || lights[1].getYellowEnabled())) {

					queueHorizontalEast.push(carsHorizontalEast[i]);
				}
				else {
					if (!queueHorizontalEast.empty()) {
						queueHorizontalEast.pop();
					}
					carsHorizontalEast[i].setX(carsHorizontalEast[i].getX() - 6);
				}
			}
		
			for (int i = 0; i < numberOfCarsVertical; i++) {

				if (carsVertical[i].getY() == 252 - (queueVertical.size() * 48)
					&& (lights[0].getRedEnabled() == true || lights[0].getYellowEnabled() == true)) {

					queueVertical.push(carsVertical[i]);
				}
				else {
					if (!queueVertical.empty() && carsVertical[i].getY() > 280) {
						queueVertical.pop();
					}
					carsVertical[i].setY(carsVertical[i].getY() + 6);
				}
			}


			for (int i = 0; i < numberOfCarsVerticalSouth; i++) {

				if (carsVerticalSouth[i].getY() ==  394 + (queueVerticalSouth.size() * 48)
					&& (lights[3].getRedEnabled() == true || lights[3].getYellowEnabled() == true)) {

					queueVerticalSouth.push(carsVerticalSouth[i]);
				}
				else {
					if (!queueVerticalSouth.empty() && carsVerticalSouth[i].getY() < 380) {
						queueVerticalSouth.pop();
					}
					carsVerticalSouth[i].setY(carsVerticalSouth[i].getY() - 6);
				}
			}

			if (wait < 121) {
				wait += 2;
			}
			
			InvalidateRect(hwnd, NULL, true);

			return 0;

		case SpawnCars:

			if (wait > 120) {

				int p_scaledH = (rand() % 101) + spawnHorizontalCarProbability;
				if (p_scaledH >= 100 && queueHorizontal.size() < 8) {
					carsHorizontal[numberOfCarsHorizontal] = Car(0, 345, (rand() + 256), (rand() + 256), (rand() + 256));
					numberOfCarsHorizontal++;
				}

				int p_scaledHEast = (rand() % 101) + spawnHorizontalCarProbability;
				if (p_scaledHEast >= 100 && queueHorizontalEast.size() < 11) {
					carsHorizontalEast[numberOfCarsHorizontalEast] = Car(1302, 295, (rand() + 256), (rand() + 256), (rand() + 256));
					numberOfCarsHorizontalEast++;
				}

				int p_scaledV = (rand() % 101) + spawnVerticalCarProbability;
				if (p_scaledV >= 100 && queueVertical.size() < 5) {
					carsVertical[numberOfCarsVertical] = Car(507, 0, (rand() + 256), (rand() + 256), (rand() + 256));
					numberOfCarsVertical++;
				}

				int p_scaledVSouth = (rand() % 101) + spawnVerticalCarProbability;
				if (p_scaledVSouth >= 100 && queueVerticalSouth.size() < 4) {
					carsVerticalSouth[numberOfCarsVerticalSouth] = Car(555, 700, (rand() + 256), (rand() + 256), (rand() + 256));
					numberOfCarsVerticalSouth++;
				}
			}

			return 0;
		}

		case WM_KEYDOWN:
			
			if (wParam == VK_RIGHT)
			{
				if (spawnHorizontalCarProbability <= 90)
				{
					spawnHorizontalCarProbability = spawnHorizontalCarProbability + 10;
				}
			}
			if (wParam == VK_LEFT)
			{
				if (spawnHorizontalCarProbability >= 10)
				{
					spawnHorizontalCarProbability = spawnHorizontalCarProbability - 10;
				}
			}
			if (wParam == VK_UP)
			{
				if (spawnVerticalCarProbability <= 90)
				{
					spawnVerticalCarProbability = spawnVerticalCarProbability + 10;
				}
			}
			if (wParam == VK_DOWN)
			{
				if (spawnVerticalCarProbability >= 10)
				{
					spawnVerticalCarProbability = spawnVerticalCarProbability - 10;
				}
			}

			return 0;

		case WM_CLOSE:
			DestroyWindow(hwnd);
			break;
		case WM_DESTROY:
			PostQuitMessage(0);
			break;
		default:
			return DefWindowProc(hwnd, msg, wParam, lParam);
		}
		return 0;
}


int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance,
	LPSTR lpCmdLine, int nCmdShow)
{
	WNDCLASSEX wc;
	HWND hwnd;
	MSG Msg;

	//Step 1: Registering the Window Class
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.style = 0;
	wc.lpfnWndProc = WndProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = g_szClassName;
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);

	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, L"Window Registration Failed!", L"Error!",
			MB_ICONEXCLAMATION | MB_OK);
		return 0;
	}

	// Step 2: Creating the Window
	hwnd = CreateWindowEx(
		WS_EX_CLIENTEDGE,
		g_szClassName,
		L"Miles Robson",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, CW_USEDEFAULT, 800, 600,
		NULL, NULL, hInstance, NULL);

	if (hwnd == NULL)
	{
		MessageBox(NULL, L"Window Creation Failed!", L"Error!",
			MB_ICONEXCLAMATION | MB_OK);
		return 0;
	}

	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);

	// Step 3: The Message Loop
	while (GetMessage(&Msg, NULL, 0, 0) > 0)
	{
		TranslateMessage(&Msg);
		DispatchMessage(&Msg);
	}
	return Msg.wParam;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}