using System;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public class TransitionAnimationFluentContext : AnimationFluentContext
    {
        internal TransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        /// <summary>
        /// ָ����ǰ�����ڹ��°濪ʼ���һ���ӳ�ʱ���ִ�С�
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public TransitionAnimationFluentContext BeginAfter(TimeSpan time)
        {
            (CompositionAnimation as KeyFrameAnimation).DelayTime = time;
            return this;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public TransitionAnimationFluentContext Spend(TimeSpan time)
        {
            (CompositionAnimation as KeyFrameAnimation).Duration = time;
            return this;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public TransitionAnimationFluentContext Spend(double millisecond)
        {
            return Spend(TimeSpan.FromMilliseconds(millisecond));
        }

        /// <summary>
        /// ָ���������ظ�������-1 Ϊ�����ظ���
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public TransitionAnimationFluentContext Repeat(int times)
        {
            if (times == -1)
            {
                return RepeatForever();
            }
            else
            {
                (CompositionAnimation as KeyFrameAnimation).IterationBehavior = AnimationIterationBehavior.Count;
                (CompositionAnimation as KeyFrameAnimation).IterationCount = times;
                return this;
            }
        }

        /// <summary>
        /// ָ������Ϊ�����ظ���
        /// </summary>
        /// <returns></returns>
        public TransitionAnimationFluentContext RepeatForever()
        {
            (CompositionAnimation as KeyFrameAnimation).IterationBehavior = AnimationIterationBehavior.Forever;
            (CompositionAnimation as KeyFrameAnimation).IterationCount = -1;
            return this;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ���ֵ�ǰֵ��
        /// </summary>
        /// <returns></returns>
        public TransitionAnimationFluentContext LeaveCurrentValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.LeaveCurrentValue;
            return this;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ��ʼֵ��
        /// </summary>
        /// <returns></returns>
        public TransitionAnimationFluentContext SetToInitialValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.SetToInitialValue;
            return this;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ����ֵ��
        /// </summary>
        /// <returns></returns>
        public TransitionAnimationFluentContext SetToFinalValueWhenStop()
        {
            (CompositionAnimation as KeyFrameAnimation).StopBehavior = AnimationStopBehavior.SetToFinalValue;
            return this;
        }
    }
}