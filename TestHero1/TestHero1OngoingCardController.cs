using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace DeckardBaseMod.TestHero1
{
    public class TestHero1OngoingCardController : CardController
    {
        public TestHero1OngoingCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
