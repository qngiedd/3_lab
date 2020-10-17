using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public partial class Student //поля
    {
        public const int NumberOfStudents = 1000; //поле константа
        private readonly int ID; //поле только для чтения
        private string Surname { get; set; }
        private string Name { get; set; }
        private string middleName { get; set; }
        private DateTime birthDate { get; set; }
        private static DateTime Now { get; }
        private int Age { get; }
        private int phoneNumber { get; set; }
        private string Faculty { get; set; }
        private int Course { get; set; }
        public int Group { get; set; }
        private static int numberOfObjects; //статическое поле, хранящее количество объектов
        private static Random random = new Random();
    }
    public partial class Student //конструкторы
    {
        static Student()  //статический конструктор, без параметров (закрытый автоматически)
        {
            numberOfObjects = 0;
        }
        //private Student() { } закрытый конструктор, который запрещает создание конструктора без параметров
        public Student() //конструктор по умолчанию
        {
            numberOfObjects++;
            ID = GetHashCode();
            Surname = "Draguts";
            Name = "Angelina";
            middleName = "Sergeevna";
            DateTime birthDate = new DateTime(1999, 11, 13);
            Age = howOldAreStudent();
            phoneNumber = 8810170;
            Faculty = "FIT";
            Course = 2;
            Group = 11;
        }
        public Student(string surname, string name, string middlename, DateTime birthdate, int phonenumber, string faculty, int course, int group) //конструктор с параметрами
        {
            numberOfObjects++;
            ID = GetHashCode();
            Surname = surname;
            Name = name;
            middleName = middlename;
            birthDate = birthdate;
            Age = howOldAreStudent();
            phoneNumber = phonenumber;
            Faculty = faculty;
            Course = course;
            Group = group;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Faculty: {Faculty} \n ID: {ID} \n Surname: {Surname} \n Name: {Name} \n Middle Name {middleName} \n Student was born on {birthDate} \n Age: {Age} \n Phone number: {phoneNumber} \n Course: {Course} \n Group: {Group} \n\n");
        }
        public void GetInfoAboutGroup()
        {
            Console.WriteLine($"{Name} {middleName} {Surname} \n");
        }
        public static string GetNumberOfObjects() //статический метод
        {
            return string.Format("The amount of objects is {0}", numberOfObjects);
        }
        public static void SelectFaculty(ref Student[] ListOfStudents) //проверка элементов массива на совпадение введенному факультету
        {
            Console.Write("Enter faculty: ");
            string enterFaculty = Console.ReadLine();

            for (int i = 0; i < ListOfStudents.Length; i++)
            {
                if (ListOfStudents[i].Faculty == enterFaculty)
                {
                    Console.WriteLine(ListOfStudents[i].Name + " " + ListOfStudents[i].middleName + " " + ListOfStudents[i].Surname);
                }
            }
        }
        public static void SelectGroup(ref Student[] ListOfStudents) //проверка элементов массива на совпадение введенной группе
        {
            Console.Write("Enter group: ");
            int enterGroup = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < ListOfStudents.Length; i++)
            {
                if (ListOfStudents[i].Group == enterGroup)
                {
                    Console.WriteLine(ListOfStudents[i].Name + " " + ListOfStudents[i].middleName + " " + ListOfStudents[i].Surname);
                    Console.WriteLine();
                }
            }
        }
    }
    public partial class Student //переопределения методов класса Object
    {
        public override int GetHashCode() //переопределение GetHashCode
        {
            int IDnumber = random.Next(5, 72);
            IDnumber = (IDnumber / 2 * (IDnumber + 131199));
            return IDnumber;
        }
        public override string ToString() //переопределение ToString
        {
            return base.ToString();
        }
        public override bool Equals(object obj) //переопределение Equals
        {
            bool myEqual = base.Equals(obj); //определяет равен ли указанный объект текущему объекту
            return myEqual;
        }
        public int howOldAreStudent()
        {
            var nowDate = DateTime.Today;
            var age = nowDate.Year - birthDate.Year;
            if (birthDate > nowDate.AddYears(-age)) 
                age--;
            return age;
        }
    }

    public class RefParameterExample //передача параметра по ссылке
    {
        static void One(string[] args) 
        { 
            int x = 61;
            int y = 4;
            Addition(ref x, y); 
            Console.WriteLine(x); //65 
            Console.ReadLine();
        }
        static void Addition(ref int x, int y)
        {
         x += y;
        }
    }
    public class OutParameterExample
    {
        static void Sum(int x, int y, out int a)
        {
            a = x + y;
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
            
 
            Student S1 = new Student("Baranovskaya", "Marina", "Vitalievna", new DateTime(2002,11,09), 1523854, "FIT",2,11);
            S1.GetInfo();
           

            Student S2 = new Student("Belaya", "Anna", "Igorevna", new DateTime(2001, 12, 03), 5686001, "FIT", 2, 11);
            S2.GetInfo();
          

            Student S3 = new Student("Briksa", "Olga", "Alexandrovna", new DateTime(2002, 06, 06), 5478239, "FIT", 2, 11);
            S3.GetInfo();
            

            Student S4 = new Student("Bytimova", "Karina", "Sergeevna", new DateTime(2001, 11, 01), 1012899, "FIT", 2, 11);
            S4.GetInfo();
            
         
            Student S5 = new Student("Kireenko", "Nadezhda", "Ivanovna", new DateTime(2002, 07, 16), 5202560, "FIT", 2, 11);
            S5.GetInfo();
           

            Student S6 = new Student("Kamenko", "Pavel", "Nikolaevich", new DateTime(1999, 09, 26), 1313072, "FIT", 2, 15);
            S6.GetInfo();
            Console.WriteLine();

            Student S7 = new Student("Sattarova", "Alexandra", "Petrovna", new DateTime(1999, 05, 10), 7853098, "FIT", 2, 15);
            S7.GetInfo();
            Console.WriteLine();

            Student S8 = new Student("Shpakova", "Valeria", "Dmitrievna", new DateTime(1999, 05, 12), 1231245, "FIT", 2, 13);
            S8.GetInfo();
            Console.WriteLine();

            Student S9 = new Student("Areshko", "Arseniy", "Andreevich", new DateTime(1999, 05, 25), 6214329, "FIT", 2, 13);
            S9.GetInfo();
            Console.WriteLine();

            Student S10 = new Student("Ivantsova", "Valentina", "Jurievna", new DateTime(2002, 07, 18), 7826726, "FIT", 2, 11);
            S10.GetInfo();
            Console.WriteLine();

            Student S11 = new Student("Mazurina", "Angelina", "Lvovna", new DateTime(2001, 04, 17), 1452147, "FIT", 2, 11);
            S11.GetInfo();
            Console.WriteLine();

            Student S12 = new Student("Metlitskaya", "Alexandra", "Dmitrievna", new DateTime(1999, 11, 26), 6214329, "FIT", 2, 13);
            S12.GetInfo();
            Console.WriteLine();

            Student S13 = new Student("Budnyak", "Eduard", "Stanislavovich", new DateTime(1998, 10, 30), 6236222, "FIT", 2, 15);
            S13.GetInfo();
            Console.WriteLine();

            Student[] ListOfStudents = new Student[] { S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13};
         

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("The list of students from chosen faculty");
            Student.SelectFaculty(ref ListOfStudents);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("The list of students from chosen group");
            Student.SelectGroup(ref ListOfStudents);

            var Person = new { Name = "Alisa", phoneNumber = 1234567 }; //анонимный тип
            Console.WriteLine(Person.Name);

            Console.ReadKey();
            }
        }
    }





