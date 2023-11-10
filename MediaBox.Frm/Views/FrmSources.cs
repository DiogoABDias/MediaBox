namespace MediaBox.Frm.Views;
public partial class FrmSources : Form
{
    private readonly IApplicationController _applicationController;
    private readonly SourcesView _sources;
    internal List<KeyValuePair<SourceView, SourceOperationType>> SourceChanges = new();

    public FrmSources(IApplicationController applicationController)
    {
        InitializeComponent();

        _applicationController = applicationController;
        _sources = _applicationController.GetSources();
    }

    private void FrmSources_Load(object sender, EventArgs e) => DisplaySources();

    //////////////////////////////////////// EVENTS ////////////////////////////////////////

    private void LsvSources_SelectedIndexChanged(object sender, EventArgs e)
    {
        BtnEdit.Enabled = LsvSources.SelectedItems.Count > 0;
        BtnDelete.Enabled = LsvSources.SelectedItems.Count > 0;
    }

    private void BtnNew_Click(object sender, EventArgs e)
    {
        FrmSource form = new(_applicationController);
        DialogResult result = form.ShowDialog();

        if (result != DialogResult.OK)
        {
            return;
        }

        if (form.Source is not null)
        {
            KeyValuePair<SourceView, SourceOperationType> sourceChange = new(form.Source, SourceOperationType.Add);
            SourceChanges.Add(sourceChange);
            _sources.Sources.Add(form.Source);
        }

        DisplaySources();
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        ListViewItem item = LsvSources.SelectedItems[0];
        int index = _sources.Sources.FindIndex(x => x.Id == (int)item.Tag);

        FrmSource form = new(_applicationController, _sources.Sources[index]);
        DialogResult result = form.ShowDialog();

        if (result != DialogResult.OK)
        {
            return;
        }

        if (form.Source is not null)
        {
            KeyValuePair<SourceView, SourceOperationType> sourceChange = new(form.Source, SourceOperationType.Edit);
            SourceChanges.Add(sourceChange);
            _sources.Sources[index] = form.Source;
        }

        DisplaySources();
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        ListViewItem item = LsvSources.SelectedItems[0];
        SourceView source = _sources.Sources.First(x => x.Id == (int)item.Tag);

        KeyValuePair<SourceView, SourceOperationType> sourceChange = new(source, SourceOperationType.Delete);
        SourceChanges.Add(sourceChange);
        _sources.Sources.Remove(source);
        LsvSources.Items.RemoveAt(LsvSources.SelectedIndices[0]);
    }

    private async void BtnSave_Click(object sender, EventArgs e)
    {
        await _applicationController.SaveSourceChangesAsync(SourceChanges);

        DialogResult = DialogResult.OK;
        Close();
    }

    private void BtnCancel_Click(object sender, EventArgs e) => Close();

    //////////////////////////////////////// METHODS ////////////////////////////////////////

    private void DisplaySources()
    {
        LsvSources.BeginUpdate();

        LsvSources.Items.Clear();

        foreach (SourceView source in _sources.Sources)
        {
            ListViewItem item;
            ListViewItem.ListViewSubItem subItem;

            item = new() { Tag = source.Id, Text = source.Name };

            subItem = new() { Text = source.Type };
            item.SubItems.Add(subItem);

            subItem = new() { Text = source.Language };
            item.SubItems.Add(subItem);

            subItem = new() { Text = source.Path };
            item.SubItems.Add(subItem);

            LsvSources.Items.Add(item);
        }

        LsvSources.EndUpdate();
    }
}