using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace SotM_ModBase.TestEnvironment
{
    public class TestEnvironmentOngoingCardController : CardController
    {
        public TestEnvironmentOngoingCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
