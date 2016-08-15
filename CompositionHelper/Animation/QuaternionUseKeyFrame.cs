using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml.Markup;

namespace CompositionHelper.Animation
{
    /// <summary>
    /// ��Ԫ��������
    /// </summary>
    [ContentProperty(Name = "KeyFrames")]
    public class QuaternionUseKeyFrame : AnimationUseKeyFrame<Quaternion>
    {
        public QuaternionUseKeyFrame()
        {
        }

        protected override KeyFrameAnimation CreateCompositionAnimation(Compositor compositor)
        {
            return compositor.CreateQuaternionKeyFrameAnimation();
        }
    }
}