namespace CombatScene.Interfaces
{
    public interface ICharacter 
    {
        string Name { get; }
        int MaxHitPoints { get; }
        int CurrentHitPoints { get; }

        int MaxManaPoints { get; }
        int CurrentManaPoints { get; }

        int Attack { get; }
        int Defense { get; }

        void HpAction(int quantity);
        void MpAction(int quantity);

        void OnTurnStart();
        void OnTurnEnd();
        ICharacter Normalize(bool forceNormalize = false);
    }
}
