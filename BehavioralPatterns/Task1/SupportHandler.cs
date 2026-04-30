public abstract class SupportHandler
{
    private SupportHandler _nextHandler;

    public SupportHandler SetNext(SupportHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual bool HandleRequest(string request)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.HandleRequest(request);
        }
        return false;
    }
}

public class BotHandler : SupportHandler
{
    public override bool HandleRequest(string request)
    {
        if (request == "1")
        {
            Console.WriteLine("Баланс: 150 грн.");
            return true;
        }
        return base.HandleRequest(request);
    }
}

public class OperatorHandler : SupportHandler
{
    public override bool HandleRequest(string request)
    {
        if (request == "2")
        {
            Console.WriteLine("Тариф змінено.");
            return true;
        }
        return base.HandleRequest(request);
    }
}

public class TechSupportHandler : SupportHandler
{
    public override bool HandleRequest(string request)
    {
        if (request == "3")
        {
            Console.WriteLine("З'єднання перевірено.");
            return true;
        }
        return base.HandleRequest(request);
    }
}

public class ManagerHandler : SupportHandler
{
    public override bool HandleRequest(string request)
    {
        if (request == "4")
        {
            Console.WriteLine("Скаргу прийнято.");
            return true;
        }
        return base.HandleRequest(request);
    }
}