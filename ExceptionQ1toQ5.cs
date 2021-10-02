using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Q1- Write a program which can take two integers to multiply and divide. Handle different Exceptions e.g. divide by zero exception, overflow exception etc.
Q2- Write a program which can create a directory and write a string to a file in the directory. Handle different exceptions. (Directory.Create to create directory, File.Create to create file and File.WriteText to write string to file)
Q3- Create a stack to add integers to stack, implement Push and Pop. Handle the exceptions which can handle conditions if you pop more than available items from stack.
Q4- Create an array with 10 integers, Write an indexer to access its values and set values. Handle the exception if an unknown index is accessed and set.
Q5- Write a program to enter customer information to the customer collection. Customer information can contain id, name, address etc. Write methods and/or indexers to access the customer information by id and name.if you access an customer information which is not present handle the exception and show appropriate messages.
*/
namespace ExceptionMultiplyDivide
{
    public delegate void DelegateException(object a, object b);
    class Program
    {
        class Multiplication
        {
            public void Multiply(object a, object b)
            {
                try
                {
                    int input1 = Int32.Parse((string)a);
                    int input2 = Int32.Parse((string)b);
                    Console.WriteLine(input1*input2);
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("Invalid cast detected: " + ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Format exception raised: " + ex.Message);
                    Console.WriteLine("Please only enter numbers");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Null exception raised: " + ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Exception raised {ex.Message}");
                    Console.WriteLine("Number cannot be divided by zero");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Overflowed: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }//Q1
        class Division
        {
            public void Divide(object a, object b)
            {
                try
                {
                    int input1 = Int32.Parse((string)a);
                    int input2 = Int32.Parse((string)b);
                    Console.WriteLine(input1 / input2);
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("Invalid cast detected: " + ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Format exception raised: " + ex.Message);
                    Console.WriteLine("Please only enter numbers");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Null exception raised: " + ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Exception raised {ex.Message}");
                    Console.WriteLine("Number cannot be divided by zero");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Overflowed: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }//Q1
        class Customer//Q5
        {
            public List<string> customerList = new List<string>();
            public event EventHandler dataAdded;
            int id { get; set; }
            string name { get; set; }
            string address { get; set; }
            string output;
            public string this[int i]
            {
                get
                {
                    return customerList[i];
                }
                set
                {
                    customerList.Add(output);
                    dataAdded?.Invoke(this, null);
                }
            }
            public void GetInput(int id, string name, string address)
            {
                output = "Name: " + name + "\nID: " + id + "\nAddress: " + address;
                customerList.Add(output);
            }
        }
        class Store //Q5
        {
            private Customer cus;
            public void subscribetoevent(Customer cus)
            {
                this.cus = cus;
                cus.dataAdded += Cus_dataAdded;
            }
            private void Cus_dataAdded(object sender, EventArgs e)
            {
                Console.WriteLine(sender + " is added to list");
            }
        }
        public static void Question1()
        {
            Console.WriteLine("Enter 1st input:");
            object a = Console.ReadLine();
            Console.WriteLine("Enter 2nd input:");
            object b = Console.ReadLine();

            Multiplication multiplication = new Multiplication();
            Division division = new Division();
            DelegateException delegateException = new DelegateException(multiplication.Multiply);
            delegateException += division.Divide;
            delegateException.Invoke(a,b);
        }
        public static void Question2()
        {
            Console.WriteLine("Enter name of file: ");
            string filename = Console.ReadLine();
            Console.WriteLine("Input string you wish to save to a file: ");
            string input = Console.ReadLine();
            string directory = @"C:\Users\USER\OneDrive\Desktop";
            try
            {
                Directory.CreateDirectory(directory);//create folder in location if its does not exist
                File.WriteAllText(filename, input);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Null Exception raised: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Path cannot be empty: " + ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine("Input path is too long: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Directory not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Not supported: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("IO exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Generic Exception: " + ex.Message);
            }


        }
        public static void Question3()
        {
            Stack<int> myStack = new Stack<int>();
            myStack.Push(10);
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Choose an option.");
                Console.WriteLine("1. Push");
                Console.WriteLine("2. Pop");
                Console.WriteLine("3. List Stack");
                Console.WriteLine("4. Exit");
                int input = Int32.Parse(Console.ReadLine());               
                if (input == 1)
                {                   
                    try
                    {
                        Console.WriteLine("Enter number to push:");
                        object a = Console.ReadLine();
                        int push = Int32.Parse((string)a);
                        myStack.Push(push);
                        Console.WriteLine(push + " has been pushed into stack.");
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine("Format exception raised: " + ex.Message);
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine("Null exception raised: " + ex.Message);
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine("Invalid cast exception raised: " + ex.Message);
                    }
                }
                else if(input == 2)
                {
                    int pop = myStack.Pop();
                    Console.WriteLine("The top number: " + pop + " has been popped from stack.");
                }
                else if(input == 3)
                {
                    Console.WriteLine("\nList of numbers in stack:");
                    foreach (var numbersInStack in myStack)
                    {
                        Console.WriteLine(numbersInStack);
                    }
                    Console.WriteLine("\n");
                }
                else if(input == 4)
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Wrong option!");
                }
            }
        }
        public static void Question4()
        {
            int[] arrayException = new int[10];
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("1. Set a value to the index.");
                Console.WriteLine("2. Display a value of an index.");
                Console.WriteLine("3. Display all value in the array.");
                Console.WriteLine("4. Exit.");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.Write("Enter the value you wish to store: ");
                            string value = Console.ReadLine();
                            Console.Write("Enter the index position you wish to store it at: ");
                            string index = Console.ReadLine();
                            try
                            {
                                int index1 = Int32.Parse((string)index);
                                int value1 = Int32.Parse((string)value);
                                arrayException[index1] = value1;
                                Console.WriteLine(value + " has been stored at index: " + index1);
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.WriteLine("Argument Null Exception caught: " + ex.Message);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Format Exception raised: " + ex.Message);
                            }
                            catch (OverflowException ex)
                            {
                                Console.WriteLine("Overflow Exception raised: " + ex.Message);
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                Console.WriteLine("Index Out Of Range Exception raised: " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("General Exception: " + ex.Message);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter the index position you wish to display: ");
                            string index = Console.ReadLine();
                            try
                            {
                                int index1 = Int32.Parse((string)index);
                                Console.WriteLine("Position " + index + " contains: " + arrayException[index1]);
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.WriteLine("Argument Null Exception caught: " + ex.Message);
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Format Exception raised: " + ex.Message);
                            }
                            catch (OverflowException ex)
                            {
                                Console.WriteLine("Overflow Exception raised: " + ex.Message);
                            }
                            catch (IndexOutOfRangeException ex)
                            {
                                Console.WriteLine("Index Out Of Range Exception raised: " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("General Exception: " + ex.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("All values in array:");
                            foreach (var value in arrayException)
                            {
                                Console.WriteLine(value);
                            }
                            break;
                        }
                    case 4:
                        {
                            loop = false;
                            break;
                        }

                }
            }
        }
        public static void Question5()
        {
            Customer customer = new Customer();
            Store store = new Store();
            store.subscribetoevent(customer);
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("1. Search Customer Name: \n2. Display all customer name: \n3. Add new customer:");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter customer name:");
                            string name = Console.ReadLine();
                            try
                            {
                            }
                            catch (Exception ex)
                            {

                            }
                            break;
                        }
                    case 2:
                        {
                            foreach (var cname in customer.customerList)
                            {
                                Console.WriteLine(cname);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter your name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter your ID:");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter your address:");
                            string addr = Console.ReadLine();
                            customer.GetInput(id, name, addr);
                            break;
                        }
                }
            }
        }
        static void Main(string[] args)
        {
            //Question1();
            //Question2();
            //Question3();
            //Question4();
            Question5();
        }
    }
}
