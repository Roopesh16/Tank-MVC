# TANK BLAST
This is my project 'TANK BLAST' part of Outscal MVC Assignment. In this game, you select your tank and in number of waves enemy tanks are spawned and you have to defeat all of them, to win the game.

## Goal
The primary goal for me in this project was  - 

 1. Implement MVC Pattern
 2. Communicate between different entities
 3. Implement Service Locator Pattern
 4. Implement Observer Pattern

Looking at the folder structure you can see the order in which I have arranged scripts. The whole idea was make codebase modular and easy to use.

## Rules
You operate the tank with WASD or arrow keys and shoot bullet with **SPACE** bar. 

## Mechanics
For player mechanics, I move it using Rigidbody and shoot taking user input.

For enemy tanks however, I use NavMeshAgent to move them across the ground and chase the player. When it is at a certain distance from player it shoots Raycast to detect player and once detected, it shoot bullet with a certain fire rate towards the player.

## Conclusion
This was a extensive learning project, where I got to implement 3 design pattern simultaneously and learn and how to manage code base and establish script communication.
