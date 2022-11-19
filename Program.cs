using pr12._11._2022;
using System.Text.Json;
using System.IO;

Stock stock = new();

stock.med.Add(new Medications { Name = "one", Quantity = 1, Price = 224.50, Recipe = true });
stock.med.Add(new Medications { Name = "forst", Quantity = 3, Price = 100.50, Recipe = false });
stock.med.Add(new Medications { Name = "three", Quantity = 6, Price = 4.50, Recipe = false });
stock.med.Add(new Medications { Name = "four", Quantity = 7, Price = 88.50, Recipe = true });
stock.med.Add(new Medications { Name = "five", Quantity = 3, Price = 11.50, Recipe = true });
stock.med.Add(new Medications { Name = "six", Quantity = 4, Price = 5.50, Recipe = false });


stock.SaveJson();
stock.AddMed("ssd", 1, 100.50, false);
stock.AddMed("e", 1, 100.50, false);
Console.WriteLine("Создались новые");
stock.PrintMed();
stock.ReserveJson();
Console.WriteLine("После востановления:");
stock.PrintMed();

























//stock.SortPrice();

//stock.SortQuantity();


//stock.PrintMed();

//stock.AddMed("kk", 1, 100.50, false); 

//stock.TakeMed("one");
//stock.NoRecipe1();



//stock.SaveJson();
//stock.AddMed("wk", 1, 100.50, true);
