using System.Threading.Tasks;
using MvvmCross.ViewModels;
using p_hello_xamarin.Services;

namespace p_hello_xamarin.ViewModels
{
    public class _c_mainview : MvxViewModel
    {
        private readonly _i_helloserv s_srv_;

        public double s_sub_
        {
            get { return s_sub_; }
            set
            {
                s_sub_ = value;
                RaisePropertyChanged(() => s_sub_);
                v_recalcuate_();
            }
        }

        public double s_tip_
        {
            get { return s_tip_; }
            set
            {
                s_tip_ = value;
                RaisePropertyChanged(() => s_tip_);
            }
        }

        public int s_gen_
        {
            get { return s_gen_; }
            set
            {
                s_gen_ = value;
                RaisePropertyChanged(() => s_gen_);

                v_recalcuate_();
            }
        }

        public _c_mainview(_i_helloserv p_srv_)
        {
            s_srv_ = p_srv_;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            s_sub_ = 100;
            s_gen_ = 10;
            v_recalcuate_();
        }

        private void v_recalcuate_()
        {
            s_tip_ = s_srv_.f_tip_(s_sub_, s_gen_);
        }
    }
}