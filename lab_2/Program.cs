using lab_2.GameAccounts;
using lab_2.Games;
using static lab_2.Games.BaseGame;

class MainClass//головний клас
{
    static void Main(string[] args)
    {

        var firstAccount = new VipGameAccount("Mike");//за серію перемог в 2 рази більше балів
        var secondAccount = new LessPointsGameAccount("Jimmy");//за поразку знімається тільки половина балів

        Console.WriteLine($"First player -  {firstAccount.UserName}");//виводимо їх імена
        Console.WriteLine($"Second player - {secondAccount.UserName}\n");

        GameFactory.CreateCommonGame(firstAccount, secondAccount, 1, AllPossibleGameStatus.Victory).PlayGame();//звичайні ігри
        GameFactory.CreateCommonGame(secondAccount, firstAccount, 1, AllPossibleGameStatus.Defeat).PlayGame();
        GameFactory.CreateCommonGame(firstAccount, secondAccount, 5, AllPossibleGameStatus.Victory).PlayGame();
        GameFactory.CreateCommonGame(secondAccount, firstAccount, 3, AllPossibleGameStatus.Defeat).PlayGame();
        GameFactory.CreateCommonGame(secondAccount, firstAccount, 5, AllPossibleGameStatus.Victory).PlayGame();
        GameFactory.CreateCommonGame(firstAccount, secondAccount, 3, AllPossibleGameStatus.Victory).PlayGame();
        GameFactory.CreateCommonGame(firstAccount, secondAccount, 5, AllPossibleGameStatus.Victory).PlayGame();
        GameFactory.CreateCommonGame(firstAccount, secondAccount, 2, AllPossibleGameStatus.Defeat).PlayGame();

        GameFactory.CreateTrainingGame(firstAccount, secondAccount, AllPossibleGameStatus.Victory).PlayGame();//тренувальні ігри
        GameFactory.CreateTrainingGame(secondAccount, firstAccount, AllPossibleGameStatus.Defeat).PlayGame();
        GameFactory.CreateTrainingGame(firstAccount, secondAccount, AllPossibleGameStatus.Defeat).PlayGame();

        GameFactory.CreateOnePlayerRateGame(firstAccount, secondAccount, 3, AllPossibleGameStatus.Defeat).PlayGame();//ігри де у програвшого рейтинг не змінюється
        GameFactory.CreateOnePlayerRateGame(firstAccount, secondAccount, 6, AllPossibleGameStatus.Victory).PlayGame();
        GameFactory.CreateOnePlayerRateGame(secondAccount, firstAccount, 5, AllPossibleGameStatus.Defeat).PlayGame();
        GameFactory.CreateOnePlayerRateGame(secondAccount, firstAccount, 10, AllPossibleGameStatus.Defeat).PlayGame();


        Console.WriteLine($"{firstAccount.UserName} statistics:\n");//виводимо статистику обох гравців
        Console.WriteLine(firstAccount.GetStats());
        Console.WriteLine($"\n{secondAccount.UserName} statistics:\n");
        Console.WriteLine(secondAccount.GetStats());

        Console.WriteLine($"\nNumber of {firstAccount.UserName} games: {firstAccount.GamesCount}, current rating = {firstAccount.CurrentRating}\n");
        //виводимо кількість ігор кожного гравця та поточний рейтинг
        Console.WriteLine($"Number of {secondAccount.UserName} games: {secondAccount.GamesCount}, current rating = {secondAccount.CurrentRating}");
    }
}