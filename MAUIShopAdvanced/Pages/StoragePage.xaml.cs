namespace MAUIShopAdvanced.Pages;

public partial class StoragePage : ContentPage
{
	public static string StorageType { get; set; } = "HDD";
	public static int StorageCapacity { get; set; } = 250;

	public StoragePage()
	{
		InitializeComponent();
		stepper.Maximum = 1000;
		stepper.Minimum = 250;
		stepper.Increment = 250;
		stepper.Value = 500;
	}

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		RadioButton rb = (RadioButton)sender;
		StorageType = rb.Content.ToString();
	}

    private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		StorageCapacity = Convert.ToInt32(stepper.Value);
		if (stepper.Value == 1000) storageSizeLbl.Text = (StorageCapacity / 1000).ToString() + "TB";
		else storageSizeLbl.Text = StorageCapacity.ToString() + "GB";

    }
}