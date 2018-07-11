﻿using System;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace XamControls.iOS.Controls
{
    public class ValueView : UIView
    {
        public static float kLayoutMarginInset = 4;

        private CAShapeLayer outerShapeLayer;
        private CAShapeLayer innerShapeLayer;

        public UILabel TextLabel;
        public UIView ShapeView;

        public UIColor OuterFillColor 
        {
            //get { return outerShapeLayer.FillColor; }
            set
            {
                outerShapeLayer.FillColor = value.CGColor;
                outerShapeLayer.RemoveAllAnimations();
            }
        }

        public UIColor InnerFillColor
        {
            //get { return outerShapeLayer.FillColor; }
            set
            {
                innerShapeLayer.FillColor = value.CGColor;
                innerShapeLayer.RemoveAllAnimations();
            }
        }

        public ValueView()
        {
            Initialize();
        }

        public ValueView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        private void Initialize()
        {
            TextLabel = new UILabel();
            ShapeView = new UIView();

            outerShapeLayer = new CAShapeLayer();
            innerShapeLayer = new CAShapeLayer();

            ShapeView.Frame = Bounds;
            ShapeView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            ShapeView.Layer.AddSublayer(outerShapeLayer);
            ShapeView.Layer.AddSublayer(innerShapeLayer);
            this.AddSubview(ShapeView);

            ShapeView.AddSubview(TextLabel);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            TextLabel.Frame = this.Bounds;

            outerShapeLayer.Path = UIBezierPath.FromOval(ShapeView.Bounds).CGPath;
            innerShapeLayer.Path = UIBezierPath.FromOval(ShapeView.Bounds.Inset(dx: kLayoutMarginInset, dy: kLayoutMarginInset)).CGPath;
            Layer.RemoveAllAnimations();
        }

        public void AnimateTrackingBegin()
        {
            //TODO: Implement animation   
        }

        public void AnimateTrackingEnd()
        {
            //TODO: Implement animation
        }
    }
}
