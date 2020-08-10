using System;
using Sessao9_ExercicioProposto.Entities;
using Sessao9_ExercicioProposto.Entities.Enums;
using System.Collections.Generic;

namespace Sessao9_ExercicioProposto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n   Éoq of Last Session 9 Exercise");

            Console.WriteLine("\n   Type the client's data below ");

            Console.Write("\n   Name: ");
            string CName = Console.ReadLine();

            Console.Write("\n   Email: ");
            string CEmail = Console.ReadLine();

            Console.Write("\n   Client's birth date: ");
            string CBirth = Console.ReadLine();
            Console.WriteLine();

            DateTime BirthDate = DateTime.Parse(CBirth);

            Client PClient = new Client() { Name = CName, Email = CEmail, Date = BirthDate };           

            Console.WriteLine("\n   Enter the order data");
            Console.Write("\n   Status: ");
            string OStatus = Console.ReadLine();
            
            OrderStatus Status1;
            Enum.TryParse<OrderStatus>(OStatus, out Status1);
            Console.WriteLine("\n   Enum teste: " + Status1);
            
            Console.Write("\n   How many items (products) to this order? ");
            int OQuantity = int.Parse(Console.ReadLine());

            string PName = " ";
            double PPrice = 0.0;
            int PQuantity = 0;

            List<Product> LProduct = new List<Product>();
            for (int i = 0; i < OQuantity; i++)
            {
                Console.WriteLine($"\n\n   Enter the {i + 1} item data ");
                Console.Write("\n   Product Name: ");
                PName = Console.ReadLine();
                Console.Write("\n   Product Price: ");
                PPrice = double.Parse(Console.ReadLine());
                Console.Write("\n   Quantity: ");
                PQuantity = int.Parse(Console.ReadLine());

                LProduct.Add(new Product() { Name = PName, Price = PPrice, Quantity = PQuantity });                                
            }           
            Console.WriteLine();

            List<OrderItem> LOrderItem = new List<OrderItem>();
            foreach(Product prdct in LProduct)
            {
                LOrderItem.Add(new OrderItem() { Quantity = LProduct[LProduct.IndexOf(prdct)].Quantity, Price = LProduct[LProduct.IndexOf(prdct)].Price, Product = LProduct[LProduct.IndexOf(prdct)] });                
            }           

            DateTime Now = DateTime.Now;
            List<Order> LOrder = new List<Order>();
            LOrder.Add(new Order() { Moment = Now, Status = Status1, Client = PClient });
            
            foreach(OrderItem orderItem in LOrderItem)
            {                
                LOrder[0].Items.Add(orderItem);                
            }               

            List<string> RContainer = new List<string>();
            foreach(Order thatOrder in LOrder)
            {                                               
                Console.WriteLine(LOrder[LOrder.IndexOf(thatOrder)]);
                RContainer.Add((string)LOrder[LOrder.IndexOf(thatOrder)].ToString());              
            }
                         
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"G:\CS TXT Files\Relatory " + (LOrder.Count - 1) + ".txt"))                
            foreach (string line in RContainer)
            { 
                file.WriteLine(line);
            }            
            Console.WriteLine();

            // FIRST USER DECISION

            Console.Write("\n   Do you want to add a new order? Type Y to yes or N to no: ");            
            char Answer = char.Parse(Console.ReadLine());

            while(Answer != 'y' && Answer != 'Y' && Answer != 'n' && Answer != 'N')
            {
                Console.WriteLine("\n   You've entered a invalid answer. Try it again! ");
                Console.Write("   Do you want to add a new order? Type Y to yes and N to no: ");
                Answer = char.Parse(Console.ReadLine());
            }

            if(Answer == 'y' || Answer == 'Y')
            {
                Operations(LOrder);
            }
            else if(Answer == 'n' || Answer == 'N')
            {
                Console.WriteLine("\n   The end ");
            }

            // DIVISION!!!

            static void Operations(List<Order> thatOperationsOrder)
            {
                Console.WriteLine();

                Console.Write("\n   Name: ");
                string CName = Console.ReadLine();

                Console.Write("\n   Email: ");
                string CEmail = Console.ReadLine();

                Console.Write("\n   Client's birth date: ");
                string CBirth = Console.ReadLine();
                Console.WriteLine();

                DateTime BirthDate = DateTime.Parse(CBirth);

                Client PClient = new Client() { Name = CName, Email = CEmail, Date = BirthDate };

                Console.WriteLine("\n   Enter the order data");
                Console.Write("\n   Status: ");
                string OStatus = Console.ReadLine();

                OrderStatus Status1;
                Enum.TryParse<OrderStatus>(OStatus, out Status1);
                Console.WriteLine("\n   Enum teste: " + Status1);

                Console.Write("\n   How many items (products) to this order? ");
                int OQuantity = int.Parse(Console.ReadLine());

                string PName = " ";
                double PPrice = 0.0;
                int PQuantity = 0;

                List<Product> LProduct = new List<Product>();
                for (int i = 0; i < OQuantity; i++)
                {
                    Console.WriteLine($"\n\n   Enter the {i + 1} item data ");
                    Console.Write("\n   Product Name: ");
                    PName = Console.ReadLine();
                    Console.Write("\n   Product Price: ");
                    PPrice = double.Parse(Console.ReadLine());
                    Console.Write("\n   Quantity: ");
                    PQuantity = int.Parse(Console.ReadLine());

                    LProduct.Add(new Product() { Name = PName, Price = PPrice, Quantity = PQuantity });
                }                
                Console.WriteLine();

                List<OrderItem> LOrderItem = new List<OrderItem>();
                foreach (Product prdct in LProduct)
                {
                    LOrderItem.Add(new OrderItem() { Quantity = LProduct[LProduct.IndexOf(prdct)].Quantity, Price = LProduct[LProduct.IndexOf(prdct)].Price, Product = LProduct[LProduct.IndexOf(prdct)] });                 
                }                

                DateTime Now = DateTime.Now;
                thatOperationsOrder.Add(new Order() { Moment = Now, Status = Status1, Client = PClient }); // Instancing a new element to the Order List that came as a parameter                
                
                foreach(OrderItem OrderItem in LOrderItem) // INTERESTING!!!! This is the function OWN LOrderItem list!!!
                {
                    thatOperationsOrder[thatOperationsOrder.Count - 1].Items.Add(OrderItem); // A different way to write [thatOperationsOrder.IndexOf(thatOrder)]
                }

                List<string> RContainer = new List<string>();
                foreach (Order thatOrder in thatOperationsOrder)
                {
                    Console.WriteLine(thatOperationsOrder[thatOperationsOrder.IndexOf(thatOrder)]);
                    RContainer.Add((string)thatOperationsOrder[thatOperationsOrder.IndexOf(thatOrder)].ToString());                    
                }
                                
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"G:\CS TXT Files\Relatory " + (thatOperationsOrder.Count - 1) + ".txt"))
                foreach (string line in RContainer)
                {
                   file.WriteLine(line);
                }                
                
                Console.WriteLine();

                // LOOP USER DECISION

                Console.Write("\n   Do you want to add a new order? Type Y to yes or N to no: ");
                char Answer = char.Parse(Console.ReadLine());

                while (Answer != 'y' && Answer != 'Y' && Answer != 'n' && Answer != 'N')
                {
                    Console.WriteLine("\n   You've entered a invalid answer. Try it again! ");
                    Console.Write("   Do you want to add a new order? Type Y to yes and N to no: ");
                    Answer = char.Parse(Console.ReadLine());
                }

                if (Answer == 'y' || Answer == 'Y')
                {
                    Operations(thatOperationsOrder);
                }
                else if (Answer == 'n' || Answer == 'N')
                {
                    Console.WriteLine("\n   The end ");
                }
            }
        }                
    }
}
