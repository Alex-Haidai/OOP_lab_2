using lab_2.GameAccounts;

namespace lab_2.Games
{

    public class OnePlayerRateGame : BaseGame//клас гри, в якому у програвшого не знімаються бали
    {
        private int immutableRate;
        public override int LoserAccountRate
        {
            get
            {
                return immutableRate;
            }
        }

        public OnePlayerRateGame(BaseGameAccount firstAccount, BaseGameAccount secondAccount, int gameRate, AllPossibleGameStatus status)
            : base(firstAccount, secondAccount, status)
        {
            immutableRate = LoserAccount.CurrentRating;
            GameRate = gameRate;
            CurrentGameType = AllPossibleGameType.OnePlayerRateGame;
        }
    }
}
