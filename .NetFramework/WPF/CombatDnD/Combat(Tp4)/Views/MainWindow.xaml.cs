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
using Combat_Tp4_.Models.Personnages;
using Combat_Tp4_.Models;
using System.Windows.Threading;
using System.Threading;

namespace Combat_Tp4_
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Champs
        private Archer _archer = new Archer();
        private Blanc _MageBlanc = new Blanc();
        private CBlanc _CheBlanc = new CBlanc();
        private CNoir _CheNoir = new CNoir();
        private Noir _MageNoir = new Noir();
        private Arène _Arène = new Arène();
        private List<Personnage> _Personnages = new List<Personnage>();
        private List<Personnage> _Personnages2 = new List<Personnage>();
        private List<Personnage> _Personnages3 = new List<Personnage>();
        private Thread _thread = null;
        private Thread _thread1 = null;
        private bool round1 = false;
        private bool round2 = false;
        private bool round3 = false;
        private bool _bExecution = false;
        private bool _bExecution1 = false;
        private string _Archer = "pack://application:,,,/images/Archer.jpg";
        private string _ChevalierB = "pack://application:,,,/images/Chevalier Blanc.jpg";
        private string _ChevalierN = "pack://application:,,,/images/Chevalier Noir.png";
        private string _MageB = "pack://application:,,,/images/Mage Blanc.png";
        private string _MageN = "pack://application:,,,/images/Mage Noir.jpg";
        private bool combat1 = false;
        private bool combat2 = false;
        private bool combat3 = false;
        private bool combat4 = false;
        private bool combat5 = false;
        private bool combat6 = false;
        private bool combat7 = false;
        int iTemp = 5000;
        Random _rnd = new Random();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _Personnages = _Arène.création();
            Images(imgCombattant_1, 0);
            Images(imgCombattant_2, 1);
            Images(imgCombattant_3, 2);
            Images(imgCombattant_4, 3);
            Images(imgCombattant_5, 4);
            Images(imgCombattant_6, 5);
            Images(imgCombattant_7, 6);
            Images(imgCombattant_8, 7);
            round1 = true;
            Stats();

        }
        private void Images(Image control, int iPerso)
        {
            if (_Personnages[iPerso].GetType() == _archer.GetType())
                control.Source = new BitmapImage(new Uri(_Archer));
            else if (_Personnages[iPerso].GetType() == _CheBlanc.GetType())
                control.Source = new BitmapImage(new Uri(_ChevalierB));
            else if (_Personnages[iPerso].GetType() == _CheNoir.GetType())
                control.Source = new BitmapImage(new Uri(_ChevalierN));
            else if (_Personnages[iPerso].GetType() == _MageBlanc.GetType())
                control.Source = new BitmapImage(new Uri(_MageB));
            else if (_Personnages[iPerso].GetType() == _MageNoir.GetType())
                control.Source = new BitmapImage(new Uri(_MageN));
        }
        private void Stats()
        {
            //while (_bExecution)
            //{
            Dispatcher.Invoke(delegate ()
            {
                    txtPvCombattant_1.Text = _Personnages[0].Point_de_vie.ToString();
                    txtExpCombattant_1.Text = _Personnages[0].Expérience.ToString();
                    txtAttCombattant_1.Text = _Personnages[0].Dommage_Max.ToString();
                    txtDéfCombattant_1.Text = _Personnages[0].Classe_Armure.ToString();
                    txtLvlCombattant_1.Text = _Personnages[0].Niveau.ToString();

                    txtPvCombattant_2.Text = _Personnages[1].Point_de_vie.ToString();
                    txtExpCombattant_2.Text = _Personnages[1].Expérience.ToString();
                    txtAttCombattant_2.Text = _Personnages[1].Dommage_Max.ToString();
                    txtDéfCombattant_2.Text = _Personnages[1].Classe_Armure.ToString();
                    txtLvlCombattant_2.Text = _Personnages[1].Niveau.ToString();

                    txtPvCombattant_3.Text = _Personnages[2].Point_de_vie.ToString();
                    txtExpCombattant_3.Text = _Personnages[2].Expérience.ToString();
                    txtAttCombattant_3.Text = _Personnages[2].Dommage_Max.ToString();
                    txtDéfCombattant_3.Text = _Personnages[2].Classe_Armure.ToString();
                    txtLvlCombattant_3.Text = _Personnages[2].Niveau.ToString();

                    txtPvCombattant_4.Text = _Personnages[3].Point_de_vie.ToString();
                    txtExpCombattant_4.Text = _Personnages[3].Expérience.ToString();
                    txtAttCombattant_4.Text = _Personnages[3].Dommage_Max.ToString();
                    txtDéfCombattant_4.Text = _Personnages[3].Classe_Armure.ToString();
                    txtLvlCombattant_4.Text = _Personnages[3].Niveau.ToString();

                    txtPvCombattant_5.Text = _Personnages[4].Point_de_vie.ToString();
                    txtExpCombattant_5.Text = _Personnages[4].Expérience.ToString();
                    txtAttCombattant_5.Text = _Personnages[4].Dommage_Max.ToString();
                    txtDéfCombattant_5.Text = _Personnages[4].Classe_Armure.ToString();
                    txtLvlCombattant_5.Text = _Personnages[4].Niveau.ToString();

                    txtPvCombattant_6.Text = _Personnages[5].Point_de_vie.ToString();
                    txtExpCombattant_6.Text = _Personnages[5].Expérience.ToString();
                    txtAttCombattant_6.Text = _Personnages[5].Dommage_Max.ToString();
                    txtDéfCombattant_6.Text = _Personnages[5].Classe_Armure.ToString();
                    txtLvlCombattant_6.Text = _Personnages[5].Niveau.ToString();

                    txtPvCombattant_7.Text = _Personnages[6].Point_de_vie.ToString();
                    txtExpCombattant_7.Text = _Personnages[6].Expérience.ToString();
                    txtAttCombattant_7.Text = _Personnages[6].Dommage_Max.ToString();
                    txtDéfCombattant_7.Text = _Personnages[6].Classe_Armure.ToString();
                    txtLvlCombattant_7.Text = _Personnages[6].Niveau.ToString();

                    txtPvCombattant_8.Text = _Personnages[7].Point_de_vie.ToString();
                    txtExpCombattant_8.Text = _Personnages[7].Expérience.ToString();
                    txtAttCombattant_8.Text = _Personnages[7].Dommage_Max.ToString();
                    txtDéfCombattant_8.Text = _Personnages[7].Classe_Armure.ToString();
                    txtLvlCombattant_8.Text = _Personnages[7].Niveau.ToString();

                if (int.Parse(txtPvCombattant_1.Text) <= 0)
                {
                    txtPvCombattant_1.Background = Brushes.Red;
                    txtPvCombattant_1.Foreground = Brushes.White;
                }
                if (int.Parse(txtPvCombattant_2.Text) <= 0)
                {
                    txtPvCombattant_2.Background = Brushes.Red;
                    txtPvCombattant_2.Foreground = Brushes.White;
                }
                if (int.Parse(txtPvCombattant_3.Text) <= 0)
                {
                    txtPvCombattant_3.Background = Brushes.Red;
                    txtPvCombattant_3.Foreground = Brushes.White;
                }
                if (int.Parse(txtPvCombattant_4.Text) <= 0)
                {
                    txtPvCombattant_4.Background = Brushes.Red;
                    txtPvCombattant_4.Foreground = Brushes.White;
                }
                if (int.Parse(txtPvCombattant_5.Text) <= 0)
                {
                    txtPvCombattant_5.Background = Brushes.Red;
                    txtPvCombattant_5.Foreground = Brushes.White;
                }
                if (int.Parse(txtPvCombattant_6.Text) <= 0)
                {
                    txtPvCombattant_6.Background = Brushes.Red;
                    txtPvCombattant_6.Foreground = Brushes.White;
                }
                if (int.Parse(txtPvCombattant_7.Text) <= 0)
                {
                    txtPvCombattant_7.Background = Brushes.Red;
                    txtPvCombattant_7.Foreground = Brushes.White;
                }
                if (int.Parse(txtPvCombattant_8.Text) <= 0)
                {
                    txtPvCombattant_8.Background = Brushes.Red;
                    txtPvCombattant_8.Foreground = Brushes.White;
                }

                if (int.Parse(txtPvCombattant_1.Text) > 0)
                {
                    txtPvCombattant_1.Background = Brushes.White;
                    txtPvCombattant_1.Foreground = Brushes.Black;
                }
                if (int.Parse(txtPvCombattant_2.Text) > 0)
                {
                    txtPvCombattant_2.Background = Brushes.White;
                    txtPvCombattant_2.Foreground = Brushes.Black;
                }
                if (int.Parse(txtPvCombattant_3.Text) > 0)
                {
                    txtPvCombattant_3.Background = Brushes.White;
                    txtPvCombattant_3.Foreground = Brushes.Black;
                }
                if (int.Parse(txtPvCombattant_4.Text) > 0)
                {
                    txtPvCombattant_4.Background = Brushes.White;
                    txtPvCombattant_4.Foreground = Brushes.Black;
                }
                if (int.Parse(txtPvCombattant_5.Text) > 0)
                {
                    txtPvCombattant_5.Background = Brushes.White;
                    txtPvCombattant_5.Foreground = Brushes.Black;
                }
                if (int.Parse(txtPvCombattant_6.Text) > 0)
                {
                    txtPvCombattant_6.Background = Brushes.White;
                    txtPvCombattant_6.Foreground = Brushes.Black;
                }
                if (int.Parse(txtPvCombattant_7.Text) > 0)
                {
                    txtPvCombattant_7.Background = Brushes.White;
                    txtPvCombattant_7.Foreground = Brushes.Black;
                }
                if (int.Parse(txtPvCombattant_8.Text) > 0)
                {
                    txtPvCombattant_8.Background = Brushes.White;
                    txtPvCombattant_8.Foreground = Brushes.Black;
                }
            });
            //}
        }
        private void Combat()
        {
            while (_Personnages[0].bFin != true && _Personnages[1].bFin != true && _Personnages[2].bFin != true && _Personnages[3].bFin != true && _Personnages[4].bFin != true && _Personnages[5].bFin != true && _Personnages[6].bFin != true && _Personnages[7].bFin != true)
            {
                while (_Personnages[0].Point_de_vie > 0 && _Personnages[1].Point_de_vie > 0 && (_Personnages[0].bFin == false || _Personnages[1].bFin == false))
                {
                    if (_Personnages[0].Point_de_vie > 0 && _Personnages[1].Point_de_vie > 0)
                    {
                        if (_Personnages[0].Point_de_vie > 0)
                        {
                            if (_Personnages[1].Point_de_vie > 0)
                            {
                                _Personnages[0].Attaquer(_Personnages[0], _Personnages[1], _rnd.Next(1, 20));
                                if (_Personnages[1].Point_de_vie < 0)
                                    _Personnages[1].Point_de_vie = 0;
                                Stats();
                            }
                        }
                        if (_Personnages[1].Point_de_vie == 0)
                        {
                            _Personnages[0].AjouterExpérience(_Personnages[0].Expérience, _Personnages[0], _Personnages[1]);
                            _Personnages2.Add(_Personnages[0]);
                        }
                        if (_Personnages[0].Point_de_vie == 0)
                        {
                            _Personnages[1].AjouterExpérience(_Personnages[1].Expérience, _Personnages[1], _Personnages[0]);
                            _Personnages2.Add(_Personnages[1]);

                        }

                        Thread.Sleep(iTemp);
                        if (_Personnages[1].Point_de_vie > 0)
                        {
                            if (_Personnages[0].Point_de_vie > 0)
                            {
                                _Personnages[1].Attaquer(_Personnages[1], _Personnages[0], _rnd.Next(1, 20));
                                if (_Personnages[0].Point_de_vie < 0)
                                    _Personnages[0].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages[0].Point_de_vie == 0)
                            {
                                _Personnages[1].AjouterExpérience(_Personnages[1].Expérience, _Personnages[1], _Personnages[0]);
                                _Personnages2.Add(_Personnages[1]);
                            }
                        }
                    }
                }

                while (_Personnages[2].Point_de_vie > 0 && _Personnages[3].Point_de_vie > 0 && (_Personnages[2].bFin == false || _Personnages[3].bFin == false))
                {
                    if (_Personnages[2].Point_de_vie > 0 && _Personnages[3].Point_de_vie > 0)
                    {
                        if (_Personnages[2].Point_de_vie > 0)
                        {
                            if (_Personnages[3].Point_de_vie > 0)
                            {
                                _Personnages[2].Attaquer(_Personnages[2], _Personnages[3], _rnd.Next(1, 20));
                                if (_Personnages[3].Point_de_vie < 0)
                                    _Personnages[3].Point_de_vie = 0;
                                Stats();
                            }
                        }
                        if (_Personnages[3].Point_de_vie == 0)
                        {
                            _Personnages[2].AjouterExpérience(_Personnages[2].Expérience, _Personnages[2], _Personnages[3]);
                            _Personnages2.Add(_Personnages[2]);
                        }
                        if (_Personnages[2].Point_de_vie == 0)
                        {
                            _Personnages[3].AjouterExpérience(_Personnages[3].Expérience, _Personnages[3], _Personnages[2]);
                            _Personnages2.Add(_Personnages[3]);
                        }

                        Thread.Sleep(iTemp);
                        if (_Personnages[3].Point_de_vie > 0)
                        {
                            if (_Personnages[2].Point_de_vie > 0)
                            {
                                _Personnages[3].Attaquer(_Personnages[3], _Personnages[2], _rnd.Next(1, 20));
                                if (_Personnages[2].Point_de_vie < 0)
                                    _Personnages[2].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages[2].Point_de_vie == 0)
                            {
                                _Personnages[3].AjouterExpérience(_Personnages[3].Expérience, _Personnages[3], _Personnages[2]);
                                _Personnages2.Add(_Personnages[3]);
                            }
                        }
                    }
                }
                while (_Personnages[4].Point_de_vie > 0 && _Personnages[5].Point_de_vie > 0 && (_Personnages[4].bFin == false || _Personnages[5].bFin == false))
                {
                    if (_Personnages[4].Point_de_vie > 0 && _Personnages[5].Point_de_vie > 0)
                    {
                        if (_Personnages[4].Point_de_vie > 0)
                        {
                            if (_Personnages[5].Point_de_vie > 0)
                            {
                                _Personnages[4].Attaquer(_Personnages[4], _Personnages[5], _rnd.Next(1, 20));
                                if (_Personnages[5].Point_de_vie < 0)
                                    _Personnages[5].Point_de_vie = 0;
                                Stats();
                            }
                        }
                        if (_Personnages[5].Point_de_vie == 0)
                            {
                                _Personnages[4].AjouterExpérience(_Personnages[4].Expérience, _Personnages[4], _Personnages[5]);
                                _Personnages2.Add(_Personnages[4]);
                            }
                        if (_Personnages[4].Point_de_vie == 0)
                        {
                            _Personnages[5].AjouterExpérience(_Personnages[5].Expérience, _Personnages[5], _Personnages[4]);
                            _Personnages2.Add(_Personnages[5]);
                        }

                        Thread.Sleep(iTemp);
                        if (_Personnages[5].Point_de_vie > 0)
                        {
                            if (_Personnages[4].Point_de_vie > 0)
                            {
                                _Personnages[5].Attaquer(_Personnages[5], _Personnages[4], _rnd.Next(1, 20));
                                if (_Personnages[4].Point_de_vie < 0)
                                    _Personnages[4].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages[4].Point_de_vie == 0)
                            {
                                _Personnages[5].AjouterExpérience(_Personnages[5].Expérience, _Personnages[5], _Personnages[4]);
                                _Personnages2.Add(_Personnages[5]);
                            }
                        }
                    }
                }
                while (_Personnages[6].Point_de_vie > 0 && _Personnages[7].Point_de_vie > 0 && (_Personnages[6].bFin == false || _Personnages[7].bFin == false))
                {
                    if (_Personnages[6].Point_de_vie > 0 && _Personnages[7].Point_de_vie > 0)
                    {
                        if (_Personnages[6].Point_de_vie > 0)
                        {
                            if (_Personnages[7].Point_de_vie > 0)
                            {
                                _Personnages[6].Attaquer(_Personnages[6], _Personnages[7], _rnd.Next(1, 20));
                                if (_Personnages[7].Point_de_vie < 0)
                                    _Personnages[7].Point_de_vie = 0;
                                Stats();
                            }
                        }
                        if (_Personnages[7].Point_de_vie == 0)
                        {
                            _Personnages[6].AjouterExpérience(_Personnages[6].Expérience, _Personnages[6], _Personnages[7]);
                            _Personnages2.Add(_Personnages[6]);
                        }
                        if (_Personnages[6].Point_de_vie == 0)
                        {
                            _Personnages[7].AjouterExpérience(_Personnages[7].Expérience, _Personnages[7], _Personnages[6]);
                            _Personnages2.Add(_Personnages[7]);
                        }

                        Thread.Sleep(iTemp);
                        if (_Personnages[7].Point_de_vie > 0)
                        {
                            if (_Personnages[6].Point_de_vie > 0)
                            {
                                _Personnages[7].Attaquer(_Personnages[7], _Personnages[6], _rnd.Next(1, 20));
                                if (_Personnages[6].Point_de_vie < 0)
                                    _Personnages[6].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages[6].Point_de_vie == 0)
                            {
                                _Personnages[7].AjouterExpérience(_Personnages[7].Expérience, _Personnages[7], _Personnages[6]);
                                _Personnages2.Add(_Personnages[7]);
                            }
                        }
                    }
                }
                round1 = false;
                round2 = true;
                //série 2
                while (_Personnages2[0].Point_de_vie > 0 && _Personnages2[1].Point_de_vie > 0 && (_Personnages2[0].bFin == false || _Personnages2[1].bFin == false))
                {
                    if (_Personnages2[0].Point_de_vie > 0 && _Personnages2[1].Point_de_vie > 0)
                    {
                        if (_Personnages2[0].Point_de_vie > 0)
                        {
                            if (_Personnages2[1].Point_de_vie > 0)
                            {
                                _Personnages2[0].Attaquer(_Personnages2[0], _Personnages2[1], _rnd.Next(1, 20));
                                if (_Personnages2[1].Point_de_vie < 0)
                                    _Personnages2[1].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages2[1].Point_de_vie == 0)
                            {
                                _Personnages2[0].AjouterExpérience(_Personnages2[0].Expérience, _Personnages2[0], _Personnages2[1]);
                                _Personnages3.Add(_Personnages2[0]);
                            }
                        }
                        else if (_Personnages2[0].Point_de_vie == 0)
                        {
                            _Personnages2[1].AjouterExpérience(_Personnages2[1].Expérience, _Personnages2[1], _Personnages2[0]);
                            _Personnages3.Add(_Personnages2[1]);
                        }
                        Thread.Sleep(iTemp);
                        if (_Personnages2[1].Point_de_vie > 0)
                        {
                            if (_Personnages2[0].Point_de_vie > 0)
                            {
                                _Personnages2[1].Attaquer(_Personnages2[1], _Personnages2[0], _rnd.Next(1, 20));
                                if (_Personnages2[0].Point_de_vie < 0)
                                    _Personnages2[0].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages2[0].Point_de_vie == 0)
                            {
                                _Personnages2[1].AjouterExpérience(_Personnages2[1].Expérience, _Personnages2[1], _Personnages2[0]);
                                _Personnages3.Add(_Personnages2[1]);
                            }
                        }
                    }
                }
                while (_Personnages2[2].Point_de_vie > 0 && _Personnages2[3].Point_de_vie > 0 && (_Personnages2[2].bFin == false || _Personnages2[3].bFin == false))
                {
                    if (_Personnages2[2].Point_de_vie > 0 && _Personnages2[3].Point_de_vie > 0)
                    {
                        if (_Personnages2[2].Point_de_vie > 0)
                        {
                            if (_Personnages2[3].Point_de_vie > 0)
                            {
                                _Personnages2[2].Attaquer(_Personnages2[2], _Personnages2[3], _rnd.Next(1, 20));
                                if (_Personnages2[3].Point_de_vie < 0)
                                    _Personnages2[3].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages2[3].Point_de_vie == 0)
                            {
                                _Personnages2[2].AjouterExpérience(_Personnages2[2].Expérience, _Personnages2[2], _Personnages2[3]);
                                _Personnages3.Add(_Personnages2[2]);
                            }
                        }
                        else if (_Personnages2[2].Point_de_vie == 0)
                        {
                            _Personnages2[3].AjouterExpérience(_Personnages2[3].Expérience, _Personnages2[3], _Personnages2[2]);
                            _Personnages3.Add(_Personnages2[3]);
                        }
                        Thread.Sleep(iTemp);
                        if (_Personnages2[3].Point_de_vie > 0)
                        {
                            if (_Personnages2[2].Point_de_vie > 0)
                            {
                                _Personnages2[3].Attaquer(_Personnages2[3], _Personnages2[2], _rnd.Next(1, 20));
                                if (_Personnages2[2].Point_de_vie < 0)
                                    _Personnages2[2].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages2[2].Point_de_vie == 0)
                            {
                                _Personnages2[3].AjouterExpérience(_Personnages2[3].Expérience, _Personnages2[3], _Personnages2[2]);
                                _Personnages3.Add(_Personnages2[3]);
                            }
                        }
                    }
                }
                round2 = false;
                round3 = true;
                while (_Personnages3[0].Point_de_vie > 0 && _Personnages3[1].Point_de_vie > 0 && (_Personnages3[0].bFin == false || _Personnages3[1].bFin == false))
                {
                    if (_Personnages3[0].Point_de_vie > 0 && _Personnages3[1].Point_de_vie > 0)
                    {
                        if (_Personnages3[0].Point_de_vie > 0)
                        {
                            if (_Personnages3[1].Point_de_vie > 0)
                            {
                                _Personnages3[0].Attaquer(_Personnages3[0], _Personnages3[1], _rnd.Next(1, 20));
                                if (_Personnages3[1].Point_de_vie < 0)
                                    _Personnages3[1].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages3[1].Point_de_vie == 0)
                            {
                                _Personnages3[0].AjouterExpérience(_Personnages3[0].Expérience, _Personnages3[0], _Personnages3[1]);
                                _Personnages3[0].Victoires.Add(_Personnages3[0]);
                            }
                        }
                        else if (_Personnages3[0].Point_de_vie == 0)
                        {
                            _Personnages3[1].AjouterExpérience(_Personnages3[1].Expérience, _Personnages3[1], _Personnages3[0]);
                            _Personnages3[1].Victoires.Add(_Personnages3[1]);
                        }
                        Thread.Sleep(iTemp);
                        if (_Personnages3[1].Point_de_vie > 0)
                        {
                            if (_Personnages2[0].Point_de_vie > 0)
                            {
                                _Personnages3[1].Attaquer(_Personnages3[1], _Personnages3[0], _rnd.Next(1, 20));
                                if (_Personnages2[0].Point_de_vie < 0)
                                    _Personnages2[0].Point_de_vie = 0;
                                Stats();
                            }
                            if (_Personnages3[0].Point_de_vie == 0)
                            {
                                _Personnages3[1].AjouterExpérience(_Personnages3[1].Expérience, _Personnages3[1], _Personnages3[0]);
                                _Personnages3[1].Victoires.Add(_Personnages3[1]);
                            }
                        }
                        else if (_Personnages3[1].Point_de_vie == 0)
                        {
                            _Personnages3[0].AjouterExpérience(_Personnages3[0].Expérience, _Personnages3[0], _Personnages3[1]);
                            _Personnages3[0].Victoires.Add(_Personnages3[0]);
                        }
                    }
                }
                round3 = false;

                foreach (var perso in _Personnages)
                {
                    if (perso.GetType() == _archer.GetType())
                    {
                        perso.Point_de_vie = 17;
                    }
                    if (perso.GetType() == _CheBlanc.GetType())
                    {
                        perso.Point_de_vie = 20;
                    }
                    if (perso.GetType() == _CheNoir.GetType())
                    {
                        perso.Point_de_vie = 20;
                    }
                    if (perso.GetType() == _MageBlanc.GetType())
                    {
                        perso.Point_de_vie = 25;
                    }
                    if (perso.GetType() == _MageNoir.GetType())
                    {
                        perso.Point_de_vie = 18;
                    }
                    round1 = true;
                }
                _Personnages2.Clear();
                _Personnages3.Clear();
            }

            string sTexte = "";
            int iPos = 8;

            var req = from personnages in _Personnages
                      orderby personnages.Niveau ascending, personnages.Expérience ascending
                      select new
                      {
                          personnages.Nom,personnages.Niveau,personnages.Expérience
                      };
            foreach (var perso in req)
            {
                sTexte += iPos+"."+ perso.Niveau + "." + perso.Nom +"Exp: "+perso.Expérience+ "\n";
                iPos--;
            }
            MessageBox.Show(sTexte,"Résultats");
        }
        private void FermerThread()
        {
            //fermer le thread
            if (_thread != null && _thread.IsAlive)
            {
                _bExecution = false;
                _thread.Abort();
            }
            if (_thread1 != null && _thread1.IsAlive)
            {
                _bExecution1 = false;
                _thread1.Abort();
            }
        }
        private void btnDémarrer_Click(object sender, RoutedEventArgs e)
        {
            if (_thread1 == null || !_thread1.IsAlive)
            {
                _bExecution1 = true;
                _thread1 = new Thread(new ThreadStart(Combat));
                _bExecution = true;
                _thread1.Start();
            }
            if (chkCombatsRapide.IsChecked == true)
            {
                iTemp = 50;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FermerThread();
        }
    }
}
