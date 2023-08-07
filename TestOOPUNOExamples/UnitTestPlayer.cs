namespace TestOOPUNOExamples
{
    public class UnitTestPlayer
    {
        Player player = new Player("Test");
        
        [Fact]
        public void TestDrawCard()
        {
            int CardsInHand = player.Hand.GetHandSize();
            player.DrawCard();
            Assert.Equal(CardsInHand + 1, player.Hand.GetHandSize());
        }
        [Fact]
        public void TestDrawCards()
        {
            int CardsInHand = player.Hand.GetHandSize();
            const int CardsDrawn = 3;
            player.DrawCards(CardsDrawn);
            Assert.Equal(CardsInHand + CardsDrawn, player.Hand.GetHandSize());
        }
    }
}