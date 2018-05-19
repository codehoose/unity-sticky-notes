Sticky Notes For Unity
	
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
	Making the system extensible
		- Get component by interface
		- Interface for note object
		- Interface for serialization
	Serializing the sticky notes
	- Read / write from disk per scene OR one big file..?
	- Saving changes
		- When is the best time? When a note is made? 
		- Where should the data be written?
			- Per user
			- Per project					
			- ?

Video #3
	Moving the data to the cloud
	- ------Web service setup 
	- ------Reading, writing to and from the web service
	- ------Add 'id' to StickyNote
	- ------Implement delete
	- ------Interface for serialization
	- ------Filter for scene name
	- ------Save just the values that have changed?

	- Refactor serialization taking web into account
	- Refactor position fields
	- URL Encode scene name

