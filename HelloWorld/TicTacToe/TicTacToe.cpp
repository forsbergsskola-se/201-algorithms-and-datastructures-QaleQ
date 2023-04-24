#include <stdlib.h>
#include <string>
#include <iostream>
#include <time.h>
using namespace std;

const int gridSize = 3;
char gameBoard[gridSize][gridSize];
int emptySlots = gridSize * gridSize;
int currentId = 0;

void GenerateBoardString() {
    for (int row = 0; row < gridSize; ++row) {
        for (int col = 0; col < gridSize; ++col) {
            cout << (gameBoard[col][row] == 0 ? ' ' : gameBoard[col][row]);
            // if we're not on the last col, append separator
            if (col < gridSize - 1) cout << '|';
        }
        cout << endl;
        // if we're not on the last row, append separator
        if (row < gridSize - 1) cout << "-----" << endl;
    }
}

int GetUserInputInt(int min, int max, const string prompt) {
    cout << prompt << " (" << min << "-" << max << ")" << endl;

    AskInput:
    int input;
    scanf_s("%d", &input);
    if (input > max || input < min) {
        printf("Invalid input. Please enter a number between %d and %d: ", min, max);
        goto AskInput;
    }
    return input;
}

struct Player {
    char Symbol;
    bool IsAi = false;

    Player(char symbol) { Symbol = symbol; }
};

struct Coords {
    int Col;
    int Row;
    Coords(int col, int row) {
        Col = col;
        Row = row;
    }
};

bool IsValidInput(int col, int row) { return gameBoard[col][row] == '\0'; }

Player players[2] = { Player('X'), Player('O') };

Coords PlayerChoice() {
    int col;
    int row;

    while (true) {
        string promptCol;
        string promptRow;
        if (players[currentId].Symbol == 'X') {
            promptCol = "In what column do you want to place your X?";
            promptRow = "In what row do you want to place your X?" ;
        }
        else if (players[currentId].Symbol == 'O') {
            promptCol = "In what column do you want to place your O?";
            promptRow = "In what row do you want to place your O?";
        }
        col = GetUserInputInt(1, gridSize, promptCol) - 1;
        row = GetUserInputInt(1, gridSize, promptRow) - 1;

        if (IsValidInput(col, row)) break;

        system("CLS");
        cout << "Selected slot unavailable" << endl;
        GenerateBoardString();
    }
    Coords returnValue = { col, row };
    return returnValue;
}

Coords AiChoice() {
    int srand(time(0));
    int pickedSlot = rand() % gridSize;
    for (int row = 0; row < gridSize; row++) {
        for (int col = 0; col < gridSize; col++) {
            if (gameBoard[col][row] != 0) continue;
            if (pickedSlot == 0) {
                Coords returnValue = { col, row };
                return returnValue;
            }
            pickedSlot--;
        }
    }
    Coords invalid = { -1, -1 };
    return invalid;
}

bool IsGameOver(int lastCol, int lastRow) {
    int maxIndex = gridSize - 1;
    char lastSymbol = players[currentId].Symbol;

    for (int i = 0; i < gridSize; i++) {
        if (gameBoard[lastCol][i] != lastSymbol) break;
        if (i == maxIndex) return true;
    }

    for (int i = 0; i < gridSize; i++) {
        if (gameBoard[i][lastRow] != lastSymbol) break;
        if (i == maxIndex) return true;
    }

    if (lastCol == lastRow) {
        for (int i = 0; i < gridSize; i++) {
            if (gameBoard[i][i] != lastSymbol) break;
            if (i == maxIndex) return true;
        }
    }

    if (lastCol + lastRow == maxIndex) {
        for (int i = 0; i < gridSize; i++) {
            if (gameBoard[i][(maxIndex - i)] != lastSymbol) break;
            if (i == maxIndex) return true;
        }
    }
    return false;
}

void Game() {
    bool winCondition;
    while (true) {
        Coords selectedCoords = players[1].IsAi && currentId == 1 ? AiChoice() : PlayerChoice();

        gameBoard[selectedCoords.Col][selectedCoords.Row] = players[currentId].Symbol;
        emptySlots--;

        system("CLS");
        GenerateBoardString();

        winCondition = IsGameOver(selectedCoords.Col, selectedCoords.Row);
        if (winCondition || emptySlots == 0) break;
        currentId = currentId == 0 ? 1 : 0;
    }

    if (winCondition) {
        if (players[currentId].Symbol == 'X') printf("Player X won!");
        if (players[currentId].Symbol == 'O') printf("Player O won!");
    }
    else printf("Game tied");
}

int main()
{
    system("CLS");
    cout << "Welcome to Tic-Tac-Toe" << endl;
    players[1].IsAi = GetUserInputInt(1, 2, "Select number of players") - 1;
    // 1 player : 1 - 1 = 0, inverted = true
    // 2 players: 2 - 1 = 1, inverted = false
    players[1].IsAi = !players[1].IsAi;
    Game();
}
