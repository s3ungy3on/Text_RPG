using System;
using System.Text;

namespace Text_RPG
{

    internal class Text_RPG
    {
        public static Character _player;

        static void Main()
        {
            //Items itemsData = new Items();
            DataSetting();
            GameStartMenu();
        }


        public static void GameStartMenu()
        {
            while (true)
            {
                Text.MainScene();

                int selectInput = int.Parse(Console.ReadLine());

                switch (selectInput)
                {
                    case 1:
                        _player.StatusDisplay();
                        break;
                    case 2:
                        Inventory.InventoryDisplay();
                        break;

                }
            }
        }

        static void DataSetting()
        {
            _player = new Character("승연", 1, "학생", 10, 5, 100, 1000);
            //Console.WriteLine("게임을 시작하기 전, 당신의 이름을 말해주세요.");
            //Console.Write(">> ");
            //string nameinput = Console.ReadLine();

            //if(nameinput != null)
            //{
            //    Console.WriteLine($"당신의 이름이 {nameinput}이(가) 맞나요?");
            //    Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //    Console.Write("1. ");
            //    Console.ResetColor();
            //    Console.WriteLine("맞다.");
            //    Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //    Console.Write("2. ");
            //    Console.ResetColor();
            //    Console.WriteLine("아니다.");
            //    Console.Write(">> ");

            //    while (true)
            //    {
            //        int seletinput = int.Parse(Console.ReadLine());

            //        if (seletinput == 1)
            //        {

            //        }
            //        else if (seletinput == 2)
            //        {

            //        }
            //    }

            //}
            //_player = new Character(nameinput, 1, "학생", 10, 5, 100, 1000);


        }
    }

    static class Text
    {
        public static void MainScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ResetColor();
            Console.WriteLine("상태 보기");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ResetColor();
            Console.WriteLine("인벤토리");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("3. ");
            Console.ResetColor();
            Console.WriteLine("랜덤 모험");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("4. ");
            Console.ResetColor();
            Console.WriteLine("마을 순찰하기");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("5. ");
            Console.ResetColor();
            Console.WriteLine("훈련하기");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("6. ");
            Console.ResetColor();
            Console.WriteLine("상점");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("7. ");
            Console.ResetColor();
            Console.WriteLine("던전입장");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("8. ");
            Console.ResetColor();
            Console.WriteLine("휴식하기");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("0. ");
            Console.ResetColor();
            Console.WriteLine("저장");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
        }

