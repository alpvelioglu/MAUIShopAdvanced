namespace MAUIShopAdvanced.Pages;

public partial class RAMPage : ContentPage
{
	public static string RamSize { get; set; } = "4GB";
	public RAMPage()
	{
		InitializeComponent();
	}

    private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		ramSizeLbl.Text = stepper.Value.ToString() + "GB";
		RamSize = ramSizeLbl.Text;
    }
}