using CombatScene.Interfaces;

namespace CombatScene.CharacterDecorators
{
    public static class CharacterRegenerationDecoratorHelper
    {
        public static ICharacter DecorateWithRegenEffectDecorator(this ICharacter self,int intensity, int duration)
        {
            return new CharacterRegenerationDecorator(self,intensity,duration);
        }
    }
    
    public class CharacterRegenerationDecorator : ICharacter
    {
        private ICharacter Decoratee;
        private readonly int Intensity;
        private int Duration;

        public CharacterRegenerationDecorator(ICharacter decoratee,int intensity,int duration)
        {
            Decoratee = decoratee;
            Intensity = intensity;
            Duration = duration;
        }

        public string Name => Decoratee.Name;

        public int MaxHitPoints => Decoratee.MaxHitPoints;

        public int CurrentHitPoints => Decoratee.CurrentHitPoints;

        public int MaxManaPoints => Decoratee.MaxManaPoints;

        public int CurrentManaPoints => Decoratee.CurrentManaPoints;

        public int Attack => Decoratee.Attack;

        public int Defense => Decoratee.Defense;

        public void HpAction(int quantity)
        {
            Decoratee.HpAction(quantity);
        }

        public void MpAction(int quantity)
        {
            Decoratee.MpAction(quantity);
        }

        public void OnTurnStart()
        {
            Decoratee.OnTurnStart();
            HpAction(Intensity);
            Duration--;
        }

        public void OnTurnEnd()
        {
            Decoratee.OnTurnEnd();
        }

        public ICharacter Normalize(bool force = false)
        {
            if (force) return Decoratee.Normalize();
            if (Duration > 0)
            {
                Decoratee = Decoratee.Normalize();
                return this;
            }
            else
            {
                return Decoratee.Normalize();
            }
        }
    }
}