//----------------------------------------------------------------------------
//  Copyright (C) 2004-2013 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;

namespace Emgu.CV.GPU
{
   public static partial class GpuInvoke
   {
      /// <summary>
      /// Transforms 8-bit unsigned integers using lookup table: dst(i)=lut(src(i)).
      /// Destination GpuMat will have the depth type as lut and the same channels number as source.
      /// Supports CV_8UC1, CV_8UC3 types.
      /// </summary>
      /// <param name="src">The source GpuMat</param>
      /// <param name="lut">Pointer to a CvArr (e.g. Emgu.CV.Matrix).</param>
      /// <param name="dst">The destination GpuMat</param>
      /// <param name="stream">Use a Stream to call the function asynchronously (non-blocking) or IntPtr.Zero to call the function synchronously (blocking).</param>
      [DllImport(CvInvoke.EXTERN_GPU_LIBRARY, CallingConvention = CvInvoke.CvCallingConvention, EntryPoint = "gpuMatLUT")]
      public static extern void LUT(IntPtr src, IntPtr lut, IntPtr dst, IntPtr stream);
   }
}
