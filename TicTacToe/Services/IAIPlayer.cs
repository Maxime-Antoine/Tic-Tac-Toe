using TicTacToe.Models;

namespace TicTacToe.Services
{
    internal interface IAIPlayer
    {
        ECaseValue[,] Play(ECaseValue[,] board);

        void Reset();
    }
}