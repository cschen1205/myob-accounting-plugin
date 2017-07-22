using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Presenters
{
    using DacII.WinForms;

    using Accounting.Bll;
    using Accounting.Bll.Jobs;

    using DacII.WinForms.Jobs;
    public class JobPresenter : ModulePresenter
    {
        public JobPresenter(ApplicationPresenter ap, FrmDac shell)
            : base(ap, shell)
        {
            
        }

        private DacII.WinForms.Jobs.FrmJobsList mFrmJobs = null;
        public void ShowJobs(BOListJob model)
        {
            if (IsInvalid(mFrmJobs))
            {
                mFrmJobs = new DacII.WinForms.Jobs.FrmJobsList(mApplicationController, model);
            }
            SetCurrentForm(mFrmJobs);
        }

        private FrmJob mFrmJob = null;
        public void ShowJob(BOJob model)
        {
            if (IsInvalid(mFrmJob))
            {
                mFrmJob = new FrmJob(mApplicationController, model);
            }
            else
            {
                mFrmJob.Model = model;
                mFrmJob.UpdateView();
            }
            SetCurrentForm(mFrmJob);
        }

        private DacII.WinForms.Analysis.FrmJobs mFrmJobsAnalysis = null;
        public void ShowJobsAnalysis(Accounting.Bll.Analysis.BOJobs model)
        {
            if (IsInvalid(mFrmJobsAnalysis))
            {
                mFrmJobsAnalysis = new DacII.WinForms.Analysis.FrmJobs(mApplicationController, model);
            }
            SetCurrentForm(mFrmJobsAnalysis);
        }
    }
}
