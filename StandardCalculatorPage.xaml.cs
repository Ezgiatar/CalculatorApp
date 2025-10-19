using CalculatorApp.Logic;

namespace CalculatorApp.Views;

public partial class StandardCalculatorPage : ContentPage
{
    private readonly CalculatorLogic _logic = new CalculatorLogic();

    public StandardCalculatorPage()
    {
        InitializeComponent();
    }

    private void UpdateDisplay()
    {
        DisplayLabel.Text = _logic.DisplayValue;
    }

    private void OnDigitClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        _logic.InputDigit(button.Text);
        UpdateDisplay();
    }

    private void OnOperatorClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        _logic.InputOperator(button.Text);
        UpdateDisplay();
    }

    private void OnUnaryOperationClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        _logic.PerformUnaryOperation(button.Text);
        UpdateDisplay();
    }

    private void OnEqualsClicked(object sender, EventArgs e)
    {
        _logic.CalculateResult();
        UpdateDisplay();
    }

    private void OnClearEntryClicked(object sender, EventArgs e)
    {
        _logic.ClearEntry();
        UpdateDisplay();
    }

    private void OnClearAllClicked(object sender, EventArgs e)
    {
        _logic.ClearAll();
        UpdateDisplay();
    }

    private void OnBackspaceClicked(object sender, EventArgs e)
    {
        _logic.Backspace();
        UpdateDisplay();
    }
}