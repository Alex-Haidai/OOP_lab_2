using lab_2.GameAccounts;
using static lab_2.Games.BaseGame;

namespace lab_2.Games
{
    public class GameFactory//фабричний клас для створення ігор різних типів, що приводяться до базового
    {
        public static BaseGame CreateCommonGame(BaseGameAccount firstAccount, BaseGameAccount secondAccount, int gameRate, AllPossibleGameStatus status)
        {
            return new CommonGame(firstAccount, secondAccount, gameRate, status);
        }

        public static BaseGame CreateTrainingGame(BaseGameAccount firstAccount, BaseGameAccount secondAccount, AllPossibleGameStatus status)
        {
            return new TrainingGame(firstAccount, secondAccount, status);
        }
        public static BaseGame CreateOnePlayerRateGame(BaseGameAccount firstAccount, BaseGameAccount secondAccount, int gameRate, AllPossibleGameStatus status)
        {
            return new OnePlayerRateGame(firstAccount, secondAccount, gameRate, status);
        }
    }
}
