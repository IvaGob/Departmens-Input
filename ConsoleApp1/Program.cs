

namespace ConsoleApp1
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        public string name;
        public int plannedTime;
        public int factTime;
        public int deviationInHours()
        {
            return plannedTime - factTime;
        }
        public float deviationInPercent()
        {
            return (deviationInHours() * 100) / plannedTime;
        }

        public Department(string name, int plannedTime, int factTime)
        {
            this.name = name;
            this.plannedTime = plannedTime;
            this.factTime = factTime;
        }
    }
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            List<Department> arr = new List<Department>();
            //Цикл вводу данних кафедр
            do
            {
                Console.WriteLine("Введіть данні кафедри:");
                //Ввід назви кафедри
                Console.WriteLine("Введіть назву:");
                string InputName = Console.ReadLine();
                //Ввід запланованих годин
                Console.WriteLine("Введіть заплановані години:");
                string InputPlannedTime = Console.ReadLine();
                //Ввід фактичних годин
                Console.WriteLine("Введіть фактичні новини години:");
                string InputFactTime = Console.ReadLine();
                //Створення нового екземпляра класу Department і його додавання в масив arr
                arr.Add(new Department(InputName, Convert.ToInt32(InputPlannedTime), Convert.ToInt32(InputFactTime)));
                Console.WriteLine("Продовжити ввід кафедр? (y/n) ");
            } while (Console.ReadLine() == "y");
            int plannedTimeSum =0;
            int factTimeSum = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                plannedTimeSum+=arr[i].plannedTime;
                factTimeSum += arr[i].factTime;
                Console.WriteLine("("+Convert.ToString(i+1)+")");
                Display(arr[i]);
            }
            Department sum = new Department("Разом",plannedTimeSum,factTimeSum);
            Display(sum);
            //Виведення данних кафедри
            void Display(Department department)
            {
                Console.WriteLine("Кафедра:" + department.name +
                                   "\n\tВикористання машинного часу" +
                                   "\n\t\tЗа планом: " + department.plannedTime +
                                   "\n\t\tФактично: " + department.factTime +
                                   "\n\tВідхилення від плану" +
                                   "\n\t\tУ годинах: " + department.deviationInHours() +
                                   "\n\t\t У %: " + department.deviationInPercent());
            }
        }
    }
}
