using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class KalkulatorKalorii : Form
    {
        public KalkulatorKalorii()
        {
            InitializeComponent();
        }

        int wiek, wzrost, waga, BodyFat, DniTreningowe, NEAT, TrainingTimeStrength, TrainingTimeCardio;
        double MezczyznaBMR, KobietaBMR, BMR, TEA, TEF, TDEE, FFMI;

        private void KalkulatorKalorii_Load(object sender, EventArgs e)
        {

        }

        private void SportFormula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BfFormula_CheckedChanged(object sender, EventArgs e)
        {
            if (BodyFatFormulaRadioButton.Checked)
            {
                BodyFat_Panel.Visible = true;
            }
            else
            {
                BodyFat_Panel.Visible = false;
            }
        }
        private void WagaBox_TextChanged(object sender, EventArgs e)
        {
            waga = int.Parse(WagaBox.Text);
        }
        private void WiekBox_TextChanged(object sender, EventArgs e)
        {
            wiek = int.Parse(WiekBox.Text);
        }
        private void WzrostBox_TextChanged(object sender, EventArgs e)
        {
            wzrost = int.Parse(WzrostBox.Text);
        }


        private void HowManyTrainDays_TextChanged(object sender, EventArgs e)
        {
            DniTreningowe = int.Parse(HowManyTrainDays_textBox.Text);
        }
        private void BodyFatPercent_TextChanged(object sender, EventArgs e)
        {
            BodyFat = int.Parse(Bf_PercentText.Text);
        }


        private void TrainingTimeStrength_TextChanged(object sender, EventArgs e)
        {
            TrainingTimeStrength = int.Parse(TrainingTimeStrength_TextBox.Text);
        }
        private void TrainingTimeCardio_TextChanged(object sender, EventArgs e)
        {
            TrainingTimeCardio = int.Parse(TrainingTimeCardio_TextBox.Text);
        }

        private void BodyFatLevel_buttonClick(object sender, EventArgs e)
        {
            new BodyFat_window().Show();
        }

        private void Info_button(object sender, EventArgs e)
        {
            MessageBox.Show("Program korzysta ze wzorów Mifflin'a-St Jeor, Katch'a-McArdle jak i z obrazka ze strony BuiltLean.com" + "\n" + "\nWersja programu: 1.0", "Informacje o programie");
        }

        private void autor_button(object sender, EventArgs e)
        {
            MessageBox.Show("Program stworzył Radosław \"Revo\" Rak.", "Autor");
        }

        public int CalculateNEAT()
        {
            if (sitting_rb.Checked)
            {
                NEAT = 200;
            }
            else if (light_rb.Checked)
            {
                NEAT = 450;
            }
            else if (active_rb.Checked)
            {
                NEAT = 650;
            }
            else if (veryActive_rb.Checked)
            {
                NEAT = 900;
            }
            return NEAT;
        }
        public double CalculateFFMI(int BodyFat)
        {
            FFMI = (waga*(100-BodyFat))/100;
            return FFMI;
        }
        public double CalculateBMR(int waga, int wzrost, int wiek)
        {
          

            if (SportFormulaRadioButton.Checked == true)
            {
                BMR = ((9.99 * waga) + (6.26 * wzrost)) - (4.92 * wiek);

                if (MezczyznaRadioButton.Checked)
                {
                    MezczyznaBMR = BMR + 5;
                    BMR = MezczyznaBMR;
                }
                else if (KobietaRadioButton.Checked)
                {
                    KobietaBMR = BMR - 161;
                    BMR = KobietaBMR;
                }
            }
            else if (BodyFatFormulaRadioButton.Checked == true)
            {
                CalculateFFMI(BodyFat);
                BMR = 370 + (21.6 * FFMI);
            }

            return BMR;
        }
        public  double CalculateTEA(int TrainingTimeCardio, int TrainingTimeStrength, int DniTreningowe)
        {
            int StrengthCalorie = 0, CardioCalorie = 0;

            if (ExcerciseLight.Checked == true)
            {
                 StrengthCalorie = TrainingTimeStrength * 7;
                 CardioCalorie = TrainingTimeCardio * 3;
            }
            else if (ExcerciseModerate.Checked == true)
            {
                StrengthCalorie = TrainingTimeStrength * 8;
                CardioCalorie = TrainingTimeCardio * 5;
            }
            else if (ExcerciseIntense.Checked == true)
            {
                StrengthCalorie = TrainingTimeStrength * 10;
                CardioCalorie = TrainingTimeCardio * 8;
            }
            else if (ExcerciseVeryIntense.Checked == true)
            {
                StrengthCalorie = TrainingTimeStrength * 12;
                CardioCalorie = TrainingTimeCardio * 10;
            }

            TEA = (CardioCalorie + StrengthCalorie) * DniTreningowe;
            TEA /= 7;

            return TEA;
        }
        public double CalculateTEF()
        {
            CalculateBMR(waga, wzrost, wiek);
            TEF = BMR * 0.1;

            return TEF;
        }
        private void Policz(object sender, EventArgs e)
        {
                CalculateTEF();
                CalculateNEAT();
                CalculateTEA(TrainingTimeCardio, TrainingTimeStrength, DniTreningowe);
                CalculateBMR(waga, wzrost, wiek);

                TDEE = NEAT + BMR + TEA + TEF;

                BMR_tb.Text = (Math.Round(BMR, 0).ToString());
                TDEE_tb.Text = (Math.Round(TDEE, 0).ToString());
        }


        private void WiekBox_MouseEnter(object sender, EventArgs e)
        {
            wiek_tooltip.SetToolTip(WiekBox, "Wpisz tutaj swój wiek w latach.");
        }

        private void WagaBox_MouseEnter(object sender, EventArgs e)
        {
            waga_tooltip.SetToolTip(WagaBox, "Wpisz tutaj swoją wagę w kilogramach.");
        }

        private void WzrostBox_MouseEnter(object sender, EventArgs e)
        {
            Wzrost_tooltip.SetToolTip(WzrostBox, "Wpisz tutaj swój wzrost w centymetach.");
        }

        private void MezczyznaRadioButton_MouseEnter(object sender, EventArgs e)
        {
            Plec_tooltip.SetToolTip(MezczyznaRadioButton, "Wybierz swoją płeć.");
        }
        private void KobietaRadioButton_MouseEnter(object sender, EventArgs e)
        {
            Plec_tooltip.SetToolTip(KobietaRadioButton, "Wybierz swoją płeć.");
        }
        private void SportFormulaRadioButton_MouseEnter(object sender, EventArgs e)
        {
            SportFormula_ToolTip.SetToolTip(SportFormulaRadioButton, "Zalecana dla osób szczupłych, bazuje na wzorze Mifflin'a-St Jeor.");
        }

        private void BodyFatFormulaRadioButton_MouseEnter(object sender, EventArgs e)
        {
            BfFormula_ToolTip.SetToolTip(BodyFatFormulaRadioButton, "Wybierz, jeśli znasz swój aktualny poziom tłuszczu w organiźmie, bazuje na wzorze Katch'a-McArdle.");
        }
    }
}
