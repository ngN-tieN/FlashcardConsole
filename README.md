# Flashcard Console
My first C# application, using visual studio code
Console based application to create stacks of flashcard to study language
Techs used: C# with .NET 8.0, MS SQL SERVER, Dapper
# Features:
- MS SQL SERVER local db
    -   Using local db feature of MS SQL Server Express
    -   Check if the table doesn't exist, creates one
    -   Deletes flashcards and sessions belong to a stack if the stack is deleted
- A console UI 
    - ![Flashcard Console Main UI Pic](/assets/ConsoleUI.png)
- Crud Functions
    -   User can Create, Read, Delete, Update whichever Stack or Flashcard they want
    -   Create Study Session record automatically when finishes a study mode sessions
- Report
    -   Report the study session by sessions per month
    -   Report the study session by average score per session per month
- Table
    -   Reporting and other data output uses ConsoleTableExt library (check [`Resource used`](#resource-used)) to output in a more pleasant way

# Challenges:
- MS SQL SERVER: the syntax is somewhat different from the database I have used before (SQLite, MySQL), I had problems while I was writing queries for checking existence of tables,creating auto increment Id and creating timestamp
- Designing the program flow: had some troubles writing code for the controller because this was my first time designing an app where entities interact with each others.
- Spaghetti code: I tried my best to use inheritance in DatabaseService section to reduce redundant codes.
# Lesson learned:
- Using **Cascade** in MS SQL Server to make the records with foreign key refer to a primary key in another table disappear when deleted the primary key's record
- Using inheritance to reduce code 
- Creating timestamp value in MS SQL Server
- Using DTO(Data transfer objects)
- Writing down a to do list before coding anything
- Pivoting table
- How to connect to localdb
# Things to improve:
- Spaghetti code in **Controller** section
- Applying Single Responsibility
# Resource used:
- [ConsoleTableExt](https://github.com/minhhungit/ConsoleTableExt)
- StackOverflow 
- Project idea and Requirements from [CSharpAcademy](https://www.thecsharpacademy.com/project/14/flashcards)
- [PIVOT - Understanding the Basics in SQL](https://www.youtube.com/watch?v=bNetxDl40pM&ab_channel=Teradata)
- [How to connect to localdb](https://www.youtube.com/watch?v=M5DhHYQlnq8)
- [Data Transfer Object Design Pattern in C#](https://www.codeproject.com/Articles/1050468/Data-Transfer-Object-Design-Pattern-in-Csharp)
