using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace SotM_ModBase.TestVillain
{
    public class TestVillainCharacterCardController : VillainCharacterCardController
    {
        public TestVillainCharacterCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
