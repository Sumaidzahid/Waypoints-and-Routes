This project is a .NET 8 C# console application for loading waypoint data from CSV files, managing a collection of waypoints, and creating editable routes built from those waypoints. It demonstrates file parsing, simple data structures (arrays/lists), basic geodata handling (latitude/longitude and elevation conversion), and interactive route operations such as add-front, add-end, insert-at-index, remove, and display.
Key features:
•	Read waypoints from a CSV file and convert mixed elevation units to meters
•	Store waypoints in a fixed-size array with search and add operations
•	Create, display and manage multiple routes composed of waypoints
•	Route operations: add to front/end, insert at specific index, remove by name
•	Simple interactive console menu for exercising functionality
How to run:
•	Requires .NET 8 SDK and Visual Studio 2022+ / Visual Studio 2026.
•	Update the FILE_PATH constant in Program.cs to point to your CSV directory or place the CSV at the existing path.
•	Open the solution in Visual Studio and run, or from the solution folder run:
•	dotnet build
•	dotnet run --project <path-to-project-file>
