using MediaBox.App.Models;
using Refit;

namespace MediaBox.App
{
    public partial class FrmMain : Form
    {
        private readonly ILogin _loginClient;
        private ITvdb? _tvdbClient;

        public FrmMain()
        {
            InitializeComponent();

            _loginClient = RestService.For<ILogin>("https://api4.thetvdb.com/v4");
        }

        private async void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                Credentials credentials = new()
                {
                    ApiKey = "580c9239-d2f8-4460-a22e-6831900a97a3",
                    Pin = "IPQZOCMN"
                };

                Task<Response<ApiToken>> response = _loginClient.LoginAsync(credentials);

                await response;

                if (response.Status != TaskStatus.RanToCompletion)
                {
                    return;
                }

                if (response.Result.Status != "success")
                {
                    return;
                }

                _tvdbClient = RestService.For<ITvdb>("https://api4.thetvdb.com/v4",
                    new RefitSettings()
                    {
                        AuthorizationHeaderValueGetter = () => Task.FromResult(response.Result?.Data?.Token ?? "")
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

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
}