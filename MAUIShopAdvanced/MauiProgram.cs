using MAUIShopAdvanced.Abstract;
using MAUIShopAdvanced.Models;

namespace MAUIShopAdvanced;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<BaseRepository<UserModel>>();
		builder.Services.AddSingleton<BaseRepository<StorageModel>>();
		builder.Services.AddSingleton<BaseRepository<RAMModel>>();
		builder.Services.AddSingleton<BaseRepository<MonitorModel>>();
		builder.Services.AddSingleton<BaseRepository<CPUModel>>();
		builder.Services.AddSingleton<BaseRepository<CheckoutModel>>();
		return builder.Build();
	}
}
