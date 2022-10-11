using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace SotM_ModBase.TestVillain
{
    public class TestVillainOngoingCardController : CardController
    {
        public TestVillainOngoingCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
