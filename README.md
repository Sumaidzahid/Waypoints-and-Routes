# Waypoints & Routes Management System

A .NET 8 C# console application for loading waypoint data from CSV files, managing waypoint collections, and creating editable navigation routes. The project demonstrates file handling, data structures, geospatial data processing, and route management through an interactive console interface.

## Overview

This application reads waypoint data from CSV files, converts mixed elevation units into meters, and stores waypoints for route creation and management. Users can create and modify routes using various operations, including insertion, deletion, and waypoint reordering.

The project was developed to demonstrate practical software engineering concepts such as file parsing, collection management, object-oriented programming, and user interaction in C#.

## Features

* Load waypoint data from CSV files
* Convert mixed elevation units to meters
* Store and manage waypoint collections
* Search and add new waypoints
* Create and manage multiple routes
* Add waypoints to the beginning or end of a route
* Insert waypoints at specific positions
* Remove waypoints by name
* Display route information interactively
* Console-based menu system for user interaction

## Technologies Used

* C#
* .NET 8
* Visual Studio
* CSV File Processing
* Object-Oriented Programming (OOP)

## Project Structure

* **Waypoint Management** – Store, search, and maintain waypoint records.
* **Route Management** – Create and modify routes composed of waypoints.
* **File Processing** – Parse CSV files and process geographic data.
* **User Interface** – Interactive console menu for route operations.

## Getting Started

### Prerequisites

* .NET 8 SDK
* Visual Studio 2022 or later

### Installation

1. Clone the repository:

```bash
git clone <repository-url>
```

2. Open the solution in Visual Studio.

3. Update the `FILE_PATH` constant in `Program.cs` to match the location of your CSV file.

4. Build and run the project.

### Command Line

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run --project <path-to-project-file>
```

## Learning Outcomes

This project demonstrates:

* File I/O operations in C#
* CSV data parsing
* Collection and array management
* Object-oriented design principles
* Route and waypoint management algorithms
* Geospatial data handling
* Console application development

## Author

Muhammad Zahid
MSc Artificial Intelligence | Mechatronics Engineer
