using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public JournalEntry(string prompt, string response){
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }

    public override string ToString(){
        return $"{Date.ToString("yyyy-MM-dd HH:mm:ss")} - {Prompt}\n{Response}\n";
    }
}

class JournalProgram{
    private List<JournalEntry> entries = new List<JournalEntry>();

    static void Main(){
        JournalProgram journalProgram = new JournalProgram();
        journalProgram.Run();
    }

    private void Run(){
        bool exit = false;
        while (!exit){
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            int choice = GetChoice();

            switch (choice){
                case 1:
                    WriteNewEntry();
                    break;
                case 2:
                    DisplayJournal();
                    break;
                case 3:
                    SaveJournalToFile();
                    break;
                case 4:
                    LoadJournalFromFile();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private int GetChoice(){
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice)){
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        return choice;
    }

    private void WriteNewEntry(){
        Console.WriteLine("Writing a new entry...");
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("> ");
        string response = Console.ReadLine();
        JournalEntry entry = new JournalEntry(randomPrompt, response);
        entries.Add(entry);
        Console.WriteLine("Entry added successfully!\n");
    }

    private string GetRandomPrompt(){
        List<string> prompts = new List<string>{
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was something exciting that happened today?",
            "How did school/work go today?",
            "If you had to relive today over and over again, what would never get old?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    private void DisplayJournal(){
        Console.WriteLine("Displaying journal entries...\n");
        foreach (var entry in entries){
            Console.WriteLine(entry);
        }
    }

    private void SaveJournalToFile(){
        Console.Write("Enter the filename to save the journal: ");
        string fileName = Console.ReadLine();
        try{
            using (StreamWriter writer = new StreamWriter(fileName)){
                foreach (var entry in entries){
                    writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved to file successfully!\n");
        }
        catch (Exception ex){
            Console.WriteLine($"Error saving journal to file: {ex.Message}\n");
        }
    }

    private void LoadJournalFromFile(){
        Console.Write("Enter the filename to load the journal from: ");
        string fileName = Console.ReadLine();
        try{
            entries.Clear();
            using (StreamReader reader = new StreamReader(fileName)){
                while (!reader.EndOfStream){
                    string[] line = reader.ReadLine().Split(',');
                    if (line.Length == 3){
                        DateTime date = DateTime.Parse(line[0]);
                        string prompt = line[1];
                        string response = line[2];
                        JournalEntry entry = new JournalEntry(prompt, response){
                            Date = date
                        };
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine("Journal loaded from file successfully!\n");
        }
        catch (Exception ex){
            Console.WriteLine($"Error loading journal from file: {ex.Message}\n");
        }
    }
}