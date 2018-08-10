namespace EventSourcing.Commands
{
    abstract class Command
    {
        public abstract void Perform();
    }
}
