using Varela_ExamenP3.ViewModels;

namespace Varela_ExamenP3.Views;

public partial class BromasGuardadasView : ContentPage
{
	public BromasGuardadasView()
	{
		InitializeComponent();
		BindingContext = new BromasGuardadasVM();
	}
}