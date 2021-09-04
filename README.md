# Card game project
This is a console application based on .NET Core, .NET core project can be deployed to any system without any software dependency like OS, other libraries.

# Prerequisite
.Net core should be installed in the system.

# Steps for running project

Basically there are multiple ways doing it.

### Using Visual studio

* Clone the repo.

* Locate CardGame/CardGame.sln and open it in visual studio.

* Now run run the console app.

* For running tests, you can mark CardGameTests as 'Set as Startup Project' and run it **OR** Open CardGameTest.cs then Right click anywhere in code inside file then Run Test(s).


### Using CLI in Visual studio code

* Clone the repo.

* In visual studio code's terminal, Navigate to CardGame.

* Then simply run 'dotnet build' & 'dotnet run'. It will print the output of game.

* Then running tests, Navigate to CardGameTest in CLI and then simply run 'dotnet test'. It will show the report test cases Passed, Failed etc.

### Using Docker (Not implemented yet)

.Net core app can be run as a container.

* We can create a Docker file at root.

* And write build & deployment steps in it.

* Then simply need to do 'docker build' and 'docker run'.
  