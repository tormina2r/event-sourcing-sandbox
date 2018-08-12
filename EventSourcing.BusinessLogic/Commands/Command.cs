namespace EventSourcing.BusinessLogic.Commands
{
    public abstract class Command
    {
        public abstract void Perform();
    }
}
