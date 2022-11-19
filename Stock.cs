using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace pr12._11._2022
{
    public class Stock
    {


        public List<Medications> med = new List<Medications>();
        public void AddMed(Medications meds)
        {
            med.Add(meds);
        }
      

        public void AddMed(string name, int quantity, double price, bool recipe) //1. Добавление нового лекарства на склад
        {
            int e = 0;
            for (int i = 0; i < med.Count; i++)
            {
                if (med[i].Name == name)
                {
                    // Если при добавлении такое лекарство уже есть на складе(имя), то просто этому лекарству к количество делаем + 1.
                    med[i].Quantity++;

                    e++;
                }

            }
            if(e==0)
            {
                     med.Add(// В ином случае создаем новую запись.
                 new Medications(name, quantity, price, recipe)
                    );
            }

        }

        public void TakeMed(string name)
        {
            //2. Забрать со склада одну единицу лекарства по названию.
            int f = 0;
            for (int i = 0; i < med.Count; i++)
            {


                if (med[i].Name == name && med[i].Quantity != 0)
                {

                    med[i].Quantity--;
                    f++;
                    if (med[i].Quantity == 0) //Если после забирания осталось 0, то запись удалить.
                    {
                        Console.WriteLine("Лекарство кончилось");
                        med.RemoveAt(i);
                        f++;
                        break;
                    }
                }


            }
            if (f == 0)
            {
                Console.WriteLine("Лекарства нет");
            }
            PrintMed();
        }


        public void PrintMed()
        {
          
            foreach (Medications meds in med)
            {
                Console.WriteLine($"{meds.Name}, {meds.Quantity}, {meds.Price}, {meds.Recipe}");
            }
            Console.WriteLine("------------------");
        }


        public void SortPrice() //3. Получить все лекарства, отсортированные по цене.
        {
           
            int len = med.Count;

            for (var i = 1; i < len; i++)
            {
                for (int j = 0; j < len - i; j++)
                {

                    med.Sort((l1, l2) => med[j + 1].Price < med[j].Price ? -1 : med[j + 1].Price > med[j].Price ? 1 : 0);

                }
            }

            Console.WriteLine("По цене:"); PrintMed();
           
        }

        public void SortQuantity() //4. Получить все лекарства, отсортированные по количеству. 
        {
            Console.WriteLine("По количеству:"); PrintMed();
            int len = med.Count;

            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {


                    med.Sort((l1, l2) => med[j + 1].Quantity < med[j].Quantity ? -1 : med[j + 1].Quantity > med[j].Quantity ? 1 : 0);

                }
            }
            PrintMed();
        }

        public void NoRecipe1() //5. Получить все лекарства, которые отпускаются без рецепта.
        {
            Console.WriteLine("Без рецепта:");
            foreach (Medications m in med)
            {

                if (m.Recipe == false)
                {
                    Console.WriteLine(m);
                }


            }
            Console.WriteLine("------------------");
        }

        public void SaveJson() //6. Сохранить все лекарства в виде JSON в файл warehouse.json
        {
            StreamWriter sw = new StreamWriter("Medications_Stock.json");
            string json = JsonSerializer.Serialize(med);
            sw.WriteLine(json);
            Console.WriteLine(json);

            sw.Close();
            Console.WriteLine("Сохранено в Medications_Stock.json:");
            PrintMed();
        }

        public void ReserveJson() //7. Загрузить все лекарства в массив/лист из файла warehouse.json
        {

            using StreamReader sr = new StreamReader("Medications_Stock.json");
            string jsonr = sr.ReadToEnd();
            List<Medications>? med = JsonSerializer.Deserialize<List<Medications>>(jsonr);
            Console.WriteLine( "Добавить с резерва:"); 
            PrintMed();
        }

    }
}

