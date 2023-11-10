namespace MediaBox.Frm.Views;
public partial class FrmSource : Form
{
    private readonly IApplicationController _applicationController;
    private ErrorProvider _errorProvider;
    internal SourceView? Source;

    private bool AddMode => Source == null;

    public FrmSource(IApplicationController applicationController, SourceView? source = default)
    {
        InitializeComponent();

        _applicationController = applicationController;

        //Errors
        _errorProvider = new()
        {
            BlinkStyle = ErrorBlinkStyle.NeverBlink
        };

        if (source is not null)
        {
            Source = new()
            {
                Id = source.Id,
                Name = source.Name,
                Type = source.Type,
                Language = source.Language,
                Path = source.Path
            };
        }
    }

    private async void FrmSourcesNew_Load(object sender, EventArgs e)
    {
        LanguagesView languages = await _applicationController.GetLanguagesAsync();

        CmbLanguage.DataSource = languages.Languages;
        CmbLanguage.ValueMember = "Id";
        CmbLanguage.DisplayMember = "NativeName";
        CmbType.SelectedIndex = 0;

        TxtName.Enabled = AddMode;

        if (!AddMode)
        {
            TxtName.Text = Source!.Name;
            CmbType.SelectedItem = Source.Type;
            CmbLanguage.SelectedValue = Source.Language;
            TxtPath.Text = Source.Path;
        }

        //Errors
        _errorProvider = new()
        {
            BlinkStyle = ErrorBlinkStyle.NeverBlink
        };
    }

    //////////////////////////////////////// EVENTS ////////////////////////////////////////

    private void TxtName_TextChanged(object sender, EventArgs e) => _errorProvider.Clear();

    private void TxtPath_TextChanged(object sender, EventArgs e) => _errorProvider.Clear();

    private void TxtPath_Click(object sender, EventArgs e)
    {
        string appLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        FolderBrowserDialog fbd = new() { SelectedPath = AddMode ? appLocation : $"{Source!.Path}\\" };
        DialogResult result = fbd.ShowDialog();

        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
        {
            TxtPath.Text = fbd.SelectedPath;
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtName.Text))
        {
            _errorProvider.SetIconAlignment(TxtName, ErrorIconAlignment.MiddleRight);
            _errorProvider.SetIconPadding(TxtName, 5);
            _errorProvider.SetError(TxtName, "Name is required!");
            return;
        }

        if (AddMode && _applicationController.SourceNameExists(TxtName.Text))
        {
            _errorProvider.SetIconAlignment(TxtName, ErrorIconAlignment.MiddleRight);
            _errorProvider.SetIconPadding(TxtName, 5);
            _errorProvider.SetError(TxtName, "A source with this name already exists!");
            return;
        }

        if (string.IsNullOrWhiteSpace(TxtPath.Text))
        {
            _errorProvider.SetIconAlignment(TxtPath, ErrorIconAlignment.MiddleRight);
            _errorProvider.SetIconPadding(TxtPath, 5);
            _errorProvider.SetError(TxtPath, "Path is required!");
            return;
        }

        if (AddMode)
        {
            Source = new()
            {
                Id = new Random((int)DateTime.UtcNow.Ticks).Next(10000, 99999),
                Name = TxtName.Text,
                Type = CmbType.SelectedItem.ToString() ?? "",
                Language = CmbLanguage.SelectedValue?.ToString() ?? "",
                Path = TxtPath.Text
            };
        }
        else
        {
            Source!.Name = TxtName.Text;
            Source.Type = CmbType.SelectedItem.ToString() ?? string.Empty;
            Source.Language = CmbLanguage.SelectedValue?.ToString() ?? string.Empty;
            Source.Path = TxtPath.Text;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        Source = null;
        Close();
    }
}