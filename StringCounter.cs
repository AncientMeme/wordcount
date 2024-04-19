
class StringCounter {
  private string inputString;
  public StringCounter(string content) {
    inputString = content;
  }

  public int GetCharCount() {
    return inputString.Length;
  }

  public int GetLineCount() {
    return 1;
  }

  public int GetWordCount() {
    return 2;
  }
}