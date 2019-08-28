using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace p_hello_xamarin.Droid
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr p_hdl_, JniHandleOwnership p_trs_) : base(p_hdl_, p_trs_) { }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity p_act_, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = p_act_;
        }

        public void OnActivityResumed(Activity p_act_)
        {
            CrossCurrentActivity.Current.Activity = p_act_;
        }

        public void OnActivityStarted(Activity p_act_)
        {
            CrossCurrentActivity.Current.Activity = p_act_;
        }

        public void OnActivityDestroyed(Activity p_act_) { }

        public void OnActivityPaused(Activity p_act_) { }

        public void OnActivitySaveInstanceState(Activity p_act_, Bundle p_bnd_) { }

        public void OnActivityStopped(Activity p_act_) { }
    }
}