using System;
using System.Drawing;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit settings of image map.
    /// </summary>
    public partial class ImageMapToolSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The image map visual tool.
        /// </summary>
        ImageMapTool _imageMapVisualTool;

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
            _imageMapVisualTool = imageMapTool;

            ShowSettings();
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // if settings is changed
            if (SetSettings())
                DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the CheckedChanged event of EnabledCheckBox object.
        /// </summary>
        private void enabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // update user interface

            bool enabled = enabledCheckBox.Checked;
            alwaysVisibleCheckBox.Enabled = enabled;
            locationComboBox.Enabled = enabled;
            sizeComboBox.Enabled = enabled;
            zoomComboBox.Enabled = enabled;
            canvasPenCheckBox.Enabled = enabled;
            imageBufferPenCheckBox.Enabled = enabled;
            visibleRectPenCheckBox.Enabled = enabled;
        }

        /// <summary>
        /// Handles the CheckedChanged event of CanvasPenCheckBox object.
        /// </summary>
        private void canvasPenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if canvas color can be changed
            if (canvasPenCheckBox.Checked)
                canvasPenColorPanelControl.Enabled = true;
            else
                canvasPenColorPanelControl.Enabled = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of VisibleRectPenCheckBox object.
        /// </summary>
        private void visibleRectPenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if visible rect color can be changed
            if (visibleRectPenCheckBox.Checked)
                visibleRectPenColorPanelControl.Enabled = true;
            else
                visibleRectPenColorPanelControl.Enabled = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of ImageBufferPenCheckBox object.
        /// </summary>
        private void imageBufferPenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if buffer color can be changed
            if (imageBufferPenCheckBox.Checked)
                imageBufferPenColorPanelControl.Enabled = true;
            else
                imageBufferPenColorPanelControl.Enabled = false;
        }

        #endregion


        /// <summary>
        /// Shows the settings in user interface.
        /// </summary>
        private void ShowSettings()
        {
            enabledCheckBox.Checked = _imageMapVisualTool.Enabled;
            alwaysVisibleCheckBox.Checked = _imageMapVisualTool.IsAlwaysVisible;
            locationComboBox.SelectedItem = _imageMapVisualTool.Anchor;
            sizeComboBox.Text = string.Format("{0}x{1}", _imageMapVisualTool.Size.Width, _imageMapVisualTool.Size.Height);
            if (_imageMapVisualTool.Zoom == 0)
                zoomComboBox.Text = "Best fit";
            else
                zoomComboBox.Text = string.Format("1/{0}", Math.Round(1 / _imageMapVisualTool.Zoom));

            canvasPenCheckBox.Checked = _imageMapVisualTool.CanvasPen != null;
            if (canvasPenCheckBox.Checked)
                canvasPenColorPanelControl.Color = _imageMapVisualTool.CanvasPen.Color;
            imageBufferPenCheckBox.Checked = _imageMapVisualTool.ImageBufferPen != null;
            if (imageBufferPenCheckBox.Checked)
                imageBufferPenColorPanelControl.Color = _imageMapVisualTool.ImageBufferPen.Color;
            visibleRectPenCheckBox.Checked = _imageMapVisualTool.VisibleRectPen != null;
            if (visibleRectPenCheckBox.Checked)
                visibleRectPenColorPanelControl.Color = _imageMapVisualTool.VisibleRectPen.Color;
        }

        /// <summary>
        /// Updates image map visual tool settings.
        /// </summary>
        private bool SetSettings()
        {
            _imageMapVisualTool.Enabled = enabledCheckBox.Checked;
            _imageMapVisualTool.IsAlwaysVisible = alwaysVisibleCheckBox.Checked;
            _imageMapVisualTool.Anchor = (AnchorType)locationComboBox.SelectedItem;

            try
            {
                // update image map visual tool size

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
                _imageMapVisualTool.Size = new Size(width, height);


                // update image map visual tool zoom

                if (zoomComboBox.Text == "Best fit")
                {
                    _imageMapVisualTool.Zoom = 0;
                }
                else
                {
                    string[] zoomStrings = zoomComboBox.Text.Split('/');
                    if (zoomStrings.Length != 2)
                        throw new Exception("Invalid zoom value.");
                    _imageMapVisualTool.Zoom = 1f / Convert.ToInt32(zoomStrings[1]);
                }


                // update image map visual tool pens

                if (canvasPenCheckBox.Checked)
                    _imageMapVisualTool.CanvasPen = new Pen(canvasPenColorPanelControl.Color);
                else
                    _imageMapVisualTool.CanvasPen = null;

                if (visibleRectPenCheckBox.Checked)
                    _imageMapVisualTool.VisibleRectPen = new Pen(visibleRectPenColorPanelControl.Color);
                else
                    _imageMapVisualTool.VisibleRectPen = null;

                if (imageBufferPenCheckBox.Checked)
                    _imageMapVisualTool.ImageBufferPen = new Pen(imageBufferPenColorPanelControl.Color);
                else
                    _imageMapVisualTool.ImageBufferPen = null;
            }
            catch (Exception e)
            {
                DemosTools.ShowErrorMessage(e);
                return false;
            }
            return true;
        }

        #endregion

    }
}
