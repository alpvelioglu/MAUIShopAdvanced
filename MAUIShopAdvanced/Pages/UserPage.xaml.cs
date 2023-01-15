using MAUIShopAdvanced.Models;

namespace MAUIShopAdvanced.Pages;

public partial class UserPage : ContentPage
{
    public UserModel user;
	public UserPage()
    {
        InitializeComponent();
        userListView.ItemsSource = App.userRepo.GetAll();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        userListView.ItemsSource = App.userRepo.GetAll();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if(user != null && user.ID != 0)
        {
            App.userRepo.AddOrUpdate(new Models.UserModel
            {
                ID = user.ID,
                UserName = userNameEntry.Text,
                UserAddress = userAddressEntry.Text
            });
            userAddressEntry.Text = "";
            userNameEntry.Text = "";
        }
        else
        {
            App.userRepo.AddOrUpdate(new Models.UserModel
            {
                UserName = userNameEntry.Text,
                UserAddress = userAddressEntry.Text
            });
        }
        userListView.ItemsSource = App.userRepo.GetAll();
    }

    private void userListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        user = (UserModel)e.Item;
        userNameEntry.Text = user.UserName.ToString();
        userAddressEntry.Text = user.UserAddress.ToString();
        AddButton.Text = "Update";
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        user = (UserModel)button.BindingContext;
        App.userRepo.Delete(user);
        userListView.ItemsSource = App.userRepo.GetAll();
    }
}