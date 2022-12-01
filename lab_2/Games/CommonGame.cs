using lab_2.GameAccounts;

namespace lab_2.Games
{
    public class CommonGame : BaseGame//клас звичайної гри
    {
        public CommonGame(BaseGameAccount firstAccount, BaseGameAccount secondAccount, int gameRate, AllPossibleGameStatus status)
            : base(firstAccount, secondAccount, status)
        {
            WinnerGameRate = gameRate;
            LoserGameRate = gameRate;
            CurrentGameType = AllPossibleGameType.CommonGame;
        }
    }
}
