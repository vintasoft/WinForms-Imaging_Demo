using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace DemosCommonCode
{
    /// <summary>
    /// A base form for the application about dialog.
    /// </summary>
    public partial class AboutBoxBaseForm : Form
    {
        
        #region Constructors

        public AboutBoxBaseForm()
        {
            InitializeComponent();
        }

        public AboutBoxBaseForm(string productPrefix)
            :this()
        {
            nameLabel.Text = string.Format(nameLabel.Text, AssemblyTitle, AssemblyShortVersion);
            imagingSDKVersionLabel.Text = string.Format(imagingSDKVersionLabel.Text, ImagingSDKVersion);
            productLinkLabel.Text = string.Format(productLinkLabel.Text, productPrefix);
        }

        #endregion



        #region Properties

        [Browsable(false)]
        public string AssemblyTitle
        {
            get
            {

                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        [Browsable(false)]
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
        }

        [Browsable(false)]
        public string AssemblyShortVersion
        {
            get
            {
                Version ver = Assembly.GetEntryAssembly().GetName().Version;
                return string.Format("{0}.{1}", ver.Major, ver.Minor);
            }
        }

        [Browsable(false)]
        public string ImagingSDKVersion
        {
            get
            {
                Assembly imagingAssembly = Assembly.GetAssembly(typeof(Vintasoft.Imaging.VintasoftImage));
                return imagingAssembly.GetName().Version.ToString();
            }
        }

        #endregion

        
        
        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            Text = "About...";
            base.OnLoad(e);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(string.Format("http://{0}", ((LinkLabel)sender).Text));
        }

        private void vintasoftLogoPictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.vintasoft.com");
        }

        #endregion

    }
}