using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Distribution_center_V2
{
    class Program
    {
   //     Create arrays
        static int articleId;
        static string[] articleName = new string[20];
        static float[] supplingCost = new float[20];
        static float[] SellingPrice = new float[20];
 
        static int supplierId;
        static string[] supplierName = new string[5];

        static int clientId;
        static string[] clientName = new string[15];

        static int supplingInvoiceId;
        static string[,] supplingInvoice = new string[20, 6];

        static int sellingInvoiceId;
        static string[,] sellingInvoice = new string[20, 6];

        static string choice;
   //     Main method begings application execution
        static void Main(string[] args)
        {
            do
            {
            start:
                Console.Clear();
          //   Create user interface
                Console.WriteLine("1-Create an article.");
                Console.WriteLine("2-Create a supplier.");
                Console.WriteLine("3-Create a client.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("4-Create a suppling invoice.");
                Console.WriteLine("5-Create a selling invoice.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("6-Find an article stock quantity.");
                Console.WriteLine("7-Find an article Sell quantity.");
                Console.WriteLine("8-Find a supplier invoices.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("9-Articles list.");
                Console.WriteLine("10-Suppliers list.");
                Console.WriteLine("11-Clients list.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("12-Suppling invoices list.");
                Console.WriteLine("13-Selling invoices list.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("14-To Exit");
          //    End user interface
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
             //     call method CreateArticles   
                        CreateArticles();
                        goto start;
                        break;
                    case "2":
             //     call method CreateSupplier
                        CreateSupplier();
                        break;
                    case "3":
             //     call method CreateClient
                        CreateClient();
                        goto start;
                        break;
                    case "4":
             //     call method CreateSupplingInvoice
                        CreateSupplingInvoice();
                        break;
                    case "5":
             //     call method CreateSellingInvoice
                        CreateSellingInvoice();
                        break;
                    case "6":
             //     find the amount of articles in the stock
                        Console.WriteLine("Article to find stock:");
                        string _articleName = Console.ReadLine();
                        if (!CheckArticleExisiting(_articleName))
                        {
                            Console.WriteLine("Article not found!");
                            return;
                        }
                        Console.WriteLine("Still " + FindArticleStock(_articleName) + " in stock!");
                        Console.ReadKey();
                        break;
                    case "7":
              //    find article in the stock 
                        Console.WriteLine("Article to find stock:");
                        string _articleName1 = Console.ReadLine();
                        if (!CheckArticleExisiting(_articleName1))
                        {
                            Console.WriteLine("Article not found!");
                            return;
                        }
                        Console.WriteLine(FindArticlesells(_articleName1) + " has been sold!");
                        Console.ReadKey();
                        break;
                    case "8":
             //     find supplier name
                        Console.WriteLine("Supplier Name:");
                        string _supplierName = Console.ReadLine();
                        if (!CheckSupplierExisiting(_supplierName))
                        {
                            Console.WriteLine("Supplier not found!");
                            return;
                        }
           //     call method  FindSupplierInvoices
                        FindSupplierInvoices(_supplierName);
                        Console.ReadKey();
                        break;
                    case "9":
             //     call method  PrintArticles
                        PrintArticles();
                        Console.ReadKey();
                        goto start;
                        break;
                    case "10":
             //     call method PrintSuppliers
                        PrintSuppliers();
                        Console.ReadKey();
                        break;
                    case "11":
             //     call method PrintClients
                        PrintClients();
                        Console.ReadKey();
                        break;
                    case "12":
             //     call method PrintSupplingInvoices
                        PrintSupplingInvoices();
                        Console.ReadKey();
                        break;
                    case "13":
              //     call method PrintSellingInvoices
                        PrintSellingInvoices();
                        Console.ReadKey();
                        break; 
                    case "14":
              //    to exit
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Error");
                        Thread.Sleep(2000);
                        goto start;
                        break;
                }

            } while (choice != "14");
         //   end do.... while

        }
  //      end Main
  //  method to create or add articles
        public static void CreateArticles()
        {

            Console.WriteLine("Article Name:");
            string _articleName = Console.ReadLine();
            if (CheckArticleExisiting(_articleName))
            {
                Console.WriteLine("Article is already created!");
                Thread.Sleep(2000);
                return;
            }
            articleName[articleId] = _articleName;
            Console.WriteLine("Article Cost:");
            supplingCost[articleId] = float.Parse(Console.ReadLine());
            Console.WriteLine("Article Selling Price:");
            SellingPrice[articleId] = float.Parse(Console.ReadLine());
            articleId++;
            Console.WriteLine("Article Added successfully!");
           Thread.Sleep(2000);
        } //    end method CreateArticles
        //    method to check article exisiting
        public static bool CheckArticleExisiting(string articleToFind)
        {
            bool isExisit = false;
            for (int i = 0; i <= articleId; i++)
            {
                if (articleToFind == articleName[i])
                {
                    isExisit = true;
                    return isExisit;

                }
                else
                {
                    isExisit = false;

                }
            } 

            return isExisit;
        }//    End method CheckArticleExisiting
        public static float FindArticleCostPrice(string _articleName)
        {
            //find article index
            int index = Array.IndexOf(articleName, _articleName);
            //Article cost
            float cost = supplingCost[index];
            return cost;
        }
        public static float FindArticleSellingPrice(string _articleName)
        {
            //find article index
            int index = Array.IndexOf(articleName, _articleName);
            //Article cost
            float sellingPrice = SellingPrice[index];
            return sellingPrice;
        }  // end method FindArticleSellingPrice
        // method to looking for article int the stock
        public static float FindArticleStock(string _articleName)
        {

            float _articleStock = 0;
            for (int i = 0; i <= supplingInvoiceId; i++)
            {
                if (_articleName == supplingInvoice[i, 1])
                {
                    _articleStock = _articleStock + float.Parse(supplingInvoice[i, 3]);
                }


            }
            return _articleStock;
        } // End method FindArticleStock
        //    method to calculate seiiing quantity
        public static float FindArticlesells(string _articleName)
        {

            float _articleSells = 0;
            for (int i = 0; i <= sellingInvoiceId; i++)
            {
                if (_articleName == sellingInvoice[i, 1])
                {
                    _articleSells = _articleSells + float.Parse(sellingInvoice[i, 3]);
                }


            }
            return _articleSells;
        }  //  end method FindArticlesells
        //    output article name and article suppling cost
        public static void PrintArticles()
        {
            for (int i = 0; i < articleId; i++)
            {
                Console.WriteLine("Article Name: " + articleName[i] + " Article Suppling cost: " + FindArticleCostPrice(articleName[i]));
            }
        }  // end method PrintArticles 
        // method to creat or add supplier
        public static void CreateSupplier()
        {

            Console.WriteLine("Supplier Name:");
            string _supplierName = Console.ReadLine();
            if (CheckSupplierExisiting(_supplierName))
            {
                Console.WriteLine("Supplier is already created!");
                Thread.Sleep(2000);
                return;
            }
            supplierName[supplierId] = _supplierName;
            supplierId++;
            Console.WriteLine("Supplier Added successfully!");
            Thread.Sleep(2000);
        }  // end method CreateSupplier
        //    method to check supplier exisiting
        public static bool CheckSupplierExisiting(string supplierToFind)
        {
            bool isExisit = false;
            for (int i = 0; i <= supplierId; i++)
            {
                if (supplierToFind == supplierName[i])
                {
                    isExisit = true;
                    return isExisit;
                }
                else
                {
                    isExisit = false;
                }
            }

            return isExisit;
        }  // end method CheckSupplierExisiting
        // mrthod to output supplier invoices and calculate total invoices amount
        public static void FindSupplierInvoices(string _supplierName)
        {
            float totalInvoicesAmount = 0;
      //    to make table
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("|| ID || Article || Supplier || Quantity || Total Price || Date ||");
            Console.WriteLine("__________________________________________________________________");
            for (int i = 0; i < supplingInvoiceId; i++)
            {
                // Find Supplier name from the suppling invoices list
                if (_supplierName == supplingInvoice[i, 2])
                {
                    // print the invoices list of this supplier name
                    Console.Write("\n");
                    for (int J = 0; J < 6; J++)
                    {

                        Console.Write("|| {0}\t", supplingInvoice[i, J]);
                    }
                    totalInvoicesAmount = totalInvoicesAmount + int.Parse(supplingInvoice[i, 4]);
                    Console.Write("\n");
                }
            }
            Console.WriteLine("||________________________________________________________________||");
            Console.WriteLine("||              Total invoices amount: {0}                        ||", totalInvoicesAmount);
            Console.WriteLine("||________________________________________________________________||");
        }  // end method FindSupplierInvoices
  //    method to output list of supplier name
        public static void PrintSuppliers()
        {
            for (int i = 0; i < supplierId; i++)
            {
                Console.WriteLine("Supplier Name: " + supplierName[i]);
            }
        }  //   end method PrintSuppliers
           // method to creat or add client
        public static void CreateClient()
        {
            Console.WriteLine("Client Name:");
            string _clientName = Console.ReadLine();
            if (CheckClientExisiting(_clientName))
            {
                Console.WriteLine("Client is already created!");
                Thread.Sleep(2000);
                return;
            }
            clientName[clientId] = _clientName;
            clientId++;
            Console.WriteLine("Client Added successfully!");
            Thread.Sleep(2000);
        } // end method CreateClient
        //    method to check client exisiting
        public static bool CheckClientExisiting(string clientToFind)
        {
            bool isExisit = false;
            for (int i = 0; i <= clientId; i++)
            {
                if (clientToFind == clientName[i])
                {
                    isExisit = true;
                    return isExisit;
                }
                else
                {
                    isExisit = false;
                }
            }
            return isExisit;
        }  //  end method CheckClientExisiting
        //    method to print client name
        public static void PrintClients()
        {
            for (int i = 0; i < clientId; i++)
            {
                Console.WriteLine("Client Name: " + clientName[i]);
            }
        } // end method PrintClients
        // method to find article type and check article exisiting
        public static void CreateSupplingInvoice()
        {

            Console.WriteLine("Article type:");
            string _articleName = Console.ReadLine();
            if (!CheckArticleExisiting(_articleName))
            {
                Console.WriteLine("Article not found\nAdd article pls!");
                Thread.Sleep(2000);
                return;
            }
     //     find supplier name and check supplier exisiting
            Console.WriteLine("Supplier Name:");
            string _supplierName = Console.ReadLine();
            if (!CheckSupplierExisiting(_supplierName))
            {
                Console.WriteLine("Supplier not found\nAdd Supplier pls!");
                Thread.Sleep(2000);
                return;
            }
      //    find quantity
            Console.WriteLine("Quantity:");
            float _articleQuantity = float.Parse(Console.ReadLine());
      //    find total price
            float _totalPrice = _articleQuantity * FindArticleCostPrice(_articleName);
            Console.WriteLine("Total Price: " + _totalPrice);
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    supplingInvoice[supplingInvoiceId, i] = supplingInvoiceId.ToString();
                }
                if (i == 1)
                {
                    supplingInvoice[supplingInvoiceId, i] = _articleName.ToString();
                }
                if (i == 2)
                {
                    supplingInvoice[supplingInvoiceId, i] = _supplierName.ToString();
                }
                if (i == 3)
                {
                    supplingInvoice[supplingInvoiceId, i] = _articleQuantity.ToString();
                }
                if (i == 4)
                {
                    supplingInvoice[supplingInvoiceId, i] = _totalPrice.ToString();
                }
                if (i == 5)
                {
                    supplingInvoice[supplingInvoiceId, i] = DateTime.Now.ToString();
                }
            }
            Console.WriteLine("Invoice Added successfully!");
            Thread.Sleep(2000);
            supplingInvoiceId++;
        }  // end method CreateSupplingInvoice
        //    method to make table for print suppling invoices
        public static void PrintSupplingInvoices()
        {
       //    to make table
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("|| ID || Article || Supplier || Quantity || Total Price || Date ||");
            Console.WriteLine("__________________________________________________________________");

            for (int i = 0; i < supplingInvoiceId; i++)
            {
          //    print the invoice list of the  supplier name
                Console.Write("\n");
                for (int J = 0; J < 6; J++)
                {
                    Console.Write("|| {0}\t", supplingInvoice[i, J]);
                }
                Console.Write("\n\n");
            }

        }  //end method PrintSupplingInvoices
        // method to find article type and check article exisiting
        public static void CreateSellingInvoice()
        {

            Console.WriteLine("Article type:");
            string _articleName = Console.ReadLine();
            if (!CheckArticleExisiting(_articleName))
            {
                Console.WriteLine("Article not found\nAdd article pls!");
                Thread.Sleep(2000);
                return;
            }
            Console.WriteLine("client Name:");
            string _clientName = Console.ReadLine();
      //    check client exisiting 
            if (!CheckClientExisiting(_clientName))
            {
                Console.WriteLine("Client not found\nAdd Client pls!");
                Thread.Sleep(2000);
                return;
            }
      //    find quantity
            Console.WriteLine("Quantity:");
            float _articleQuantity = float.Parse(Console.ReadLine());
            // to calculate the sufficient quantity of the article in stock
            if (FindArticleStock(_articleName) < _articleQuantity)
            {
                Console.WriteLine("Sorry you don't have enaugh in stock!");
                Console.WriteLine("You have " + FindArticleStock(_articleName) + " " + _articleName + " in stock!");
                Console.ReadKey();
                return;
            }
      //    find total price
            float _totalPrice = _articleQuantity * FindArticleSellingPrice(_articleName);
            Console.WriteLine("Total Price: " + _totalPrice);
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    sellingInvoice[sellingInvoiceId, i] = sellingInvoiceId.ToString();
                }
                if (i == 1)
                {
                    sellingInvoice[sellingInvoiceId, i] = _articleName.ToString();
                }
                if (i == 2)
                {
                    sellingInvoice[sellingInvoiceId, i] = _clientName.ToString();
                }
                if (i == 3)
                {
                    sellingInvoice[sellingInvoiceId, i] = _articleQuantity.ToString();
                }
                if (i == 4)
                {
                    sellingInvoice[sellingInvoiceId, i] = _totalPrice.ToString();
                }
                if (i == 5)
                {
                    sellingInvoice[sellingInvoiceId, i] = DateTime.Now.ToString();
                }
            }
            Console.WriteLine("Selling invoice Added successfully!");
            Thread.Sleep(2000);
            sellingInvoiceId++;
        }  // end method CreateSellingInvoice
        // method to print PrintSellingInvoices
        public static void PrintSellingInvoices()
        {
      //    make table
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("|| ID || Article || Supplier || Quantity || Total Price || Date ||");
            Console.WriteLine("__________________________________________________________________");

            for (int i = 0; i < sellingInvoiceId; i++)
            {
                Console.Write("\n");
                for (int J = 0; J < 6; J++)
                {
                    Console.Write("|| {0}\t", sellingInvoice[i, J]);
                }
                Console.Write("\n\n");
            }

        }  // end method printSellingInvoices


    }  // end class


}