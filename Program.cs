using ClassLibraryLaba10;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laba12_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<Plants> table = new MyHashTable<Plants>(10, 0.72);
            int answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("------ РАБОТА С ХЕШ-ТАБЛИЦЕЙ ------");
                Console.WriteLine("1. Создание хеш-таблицы");
                Console.WriteLine("2. Печать хеш-таблицы");
                Console.WriteLine("3. Добавление элементов в хеш-таблицу ");
                Console.WriteLine("4. Удаление элементов с заданным ключом");
                Console.WriteLine("5. Поиск элемента в хеш-таблице");
                Console.WriteLine("6. Выход");
                Console.WriteLine();
                answer = InputAnswer();
                Console.WriteLine();
                switch (answer)
                {
                    case 1:
                        table = Сreating();
                        break;
                    case 2: table.Print(); break;
                    case 3:
                        Add(table);
                        break;
                    case 4:
                        Remove(table);
                        break;
                    case 5:
                        Search(table);
                        break;
                    case 6: break;
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (answer != 6);
        }

        static int InputAnswer()
        {
            int answer;
            bool Ok;
            do
            {
                string buf = Console.ReadLine();
                Ok = int.TryParse(buf, out answer);
                if (!Ok)
                {
                    Console.WriteLine("Неправильно выбран пункт меню. Повторите ввод");
                }
            } while (!Ok);
            return answer;
        }
        static MyHashTable<Plants> Сreating()
        {
            MyHashTable<Plants> table = new MyHashTable<Plants>(5, 0.72);

            Plants p1 = new Plants();
            p1.RandomInit();
            Flowers p2 = new Flowers();
            p2.RandomInit();
            Trees p3 = new Trees();
            p3.RandomInit();
            Rose p4 = new Rose();
            p4.RandomInit();
            Plants p5 = new Plants();
            p5.RandomInit();

            // Добавление элементов
            table.AddItem(p1);
            table.AddItem(p2);
            table.AddItem(p3);
            table.AddItem(p4);
            table.AddItem(p5);

            Console.WriteLine("Таблица создана");
            return table;
        }
        static MyHashTable<Plants> Add (MyHashTable<Plants> table)
        {
            int ans;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите какой элемент вы хотите добавить:");
                ans = Menu();
                Console.WriteLine();
                switch (ans)
                {
                    case 1:
                            Plants plants = new Plants();
                            plants.Init();
                            if (table.Contains(plants))
                            {
                                Console.WriteLine("Элемент с таким значением уже присутствует в таблице");
                            }
                            else
                            {
                                table.AddItem(plants);
                                Console.WriteLine("Растение добавлено");
                            }
                            break;
                    case 2:
                        table.AddItem(CreateTree());
                        Console.WriteLine("Дерево добавлено");
                        break;
                    case 3:
                        table.AddItem(CreateFlower());
                        Console.WriteLine("Цветок добавлен");
                        break;
                    case 4:
                        table.AddItem(CreateRose());
                        Console.WriteLine("Роза добавлена");
                        break;
                    case 5: break;
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (ans != 5);
            return table;
        }
        static MyHashTable<Plants> Remove(MyHashTable<Plants> table)
        {
            if (table.Count == 0)
            {
                Console.WriteLine("Таблица пуста. Необходимо добавить элементы перед продолжением.");
                return table;
            }
            int ans;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите какой элемент вы хотите удалить:");
                ans = Menu();
                Console.WriteLine();
                switch (ans)
                {
                    case 1:
                        RemoveElement(table, CreatePlant());
                        break;
                    case 2:
                        RemoveElement(table, CreateTree());
                        break;
                    case 3:
                        RemoveElement(table, CreateFlower());
                        break;
                    case 4:
                        RemoveElement(table, CreateRose());
                        break;
                    case 5: break;
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (ans != 5);
            return table;
        }
        static MyHashTable<Plants> Search(MyHashTable<Plants> table)
        {
            if (table.Count == 0)
            {
                Console.WriteLine("Таблица пуста. Необходимо добавить элементы перед продолжением.");
                return table;
            }
            int ans;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите какой элемент вы хотите найти:");
                ans = Menu();
                Console.WriteLine();
                switch (ans)
                {
                    case 1:
                        SearchElement(table, CreatePlant());
                        break;
                    case 2:
                        SearchElement(table, CreateTree());
                        break;
                    case 3:
                        SearchElement(table, CreateFlower());
                        break;
                    case 4:
                        SearchElement(table, CreateRose());
                        break;
                    case 5: break;
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (ans != 5);
            return table;
        }
        static Plants CreatePlant()
        {
            Plants plant = new Plants();
            plant.RandomInit();
            return plant;
        }

        static Trees CreateTree()
        {
            Trees tree = new Trees();
            tree.RandomInit();
            return tree;
        }

        static Flowers CreateFlower()
        {
            Flowers flower = new Flowers();
            flower.RandomInit();
            return flower;
        }

        static Rose CreateRose()
        {
            Rose rose = new Rose();
            rose.RandomInit();
            return rose;
        }
        static bool RemoveElement<T>(MyHashTable<Plants> table, T element) where T : Plants
        {
            element.Init();
            bool removed = table.RemoveData(element);
            if (removed)
            {
                Console.WriteLine("Элемент удален");
            }
            else
            {
                Console.WriteLine("Элемента нет в таблице");
            }
            return removed;
        }

        static bool SearchElement<T>(MyHashTable<Plants> table, T element) where T : Plants
        {
            element.Init();
            bool found = table.Contains(element);
            if (found)
            {
                Console.WriteLine("Элемент найден");
            }
            else
            {
                Console.WriteLine("Элемента нет в таблице");
            }
            return found;
        }
        static int Menu()
        {
            Console.WriteLine("1. Растение (базовый класс)");
            Console.WriteLine("2. Дерево (производный класс)");
            Console.WriteLine("3. Цветок (производный класс)");
            Console.WriteLine("4. Роза (производный класс)");
            Console.WriteLine("5. Назад");
            Console.WriteLine();
            return InputAnswer();
        }
    }
}
