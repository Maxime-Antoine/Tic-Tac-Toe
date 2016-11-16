using TicTacToe.Models;

namespace TicTacToe.Services
{
    internal interface IGameChecker
    {
        EGameStatus CheckGame(ECaseValue[,] board);
    }
}