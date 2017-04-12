using System;
using System.Diagnostics;
using System.Numerics;
using Windows.Foundation;
using CompositionHelper.Animation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using CompositionHelper;
using CompositionHelper.Animation.Fluent;

namespace Sample
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        private async void Rectangle_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //await Rectangle.GetVisual().StartBuildAnimation()
            //    .Animate(AnimatableProperties.Translation.Y)
            //    .ToExpression("this.target.Translation.y + 100")
            //    .Spend(TimeSpan.FromSeconds(0.5))
            //    .Over()
            //    .Start()
            //    .Wait();

            Rectangle.GetVisual().StartBuildAnimation()
                .Animate(AnimatableProperties.Offset.XY)
                .To(20)
                .Spend(500)
                .Over()
                .Start();

            //Rectangle.GetVisual().Offset = new Vector3(100, 100, 0);
        }
    }
}