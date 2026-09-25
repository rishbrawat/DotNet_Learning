using System;
using System.ComponentModel.Design.Serialization;
using System.Xml.Linq;
using static Microsoft.Data.SqlClient.Internal.SqlClientEventSource;

/**
 * class is a user defined datatype / custom data structure, it defines what variables(data) and methods(action) an entity will have. an instance of the class is not created untill an object is instantiated
 * 
 * class ClassName{
 *  fields
 *  methods
 *  properties
 * }
 * */


// modifiers: defines the accessibility of the class, by default its internal

// internal class: a class that can only be accessed by  code inside the same project, and is completely hidden from other projects.

/*
    access modifiers:
    public: anyone within the project can access the class , other projects, assemblies that references our code.

    private: its accessible within the class only or struct where it is declared, its a default modifier.

    protected: accessible with class or child classes that inherit from it.

*/
<<<<<<< HEAD
namespace oop { 
    class Student
    {
        // get and set methods are used  inside a proprety to control how a value is read and changed

        // get -> reads the value
        // set -> sets the value
        // value -> a special keyword containing the value being passed
        // a field is a variable declared inside a class
        // a property is a controlled way to access the data 

        // the syntax below is called auto-implemented property, c# automatically creates the hidden storage needed for the property. we can also disable the ability to make changes using {private get; private set;)
        private int id = 0;
        private string name = "NULL";
        private int age = 0;
        private string course = "NULL";
        private int[] marks = new int[0];

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value; // value: speical keyword for the value being passed.
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
            }
        }

        public int[] Marks
        {
            get
            {
                return marks;
            }
            set
            {
                marks = value;
            }
        }
=======
namespace OOPS {
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public int[] Marks { get; set; }

>>>>>>> 1efd250199b35ead97735e182d6a3c40579a8ac1
        public Student(int id, string name, int age, string course, int[] marks)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Course = course;
            this.Marks = marks;
        }

        public void printDetails()
        {
            Console.WriteLine($" Name: {this.Name}\n ID: {this.Id}\n Age: {this.Age}\n Course: {this.Course}\n");
        }

    }

    public class MainProgram
    {
        static void Main()
        {
            Student std1 = new Student(1, "Rishabh Rawat", 23, "BTech CSE", new int[] { 96, 97, 95, 99, 97 });
            Student std2 = new Student(2, "Ankush Chauhan", 25, "BTech CSE", new int[] {61, 45, 41, 62, 0});
<<<<<<< HEAD

            std1.printDetails();
            std2.printDetails();
        }
    }
}
=======

            std1.printDetails();
            std2.printDetails();
        }
    }

}
>>>>>>> 1efd250199b35ead97735e182d6a3c40579a8ac1
