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
        public void button1ClickTest()
        {
            Button NewGameButton = new Button();
            NewGameButton.Name = "NewGameButton";
            SettingsForm newGame = new SettingsForm(NewGameButton);
            newGame.button1_Click(NewGameButton, null);
            Button CustomButton = new Button();
            NewGameButton.Name = "CustomMapEditorButton";
            SettingsForm editor = new SettingsForm(CustomButton);
            newGame.button1_Click(CustomButton, null);

            //code coverage
        }

        [TestMethod]
        public void formLoadTest()
        {
            Button NewGameButton = new Button();
            NewGameButton.Name = "NewGameButton";
            SettingsForm newGame = new SettingsForm(NewGameButton);
            newGame.Form4_Load(NewGameButton, null);
            foreach (Control c in newGame.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox text = (TextBox)c;
                    text.Text = 10.ToString();

                }
            }
            foreach (Control c in newGame.Controls)
            {
                if (c.GetType() == typeof(HScrollBar))
                {
                    HScrollBar sbar = (HScrollBar)c;
                    Assert.AreEqual(sbar.Value, 10);
                }
            }
            bool visible = true;
            Assert.AreEqual(visible, newGame.visibility);

            Button CustomButton = new Button();
            CustomButton.Name = "CustomMapEditorButton";
            SettingsForm CustomGame = new SettingsForm(CustomButton);
            newGame.Form4_Load(CustomButton, null);
            foreach (Control c in CustomGame.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox text = (TextBox)c;
                    text.Text = 10.ToString();

                }
            }
            foreach (Control c in CustomGame.Controls)
            {
                if (c.GetType() == typeof(HScrollBar))
                {
                    HScrollBar sbar = (HScrollBar)c;
                    Assert.AreEqual(sbar.Value, 10);
                }
            }
            visible = false;
            Assert.AreEqual(visible, CustomGame.visibility);
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
                    text.Text = 0.ToString();
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
            settingsForm.Controls["xText"].Text = 1000.ToString();
            settingsForm.Controls["yText"].Text = 1000.ToString();
            settingsForm.Controls["bombsText"].Text = 1000.ToString();
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
                    Assert.AreEqual(sbar.Value, sbar.Minimum); //values shouldn't have changed
                }
            }

        }

        [TestMethod]
        public void testIsDigitsOnly()
        {
            Button b = new Button();
            b.Name = "NewGameButton";
            SettingsForm settingsForm = new SettingsForm(b);
            String empty = "";
            String belowZero = "!!!";
            String aboveNine = "ABC";
            String digits = "123";
            Assert.IsFalse(settingsForm.IsDigitsOnly(empty));
            Assert.IsFalse(settingsForm.IsDigitsOnly(belowZero));
            Assert.IsFalse(settingsForm.IsDigitsOnly(aboveNine));
            Assert.IsTrue(settingsForm.IsDigitsOnly(digits));
        }

        [TestMethod]
        public void testButton2Click()
        {
            Button b = new Button();
            b.Name = "NewGameButton";
            SettingsForm settingsForm = new SettingsForm(b);
            settingsForm.button2_Click(null, null); //This will open an "Open File" dialog that will be tested functionally
        }
    }
}
