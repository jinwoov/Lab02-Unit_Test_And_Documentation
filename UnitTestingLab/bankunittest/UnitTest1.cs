using System;
using Xunit;
using UnitTestingLab;

namespace bankunittest
{
    public class UnitTest1
    {
        // checking if i can deposit
        [Fact]
        public void CanIDeposit()
        {
            //Arrange
            Program.defaultMoney = 5000;
            // Act and Assert
            Assert.Equal(6000, Program.DepositCash(1000));
        }

        // checking if I can withdraw
        [Fact]
        public void CanIWithDraw()
        {
            //Arrange
            Program.defaultMoney = 5000;
            // Act and Assert
            Assert.Equal(1000, Program.WithdrawCash(4000));
        }

        // Testing if I can deposit negative number
        [Theory]
        [InlineData(5000, -2000)]
        [InlineData(5000, -5000)]
        public void TestingIfNegativeWorkOnDeposit(int exp, int act)
        {
            // arrange
            Program.defaultMoney = 5000;
            // Act and assert
            Assert.Equal(exp, Program.DepositCash(act));
        }

        // Testing if I can withdraw more than what i have
        [Theory]
        [InlineData(1,6000)]
        [InlineData(1, 10000)]
        public void TakingMoreThanWhatIHave(int exp, int act)
        {
            // arrange
            Program.defaultMoney = 5000;
            //Act and Assert
            Assert.Equal(exp, Program.WithdrawCash(act));
        }
    }
}
