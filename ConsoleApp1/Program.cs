

namespace ConsoleApp1
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        private string name { get; set; }

        private int _plannedTime = 0;
        int plannedTime
        {
            get => _plannedTime;
            set
            {
                if (value >= 0) _plannedTime = value;
            }
        }
        private int _factTime = 0;
        int factTime
        {
            get => _factTime;
            set
            {
                if (value >= 0 && value <= plannedTime)
                {
                    _factTime = value;
                }
                else if (value > plannedTime) _factTime = plannedTime;
            }
        }
        public int deviationInHours()
        {
            return plannedTime - factTime;
        }
        public float deviationInPercent()
        {
            return (deviationInHours() * 100) / plannedTime;
        }
        public int GetPlannedTime()
        {
            return plannedTime;
        }
        public int GetFactTime()
        {
            return factTime;
        }
        public Department(string name, int plannedTime, int factTime)
        {
            this.name = name;
            this.plannedTime = plannedTime;
            this.factTime = factTime;
        }
        public virtual void Display()
        {
            Console.WriteLine("Кафедра:" + this.name +
                               "\n\tВикористання машинного часу" +
                               "\n\t\tЗа планом: " + this.plannedTime +
                               "\n\t\tФактично: " + this.factTime +
                               "\n\tВідхилення від плану" +
                               "\n\t\tУ годинах: " + this.deviationInHours() +
                               "\n\t\t У %: " + this.deviationInPercent());
        }
    }
    class AllDepartments : Department
    {
        private int _plannedTime = 0;
        int plannedTime { get => _plannedTime;
            set 
            {
                if(value>=0)_plannedTime = value;
            } 
        }
        private int _factTime= 0;
        int factTime { get => _factTime;
            set
            {
                if (value >= 0) _factTime = value;
            }
        }
        public AllDepartments(int plannedTime, int factTime) : base("разом", plannedTime, factTime)
        {
            this.plannedTime= plannedTime;
            this.factTime= factTime;
        }

        public override void Display()
        {
            Console.WriteLine("Разом:"+
                              "\n\tВикористання машинного часу" +
                              "\n\t\tЗа планом: " + this.plannedTime +
                              "\n\t\tФактично: " + this.factTime +
                              "\n\tВідхилення від плану" +
                              "\n\t\tУ годинах: " + this.deviationInHours() +
                              "\n\t\t У %: " + this.deviationInPercent());
        }
    }

    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            List<Department> arr = new List<Department>();
            Input(arr);

            int plannedTimeSum =0;
            int factTimeSum = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                plannedTimeSum += arr[i].GetPlannedTime();
                factTimeSum += arr[i].GetFactTime();
                
                Console.WriteLine("("+Convert.ToString(i+1)+")");
                arr[i].Display();
            }
            AllDepartments all = new AllDepartments(plannedTimeSum,factTimeSum);
            all.Display();
            
        }
        //Ввід данних
        static void Input(List<Department> arr)
        {
            //Цикл вводу данних кафедр
            do
            {
                Console.WriteLine("Введіть данні кафедри:");
                //Ввід назви кафедри
                Console.WriteLine("Введіть назву:");
                string InputName = Console.ReadLine();
                //Ввід запланованих годин
                Console.WriteLine("Введіть заплановані години:");
                int InputPlannedTime = Convert.ToInt32(Console.ReadLine());
                //Ввід фактичних годин
                Console.WriteLine("Введіть фактичні години:");
                int InputFactTime = Convert.ToInt32(Console.ReadLine());
                //Створення нового екземпляра класу Department і його додавання в масив arr
                arr.Add(new Department(InputName, InputPlannedTime, InputFactTime));
                Console.WriteLine("Продовжити ввід кафедр? (y/n) ");
            } while (Console.ReadLine() == "y");
        }
    }
}
