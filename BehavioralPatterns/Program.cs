class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var bot = new BotHandler();
        var operatorSupport = new OperatorHandler();
        var techSupport = new TechSupportHandler();
        var manager = new ManagerHandler();

        bot.SetNext(operatorSupport).SetNext(techSupport).SetNext(manager);

        bool isHandled = false;

        while (!isHandled)
        {
            Console.WriteLine("1-Баланс, 2-Тариф, 3-Інтернет, 4-Скарга");
            Console.Write("Вибір: ");
            string choice = Console.ReadLine();

            isHandled = bot.HandleRequest(choice);

            if (!isHandled)
            {
                Console.WriteLine("Помилка.");
            }
        }
       
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ICommandCentre centre = new CommandCentre();
        Runway runway = new Runway(centre);
        Aircraft aircraft1 = new Aircraft(centre);
        Aircraft aircraft2 = new Aircraft(centre);

        aircraft1.Land();
        aircraft2.Land();
    }
}