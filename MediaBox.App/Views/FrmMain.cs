namespace MediaBox.App.Views;

public partial class FrmMain : Form
{
    public FrmMain() => InitializeComponent();

    private async void FrmMain_Load(object sender, EventArgs e) => await LoginController.LoginAsync();

    //////////////////////////////////////// EVENTS ////////////////////////////////////////

    private void BtnMovies_Click(object sender, EventArgs e)
    {

    }

    private void BtnTvShows_Click(object sender, EventArgs e)
    {

    }

    private void BtnCartoons_Click(object sender, EventArgs e)
    {

    }

    private void BtnSources_Click(object sender, EventArgs e)
    {
        FrmSources form = new();
        form.ShowDialog();
    }

    private void BtnSettings_Click(object sender, EventArgs e)
    {

    }

    private void LsvMedia_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void LsvEpisodes_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}