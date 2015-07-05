
namespace AIBlockBattleBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var bot = new Bot())
            {
                bot.Run();
            }
        }
    }
}