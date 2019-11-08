This program calculates in input based on a list. 
To execute this from GUI(Clicking on the exe or running in debug):

You can paste the list of players in the format. 
"
id <rank><suit> <rank><suit> <rank><suit>
id <rank><suit> <rank><suit> <rank><suit>
id <rank><suit> <rank><suit> <rank><suit>
"

Ranks and Suits are represented by their DisplayName in the Rank and Suit Enums

The StreamReader uses readToEnd() which can hang due to not knowing the end. 
To show the end with StreamReader, press Control + Z and Enter.

This is built with .NET Core 2.1.

I made a Libaray for the Poker logic and a console application that uses the Library to manage the execution.