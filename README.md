# unity-sticky-notes
I saw a tweet from [Gareth Noyce](https://medium.com/@TripleEhLtd/in-game-sticky-notes-c5f4013892f6) about some functionality he implemented for use in his new game. It's based on Nintendo's bug notes for Zelda Breath of the Wild and I had to try implementing it in Unity.

Purpose:
* Bake bug reporting directly into your game
* Illustrate to fellow developers where the issues are

See TODO.md for the plan / video schedule.

# BEFORE YOU START

Once you clone this repo, install the following asset packages:
- Characters
- Cameras

# WAMP / LAMP / MAMP Server
I used Laragon (Portable) for this project, but you could use anything you prefer so long as it has PHP and MySql. You can download Laragon from https://laragon.org/download/. For Mac I have used MAMP https://www.mamp.info/en/

FYI: W = Windows, L = Linux and M = Mac in WAMP, LAMP and MAMP 

## Setting Up The Server
Copy the contents of the www folder in this repository to the www folder for your Laragon installation.

To install the database you will need to run the SQL script. This is done through the Laragon UI. Select "Database" at the bottom and enter the credentials (default is username = root, password is blank). In the top-left of the Admin UI is "Import" click this link and upload the SQL file. Run it. You now have the database set up :)