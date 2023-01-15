using MAUIShopAdvanced.Abstract;
using MAUIShopAdvanced.Models;

namespace MAUIShopAdvanced;

public partial class App : Application
{
	public static BaseRepository<UserModel> userRepo;
	public static BaseRepository<CPUModel> cpuRepo;
	public static BaseRepository<RAMModel> ramRepo;
	public static BaseRepository<StorageModel> storageRepo;
	public static BaseRepository<CheckoutModel> checkoutRepo;
	public static BaseRepository<MonitorModel> monitorRepo;

	public App(BaseRepository<UserModel> user,
               BaseRepository<CPUModel> cpu,
               BaseRepository<RAMModel> ram,
               BaseRepository<StorageModel> storage,
               BaseRepository<CheckoutModel> checkout,
               BaseRepository<MonitorModel> monitor)
	{
		InitializeComponent();
		userRepo = user;
		cpuRepo = cpu;
		ramRepo = ram;
		storageRepo = storage;
		checkoutRepo = checkout;
		monitorRepo = monitor;
		MainPage = new AppShell();
	}
}
