/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.10
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class CEngineWrapper : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal CEngineWrapper(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(CEngineWrapper obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~CEngineWrapper() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          SwigEnginePINVOKE.delete_CEngineWrapper(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public CEngineWrapper() : this(SwigEnginePINVOKE.new_CEngineWrapper(), true) {
  }

  public CSoundWrapper PlayFile(string filePath) {
    IntPtr cPtr = SwigEnginePINVOKE.CEngineWrapper_PlayFile__SWIG_0(swigCPtr, filePath);
    CSoundWrapper ret = (cPtr == IntPtr.Zero) ? null : new CSoundWrapper(cPtr, false);
    return ret;
  }

  public CSoundWrapper PlayFile(string filePath, bool playLooped, bool startPaused) {
    IntPtr cPtr = SwigEnginePINVOKE.CEngineWrapper_PlayFile__SWIG_1(swigCPtr, filePath, playLooped, startPaused);
    CSoundWrapper ret = (cPtr == IntPtr.Zero) ? null : new CSoundWrapper(cPtr, false);
    return ret;
  }

  public CSourceWrapper LoadFile(string filePath) {
    IntPtr cPtr = SwigEnginePINVOKE.CEngineWrapper_LoadFile(swigCPtr, filePath);
    CSourceWrapper ret = (cPtr == IntPtr.Zero) ? null : new CSourceWrapper(cPtr, false);
    return ret;
  }

}
