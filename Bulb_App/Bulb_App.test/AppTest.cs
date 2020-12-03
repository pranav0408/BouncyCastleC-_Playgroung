using System;
using NUnit.Framework;

namespace Bulb_App.Test
{
    [TestFixture]
    public class AppTest
    {
        string Bulb, Color, ExpectedOutput;
        int Hour;
        [SetUp]
        public void Init()
        {
            DateTime now = DateTime.Now;
            string[] Bulb_Series = { "LED", "Candescent", "LED", "Candescent", "LED", "Candescent", "LED" }; //  { Sunday -> Saturday }
            Bulb = Bulb_Series[(int)now.DayOfWeek];
            Hour = now.Hour;

            if( Bulb == "Candescent")
            {
                Color = "Yellow";
            }
            else if(Bulb == "LED")
            {
                if (Hour > 0 && Hour <= 3)
                    Color = "Violet";
                if (Hour >= 4 && Hour <= 7)
                    Color = "Indigo";
                if (Hour >= 8 && Hour <= 11)
                    Color = "Blue";
                if (Hour >= 12 && Hour <= 15)
                    Color = "Green";
                if (Hour >= 16 && Hour <= 19)
                    Color = "Yellow";
                if (Hour >= 20 && Hour <= 23)
                    Color = "Orange";
                if (Hour == 0)
                    Color = "Red";
            }
            ExpectedOutput = "Bulb Type is: " + Bulb + "\nBulb Status is: on\nBulb Color is: " + Color + "\nBulb Intensity is: 100";
        } // setup

        [Test]
        public void ShouldOperate_ValidOn()
        {
            if( Bulb == "Candescent")
            {
                Bulb_Candescent.Candescent BulbObj = new Bulb_Candescent.Candescent();
                string ActualOutput = Bulb_App.App.bulbOperation(BulbObj, "on");
                Assert.AreEqual(ExpectedOutput, ActualOutput);
            }
            else if( Bulb == "LED")
            {
                Bulb_Led.Led BulbObj = new Bulb_Led.Led();
                string ActualOutput = Bulb_App.App.bulbOperation(BulbObj, "on");
                Assert.AreEqual(ExpectedOutput, ActualOutput);
            }
        }
        [Test]
        public void ShouldOperate_ValidOff()
        {
            string ExpectedOutput = "Bulb is already OFF";
            if (Bulb == "Candescent")
            {
                Bulb_Candescent.Candescent BulbObj = new Bulb_Candescent.Candescent();
                string ActualOutput = Bulb_App.App.bulbOperation(BulbObj, "off");
                Assert.AreEqual(ExpectedOutput, ActualOutput);
            }
            else if (Bulb == "LED")
            {
                Bulb_Led.Led BulbObj = new Bulb_Led.Led();
                string ActualOutput = Bulb_App.App.bulbOperation(BulbObj, "off");
                Assert.AreEqual(ExpectedOutput, ActualOutput);
            }
        }
        [Test]
        public void ShouldOperate_InvalidSwitchInput()
        {
            string ExpectedOutput = "Invalid switching option selected"; 
            if (Bulb == "Candescent")
            {
                Bulb_Candescent.Candescent BulbObj = new Bulb_Candescent.Candescent();
                string ActualOutput = Bulb_App.App.bulbOperation(BulbObj, "onn");
                Assert.AreEqual(ExpectedOutput, ActualOutput);
            }
            else if (Bulb == "LED")
            {
                Bulb_Led.Led BulbObj = new Bulb_Led.Led();
                string ActualOutput = Bulb_App.App.bulbOperation(BulbObj, "onff");
                Assert.AreEqual(ExpectedOutput, ActualOutput);
            }
        }
        [Test]
        public void ShouldFail_InvalidInput()
        {
            if (Bulb == "Candescent")
            {
                Bulb_Candescent.Candescent BulbObj = new Bulb_Candescent.Candescent();
                string ActualOutput = Bulb_App.App.bulbOperation(BulbObj, "onn");
                Assert.AreEqual(ExpectedOutput, ActualOutput);
            }
            else if (Bulb == "LED")
            {
                Bulb_Led.Led BulbObj = new Bulb_Led.Led();
                string ActualOutput = Bulb_App.App.bulbOperation(BulbObj, "onff");
                Assert.AreEqual(ExpectedOutput, ActualOutput);
            }
        }
    }
}
