using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// ��άʸ�������ؼ�֡��
    /// </summary>
    public class Vector4KeyFrame : ValueKeyFrame<Vector4>
    {
        public Vector4KeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector4KeyFrameAnimation)
            {
                (animation as Vector4KeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("����Ķ������͡�");
            }
        }

        protected override Vector4 GetValueObject(string value)
        {
            return value.ToVector4();
        }
    }
}