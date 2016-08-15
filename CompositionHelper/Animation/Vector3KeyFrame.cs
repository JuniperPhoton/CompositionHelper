using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// ��άʸ�������ؼ�֡��
    /// </summary>
    public class Vector3KeyFrame : ValueKeyFrame<Vector3>
    {
        public Vector3KeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector3KeyFrameAnimation)
            {
                (animation as Vector3KeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("����Ķ������͡�");
            }
        }

        protected override Vector3 GetValueObject(string value)
        {
            return value.ToVector3();
        }
    }
}