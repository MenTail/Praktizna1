using System;

namespace StructConlsole
{
    struct Company
    {
        public string Name;
        public string Position;
        public double Salary;
        public Company(string Name = "NONE", double Salary = 0, string Position = "NONE")
        {
            this.Name = Name; // Назва компанiї; 
            this.Salary = Salary; // Посада працiвника;
            this.Position = Position; // Зарплата працiвника.
        }
    }
    struct Worker
    {
        public int Year; // Рiк початку роботи
        public int Month; // Мiсяць початку роботи
        public string Name; // Прiзвище та iнiцiали працiвника;
        public Company WorkPlace; // Структура типу Company
        public Worker(string Name = "NONE", int Month = 0, int Year = 1900)
        {
            this.Name = Name;
            this.Year = Year;
            this.Month = Month;
            this.WorkPlace = new Company();
        }
        public double GetTotalMoney() // Повертає загальну суму зароблених коштiв за усi мiсяцi роботи.
        { return (this.GetWorkExperience() * WorkPlace.Salary); }
        public int GetWorkExperience() // Обраховує i повертає стаж роботи на пiдприємствi у мiсяцях.
        { return ((DateTime.Now.Month + DateTime.Now.Year * 12) - (this.Month + this.Year * 12)); }
    }
    class Program
    {
        static Worker[] ReadWorkersArray() // Читає з клавiатури масив структур i повертає масив структур типу Worker
        {
            Console.Write("|+| Ввести кiлькiсть працiвникiв: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Worker[] Zis = new Worker[size];
            for (int i = 0; i < size; i++)
            {
                Zis[i] = new Worker(); Company temp = new Company();
                Console.Write("\n|+| Працiвник " + (i + 1) + "\nВвести iмя працiвника --> "); Zis[i].Name = Console.ReadLine();
                Console.Write("|+| Ввести рiк влаштування на роботу --> "); Zis[i].Year = Convert.ToInt32(Console.ReadLine());
                Console.Write("|+| Ввести мiсяць влаштування на роботу --> "); Zis[i].Month = Convert.ToInt32(Console.ReadLine());
                Console.Write("|+| Ввести назву роботи --> "); temp.Name = Console.ReadLine();
                Console.Write("|+| Ввести назву посади --> "); temp.Position = Console.ReadLine();
                Console.Write("|+| Ввести зарплату працiвника --> "); temp.Salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(); Zis[i].WorkPlace = temp;
            }
            return Zis;
        }
        static void PrintWorker(Worker ob) // Приймає структуру типу Worker i виводить її на екран
        {
            Console.Write("|+| iмя : " + ob.Name);
            Console.Write("\n|+| Зарплата : " + ob.WorkPlace.Salary);
            Console.Write("\n|+| Компанiя : " + ob.WorkPlace.Name);
            Console.Write("\n|+| Статус працiвника : " + ob.WorkPlace.Position);
            Console.Write("\n|+| На посадi (мiсяць) : " + ob.GetWorkExperience());
        }
        static void PrintWorkers(Worker[] ob) // Приймає масив структур типу Worker i виводить його на екран
        {
            for (int i = 0; i < ob.Length; i++) { Console.Write("\n|+| Номер " + (i + 1) + ":\n"); PrintWorker(ob[i]); }
        }
        static void GetWorkersInfo(Worker[] obj, out double max_time, out double min_time) // Приймає масив структур типу
        // Worker i повертає через out- параметри найбiльшу та найменшу зарплату серед усiх працiвникiв.
        {
            max_time = obj[0].WorkPlace.Salary;
            min_time = max_time;
            for (int i = 1; i < obj.Length; i++)
            {
                if (max_time < obj[i].WorkPlace.Salary) { max_time = obj[i].WorkPlace.Salary; }
                else if (min_time > obj[i].WorkPlace.Salary) { min_time = obj[i].WorkPlace.Salary; }
            }
        }
        static Worker[] SortWorkerByWorkExperience(Worker[] wo) // Приймає масив структур типу Worker i сортує
        // його за зростанням стажу роботи.
        {
            for (int i = 1; i < wo.Length; i++)
            {
                for (int j = 0; j < wo.Length - i; j++)
                {
                    if (wo[j].GetWorkExperience() > wo[j + 1].GetWorkExperience())
                    { Worker Zis = wo[j]; wo[j] = wo[j + 1]; wo[j + 1] = Zis; }
                }
            }
            return wo;
        }
        static void Main()
        {
            Worker[] test = ReadWorkersArray(); PrintWorkers(test);
            double max_time, min_time; GetWorkersInfo(test, out max_time, out min_time);
            Console.Write("|+| Максимальна зарплата - " + max_time + ",\n|+| Мiнiмальна зарплата - " + min_time + ".\n");
            Console.Write("|+| Скилл : \n"); PrintWorkers(SortWorkerByWorkExperience(test)); Console.ReadKey();
        }
    }
}