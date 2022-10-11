using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace SotM_ModBase.TestEnvironment
{
    public class TestEnvironmentOneShotCardController : CardController
    {
        public TestEnvironmentOneShotCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
