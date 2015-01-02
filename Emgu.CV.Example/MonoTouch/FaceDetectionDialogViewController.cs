//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using CoreGraphics;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using MonoTouch.Dialog;
using Foundation;
using UIKit;
using FaceDetection;

namespace Emgu.CV.Example.MonoTouch
{
   public class FaceDetectionDialogViewController : ButtonMessageImageDialogViewController
   {
      public FaceDetectionDialogViewController()
         : base()
      {
      }

      public override void ViewDidLoad()
      {
         base.ViewDidLoad();

         ButtonText = "Detect Face & Eyes";
         OnButtonClick += delegate
         {
            long processingTime;
            using (Image<Bgr, Byte> image = new Image<Bgr, Byte>("lena.jpg"))
            {
               List<Rectangle> faces = new List<Rectangle>();
               List<Rectangle> eyes = new List<Rectangle>();
               DetectFace.Detect(
                        image,
                        "haarcascade_frontalface_default.xml",
                        "haarcascade_eye.xml",
                        faces,
                        eyes,
                        out processingTime
               );
               foreach (Rectangle face in faces)
                  image.Draw(face, new Bgr(Color.Red), 1);
               foreach (Rectangle eye in eyes)
                  image.Draw(eye, new Bgr(Color.Blue), 1);
               CGSize frameSize = FrameSize;
               using (Image<Bgr, Byte> resized =image.Resize((int)frameSize.Width, (int)frameSize.Height, Emgu.CV.CvEnum.INTER.CV_INTER_NN, true))
               {
                  SetImage(resized);
               }
            }
            MessageText = String.Format(
                    "Processing Time: {0} milliseconds.",
                    processingTime
            );
                
         };
      }

   }
}


