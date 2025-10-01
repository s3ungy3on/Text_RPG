using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Text_RPG
{

    internal class Text_RPG
    {
        static void Main()
        {
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
                        Character._player.StatusDisplay();
                        break;
                    case 2:
                        Inventory.InventoryDisplay();
                        break;
                    case 3:
                        Adventure.RandomAdventure();
                        break;
                    case 4:
                        Adventure.TownPatrol();
                        break;
                    case 5:
                        Adventure.Training();
                        break;
                    case 6:
                        Store.StoreDisplay();
                        break;
                    case 7:
                        Dungeon.DungeonDisplay();
                        break;
                    case 8:
                        Adventure.Relax();
                        break;
                    case 9:
                        break;

                }
            }
        }

        static void DataSetting()
        {
            Character._player = new Character("승연", 1, "학생", 10, 5, 100, 1000);
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

    public class Text
    {
        public static void MainScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            TextNumberHlight("1");
            Console.WriteLine(". 상태 보기");
            TextNumberHlight("2");
            Console.WriteLine(". 인벤토리");
            TextNumberHlight("3");
            Console.WriteLine(". 랜덤 모험");
            TextNumberHlight("4");
            Console.WriteLine(". 마을 순찰하기");
            TextNumberHlight("5");
            Console.WriteLine(". 훈련하기");
            TextNumberHlight("6");
            Console.WriteLine(". 상점");
            TextNumberHlight("7");
            Console.WriteLine(". 던전입장");
            TextNumberHlight("8");
            Console.WriteLine(". 휴식하기\n");
            TextNumberHlight("0");
            Console.WriteLine(". 저장\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
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

        public static void TextTitleHlight(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void TextNumberHlight(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(text);
            Console.ResetColor();
        }

        public static string PaddingKorean_Right(string str, int width)
        {
            int curWidth = 0;

            foreach (char c in str)
            {
                curWidth += c <= 127 ? 1 : 2;
            }

            int padding = width - curWidth;

            return str + new string(' ', Math.Max(0, padding));
        }

        public static void ThredSleep()
        {
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(500);
        }
    }

    public class Character
    {
        public static Character _player;
        public string Name { get; }
        public int Level { get; }
        public string Job { get; }
        public int Attack { get; }
        public int Defense { get; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public int Exp { get; set; }
        public int Stamina {  get; set; }

        private int itemAttack = 0;
        private int itemDefense = 0;

        public Character(string name, int level, string job, int attack, int defese, int hp, int gold, int exp = 0, int stamina = 20)
        {
            Name = name;
            Job = job;
            Level = level;
            Attack = attack;
            Defense = defese;
            Hp = hp;
            Gold = gold;
            Exp = exp;
            Stamina = stamina;
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

        private void StatsPlus(int value)
        {
            if(value > 0)
            {
                Console.Write(" (+");
                Text.TextNumberHlight($"{value}");
                Console.Write(")\n");
            }
            else
            {
                Console.Write(" \n");
            }
        }

        public void StatusDisplay()
        {
            StatsUpdate();
            Console.Clear();
            Text.TextTitleHlight("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표기됩니다.\n");
            //레벨
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LV. ");
            Console.ResetColor();
            Text.TextNumberHlight(Level.ToString());
            //경험치
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tExp");
            Console.ResetColor();
            Console.WriteLine($" {Exp}");
            //이름, 직업
            Console.WriteLine($"{Name} ( {Job} )");
            //공격력 (+아이템 추가 공격력)
            Console.Write("공격력 : ");
            Text.TextNumberHlight($"{CurrentAttack}");
            StatsPlus(itemAttack);
            //방어력 (+아이템 추가 방어력)
            Console.Write("방어력 : ");
            Text.TextNumberHlight($"{CurrentDefense}");
            StatsPlus(itemDefense);
            //체력
            Console.Write("체 력 : ");
            Text.TextNumberHlight($"{Hp}\n");
            //스태미나
            Console.Write("스태미나 : ");
            Text.TextNumberHlight($"{Stamina}\n");
            //골드
            Console.Write("Gold : ");
            Text.TextNumberHlight($"{Gold} ");
            Console.WriteLine("G");
            Console.WriteLine();

            Text.TextNumberHlight("0");
            Console.Write(". 나가기\n\n원하시는 행동을 입력해주세요.\n>> ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int selectInput))
                {
                    if (selectInput == 0)
                    {
                        Text_RPG.GameStartMenu();
                    }
                }

                Console.Write("잘못된 입력입니다.\n>> ");
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
        public bool IsPurchased { get; set; } // 아이템 구매 유무
        public static int ItemCount = 0; //아이템 개수 추적
        public static Items[] _items; // 아이템 배열 변수 선언



        public Items(string name, string desc, ItemType type, int attack, int defense, int gold, bool isEquipped = false, bool isPurchased = false)
        {
            Name = name;
            Desc = desc;
            Type = type;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            IsEquipped = isEquipped;
            IsPurchased = isPurchased;
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

    }

    public class Inventory
    {
        public static void InventoryDisplay()
        {
            Console.Clear();
            Text.TextTitleHlight("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");

            for (int i = 0; i < Items._items.Length; i++)
            {
                Items item = Items._items[i];
                string statsType;
                int statsValue;

                if (item.Type == ItemType.Armor)
                {
                    statsType = "방어력";
                    statsValue = item.Defense;
                }
                else
                {
                    statsType = "공격력";
                    statsValue = item.Attack;
                }

                Console.Write($"- ");
                Text.Equipped_E_Text(item.IsEquipped);
                Console.WriteLine($"{item.Name.PadRight(10, ' ')}\t| {statsType} +{statsValue}\t| {item.Desc}");
            }

            Console.WriteLine();
            Text.TextNumberHlight("1");
            Console.WriteLine(". 장착 관리");
            Text.TextNumberHlight("2");
            Console.WriteLine(". 아이템 정렬");
            Text.TextNumberHlight("0");
            Console.Write(". 나가기\n\n원하시는 행동을 입력해주세요.\n>> ");

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
                else if (selectInput == 2)
                {
                    ItemArray();
                }
                else
                {
                    Console.Write("잘못된 입력입니다.\n>> ");
                }
            }
        }

        public static void ItemEquipped()
        {
            Console.Clear();
            Text.TextTitleHlight("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");

            for (int i = 0; i < Items._items.Length; i++)
            {
                Items item = Items._items[i];
                string statsType;
                int statsValue;

                if (item.Type == ItemType.Armor)
                {
                    statsType = "방어력";
                    statsValue = item.Defense;
                }
                else
                {
                    statsType = "공격력";
                    statsValue = item.Attack;
                }

                Console.Write($"- ");
                Text.TextNumberHlight($"{i + 1} ");
                Text.Equipped_E_Text(item.IsEquipped);
                Console.WriteLine($"{item.Name.PadRight(10, ' ')}\t| {statsType} +{statsValue}\t| {item.Desc}");
            }

            Console.WriteLine();
            Text.TextNumberHlight("0");
            Console.Write(". 나가기\n\n원하시는 행동을 입력해주세요.\n>> ");

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
                    Console.Write("잘못된 입력입니다.\n>> ");
                }
            }
        }

        public static void ItemArray() // 배열 이름 길이로 정렬
        {
            Items._items = (from item in Items._items
                            orderby item.Name.Length
                            select item).ToArray();

            InventoryDisplay();
        }
    }

    public class Store
    {
        public static void StoreDisplay()
        {
            Console.Clear();
            Text.TextTitleHlight("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
            Text.TextNumberHlight($"{Character._player.Gold}");
            Console.WriteLine(" G\n\n[아이템 목록]");

            for (int i = 0; i < Items._items.Length; i++)
            {
                Items item = Items._items[i];
                string statsType;
                int statsValue;

                if (item.Type == ItemType.Armor)
                {
                    statsType = "방어력";
                    statsValue = item.Defense;
                }
                else
                {
                    statsType = "공격력";
                    statsValue = item.Attack;
                }
                Console.Write($"- ");
                Text.Equipped_E_Text(item.IsEquipped);
                Console.WriteLine($"{item.Name.PadRight(10, ' ')}\t| {statsType} +{statsValue}\t| {item.Desc}");
            }

            Console.WriteLine();
            Text.TextNumberHlight("1");
            Console.WriteLine(". 아이템 구매");
            Text.TextNumberHlight("2");
            Console.WriteLine(". 아이템 판매");
            Text.TextNumberHlight("0");
            Console.Write(". 나가기\n\n원하시는 행동을 입력해주세요.\n>> ");

            while (true)
            {
                int selectInput = int.Parse(Console.ReadLine());

                if (selectInput == 0)
                {
                    Text_RPG.GameStartMenu();
                }
                else if (selectInput == 1)
                {
                    StoreBuy();
                }
                else if (selectInput == 2)
                {
                    StoreSell();
                }
                else
                {
                    Console.Write("잘못된 입력입니다.\n>> ");
                }
            }
        }

        private static void StoreBuy() // 아이템 구매
        {
            Console.Clear();
            Text.TextTitleHlight("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
            Text.TextNumberHlight($"{Character._player.Gold}");
            Console.WriteLine(" G\n\n[아이템 목록]");

            for (int i = 0; i < Items._items.Length; i++)
            {
                Items item = Items._items[i];
                string statsType;
                int statsValue;

                if (item.Type == ItemType.Armor)
                {
                    statsType = "방어력";
                    statsValue = item.Defense;
                }
                else
                {
                    statsType = "공격력";
                    statsValue = item.Attack;
                }

                Console.Write($"- ");
                Text.TextNumberHlight($"{i + 1} ");
                Text.Equipped_E_Text(item.IsEquipped);
                Console.WriteLine($"{item.Name.PadRight(10, ' ')}\t| {statsType} +{statsValue}\t| {item.Desc}");
            }

            Console.WriteLine();
            Text.TextNumberHlight("0");
            Console.Write(". 나가기\n\n원하시는 행동을 입력해주세요.\n>> ");

            while (true)
            {
                int selectInput = int.Parse(Console.ReadLine());

                if (selectInput == 0)
                {
                    StoreDisplay();
                }
                else if (selectInput >= 1 && selectInput <= Items.ItemCount)
                {
                    int itemIndex = selectInput - 1;
                    //아이템 구매
                    break;
                }
                else
                {
                    Console.Write("잘못된 입력입니다.\n>> ");
                }

            }
        }

        private static void StoreSell() // 아이템 판매
        {
            Console.Clear();
            Text.TextTitleHlight("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
            Text.TextNumberHlight($"{Character._player.Gold}");
            Console.WriteLine(" G\n\n[아이템 목록]");

            for (int i = 0; i < Items._items.Length; i++) //보유중인 아이템만 표시하도록 변경 필요
            {
                Items item = Items._items[i];
                string statsType;
                int statsValue;

                if (item.Type == ItemType.Armor)
                {
                    statsType = "방어력";
                    statsValue = item.Defense;
                }
                else
                {
                    statsType = "공격력";
                    statsValue = item.Attack;
                }

                Console.Write($"- ");
                Text.TextNumberHlight($"{i + 1} ");
                Text.Equipped_E_Text(item.IsEquipped);
                Console.WriteLine($"{item.Name.PadRight(10, ' ')}\t| {statsType} +{statsValue}\t| {item.Desc}");
            }

            Console.WriteLine();
            Text.TextNumberHlight("0");
            Console.Write(". 나가기\n\n원하시는 행동을 입력해주세요.\n>> ");

            while (true)
            {
                int selectInput = int.Parse(Console.ReadLine());

                if (selectInput == 0)
                {
                    StoreDisplay();
                }
                else if (selectInput >= 1 && selectInput <= Items.ItemCount)
                {
                    int itemIndex = selectInput - 1;
                    //아이템 판매
                    break;
                }
                else
                {
                    Console.Write("잘못된 입력입니다.\n>> ");
                }
            }
        }
    }

    public class Adventure
    {
        public static void RandomAdventure() //랜덤 모험 화면
        {
            Console.Clear();
            Console.WriteLine("랜덤 모험을 진행하시겠습니까?\n스태미나 10이 소비됩니다.\n");
            Text.TextNumberHlight("1");
            Console.WriteLine(". 진행한다");
            Text.TextNumberHlight("0");
            Console.WriteLine(". 돌아간다\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int seletInput = int.Parse(Console.ReadLine());

            while (true)
            {
                if (seletInput == 0)
                {
                    Text_RPG.GameStartMenu();
                }
                else if (seletInput == 1)
                {
                    RandomAdventurePlay();
                }
                else
                {
                    Console.Write("잘못된 입력입니다.\n>> ");
                }
            }


        }

        private static void RandomAdventurePlay() //랜덤 모험 진행
        {
            Random rand = new Random();
            int randnum = rand.Next(1, 101);

            if (Character._player.Stamina >= 10)
            {
                if(randnum >= 50)
                {
                    Text.ThredSleep();
                    Console.WriteLine("몬스터 조우! 골드 500 획득");
                    Character._player.Gold += 500;
                    Character._player.Stamina -= 10;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
                else if(randnum <= 51)
                {
                    Text.ThredSleep();
                    Console.WriteLine("아무 일도 일어나지 않았다.");
                    Character._player.Stamina -= 10;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }

            }
            else if (Character._player.Stamina < 10)
            {
                Console.WriteLine();
                Console.WriteLine("스태미나가 부족합니다.");
                Thread.Sleep(1000);
                Text_RPG.GameStartMenu();
            }
        }

        public static void TownPatrol() //마을 순찰 화면
        {
            Console.Clear();
            Console.WriteLine("마을 순찰을 진행하시겠습니까?\n스태미나 5가 소비됩니다.\n");
            Text.TextNumberHlight("1");
            Console.WriteLine(". 진행한다");
            Text.TextNumberHlight("0");
            Console.WriteLine(". 돌아간다\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int seletInput = int.Parse(Console.ReadLine());

            while (true)
            {
                if (seletInput == 0)
                {
                    Text_RPG.GameStartMenu();
                }
                else if (seletInput == 1)
                {
                    TownPatrolPlay();
                }
                else
                {
                    Console.Write("잘못된 입력입니다.\n>> ");
                }
            }
        }

        private static void TownPatrolPlay() //마을 순찰 진행
        {
            Random rand = new Random();
            int randnum = rand.Next(1, 101);

            if (Character._player.Stamina >= 5)
            {
                if (randnum <= 10)
                {
                    Text.ThredSleep();
                    Console.WriteLine("마을 아이들이 모여있다. 간식을 사줘볼까?\n500G 를 소비하였습니다.");
                    Character._player.Gold -= 500;
                    Character._player.Stamina -= 5;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
                else if (randnum <= 20)
                {
                    Text.ThredSleep();
                    Console.WriteLine("촌장님을 만나서 심부름을 했다.\n2000G 를 획득하였습니다.");
                    Character._player.Gold += 2000;
                    Character._player.Stamina -= 5;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
                else if (randnum <= 40)
                {
                    Text.ThredSleep();
                    Console.WriteLine("길 잃은 사람을 안내해주었다.\n1000G 를 획득하였습니다.");
                    Character._player.Gold += 1000;
                    Character._player.Stamina -= 5;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
                else if (randnum <= 70)
                {
                    Text.ThredSleep();
                    Console.WriteLine("마을 주민과 인사를 나눴다. 선물을 받았다.\n500G 를 획득하였습니다.");
                    Character._player.Gold += 500;
                    Character._player.Stamina -= 5;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
                else if (randnum <= 100)
                {
                    Text.ThredSleep();
                    Console.WriteLine("아무 일도 일어나지 않았다.");
                    Character._player.Stamina -= 5;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
            }
            else if (Character._player.Stamina < 5)
            {
                Console.WriteLine();
                Console.WriteLine("스태미나가 부족합니다.");
                Thread.Sleep(1000);
                Text_RPG.GameStartMenu();
            }
        }

        public static void Training() //훈련 화면
        {
            Console.Clear();
            Console.WriteLine("훈련을 진행하시겠습니까? \n스태미나 15가 소비됩니다.");
            Console.WriteLine();
            Text.TextNumberHlight("1");
            Console.WriteLine(". 진행한다");
            Text.TextNumberHlight("0");
            Console.WriteLine(". 돌아간다\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int seletInput = int.Parse(Console.ReadLine());

            while (true)
            {
                if (seletInput == 0)
                {
                    Text_RPG.GameStartMenu();
                }
                else if (seletInput == 1)
                {
                    TrainingPlay();
                }
                else
                {
                    Console.Write("잘못된 입력입니다.\n>> ");
                }
            }
        }

        private static void TrainingPlay() //훈련 진행
        {
            Random rand = new Random();
            int randnum = rand.Next(1, 101);

            if (Character._player.Stamina >= 15)
            {
                if (randnum <= 15)
                {
                    Text.ThredSleep();
                    Console.WriteLine("훈련이 잘 되었습니다!\n경험치 60을 획득하였습니다.");
                    Character._player.Stamina -= 15;
                    Character._player.Exp += 60;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
                else if(randnum <= 75)
                {
                    Text.ThredSleep();
                    Console.WriteLine("오늘하루 열심히 훈련했습니다.\n경험치 40을 획득하였습니다.");
                    Character._player.Stamina -= 15;
                    Character._player.Exp += 40;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
                else if(randnum <= 100)
                {
                    Text.ThredSleep();
                    Console.WriteLine("하기 싫다... 훈련이...\n경험치 30을 획득하였습니다.");
                    Character._player.Stamina -= 15;
                    Character._player.Exp += 30;
                    Thread.Sleep(1000);
                    Text_RPG.GameStartMenu();
                }
            }
            else if (Character._player.Stamina < 5)
            {
                Console.WriteLine();
                Console.WriteLine("스태미나가 부족합니다.");
                Thread.Sleep(1000);
                Text_RPG.GameStartMenu();
            }
        }

        public static void Relax() //휴식하기 화면
        {
            Console.Clear();
            Text.TextTitleHlight("휴식하기");
            Text.TextNumberHlight("500");
            Console.Write($" G를 내면 체력을 회복할 수 있습니다. (보유 골드 : ");
            Text.TextNumberHlight($"{Character._player.Gold}");
            Console.WriteLine(" G)\n");
            Text.TextNumberHlight("1");
            Console.WriteLine(". 휴식하기");
            Text.TextNumberHlight("0");
            Console.WriteLine(". 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            int seletInput = int.Parse(Console.ReadLine());

            while (true)
            {
                if (seletInput == 0)
                {
                    Text_RPG.GameStartMenu();
                }
                else if (seletInput == 1)
                {
                    RelaxPlay();
                }
                else
                {
                    Console.Write("잘못된 입력입니다.\n>> ");
                }
            }
        }

        private static void RelaxPlay() //휴식하기 진행
        {
            if(Character._player.Gold >= 500)
            {
                Text.ThredSleep();
                Console.WriteLine("휴식을 완료했습니다.\n체력과 스태미나가 최대치로 회복되었습니다.");
                Character._player.Stamina = 20; //고치기
                Character._player.Hp = 100; //고치기
                Character._player.Gold -= 500;
                Thread.Sleep(1000);
                Text_RPG.GameStartMenu();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Gold 가 부족합니다.");
                Thread.Sleep(1000);
                Text_RPG.GameStartMenu();
            }
        }
    }

    public class Dungeon
    {
        public static void DungeonDisplay() //던전 입장 화면
        {
            Console.Clear();
            Text.TextTitleHlight("던전 입장");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            // 1. 쉬운 던전
            Text.TextNumberHlight("1");
            Console.Write(". 쉬운 던전 \t| 방어력");
            Text.TextNumberHlight(" 5 ");
            Console.WriteLine("이상 권장");
            // 2. 일반 던전
            Text.TextNumberHlight("2");
            Console.Write(". 일반 던전 \t| 방어력");
            Text.TextNumberHlight(" 11 ");
            Console.WriteLine("이상 권장");
            // 3. 어려운 던전
            Text.TextNumberHlight("3");
            Console.Write(". 어려운 던전 \t| 방어력");
            Text.TextNumberHlight(" 17 ");
            Console.WriteLine("이상 권장");
            // 나가기
            Text.TextNumberHlight("0");
            Console.Write(". 나가기\n\n원하시는 행동을 입력해주세요.\n>> ");

            int seletInput = int.Parse(Console.ReadLine());

            if (seletInput == 0)
            {
                Text_RPG.GameStartMenu();
            }
            else if (seletInput == 1)
            {
                return;
            }
            else if (seletInput == 2)
            {
                return;
            }
            else if (seletInput == 3)
            {
                return;
            }
            else
            {
                Console.Write("잘못된 입력입니다.\n>> ");
            }
        }
    }  
}