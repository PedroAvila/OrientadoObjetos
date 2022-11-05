using System;

namespace BranchingDemo
{
    public class Frozen : IAccountState
    {
        private Action _OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            _OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            _OnUnfreeze();
            addToBalance();
            return new Active(_OnUnfreeze);
        }

        public IAccountState Freeze() => this;
        

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            _OnUnfreeze();
            subtractFromBalance();
            return new Active(_OnUnfreeze);
        }

        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}
