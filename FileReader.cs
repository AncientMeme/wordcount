using System.IO;
using System.Text;

public class FileReader {
  private string? filePath = null;

  public FileReader(string path) {
    if (File.Exists(path)) {
      filePath = path;
    }
  }

  public bool FileExists() {
    return (filePath != null);
  }

  public string GetContent() {
    if (filePath == null) {
      return "";
    }

    StringBuilder sb = new StringBuilder();
    try {
      StreamReader sr = new StreamReader(filePath);
      string? line = sr.ReadLine();
      while (line != null) {
        sb.AppendLine(line);
        line = sr.ReadLine();
      }
      sr.Close();
    } catch (Exception e) {
      Console.WriteLine($"FileReader Exception: {e.Message}");
      System.Environment.Exit(1);
    }
    
    return sb.ToString();
  }
}