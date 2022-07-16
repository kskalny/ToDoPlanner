# ToDoPlanner
Simple ToDo App built with C# WPF and EntityFramework as ORM connector to SQLite database.

## What's working for this moment:
 - Interface routing:
    - ListView - Used to preview and delete tasks
    - CreateView - Used to create tasks
 - Operations on tasks:
    - Create
    - Delete
    - Read

## Things which can be implemented in future:
  - Update operation for tasks
  - Interface to manage Categories
  - User login page to use Author table
  - Rearrangement of application logic


## How to use?
For this moment application is build in `test` mode, what means it will create 3 Tasks, 3 Categories and 1 User named "Kamil Skalny".
After first application run you should see new file created named: `todolist.db` - File name can be changed in Properties/Settings.settings
Changes made in application are cleared with next run, so if you want to verify it's content it's necessary to use 3rd party software.


