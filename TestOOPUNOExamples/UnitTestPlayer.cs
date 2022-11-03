namespace TestOOPUNOExamples
{
    public class UnitTestPlayer
    {
        Player player = new Player("Test");
        
        [Fact]
        public void TestDrawCard()
        {
            int CardsInHand = player.GetHandSize();
            player.DrawCard();
            Assert.Equal(CardsInHand + 1, player.GetHandSize());
        }
        [Fact]
        public void TestDrawCards()
        {
            int CardsInHand = player.GetHandSize();
            const int CardsDrawn = 3;
            player.DrawCards(CardsDrawn);
            Assert.Equal(CardsInHand + CardsDrawn, player.GetHandSize());
        }
    }
}