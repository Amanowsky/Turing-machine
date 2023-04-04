using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        /// Size of the one instruction
        const int INSTRUCTION_SIZE = 5;


        /// Current state of the machine
        string currentState = "s";

        /// Symbol to move left
        string leftSymbol = "L";

        /// Symbol to move right
        string rightSymbol = "R";

        /// Key to stop machine 
        string machineStopKey = "yes";

        /// Current position of the machine head 
        int currentHeadPosition = 0;

        /// Tape of the machine
        List<string> tape = new List<string> { "a", "b", "a", "a", "b", "a", "_" };

        /// Path to file with instrucions 
        string instructionsFilePath = "**\\Turing-machine\\Turing-machine\\instructions.txt";

        // Define the map structure for instructions as a nested dictionary
        Dictionary<string, Dictionary<string, Dictionary<string, string>>> instructions = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();


        // ====== Prepare instructions ======

        // Open the instructions file and read the instructions
        StreamReader instructionsFile = new StreamReader(instructionsFilePath);
        string line;

        // Check if the file was successfully opened
        if (instructionsFile != null)
        {
            // Read in each line of the file and parse it tinto the elements of instruction
            while ((line = instructionsFile.ReadLine()) != null)
            {
                // Create line elements
                string[] lineElements = new string[INSTRUCTION_SIZE];
                int j = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ',')
                    {
                        j++;
                    }
                    else
                    {
                        lineElements[j] += line[i];
                    }
                }

                // Assign the elements to variables for use in the instructions dictionary
                string state = lineElements[0];
                string symbolToFind = lineElements[1];
                string newState = lineElements[2];
                string symbolToReplace = lineElements[3];
                string moveDir = lineElements[4];

                // Check if the current state has already been added to the instruction
                if (!instructions.ContainsKey(state))
                {
                    instructions[state] = new Dictionary<string, Dictionary<string, string>>();
                }

                // Assign instaruction to current state
                instructions[state][symbolToFind] = new Dictionary<string, string>() {
                { "newState", newState },
                { "symbolToReplace", symbolToReplace },
                { "moveDir", moveDir }
            };
            }

            // Close the file after reading in all the instructions
            instructionsFile.Close();
        }
        // If the file could not be opened, print an error message
        else
        {
            Console.WriteLine("Cannot open file: " + instructionsFilePath);
        }

        // ====== Start machine ======

        while (true)
        {
            // Read the symbol at the current position on the tape
            string readSymbol = tape[currentHeadPosition];

            // Check if symbol exists in the instructions
            if (!instructions[currentState].ContainsKey(readSymbol))
            {
                Console.WriteLine("NO");
                break;
            }

            // Get the current instruction
            Dictionary<string, string> currentInstruction = instructions[currentState][readSymbol];

            // Update the current state
            currentState = currentInstruction["newState"];

            //If the new state is the stop key, stop the machine
            if (currentInstruction["newState"] == machineStopKey)
            {
                break;
            }

            // Write new/prev symbol
            tape[currentHeadPosition] = currentInstruction["symbolToReplace"];

            // Move the machine head
            if (currentInstruction["moveDir"] == leftSymbol)
            {
                if (currentHeadPosition > 0)
                {
                    currentHeadPosition--;
                }
            }
            else if (currentInstruction["moveDir"] == rightSymbol)
            {
                currentHeadPosition++;
            }
        }

        // Print the final state of the machine
        Console.WriteLine(currentState);
    }

}