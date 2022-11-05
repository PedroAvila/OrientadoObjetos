using System;

namespace BranchingDemo
{
    public class Active : IAccountState
    {
        private Action _OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            _OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }


        public IAccountState Freeze() => new Frozen(_OnUnfreeze);
        

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState HolderVerified() => this;
        

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}
