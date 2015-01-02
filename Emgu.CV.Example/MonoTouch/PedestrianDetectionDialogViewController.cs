//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using CoreGraphics;
using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Structure;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using PedestrianDetection;

namespace Emgu.CV.Example.MonoTouch
{
   public class PedestrianDetectionDialogViewController : ButtonMessageImageDialogViewController
   {
      public PedestrianDetectionDialogViewController()
         : base()
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();
         ButtonText = "Detect Pedestrian";
         OnButtonClick += delegate
         { 
            long processingTime;
            using (Image<Bgr, byte> image = new Image<Bgr, byte>("pedestrian.png"))
            {
               Rectangle[] pedestrians = FindPedestrian.Find(
                        image,
                        out processingTime
               );
               foreach (Rectangle rect in pedestrians)
               {
                  image.Draw(rect, new Bgr(0,0,255), 1);
               }
               CGSize frameSize = FrameSize;
               using (Image<Bgr, Byte> resized = image.Resize((int)frameSize.Width, (int)frameSize.Height, Emgu.CV.CvEnum.INTER.CV_INTER_NN, true))
               {
                  MessageText = String.Format(
                            "Detection Time: {0} milliseconds.",
                            processingTime
                  );
                  SetImage(resized);
               }
            }
         };
           
      }
   }
}

