using System;
using System.Drawing;
using System.Windows.Forms;
using Vintasoft.Imaging;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit settings of image map.
    /// </summary>
    public partial class ImageMapToolSettingsForm : Form
    {

        #region Fields

        ImageMapTool _imageMapTool;

        #endregion



        #region Constructros

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageMapToolSettingsForm"/> class.
        /// </summary>
        public ImageMapToolSettingsForm()
        {
            InitializeComponent();

            sizeComboBox.Items.Add("64");
            sizeComboBox.Items.Add("120");
            sizeComboBox.Items.Add("150x200");
            sizeComboBox.Items.Add("200");
            sizeComboBox.Items.Add("320x240");
            sizeComboBox.Items.Add("400x300");
            sizeComboBox.Items.Add("640x480");

            zoomComboBox.Items.Add("1/20");
            zoomComboBox.Items.Add("1/25");
            zoomComboBox.Items.Add("1/40");
            zoomComboBox.Items.Add("1/80");
            zoomComboBox.Items.Add("1/100");
            zoomComboBox.Items.Add("Best fit");

            object[] aStyles = new object[]
            {
                AnchorStyles.None,
                AnchorStyles.Left | AnchorStyles.Top,
                AnchorStyles.Top,
                AnchorStyles.Top | AnchorStyles.Right,
                AnchorStyles.Right,
                AnchorStyles.Bottom| AnchorStyles.Right,
                AnchorStyles.Bottom,
                AnchorStyles.Bottom | AnchorStyles.Left,
                AnchorStyles.Left,
            };

            locationComboBox.Items.AddRange(aStyles);
            locationComboBox.SelectedIndex = 7;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageMapToolSettingsForm"/> class.
        /// </summary>
        /// <param name="imageMapTool">The <see cref="ImageMapTool"/>.</param>
        public ImageMapToolSettingsForm(ImageMapTool imageMapTool)
            : this()
        {
            _imageMapTool = imageMapTool;

            ShowSettings();
        }

        #endregion



        #region Methods

        private void ShowSettings()
        {
            enabledCheckBox.Checked = _imageMapTool.Enabled;
            alwaysVisibleCheckBox.Checked = _imageMapTool.IsAlwaysVisible;
            locationComboBox.SelectedItem = _imageMapTool.Anchor;
            sizeComboBox.Text = string.Format("{0}x{1}", _imageMapTool.Size.Width, _imageMapTool.Size.Height);
            if (_imageMapTool.Zoom == 0)
                zoomComboBox.Text = "Best fit";
            else
                zoomComboBox.Text = string.Format("1/{0}", Math.Round(1 / _imageMapTool.Zoom));

            canvasPenCheckBox.Checked = _imageMapTool.CanvasPen != null;
            if (canvasPenCheckBox.Checked)
                canvasPenColorPanelControl.Color = _imageMapTool.CanvasPen.Color;
            imageBufferPenCheckBox.Checked = _imageMapTool.ImageBufferPen != null;
            if (imageBufferPenCheckBox.Checked)
                imageBufferPenColorPanelControl.Color = _imageMapTool.ImageBufferPen.Color;
            visibleRectPenCheckBox.Checked = _imageMapTool.VisibleRectPen != null;
            if (visibleRectPenCheckBox.Checked)
                visibleRectPenColorPanelControl.Color = _imageMapTool.VisibleRectPen.Color;
        }

        private bool SetSettings()
        {
            _imageMapTool.Enabled = enabledCheckBox.Checked;
            _imageMapTool.IsAlwaysVisible = alwaysVisibleCheckBox.Checked;
            _imageMapTool.Anchor = (AnchorType)locationComboBox.SelectedItem;

            try
            {
                // Size
                string[] sizeStrings = sizeComboBox.Text.Split('x');
                int width;
                int height;
                if (sizeStrings.Length == 1)
                {
                    width = Convert.ToInt32(sizeStrings[0]);
                    height = width;
                }
                else
                {
                    width = Convert.ToInt32(sizeStrings[0]);
                    height = Convert.ToInt32(sizeStrings[1]);
                }
                _imageMapTool.Size = new Size(width, height);

                // Zoom
                if (zoomComboBox.Text == "Best fit")
                {
                    _imageMapTool.Zoom = 0;
                }
                else
                {
                    string[] zoomStrings = zoomComboBox.Text.Split('/');
                    if (zoomStrings.Length != 2)
                        throw new Exception("Invalid zoom value.");
                    _imageMapTool.Zoom = 1f / Convert.ToInt32(zoomStrings[1]);
                }

                // Pens
                if (canvasPenCheckBox.Checked)
                    _imageMapTool.CanvasPen = new Pen(canvasPenColorPanelControl.Color);
                else
                    _imageMapTool.CanvasPen = null;

                if (visibleRectPenCheckBox.Checked)
                    _imageMapTool.VisibleRectPen = new Pen(visibleRectPenColorPanelControl.Color);
                else
                    _imageMapTool.VisibleRectPen = null;

                if (imageBufferPenCheckBox.Checked)
                    _imageMapTool.ImageBufferPen = new Pen(imageBufferPenColorPanelControl.Color);
                else
                    _imageMapTool.ImageBufferPen = null;
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
                return false;
            }
            return true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (SetSettings())
                DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void enabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = enabledCheckBox.Checked;
            alwaysVisibleCheckBox.Enabled = enabled;
            locationComboBox.Enabled = enabled;
            sizeComboBox.Enabled = enabled;
            zoomComboBox.Enabled = enabled;
            canvasPenCheckBox.Enabled = enabled;
            imageBufferPenCheckBox.Enabled = enabled;
            visibleRectPenCheckBox.Enabled = enabled;
        }

        private void canvasPenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            canvasPenColorPanelControl.Enabled = canvasPenCheckBox.Checked;
        }

        private void visibleRectPenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            visibleRectPenColorPanelControl.Enabled = visibleRectPenCheckBox.Checked;
        }

        private void imageBufferPenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            imageBufferPenColorPanelControl.Enabled = imageBufferPenCheckBox.Checked;
        }

        #endregion

    }
}
