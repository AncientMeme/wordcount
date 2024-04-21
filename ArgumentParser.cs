
class ArgumentParser {
  const int CharFlag = (1 << 0);
  const int LineFlag = (1 << 1);
  const int WordFlag = (1 << 2);
  private Dictionary<char, int> modeFlags;
  public string[] options {get; private set;}
  public string filename {get; private set;}
  public bool isValidCount {get; private set;}
  public ArgumentParser(string[] args) {
    // Valid options and corresponding flag bits
    modeFlags = new Dictionary<char, int>{
      {'c', CharFlag},
      {'m', CharFlag},
      {'l', LineFlag},
      {'w', WordFlag}
    };

    // Check if argument count is valid
    isValidCount = (args.Length > 0 && args.Length < modeFlags.Count + 1);

    // Parse options only if arg count is valid
    options = new string[]{};
    filename = "";
    for (int i = 0; i < args.Length; ++i) {
      if (i < args.Length - 1) {
        options.Append(args[i]);
      } else {
        filename = args[i];
      }
    }
  }

  // Parse the input options, returns all enabled modes as flagged bits
  public int GetOutputMode() {
    int outputMode = 0;
    foreach (string option in options) {
      if (option.Length != 2 || option[0] != '-' || !modeFlags.ContainsKey(option[1])) {
        return -1;
      }
      outputMode |= modeFlags[option[1]];
    }
    return outputMode;
  }

  // Check if the file can be opened
  public bool IsFileAvailable() {
    return File.Exists(filename);
  }

  public void PrintArgs() {
    Console.WriteLine($"options: {options}, file: {filename}");
  }
}