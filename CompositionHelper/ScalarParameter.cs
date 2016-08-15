using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper
{
    /// <summary>
    /// ����������
    /// </summary>
    public class ScalarParameter : Parameter<float>
    {
        public override void AddParameterToAnimation(CompositionAnimation animation)
        {
            animation.SetScalarParameter(Key, ObjectValue);
        }

        protected override float ValueToObject(string value)
        {
            return value.ToScalar();
        }
    }
}