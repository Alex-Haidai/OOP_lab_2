using lab_2.GameAccounts;


namespace lab_2.Games
{
    public abstract class BaseGame//клас гри
    {
        public enum AllPossibleGameStatus
        {
            Victory, Defeat
        }
        public enum AllPossibleGameType
        {
            CommonGame, TrainingGame, OnePlayerRateGame
        }

        public AllPossibleGameStatus CurrentGameStatus { get; set; }
        public AllPossibleGameType CurrentGameType { get; set; }

        public BaseGameAccount WinnerAccount { get; set; }
        public BaseGameAccount LoserAccount { get; set; }
        public int GameId { get; }
        private static int gameUniqueIndex = 1;
        private int gameRating;
        public int GameRate
        {
            get
            {
                return gameRating;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Rating of game must be positive");//якщо рейтинг гри від'ємний викидаємо виключення
                }
                else gameRating = value;
            }
        }
        public int WinnerAccountRate { get; set; }
        public virtual int LoserAccountRate { get; set; }


        public BaseGame(BaseGameAccount firstAccount, BaseGameAccount secondAccount, AllPossibleGameStatus status)//конструктор
        {
            FindThePlayerStatus(firstAccount, secondAccount);
            CurrentGameStatus = status;
            GameId = gameUniqueIndex;
            gameUniqueIndex++;
        }

        public void PlayGame()//метод, що викликає методи виграшу та поразки
        {
            WinnerAccount.WinGame(this);
            LoserAccount.LoseGame(this);
        }
        private void FindThePlayerStatus(BaseGameAccount firstAccount, BaseGameAccount secondAccount)//метод, що шукає акаунт переможця
        {
            if (firstAccount.Equals(secondAccount))
            {
                throw new InvalidDataException("You can`t play with yourself");
            }
            if (CurrentGameStatus.Equals(AllPossibleGameStatus.Victory))
            {
                WinnerAccount = firstAccount;
                LoserAccount = secondAccount;
            }
            else
            {
                WinnerAccount = secondAccount;
                LoserAccount = firstAccount;
            }
        }
    }
}
