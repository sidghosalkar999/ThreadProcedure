using System;
using DatabaseDemo;

namespace CRUDDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 C = new Class1();
            C.DisplayStudent();

            C.AddStudent();
            C.DisplayStudent();

            C.EditStudent();
            C.DisplayStudent();

            C.DeleteStudent();
            C.DisplayStudent();
        }
    }
}