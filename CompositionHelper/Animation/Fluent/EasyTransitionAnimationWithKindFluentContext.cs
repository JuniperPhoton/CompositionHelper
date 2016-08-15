using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public abstract class EasyTransitionAnimationWithKindFluentContext<T> : EasyTransitionAnimationFluentContext<T>
    {
        internal EasyTransitionAnimationWithKindFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
        }

        protected TransitionAnimationKind AnimationKind { get; set; }

        /// <summary>
        /// ָ�������������ֵ���ж�����
        /// </summary>
        /// <returns></returns>
        public EasyTransitionAnimationWithKindFluentContext<T> RelativeBased()
        {
            AnimationKind = TransitionAnimationKind.Relative;
            return this;
        }

        /// <summary>
        /// [SDK14393+]ָ���������Ծ���ֵ���ж�����
        /// </summary>
        /// <returns></returns>
        public EasyTransitionAnimationWithKindFluentContext<T> AbsolutelyBased()
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
        public new EasyTransitionAnimationWithKindFluentContext<T> BeginAfter(TimeSpan time)
        {
            return base.BeginAfter(time) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> Spend(TimeSpan time)
        {
            return base.Spend(time) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> Spend(double millisecond)
        {
            return base.Spend(millisecond) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ���������ظ�������-1 Ϊ�����ظ���
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> Repeat(int times)
        {
            return base.Repeat(times) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ������Ϊ�����ظ���
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> RepeatForever()
        {
            return base.RepeatForever() as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ���ֵ�ǰֵ��
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> LeaveCurrentValueWhenStop()
        {
            return base.LeaveCurrentValueWhenStop() as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ��ʼֵ��
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetToInitialValueWhenStop()
        {
            return base.SetToInitialValueWhenStop() as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ����ֵ��
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetToFinalValueWhenStop()
        {
            return base.SetToFinalValueWhenStop() as EasyTransitionAnimationWithKindFluentContext<T>;
        }
        #endregion

        #region AnimationFluentContext
        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Color parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Matrix3x2 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Matrix4x4 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Quaternion parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, CompositionObject parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, float parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector2 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector3 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, Vector4 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> SetParameter(string key, bool parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationWithKindFluentContext<T>;
        }
#endif
        #endregion

        #region EasyTransitionAnimationFluentContext
        /// <summary>
        /// ָ��������ʼ��ֵ��
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> From(T value)
        {
            return base.From(value) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ָ������������ֵ��
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> To(T value)
        {
            return base.To(value) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ͨ�����ʽָ��������ʼ��ֵ��
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> FromExpression(String expression)
        {
            return base.FromExpression(expression) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// ͨ�����ʽָ������������ֵ
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> ToExpression(String expression)
        {
            return base.ToExpression(expression) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// Ϊ��ǰ֡����һ�����Ի�����
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> WithLinerEasing()
        {
            return base.WithLinerEasing() as EasyTransitionAnimationWithKindFluentContext<T>;
        }

        /// <summary>
        /// Ϊ��ǰ֡����һ�����ڱ��������ߵĻ�����
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> WithCubicBezierEasing(Point point1, Point point2)
        {
            return base.WithCubicBezierEasing(point1, point2) as EasyTransitionAnimationWithKindFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]Ϊ��ǰ֡����һ�����ڲ����Ļ�����
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationWithKindFluentContext<T> WithStepEasing(int stepCount)
        {
            return base.WithStepEasing(stepCount) as EasyTransitionAnimationWithKindFluentContext<T>;
        }
#endif
        #endregion
    }
}