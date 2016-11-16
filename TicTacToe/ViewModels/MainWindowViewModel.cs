using System;
using System.Windows.Input;
using TicTacToe.Infrastructure;
using TicTacToe.Models;
using TicTacToe.Services;

namespace TicTacToe.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {
        private IGameChecker _gameChecker;
        private IAIPlayer _aiPlayer;

        public MainWindowViewModel(IAIPlayer aiPlayer, IGameChecker gameChecker)
        {
            _pendingPlayerAction = true;
            _aiPlayer = aiPlayer;
            _gameChecker = gameChecker;
        }

        #region Observables Properties

        private bool _pendingPlayerAction;

        public bool PendingPlayerAction
        {
            get { return _pendingPlayerAction; }
            set
            {
                _pendingPlayerAction = value;
                OnPropertyChanged();
            }
        }

        private string _c_1_1;

        public string C_1_1
        {
            get { return _c_1_1; }
            set
            {
                _c_1_1 = value;
                OnPropertyChanged();
            }
        }

        private string _c_1_2;

        public string C_1_2
        {
            get { return _c_1_2; }
            set
            {
                _c_1_2 = value;
                OnPropertyChanged();
            }
        }

        private string _c_1_3;

        public string C_1_3
        {
            get { return _c_1_3; }
            set
            {
                _c_1_3 = value;
                OnPropertyChanged();
            }
        }

        private string _c_2_1;

        public string C_2_1
        {
            get { return _c_2_1; }
            set
            {
                _c_2_1 = value;
                OnPropertyChanged();
            }
        }

        private string _c_2_2;

        public string C_2_2
        {
            get { return _c_2_2; }
            set
            {
                _c_2_2 = value;
                OnPropertyChanged();
            }
        }

        private string _c_2_3;

        public string C_2_3
        {
            get { return _c_2_3; }
            set
            {
                _c_2_3 = value;
                OnPropertyChanged();
            }
        }

        private string _c_3_1;

        public string C_3_1
        {
            get { return _c_3_1; }
            set
            {
                _c_3_1 = value;
                OnPropertyChanged();
            }
        }

        private string _c_3_2;

        public string C_3_2
        {
            get { return _c_3_2; }
            set
            {
                _c_3_2 = value;
                OnPropertyChanged();
            }
        }

        private string _c_3_3;

        public string C_3_3
        {
            get { return _c_3_3; }
            set
            {
                _c_3_3 = value;
                OnPropertyChanged();
            }
        }

        #endregion Observables Properties

        #region Commands

        private ICommand _caseClicked;

        public ICommand CaseClicked
        {
            get
            {
                if (_caseClicked == null)
                    _caseClicked = new RelayCommand<string>((string address) => OnPlayerPlayed(address),
                                                            (string address) => IsCaseEmpty(address));

                return _caseClicked;
            }
        }

        private ICommand _reset;

        public ICommand Reset
        {
            get
            {
                if (_reset == null)
                    _reset = new RelayCommand<object>((object o) => ResetGame(),
                                                      (object o) => CanResetGame());

                return _reset;
            }
        }

        #endregion Commands

        #region Private Methods

        private void OnPlayerPlayed(string adress)
        {
            PendingPlayerAction = false;

            GetType().GetProperty(adress).SetValue(this, "X");

            var board = BuildBoardFromObservableProperties();
            var status = _gameChecker.CheckGame(board);

            switch (status)
            {
                case EGameStatus.Running:
                    //make AI play
                    var newBoard = _aiPlayer.Play(board);
                    UpdateObservablePropertiesFromBoard(newBoard);
                    var newStatus = _gameChecker.CheckGame(newBoard);
                    if (newStatus != EGameStatus.Running)
                        ResetGame();
                    break;

                default: //somebody won or tie
                    ResetGame();
                    break;
            }

            PendingPlayerAction = true;
        }

        private bool IsCaseEmpty(string adress)
        {
            return GetType().GetProperty(adress).GetValue(this) == null;
        }

        private void ResetGame()
        {
            C_1_1 = null;
            C_1_2 = null;
            C_1_3 = null;
            C_2_1 = null;
            C_2_2 = null;
            C_2_3 = null;
            C_3_1 = null;
            C_3_2 = null;
            C_3_3 = null;
        }

        private bool CanResetGame()
        {
            for (var i = 1; i <= 3; i++)
                for (var j = 1; j <= 3; j++)
                    if (GetType().GetProperty("C_" + i + "_" + j).GetValue(this) != null)
                        return true;

            return false;
        }

        private ECaseValue[,] BuildBoardFromObservableProperties()
        {
            return new ECaseValue[3, 3]
            {
                { ConvertStringToECaseValue(C_1_1), ConvertStringToECaseValue(C_1_2), ConvertStringToECaseValue(C_1_3) },
                { ConvertStringToECaseValue(C_2_1), ConvertStringToECaseValue(C_2_2), ConvertStringToECaseValue(C_2_3) },
                { ConvertStringToECaseValue(C_3_1), ConvertStringToECaseValue(C_3_2), ConvertStringToECaseValue(C_3_3) }
            };
        }

        private ECaseValue ConvertStringToECaseValue(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return ECaseValue.Empty;

            return (ECaseValue)Enum.Parse(typeof(ECaseValue), str);
        }

        private void UpdateObservablePropertiesFromBoard(ECaseValue[,] board)
        {
            for (var i = 1; i <= 3; i++)
                for (var j = 1; j <= 3; j++)
                    if (board[i - 1, j - 1] != ECaseValue.Empty && board[i - 1, j - 1].ToString() != (string)GetType().GetProperty("C_" + i + "_" + j).GetValue(this))
                        GetType().GetProperty("C_" + i + "_" + j).SetValue(this, board[i - 1, j - 1].ToString());
        }

        #endregion Private Methods
    }
}