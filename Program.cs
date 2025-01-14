// namespace ToDo; // se puede declarar el namespace asi, pero se requiere de toda la estructura clasicas (ver cambios del commit). Esto se llamaria static namespace o tambien se puede eliminar el namespace y dejarlo sin namespace, a lo que se llamaria top-level statement

// cuando se usa el top-level statement se puede usar funciones y variables en lugar de los metodos y propiedades de la clase Program

List<string> TaskList = new List<string>();

int menuSelected = 0;
do
{
  menuSelected = ShowMainMenu();
  if ((MenuOptions)menuSelected == MenuOptions.Add)
  {
    ShowMenuAdd();
  }
  else if ((MenuOptions)menuSelected == MenuOptions.Remove)
  {
    ShowMenuRemove();
  }
  else if ((MenuOptions)menuSelected == MenuOptions.List)
  {
    ShowMenuTaskList();
  }
} while ((MenuOptions)menuSelected != MenuOptions.Exit);
/// <summary>
/// Show the main menu 
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
{
  Console.WriteLine("----------------------------------------");
  Console.WriteLine("Ingrese la opción a realizar: ");
  Console.WriteLine("1. Nueva tarea");
  Console.WriteLine("2. Remover tarea");
  Console.WriteLine("3. Tareas pendientes");
  Console.WriteLine("4. Salir");

  // Read line
  string optionSelected = Console.ReadLine();
  return Convert.ToInt32(optionSelected);
}

void ShowMenuRemove()
{
  try
  {
    Console.WriteLine("Ingrese el número de la tarea a remover: ");
    // Show current taks
    ShowTaskList();

    string optionSelected = Console.ReadLine();
    // Remove one position
    int indexToRemove = Convert.ToInt32(optionSelected) - 1;
    if (indexToRemove > -1 && TaskList.Count > 0 && indexToRemove < TaskList.Count)
    {
      string task = TaskList[indexToRemove];
      TaskList.RemoveAt(indexToRemove);
      Console.WriteLine("----------------------------------------");
      Console.WriteLine($"Tarea {task} eliminada");
    }
    else
    {
      Console.WriteLine("No se encontró la tarea a eliminar");
    }
  }
  catch (Exception ex)
  {
    Console.WriteLine("Ha ocurrido un error al intentar eliminar la tarea");
    // mensaje de error (ex.Message) en log para revisión
  }
}

void ShowMenuAdd()
{
  try
  {
    Console.WriteLine("Ingrese el nombre de la tarea: ");
    string task = Console.ReadLine();

    if (!string.IsNullOrEmpty(task))
    {
      TaskList.Add(task);
      Console.WriteLine("Tarea registrada");
    }
    else
    {
      Console.WriteLine("No se puede agregar una tarea vacía");
    }

  }
  catch (Exception)
  {
    Console.WriteLine("Ha ocurrido un error al intentar agregar la tarea");
    // mensaje de error (ex.Message) en log para revisión
  }
}

void ShowMenuTaskList()
{
  if (TaskList?.Count > 0)
  {
    ShowTaskList();
  }
  else
  {
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("No hay tareas por realizar");
  }
}

void ShowTaskList()
{
  Console.WriteLine("----------------------------------------");

  var indexTask = 0;
  // cuando se usa indexTask++ se incrementa después de que se usa
  // cuando se usa ++indexTask se incrementa antes de que se use
  TaskList.ForEach(task => Console.WriteLine($"{++indexTask} . {task}"));

  Console.WriteLine("----------------------------------------");
}

public enum MenuOptions
{
  Add = 1,
  Remove = 2,
  List = 3,
  Exit = 4
}
