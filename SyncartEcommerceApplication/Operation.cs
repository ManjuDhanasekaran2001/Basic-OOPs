using System;
using System.Collections.Generic;

namespace EcommerceApplication
{
    
    public static  class Operation
    {
        //static Global Variable
       static CustomerDetails CurrentCustomer;
        //Static List
        static List<CustomerDetails>  customerList = new List<CustomerDetails>();
        static List<ProductDetails> productlist =new List<ProductDetails>();
        static List<OrderDetails> orderList = new List<OrderDetails>();

        //MAin menu
        public static void MainMenu()
        {
            Console.WriteLine("********Welcome to SynCart E - Commerce Application*********");
            

            string mainChoice ="yes";
           do
           {
            //Need to show main menu option
            Console.WriteLine("MainMenu\n1. Customer Registration\n2. Customer Login\n3. Exit");
            // Need to get input from user and validate.
            Console.Write("Select an Option : ");
            
            int mainOption;
                bool tempMainOption = int.TryParse(Console.ReadLine(),out mainOption);
                while(!tempMainOption || mainOption>4 ||mainOption<1)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    tempMainOption = int.TryParse(Console.ReadLine(),out mainOption);
                }
            //Need to create mainmenu structure
            switch(mainOption){
                case 1:
                {
                    Console.WriteLine("**********Customer Registration**************");
                    CustomerRegistration();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("**************Customer Login**********");
                    CustomerLogin();
                    break;
                }
                
                case 3:
                {
                    Console.WriteLine("Application Exited Successfully");
                    mainChoice="no";
                    break;
                }

            }
            //Need to iterate untill the option is exit.

           }while(mainChoice=="yes");
        }//Main Menu ends
        // Registration starts
        public static void CustomerRegistration()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter yor city : ");
            string city = Console.ReadLine();
            Console.Write("Enter Your  phone Number");
            long phoneNo ;
            bool tempPhone = long.TryParse(Console.ReadLine(), out phoneNo);
            while(!tempPhone)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Phone Number.");
                tempPhone = long.TryParse(Console.ReadLine(), out phoneNo);
            }
            Console.Write("Enter your Balance : ");
            double balance ;
            bool tempbalnace = double.TryParse(Console.ReadLine(), out balance);
            while(!tempbalnace)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid input.");
                tempbalnace = double.TryParse(Console.ReadLine(), out balance );
            }
            Console.Write("Enter Your mail ID : ");
            string mail = Console.ReadLine();

            CustomerDetails customer1 = new CustomerDetails(name,city,phoneNo,balance,mail);
            customerList.Add(customer1);

            Console.WriteLine("Your Registration is Successful and your Customer ID id : "+customer1.CustomerID);

             
        }//Registration ends

        //login start
        public static void CustomerLogin()

        {
            //need to get id input
            Console.Write("Enter your CustomerID : ");
            string loginID = Console.ReadLine().ToUpper();
            //validate by its presence in the list.
            bool flag = true;
            foreach(CustomerDetails customer in customerList)
            {
                if(loginID.Equals(customer.CustomerID))
                {
                    flag=false;
                    //assigning current user to global variable
                    CurrentCustomer = customer;
                    Console.WriteLine("Logged In successfully.");
                    //Need to call SubMenu
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID is not present");
            }
            //If not - Invalid  valid
        }// login ends
        
        public static void SubMenu()
        {
            string subChoice ="yes";
            do
            {
                Console.WriteLine("*********SubMenu*******");
                //Need to show submenu options
                Console.WriteLine("Select an Option\n1. Purchase\n2. Order History\n3. Cancel Order\n4. Wallet Balnce\n5. Wallet Recharge\n6. Exit");
                //Getting User option
                Console.Write("Enter your Option : ");
                
                int subOption;
                bool tempSubOption = int.TryParse(Console.ReadLine(),out subOption);
                while(!tempSubOption || subOption>6 ||subOption<1)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    tempSubOption = int.TryParse(Console.ReadLine(),out subOption);
                }
                //Need to create submenu structure
                switch(subOption){
                    case 1:{
                        Console.WriteLine("*********Purchase*********");
                        Purchase();
                        break;
                    }
                    case 2:{
                        Console.WriteLine("*********Order History*********");
                        OrderHistory();
                        break;
                    }
                    case 3:{
                        Console.WriteLine("*********Cancel Order*********");
                        CancelOrder();
                        break;
                    }
                    case 4:{
                        Console.WriteLine("*********Wallet Balnce********");
                        Walletbalance();
                        break;
                    }
                    case 5:{
                        Console.WriteLine("*********Wallet Recharge*********");
                        WalletRecharge();
                        break;
                    }
                    case 6:{
                        Console.WriteLine("Taking back to MainMenu");
                        subChoice="no";
                        break;
                    }
                }
                //Iterate till the option is exit

            }while(subChoice=="yes");

        }//SubMenu ends
        //Purchase
        public static void Purchase(){

            foreach(ProductDetails product in productlist){
                Console.WriteLine($"|{product.ProductID}|{product.ProductName}|{product.Stock}|{product.Price}|{product.ShippingDuriation}|");
            }

            Console.Write("Enter The Product ID : ");
            string customerproductID = Console.ReadLine().ToUpper();
            bool flag= true;
            foreach(ProductDetails product in productlist){

            if(customerproductID.Equals(product.ProductID))
            {
                flag = false;
                Console.Write("Enter the count of the Product to purchase: ");
                int customercount;
                bool tempcount = int.TryParse(Console.ReadLine(), out customercount);
            while(!tempcount)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Input.");
                tempcount = int.TryParse(Console.ReadLine(), out customercount);
            }
                if(customercount<=product.Stock && customercount>0)
                {
                    double totalAmount = customercount*product.Price+50;
                    Console.WriteLine("The total Price Is : "+totalAmount);
                    if(totalAmount<=CurrentCustomer.Balance)
                    {
                        CurrentCustomer.DeductBalance(totalAmount);
                        product.Stock--;

                        OrderDetails order = new OrderDetails(CurrentCustomer.CustomerID,customerproductID,totalAmount,DateTime.Now,customercount,OrderStatus.Ordered);
                        Console.WriteLine("Your order placed Successfully . Your Order Id is :"+order.OrderID);
                        Console.WriteLine($"Your order will be delivered on {order.PurchasedDate.AddDays(product.ShippingDuriation).ToString("dd/MM/yyyy")}");
                    
                    }
                    else
                    {
                       Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                    }
                }
                else
                {
                    Console.WriteLine($"Required count not available. Current availability is {product.Stock}");
                }
            }
            }
            if(flag){
                Console.WriteLine("Invalid ProductID");
            }
            
        }// purchase end
        public static void OrderHistory(){
            if(orderList.Count>0){
                bool flag = true;
                Console.WriteLine("Order ID|Customer ID |Product ID |TotalPrice|PurchasedDate| Quantity Purchase| OrderStatus");
                foreach(OrderDetails order in orderList)
                {
                    if(CurrentCustomer.CustomerID.Equals(order.CustomerID))
                    {
                        flag = false;
                        Console.WriteLine($"|{order.OrderID}|{order.CustomerID}|{order.ProductID}|{order.TotalPrice}|{order.PurchasedDate.ToString("dd/MM/yyyy")}|{order.QuantityPurchased}|{order.OrderStatus}|");
                    }
                }
                if(flag){
                    Console.WriteLine("Ther is No order History");
                }

            }
            else{
                Console.WriteLine("Ther is No order History");
            }

        }// order ends
        public static void CancelOrder(){
            bool flag = true;
             Console.WriteLine("Order ID|Customer ID | product ID |TotalPrice|PurchasedDate| Quantity Purchase| OrderStatus");
            foreach(OrderDetails order in orderList){
                
                if(CurrentCustomer.CustomerID.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered)){
                    flag = false;
                    Console.WriteLine($"|{order.OrderID}|{order.CustomerID}|{order.ProductID}|{order.TotalPrice}|{order.ProductID}|{order.QuantityPurchased}|{order.OrderStatus}|");
                    Console.Write("Choose The Order ID to Cancell the product : ");
                    string customerOrderId = Console.ReadLine().ToUpper();
                    
                    if(customerOrderId.Equals(order.OrderID))
                    {
                        order.OrderStatus=OrderStatus.Cancelled;
                        CurrentCustomer.Balance+=order.TotalPrice;
                        foreach(ProductDetails product in productlist)
                        {
                            if(order.ProductID.Equals(product.ProductID)){
                                product.Stock+=order.QuantityPurchased;
                            }
                        }

                        Console.WriteLine($"{customerOrderId}  cancelled successfully");
                        
                    }
                    else{
                        Console.WriteLine("Invalid OrderID");
                    }
                    
                
                }
            }
            if(flag){
                Console.WriteLine("There is no Order to cancel");
            }

        }//Cancel order ends
        public static void Walletbalance(){

            Console.WriteLine("Your Current Balnace IS : "+CurrentCustomer.Balance);

        }// balance ends 
        public static void WalletRecharge(){

            Console.Write("You Want to Recharge (yes/no) : ");
            string option = Console.ReadLine().ToLower();
            if(option=="yes"){
                Console.Write("Enter the Amount to  Recharge : ");
                double rechargeAmount;
                bool tempbalnace = double.TryParse(Console.ReadLine(), out rechargeAmount);
            while(!tempbalnace)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid input.");
                tempbalnace = double.TryParse(Console.ReadLine(), out rechargeAmount );
            }
                CurrentCustomer.WalletRecharge(rechargeAmount);
            }

        }//recharge Ends 
        
        //Adding Default values
        public static void AddDefault()
        {
           
           ProductDetails product1 = new ProductDetails("Mobile (Samsung)",10,10000,3);
           ProductDetails  product2 = new ProductDetails("Tablet (Lenovo)",5,15000,2);
           ProductDetails  product3 = new ProductDetails("Camara (Sony)",3,20000,4);
           ProductDetails  product4 = new ProductDetails("iPhone",5,50000,6);
           ProductDetails  product5 = new ProductDetails("Laptop (Lenovo I3)",3,40000,3);
           ProductDetails  product6 = new ProductDetails("HeadPhone (Boat)"	,5,	1000,2);
           ProductDetails  product7 = new ProductDetails("Speakers (Boat)",	4,500,2);
           
           productlist.Add(product1);
           productlist.Add(product2);
           productlist.Add(product3);
           productlist.Add(product4);
           productlist.Add(product5);
           productlist.Add(product6);
           productlist.Add(product7);


           OrderDetails order1 = new OrderDetails("CID1001"	,"PID101",20000	,DateTime.Now,2,OrderStatus.Ordered);
           OrderDetails order2 = new OrderDetails("CID1002","PID103",40000	,DateTime.Now,2,OrderStatus.Ordered);

            orderList.Add(order1);
            orderList.Add(order2);
        
        CustomerDetails customer1 = new CustomerDetails("Ravi","Chennai",9885858588,50000,"ravi@mail.com");
         CustomerDetails customer2 = new CustomerDetails("Baskaran","Chennai",9888475757,60000,"baskaran@mail.com");


         customerList.Add(customer1);
         customerList.Add(customer2);







        }
        
    }
}
