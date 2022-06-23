# GalaxyGuardian
Ka Pui Man's Final Year Project, Galaxy Guardian.

## Introduction
This project aims to demonstrate my abilities of my previous study years. I am always interested in computer video games and wanted to develop one. Therefore, I believe this is my opportunity to challenge myself as my final year project idea. I am a software engineering student and experienced programming in my previous studies, but never in computer games. This is my first time experience Unity, it was not easy to master, but relatively speaking, I would've to say this project was enjoyable overall, thankfully my supervisor provided lots of advice to me regarding the features and abilities that Unity assists many beginner video game developers, such as its community and asset store.

## Specification
Galaxy Guardian is a single player round-based top-down shooter survival mobile (Android) platform based. There are infinite rounds based, enemy numbers size increased each round, after it reached round 7, enemy type changes from the '**Claw**' to the '**Bull**' and it's ability increased to occurs higher difficulty in-game. Player's objective is to survive as many waves as possible by avoiding components wave attacks. Earn points by elminating enemies. Alternatively, player can spend points to purchase **_UPGRADES_** to remind longer waves.

The game system is designed using an Object-Oriented Programming (OOP) alongside with the game engine, Unity. This utilises the concept of inheritance with similar functions can share the same declared functions, as known as the 'parent' class. When child class inherits the properties and functionality of its parent class can reduce any redundant code. In future development allows to reuse the existing codes.

There are multiple options available in the main menu, there are "**Play**", "**Help**", "**Credits**" and "**Quit**". Each options contain it's unique functions as it stated.

## Game Begin
In order to start the game, player needs to press "**Play**" to process to the next scene, which to the gameplay scene. After entered the game scene, there are some visable elements on screen that represents different components. Health bar represent the character's health, using gradient color to meansure its health bar where allocates to the set health precentage. There are 3 colours to represent player's health level condition, there are green, orange and red. Based on its health percentage, health bar colour changes when it reaches the set percentage set in the programm. And also, player can purchase upgrades to upgrade its health to remind long process in game, more information will be detailed in below documentation.

## Movement
To move the character player requires to use the onscreen joystick to control its movement, which allocated on the bottom left of the screen. And also, player has the ability to fire by pressing the joy button which allocated on the bottom right on screen. There are 2 patterns of shooting mode, press to shoot single bullet and hold for auto fire. Currently bullet courts have not implemented to the game, this feature will be added for future improvement.
