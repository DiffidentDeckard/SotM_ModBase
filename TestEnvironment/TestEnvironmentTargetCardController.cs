using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace DeckardBaseMod.TestEnvironment
{
    public class TestEnvironmentTargetCardController : CardController
    {
        public TestEnvironmentTargetCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
