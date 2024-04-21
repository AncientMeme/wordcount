using System.IO;
using System.Text;

class FileReader {
  public int ByteCount {get; private set;}
  public int CharCount {get; private set;}
  public int LineCount {get; private set;}
  public int WordCount {get; private set;}
  public FileReader(string filepath) {
    byte[] bytes = File.ReadAllBytes(filepath);
    ByteCount = bytes.Length;

    try {
      StreamReader sr = new(filepath);
      char? next = null;
      while (sr.Peek() >= 0) {
        next = (char)sr.Read();
        CharCount += 1;
        if (next == ' ') {
          WordCount += 1;
        }
        if (next == '\n') {
          WordCount += 1;
          LineCount += 1;
        }
      }

      if (next != null) {
        WordCount += 1;
      }
      
      sr.Close();
    } catch (Exception e) {
      Console.WriteLine("Exception: " + e.Message);
    }
  }  
}