using MAUIShopAdvanced.Models;

namespace MAUIShopAdvanced.Pages;

public partial class CPUPage : ContentPage
{
    public CPUModel cpuModel;
	public CPUPage()
	{
		InitializeComponent();
        cpuListView.ItemsSource = App.cpuRepo.GetAll();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        cpuListView.ItemsSource = App.cpuRepo.GetAll();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if(cpuModel != null && cpuModel.ID != 0)
        {
            App.cpuRepo.AddOrUpdate(new Models.CPUModel
            {
                ID = cpuModel.ID,
                CPUName = cpuNameEntry.Text,
                CPUPrice = Convert.ToInt32(cpuPriceEntry.Text)
            });
            cpuListView.ItemsSource = App.cpuRepo.GetAll();
            cpuNameEntry.Text = "";
            cpuPriceEntry.Text = "";
        }
        else
        {
            App.cpuRepo.AddOrUpdate(new Models.CPUModel
            {
                CPUName = cpuNameEntry.Text,
                CPUPrice = Convert.ToInt32(cpuPriceEntry.Text)
            });
            cpuListView.ItemsSource = App.cpuRepo.GetAll();
        }
        cpuModel = null;
        AddButton.Text = "Add";
    }

    private void cpuListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        cpuModel = (CPUModel)e.Item;
        cpuNameEntry.Text = cpuModel.CPUName.ToString();
        cpuPriceEntry.Text = cpuModel.CPUPrice.ToString();
        AddButton.Text = "UPDATE";
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        cpuModel = (CPUModel)button.BindingContext;
        App.cpuRepo.Delete(cpuModel);
        cpuListView.ItemsSource = App.cpuRepo.GetAll();
    }
}