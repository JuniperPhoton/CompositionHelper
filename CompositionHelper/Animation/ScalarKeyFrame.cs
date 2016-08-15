using System;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// ���������ؼ�֡��
    /// </summary>
    public class ScalarKeyFrame : ValueKeyFrame<float>
    {
        public ScalarKeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is ScalarKeyFrameAnimation)
            {
                (animation as ScalarKeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("����Ķ������͡�");
            }
        }

        protected override float GetValueObject(string value)
        {
            return value.ToScalar();
        }
    }
}