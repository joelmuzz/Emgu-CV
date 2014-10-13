//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Emgu.Util;

namespace Emgu.CV.VideoStab
{
   /// <summary>
   /// Gaussian motion filter
   /// </summary>
   public class GaussianMotionFilter : UnmanagedObject
   {
      /// <summary>
      /// Create a Gaussian motion filter
      /// </summary>
      public GaussianMotionFilter()
      {
         _ptr = VideoStabInvoke.GaussianMotionFilterCreate();
      }

      /// <summary>
      /// Release all the unmanaged memory associated with this object
      /// </summary>
      protected override void DisposeObject()
      {
         VideoStabInvoke.GaussianMotionFilterRelease(ref _ptr);
      }
   }
}
