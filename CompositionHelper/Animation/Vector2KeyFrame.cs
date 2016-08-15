using System;
using System.Numerics;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// ��άʸ�������ؼ�֡��
    /// </summary>
    public class Vector2KeyFrame : ValueKeyFrame<Vector2>
    {
        public Vector2KeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is Vector2KeyFrameAnimation)
            {
                (animation as Vector2KeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("����Ķ������͡�");
            }
        }

        protected override Vector2 GetValueObject(string value)
        {
            return value.ToVector2();
        }
    }
}