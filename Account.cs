using System;

namespace BranchingDemo
{
    public class Account
    {
        public decimal Balance { get; private set; }
        
        private IAccountState _State { get; set; }


        public Account(Action onUnfreeze)
        {
            _State = new NotVerified(onUnfreeze);
        }

        // #1 (Interaction): Deposit was invoked on the State
        // #2 (Behavior): Result of State.Deposit is new State
        // #5 (Behavior): Deposit 10, Deposit 1 - Balance == 11
        public void Deposit(decimal amount)
        {
            _State = _State.Deposit(() => { Balance += amount; });
        }

        // #3 (Interaction): Deposit was invoked on the State
        // #4 (Behavior): Result of State.Deposit is new State
        // #6 (Behavior): Deposit 1, Verify, Withdraw 1 - Balance == 9
        public void Withdraw(decimal amount)
        {
            _State = _State.Withdraw(() => { Balance -= amount; });
        }

        public void HolderVerified()
        {
            _State = _State.HolderVerified();
        }

        public void Cloose()
        {
            _State = _State.Close();
        }

        public void Freeze()
        {
            _State = _State.Freeze();
        }
    }
}
