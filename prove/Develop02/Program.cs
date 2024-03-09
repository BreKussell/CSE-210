using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


public class JournalPrompt
{
 public static string[] _prompt =
 {
"I was today years old when I found out....",

"If I could redo something today what would it be?",

"What are three things you are grateful for today?",

"Do I have any goals that I'm working on? If so, what did I do to get closer to achieving them? If not, try making one.",

"What was the best part of my day?",

"How did I see the hand of the Lord in my life today?",

"What was the strongest emotion I felt today?",

"What was the most memorable part of my day?",

"My guilty pleasure of the day?",

"What can I do to make tomorrow better?",

"Did you give your 100% today of what you could give?",

"What was today's weather? How did it make me feel?",

"Best thing I ate today?"
 };


 public List<string> _journalPrompt = new List<string>(_prompt);
 public JournalPrompt()
 {
 }
 public void Display()
 {
 var random = new Random();
 int index = random.Next(_journalPrompt.Count);
 string journalPrompt = _journalPrompt[index];

Console.WriteLine($"\n{journalPrompt}");
 }
 public string GetPrompt()
 {
 var random = new Random();
 int index = random.Next(_journalPrompt.Count);
 string journalPrompt = _journalPrompt[index];
 return journalPrompt;
 }
}