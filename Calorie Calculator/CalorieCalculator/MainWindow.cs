using System;
using System.Windows.Forms;

namespace CalorieCalculator
{
    partial class CalorieCalculator : Form
    {
        #region Constructors

        public CalorieCalculator()
        {
            InitializeComponent();
        }

        #endregion

        #region Private fields

        private int age, height, weight, BodyFat, TrainingDays, NEAT, TrainingTimeStrength, TrainingTimeCardio;

        private float ManBMR, WomanBMR, BMR, TEA, TEF, TDEE, FFMI;

        #endregion

        #region Private event methods

        private void BfFormula_CheckedChanged(object sender, EventArgs e)
        {
            BodyFat_Panel.Visible = BodyFatFormulaRadioButton.Checked ? true : false;
        }

        private void WeightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckIfNumber(e))
                weight = Convert.ToInt32(e.KeyChar);
        }

        private void AgeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckIfNumber(e))
                age = Convert.ToInt32(e.KeyChar);
        }

        private void HeightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckIfNumber(e))
                height = Convert.ToInt32(e.KeyChar);
        }

        private void HowManyTrainDays_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckIfNumber(e))
                TrainingDays = Convert.ToInt32(e.KeyChar);
        }

        private void TrainingTimeStrength_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckIfNumber(e))
                TrainingTimeStrength = Convert.ToInt32(e.KeyChar);
        }

        private void TrainingTimeCardio_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckIfNumber(e))
                TrainingTimeCardio = Convert.ToInt32(e.KeyChar);
        }

        private void Bf_PercentText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CheckIfNumber(e))
                BodyFat = Convert.ToInt32(e.KeyChar);
        }

        private void BodyFatLevel_buttonClick(object sender, EventArgs e) => new BodyFat_window().Show();

        private void Info_button(object sender, EventArgs e) 
            => MessageBox.Show("Program korzysta ze wzorów Mifflin'a-St Jeor, Katch'a-McArdle jak i z obrazka ze strony BuiltLean.com" + "\n" + "\nWersja programu: 1.0", "Informacje o programie");

        private void Autor_button(object sender, EventArgs e) 
            => MessageBox.Show("Program stworzył Radosław \"Revo\" Rak.", "Autor");

        #endregion
    }
}
