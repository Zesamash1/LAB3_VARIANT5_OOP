using System;
public class Subscription
{
    //Приватні змінні з завдання, назва сервісу, щомісячна плата та актвність підписки
    private string serviceName;
    private double monthlyFee;
    private bool isActive;
    //Публічні властивості читання та запис
    public string ServiceName
    {
        get { return serviceName; }
        set { serviceName = value; }
    }

    public double MonthlyFee
    {
        get { return monthlyFee; }
        set { monthlyFee = value; }
    }

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
    //Конструктор за замовчуванням, що встановлює базові значення
    public Subscription()
    {
        serviceName = "Unknown Service";
        monthlyFee = 0.0;
        isActive = false;
    }
    //Конструктор з параметрами для ініціалізації всіх полів
    public Subscription(string serviceName, double monthlyFee, bool isActive)
    {
        this.serviceName = serviceName;
        this.monthlyFee = monthlyFee;
        this.isActive = isActive;
    }
    //Метод для активації підписки
    public void ActivateSubscription()
    {
        if (isActive)
        {
            Console.WriteLine($"Неможливо активувати підписку {serviceName} оскільки вона вже активована!");
        }
        else
        {
            isActive = true;
            Console.WriteLine($"Підписка на {serviceName} активована.");
        }
    }
    //Метод для відміни підписки
    public void CancelSubscription()
    {
        if (!isActive)
        {
            Console.WriteLine($"Неможливо деактивувати підписку на {serviceName} оскільки вона не активована!");
        }
        else
        {
            isActive = false;
            Console.WriteLine($"Підписка на {serviceName} скасована.");
        }
    }
    //Метод для розрахунку річної вартості підписки
    public double CalculateYearlyFee()
    {
        return monthlyFee * 12;
    }
    //Перевизначенння методу ToString  для виведення інформації про підписку
    public override string ToString()
    {
        return $"Сервіс: {serviceName}, Щомісячна плата: {monthlyFee}, Активність: {isActive}";
    }
}
//Клас музичної підписки, що успадковує клас "підписка" та додає кількість плейлістів та видаляє їх
public class MusicSubscription : Subscription
{
    private int playlistsCount;
    public int PlaylistsCount
    {
        get { return playlistsCount; }
        set { playlistsCount = value; }
    }
    public MusicSubscription(string serviceName, double monthlyFee, bool isActive, int playlistsCount)
        : base(serviceName, monthlyFee, isActive)
    {
        this.playlistsCount = playlistsCount;
    }
    public void CreatePlaylist()
    {
        playlistsCount++;
        Console.WriteLine($"Новий плейлист створено. Всього плейлистів: {playlistsCount}.");
    }
    public void RemovePlaylist()
    {
        if (playlistsCount > 0)
        {
            playlistsCount--;
            Console.WriteLine($"Плейлист видалено. Всього плейлистів: {playlistsCount}.");
        }
        else
        {
            Console.WriteLine("Немає плейлистів для видалення.");
        }
    }
}
//Клас відео підписки, що успадковує клас "підписка" та регулює якість відео
public class VideoSubscription : Subscription
{
    private string availableQuality;
    public string AvailableQuality
    {
        get { return availableQuality; }
        set { availableQuality = value; }
    }
    public VideoSubscription(string serviceName, double monthlyFee, bool isActive, string availableQuality)
        : base(serviceName, monthlyFee, isActive)
    {
        this.availableQuality = availableQuality;
    }
    //Зміна якості користувачем
    public void ChangeVideoQuality(string quality)
    {
        availableQuality = quality;
        Console.WriteLine($"Якість відео змінено на {availableQuality}.");
    }
    //Зміна автоматична
    public void SetAutomaticQuality()
    {
        Random rand = new Random();
        int internetSpeed = rand.Next(1, 101); 

        if (internetSpeed < 20)
        {
            availableQuality = "720p";
        }
        else if (internetSpeed < 50)
        {
            availableQuality = "720p";
        }
        else if (internetSpeed < 80)
        {
            availableQuality = "1080p";
        }
        else
        {
            availableQuality = "4K";
        }

        Console.WriteLine($"Автоматично обрано якість відео: {availableQuality} (швидкість інтернету: {internetSpeed} Мбіт/с).");
    }
    public override string ToString()
    {
        return base.ToString() + $", Якість відео: {availableQuality}";
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //Створення об'єктів для музичної та відео підписки
        MusicSubscription spotifySubscription = new MusicSubscription("Spotify Premium", 4.99, false, 0);
        VideoSubscription youtubeSubscription = new VideoSubscription("YouTube Premium", 13.99, false, "не встановлено");
        //Головне меню
        Console.ForegroundColor = ConsoleColor.White;
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n -Music- Онлайн-сервіс -Video-");
            Console.WriteLine("1. Spotify ");
            Console.WriteLine("2. YouTube ");
            Console.WriteLine("0. Вихід");

            Console.Write("Оберіть сервіс: ");
            //Виклик методів для музичного та відео сервісу
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Spotify(spotifySubscription);
                    break;
                case "2":
                    YouTube(youtubeSubscription);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
    //Меню музичного сервісу з обробкою дій
    public static void Spotify(MusicSubscription spotifySubscription)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Green;
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n=Music= ♬ Spotify ♬ =Music=");
            Console.WriteLine("1. Статус підписки");
            Console.WriteLine("2. Активувати підписку");
            Console.WriteLine("3. Деактивувати підписку");
            Console.WriteLine("4. Додати новий плейлист");
            Console.WriteLine("5. Видалити плейлист");
            Console.WriteLine("6. Розрахувати річну вартість");
            Console.WriteLine("0. Повернутися до головного меню");

            Console.Write("Оберіть дію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(spotifySubscription.ToString());
                    break;
                case "2":
                    spotifySubscription.ActivateSubscription();
                    break;
                case "3":
                    spotifySubscription.CancelSubscription();
                    break;
                case "4":
                    spotifySubscription.CreatePlaylist();
                    break;
                case "5":
                    spotifySubscription.RemovePlaylist();
                    break;
                case "6":
                    Console.WriteLine($"Річна вартість: {spotifySubscription.CalculateYearlyFee()} долларів");
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
    //Меню відео сервісу з обробкою дій
    public static void YouTube(VideoSubscription youtubeSubscription)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Red;
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n=Video= 🖥️ YouTube 🖥️ =Video=");
            Console.WriteLine("1. Статус підписки та якості відео");
            Console.WriteLine("2. Активувати підписку");
            Console.WriteLine("3. Деактивувати підписку");
            Console.WriteLine("4. Змінити якість відео (ручний вибір)");
            Console.WriteLine("5. Змінити якість відео (автоматичний вибір)");
            Console.WriteLine("6. Розрахувати річну вартість");
            Console.WriteLine("0. Повернутися до головного меню");

            Console.Write("Оберіть дію: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(youtubeSubscription.ToString());
                    break;
                case "2":
                    youtubeSubscription.ActivateSubscription();
                    break;
                case "3":
                    youtubeSubscription.CancelSubscription();
                    break;
                case "4":
                    bool validInput = false;
                    while (!validInput)
                    {
                        Console.Write("Введіть нову якість відео (720p, 1080p, 4K): ");
                        string newQuality = Console.ReadLine();
                        //Перевірка на коректність введеної якості відео
                        if (newQuality == "720p" || newQuality == "1080p" || newQuality == "4K")
                        {
                            youtubeSubscription.ChangeVideoQuality(newQuality);
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Неккоректна якість відео.");
                        }
                    }
                    break;
                case "5":
                    youtubeSubscription.SetAutomaticQuality();
                    break;
                case "6":
                    Console.WriteLine($"Річна вартість: {youtubeSubscription.CalculateYearlyFee()} долларів");
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}