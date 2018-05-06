# unity-sticky-notes
I saw a tweet from [Gareth Noyce](https://medium.com/@TripleEhLtd/in-game-sticky-notes-c5f4013892f6) about some functionality he implemented for use in his new game. It's based on Nintendo's bug notes for Zelda Breath of the Wild and I had to try implementing it in Unity.

Purpose:
* Bake bug reporting directly into your game
* Illustrate to fellow developers where the issues are

Here's the plan for the videos:

Video #1
User interface to create, update, delete sticky notes
- Prefab for user interface with Canvas Group
- Standard UI buttons for actions
- Text boxes for input / display

Things we need to store:
- Postion in the game
- The name of the scene
- Bug report text

Prefab for Note
- Collision detection to show information
- Arrow to say "Here's a note!"

Video #2
Serializing the sticky notes
- Read / write from disk per scene
- Saving changes

Video #3
Moving the data to the cloud
- Web service setup
- Reading, writing to and from the web service

# BEFORE YOU START

Once you clone this repo, install the following asset packages:
- Characters
- Cameras