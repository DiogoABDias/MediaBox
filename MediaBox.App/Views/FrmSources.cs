namespace MediaBox.App.Views;

public partial class FrmSources : Form
{
    public FrmSources() => InitializeComponent();

    private void FrmSources_Load(object sender, EventArgs e) => LoadSources();

    //////////////////////////////////////// EVENTS ////////////////////////////////////////

    private void LsvSources_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnEdit.Enabled = LsvSources.SelectedItems.Count > 0;
        BtnDelete.Enabled = LsvSources.SelectedItems.Count > 0;
    }

    private void BtnNew_Click(object sender, EventArgs e)
    {
        FrmSource form = new();
        DialogResult result = form.ShowDialog();

        if (result != DialogResult.OK)
        {
            return;
        }

        LoadSources();
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        if (LsvSources.SelectedItems.Count == 0)
        {
            return;
        }

        if (Program._sources?.Sources is null)
        {
            return;
        }

        FrmSource form = new(Program._sources.Sources[LsvSources.SelectedIndices[0]]);
        DialogResult result = form.ShowDialog();

        if (result != DialogResult.OK)
        {
            return;
        }

        LoadSources();
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        if (LsvSources.SelectedItems.Count == 0)
        {
            return;
        }

        if (Program._sources?.Sources is null)
        {
            return;
        }

        SourceView source = Program._sources.Sources[LsvSources.SelectedIndices[0]];
        string name = source.Name ?? "";

        SourceController.DeleteSource(name);
        LsvSources.Items.RemoveAt(LsvSources.SelectedIndices[0]);
    }

    private async void BtnSave_Click(object sender, EventArgs e)
    {
        await SourceController.SaveSourcesAsync();
        Close();
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        SourceController.DiscardChanges();
        Close();
    }

    //////////////////////////////////////// METHODS ////////////////////////////////////////

    private void LoadSources()
    {
        Program._sources = SourceController.GetSources();

        if (Program._sources.Sources is null)
        {
            return;
        }

        LsvSources.BeginUpdate();

        if (LsvSources.Items.Count > 0)
        {
            LsvSources.Items.Clear();
        }

        foreach (SourceView source in Program._sources.Sources)
        {
            ListViewItem item;
            ListViewItem.ListViewSubItem subItem;

            item = new()
            {
                Text = source.Name
            };

            subItem = new()
            {
                Text = source.Type
            };
            item.SubItems.Add(subItem);

            subItem = new()
            {
                Text = source.Language
            };
            item.SubItems.Add(subItem);

            subItem = new()
            {
                Text = source.Path
            };
            item.SubItems.Add(subItem);

            LsvSources.Items.Add(item);
        }

        LsvSources.EndUpdate();
    }
}