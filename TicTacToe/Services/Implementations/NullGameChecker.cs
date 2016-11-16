using TicTacToe.Models;

namespace TicTacToe.Services.Implementations
{
    internal class NullGameChecker : IGameChecker
    {
        public EGameStatus CheckGame(ECaseValue[,] board)
        {
            return EGameStatus.Running;
        }
    }
}