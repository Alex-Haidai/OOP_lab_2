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
                    if (item.WinnerAccount.Equals(this))//якщо перемога додаємо до поточного рейтингу рейтинг гри
                    {
                        winCounter++;//лічильник серії перемог
                        if (winCounter > 2)
                        {
                            rating += item.WinnerGameRate * 2;//подвоюємо бали
                        }
                        else { rating += item.WinnerGameRate; }
                    }
                    else//якщо поразка
                    {
                        winCounter = 0;//обнуляємо лічильник
                       
                            rating = rating - item.LoserGameRate >= 1 ? rating -= item.LoserGameRate : rating = 1;
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
