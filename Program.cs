using pr12._11._2022;
using System.Text.Json;
using System.IO;

Stock stock = new();

stock.med.Add(new Medications { Name = "one", Quantity = 1, Price = 44.50, Recipe = true });
stock.med.Add(new Medications { Name = "kt", Quantity = 3, Price = 100.50, Recipe = false });
stock.med.Add(new Medications { Name = "kk", Quantity = 3, Price = 4.50, Recipe = false });

stock.PrintMed();

stock.AddMed("kk", 1, 100.50, false); 

stock.TakeMed("one");
stock.NoRecipe1();

stock.SortPrice();

stock.SortQuantity();

stock.SaveJson();
stock.AddMed("wk", 1, 100.50, true);
stock.ReserveJson();