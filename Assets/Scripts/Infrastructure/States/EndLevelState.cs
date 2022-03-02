using Assets.Scripts.Infrastructure.States.Interfaces;
using Assets.Scripts.UI.Factory;

namespace Assets.Scripts.Infrastructure.States
{
    public class EndLevelState : IState
    {
        private readonly IUIFactory _uiFactory;

        public EndLevelState(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Enter() => 
            _uiFactory.CreateLevelCompletedWindow();

        public void Exit()
        {

        }
    }
}
