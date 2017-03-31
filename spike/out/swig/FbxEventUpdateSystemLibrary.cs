//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.11
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace FbxSdk {

public class FbxEventUpdateSystemLibrary : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FbxEventUpdateSystemLibrary(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxEventUpdateSystemLibrary obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FbxEventUpdateSystemLibrary() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          examplePINVOKE.delete_FbxEventUpdateSystemLibrary(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public virtual string GetEventName() {
    string ret = examplePINVOKE.FbxEventUpdateSystemLibrary_GetEventName(swigCPtr);
    return ret;
  }

  public FbxEventUpdateSystemLibrary(FbxLibrary pLibrary) : this(examplePINVOKE.new_FbxEventUpdateSystemLibrary(FbxLibrary.getCPtr(pLibrary)), true) {
  }

  public FbxLibrary GetLibrary() {
    global::System.IntPtr cPtr = examplePINVOKE.FbxEventUpdateSystemLibrary_GetLibrary(swigCPtr);
    FbxLibrary ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxLibrary(cPtr, false);
    return ret;
  }

}

}