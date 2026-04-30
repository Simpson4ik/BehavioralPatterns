public interface ICommandCentre
{
    void RegisterRunway(Runway runway);
    void RegisterAircraft(Aircraft aircraft);
    bool RequestLanding();
}

public class CommandCentre : ICommandCentre
{
    private Runway _runway;
    private Aircraft _aircraft;

    public void RegisterRunway(Runway runway) => _runway = runway;
    public void RegisterAircraft(Aircraft aircraft) => _aircraft = aircraft;

    public bool RequestLanding()
    {
        if (_runway.IsClear)
        {
            _runway.IsClear = false;
            return true;
        }
        return false;
    }
}

public class Runway
{
    private readonly ICommandCentre _mediator;
    public bool IsClear { get; set; } = true;

    public Runway(ICommandCentre mediator)
    {
        _mediator = mediator;
        _mediator.RegisterRunway(this);
    }
}

public class Aircraft
{
    private readonly ICommandCentre _mediator;

    public Aircraft(ICommandCentre mediator)
    {
        _mediator = mediator;
        _mediator.RegisterAircraft(this);
    }

    public void Land()
    {
        if (_mediator.RequestLanding())
        {
            Console.WriteLine("Посадка успішна.");
        }
        else
        {
            Console.WriteLine("Смуга зайнята.");
        }
    }
}