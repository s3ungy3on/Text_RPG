//using System;

//namespace Text_RPG
//{
//    internal class Program
//    {
//        static void Main()
//        {
//            Character player = new Character("승연", 1, "학생", 10, 5, 100, 1000);
//            GameStart(player);
//        }

//        static void GameStart(Character player)
//        {
//            do
//            {
//                Console.Clear();
//                /*Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n\n1. 상태 보기\n2. 인벤토리\n\n원하시는 행동을 입력해주세요.");*/
//                Console.Write(">> ");
//                string input = Console.ReadLine();

//                if (input == "1")
//                {
//                    player.PlayerDisplayInfo();
//                }
//                else if (input == "2")
//                {
//                    Inventory.DisplayInventory();
//                }
//                else
//                {
//                    continue;
//                }
//            }
//            while (true);
//        }
//    }

//    public class Character
//    {
//        public string Name { get; }
//        public int Level { get; }
//        public string Job { get; }
//        public int Attack { get; }
//        public int Defense { get; }
//        public int Hp { get; set; }
//        public int Gold { get; set; }

//        private int plusAttack = 0;
//        private int plusDefense = 0;

//        public Character(string name, int level, string job, int attack, int defese, int hp, int gold)
//        {
//            Name = name;
//            Job = job;
//            Level = level;
//            Attack = attack;
//            Defense = defese;
//            Hp = hp;
//            Gold = gold;
//        }

//        public int CurrentAttack
//        {
//            get
//            { return Attack + plusAttack; }
//        }

//        public int CurrentDefense
//        {
//            get { return Defense + plusDefense; }
//        }

//        public void UpdateStats()
//        {
//            plusAttack = 0;
//            plusDefense = 0;

//            for (int i = 0; i < Item.itemNames.Length; i++)
//            {
//                if (Item.isEquipped[i])
//                {
//                    if (Item.itemType[i] == "무기")
//                    {
//                        plusAttack += Item.itemstats[i];
//                    }
//                    else if (Item.itemType[i] == "방어구")
//                    {
//                        plusDefense += Item.itemstats[i];
//                    }

//                }

//            }
//        }

//        public void PlayerDisplayInfo()
//        {
//            UpdateStats();

//            Console.Clear();
//            Console.Clear();
//            Console.ForegroundColor = ConsoleColor.DarkYellow;
//            Console.WriteLine("상태 보기");
//            Console.ResetColor();
//            Console.WriteLine($"캐릭터의 정보가 표시됩니다.\n\nLv. {Level} \n{Name}({Job})");
//            Console.WriteLine($"공격력 : {CurrentAttack}" + " " + (plusAttack > 0 ? $"(+{plusAttack})" : ""));
//            Console.WriteLine($"방어력 : {CurrentDefense}" + " " + (plusDefense > 0 ? $"(+{plusDefense})" : ""));
//            Console.WriteLine($"체 력 : {Hp}");
//            Console.WriteLine($"Gold : {Gold}G");
//            Console.WriteLine();
//            Console.WriteLine("0. 나가기");
//            Console.WriteLine();
//            Console.WriteLine("원하시는 행동을 입력해주세요.");
//            Console.Write(">> ");

//            if (Console.ReadLine() == "0")
//            {
//                return;
//            }
//            else
//            {
//                PlayerDisplayInfo();
//            }

//        }
//    }

//    class Item()
//    {
//        public static string[] itemNames =
//        {
//            "무쇠 갑옷",
//            "낡은 검",
//            "연습용 창",
//        };
//        public static string[] itemType =
//        {
//            "방어구",
//            "무기",
//            "무기",
//        };
//        public static int[] itemstats =
//        {
//            5,
//            2,
//            3,
//        };
//        public static string[] itemDesc =
//        {
//            "무쇠로 만들어져 튼튼한 갑옷입니다.",
//            "쉽게 볼 수 있는 낡은 검 입니다.",
//            "검보다는 그대로 창이 다루기 쉽죠.",
//        };

//        public static bool[] isEquipped =
//        {
//            false,
//            false,
//            false,
//        };
//    }

//    class Inventory()
//    {
//        public static void DisplayInventory()
//        {
//            while (true)
//            {
//                Console.Clear();
//                Console.ForegroundColor = ConsoleColor.DarkYellow;
//                Console.WriteLine("인벤토리");
//                Console.ResetColor();
//                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
//                Console.WriteLine();
//                Console.WriteLine("[아이템 목록]");

//                for (int i = 0; i < Item.itemNames.Length; i++)
//                {
//                    string equipCheck = Item.isEquipped[i] ? "[E]" : "";
//                    string statsType = (Item.itemType[i] == "방어구") ? "방어력" : "공격력";
//                    Console.Write($"- ");
//                    Console.WriteLine($"{equipCheck}{Item.itemNames[i]} \t| {statsType} +{Item.itemstats[i]} | {Item.itemDesc[i]}");
//                }

//                Console.WriteLine();
//                Console.WriteLine("1. 장착 관리");
//                Console.WriteLine("0. 나가기");
//                Console.WriteLine();
//                Console.WriteLine("원하시는 행동을 입력해주세요.");
//                Console.Write(">> ");
//                string input = Console.ReadLine();

//                if (input == "0")
//                {
//                    return;
//                }
//                else if (input == "1")
//                {
//                    ItemEquipMenu();
//                }
//            }
//        }

//        public static void ItemEquipMenu()
//        {
//            while (true)
//            {
//                Console.Clear();
//                Console.ForegroundColor = ConsoleColor.DarkYellow;
//                Console.WriteLine("인벤토리 - 장착 관리");
//                Console.ResetColor();
//                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
//                Console.WriteLine();
//                Console.WriteLine("[아이템 목록]");

//                for (int i = 0; i < Item.itemNames.Length; i++)
//                {
//                    string equipCheck = Item.isEquipped[i] ? "[E]" : "";
//                    string statsType = (Item.itemType[i] == "방어구") ? "방어력" : "공격력";
//                    Console.Write($"- ");
//                    Console.WriteLine($"{i + 1} {equipCheck}{Item.itemNames[i]} \t| {statsType} +{Item.itemstats[i]} | {Item.itemDesc[i]}");
//                }

//                Console.WriteLine();
//                Console.WriteLine("0. 나가기");
//                Console.WriteLine();
//                Console.WriteLine("원하시는 행동을 입력해주세요.");
//                Console.Write(">> ");

//                int input = int.Parse(Console.ReadLine());

//                if (input == 0)
//                {
//                    return;
//                }
//                else if (input >= 1 && input <= Item.itemNames.Length)
//                {
//                    int itemIndex = input - 1;

//                    Item.isEquipped[itemIndex] = !Item.isEquipped[itemIndex];
//                }
//                else
//                {
//                    Console.WriteLine("잘못된 입력입니다.");
//                }
//            }
//        }
//    }
//}
