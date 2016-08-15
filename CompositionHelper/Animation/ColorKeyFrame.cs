using System;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Helper;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// ��ɫ�����ؼ�֡��
    /// </summary>
    public class ColorKeyFrame : ValueKeyFrame<Color>
    {
        public ColorKeyFrame()
        {
        }

        public override void AddKayFrameToAnimation(KeyFrameAnimation animation)
        {
            if (animation is ColorKeyFrameAnimation)
            {
                (animation as ColorKeyFrameAnimation).InsertKeyFrame((float)Progress, ValueObject, EasingFunction.CreateCompositionEasingFunction(animation.Compositor));
            }
            else
            {
                throw new InvalidOperationException("����Ķ������͡�");
            }
        }

        protected override Color GetValueObject(string value)
        {
            return value.ToColor();
        }
    }
}