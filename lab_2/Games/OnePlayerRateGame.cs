using lab_2.GameAccounts;

namespace lab_2.Games
{

    public class OnePlayerRateGame : BaseGame//клас гри, в якому у програвшого не знімаються бали
    {
        public OnePlayerRateGame(BaseGameAccount firstAccount, BaseGameAccount secondAccount, int gameRate, AllPossibleGameStatus status)
            : base(firstAccount, secondAccount, status)
        {
            WinnerGameRate = gameRate;
            LoserGameRate = 0;
            CurrentGameType = AllPossibleGameType.OnePlayerRateGame;
        }
    }
}
