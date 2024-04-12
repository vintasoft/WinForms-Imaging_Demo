using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Drawing;
using Vintasoft.Imaging.Drawing.Gdi;
#if !REMOVE_PDF_PLUGIN
using Vintasoft.Imaging.Pdf;
#endif

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A form that allows to view and edit the composite image rendering settings.
    /// </summary>
    public partial class CompositeRenderingSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// Contains image/document rendering settings.
        /// </summary>
        RenderingSettings _renderingSettings;

        #endregion



        #region Constructors

        /// <summary>
        /// Inititalizes new instance of <see cref="CompositeRenderingSettingsForm"/>.
        /// </summary>
        public CompositeRenderingSettingsForm()
        {
            InitializeComponent();

            // init "Text Rendering Hint"
            textRenderingHintComboBox.Items.Add(TextRenderingHint.Auto);
            textRenderingHintComboBox.Items.Add(TextRenderingHint.AntiAlias);
            textRenderingHintComboBox.Items.Add(TextRenderingHint.AntiAliasGridFit);
            textRenderingHintComboBox.Items.Add(TextRenderingHint.ClearTypeGridFit);
            textRenderingHintComboBox.Items.Add(TextRenderingHint.SingleBitPerPixel);
            textRenderingHintComboBox.Items.Add(TextRenderingHint.SingleBitPerPixelGridFit);
            textRenderingHintComboBox.Items.Add(TextRenderingHint.SystemDefault);

            // init "Interpolation Mode"
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.Bicubic);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.Bilinear);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.HighQualityBicubic);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.HighQualityBilinear);
            interpolationModeComboBox.Items.Add(ImageInterpolationMode.NearestNeighbor);

            // init "Smoothing Mode"
            smoothingModeComboBox.Items.Add(DrawingSmoothingMode.AntiAlias);
            smoothingModeComboBox.Items.Add(DrawingSmoothingMode.None);
        }

        /// <summary>
        /// Inititalizes new instance of <see cref="CompositeRenderingSettingsForm"/>.
        /// </summary>
        /// <param name="renderingSettings">Current rendering settings.</param>
        public CompositeRenderingSettingsForm(RenderingSettings renderingSettings)
            : this()
        {
            if (renderingSettings == null)
                renderingSettings = RenderingSettings.Empty;

            _renderingSettings = renderingSettings;

            // init common settings

            if (renderingSettings.IsEmpty || renderingSettings.Resolution.IsEmpty())
            {
                resolutionSettingsCheckBox.Checked = false;
            }
            else
            {
                resolutionSettingsCheckBox.Checked = true;
                horizontalResolutionNumericUpDown.Value = (int)renderingSettings.Resolution.Horizontal;
                verticalResolutionNumericUpDown.Value = (int)renderingSettings.Resolution.Vertical;
            }

            smoothingModeComboBox.SelectedItem = renderingSettings.SmoothingMode;
            interpolationModeComboBox.SelectedItem = renderingSettings.InterpolationMode;
            optimizeImageDrawingCheckBox.Checked = renderingSettings.OptimizeImageDrawing;
            drawSharpImageBordersCheckBox.Checked = renderingSettings.DrawSharpImageBorders;

            // init PDF settings
            bool isPdfSettingsEnabled = false;

#if !REMOVE_PDF_PLUGIN
            // get the PDF rendering settings from image rendering settings
            PdfRenderingSettings pdfSettings = CompositeRenderingSettings.GetRenderingSettings<PdfRenderingSettings>(renderingSettings);
            
            // if PDF rendering settings are found
            if (pdfSettings != null)
            {
                // set the form properties according to the PDF rendering settings

                PdfAnnotationRenderingMode renderingMode = pdfSettings.AnnotationRenderingMode;
                vintasoftAnnotationsCheckBox.Checked = (renderingMode & PdfAnnotationRenderingMode.VintasoftAnnotations) != 0;
                nonMarkupAnnotationsCheckBox.Checked = (renderingMode & PdfAnnotationRenderingMode.NonMarkupAnnotations) != 0;
                markupAnnotationsCheckBox.Checked = (renderingMode & PdfAnnotationRenderingMode.MarkupAnnotations) != 0;
                renderInvisibleCheckBox.Checked = (renderingMode & PdfAnnotationRenderingMode.RenderInvisible) != 0;
                renderHiddenCheckBox.Checked = (renderingMode & PdfAnnotationRenderingMode.RenderHidden) != 0;
                renderPrintableCheckBox.Checked = (renderingMode & PdfAnnotationRenderingMode.RenderPrintable) != 0;
                renderNoViewCheckBox.Checked = (renderingMode & PdfAnnotationRenderingMode.RenderNoView) != 0;
                renderDisplayableCheckBox.Checked = (renderingMode & PdfAnnotationRenderingMode.RenderDisplayable) != 0;
                
                ignoreImageInterpolationFlagCheckBox.Checked = pdfSettings.IgnoreImageInterpolateFlag;
                optimizePatternRenderingCheckBox.Checked = pdfSettings.OptimizePatternRendering;
                drawErrorsCheckBox.Checked = pdfSettings.DrawResourceErrorMessages;

                isPdfSettingsEnabled = true;
            }

#endif

            // if PDF document rendering settings are not enabled
            if (!isPdfSettingsEnabled)
                // remove tab page with PDF document rendering settings from the form
                renderingSettingsTabControl.TabPages.Remove(pdfSettingsTabPage);

            // init the Office document settings
            bool isOfficeDocumentSettingsEnabled = false;

#if !REMOVE_OFFICE_PLUGIN
            // get the Office document markup rendering settings from image rendering settings
            MarkupRenderingSettings markupSettings = CompositeRenderingSettings.GetRenderingSettings<MarkupRenderingSettings>(renderingSettings);

            // if Office document markup rendering settings are found
            if (markupSettings != null)
            {
                // set the form properties according to the Office document markup rendering settings
                textRenderingHintComboBox.SelectedItem = markupSettings.TextRenderingHint;
                showInvisibleTableBordersCheckBox.Checked = markupSettings.ShowInvisibleTableBorders;
                invisibleTableBordersColorPanelControl.CanSetColor = true;
                invisibleTableBordersColorPanelControl.Color = markupSettings.InvisibleTableBordersColor;
                invisibleTableBordersGroupBox.Enabled = showInvisibleTableBordersCheckBox.Checked;
                showNonPrintableCharactersCheckBox.Checked = markupSettings.ShowNonPrintableCharacters;

                isOfficeDocumentSettingsEnabled = true;
            }
#endif

            // if Office document rendering settings are not enabled
            if (!isOfficeDocumentSettingsEnabled)
                // remove tab page with Office document rendering settings from the form
                renderingSettingsTabControl.TabPages.Remove(officeSettingsTabPage);
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of buttonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // set common rendering settings

            // if resolution is specified
            if (resolutionSettingsCheckBox.Checked)
            {
                // get rendering resolution
                _renderingSettings.Resolution = new Resolution(
                    (float)horizontalResolutionNumericUpDown.Value,
                    (float)verticalResolutionNumericUpDown.Value);
            }
            else
            {
                // set default resolution
                _renderingSettings.Resolution = RenderingSettings.Empty.Resolution;
            }

            // get rendering interpolation mode
            _renderingSettings.InterpolationMode = (ImageInterpolationMode)interpolationModeComboBox.SelectedItem;
            // get rendering smoothing mode
            _renderingSettings.SmoothingMode = (DrawingSmoothingMode)smoothingModeComboBox.SelectedItem;
            // get a value indicating whether the image drawing method must use performance optimizations for image drawing
            _renderingSettings.OptimizeImageDrawing = optimizeImageDrawingCheckBox.Checked;
            // get a value indicating whether the SDK must use special algorithm for drawing sharp image borders
            _renderingSettings.DrawSharpImageBorders = drawSharpImageBordersCheckBox.Checked;


#if !REMOVE_PDF_PLUGIN
            // if tab page with PDF rendering settings presents
            if (renderingSettingsTabControl.TabPages.Contains(pdfSettingsTabPage))
            {
                // get all of the PDF rendering settings objects from image rendering settings
                PdfRenderingSettings[] pdfSettings = CompositeRenderingSettings.FindRenderingSettings<PdfRenderingSettings>(_renderingSettings);

                foreach (PdfRenderingSettings settings in pdfSettings)
                {
                    // copy setting from dialog to each PDF rendering settings object
                    settings.AnnotationRenderingMode = GetAnnotationRenderingMode();
                    settings.IgnoreImageInterpolateFlag = ignoreImageInterpolationFlagCheckBox.Checked;
                    settings.OptimizePatternRendering = optimizePatternRenderingCheckBox.Checked;
                    settings.DrawResourceErrorMessages = drawErrorsCheckBox.Checked;
                }
            }
#endif

#if !REMOVE_OFFICE_PLUGIN
            // if tab page with Office document rendering settings presents
            if (renderingSettingsTabControl.TabPages.Contains(officeSettingsTabPage))
            {
                // get all of the markup rendering settings objects from image rendering settings
                MarkupRenderingSettings[] markupSettings = CompositeRenderingSettings.FindRenderingSettings<MarkupRenderingSettings>(_renderingSettings);

                foreach (MarkupRenderingSettings settings in markupSettings)
                {
                    // copy setting from dialog to each markup rendering settings object
                    settings.TextRenderingHint = (TextRenderingHint)textRenderingHintComboBox.SelectedItem;
                    settings.ShowInvisibleTableBorders = showInvisibleTableBordersCheckBox.Checked;
                    settings.ShowNonPrintableCharacters = showNonPrintableCharactersCheckBox.Checked;
                    settings.InvisibleTableBordersColor = invisibleTableBordersColorPanelControl.Color;
                }
            }
#endif
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the CheckedChanged event of resolutionSettingsCheckBox object.
        /// </summary>
        private void resolutionSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // enable/disable resolution groupbox
            resolutionSettingsGroupBox.Enabled = resolutionSettingsCheckBox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of showInvisibleTableBordersCheckBox object.
        /// </summary>
        private void showInvisibleTableBordersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // enable/disable table borders color panel
            invisibleTableBordersGroupBox.Enabled = showInvisibleTableBordersCheckBox.Checked;
        }


