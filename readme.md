# BATTLESHIPS game - singleplayer

### What is it?
The application is a simplified version of the game named Battleships. It allows a player to play a one-sided game of Battleships against randomly placed ships.

### How to play it?
- you will see battlefield as 10 x 10 grid:
	- rows will be numbered in consecutive letters;
	- columns will be numbered in consecutive digits;
- as default setting there will be randomly placed 3 ships, with every having random length;
- ships quantity can be adjusted - with minimum of 1 and maximum of 5;
- ships length can be set as below or set to random (in that second case one from list below will be picked):
	- Battleship (5 fields) - most powerful and largest ship;
	- Destroyer (4 fields) - slightly smaller but still powerful;
	- Cruiser (3 fields) - moderately powerful and versatile;
	- Submarine (2 fields) - smallest but agile and capable of surprise attacks;
- by typing field coordinates in console: column [A - J], row [1 - 10] (without space, for example: B3) and pressing enter you declare to bombard certain field;
- at the start of the battle fields are not bombarded and look like [-];
- bombarded field where there was not hit ship will be marked as [0];
- bombarded field where there was hit ship will be marked as [X];
- you will be notified about result of bombarding: MISS, HIT or SINK (in third scenario you will also get notified about ship's length you sunk);
- once you destroy all ships you will get notified about victory and asked if you want to play again or return to main menu.