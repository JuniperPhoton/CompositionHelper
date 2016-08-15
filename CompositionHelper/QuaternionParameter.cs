using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    /// <summary>
    /// ��Ԫ��������
    /// </summary>
    public class QuaternionParameter : Parameter<Quaternion>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetQuaternionParameter(Key, ObjectValue);
        }

        protected override Quaternion ValueToObject(string value)
        {
            return value.ToQuaternion();
        }
    }
}