using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PhysicsUnitsMobile
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool coulombEnabled;
        private bool divide;
        private bool dividePressed;
        private bool faradEnabled;
        private bool henryEnabled;
        private bool hertzEnabled;
        private bool jouleEnabled;
        private bool newtonEnabled;
        private bool ohmEnabled;
        private bool pascalEnabled;
        private bool siemensEnabled;
        private bool teslaEnabled;
        private bool voltEnabled;
        private bool wattEnabled;
        private bool weberEnabled;
        private ICommand ampereCommand;
        private ICommand coulombCommand;
        private ICommand divideCommand;
        private ICommand faradCommand;
        private ICommand henryCommand;
        private ICommand hertzCommand;
        private ICommand jouleCommand;
        private ICommand kilogramCommand;
        private ICommand meterCommand;
        private ICommand newtonCommand;
        private ICommand ohmCommand;
        private ICommand pascalCommand;
        private ICommand resetCommand;
        private ICommand secondCommand;
        private ICommand siemensCommand;
        private ICommand teslaCommand;
        private ICommand voltCommand;
        private ICommand wattCommand;
        private ICommand weberCommand;
        private int amperesFactor;
        private int kilogramsFactor;
        private int metersFactor;
        private int secondsFactor;
        private string abbreviation;
        private string formula;
        private string measurement;

        public MainViewModel()
        {
            MessagingCenter.Subscribe<IKeyboardListener, string>(this, "KeyboardListener", (sender, e) =>
            {
                switch (e)
                {
                    case "Number0":
                        ResetAction();
                        break;
                    case "A":
                        AmpereAction();
                        break;
                    case "B":
                        if (WeberEnabled)
                            WeberAction();
                        break;
                    case "C":
                        if (CoulombEnabled)
                            CoulombAction();
                        break;
                    case "F":
                        if (FaradEnabled)
                            FaradAction();
                        break;
                    case "G":
                        if (SiemensEnabled)
                            SiemensAction();
                        break;
                    case "H":
                        if (HenryEnabled)
                            HenryAction();
                        break;
                    case "J":
                        if (JouleEnabled)
                            JouleAction();
                        break;
                    case "K":
                        KilogramAction();
                        break;
                    case "M":
                        MeterAction();
                        break;
                    case "N":
                        if (NewtonEnabled)
                            NewtonAction();
                        break;
                    case "O":
                        if (OhmEnabled)
                            OhmAction();
                        break;
                    case "P":
                        if (PascalEnabled)
                            PascalAction();
                        break;
                    case "S":
                        SecondAction();
                        break;
                    case "T":
                        if (TeslaEnabled)
                            TeslaAction();
                        break;
                    case "V":
                        if (VoltEnabled)
                            VoltAction();
                        break;
                    case "W":
                        if (WattEnabled)
                            WattAction();
                        break;
                    case "Z":
                        if (HertzEnabled)
                            HertzAction();
                        break;
                    case "191":
                        DivideAction();
                        break;
                }
            });
        }

        public string Abbreviation
        {
            get => abbreviation;
            set => SetProperty(ref abbreviation, value);
        }

        public bool CoulombEnabled
        {
            get => coulombEnabled;
            set => SetProperty(ref coulombEnabled, value);
        }

        public bool DividePressed
        {
            get => dividePressed;
            set => SetProperty(ref dividePressed, value);
        }

        public bool FaradEnabled
        {
            get => faradEnabled;
            set => SetProperty(ref faradEnabled, value);
        }

        public string Formula
        {
            get => formula;
            set => SetProperty(ref formula, value);
        }

        public bool HenryEnabled
        {
            get => henryEnabled;
            set => SetProperty(ref henryEnabled, value);
        }

        public bool HertzEnabled
        {
            get => hertzEnabled;
            set => SetProperty(ref hertzEnabled, value);
        }

        public bool JouleEnabled
        {
            get => jouleEnabled;
            set => SetProperty(ref jouleEnabled, value);
        }

        public string Measurement
        {
            get => measurement;
            set => SetProperty(ref measurement, value);
        }

        public bool NewtonEnabled
        {
            get => newtonEnabled;
            set => SetProperty(ref newtonEnabled, value);
        }

        public bool OhmEnabled
        {
            get => ohmEnabled;
            set => SetProperty(ref ohmEnabled, value);
        }

        public bool PascalEnabled
        {
            get => pascalEnabled;
            set => SetProperty(ref pascalEnabled, value);
        }

        public bool SiemensEnabled
        {
            get => siemensEnabled;
            set => SetProperty(ref siemensEnabled, value);
        }

        public bool TeslaEnabled
        {
            get => teslaEnabled;
            set => SetProperty(ref teslaEnabled, value);
        }

        public bool VoltEnabled
        {
            get => voltEnabled;
            set => SetProperty(ref voltEnabled, value);
        }

        public bool WattEnabled
        {
            get => wattEnabled;
            set => SetProperty(ref wattEnabled, value);
        }

        public bool WeberEnabled
        {
            get => weberEnabled;
            set => SetProperty(ref weberEnabled, value);
        }

        public ICommand AmpereCommand => ampereCommand ?? (ampereCommand = new Command(AmpereAction));
        private void AmpereAction()
        {
            amperesFactor += divide ? -1 : 1;
            DisplayFormula();
        }

        public ICommand CoulombCommand => coulombCommand ?? (coulombCommand = new Command(CoulombAction));
        private void CoulombAction()
        {
            secondsFactor += divide ? -1 : 1;
            amperesFactor += divide ? -1 : 1;
            DisplayFormula();
        }

        public ICommand DivideCommand => divideCommand ?? (divideCommand = new Command(DivideAction));
        private void DivideAction()
        {
            if (!divide)
            {
                DividePressed = true;
                divide = true;
            }
            else
            {
                UnsetDivide();
            }
        }

        public ICommand FaradCommand => faradCommand ?? (faradCommand = new Command(FaradAction));
        private void FaradAction()
        {
            kilogramsFactor += divide ? 1 : -1;
            metersFactor += divide ? 2 : -2;
            secondsFactor += divide ? -4 : 4;
            amperesFactor += divide ? -2 : 2;
            DisplayFormula();
        }

        public ICommand HenryCommand => henryCommand ?? (henryCommand = new Command(HenryAction));
        private void HenryAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            metersFactor += divide ? -2 : 2;
            secondsFactor += divide ? 2 : -2;
            amperesFactor += divide ? 2 : -2;
            DisplayFormula();
        }

        public ICommand HertzCommand => hertzCommand ?? (hertzCommand = new Command(HertzAction));
        private void HertzAction()
        {
            secondsFactor += divide ? 1 : -1;
            DisplayFormula();
        }

        public ICommand JouleCommand => jouleCommand ?? (jouleCommand = new Command(JouleAction));
        private void JouleAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            metersFactor += divide ? -2 : 2;
            secondsFactor += divide ? 2 : -2;
            DisplayFormula();
        }

        public ICommand KilogramCommand => kilogramCommand ?? (kilogramCommand = new Command(KilogramAction));
        private void KilogramAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            DisplayFormula();
        }

        public ICommand MeterCommand => meterCommand ?? (meterCommand = new Command(MeterAction));
        private void MeterAction()
        {
            metersFactor += divide ? -1 : 1;
            DisplayFormula();
        }

        public ICommand NewtonCommand => newtonCommand ?? (newtonCommand = new Command(NewtonAction));
        private void NewtonAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            metersFactor += divide ? -1 : 1;
            secondsFactor += divide ? 2 : -2;
            DisplayFormula();
        }

        public ICommand OhmCommand => ohmCommand ?? (ohmCommand = new Command(OhmAction));
        private void OhmAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            metersFactor += divide ? -2 : 2;
            secondsFactor += divide ? 3 : -3;
            amperesFactor += divide ? 2 : -2;
            DisplayFormula();
        }

        public ICommand PascalCommand => pascalCommand ?? (pascalCommand = new Command(PascalAction));
        private void PascalAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            metersFactor += divide ? 1 : -1;
            secondsFactor += divide ? 2 : -2;
            DisplayFormula();
        }

        public ICommand ResetCommand => resetCommand ?? (resetCommand = new Command(ResetAction));
        private void ResetAction()
        {
            kilogramsFactor = 0;
            metersFactor = 0;
            secondsFactor = 0;
            amperesFactor = 0;
            DisplayFormula();
        }

        public ICommand SecondCommand => secondCommand ?? (secondCommand = new Command(SecondAction));
        private void SecondAction()
        {
            secondsFactor += divide ? -1 : 1;
            DisplayFormula();
        }

        public ICommand SiemensCommand => siemensCommand ?? (siemensCommand = new Command(SiemensAction));
        private void SiemensAction()
        {
            kilogramsFactor += divide ? 1 : -1;
            metersFactor += divide ? 2 : -2;
            secondsFactor += divide ? -3 : 3;
            amperesFactor += divide ? -2 : 2;
            DisplayFormula();
        }

        public ICommand TeslaCommand => teslaCommand ?? (teslaCommand = new Command(TeslaAction));
        private void TeslaAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            secondsFactor += divide ? 2 : -2;
            amperesFactor += divide ? 1 : -1;
            DisplayFormula();
        }

        public ICommand VoltCommand => voltCommand ?? (voltCommand = new Command(VoltAction));
        private void VoltAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            metersFactor += divide ? -2 : 2;
            secondsFactor += divide ? 3 : -3;
            amperesFactor += divide ? 1 : -1;
            DisplayFormula();
        }

        public ICommand WattCommand => wattCommand ?? (wattCommand = new Command(WattAction));
        private void WattAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            metersFactor += divide ? -2 : 2;
            secondsFactor += divide ? 3 : -3;
            DisplayFormula();
        }

        public ICommand WeberCommand => weberCommand ?? (weberCommand = new Command(WeberAction));
        private void WeberAction()
        {
            kilogramsFactor += divide ? -1 : 1;
            metersFactor += divide ? -2 : 2;
            secondsFactor += divide ? 2 : -2;
            amperesFactor += divide ? 1 : -1;
            DisplayFormula();
        }

        private void DisplayFormula()
        {
            string formula = string.Empty;
            if (kilogramsFactor != 0)
            {
                if (formula.Length > 0)
                    formula += " \x22c5 ";
                formula += "kg";
                if (kilogramsFactor != 1)
                    formula += GetSuperscripts(kilogramsFactor);
            }
            if (metersFactor != 0)
            {
                if (formula.Length > 0)
                    formula += " \x22c5 ";
                formula += "m";
                if (metersFactor != 1)
                    formula += GetSuperscripts(metersFactor);
            }
            if (secondsFactor != 0)
            {
                if (formula.Length > 0)
                    formula += " \x22c5 ";
                formula += "s";
                if (secondsFactor != 1)
                    formula += GetSuperscripts(secondsFactor);
            }
            if (amperesFactor != 0)
            {
                if (formula.Length > 0)
                    formula += " \x22c5 ";
                formula += "A";
                if (amperesFactor != 1)
                    formula += GetSuperscripts(amperesFactor);
            }
            Formula = formula;
            DisplayName();
            UnsetDivide();
        }

        private string GetSuperscripts(int factor)
        {
            string text = factor.ToString()
                .Replace('-', '\x207b')
                .Replace('0', '\x2070')
                .Replace('1', '\x00b9')
                .Replace('2', '\x00b2')
                .Replace('3', '\x00b3')
                .Replace('4', '\x2074')
                .Replace('5', '\x2075')
                .Replace('6', '\x2076')
                .Replace('7', '\x2077')
                .Replace('8', '\x2078')
                .Replace('9', '\x2079');
            return text;
        }

        private void UnsetDivide()
        {
            DividePressed = false;
            divide = false;
        }

        private void DisplayName()
        {
            string abbreviation = string.Empty;
            string measurement = string.Empty;
            if (amperesFactor == 0)
            {
                if (kilogramsFactor == 0)
                {
                    if (metersFactor == 0)
                    {
                        if (secondsFactor == 1)
                        {
                            abbreviation = "s - second";
                            measurement = "time (t)";
                        }
                        else if (secondsFactor == -1)
                        {
                            abbreviation = "Hz - hertz";
                            HertzEnabled = true;
                        }
                    }
                    else if (metersFactor == 1)
                    {
                        if (secondsFactor == 0)
                        {
                            abbreviation = "m - meter";
                            measurement = "displacement (x)";
                        }
                        else if (secondsFactor == -1)
                            measurement = "velocity (v)";
                        else if (secondsFactor == -2)
                            measurement = "acceleration (a)";
                    }
                    else if (metersFactor == 2)
                    {
                        if (secondsFactor == 0)
                            measurement = "area";
                    }
                    else if (metersFactor == 3)
                    {
                        if (secondsFactor == 0)
                            measurement = "volume";
                    }
                }
                else if (kilogramsFactor == 1)
                {
                    if (metersFactor == 0)
                    {
                        if (secondsFactor == 0)
                        {
                            abbreviation = "kg - kilogram";
                            measurement = "mass (m)";
                        }
                    }
                    else if (metersFactor == 1)
                    {
                        if (secondsFactor == -2)
                        {
                            abbreviation = "N - newton";
                            measurement = "force (F)";
                            NewtonEnabled = true;
                        }
                    }
                    else if (metersFactor == 2)
                    {
                        if (secondsFactor == -2)
                        {
                            abbreviation = "J - joule";
                            measurement = "work (W) or energy (E)";
                            JouleEnabled = true;
                        }
                        else if (secondsFactor == -3)
                        {
                            abbreviation = "W - watt";
                            measurement = "energy conversion (W)";
                            WattEnabled = true;
                        }
                    }
                    else if (metersFactor == -1)
                    {
                        if (secondsFactor == -2)
                        {
                            abbreviation = "Pa - pascal";
                            measurement = "pressure (P)";
                            PascalEnabled = true;
                        }
                    }
                }
            }
            else if (amperesFactor == 1)
            {
                if (kilogramsFactor == 0)
                {
                    if (metersFactor == 0)
                    {
                        if (secondsFactor == 0)
                        {
                            abbreviation = "A - ampere";
                            measurement = "current (I)";
                        }
                        else if (secondsFactor == 1)
                        {
                            abbreviation = "C - coulomb";
                            measurement = "charge (q)";
                            CoulombEnabled = true;
                        }
                    }
                }
            }
            else if (amperesFactor == 2)
            {
                if (kilogramsFactor == -1)
                {
                    if (metersFactor == -2)
                    {
                        if (secondsFactor == 3)
                        {
                            abbreviation = "S - siemens";
                            measurement = "electrical conductance (G)";
                            SiemensEnabled = true;
                        }
                        else if (secondsFactor == 4)
                        {
                            abbreviation = "F - farad";
                            measurement = "capacitance (C)";
                            FaradEnabled = true;
                        }
                    }
                    else if (metersFactor == -3)
                    {
                        if (secondsFactor == 3)
                        {
                            measurement = "conductivity (σ)";
                        }
                    }
                }
            }
            else if (amperesFactor == -1)
            {
                if (kilogramsFactor == 1)
                {
                    if (metersFactor == 0)
                    {
                        if (secondsFactor == -2)
                        {
                            abbreviation = "T - tesla";
                            measurement = "magnetic flux density (B)";
                            TeslaEnabled = true;
                        }
                    }
                    else if (metersFactor == 2)
                    {
                        if (secondsFactor == -2)
                        {
                            abbreviation = "Wb - weber";
                            measurement = "magnetic flux (Φ)";
                            WeberEnabled = true;
                        }
                        else if (secondsFactor == -3)
                        {
                            abbreviation = "V - volt";
                            measurement = "voltage (V)";
                            VoltEnabled = true;
                        }
                    }
                }
            }
            else if (amperesFactor == -2)
            {
                if (kilogramsFactor == 1)
                {
                    if (metersFactor == 2)
                    {
                        if (secondsFactor == -3)
                        {
                            abbreviation = "(Omega) - ohm";
                            measurement = "resistance (R)";
                            OhmEnabled = true;
                        }
                        else if (secondsFactor == -2)
                        {
                            abbreviation = "H - henry";
                            measurement = "inductance (L)";
                            HenryEnabled = true;
                        }
                    }
                }
            }
            Abbreviation = abbreviation;
            Measurement = measurement;
        }

        /// <summary>Implements <see cref="INotifyPropertyChanged.PropertyChanged"/>.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the value for a property and fires the <see cref="PropertyChanged"/> event if the value has changed.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="field"/> and <paramref name="value"/> being evaluated.</typeparam>
        /// <param name="field">The backing store variable for the property in question.</param>
        /// <param name="value">The new value to be evaluated and stored if changed.</param>
        /// <param name="name">The name of the property in question. Will populate automatically if left not set.</param>
        /// <returns>A value indicating that the <see cref="PropertyChanged"/> event was invoked.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
