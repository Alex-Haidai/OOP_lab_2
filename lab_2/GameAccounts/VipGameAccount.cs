using lab_2.Games;

namespace lab_2.GameAccounts
{
    internal class VipGameAccount : BaseGameAccount//клас, в якому за серію перемог бали подвоюються
    {

        public override int CurrentRating//поточний рейтинг коричтувача
        {
            get
            {
                int rating = 1;//ініціалізуємо початковий рейтинг
                int winCounter = 0;
                foreach (var item in gameList)//цикл проходу по всіх іграх, в яких брав участь користувач
                {
                    if (item.WinnerAccount.UserName.Equals(UserName))//якщо перемога додаємо до поточного рейтингу рейтинг гри
                    {
                        winCounter++;//лічильник серії перемог
                        if (winCounter > 2)
                        {
                            rating += item.GameRate * 2;//подвоюємо бали
                        }
                        else { rating += item.GameRate; }
                    }
                    else//якщо поразка
                    {
                        winCounter = 0;//обнуляємо лічильник
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
        public VipGameAccount(string name)
            : base(name)
        {
        }
    }
}