        public static void Equipped_E_Text(bool isEquipped)
        {
            if (isEquipped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
            }

        }
    }

    public class Character
    {
        public string Name { get; }
        public int Level { get; }
        public string Job { get; }
        public int Attack { get; }
        public int Defense { get; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        private int itemAttack = 0;
        private int itemDefense = 0;

        public Character(string name, int level, string job, int attack, int defese, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Attack = attack;
            Defense = defese;
            Hp = hp;
            Gold = gold;
        }

        private int CurrentAttack
        {
            get { return Attack + itemAttack; }
        }

        private int CurrentDefense
        {
            get { return Defense + itemDefense; }
        }

        private void StatsUpdate()
        {
            itemAttack = 0;
            itemDefense = 0;

            if (Items._items == null)
            {
                return;
            }

            foreach (var item in Items._items)
            {
                if (item != null && item.IsEquipped)
                {
                    if (item.Type == ItemType.Wepon)
                    {
                        itemAttack += item.Attack;
                    }
                    else if (item.Type == ItemType.Armor)
                    {
                        itemDefense += item.Defense;
                    }

                }

            }
        }

        public void StatusDisplay()
        {
            StatsUpdate();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상태 보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표기됩니다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LV. ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{Level}");
            Console.ResetColor();
            Console.WriteLine($"{Name} ( {Job} )");
            Console.Write("공격력 : ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{CurrentAttack}" + " " + (itemAttack > 0 ? $"(+{itemAttack})" : " "));
            Console.ResetColor();
            Console.Write("방어력 : ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{CurrentDefense}" + " " + (itemDefense > 0 ? $"(+{itemDefense})" : " "));
            Console.ResetColor();
            Console.Write("체 력 : ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{Hp}");
            Console.ResetColor();
            Console.Write("Gold : ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{Gold} ");
            Console.ResetColor();
            Console.WriteLine("G");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("0. ");
            Console.ResetColor();
            Console.WriteLine("나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int selectInput))
                {
                    if (selectInput == 0)
                    {
                        Text_RPG.GameStartMenu();
                    }
                }

                Console.WriteLine("잘못된 입력입니다.");
                Console.Write(">> ");
            }
        }
    }


    public enum ItemType // 아이템 타입 enum형
    {
        Wepon = 0,
        Armor = 1
    }

    public class Items
    {
        public string Name { get; } //아이템 이름
        public string Desc { get; } //아이템 설명
        public ItemType Type { get; } // 0 = 무기 / 1 = 방어구
        public int Attack { get; } // 아이템 공격력
        public int Defense { get; } // 아이템 방어력
        public int Gold { get; set; } // 아이템 가격
        public bool IsEquipped { get; set; } // 아이템 장착 유무
        public static int ItemCount = 0; //아이템 개수 추적
        public static Items[] _items; // 아이템 배열 변수 선언



        public Items(string name, string desc, ItemType type, int attack, int defense, int gold, bool isEquipped = false)
        {
            Name = name;
            Desc = desc;
            Type = type;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            IsEquipped = isEquipped;
        }

        static Items()
        {
            _items = new Items[6];

            //이름, 설명, 아이템 타입, 공격력, 방어력, 골드
            _items[0] = new Items("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", ItemType.Armor, 0, 5, 1000);
            _items[1] = new Items("무쇠 갑옷", "무쇠로 만들어진 튼튼한 갑옷입니다.", ItemType.Armor, 0, 9, 1800);
            _items[2] = new Items("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", ItemType.Armor, 0, 15, 3500);
            _items[3] = new Items("낡은 검  ", "쉽게 볼 수 있는 낡은 검 입니다.", ItemType.Wepon, 2, 0, 600);
            _items[4] = new Items("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", ItemType.Wepon, 5, 0, 1500);
            _items[5] = new Items("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", ItemType.Wepon, 7, 0, 2700);

            ItemCount = _items.Length;
        }
        //객체를 생성해서 넣고 초기화 / 전투하게되면 스테이트 머신(전략 패턴)

    }

    public class Inventory
    {
        public static void InventoryDisplay()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Items._items.Length; i++)
            {
                Items item = Items._items[i];

                string statsType = (item.Type == ItemType.Armor) ? "방어력" : "공격력";
                int statValue = (item.Type == ItemType.Armor) ? item.Defense : item.Attack;
                Console.Write($"- ");
                Text.Equipped_E_Text(item.IsEquipped);
                Console.WriteLine($"{item.Name.PadRight(10, ' ')}\t| {statsType} +{statValue}\t| {item.Desc}");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ResetColor();
            Console.WriteLine("장착 관리");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("0. ");
            Console.ResetColor();
            Console.WriteLine("나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            while (true)
            {
                int selectInput = int.Parse(Console.ReadLine());

                if (selectInput == 0)
                {
                    Text_RPG.GameStartMenu();
                }
                else if (selectInput == 1)
                {
                    ItemEquipped();
                }


                Console.WriteLine("잘못된 입력입니다.");
                Console.Write(">> ");
            }
        }

        public static void ItemEquipped()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Items._items.Length; i++)
            {
                Items item = Items._items[i];

                string statsType = (item.Type == ItemType.Armor) ? "방어력" : "공격력";
                int statValue = (item.Type == ItemType.Armor) ? item.Defense : item.Attack;
                Console.Write($"- ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{i + 1} ");
                Console.ResetColor();
                Text.Equipped_E_Text(item.IsEquipped);
                Console.WriteLine($"{item.Name.PadRight(10, ' ')}\t| {statsType} +{statValue}\t| {item.Desc}");
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            while (true)
            {
                int selectInput = int.Parse(Console.ReadLine());

                if (selectInput == 0)
                {
                    InventoryDisplay();
                }
                else if (selectInput >= 1 && selectInput <= Items.ItemCount)
                {
                    int itemIndex = selectInput - 1;

                    Items._items[itemIndex].IsEquipped = !Items._items[itemIndex].IsEquipped;
                    ItemEquipped();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.Write(">> ");
                }
            }
        }
    }
}
