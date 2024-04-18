using System;

const string InvalidOptionMessage = @"Invalid Option:
  -c, -m Returns the character count of the file
  -l     Returns the line count of the file
  -w     Returns the word count of the file";
Dictionary<char, int> modeFlags = new Dictionary<char, int>();
modeFlags.Add('c', (1 << 0));
modeFlags.Add('m', (1 << 0));
modeFlags.Add('l', (1 << 1));
modeFlags.Add('w', (1 << 2));

// Check for argument count
if (args.Length == 0 || args.Length > modeFlags.Count + 1) {
  Console.WriteLine("Invalid arguments");
  Console.WriteLine("Usage: wordcount <options> filename");
  System.Environment.Exit(1);
}

// Parse argument
int outputMode = 0;
for (int i = 0; i < args.Length; ++i) {
  // if (i == args.Length - 1) {
  //   break;
  // }

  if (args[i].Length == 2 && args[i][0] == '-' && modeFlags.ContainsKey(args[i][1])) {
    outputMode |= modeFlags[args[i][1]];
  } else {
    Console.Write(InvalidOptionMessage);
    System.Environment.Exit(1);
  }
}

Console.WriteLine($"Startup successful: {Convert.ToString(outputMode, 2)}");