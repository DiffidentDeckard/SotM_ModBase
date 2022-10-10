using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace DeckardBaseMod.TestVillain
{
    public class TestVillainTargetCardController : CardController
    {
        public TestVillainTargetCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