#if !REMOVE_PDF_PLUGIN
        /// <summary>
        /// Returns the PDF annotation rendering mode, according to selected values on the form.
        /// </summary>
        /// <returns>PDF annotation rendering mode, according to selected values on the form.</returns>
        private PdfAnnotationRenderingMode GetAnnotationRenderingMode()
        {
            PdfAnnotationRenderingMode result = PdfAnnotationRenderingMode.None;

            if (vintasoftAnnotationsCheckBox.Checked)
                result |= PdfAnnotationRenderingMode.VintasoftAnnotations;
            if (nonMarkupAnnotationsCheckBox.Checked)
                result |= PdfAnnotationRenderingMode.NonMarkupAnnotations;
            if (markupAnnotationsCheckBox.Checked)
                result |= PdfAnnotationRenderingMode.MarkupAnnotations;
            if (renderInvisibleCheckBox.Checked)
                result |= PdfAnnotationRenderingMode.RenderInvisible;
            if (renderHiddenCheckBox.Checked)
                result |= PdfAnnotationRenderingMode.RenderHidden;
            if (renderPrintableCheckBox.Checked)
                result |= PdfAnnotationRenderingMode.RenderPrintable;
            if (renderNoViewCheckBox.Checked)
                result |= PdfAnnotationRenderingMode.RenderNoView;
            if (renderDisplayableCheckBox.Checked)
                result |= PdfAnnotationRenderingMode.RenderDisplayable;

            return result;
        }
#endif

        #endregion

    }
}
