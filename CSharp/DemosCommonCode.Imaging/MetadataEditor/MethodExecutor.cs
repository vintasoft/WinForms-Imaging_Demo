using System.Reflection;

namespace DemosCommonCode.Imaging
{
    public class MethodExecutor
    {

        object _obj;
        MethodInfo _method;



        public MethodExecutor(object obj, MethodInfo method)
        {
            _method = method;
            _obj = obj;
        }



        public void Execute()
        {
            _method.Invoke(_obj, new object[] { });
        }

        public override string ToString()
        {
            return _method.Name;
        }

    }
}
