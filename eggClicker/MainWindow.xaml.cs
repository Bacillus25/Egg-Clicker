using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using System.Media;

namespace eggClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        int eggCounter = 0, salt = 0, cheese = 0, pan = 0, goldenEgg = 0;
        int saltPrice = 50, cheesePrice = 500, panPrice = 5000, goldenPrice = 50000;
        int clickerPwr = 1;
        bool animDone = true;
        bool clicker1, clicker2, clicker3, clicker4, clicker5;

        //upgrades
        private void Window_Load(object sender, RoutedEventArgs e)
        {
            SaltUpgrade();
            CheeseUpgrade();
            PanUpgrade();
            GoldenEggUpgrade();
            EggsPerSecond();
            UpgradePrices();
            UpgradeListFill();
        }
        private void UpgradeListFill()
        {

            ClickerUpgrades oClickerUpgrades = new ClickerUpgrades();
            oClickerUpgrades.ClickerU = "Clicker 1";
            oClickerUpgrades.ClickerUCost = 100;
            lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());


            oClickerUpgrades.ClickerU = "Clicker 2";
            oClickerUpgrades.ClickerUCost = 1000;
            lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());


            oClickerUpgrades.ClickerU = "Clicker 3";
            oClickerUpgrades.ClickerUCost = 10000;
            lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());


            oClickerUpgrades.ClickerU = "Clicker 4";
            oClickerUpgrades.ClickerUCost = 100000;
            lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());

            oClickerUpgrades.ClickerU = "Clicker 5";
            oClickerUpgrades.ClickerUCost = 1000000;
            lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());

        }

        private async void SaltUpgrade()
        {
            while (true)
            {
                eggCounter = eggCounter + 1 * salt;
                lblEggCount.Content = eggCounter.ToString();
                await Task.Delay(TimeSpan.FromSeconds(1));
                if (salt >= 1)
                {
                    EggAnimation();
                }

            }
        }
        private async void CheeseUpgrade()
        {
            while (true)
            {
                eggCounter = eggCounter + 10 * cheese;
                lblEggCount.Content = eggCounter.ToString();
                await Task.Delay(TimeSpan.FromSeconds(1));
                if (cheese >= 1)
                {
                    EggAnimation();
                }
            }
        }
        private async void PanUpgrade()
        {
            while (true)
            {
                eggCounter = eggCounter + 50 * pan;
                lblEggCount.Content = eggCounter.ToString();
                await Task.Delay(TimeSpan.FromSeconds(1));
                if (pan >= 1)
                {
                    EggAnimation();
                }
            }
        }


        private async void GoldenEggUpgrade()
        {
            while (true)
            {
                eggCounter = eggCounter + 100 * goldenEgg;
                lblEggCount.Content = eggCounter.ToString();
                await Task.Delay(TimeSpan.FromSeconds(1));
                if (goldenEgg >= 1)
                {
                    EggAnimation();
                }
            }
        }

        //save to txt file
        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            string fileName = "";
            TextWriter tw;
            try
            {
                fileName = "EggClickerSave.txt";
                tw = new StreamWriter(fileName);
                tw.WriteLine(eggCounter);
                tw.WriteLine(salt);
                tw.WriteLine(cheese);
                tw.WriteLine(pan);
                tw.WriteLine(goldenEgg);
                tw.WriteLine(clickerPwr);
                tw.WriteLine(clicker1);
                tw.WriteLine(clicker2);
                tw.WriteLine(clicker3);
                tw.WriteLine(clicker4);
                tw.WriteLine(clicker5);
                tw.Close();
            }
            catch (Exception ex)
            {
            }
        }

        //load txt file
        public void btnLoad_Click_1()
        {
            string fileName = "";
            TextReader tr;
            try
            {
                fileName = "EggClickerSave.txt";
                tr = new StreamReader(fileName);
                eggCounter = Convert.ToInt32(tr.ReadLine());
                salt = Convert.ToInt32(tr.ReadLine());
                cheese = Convert.ToInt32(tr.ReadLine());
                pan = Convert.ToInt32(tr.ReadLine());
                goldenEgg = Convert.ToInt32(tr.ReadLine());
                clickerPwr = Convert.ToInt32(tr.ReadLine());
                clicker1 = Convert.ToBoolean(tr.ReadLine());
                clicker2 = Convert.ToBoolean(tr.ReadLine());
                clicker3 = Convert.ToBoolean(tr.ReadLine());
                clicker4 = Convert.ToBoolean(tr.ReadLine());
                clicker5 = Convert.ToBoolean(tr.ReadLine());
                tr.Close();
            }
            catch (Exception ex)
            {

            }

            ClickerUpgrades oClickerUpgrades = new ClickerUpgrades();
            lstClickerUpgrades.Items.Clear();
            if (clicker1 == false)
            {
                oClickerUpgrades.ClickerU = "Clicker 1";
                oClickerUpgrades.ClickerUCost = 100;
                lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());
            }
            if (clicker2 == false)
            {
                oClickerUpgrades.ClickerU = "Clicker 2";
                oClickerUpgrades.ClickerUCost = 1000;
                lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());
            }
            if (clicker3 == false)
            {
                oClickerUpgrades.ClickerU = "Clicker 3";
                oClickerUpgrades.ClickerUCost = 10000;
                lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());
            }
            if (clicker4 == false)
            {
                oClickerUpgrades.ClickerU = "Clicker 4";
                oClickerUpgrades.ClickerUCost = 100000;
                lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());
            }
            if (clicker5 == false)
            {
                oClickerUpgrades.ClickerU = "Clicker 5";
                oClickerUpgrades.ClickerUCost = 1000000;
                lstClickerUpgrades.Items.Add(oClickerUpgrades.ToString());
            }
        }

        //buttons
        private void btnBuyListUpgrade_Click(object sender, RoutedEventArgs e)
        {
            ClickerUpgrades oClickerUpgrades = new ClickerUpgrades();
            if (lstClickerUpgrades.SelectedItem.ToString() == "Clicker 1 (100 Eggs)")
            {
                if(eggCounter > 100)
                {
                    clickerPwr = clickerPwr + 1;
                    clicker1 = true;
                    lstClickerUpgrades.Items.Remove(lstClickerUpgrades.SelectedItem);
                    eggCounter = eggCounter - 100;
                    return;
                }
                
            }
            if (lstClickerUpgrades.SelectedItem.ToString() == "Clicker 2 (1000 Eggs)")
            {
                if(eggCounter > 1000)
                {
                    clickerPwr = clickerPwr + 5;
                    clicker2 = true;
                    lstClickerUpgrades.Items.Remove(lstClickerUpgrades.SelectedItem);
                    eggCounter = eggCounter - 1000;
                    return;
                }
                
            }
            if (lstClickerUpgrades.SelectedItem.ToString() == "Clicker 3 (10000 Eggs)")
            {
                if(eggCounter > 10000)
                {
                    clickerPwr = clickerPwr + 50;
                    clicker3 = true;
                    lstClickerUpgrades.Items.Remove(lstClickerUpgrades.SelectedItem);
                    eggCounter = eggCounter - 10000;
                    return;
                }
                
            }
            if (lstClickerUpgrades.SelectedItem.ToString() == "Clicker 4 (100000 Eggs)")
            {
                if(eggCounter > 100000)
                {
                    clickerPwr = clickerPwr + 500;
                    clicker4 = true;
                    lstClickerUpgrades.Items.Remove(lstClickerUpgrades.SelectedItem);
                    eggCounter = eggCounter - 100000;
                    return;
                }
                
            }
            if (lstClickerUpgrades.SelectedItem.ToString() == "Clicker 5 (1000000 Eggs)")
            {
                if (eggCounter > 1000000)
                {
                    clickerPwr = clickerPwr + 5000;
                    clicker5 = true;
                    lstClickerUpgrades.Items.Remove(lstClickerUpgrades.SelectedItem);
                    eggCounter = eggCounter - 1000000;
                    return;
                }
                
            }
        }

        private void btnEgg_Click(object sender, RoutedEventArgs e)
        {
            eggCounter = eggCounter + clickerPwr;
            lblEggCount.Content = eggCounter.ToString();

            EggAnimation();
        }

        private async void EggAnimation()
        {

            if (animDone == true)
            {
                animDone = false;
                imgEgg.Width = imgEgg.Width + 5;
                imgEgg.Height = imgEgg.Height + 5;
                imgEgg.Margin = new Thickness(imgEgg.Margin.Left - 2.5, imgEgg.Margin.Top - 3, 0, 0);

                await Task.Delay(TimeSpan.FromMilliseconds(100));

                imgEgg.Width = imgEgg.Width - 5;
                imgEgg.Height = imgEgg.Height - 5;
                imgEgg.Margin = new Thickness(imgEgg.Margin.Left + 2.5, imgEgg.Margin.Top + 3, 0, 0);
                animDone = true;
            }

        }

        private void btnSalt_Click(object sender, RoutedEventArgs e)
        {
            if (eggCounter >= saltPrice)
            {
                eggCounter = eggCounter - saltPrice;
                salt++;
                SoundPlayer buySound = new SoundPlayer("buy.wav");
                buySound.Play();
            }
        }

        private void btnCheese_Click(object sender, RoutedEventArgs e)
        {
            if (eggCounter >= cheesePrice)
            {
                eggCounter = eggCounter - cheesePrice;
                cheese++;
                SoundPlayer buySound = new SoundPlayer("buy.wav");
                buySound.Play();
            }
        }

        private void btnPan_Click(object sender, RoutedEventArgs e)
        {
            if (eggCounter >= panPrice)
            {
                eggCounter = eggCounter - panPrice;
                pan++;
                SoundPlayer buySound = new SoundPlayer("buy.wav");
                buySound.Play();
            }
        }

        private void btnGoldenEgg_Click(object sender, RoutedEventArgs e)
        {
            if (eggCounter >= goldenPrice)
            {
                eggCounter = eggCounter - goldenPrice;
                goldenEgg++;
                SoundPlayer buySound = new SoundPlayer("buy.wav");
                buySound.Play();
            }
        }

        //eggs per second
        private async void EggsPerSecond()
        {
            while (true)
            {
                lblEPS.Content = (salt * 1) + (cheese * 10) + (pan * 50) + (goldenEgg * 100) + " eggs/sec";
                lblEggPwr.Content = clickerPwr.ToString();
                lblSaltCount.Content = salt.ToString();
                lblCheeseCount.Content = cheese.ToString();
                lblPanCount.Content = pan.ToString();
                lblGoldenEggCount.Content = goldenEgg.ToString();
                await Task.Delay(TimeSpan.FromMilliseconds(1));

            }
        }

        //upgrade prices
        private async void UpgradePrices()
        {
            while (true)
            {
                if (salt > 0)
                {
                    saltPrice = (salt + 1) * 50;
                }
                if (cheese > 0)
                {
                    cheesePrice = (cheese + 1) * 500;
                }
                if (pan > 0)
                {
                    panPrice = (pan + 1) * 5000;
                }
                if (goldenEgg > 0)
                {
                    goldenPrice = (goldenEgg + 1) * 50000;
                }
                lblSaltCost.Content = saltPrice.ToString();
                lblCheeseCost.Content = cheesePrice.ToString();
                lblPanCost.Content = panPrice.ToString();
                lblGoldenEggCost.Content = goldenPrice.ToString();
                await Task.Delay(TimeSpan.FromMilliseconds(1));
            }

        }
    }
}
