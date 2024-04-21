using System;

const string InvalidArgCountMessage = @"Invalid arguments
Usage: wordcount <options> filepath";
const string InvalidOptionMessage = @"Invalid Option:
  -c, -m Returns the character count of the file
  -l     Returns the line count of the file
  -w     Returns the word count of the file";

ArgumentParser argsParser = new(args);
// Check count
if (!argsParser.isValidCount) {
  Console.Write(InvalidArgCountMessage);
  System.Environment.Exit(1);
}

// Check options
int outputMode = argsParser.GetOutputMode();
if (outputMode == -1) {
  Console.Write(InvalidOptionMessage);
  System.Environment.Exit(1);
}

// Check file exists
if (!argsParser.IsFileAvailable()) {
  Console.WriteLine($"Cannot read file: {argsParser.filepath}");
  System.Environment.Exit(1);
}

// Insert the file into FileReader
FileReader fr = new(argsParser.filepath);
Console.WriteLine($"{fr.LineCount} {fr.WordCount} {fr.ByteCount} {argsParser.filepath}");

System.Environment.Exit(0);