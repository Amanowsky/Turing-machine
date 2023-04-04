# Turing machine
A simple program to simulate a turing machine

## Environment
.NET 7.0 <br>
Visual Studio 2022

## Instruction 
The loaded instruction checks whether the text on the tape is a palindrome

> U can change instruction in `string instructionsFilePath`

## Symbol table
Size of the one instruction<br> 
```
const int INSTRUCTION_SIZE = 5 
```
Current state of the machine <br>
```
string currentState = "s";
```
Symbol to move left <br>
```
string leftSymbol = "L";
```
Symbol to move right <br>
```
string rightSymbol = "R";
```
Key to stop machine <br>
```
string machineStopKey = "yes"
```
### Important!
### Tape of the machine 
```
List<string> tape = new List<string> { "a", "b", "a", "a", "b", "a", "_" }
```
### Path to the file with instruction
```
string instructionsFilePath = "**\\Maszine Turinge\\instructions.txt";
```
