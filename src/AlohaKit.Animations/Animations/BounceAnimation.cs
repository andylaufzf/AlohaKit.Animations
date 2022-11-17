﻿namespace AlohaKit.Animations
{
    using System;
    using System.Threading.Tasks;


    public class BounceInAnimation : AnimationBase
    {
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Task.Run(() =>
            {
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("BounceIn", BounceIn(), 16, Convert.ToUInt32(Duration));
                });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
            });
        }

        internal Animation BounceIn()
        {
            var animation = new Animation();

            animation.WithConcurrent(
                           f => Target.Scale = f,
                            0.5, 1,
                           Microsoft.Maui.Easing.Linear, 0, 1);

            animation.WithConcurrent(
                    (f) => Target.Opacity = f,
                    0, 1,
                    null,
                    0, 0.25);

            return animation;
        }
    }

    public class BounceOutAnimation : AnimationBase
    {
        protected override Task BeginAnimation()
        {
            if (Target == null)
            {
                throw new NullReferenceException("Null Target property.");
            }

            return Task.Run(() =>
            {
#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("BounceOut", BounceOut(), 16, Convert.ToUInt32(Duration));
                });
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0612 // Type or member is obsolete
            });
        }

        internal Animation BounceOut()
        {
            var animation = new Animation();

            Target.Opacity = 1;

            animation.WithConcurrent(
                (f) => Target.Opacity = f,
                1, 0,
                null,
                0.5, 1);

            animation.WithConcurrent(
                (f) => Target.Scale = f,
                1, 0.3,
                Microsoft.Maui.Easing.Linear, 0, 1);

            return animation;
        }
    }
}
