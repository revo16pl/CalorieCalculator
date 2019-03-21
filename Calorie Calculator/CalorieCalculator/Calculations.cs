using System;
using System.Windows.Forms;

namespace CalorieCalculator
{
    partial class CalorieCalculator
    {
        #region private methods - Calculations

        private void CalculateCaloriesClick(object sender, EventArgs e)
        {
            CalculateTEF();
            CalculateNEAT();
            CalculateTEA(TrainingTimeCardio, TrainingTimeStrength, TrainingDays);
            CalculateBMR(weight, height, age);

            TDEE = NEAT + BMR + TEA + TEF;

            BMR_tb.Text = (Math.Round(BMR, 0).ToString());
            TDEE_tb.Text = (Math.Round(TDEE, 0).ToString());
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
            FFMI = (weight * (100 - BodyFat)) / 100;
            return FFMI;
        }

        public float CalculateBMR(int weight, int height, int age)
        {
            if (SportFormulaRadioButton.Checked == true)
            {
                BMR = ((9.99f * weight) + (6.26f * height) - (4.92f * age));

                if (MezczyznaRadioButton.Checked)
                {
                    ManBMR = BMR + 5;
                    BMR = ManBMR;
                }
                else if (KobietaRadioButton.Checked)
                {
                    WomanBMR = BMR - 161;
                    BMR = WomanBMR;
                }
            }
            else if (BodyFatFormulaRadioButton.Checked == true)
            {
                CalculateFFMI(BodyFat);
                BMR = 370f + (21.6f * FFMI);
            }

            return BMR;
        }

        public double CalculateTEA(int TrainingTimeCardio, int TrainingTimeStrength, int TrainingDays)
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

            TEA = (CardioCalorie + StrengthCalorie) * TrainingDays;
            TEA /= 7;

            return TEA;
        }

        public float CalculateTEF()
        {
            CalculateBMR(weight, height, age);
            TEF = BMR * 0.1f;

            return TEF;
        }

        private static bool CheckIfNumber(KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("Proszę wpisać liczbę.");
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
