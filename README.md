# VintaSoft WinForms Imaging Demo

This C# project uses <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html">VintaSoft Imaging .NET SDK</a> and demonstrates how to process images in WinForms:
* Load image from file, acquire from TWAIN scanner, capture from webcam.
* Display, print and save all supported image and document formats.
* Navigate images: first, previous, next, last.
* Copy image to/from clipboard.
* Access image pixels directly.
* Set image and thumbnail preview settings.
* Process images using 90+ image processing functions.
* Undo/redo changes in processed images.
* View image slide show.
* View and edit image palette.
* Process images interactively: select, magnify, crop, drag-n-drop, overlay, zoom, pan, scroll.
* Supported image formats: BMP, CUR, DICOM, DOC, DOCX, XLS, XLSX, EMF, GIF, ICO, JBIG2, JPEG, JPEG2000, JPEG-LS, PCX, PDF, PNG, TIFF, BigTIFF, WMF, RAW (NEF, NRW, CR2, CRW, DNG).


## Screenshot
<img src="vintasoft-imaging-demo.png" title="VintaSoft Imaging Demo">


## Usage
1. Get the 30 day free evaluation license for <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html" target="_blank">VintaSoft Imaging .NET SDK</a> as described here: <a href="https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html" target="_blank">https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html</a>

2. Update the evaluation license in "CSharp\MainForm.cs" file:
   ```
   Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");
   ```

3. Build the project ("ImagingDemo.Net8.csproj" file) in Visual Studio or using .NET CLI:
   ```
   dotnet build ImagingDemo.Net8.csproj
   ```

4. Run compiled application and try to process images.


## Documentation
VintaSoft Imaging .NET SDK on-line User Guide and API Reference for .NET developer is available here: https://www.vintasoft.com/docs/vsimaging-dotnet/


## Support
Please visit our <a href="https://myaccount.vintasoft.com/">online support center</a> if you have any question or problem.
