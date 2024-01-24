using Varela_ExamenP3.ViewModels;

namespace Varela_ExamenP3.Views;

public partial class BromasAleatoriaView : ContentPage
{
	public BromasAleatoriaView()
	{
		InitializeComponent();
		BindingContext = new BromaAleatoriaVM();
	}
}