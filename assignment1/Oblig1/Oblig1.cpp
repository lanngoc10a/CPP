// Oblig1.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "Oblig1.h"
#include "Car.h"
#include "Cars.h"
#include <iostream>
#include <queue>
#include <cstring>
#include <atlstr.h>

using namespace std;

#define TrafficLight_1    1
#define TrafficLight_2	2
#define SpawnCars   3
#define MoveCars	4
#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

Car carsHorizontal[1000];
Car carsVertical[1000];

queue<Car> queueHorizontal;
queue<Car> queueVertical;

int numberOfCarsHorizontal;
int numberOfCarsVertical;
int numberOfCarsInQueue;
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
	int rectX = 232;
	int rectY = 337;

	// Static colors
	static int grayRGB[3] = { 128, 128, 128 };
	static int redRGB[3] = { 179,0,6 };
	static int yellowRGB[3] = { 251,208,75 };
	static int greenRGB[3] = { 127, 204, 40 };
	static int carRGB[3] = { 251,208,75 };

	/*
		Light 1
	*/

	// Red traffic light

	static int light1_redCurrentRGB[3] = { 179, 0, 6 };
	static bool light1_redEnabled = true;

	// Yellow traffic light
	
	static int light1_yellowCurrentRGB[3] = { 128, 128, 128 };
	static bool light1_yellowEnabled = false;

	// Green traffic light
	
	static int light1_greenCurrentRGB[3] = { 128, 128, 128 };
	static bool light1_greenEnabled = false;

	static int light1_loopingDown = true;

	/*
		Light 2
	*/

	// Red traffic light

	static int light2_redCurrentRGB[3] = { 128, 128, 128 };
	static bool light2_redEnabled = false;

	// Yellow traffic light

	static int light2_yellowCurrentRGB[3] = { 128, 128, 128 };
	static bool light2_yellowEnabled = false;

	// Green traffic light

	static int light2_greenCurrentRGB[3] = { 127, 204, 40 };
	static bool light2_greenEnabled = true;

	static int light2_loopingDown = true;

	// Light positions
	int light1_positionX = 435;
	int light1_positionY = 200;

	int light2_positionX = 320;
	int light2_positionY = 550;

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

		SetTimer(hwnd, TrafficLight_1, 2000, NULL);
		SetTimer(hwnd, TrafficLight_2, 2000, NULL);
		SetTimer(hwnd, MoveCars, 50, NULL);
		SetTimer(hwnd, SpawnCars, 1000, NULL);

		numberOfCarsHorizontal = 0;
		numberOfCarsVertical = 0;

		spawnVerticalCarProbability = 40;
		spawnHorizontalCarProbability = 40;

		
		for (int i = 0; i < 5; i++) {
			carsVertical[numberOfCarsVertical] = Car(507, 0);
			numberOfCarsVertical++;
			carsHorizontal[numberOfCarsHorizontal] = Car(0, 345);
			numberOfCarsHorizontal++;
		}
		

		return 0;
	
	case WM_PAINT:
	{
		hDC = BeginPaint(hwnd, &Ps);

		HBRUSH roadBrush = CreateSolidBrush(RGB(grayRGB[0], grayRGB[1], grayRGB[2]));
		HBRUSH centerLineBrush = CreateSolidBrush(RGB(yellowRGB[0], yellowRGB[1], yellowRGB[2]));
		HBRUSH rectBrush = CreateSolidBrush(RGB(rectRGB[0], rectRGB[1], rectRGB[2]));

		/*
			Light 1
		*/

		// Create the rectangle
		HGDIOBJ horg = SelectObject(hDC, rectBrush);
		Rectangle(hDC, light1_positionX + 25, light1_positionY - 170, light1_positionX - 40, light1_positionY + 25);

		// Create red circle
		cirBrush = CreateSolidBrush(RGB(light1_redCurrentRGB[0],
			light1_redCurrentRGB[1], light1_redCurrentRGB[2]));
		SelectObject(hDC, cirBrush);
		Ellipse(hDC, light1_positionX + 18, light1_positionY - 160, light1_positionX - 32, light1_positionY - 110);
		DeleteObject(cirBrush);

		// Create yellow circle
		cirBrush = CreateSolidBrush(RGB(light1_yellowCurrentRGB[0],
			light1_yellowCurrentRGB[1], light1_yellowCurrentRGB[2]));
		SelectObject(hDC, cirBrush);
		Ellipse(hDC, light1_positionX + 18, light1_positionY - 100, light1_positionX - 32, light1_positionY - 50);
		DeleteObject(cirBrush);

		// Create green circle
		cirBrush = CreateSolidBrush(RGB(light1_greenCurrentRGB[0],
			light1_greenCurrentRGB[1], light1_greenCurrentRGB[2]));
		SelectObject(hDC, cirBrush);
		Ellipse(hDC, light1_positionX + 18, light1_positionY - 40, light1_positionX - 32, light1_positionY + 10);
		DeleteObject(cirBrush);
		/*
			Light 2
		*/

		// Create the rectangle
		SelectObject(hDC, rectBrush);
		Rectangle(hDC, light2_positionX + 25, light2_positionY - 170, light2_positionX - 40, light2_positionY + 25);

		// Create red circle
		cirBrush = CreateSolidBrush(RGB(light2_redCurrentRGB[0], light2_redCurrentRGB[1]
			, light2_redCurrentRGB[2]));
		SelectObject(hDC, cirBrush);
		Ellipse(hDC, light2_positionX + 18, light2_positionY - 160, light2_positionX - 32, light2_positionY - 110);
		DeleteObject(cirBrush);
		// Create yellow circle
		cirBrush = CreateSolidBrush(RGB(light2_yellowCurrentRGB[0], light2_yellowCurrentRGB[1],
			light2_yellowCurrentRGB[2]));
		SelectObject(hDC, cirBrush);
		Ellipse(hDC, light2_positionX + 18, light2_positionY - 100, light2_positionX - 32, light2_positionY - 50);
		DeleteObject(cirBrush);

		// Create green circle
		cirBrush = CreateSolidBrush(RGB(light2_greenCurrentRGB[0], light2_greenCurrentRGB[1],
			light2_greenCurrentRGB[2]));
		SelectObject(hDC, cirBrush);
		Ellipse(hDC, light2_positionX + 18, light2_positionY - 40, light2_positionX - 32, light2_positionY + 10);
		DeleteObject(cirBrush);

		/*
			Roads
		*/

		SelectObject(hDC, roadBrush);

		//Horizontal road
		Rectangle(hDC, road_horizontal_positionX + 600, road_horizontal_positionY - 70
			, road_horizontal_positionX - 300, road_horizontal_positionY + 25);

		// Vertical road
		Rectangle(hDC, road_vertical_positionX + 70, road_vertical_positionY - 150
			, road_vertical_positionX - 25, road_vertical_positionY + 450);

		/*
			Center lane lines
		*/
		SelectObject(hDC, centerLineBrush);
		Rectangle(hDC, road_horizontal_positionX + 550, road_horizontal_positionY - 20
			, road_horizontal_positionX - 300, road_horizontal_positionY - 25);

		Rectangle(hDC, road_vertical_positionX + 20, road_vertical_positionY - 150
			, road_vertical_positionX + 25, road_vertical_positionY + 450);
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

		/*
			Cars
		*/

		carVerticalBrush = CreateSolidBrush(RGB(carRGB[0], carRGB[1], carRGB[2]));
		carHorizontalBrush = CreateSolidBrush(RGB(carRGB[0], carRGB[1], carRGB[2]));

		for (int i = 5; i < numberOfCarsHorizontal; i++) {

			SelectObject(hDC, carHorizontalBrush);

			if (carsHorizontal[i].getX() < 900) {
				Rectangle(hDC, carsHorizontal[i].getX() + 10
					, carsHorizontal[i].getY() - 5
					, carsHorizontal[i].getX() - 25
					, carsHorizontal[i].getY() + 20);
			}
		}

		for (int i = 5; i < numberOfCarsVertical; i++) {

			SelectObject(hDC, carVerticalBrush);

			if (carsVertical[i].getY() < 600) {
				Rectangle(hDC, carsVertical[i].getX() + 5
					, carsVertical[i].getY() - 10
					, carsVertical[i].getX() - 20
					, carsVertical[i].getY() + 25);
			}
		}

		SelectObject(hDC, horg);
		DeleteObject(carVerticalBrush);
		DeleteObject(carHorizontalBrush);
		DeleteObject(roadBrush);
		DeleteObject(centerLineBrush);
		DeleteObject(rectBrush);
		DeleteObject(cirBrush);

		EndPaint(hwnd, &Ps);
		break;
	}

	

	case WM_TIMER:

		switch (wParam)
		{
		case TrafficLight_1:

			if (light1_redEnabled == true && light1_yellowEnabled == false) {

				light1_yellowEnabled = true;
				light1_loopingDown = true;
				light1_yellowCurrentRGB[0] = yellowRGB[0];
				light1_yellowCurrentRGB[1] = yellowRGB[1];
				light1_yellowCurrentRGB[2] = yellowRGB[2];


			}

			else if (light1_loopingDown == true && light1_yellowEnabled == true 
				&& light1_greenEnabled == false) {
				light1_redEnabled = false;
				light1_yellowEnabled = false;
				light1_greenEnabled = true;
				light1_redCurrentRGB[0] = grayRGB[0];
				light1_redCurrentRGB[1] = grayRGB[1];
				light1_redCurrentRGB[2] = grayRGB[2];

				light1_yellowCurrentRGB[0] = grayRGB[0];
				light1_yellowCurrentRGB[1] = grayRGB[1];
				light1_yellowCurrentRGB[2] = grayRGB[2];

				light1_greenCurrentRGB[0] = greenRGB[0];
				light1_greenCurrentRGB[1] = greenRGB[1];
				light1_greenCurrentRGB[2] = greenRGB[2];


			}
			else if (light1_redEnabled == false
				&& light1_yellowEnabled == false && light1_greenEnabled == true) {
				light1_yellowEnabled = true;
				light1_greenEnabled = false;
				light1_loopingDown = false;
				light1_greenCurrentRGB[0] = grayRGB[0];
				light1_greenCurrentRGB[1] = grayRGB[1];
				light1_greenCurrentRGB[2] = grayRGB[2];

				light1_yellowCurrentRGB[0] = yellowRGB[0];
				light1_yellowCurrentRGB[1] = yellowRGB[1];
				light1_yellowCurrentRGB[2] = yellowRGB[2];


			}
			else if (light1_redEnabled == false && light1_yellowEnabled == true) {
				light1_redEnabled = true;
				light1_yellowEnabled = false;
				light1_yellowCurrentRGB[0] = grayRGB[0];
				light1_yellowCurrentRGB[1] = grayRGB[1];
				light1_yellowCurrentRGB[2] = grayRGB[2];

				light1_redCurrentRGB[0] = redRGB[0];
				light1_redCurrentRGB[1] = redRGB[1];
				light1_redCurrentRGB[2] = redRGB[2];

		
			}

			//InvalidateRect(hwnd, NULL, true);

			return 0;

		case TrafficLight_2:

			if (light2_redEnabled == true && light2_yellowEnabled == false) {
				light2_yellowCurrentRGB[0] = yellowRGB[0];
				light2_yellowCurrentRGB[1] = yellowRGB[1];
				light2_yellowCurrentRGB[2] = yellowRGB[2];

				light2_yellowEnabled = true;
				light2_loopingDown = true;

			}

			else if (light2_loopingDown == true && light2_yellowEnabled == true
				&& light2_greenEnabled == false) {
				light2_redCurrentRGB[0] = grayRGB[0];
				light2_redCurrentRGB[1] = grayRGB[1];
				light2_redCurrentRGB[2] = grayRGB[2];

				light2_yellowCurrentRGB[0] = grayRGB[0];
				light2_yellowCurrentRGB[1] = grayRGB[1];
				light2_yellowCurrentRGB[2] = grayRGB[2];

				light2_greenCurrentRGB[0] = greenRGB[0];
				light2_greenCurrentRGB[1] = greenRGB[1];
				light2_greenCurrentRGB[2] = greenRGB[2];
				light2_redEnabled = false;
				light2_yellowEnabled = false;
				light2_greenEnabled = true;

			}
			else if (light2_redEnabled == false
				&& light2_yellowEnabled == false && light2_greenEnabled == true) {
				light2_greenCurrentRGB[0] = grayRGB[0];
				light2_greenCurrentRGB[1] = grayRGB[1];
				light2_greenCurrentRGB[2] = grayRGB[2];

				light2_yellowCurrentRGB[0] = yellowRGB[0];
				light2_yellowCurrentRGB[1] = yellowRGB[1];
				light2_yellowCurrentRGB[2] = yellowRGB[2];

				light2_yellowEnabled = true;
				light2_greenEnabled = false;
				light2_loopingDown = false;
			}
			else if (light2_redEnabled == false && light2_yellowEnabled == true) {
				light2_yellowCurrentRGB[0] = grayRGB[0];
				light2_yellowCurrentRGB[1] = grayRGB[1];
				light2_yellowCurrentRGB[2] = grayRGB[2];

				light2_redCurrentRGB[0] = redRGB[0];
				light2_redCurrentRGB[1] = redRGB[1];
				light2_redCurrentRGB[2] = redRGB[2];

				light2_redEnabled = true;
				light2_yellowEnabled = false;
			}

			return 0;

		case MoveCars:

			for (int i = 0; i < numberOfCarsHorizontal; i++) {

				if (carsHorizontal[i].getX() == 456 - (queueHorizontal.size() * 48)
					&& (light2_redEnabled || light2_yellowEnabled)) {
						
						queueHorizontal.push(carsHorizontal[i]);
						
				}
				else {
					if (!queueHorizontal.empty() && carsHorizontal[i].getX() > 550) {
						queueHorizontal.pop();
					}
					carsHorizontal[i].setX(carsHorizontal[i].getX() + 6);
				}
			}
		
			for (int i = 0; i < numberOfCarsVertical; i++) {

				if (carsVertical[i].getY() == 252 - (queueVertical.size() * 48)
					&& (light1_redEnabled == true || light1_yellowEnabled == true)) {

					queueVertical.push(carsVertical[i]);
				}
				else {
					if (!queueVertical.empty() && carsVertical[i].getY() > 280) {
						queueVertical.pop();
					}
					carsVertical[i].setY(carsVertical[i].getY() + 6);
				}
			}

			if (wait < 201) {
				wait += 2;
			}
			
			InvalidateRect(hwnd, NULL, true);

			break;

		case SpawnCars:

			if (wait > 120) {
				int p_scaledH = (rand() % 101) + spawnHorizontalCarProbability;
				if (p_scaledH >= 100 && queueHorizontal.size() < 7) {
					carsHorizontal[numberOfCarsHorizontal] = Car(0, 345);
					numberOfCarsHorizontal++;
				}

				int p_scaledV = (rand() % 101) + spawnVerticalCarProbability;
				if (p_scaledV >= 100 && queueVertical.size() < 5) {
					carsVertical[numberOfCarsVertical] = Car(507, 0);
					numberOfCarsVertical++;
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