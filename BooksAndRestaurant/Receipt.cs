using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksAndRestaurant
{
    class Receipt
    {
        public string ResName { get; set; }
        public string ResType { get; set; }
        public int ReceiptNum { get; set; }
        public int TableNum { get; set; }
        public string WaiterName { get; set; }
        public int WaiterNum { get; set; }
        public int NumOfCustomers { get; set; }
        public double TipPerc { get; set; }

        private decimal Subtotal;
        private decimal Tip;
        private decimal Total;

        public List<Food> ProductsDetail;

        public Receipt(string restaurantName, string restaurantType, int billNumber,
            int tableNumber, string waiterName, int waiterNumber, int numberOfCustomers, double tipPercentage,
            List<Food> listOfProducts)
        {
            ResName = restaurantName;
            ResType = restaurantType;
            ReceiptNum = billNumber;
            TableNum = tableNumber;
            WaiterName = waiterName;
            WaiterNum = waiterNumber;
            NumOfCustomers = numberOfCustomers;
            TipPerc = tipPercentage;
            ProductsDetail = listOfProducts;

            getSubtotal();
            getTip();
            getTotal();
        }
        private void getSubtotal()
        {
            Subtotal = ProductsDetail.Sum(item => item.SubtotalProduct);
        }
        private void getTip()
        {
            Tip = Convert.ToDecimal(TipPerc * Convert.ToDouble(Subtotal));
        }
        private void getTotal()
        {
            Total = Tip + Subtotal;
        }
        public void printBill()
        {
            Console.WriteLine("\t\t{0}", ResName);
            Console.WriteLine("\t\t{0}\n",ResType);
            Console.WriteLine("\t\tEstado de Cuenta\n\t\tExija Su Factura\n");
            Console.WriteLine("\tCuenta: {0}  Mesa: {1}\n", ReceiptNum, TableNum);
            Console.WriteLine("\tMesero: {0}  Personas: {1}\n", WaiterNum, NumOfCustomers);
            foreach (Food product in ProductsDetail)
            {
                Console.WriteLine("\t{0} x {1}\n", product.Quantity, product.Price);
                Console.WriteLine("\t{0}\t\t${1}\n", product.Name, product.SubtotalProduct);
            }
            Console.WriteLine("\t           -----------------");
            Console.WriteLine("\tSUBTOTAL:\t\t${0}", Subtotal);
            Console.WriteLine("\tPropina:\t\t${0}", Tip);
            Console.WriteLine("\tTotal:\t\t${0}\n", Total);
            Console.WriteLine("\t{0}",WaiterName);
            Console.WriteLine("\tFecha: {0}", DateTime.Now);
        }
    }
}
