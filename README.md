# Flashcard Console
My first C# application, using visual studio code
Console based application to create stacks of flashcard to study language
Techs used: C# with .NET 8.0, MS SQL SERVER, Dapper
#Features:
- MS SQL SERVER local db
    -   Using local db feature of MS SQL Server Express
    -   Check if the table doesn't exist, creates one
- A console UI 
    - ![a](/README assets/Screenshot 2024-05-07 193619.png)
- Crud Functions
    -   User can Create, Read, Delete, Update whichever Stack or Flashcard they want
    -   Create Study Session record automatically when finishes a study mode sessions
- Report
    -   Report the study session by sessions per month
    -   Report the study session by average score per session per month
- Table
    -   Reporting and other data output uses ConsoleTableExt library to output in a more pleasant way

