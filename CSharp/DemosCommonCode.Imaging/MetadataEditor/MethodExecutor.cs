using System.Reflection;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Executes the specified method.
    /// </summary>
    public class MethodExecutor
    {

        #region Fields

        /// <summary>
        /// The invoke target object.
        /// </summary>
        object _obj;

        /// <summary>
        /// The method, which must be called.
        /// </summary>
        MethodInfo _method;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodExecutor"/> class.
        /// </summary>
        /// <param name="obj">The invoke target object.</param>
        /// <param name="method">The method, which must be called.</param>
        public MethodExecutor(object obj, MethodInfo method)
        {
            _method = method;
            _obj = obj;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Executes the method.
        /// </summary>
        public void Execute()
        {
            _method.Invoke(_obj, new object[] { });
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _method.Name;
        } 

        #endregion

    }
}
