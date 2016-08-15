using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public abstract class KeyFrameTransitionAnimationWithKindFluentContext<T> :
        KeyFrameTransitionAnimationFluentContext<T>
    {
        internal KeyFrameTransitionAnimationWithKindFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected TransitionAnimationKind AnimationKind { get; set; }
        /// <summary>
        /// ָ�������������ֵ���ж�����
        /// </summary>
        /// <returns></returns>
        public KeyFrameTransitionAnimationWithKindFluentContext<T> RelativeBased()
        {
            AnimationKind = TransitionAnimationKind.Relative;
            return this;
        }

        /// <summary>
        /// [SDK14393+]ָ���������Ծ���ֵ���ж�����
        /// </summary>
        /// <returns></returns>
        public KeyFrameTransitionAnimationWithKindFluentContext<T> AbsolutelyBased()
        {
            AnimationKind = TransitionAnimationKind.Absolute;
            return this;
        }

        #region TransitionAnimationFluentContext
        /// <summary>
        /// ָ����ǰ�����ڹ��°濪ʼ���һ���ӳ�ʱ���ִ�С�
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> BeginAfter(TimeSpan time)
        {
            return base.BeginAfter(time) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> Spend(TimeSpan time)
        {
            return base.Spend(time) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> Spend(double millisecond)
        {
            return base.Spend(millisecond) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ���������ظ�������-1 Ϊ�����ظ���
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> Repeat(int times)
        {
            return base.Repeat(times) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ������Ϊ�����ظ���
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> RepeatForever()
        {
            return base.RepeatForever() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ���ֵ�ǰֵ��
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> LeaveCurrentValueWhenStop()
        {
            return base.LeaveCurrentValueWhenStop() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ��ʼֵ��
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetToInitialValueWhenStop()
        {
            return base.SetToInitialValueWhenStop() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ����ֵ��
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetToFinalValueWhenStop()
        {
            return base.SetToFinalValueWhenStop() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }
        #endregion

        #region AnimationFluentContext
        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Color parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Matrix3x2 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Matrix4x4 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Quaternion parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, CompositionObject parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, float parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector2 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector3 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector4 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> SetParameter(string key, bool parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }
#endif
        #endregion

        #region EasyTransitionAnimationFluentContext
        /// <summary>
        /// ����һ�����ʽ֡�����ύ��һ֡��
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> ExpressionKeyFrame(String expression)
        {
            return base.ExpressionKeyFrame(expression) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ����һ���ؼ�֡�����ύ��һ֡��
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> KeyFrame(T value)
        {
            return base.KeyFrame(value) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// �ؼ�֡�����Ľ��ȡ�
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> At(float progress)
        {
            return base.At(progress) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// Ϊ��ǰ֡����һ�����Ի�����
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> WithLinerEasing()
        {
            return base.WithLinerEasing() as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// Ϊ��ǰ֡����һ�����ڱ��������ߵĻ�����
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> WithCubicBezierEasing(Point point1, Point point2)
        {
            return base.WithCubicBezierEasing(point1, point2) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]Ϊ��ǰ֡����һ�����ڲ����Ļ�����
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationWithKindFluentContext<T> WithStepEasing(int stepCount)
        {
            return base.WithStepEasing(stepCount) as KeyFrameTransitionAnimationWithKindFluentContext<T>;
        }
#endif
        #endregion
    }
}