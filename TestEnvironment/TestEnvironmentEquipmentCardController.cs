using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace DeckardBaseMod.TestEnvironment
{
    public class TestEnvironmentEquipmentCardController : CardController
    {
        public TestEnvironmentEquipmentCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }
    }
}
