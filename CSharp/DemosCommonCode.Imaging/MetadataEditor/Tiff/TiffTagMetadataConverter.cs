using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.ImageFiles.Tiff;
using Vintasoft.Imaging.Metadata;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// A converter for TIFF tag metadata.
    /// </summary>
    public class TiffTagMetadataConverter
    {

        #region Fields

        TiffTagMetadata _node;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TiffTagMetadataConverter"/> class.
        /// </summary>
        /// <param name="node">TIFF tag metadata.</param>
        public TiffTagMetadataConverter(TiffTagMetadata node)
        {
            _node = node;
        }

        #endregion



        #region Properties

        /// <summary> 
        /// Gets a value that indicating whether the metadata node can be copied
        /// to new metadata three.
        /// </summary>
        [Description("Indicates whether the metadata node can be copied to new metadata three.")]
        [Category("Metadata node")]
        public bool CanCopy
        {
            get
            {
                return _node.CanCopy;
            }
        }

        /// <summary>
        /// Gets a name of the node.
        /// </summary>
        [Description("Name of the node.")]
        [Category("Metadata node")]
        public string Name
        {
            get
            {
                return _node.Name;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the node is read-only.
        /// </summary>
        /// <value>
        /// <b>true</b> - node is read-only;
        /// <b>false</b> - node is not read-only.
        /// </value>
        [Description("Indicates whether the node is read-only.")]
        [Category("Metadata node")]
        public bool IsReadOnly
        {
            get
            {
                return _node.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the node is changed.
        /// </summary>
        /// <value>
        /// <b>true</b> - node is changed;
        /// <b>false</b> - node is not changed.
        /// </value>
        [Description("Indicates whether the node is changed.")]
        [Category("Metadata node")]
        public bool IsChanged
        {
            get
            {
                return _node.IsChanged;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the node is leaf of metadata tree.
        /// </summary>
        [Description("Indicates whether the node is leaf of metadata tree.")]
        [Category("Metadata node")]
        public bool IsLeafNode
        {
            get
            {
                return _node.IsLeafNode;
            }
        }

        /// <summary>
        /// Gets the ID of TIFF tag.
        /// </summary>
        [Description("ID of TIFF tag.")]
        public int Id
        {
            get
            {
                return _node.Id;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the node has value.
        /// </summary>
        [Description("Indicates whether the node has value.")]
        [Category("Metadata node")]
        public bool HasValue
        {
            get
            {
                return _node.HasValue;
            }
        }

        /// <summary>
        /// Gets a value that indicating whether the metadata node can be deleted 
        /// from children collection of parent node.
        /// </summary>
        [Description("Indicates whether the metadata node can be deleted from children collection of parent node.")]
        [Category("Metadata node")]
        public bool CanDelete
        {
            get
            {
                return _node.CanRemove;
            }
        }

        /// <summary>
        /// Gets the data type of TIFF tag.
        /// </summary>
        [Description("Data type of TIFF tag.")]
        public TiffTagDataType DataType
        {
            get
            {
                return _node.DataType;
            }
        }

        /// <summary>
        /// Gets or sets the node value.
        /// </summary>
        [Description("Node value.")]
        [ReadOnly(true)]
        public object Value
        {
            get
            {
                return _node.Value;
            }
            set
            {
                _node.Value = value;
            }
        }

        /// <summary>
        /// Gets or sets the node value as string.
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        [Description("Node value as string.")]
        public string ValueAsString
        {
            get
            {
                if (_node.Value == null)
                    return null;

                TiffTagId id = (TiffTagId)_node.Id;
                Type enumType = null;

                switch (id)
                {
                    case TiffTagId.Compression:
                        enumType = typeof(TiffCompression);
                        break;

                    case TiffTagId.PhotometricInterpretation:
                        enumType = typeof(PhotometricInterpretation);
                        break;

                    case TiffTagId.SampleFormat:
                        enumType = typeof(SampleFormat);
                        break;

                    case TiffTagId.PlanarConfiguration:
                        enumType = typeof(PlanarConfiguration);
                        break;

                    case TiffTagId.ExtraSamples:
                        enumType = typeof(ExtraSamples);
                        break;
                }

                if (enumType != null)
                {
                    string format = "{0} ({1})";
                    if (_node.Value is Array)
                    {
                        Array nodeValueArray = (Array)_node.Value;
                        string[] nodeValueArrayString = new string[nodeValueArray.Length];
                        for (int i = 0; i < nodeValueArray.Length; i++)
                            nodeValueArrayString[i] =
                                string.Format(format, nodeValueArray.GetValue(i), Enum.GetName(enumType, nodeValueArray.GetValue(i)));
                        return GetArrayAsString(nodeValueArrayString);
                    }
                    else
                        return string.Format(format, _node.Value, Enum.GetName(enumType, _node.Value));
                }

                object nodeValue = _node.Value;
                Type nodeValueType = nodeValue.GetType();

                if (nodeValueType == typeof(byte[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(Int16[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(UInt16[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(Single[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(Int32[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(UInt32[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(Int64[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(UInt64[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(TiffRational))
                    return ((TiffRational)_node.Value).ToFloat().ToString();
                else if (nodeValueType == typeof(TiffSRational))
                    return ((TiffSRational)_node.Value).ToFloat().ToString();
                else if (nodeValueType == typeof(TiffRational[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(TiffSRational[]))
                    return GetArrayAsString(nodeValue);
                else if (nodeValueType == typeof(String))
                    return nodeValue.ToString().Replace("\0", "");

                return _node.Value.ToString();
            }
            set
            {
                if (_node.IsReadOnly)
                    throw new Exception("This node is read-only.");

                Type nodeValueType = _node.Value.GetType();

                if (nodeValueType.IsArray)
                {
                    MessageBox.Show("Array value cannot be edited in this demo.");
                    return;
                }

                if (nodeValueType == typeof(sbyte))
                    _node.Value = sbyte.Parse(value);
                else if (nodeValueType == typeof(byte))
                    _node.Value = byte.Parse(value);
                else if (nodeValueType == typeof(Int16))
                    _node.Value = Int16.Parse(value);
                else if (nodeValueType == typeof(UInt16))
                    _node.Value = UInt16.Parse(value);
                else if (nodeValueType == typeof(Int32))
                    _node.Value = Int32.Parse(value);
                else if (nodeValueType == typeof(UInt32))
                    _node.Value = UInt32.Parse(value);
                else if (nodeValueType == typeof(Int64))
                    _node.Value = Int64.Parse(value);
                else if (nodeValueType == typeof(UInt64))
                    _node.Value = UInt64.Parse(value);
                else if (nodeValueType == typeof(float))
                    _node.Value = float.Parse(value);
                else if (nodeValueType == typeof(double))
                    _node.Value = double.Parse(value);
                else if (nodeValueType == typeof(string))
                    _node.Value = value;
                else if (nodeValueType == typeof(TiffSRational))
                {
                    float floatValue = float.Parse(value);
                    TiffSRational oldValue = (TiffSRational)_node.Value;
                    _node.Value = new TiffSRational((int)(floatValue * oldValue.Denominator), oldValue.Denominator);
                }
                else if (nodeValueType == typeof(TiffRational))
                {
                    float floatValue = float.Parse(value);
                    TiffRational oldValue = (TiffRational)_node.Value;
                    _node.Value = new TiffRational((uint)(floatValue * oldValue.Denominator), oldValue.Denominator);
                }
                else
                    MessageBox.Show(string.Format("Value of type '{0}' cannot be edited in this demo.", nodeValueType));
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Returns array as a string.
        /// </summary>
        /// <param name="value">Array value.</param>
        /// <returns>Array as a string.</returns>
        private string GetArrayAsString(object value)
        {
            Array valueAsArray = (Array)value;
            int count = valueAsArray.Length;
            if (count > 50)
                count = 50;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                object arrayValue = valueAsArray.GetValue(i);
                if (arrayValue is TiffRational)
                    sb.Append(((TiffRational)arrayValue).ToFloat().ToString());
                else if (arrayValue is TiffSRational)
                    sb.Append(((TiffSRational)arrayValue).ToFloat().ToString());
                else
                    sb.Append(arrayValue.ToString());
                sb.Append(' ');
            }

            if (count < valueAsArray.Length)
                sb.Append("...");

            return sb.ToString();
        }

        #endregion

    }
}
