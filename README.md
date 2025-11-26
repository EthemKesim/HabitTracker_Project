# Habit Tracker — C# Console Application

A simple *CLI (Command Line Interface)* Habit Tracking application developed in *C# (.NET 6)*.  
This project allows users to *create habits, track daily progress, view streaks, and save data* using a JSON file for persistent storage.

---

## Features

### Add new habits  
Users can create any kind of daily habit such as:
- Study
- Gym
- Drink Water
- Sleep Early

### List all habits  
Display each habit with:
- Name  
- Start Date  
- Last Done Date  
- Total Done Count  
- Current Streak (days)

### Mark a habit as completed  
Updates:
- Count (+1)  
- LastDoneDate  
- Streak (daily streak logic)

### Delete habits  
Remove habits cleanly from the tracker.

### Auto-save (JSON Persistence)  
All habits are saved into habits.json automatically when you exit.  
When the app restarts, it loads all progress back.

---

## Project Structure

HabitTracker_Project/
│── Program.cs
│── Habit.cs
│── habits.json <-- generated automatically
│── obj/
│── bin/



---

## Streak Logic (How it works)

- If user completes habit *two days in a row* → streak increases  
- If user completes habit after skipping a day → streak resets to 1  
- If user tries to complete a habit *twice in the same day*, the program prevents duplicate streaks

---

## Technologies Used

- *C#*
- *.NET 6 Console Application*
- *System.Text.Json* (for JSON serialization)
- *CLI Interface*
- *OOP (Classes, Instances)*
- *File I/O* (JSON persistence)

---

## How to Run the Project

1. Open the project folder in VS Code.
2. Make sure you have *.NET 6 SDK* installed:
   bash
   dotnet --version
   
---

## Streak Logic (How it works)

- If user completes habit **two days in a row** → streak increases  
- If user completes habit after skipping a day → streak resets to 1  
- If user tries to complete a habit **twice in the same day**, the program prevents duplicate streaks

---

## Technologies Used

- **C#**
- **.NET 6 Console Application**
- **System.Text.Json** (for JSON serialization)
- **CLI Interface**
- **OOP (Classes, Instances)**
- **File I/O** (JSON persistence)

---

## How to Run the Project

1. Open the project folder in VS Code.
2. Make sure you have **.NET 6 SDK** installed:
   bash
   dotnet --version
   dotnet run 

--- Habit Tracker ---
1. Add Habit
2. List Habits
3. Mark Habit as Done
4. Delete Habit
5. Exit
Select:
