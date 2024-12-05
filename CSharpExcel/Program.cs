using System;
using System.Diagnostics;
using System.IO;

class Program
{
    // Shared variables
    static string CurrentDirectory = Directory.GetCurrentDirectory(); // Current directory path
    static string FileName = "TestProcess01.txt"; // File name to create
    static string FilePath = Path.Combine(CurrentDirectory, FileName); // Full path of the file

    static void Main(string[] args)
    {
        Console.WriteLine("Starting the script...");

        // Open the current folder
        OpenCurrentFolder();

        // Create the file
        CreateFile();

        // Open the file in a new process
        OpenFileInNewProcess();
    }

    // -------------------- Function to open the current folder --------------------
    static void OpenCurrentFolder()
    {
        try
        {
            Console.WriteLine($"Opening current folder: {CurrentDirectory}");
            Process.Start("explorer.exe", CurrentDirectory);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Folder '{CurrentDirectory}' opened successfully.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error opening folder: {ex.Message}");
            Console.ResetColor();
        }
    }

    // -------------------- Function to create a file --------------------
    static void CreateFile()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                // Create the file
                File.WriteAllText(FilePath, "This is a test file created by the script.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"File '{FileName}' created successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"File '{FileName}' already exists.");
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error creating file: {ex.Message}");
            Console.ResetColor();
        }
    }

    // -------------------- Function to open a file in a new process --------------------
    static void OpenFileInNewProcess()
    {
        try
        {
            Console.WriteLine($"Opening file '{FileName}' in a new process...");
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = FilePath,
                    UseShellExecute = true
                }
            };
            process.Start();

            // Output the PID of the process
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"File '{FileName}' opened successfully with PID: {process.Id}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error opening file: {ex.Message}");
            Console.ResetColor();
        }
    }
}
