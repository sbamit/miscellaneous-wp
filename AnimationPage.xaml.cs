using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace miscellaneous
{
    public partial class AnimationPage : PhoneApplicationPage
    {
        public AnimationPage()
        {
            InitializeComponent();
       
        }

        Storyboard sB1 = new Storyboard();
        DoubleAnimation dA1 = new DoubleAnimation();
        TimeSpan tSpan = new TimeSpan(0, 0, 0, 0, 3000);    // 3 sec  
        Storyboard sB2 = new Storyboard();
        DoubleAnimation dA2 = new DoubleAnimation();
        TimeSpan tSpan2 = new TimeSpan(0, 0, 0, 0, 1000);    // 1 sec  

        //void FadeSetUp()
        //{
        //    textBlock1.Opacity = 0; // make it invisible  

        //    dA1.Duration = tSpan;   // set the time  
        //    dA1.From = 1;   // visible  
        //    dA1.To = 0; // invisible  
        //    Storyboard.SetTarget(dA1, textBlock1);    // set the control as the target  
        //    Storyboard.SetTargetProperty(dA1, new PropertyPath("Opacity")); // set the property path to opacity  
        //    sB1.Children.Add(dA1);

        //    dA2.Duration = tSpan2;   // set the time  
        //    dA2.From = 1;   // visible  
        //    dA2.To = 1; // visible  
        //    Storyboard.SetTarget(dA2, textBlock1);    // set the control as the target  
        //    Storyboard.SetTargetProperty(dA2, new PropertyPath("Opacity")); // set the property path to opacity  
        //    sB2.Completed += new EventHandler(sB2_Completed);
        //    sB2.Children.Add(dA2);
        //}

        void sB2_Completed(object sender, EventArgs e)
        {
            sB1.Begin();    // animate  
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //textBlock1.Opacity = 1; // make it visible  
            sB2.Begin();    // animate  
        }

        private void MyAnimatedRectangle_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            myStoryboard.Begin();
        }

        private void MyAnimatedRectangle1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // If the Storyboard is running and you try to change
            // properties of its animation objects programmatically, 
            // an error will occur.
            //myStoryboard1.Stop();

            // Get a reference to the rectangle that was clicked.
            TextBlock myRect = (TextBlock)sender;

            // Change the TargetName of the animation to the name of the
            // rectangle that was clicked.
            //myDoubleAnimation.SetValue(Storyboard.TargetNameProperty, myRect.Name);

            // Begin the animation.
            //myStoryboard1.Begin();
        }
        //private void Start_Animation(object sender, MouseEventArgs e)
        //{

        //    // If the Storyboard is running and you try to change
        //    // properties of its animation objects programmatically, 
        //    // an error will occur.
        //    myStoryboard.Stop();

        //    // Get a reference to the rectangle that was clicked.
        //    Rectangle myRect = (Rectangle)sender;

        //    // Change the TargetName of the animation to the name of the
        //    // rectangle that was clicked.
        //    myDoubleAnimation.SetValue(Storyboard.TargetNameProperty, myRect.Name);

        //    // Begin the animation.
        //    myStoryboard.Begin();
        //}


    }
}