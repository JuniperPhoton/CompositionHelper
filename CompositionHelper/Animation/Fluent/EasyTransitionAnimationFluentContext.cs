using System;
using System.Numerics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Composition;
using CompositionHelper.Annotations;

namespace CompositionHelper.Animation.Fluent
{
    public abstract class EasyTransitionAnimationFluentContext<T> : TransitionAnimationFluentContext
    {
        internal EasyTransitionAnimationFluentContext([NotNull] StoryBoardFluentContext parentStoryBoard, [NotNull] KeyFrameAnimation animation, [NotNull] String targetProperty) : base(parentStoryBoard, animation, targetProperty)
        {

        }

        protected IKeyFrameFluentContext FromKeyFrameContext { get; private set; }
        protected IKeyFrameFluentContext ToKeyFrameContext { get; private set; }


        /// <summary>
        /// Ϊ��ǰ֡����һ�����Ի�����
        /// </summary>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> WithLinerEasing()
        {
            ToKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateLinearEasingFunction();
            return this;
        }

        /// <summary>
        /// Ϊ��ǰ֡����һ�����ڱ��������ߵĻ�����
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> WithCubicBezierEasing(Point point1, Point point2)
        {
            ToKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateCubicBezierEasingFunction(point1.ToVector2(), point2.ToVector2());
            return this;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]Ϊ��ǰ֡����һ�����ڲ����Ļ�����
        /// </summary>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> WithStepEasing(int stepCount)
        {
            ToKeyFrameContext.EasingFunction = CompositionAnimation.Compositor.CreateStepEasingFunction(stepCount);
            return this;
        }
#endif

        protected override void OnAnimationBuildOver()
        {
            base.OnAnimationBuildOver();
            InsertActiveKeyFrameToAnimation();
        }

        protected abstract void InsertKeyFrame(KeyFrameFluentContext<T> keyFrameContext);
        protected abstract void InsertExpressionKeyFrame(ExpressionKeyFrameFluentContext keyFrameContext);

        private void InsertActiveKeyFrameToAnimation()
        {
            if (FromKeyFrameContext != null)
            {
                if (FromKeyFrameContext is ExpressionKeyFrameFluentContext)
                {
                    InsertExpressionKeyFrame(FromKeyFrameContext as ExpressionKeyFrameFluentContext);
                }
                else
                {
                    InsertKeyFrame(FromKeyFrameContext as KeyFrameFluentContext<T>);
                }
            }

            if (ToKeyFrameContext != null)
            {
                if (ToKeyFrameContext is ExpressionKeyFrameFluentContext)
                {
                    InsertExpressionKeyFrame(ToKeyFrameContext as ExpressionKeyFrameFluentContext);
                }
                else
                {
                    InsertKeyFrame(ToKeyFrameContext as KeyFrameFluentContext<T>);
                }
            }
        }

        /// <summary>
        /// ָ��������ʼ��ֵ��
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> From(T value)
        {
            if (FromKeyFrameContext != null)
            {
                throw new InvalidOperationException("From �Ѿ���ָ����");
            }

            FromKeyFrameContext = new KeyFrameFluentContext<T>
            {
                Value = value,
                Progress = 0
            };
            return this;
        }

        /// <summary>
        /// ָ������������ֵ��
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> To(T value)
        {
            if (ToKeyFrameContext != null)
            {
                throw new InvalidOperationException("To �Ѿ���ָ����");
            }

            ToKeyFrameContext = new KeyFrameFluentContext<T>
            {
                Value = value,
                Progress = 1
            };
            return this;
        }

        /// <summary>
        /// ͨ�����ʽָ��������ʼ��ֵ��
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> FromExpression(String expression)
        {
            if (FromKeyFrameContext != null)
            {
                throw new InvalidOperationException("From �Ѿ���ָ����");
            }

            FromKeyFrameContext = new ExpressionKeyFrameFluentContext
            {
                Value = expression,
                Progress = 0
            };
            return this;
        }

        /// <summary>
        /// ͨ�����ʽָ������������ֵ
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public EasyTransitionAnimationFluentContext<T> ToExpression(String expression)
        {
            if (ToKeyFrameContext != null)
            {
                throw new InvalidOperationException("To �Ѿ���ָ����");
            }

            ToKeyFrameContext = new ExpressionKeyFrameFluentContext()
            {
                Value = expression,
                Progress = 1
            };
            return this;
        }

        #region TransitionAnimationFluentContext
        /// <summary>
        /// ָ����ǰ�����ڹ��°濪ʼ���һ���ӳ�ʱ���ִ�С�
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> BeginAfter(TimeSpan time)
        {
            return base.BeginAfter(time) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> Spend(TimeSpan time)
        {
            return base.Spend(time) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ����ǰ���������ѵ�ʱ�䡣
        /// </summary>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> Spend(double millisecond)
        {
            return base.Spend(millisecond) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ���������ظ�������-1 Ϊ�����ظ���
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> Repeat(int times)
        {
            return base.Repeat(times) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ������Ϊ�����ظ���
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> RepeatForever()
        {
            return base.RepeatForever() as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ���ֵ�ǰֵ��
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> LeaveCurrentValueWhenStop()
        {
            return base.LeaveCurrentValueWhenStop() as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ��ʼֵ��
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetToInitialValueWhenStop()
        {
            return base.SetToInitialValueWhenStop() as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ָ�������ڽ���ʱ����Ϊ����ֵ��
        /// </summary>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetToFinalValueWhenStop()
        {
            return base.SetToFinalValueWhenStop() as EasyTransitionAnimationFluentContext<T>;
        }
        #endregion

        #region AnimationFluentContext
        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Color parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Matrix3x2 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Matrix4x4 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Quaternion parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, CompositionObject parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, float parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Vector2 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Vector3 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

        /// <summary>
        /// ��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, Vector4 parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }

#if SDKVERSION_INSIDER
        /// <summary>
        /// [SDK14393+]��һ���������붯����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public new EasyTransitionAnimationFluentContext<T> SetParameter(string key, bool parameter)
        {
            return base.SetParameter(key, parameter) as EasyTransitionAnimationFluentContext<T>;
        }
#endif
        #endregion
    }
}