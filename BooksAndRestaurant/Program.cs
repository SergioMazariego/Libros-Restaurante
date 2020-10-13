using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BooksAndRestaurant
{
    class Program
    {
        static public SetOfBooks myBooksCollection = new SetOfBooks();
        static  int limit = 0;
        static List<Receipt> receipts = new List<Receipt>();
        static void Main(string[] args)
        {
            DisplayMenu();
        }
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|      BIENVENIDO/A       |");
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("\n1. Libros");
            Console.WriteLine("2. Restaurante");
            Console.Write("\nSelecciona una opcion: ");
            string option = Console.ReadLine();
            ShowProgram(option);
        }
        static void ShowProgram(string option)
        {
            Console.Clear();
            if (option == "1")
            {
                Books();
            }
            else if (option == "2")
            {
                Restaurant();
            }
            else
            {  
                Console.WriteLine("Introduzca una opcion valida");
                Console.WriteLine("Espere...");
                Thread.Sleep(2000);
                DisplayMenu();
            }
        }
        static void Books()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|        BIBLIOTECA       |");
            Console.WriteLine("+-------------------------+");
            if (limit > 0 && limit < 5)
            {
                Console.WriteLine("1. Introducir libro");           //Si hay libros y aun puedo introducir libros entonces se pueden tomar ambas opciones
                Console.WriteLine("2. Consultar informacion por libro");
            }
            else if (limit == 0) 
            {
                Console.WriteLine("1. Introducir libro"); //Si no hay libros solo puedo introducirlos
            }
            else
            {
                Console.WriteLine("¡Espacio para libros lleno!");
                Console.WriteLine("2. Consultar informacion por libro"); //Si hay libros y ya no puedo introducir mas
            }
            Console.WriteLine("3. Volver al menu principal");

            Console.Write("Opcion: ");
            int option = Convert.ToInt32(Console.ReadLine());
            BooksOption(option);
        }

        static int BooksLimit(int limit)
        {
            if (limit < 5)
            {
                return 1;
            }
            else

            {
                Console.WriteLine("Espacio para libros agotado");
                Console.WriteLine("Presiona cualquir tecla para volver al menu");
                Console.ReadKey();
                return 0;
            }
        }
        static void AddBook()
        {
            Console.Write("Introduce titulo: ");
            string title = Console.ReadLine();
            Console.Write("Introduce autor: ");
            string author = Console.ReadLine();
            Console.Write("Introduce la calificacion: ");
            int qualification = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduce numero de paginas: ");
            string pages = Console.ReadLine();
            Book book = new Book(title, author, qualification, pages);
            myBooksCollection.BooksCollection[limit] = book;
            Console.WriteLine("Espere porfavor...");
            Thread.Sleep(2000);
            Console.Clear();
        }

        static void SelectBook(int index)
        {
            Console.WriteLine("\n¿Qué deseas consultar?");
            Console.WriteLine("1. Titulo");
            Console.WriteLine("2. Autor");
            Console.WriteLine("3. Numero de paginas");
            Console.WriteLine("4. Calificacion");
            Console.WriteLine("5. Toda la informacion");
            Console.Write("Opción: ");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (option)
            {
                case 1:
                    Console.WriteLine("Titulo: {0}",myBooksCollection.BooksCollection[index].Title);
                break;
                case 2:
                    Console.WriteLine("Autor: {0}", myBooksCollection.BooksCollection[index].Author);
                break;
                case 3:
                    Console.WriteLine("Páginas: {0}", myBooksCollection.BooksCollection[index].Pages);
                break;
                case 4:
                    Console.WriteLine("Calificación: {0}", myBooksCollection.BooksCollection[index].Qualification);
                break;
                case 5:
                    Console.WriteLine(myBooksCollection.BooksCollection[index].ToString());
                break;
                default:
                    SelectBook(index);
                    break;
            }
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
            Books();
        }
        static void ConsultBooks()
        {
            Console.Clear();
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("{0}. Titulo: {1}",i + 1 ,myBooksCollection.BooksCollection[i].Title);
            }
            Console.Write("Libro a consultar: ");
            int option = Convert.ToInt32(Console.ReadLine());
            SelectBook(option - 1); //Pasa el indice del libro para saber que quiere consultar 
        }
        static void BooksOption(int option)
        {
            if (option == 1)
            {
                Console.WriteLine("Introducir libro seleccionado");
                int next = 1;
                while (next == 1 && BooksLimit(limit) == 1)
                {
                    Console.Clear();
                    AddBook();
                    limit++;
                    Console.WriteLine("+----------------------------------+");
                    Console.WriteLine("|Espacio disponible: {0} libros mas. |", 5 - limit);
                    Console.WriteLine("+----------------------------------+");
                    Console.Write("Introducir otro libro? Si(1)/No(0)");
                    next = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
                Books();
            }
            else if (option == 2)
            {
                ConsultBooks();
                Console.ReadKey();
            }
            else if (option == 3)
            {
                DisplayMenu();
            }
            else
            {
                Console.WriteLine("Ingrese opcion valida");
                Books();
            }
        }
        static void Restaurant()
        {
            Console.Clear();
            Console.WriteLine("+----------------------+");
            Console.WriteLine("|SISTEMA DE FACTURACIÓN|");
            Console.WriteLine("+----------------------+");
            Console.WriteLine("\n¿Qué deseas hacer?");
            Console.WriteLine("\n1. Tomar orden.");
            Console.WriteLine("2. Generar json.");
            Console.Write("\nOpcion: ");
            int option = Convert.ToInt32(Console.ReadLine());
            RestaurantOptions(option);
        }

        static void RestaurantOptions(int option)
        {
            if (option == 1)
            {
                TakeOrder();
            }
            else if (option == 2)
            {
                PrintJsonReceipts();
            }
            else
            {
                Restaurant();
            }
            
        }

        static void PrintJsonReceipts()
        {
            string json = JsonConvert.SerializeObject(receipts.ToArray());
            System.IO.File.WriteAllText(@"C:\json\receipts.json",json);
            Console.WriteLine("Json generado, presiona cualquier tecla para continuar");
            Console.ReadKey();
            Restaurant();
        }
        static void TakeOrder()
        {
            Console.Clear();
            List<Food> products = new List<Food>();
            Receipt receipt;
            Console.Write("Ingrese nombre de restaurante: ");
            string ResName = Console.ReadLine();
            Console.Write("\nIngrese tipo de restaurante: ");
            string ResType = Console.ReadLine();
            Console.Write("\nIngrese número de factura: ");
            string BillNumber = Console.ReadLine();
            Console.Write("\nIngrese número de clientes de la mesa: ");
            string TableNumber = Console.ReadLine();
            Console.Write("\nIngrese el número de mesa: ");
            string NumOfCust = Console.ReadLine();
            Console.Write("\nIngrese l nombre del mesero: ");
            string WaiterName = Console.ReadLine();
            Console.Write("\nIngrese el numero de identificacion del mesero: ");
            string WaiterNum = Console.ReadLine();
            Console.Write("\nIngrese la número de productos a comprar: ");
            string prodQuant = Console.ReadLine();
            for (int i = 0; i < Convert.ToInt16(prodQuant); i++)
            {
                Console.Write("\nIngrese el nombre del producto #{0} a comprar: ", i + 1);
                string prodName = Console.ReadLine();
                Console.Write("\nIngrese el precio del producto #{0} a comprar: ", i + 1);
                string prodPrice = Console.ReadLine();
                Console.Write("\nIngrese la cantidad del producto #{0} a comprar: ", i + 1);
                string prodQuanti = Console.ReadLine();
                products.Add(new Food(prodName, Convert.ToDecimal(prodPrice), Convert.ToInt32(prodQuanti)));
            }
            Console.Write("\nIngrese el porcentaje de propina a aplicar: ");
            string tipPer = Console.ReadLine();
            receipt = new Receipt(ResName, ResType, Convert.ToInt32(BillNumber),
                Convert.ToInt32(TableNumber), WaiterName, Convert.ToInt32(WaiterNum),
                Convert.ToInt32(NumOfCust), Convert.ToDouble(tipPer), products);
            receipts.Add(receipt);
            Console.WriteLine("\nPresiona cualquier tecla para imprimir ticket");
            Console.ReadKey();
            Console.WriteLine();
            receipt.printBill();
            Console.WriteLine("\nPresiona cualquier tecla para continuar");
            Console.ReadKey();
            Console.WriteLine();
            Restaurant();
        }
    }
}
