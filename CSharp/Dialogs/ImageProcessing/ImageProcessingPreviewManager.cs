using System.Drawing;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

namespace ImagingDemo
{
    /// <summary>
    /// Manages the image processing preview in image viewer.
    /// </summary>
    public class ImageProcessingPreviewManager
    {

        #region Fields

        /// <summary>
        /// A value indicating whether image processing preview is started.
        /// </summary>
        bool _isPreviewStarted = false;

        /// <summary>
        /// An image viewer, which contains processing image.
        /// </summary>
        ImageViewer _viewer;

        /// <summary>
        /// The view of the selection in image viewer.
        /// </summary>
        SelectionRegionView _selectionRegionView;

        /// <summary>
        /// The visual tool of image viewer.
        /// </summary>
        VisualTool _viewerTool;

        /// <summary>
        /// Tool for processing the results preview.
        /// </summary>
        ImageProcessingTool _rectangularPreview;

        /// <summary>
        /// Selected region.
        /// </summary>
        Rectangle _rectangularSelectionToolRect;

        /// <summary>
        /// Selected region view.
        /// </summary>
        SelectionRegionViewWithImageProcessingPreview _processedSelectionRegionView;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageProcessingPreviewManager"/> class.
        /// </summary>
        /// <param name="viewer">The image viewer for image preview.</param>
        public ImageProcessingPreviewManager(ImageViewer viewer)
        {
            _viewer = viewer;
        }

        #endregion



        #region Properties

        bool _useCurrentViewerZoomWhenPreviewProcessing = false;
        /// <summary>
        /// Gets or sets a value indicating whether the zoom value of image viewer is used for previewing the image processing.
        /// </summary>
        public bool UseCurrentViewerZoomWhenPreviewProcessing
        {
            get
            {
                return _useCurrentViewerZoomWhenPreviewProcessing;
            }
            set
            {
                _useCurrentViewerZoomWhenPreviewProcessing = value;
            }
        }

        bool _expandSupportedPixelFormats = true;
        /// <summary>
        /// Gets or sets a value indicating whether the processing command need to
        /// convert the processing image to the nearest pixel format without color loss
        /// if processing command does not support pixel format of the processing image.
        /// </summary>
        public bool ExpandSupportedPixelFormats
        {
            get
            {
                return _expandSupportedPixelFormats;
            }
            set
            {
                _expandSupportedPixelFormats = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Starts the preview.
        /// </summary>
        public void StartPreview()
        {
            // if current tool is CustomSelectionTool
            if (_viewer.VisualTool is CustomSelectionTool)
            {
                CustomSelectionTool selectionTool = (CustomSelectionTool)_viewer.VisualTool;
                RectangleF selectionBBox = RectangleF.Empty;
                if (selectionTool.Selection != null)
                    selectionBBox = selectionTool.Selection.GetBoundingBox();
                if (selectionBBox.Width >= 1 && selectionBBox.Height >= 1)
                {
                    _selectionRegionView = selectionTool.Selection.View;
                    _processedSelectionRegionView = new SelectionRegionViewWithImageProcessingPreview();
                    _processedSelectionRegionView.UseViewerZoomForProcessing = UseCurrentViewerZoomWhenPreviewProcessing;
                    selectionTool.Selection.View = _processedSelectionRegionView;
                    _isPreviewStarted = true;
                    return;
                }
            }

            // set current tool to ImageProcessingTool
            _viewerTool = _viewer.VisualTool;
            _rectangularPreview = new ImageProcessingTool();
            Rectangle imageRect = new System.Drawing.Rectangle(0, 0, _viewer.Image.Width, _viewer.Image.Height);
            Rectangle rect = imageRect;
            if (_viewer.VisualTool is RectangularSelectionTool)
            {
                RectangularSelectionTool rectangularSelection = (RectangularSelectionTool)_viewer.VisualTool;
                if (!rectangularSelection.Rectangle.Size.IsEmpty)
                {
                    if (_viewer.VisualTool is RectangularSelectionToolWithCopyPaste)
                        rect = rectangularSelection.Rectangle;
                    _rectangularSelectionToolRect = rectangularSelection.Rectangle;
                }
            }
            _rectangularPreview.UseViewerZoomForPreviewProcessing = UseCurrentViewerZoomWhenPreviewProcessing;
            _viewer.VisualTool = _rectangularPreview;
            _rectangularPreview.Rectangle = rect;
            if (rect == imageRect)
                _rectangularPreview.InteractionController = null;
            _isPreviewStarted = true;
        }

        /// <summary>
        /// Stops the preview.
        /// </summary>
        public void StopPreview()
        {
            if (_viewer.VisualTool is CustomSelectionTool)
            {
                CustomSelectionTool selectionTool = (CustomSelectionTool)_viewer.VisualTool;
                if (selectionTool.Selection != null)
                    selectionTool.Selection.View = _selectionRegionView;
            }
            else
            {
                _viewer.VisualTool = _viewerTool;
                if (_viewer.VisualTool is RectangularSelectionTool)
                    ((RectangularSelectionTool)_viewer.VisualTool).Rectangle = _rectangularSelectionToolRect;
            }
            _isPreviewStarted = false;
        }

        /// <summary>
        /// Sets the current image processing command.
        /// </summary>
        /// <param name="command">The processing command.</param>
        public void SetCommand(ProcessingCommandBase command)
        {
            if (_isPreviewStarted)
            {
                if (command != null)
                {
                    command.ExpandSupportedPixelFormats = ExpandSupportedPixelFormats;
                }

                if (_viewer.VisualTool is CustomSelectionTool)
                {
                    CustomSelectionTool selectionTool = (CustomSelectionTool)_viewer.VisualTool;
                    _processedSelectionRegionView.ProcessingCommand = command;
                    selectionTool.InvalidateItem(selectionTool.Selection);
                }
                else
                {
                    _rectangularPreview.ProcessingCommand = command;
                }
            }
        }

        #endregion

    }
}
