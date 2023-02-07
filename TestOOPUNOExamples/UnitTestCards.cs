using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOOPUNOExamples
{
    public class UnitTestCards
    {
        Card redCard1 = new RedCard(1);
        Card redCard2 = new RedCard(2);
        Card blueCard1 = new BlueCard(1);
        Card blueCard2 = new BlueCard(2);
        Card blueActionCard = new BlueActionCard(ColoredActionCardType.DrawTwo);
        Card redActionCard = new RedActionCard(ColoredActionCardType.DrawTwo);
        Card wildCard = new WildCard(WildActionCardType.DrawFour);
        [Fact]
        public void TestToCompareColor()
        {
            Assert.True(redCard1.ToCompare(redCard2));
            Assert.True(redCard1.ToCompare(redActionCard));
            Assert.True(blueCard1.ToCompare(blueCard2));
            Assert.True(blueCard2.ToCompare(blueActionCard));
        }
        [Fact]
        public void TestToCompareNumber()
        {
            Assert.True(redCard1.ToCompare(blueCard1));
            Assert.True(blueCard2.ToCompare(redCard2));
        }
        [Fact]
        public void TestToCompareType()
        {
            Assert.True(blueActionCard.ToCompare(redActionCard));
            Assert.True(redActionCard.ToCompare(blueActionCard));
            Assert.True(wildCard.ToCompare(redCard2));
            Assert.True(redCard1.ToCompare(wildCard));
        }
        [Fact]
        public void TestToCompareWildCard()
        {
            Assert.True(wildCard.ToCompare(redActionCard));
            Assert.True(redActionCard.ToCompare(wildCard));
            Assert.True(wildCard.ToCompare(redCard2));
            Assert.True(redCard1.ToCompare(wildCard));
        }
        [Fact]
        public void TestToCompareFails()
        {
            Assert.False(blueActionCard.ToCompare(redCard1));
            Assert.False(redActionCard.ToCompare(blueCard1));
            Assert.False(blueCard2.ToCompare(redCard1));
            Assert.False(redCard2.ToCompare(blueCard1));
        }
    }
}
