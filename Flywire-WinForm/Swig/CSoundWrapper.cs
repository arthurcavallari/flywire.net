/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.10
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class CSoundWrapper : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal CSoundWrapper(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(CSoundWrapper obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~CSoundWrapper() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SwigEnginePINVOKE.delete_CSoundWrapper(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public CSoundWrapper(SWIGTYPE_p_ISound sound) : this(SwigEnginePINVOKE.new_CSoundWrapper(SWIGTYPE_p_ISound.getCPtr(sound)), true) {
  }

  public void Stop() {
    SwigEnginePINVOKE.CSoundWrapper_Stop(swigCPtr);
  }

  public uint getPlayPosition() {
    uint ret = SwigEnginePINVOKE.CSoundWrapper_getPlayPosition(swigCPtr);
    return ret;
  }

  public uint getPlayLength() {
    uint ret = SwigEnginePINVOKE.CSoundWrapper_getPlayLength(swigCPtr);
    return ret;
  }

}