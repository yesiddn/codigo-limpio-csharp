using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
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
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
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

        public static void ShowMenuRemove()
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
                    Console.WriteLine("Tarea " + task + " eliminada");
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

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();

                if(!string.IsNullOrEmpty(task))
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

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                ShowTaskList();
            }
        }

        public static void ShowTaskList()
        {
            Console.WriteLine("----------------------------------------");

            var indexTask = 0;
            // cuando se usa indexTask++ se incrementa después de que se usa
            // cuando se usa ++indexTask se incrementa antes de que se use
            TaskList.ForEach(task => Console.WriteLine((++indexTask) + ". " + task));
            
            Console.WriteLine("----------------------------------------");
        }

        public enum MenuOptions
        {
            Add = 1,
            Remove = 2,
            List = 3,
            Exit = 4
        }

    }
}
