using System;

const int CharFlag = (1 << 0);
const int LineFlag = (1 << 1);
const int WordFlag = (1 << 2);
const string InvalidArgCountMessage = @"Invalid arguments
Usage: wordcount <options> filename";
const string InvalidOptionMessage = @"Invalid Option:
  -c, -m Returns the character count of the file
  -l     Returns the line count of the file
  -w     Returns the word count of the file";

// Valid options and corresponding flag bits
Dictionary<char, int> modeFlags = new Dictionary<char, int>();
modeFlags.Add('c', CharFlag);
modeFlags.Add('m', CharFlag);
modeFlags.Add('l', LineFlag);
modeFlags.Add('w', WordFlag);

// Check for argument count
if (args.Length == 0 || args.Length > modeFlags.Count + 1) {
  Console.Write(InvalidArgCountMessage);
  System.Environment.Exit(1);
}

// Parse options
int outputMode = 0;
for (int i = 0; i < args.Length - 1; ++i) {
  if (args[i].Length == 2 && args[i][0] == '-' && modeFlags.ContainsKey(args[i][1])) {
    outputMode |= modeFlags[args[i][1]];
  } else {
    Console.Write(InvalidOptionMessage);
    System.Environment.Exit(1);
  }
}
// Console.WriteLine($"Options Enabled: {Convert.ToString(outputMode, 2)}");

// Parse file
string filePath = args[args.Length - 1];
FileReader reader = new FileReader(filePath);
if (!reader.FileExists()) {
  Console.Write($"Invalid File: {filePath} cannot be read");
  System.Environment.Exit(1);
}
string fileContent = reader.GetContent();
Console.Write(fileContent);
