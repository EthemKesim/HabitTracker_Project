using System.Text.Json;
using System.IO;

List<Habit> habits = new List<Habit>();

//upload json files when program running 
if (File.Exists("habits.json"))
{
    string json = File.ReadAllText("habits.json");
    habits = JsonSerializer.Deserialize<List<Habit>>(json);
}

while (true)
{
    Console.WriteLine("\n--- Habit Tracker ---");
    Console.WriteLine("1. Add Habit");
    Console.WriteLine("2. List Habits");
    Console.WriteLine("3. Mark Habit as Done");
    Console.WriteLine("4. Delete Habit");
    Console.WriteLine("5. Exit");
    Console.Write("Select: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddHabit();
            break;

        case "2":
            ListHabits();
            break;

        case "3":
            MarkDone();
            break;

        case "4":
            DeleteHabit();
            break;

        case "5":
            Save();
            Console.WriteLine("Saved, goodbye!");
            return;

        default:
            Console.WriteLine("Invalid selection");
            break;
    }
}

void AddHabit()
{
    Console.Write("Enter habit name: ");
    string habitName = Console.ReadLine();

    habits.Add(new Habit 
{ 
    Name = habitName,
    Count = 0,
    StartDate = DateTime.Now,
    LastDoneDate = DateTime.MinValue,
    Streak = 0,
    LastStreakDate = DateTime.MinValue 
});


    Console.WriteLine("Habit added.");
}


void ListHabits()
{
    if (habits.Count == 0)
    {
        Console.WriteLine("No habits added yet.");
        return;
    }

    Console.WriteLine("\n--- Habit List ---");

    for (int i = 0; i < habits.Count; i++)
    {
        var h = habits[i];

        Console.WriteLine($"\n{i + 1}. {h.Name}");
        Console.WriteLine($"   Started      : {h.StartDate}");
        Console.WriteLine($"   Last Done    : {h.LastDoneDate}");
        Console.WriteLine($"   Done Count   : {h.Count}");

        // Eğer streak eklediysen bunu da göster
        Console.WriteLine($"   Streak       : {h.Streak} days");
    }

    Console.WriteLine("\n----------------------------------\n");
}

void MarkDone()
{
    ListHabits();

    Console.Write("Which habit number? ");
    int index = int.Parse(Console.ReadLine()) - 1;

    if (index < 0 || index >= habits.Count)
    {
        Console.WriteLine("Invalid selection.");
        return;
    }

    Habit h = habits[index];
    DateTime today = DateTime.Today;

    // Eğer bugün zaten yapılmışsa streak artırma
    if (h.LastStreakDate == today)
    {
        Console.WriteLine("You already completed this habit today.");
        return;
    }

    // Eğer son yapılma tarihi DÜN ise → streak devam eder
    if (h.LastStreakDate == today.AddDays(-1))
    {
        h.Streak++;
    }
    else
    {
        // Streak kırılmıştır → yeniden başlar
        h.Streak = 1;
    }

    // Tarihleri güncelle
    h.LastStreakDate = today;
    h.LastDoneDate = DateTime.Now;
    h.Count++;

    Console.WriteLine("Marked as done, streak updated.");
}



void DeleteHabit()
{
    ListHabits();

    Console.Write("Which habit to delete? ");
    int index = int.Parse(Console.ReadLine()) - 1;

    if (index < 0 || index >= habits.Count)
    {
        Console.WriteLine("Invalid selection.");
        return;
    }

    habits.RemoveAt(index);
    Console.WriteLine("Habit deleted.");
}

void Save()
{
    string json = JsonSerializer.Serialize(habits, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText("habits.json", json);
}