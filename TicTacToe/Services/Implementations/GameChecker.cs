using TicTacToe.Models;

namespace TicTacToe.Services.Implementations
{
    internal class GameChecker : IGameChecker
    {
        public EGameStatus CheckGame(ECaseValue[,] board)
        {
            //check lines and cols
            for (var i = 0; i < 3; i++)
            {
                if (board[i, 0] != ECaseValue.Empty && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return board[i, 0] == ECaseValue.X ? EGameStatus.PlayerWon : EGameStatus.AIWon;

                if (board[0, i] != ECaseValue.Empty && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return board[1, i] == ECaseValue.X ? EGameStatus.PlayerWon : EGameStatus.AIWon;
            }

            //check diags
            if (board[2, 2] != ECaseValue.Empty
             && ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
             || (board[0, 2] == board[2, 2] && board[2, 2] == board[2, 0])))
                return board[2, 2] == ECaseValue.X ? EGameStatus.PlayerWon : EGameStatus.AIWon;

            //check tie
            if (IsBoardFull(board))
                return EGameStatus.Tie;

            return EGameStatus.Running;
        }

        private bool IsBoardFull(ECaseValue[,] board)
        {
            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    if (board[i, j] != ECaseValue.Empty)
                        return false;

            return true;
        }
    }
}