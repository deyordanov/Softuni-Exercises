using MementoDesignPattern;

Editor editor = new Editor();
editor.Write("Like and");
editor.PrintText();
editor.Write("Like and Subscribe");
editor.PrintText();
editor.Write("Like and Subscribe to Geekific!");
editor.PrintText();
editor.Undo();
editor.PrintText();
editor.Undo();
editor.PrintText();
editor.Undo();
editor.PrintText();