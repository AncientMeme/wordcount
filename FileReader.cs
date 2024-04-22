using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class FileReader {
  string content;
  string file;
  public FileReader(string filepath) {
    file = filepath;
    using(var reader = new StreamReader(filepath)) {
      content = reader.ReadToEnd();
    }
  }

  public int GetBytes() {
    return (int)new FileInfo(file).Length;
  }

  public int GetChars() {
    // the '\0' should be included
    return content.Length + 1;
  }

  public int GetWords() {
    var words = Regex.Matches(content, @"\b\w+\b").Count;
    return words;
  }

  public int GetLines() {
    var lines = Regex.Matches(content, "\n").Count;
    return lines;
  }
}