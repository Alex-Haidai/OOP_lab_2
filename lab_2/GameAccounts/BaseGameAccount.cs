
using lab_2.Games;
using static lab_2.Games.BaseGame;

namespace lab_2.GameAccounts
{
    public class BaseGameAccount//клас базового ігрового акаунту
    {
        public string UserName { get; set; }//ім'я користувача
        public int GamesCount //кількість ігор користувача
        {
            get
            {
                return gameList.Count;
            }
        }

        protected List<BaseGame> gameList = new();//список ігор користувача
        private static readonly List<BaseGameAccount> accountList = new();//список усіх ігрових акаунтів

        public virtual int CurrentRating//поточний рейтинг коричтувача
        {
            get
            {
                int rating = 1;//ініціалізуємо початковий рейтинг
                foreach (var item in gameList)//цикл проходу по всіх іграх, в яких брав участь користувач
                {
                    if (item.WinnerAccount.UserName.Equals(UserName))//якщо перемога додаємо до поточного рейтингу рейтинг гри
                    {
                        rating += item.GameRate;
                    }
                    else//якщо поразка
                    {
                        if (item is OnePlayerRateGame)
                        {
                            rating = item.LoserAccountRate;
                        }
                        else
                        {
                            rating = rating - item.GameRate >= 1 ? rating -= item.GameRate : rating = 1;
                        }
                    }
                }
                return rating;
            }
        }

        public BaseGameAccount(string name)//конструктор
        {
            UserName = name;
            GameAccountIsValid(this);
            accountList.Add(this);
        }

        private static void GameAccountIsValid(BaseGameAccount currentAccount) //пеервірка нового акаунту
        {
            foreach (var item in accountList)
            {
                if (item.UserName == currentAccount.UserName)
                {
                    throw new InvalidDataException("An account with this name already exists");
                }
            }
        }

        public void WinGame(BaseGame game)//метод, що викликається у разі перемоги
        {
            gameList.Add(game);
            game.WinnerAccountRate = CurrentRating;
        }

        public void LoseGame(BaseGame game)//метод, що викликається у разі поразки
        {
            gameList.Add(game);
            game.LoserAccountRate = CurrentRating;
        }

        public string GetStats()//метод отримання статистики користувача
        {
            var gameReport = new System.Text.StringBuilder();//створюємо динамічний рядок
            gameReport.AppendLine("Opponent name\tGame status\t\tGame type\t\t   Game Rating\t\tGame Id\t\tCurrent rating");//додаємо значення статистики
            foreach (var item in gameList)//цикл проходу по всіх іграх, в яких брав участь користувач
            {
                if (item.WinnerAccount.UserName.Equals(UserName))
                {
                    gameReport.AppendLine($"{item.LoserAccount.UserName}\t\t{AllPossibleGameStatus.Victory}\t\t\t{item.CurrentGameType,-20}\t\t{item.GameRate}\t\t{item.GameId,5}\t\t{item.WinnerAccountRate,10}");//виводимо рядок інформації про поточну гру та користувача 
                }
                else
                {
                    gameReport.AppendLine($"{item.WinnerAccount.UserName}\t\t{AllPossibleGameStatus.Defeat}\t\t\t{item.CurrentGameType,-20}\t\t{item.GameRate}\t\t{item.GameId,5}\t\t{item.LoserAccountRate,10}");
                }
            }
            return gameReport.ToString();
        }
    }
}
