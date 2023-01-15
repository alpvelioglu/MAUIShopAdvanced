using MAUIShopAdvanced.Models;

namespace MAUIShopAdvanced.Pages;

public partial class MonitorPage : ContentPage
{
    RadioButton rb;
    public MonitorModel monitor;
    public string monitorName;
	public MonitorPage()
	{
		InitializeComponent();
        monitorListView.ItemsSource = App.monitorRepo.GetAll();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        monitorListView.ItemsSource = App.monitorRepo.GetAll();
        hpRadio.IsChecked = true;
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if (monitor != null && monitor.ID != 0 && rb != null)
        {
            App.monitorRepo.AddOrUpdate(new Models.MonitorModel
            {
                ID = monitor.ID,
                MonitorName = rb.Content.ToString(),
                MonitorPrice = Convert.ToInt32(monitorPriceEntry.Text)
            });
            
            monitorPriceEntry.Text = "";
        }
        else
        {
            App.monitorRepo.AddOrUpdate(new Models.MonitorModel
            {
                MonitorName = monitorName,
                MonitorPrice = Convert.ToInt32(monitorPriceEntry.Text)
            });
        }
        monitorListView.ItemsSource = App.monitorRepo.GetAll();
        rb = null;
        AddButton.Text = "Add";
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        monitor = (MonitorModel)button.BindingContext;
        App.monitorRepo.Delete(monitor);
        monitorListView.ItemsSource = App.monitorRepo.GetAll();
    }

    private void monitorListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        monitor = (MonitorModel)e.Item;
        monitorName = monitor.MonitorName;
        //if(rb.Content.ToString() != monitorName)
        //{
        //    if (monitorName == "Asus") asusRadio.IsChecked = true;
        //    else if (monitorName == "HP") hpRadio.IsChecked = true;
        //    else if (monitorName == "Philips") philipsRadio.IsChecked = true;
        //}
        // ListView'den seçtiðin monitöre ait radio button seçilmiyor.
        monitorPriceEntry.Text = monitor.MonitorPrice.ToString();
        AddButton.Text = "Update";
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        rb = (RadioButton)sender;
        monitorName = rb.Content.ToString();
    }
}