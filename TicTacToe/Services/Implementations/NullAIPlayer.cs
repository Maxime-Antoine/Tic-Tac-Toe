using TicTacToe.Models;

namespace TicTacToe.Services.Implementations
{
    internal class NullAIPlayer : IAIPlayer
    {
        public ECaseValue[,] Play(ECaseValue[,] board)
        {
            return board;
        }

        public void Reset()
        { }
    }
}