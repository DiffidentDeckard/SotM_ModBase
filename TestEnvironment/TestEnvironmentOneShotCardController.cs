using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace DeckardBaseMod.TestEnvironment
{
    public class TestEnvironmentOneShotCardController : CardController
    {
        public TestEnvironmentOneShotCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
