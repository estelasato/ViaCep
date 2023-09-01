using tarefa3_viaCep.Views;

namespace tarefa3_viaCep;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}


    public async void ChangeGetAddress(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new getAddress());
    }
    public async void ChangeGetCEP(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new getCep());
    }
}

