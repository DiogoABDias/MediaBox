namespace MediaBox.Frm.Views;
public partial class FrmSource : Form
{
    private SourceView? _source;
    private readonly ErrorProvider _erpName;

    public FrmSource(SourceView? source = null)
    {
        InitializeComponent();
        _source = source;

        //Errors
        _erpName = new()
        {
            BlinkStyle = ErrorBlinkStyle.NeverBlink
        };

        _erpName.SetIconAlignment(TxtName, ErrorIconAlignment.MiddleRight);
        _erpName.SetIconPadding(TxtName, 5);
    }

    private async void FrmSourcesNew_Load(object sender, EventArgs e)
    {
        LanguagesView languages = await SourceController.GetLanguagesAsync();

        CmbLanguage.DataSource = languages.Languages;
        CmbLanguage.ValueMember = "Id";
        CmbLanguage.DisplayMember = "NativeName";
        CmbType.SelectedIndex = 0;

        if (_source is null)
        {
            return;
        }

        TxtName.Enabled = false;
        TxtName.Text = _source.Name;
        CmbType.SelectedItem = _source.Type;
        CmbLanguage.SelectedValue = _source.Language;
        TxtPath.Text = _source.Path;
    }

    //////////////////////////////////////// EVENTS ////////////////////////////////////////

    private void TxtName_TextChanged(object sender, EventArgs e) => _erpName.Clear();

    private void TxtPath_Click(object sender, EventArgs e)
    {
        using FolderBrowserDialog fbd = new() { SelectedPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "" };
        DialogResult result = fbd.ShowDialog();

        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
        {
            TxtPath.Text = fbd.SelectedPath;
        }
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        bool add = _source is null;

        _source = new()
        {
            Name = TxtName.Text,
            Type = CmbType.SelectedItem.ToString() ?? "",
            Language = CmbLanguage.SelectedValue?.ToString() ?? "",
            Path = TxtPath.Text
        };

        if (add)
        {
            bool hasErrors = false;

            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                _erpName.SetError(TxtName, "Name is required!");
                hasErrors = true;
            }

            if (Program._sources.Sources.Any(x => x.Name == TxtName.Text))
            {
                _erpName.SetError(TxtName, "A source with this name already exists!");
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(TxtPath.Text))
            {
                _erpName.SetError(TxtPath, "Path is required!");
                hasErrors = true;
            }

            if (hasErrors)
            {
                _source = null;
                return;
            }

            SourceController.AddSource(_source);
        }
        else
        {
            SourceController.EditSource(_source);
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void BtnCancel_Click(object sender, EventArgs e) => Close();
}