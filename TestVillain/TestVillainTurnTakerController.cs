using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace DeckardBaseMod.TestVillain
{
    public class TestVillainTurnTakerController : TurnTakerController
    {
        public TestVillainTurnTakerController(TurnTaker turnTaker, GameController gameController) : base(turnTaker, gameController)
        {
        }
    }
}
