using System;
using System.Collections.Generic;

namespace manageBillRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ObjectFactory objectFactory = new ObjectFactory();
            Dictionary<string, object> data = new Dictionary<string, object>();

            int id;
            IObject obj;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("1.  Find Food");
                Console.WriteLine("2.  Find Drink");
                Console.WriteLine("3.  Find Staff Info");
                Console.WriteLine("4.  Create and save Food");
                Console.WriteLine("5.  Create and save Drink");
                Console.WriteLine("6.  Create and save Staff Info");
                Console.WriteLine("7.  Create and save Bill");
                Console.WriteLine("8.  Find Bill");
                Console.WriteLine("9.  Delete Bill");
                Console.WriteLine("10. Update Food");
                Console.WriteLine("11. Update Drink");
                Console.WriteLine("12. Update Staff");
                Console.WriteLine();
                Console.Write("Select option: ");

                double p;
                string n; 
                int option;
                if (Int32.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1://Find Food
                            Console.Write("Enter Food ID: ");
                            if(!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            obj = objectFactory.Get(ObjectType.Food, id);

                            if(obj != null)
                            {
                                Console.WriteLine(obj.GetInfo());
                            }else
                            {
                                Console.WriteLine("Data Not Found!");
                            }

                            break;

                        case 2://Find Drink

                            Console.Write("Enter Drink ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            obj = objectFactory.Get(ObjectType.Drink, id);

                            if (obj != null)
                            {
                                Console.WriteLine(obj.GetInfo());
                            }
                            else
                            {
                                Console.WriteLine("Data Not Found!");
                            }

                            break;

                        case 3://Find Staff

                            Console.Write("Enter Staff ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            obj = objectFactory.Get(ObjectType.Staff, id);

                            if (obj != null)
                            {
                                Console.WriteLine(obj.GetInfo());
                            }
                            else
                            {
                                Console.WriteLine("Data Not Found!");
                            }

                            break;

                        case 4://Create and save Food

                            Console.Write("Enter Food ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            Console.Write("Enter Food Name: ");
                            n = Console.ReadLine();
                            Console.Write("Enter Food Price: ");
                            if (!Double.TryParse(Console.ReadLine(), out p)) Console.WriteLine("Price is Not Valid!");
                            objectFactory.Add(ObjectType.Food, new Food() { id = id, foodName = n, foodPrice = p });

                            break;

                        case 5://Create and save Drink

                            Console.Write("Enter Drink ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            Console.Write("Enter Drink Name: ");
                            n = Console.ReadLine();
                            Console.Write("Enter Drink Price: ");
                            if (!Double.TryParse(Console.ReadLine(), out p)) Console.WriteLine("Price is Not Valid!");
                            objectFactory.Add(ObjectType.Drink, new Drink() { id = id, drinkName = n, drinkPrice = p });

                            break;

                        case 6://Create and save Staff

                            Console.Write("Enter Staff ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            Console.Write("Enter Staff Name: ");
                            n = Console.ReadLine();
                            Console.Write("Enter Staff Position: ");
                            string pos = Console.ReadLine();

                            objectFactory.Add(ObjectType.Staff, new Staff() { id = id,staffName = n, staffPosition = pos });

                            break;

                        case 7://Create Bill

                            DateTime aDateTime = DateTime.Now;
                            Console.WriteLine("Issue Date: " + aDateTime);

                            double totalFood = 0;
                            double totalDrink = 0;
                            double totalAmount;

                            Console.Write("Enter Staff ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            obj = objectFactory.Get(ObjectType.Staff, id);
                            Console.WriteLine(obj.GetInfo());

                            while (true)
                            {
                                Console.Write("Enter Food ID: ");
                                string s = Console.ReadLine();
                                if (s == "end") break;
                                if (!Int32.TryParse(s, out id)) Console.WriteLine("ID is Not Valid!");
                                Food f1 = (Food) objectFactory.Get(ObjectType.Food, id);
                                Console.WriteLine(f1.GetInfo());
                                totalFood += f1.foodPrice;   
                            }

                            while (true)
                            {
                                Console.Write("Enter Drink ID: ");
                                string s = Console.ReadLine();
                                if (s == "end") break;
                                if (!Int32.TryParse(s, out id)) Console.WriteLine("ID is Not Valid!");
                                Drink f1 = (Drink)objectFactory.Get(ObjectType.Drink, id);
                                Console.WriteLine(f1.GetInfo());
                                totalDrink += f1.drinkPrice;
                            }

                            Console.Write("Enter VAT: ");
                            double d;
                            Double.TryParse(Console.ReadLine(), out d);
                            totalAmount = (totalDrink + totalFood) * d;

                            Console.Write("Enter Bill ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");

                            objectFactory.Add(ObjectType.Bill, new Bill() { id = id, totalFood = totalFood, totalDrink = totalDrink, totalAmount = totalAmount });

                            Console.WriteLine("VAT: {0:P}", d);
                            Console.WriteLine("Total Food {0:C}: ", totalFood);
                            Console.WriteLine("Total Drink: {0:C}", totalDrink);
                            Console.WriteLine("Total Amount: {0:C}", totalAmount);
                            break;

                        case 8://Find Bill

                            Console.Write("Enter Bill ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            obj = objectFactory.Get(ObjectType.Bill, id);

                            if (obj != null)
                            {
                                Console.WriteLine(obj.GetInfo());
                            }
                            else
                            {
                                Console.WriteLine("Data Not Found!");
                            }

                            break;

                        case 9://Delete Bill

                            Console.Write("Enter Bill ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            Console.Write("Deleted this Bill");
                            objectFactory.Remove(ObjectType.Bill, id);

                            break;

                        case 10://Update Food

                            Console.Write("Enter Old Food ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");

                            Food f = (Food) objectFactory.Get(ObjectType.Food, id);

                            Console.Write("Enter New Food ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            Console.Write("Enter New Food Name: ");
                            n = Console.ReadLine();
                            Console.Write("Enter New Food Price: ");
                            if (!Double.TryParse(Console.ReadLine(), out p)) Console.WriteLine("Price is Not Valid!");

                            f.Update(id, n, p); 

                            break;

                        case 11://Update Drink

                            Console.Write("Enter Old Drink ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");

                            Drink dri = (Drink)objectFactory.Get(ObjectType.Drink, id);

                            Console.Write("Enter New Drink ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            Console.Write("Enter New Drink Name: ");
                            n = Console.ReadLine();
                            Console.Write("Enter New Drink Price: ");
                            if (!Double.TryParse(Console.ReadLine(), out p)) Console.WriteLine("Price is Not Valid!");

                            dri.Update(id, n, p);

                            break;

                        case 12://Update Staff

                            Console.Write("Enter Old Staff ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");

                            Staff sf = (Staff)objectFactory.Get(ObjectType.Staff, id);

                            Console.Write("Enter New Staff ID: ");
                            if (!Int32.TryParse(Console.ReadLine(), out id)) Console.WriteLine("ID is Not Valid!");
                            Console.Write("Enter New Staff Name: ");
                            n = Console.ReadLine();
                            Console.Write("Enter New Staff Position: ");
                            string posi = Console.ReadLine();

                            sf.Update(id, n, posi);

                            break;

                        default:
                            break;
                    }

                    Console.ReadLine();
                }

                else Console.WriteLine("Invalid Selection!");

            }
        }
    }

    #region Object

    public abstract class IObject
    {
        public int id;

        public abstract string GetInfo();
       
        public int GetID()
        {
            return this.id;
        }
    }

    class Food : IObject
    {
        public string foodName;
        public double foodPrice;

        public override string GetInfo()
        {
            return string.Format("foodID {0}. foodName {1}. foodPrice {2}.", id, foodName, foodPrice);
        }
        public void Update(int id, string foodName, double foodPrice)
        {
            this.id = id;
            this.foodName = foodName;
            this.foodPrice = foodPrice;
        }
    }

    class Drink : IObject
    {
        public string drinkName;
        public double drinkPrice;

        public override string GetInfo()
        {
            return string.Format("drinkID {0}. drinkName {1}. drinkPrice {2}.", id, drinkName, drinkPrice);
        }

        public void Update(int id, string drinkName, double drinkPrice)
        {
            this.id = id;
            this.drinkName = drinkName;
            this.drinkPrice = drinkPrice;
        }
    }

    class Staff : IObject
    {
        public string staffName;
        public string staffPosition;

        public override string GetInfo()
        {
            return string.Format("staffID {0}. staffName {1}. staffPosition {2}.", id, staffName, staffPosition);
        }

        public void Update(int id, string staffName, string staffPosition)
        {
            this.id = id;
            this.staffName = staffName;
            this.staffPosition = staffPosition;
        }
    }

    class Bill : IObject
    {
        public double totalFood;
        public double totalDrink;
        public double totalAmount;

        public override string GetInfo()
        {
            return string.Format("totalFood {0}. totalDrink {1}. totalAmount {2}.", totalFood, totalDrink, totalAmount); ;
        }
    }

    enum ObjectType
    {
        Food,
        Drink,
        Staff,
        Bill
    }

    #endregion Object

    #region Object Factory

    class ObjectFactory
    {
        ObjectType _type;
        int _id;
        Dictionary<ObjectType, List<IObject>> data = new Dictionary<ObjectType, List<IObject>>();

        public ObjectFactory() {

            List<IObject> foodList = new List<IObject>();

            foodList.Add(new Food() { id = 101, foodName = "Fish", foodPrice = 23.56 });
            foodList.Add(new Food() { id = 102, foodName = "Chicken", foodPrice = 55.23 });
            foodList.Add(new Food() { id = 103, foodName = "Craf", foodPrice = 56.22 });

            List<IObject> drinkList = new List<IObject>();

            drinkList.Add(new Drink() { id = 201, drinkName = "Mango", drinkPrice = 5.3 });
            drinkList.Add(new Drink() { id = 202, drinkName = "Melon", drinkPrice = 8.3 });
            drinkList.Add(new Drink() { id = 203, drinkName = "Orange", drinkPrice = 5.7 });

            List<IObject> staffList = new List<IObject>();

            staffList.Add(new Staff() { id = 301, staffName = "Lisa", staffPosition = "Cashier" });

            List<IObject> billList = new List<IObject>();

            data[ObjectType.Food] = foodList;
            data[ObjectType.Drink] = drinkList;
            data[ObjectType.Staff] = staffList;
            data[ObjectType.Bill] = billList;

        }

        public IObject Get(ObjectType type, int id)
        {
            _type = type;
            _id = id;

            return GetObject();
        }

        public void Add(ObjectType type, IObject obj)
        {
            data[type].Add(obj);
        }

        public void Remove(ObjectType type, int id)
        {
            IObject obj = Get(type, id);

            if(obj != null) data[type].Remove(obj);
        }

        public IObject GetObject()
        {
            IObject obj = null;

            foreach (IObject item in data[_type])
            {
                if (item.id == _id)
                {
                    obj = item;
                    break;
                }
            }

            return obj;

        }
    }

    #endregion Object Factory
}
