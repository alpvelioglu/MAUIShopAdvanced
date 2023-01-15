using MAUIShopAdvanced.Models;

namespace MAUIShopAdvanced.Pages;

public partial class CheckoutPage : ContentPage
{
    UserModel user;
    CPUModel cpu = new CPUModel();
    MonitorModel monitor = new MonitorModel();

	public int RAMPrice { get; set; }
    public int StoragePrice { get; set; }
    public int TotalPrice { get; set; }

    public CheckoutPage()
	{
		InitializeComponent();
		userListView.ItemsSource = App.userRepo.GetAll();
		cpuListView.ItemsSource = App.cpuRepo.GetAll();
		monitorListView.ItemsSource = App.monitorRepo.GetAll();
        checkoutListView.ItemsSource = App.checkoutRepo.GetAll();
        CalculateRAMPrice();
        CalculateStoragePrice();
        lblTotalPrice.Text = "Total Price: "+(RAMPrice + StoragePrice + cpu.CPUPrice + monitor.MonitorPrice).ToString("C");

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        userListView.ItemsSource = App.userRepo.GetAll();
        cpuListView.ItemsSource = App.cpuRepo.GetAll();
        monitorListView.ItemsSource = App.monitorRepo.GetAll();
        checkoutListView.ItemsSource = App.checkoutRepo.GetAll();
        CalculateRAMPrice();
        CalculateStoragePrice();
        lblTotalPrice.Text = "Total Price: " + (RAMPrice + StoragePrice + cpu.CPUPrice + monitor.MonitorPrice).ToString("C");
    }

    private void userListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
        user = (UserModel)e.Item;
	}

    private void cpuListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        cpu = (CPUModel)e.Item;
        lblTotalPrice.Text = "Total Price: " + (RAMPrice + StoragePrice + cpu.CPUPrice + monitor.MonitorPrice).ToString("C");
    }

    private void monitorListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        monitor = (MonitorModel)e.Item;
        lblTotalPrice.Text = "Total Price: " + (RAMPrice + StoragePrice + cpu.CPUPrice + monitor.MonitorPrice).ToString("C");
    }

    private void CalculateRAMPrice()
    {
        if (RAMPage.RamSize.Contains("GB"))
        {
            RAMPrice = Convert.ToInt32(RAMPage.RamSize.Replace("GB", ""));
        }
        else if (RAMPage.RamSize.Contains("TB"))
        {
            RAMPrice = Convert.ToInt32(RAMPage.RamSize.Replace("TB", ""));
        }
        RAMPrice *= 150;
        lblRamPrice.Text = "RAM Size: " + RAMPage.RamSize + "\nRAM Price: " + RAMPrice.ToString("C");
    }

    private void CalculateStoragePrice()
    {
        if(StoragePage.StorageType == "HDD")
        {
            StoragePrice = (StoragePage.StorageCapacity * 2) - 150;
        }
        else if(StoragePage.StorageType == "SSD")
        {
            StoragePrice = (StoragePage.StorageCapacity * 3) - 350;
        }
        lblStoragePrice.Text = $"Storage Type: {StoragePage.StorageType}\nStorage Capacity: {StoragePage.StorageCapacity}GB\nStorage Price: {StoragePrice:C}";
    }

    private void orderButton_Clicked(object sender, EventArgs e)
    {
        if(user != null && cpu != null && monitor != null)
        {
            App.checkoutRepo.AddOrUpdate(new Models.CheckoutModel
            {
                CPUName = cpu.CPUName,
                MonitorName = monitor.MonitorName,
                RamSize = RAMPage.RamSize,
                StorageCapacity = StoragePage.StorageCapacity,
                StorageType = StoragePage.StorageType,
                UserName = user.UserName
            });
        }
        checkoutListView.ItemsSource = App.checkoutRepo.GetAll();
    }

    private async void checkoutListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new FinalPage((CheckoutModel)e.Item));
    }
}