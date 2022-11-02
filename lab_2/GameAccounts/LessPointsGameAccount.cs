using lab_2.Games;

namespace lab_2.GameAccounts
{
    public class LessPointsGameAccount : BaseGameAccount//клас ігрового акаунту, в якому при поразці знімається вдвічі менше балів
    {
        public override int CurrentRating//поточний рейтинг коричтувача
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
                            rating = rating - item.GameRate >= 1 ? rating -= item.GameRate / 2 : rating = 1;//при поразці знімається вдвічі менше балів
                        }
                    }
                }
                return rating;
            }
        }
        public LessPointsGameAccount(string name)
            : base(name)
        {
        }
    }
}
