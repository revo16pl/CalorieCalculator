using System;

namespace CalorieCalculator
{
    partial class CalorieCalculator
    {
        #region private methods

        private void AgeBox_MouseEnter(object sender, EventArgs e) 
            => Age_tooltip.SetToolTip(ageBox, "Wpisz tutaj swój wiek w latach.");

        private void WeightBox_MouseEnter(object sender, EventArgs e) 
            => Weight_tooltip.SetToolTip(weightBox, "Wpisz tutaj swoją wagę w kilogramach.");
  
        private void HeightBox_MouseEnter(object sender, EventArgs e) 
            => Height_tooltip.SetToolTip(heightBox, "Wpisz tutaj swój wzrost w centymetach.");

        private void MezczyznaRadioButton_MouseEnter(object sender, EventArgs e) 
            => Plec_tooltip.SetToolTip(MezczyznaRadioButton, "Wybierz swoją płeć.");

        private void KobietaRadioButton_MouseEnter(object sender, EventArgs e) 
            => Plec_tooltip.SetToolTip(KobietaRadioButton, "Wybierz swoją płeć.");

        private void SportFormulaRadioButton_MouseEnter(object sender, EventArgs e)
            => SportFormula_ToolTip.SetToolTip(SportFormulaRadioButton, "Zalecana dla osób szczupłych, bazuje na wzorze Mifflin'a-St Jeor.");

        private void BodyFatFormulaRadioButton_MouseEnter(object sender, EventArgs e) 
            => BfFormula_ToolTip.SetToolTip(BodyFatFormulaRadioButton, "Wybierz, jeśli znasz swój aktualny poziom tłuszczu w organiźmie, bazuje na wzorze Katch'a-McArdle.");

        #endregion
    }
}
