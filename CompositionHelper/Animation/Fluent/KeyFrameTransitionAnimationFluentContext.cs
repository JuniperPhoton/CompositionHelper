using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public abstract class KeyFrameTransitionAnimationFluentContext<T> : TransitionAnimationFluentContext
    {
        internal KeyFrameTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {
            KeyFrameContexts = new List<IKeyFrameFluentContext>();
        }

        protected IList<IKeyFrameFluentContext> KeyFrameContexts { get; private set; }
        protected IKeyFrameFluentContext CurrentKeyFrameContext { get; private set; }

        /// <summary>
        /// ����һ�����ʽ֡�����ύ��һ֡��
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> ExpressionKeyFrame(String expression)
        {
            InsertActiveKeyFrame();
            CurrentKeyFrameContext = new ExpressionKeyFrameFluentContext { Value = expression };
            return this;
        }

        /// <summary>
        /// ����һ���ؼ�֡�����ύ��һ֡��
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> KeyFrame(T value)
        {
            InsertActiveKeyFrame();
            CurrentKeyFrameContext = new KeyFrameFluentContext<T> { Value = value };
            return this;
        }

        /// <summary>
        /// �ؼ�֡�����Ľ��ȡ�
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> At(float progress)
        {
            CurrentKeyFrameContext.Progress = progress;
            return this;
        }

        /// <summary>
        /// Ϊ��ǰ֡����һ�����Ի�����
        /// </summary>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> WithLinerEasing()
        {
            CurrentKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateLinearEasingFunction();
            return this;
        }

        /// <summary>
        /// Ϊ��ǰ֡����һ�����ڱ��������ߵĻ�����
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> WithCubicBezierEasing(Point point1, Point point2)
        {
            CurrentKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateCubicBezierEasingFunction(point1.ToVector2(), point2.ToVector2());
            return this;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]Ϊ��ǰ֡����һ�����ڲ����Ļ�����
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public KeyFrameTransitionAnimationFluentContext<T> WithStepEasing(int stepCount)
        {
            CurrentKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateStepEasingFunction(stepCount);
            return this;
        }
#endif

        protected override void OnAnimationBuildOver()
        {
            base.OnAnimationBuildOver();
            InsertActiveKeyFrame();
            InsertActiveKeyFrameToAnimation();
        }

        protected abstract void InsertKeyFrame(KeyFrameFluentContext<T> keyFrameContext);
        protected abstract void InsertExpressionKeyFrame(ExpressionKeyFrameFluentContext keyFrameContext);
        private void InsertActiveKeyFrameToAnimation()
        {
            foreach (var frameContext in KeyFrameContexts)
            {
                if (frameContext is ExpressionKeyFrameFluentContext)
                {
                    InsertExpressionKeyFrame(frameContext as ExpressionKeyFrameFluentContext);
                }
                else
                {
                    InsertKeyFrame(frameContext as KeyFrameFluentContext<T>);
                }
            }
            KeyFrameContexts.Clear();
        }
        private void InsertActiveKeyFrame()
        {
            var activeKeyFrame = CurrentKeyFrameContext;

            if (activeKeyFrame == null)
            {
                return;
            }

            KeyFrameContexts.Add(activeKeyFrame);

            CurrentKeyFrameContext = null;
        }

                #region TransitionAnimationFluentContext
        /// <summary>
        /// ָ����ǰ�����ڹ��°濪ʼ���һ���ӳ�ʱ���ִ�С�
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> BeginAfter(TimeSpan time)
        {
            return base.BeginAfter(time) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> Spend(TimeSpan time)
        {
            return base.Spend(time) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> Spend(double millisecond)
        {
            return base.Spend(millisecond) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ���������ظ�������-1 Ϊ�����ظ���
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> Repeat(int times)
        {
            return base.Repeat(times) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ������Ϊ�����ظ���
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> RepeatForever()
        {
            return base.RepeatForever() as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ���ֵ�ǰֵ��
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> LeaveCurrentValueWhenStop()
        {
            return base.LeaveCurrentValueWhenStop() as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ��ʼֵ��
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetToInitialValueWhenStop()
        {
            return base.SetToInitialValueWhenStop() as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ����ֵ��
        /// </summary>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetToFinalValueWhenStop()
        {
            return base.SetToFinalValueWhenStop() as KeyFrameTransitionAnimationFluentContext<T>;
        }
        #endregion

        #region AnimationFluentContext
        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Color parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Matrix3x2 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Matrix4x4 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Quaternion parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, CompositionObject parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, float parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Vector2 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Vector3 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, Vector4 parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new KeyFrameTransitionAnimationFluentContext<T> SetParameter(string key, bool parameter)
        {
            return base.SetParameter(key, parameter) as KeyFrameTransitionAnimationFluentContext<T>;
        }
#endif
        #endregion
    }
}