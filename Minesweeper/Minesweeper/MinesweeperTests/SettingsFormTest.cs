using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinesweeperTests
{
    [TestClass]
    public class SettingsFormTest
    {
        [TestMethod]
        public void CorrectInstantiationTest()
        {
            Button NewGameButton = new Button();
            NewGameButton.Name = "NewGameButton";
            Button CustomMapEditorButton = new Button();
            NewGameButton.Name = "CustomMapEditorButton";

            SettingsForm newGame = new SettingsForm(NewGameButton);
            SettingsForm customMap = new SettingsForm(CustomMapEditorButton);

            //Just make sure it instantiated correctly
            Assert.IsTrue(true);
        }





        [TestMethod]
        public void TextChangedTest()
        {
            Button b = new Button();
            b.Name = "NewGameButton";
            SettingsForm settingsForm = new SettingsForm(b);
            //Good values
            foreach (Control c in settingsForm.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox text = (TextBox)c;
                    text.Text = 10.ToString();
                }
            }
            foreach (Control c in settingsForm.Controls)
            {
                if (c.GetType() == typeof(HScrollBar))
                {
                    HScrollBar sbar = (HScrollBar)c;
                    Assert.AreEqual(sbar.Value, 10);
                }
            }
            //Too low values
            foreach (Control c in settingsForm.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox text = (TextBox)c;
                    text.Text = 1.ToString();
                }
            }
            foreach (Control c in settingsForm.Controls)
            {
                if (c.GetType() == typeof(HScrollBar))
                {
                    HScrollBar sbar = (HScrollBar)c;
                    Assert.AreEqual(sbar.Value, sbar.Minimum); //value shouldn't have changed
                }
            }

            //Too high values
            foreach (Control c in settingsForm.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox text = (TextBox)c;
                    text.Text = 100.ToString();
                }
            }
            foreach (Control c in settingsForm.Controls)
            {
                if (c.GetType() == typeof(HScrollBar))
                {
                    HScrollBar sbar = (HScrollBar)c;
                    Assert.AreEqual(sbar.Value, sbar.Maximum); //value shouldn't have changed
                }
            }

            //Bad input
            foreach (Control c in settingsForm.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox text = (TextBox)c;
                    text.Text = "A";
                }
            }
            foreach (Control c in settingsForm.Controls)
            {
                if (c.GetType() == typeof(HScrollBar))
                {
                    HScrollBar sbar = (HScrollBar)c;
                    Assert.AreEqual(sbar.Value, 10); //values shouldn't have changed
                }
            }

        }
    }
}
