# GameEngineeringIII_SimpleGame
The game I made is Breakout+, it is a game based on Breakout Atari made at 1976.

I use Unity 6 to make this project.

## Controls

The game support keyboard and mouse

A : player(the moving paddle) move left 

D : player move right

K : magnify player for 3 seconds

mouse : interact with start/end menu

## About the Game

I will only discuss the basic gameplay, the specific features are in the following paragraph

While enter the game scene, there will be a movable paddle(player), a ball, and some bricks in rainbow color will generate on the screen. Player can move the paddle by pressing A and D, and when the ball hit the paddle, the ball will bounce back in a different vertical direction, and the horizontal direction and speed will determine by where the ball and the player collide.

When the ball hit a brick, the brick will break(disappear) and player can get point. Red brick is 1 point, orange brick is 2 points, yellow brick is 3 points, and so on…

If player didn’t hit the ball and make it fall out of the bottom of the screen, player will lose one health(the heart at right top). Once player lose all their life or clear all the bricks, the game will end.

## Specific Gameplay

There are two features I added to the game:

### Magnify Player

While playing the original Breakout, I noticed that it is hard to hit the ball when the ball speed is too fast or player is too far from the ball, and this made me frustrated. Therefore, I try modifying player speed and ball speed, this indeed help me hit the ball easier. However, the game start to feel boring, it is too easy to beat the game.

Then I tried to add an ability that player can magnify the paddle for few seconds, with a cooldown time, and I found this feature is interesting. Since player can grow the paddle to hit ball easily, the ball speed will increase while the paddle is bigger(the horizontal speed determine by the contact point). Players need to decide when is the best timing to use the magnify ability.

Additionally, the ability improve the visual of the game, the paddle looks more dynamic since it will grow and shrink to react player inputs.  I also add a hint UI that notice if the ability is ready to use. (bottom right text)

### Generate more ball when the bricks get hit

When there is only one ball per game, the pace of the game will be too slow. Players need to spent a lot of time waiting the ball bounce back after hitting a brick. Hence, I added a feature that whenever a brick is broke, it will generate a new ball with lower opacity (players will not confused with the original ball) and random speed. This will help speed up the game and make it more chaotic. Hitting multiple balls back to the bricks side is satisfying, and approach this with the first feature will having more fun.
