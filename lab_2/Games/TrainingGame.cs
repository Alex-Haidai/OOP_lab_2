using lab_2.GameAccounts;

namespace lab_2.Games
{
    public class TrainingGame : BaseGame//клас тренувальної гри
    {
        public TrainingGame(BaseGameAccount firstAccount, BaseGameAccount secondAccount, AllPossibleGameStatus status)
        : base(firstAccount, secondAccount, status)
        {
            WinnerGameRate = 0;
            LoserGameRate = 0;
            CurrentGameType = AllPossibleGameType.TrainingGame;
        }
    }
}
