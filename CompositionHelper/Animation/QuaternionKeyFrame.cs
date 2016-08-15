using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// ��Ԫ�������ؼ�֡��
    /// </summary>
    public class QuaternionKeyFrame : ValueKeyFrame<Quaternion>
    {
        public QuaternionKeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is QuaternionKeyFrameAnimation)
            {
                (animation as QuaternionKeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("����Ķ������͡�");
            }
        }

        protected override Quaternion GetValueObject(string value)
        {
            return value.ToQuaternion();
        }
    }
}