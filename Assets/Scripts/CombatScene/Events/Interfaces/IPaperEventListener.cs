namespace CombatScene.Events.Interfaces
{
    public interface IPaperEventListener
    {
        void Visit(IPaperEvent paperEvent);
    }
}
