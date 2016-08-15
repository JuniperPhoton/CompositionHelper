using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    /// <summary>
    /// 3x2���������
    /// </summary>
    public class Matrix3x2Parameter : Parameter<Matrix3x2>
    {
        /// <summary>
        /// Ϊ������Ӳ�����
        /// </summary>
        /// <param name="animation"></param>
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetMatrix3x2Parameter(Key, ObjectValue);
        }

        protected override Matrix3x2 ValueToObject(string value)
        {
            return value.ToMatrix3x2();
        }
    }
}