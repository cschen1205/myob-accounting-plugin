using System;
using System.Windows.Forms;

namespace DacII.WinForms.Jobs
{
    using DacII.Presenters;
    using DacII.ViewModels;
    using Accounting.Bll.Jobs;

    public partial class FrmJob : BaseView
    {
        private BOJob mModel;
        private BOViewModel mViewModel;

        protected override void BindViews()
        {
            cboCustomer.DataSource = mApplicationController.FindAllCustomers();
            cboParentJob.DataSource = mApplicationController.FindAllJobs();

            mViewModel.BindView(BOJob.JOB_NUMBER, lblJobNumber, txtJobNumber);
            mViewModel.BindView(BOJob.JOB_NAME, lblName, txtName);
            mViewModel.BindView(BOJob.MANAGER, lblManager, txtManager);
            mViewModel.BindView(BOJob.PERCENT_COMPLETED, lblPercentCompleted, txtPercentCompleted);
            mViewModel.BindView(BOJob.JOB_DESCRIPTION, lblJobDescription, txtJobDescription);
            mViewModel.BindView(BOJob.CONTACT_NAME, lblContactPerson, txtContactPerson);
            mViewModel.BindView(BOJob.IS_ACTIVE, chkActive);
            mViewModel.BindView(BOJob.IS_TRACKING_REIMBURSEABLE, chkIsTrackingReimburseable);
            mViewModel.BindView(BOJob.IS_HEADER, chkIsHeader);
            mViewModel.BindView(BOJob.CUSTOMER, lblCustomer, cboCustomer);
            mViewModel.BindView(BOJob.PARENT_JOB, lblParentJob, cboParentJob);
            mViewModel.BindView(BOJob.START_DATE, lblStartDate, dtpStartDate);
            mViewModel.BindView(BOJob.FINISH_DATE, lblFinishDate, dtpFinishDate);

            mViewModel.BindView(BOJob.PERSIST_OBJECT, btnRecord);
        }

        private void Record(object sender, EventArgs args)
        {
            if (mViewModel.ValidateModel())
            {
                string job_number = mModel.DataSource.JobNumber;
                if (job_number != txtJobNumber.Text)
                {
                    if (MessageBox.Show("You have modified the Job Number, this will create a number job with your entry, would you like proceed?", "Confirm Create New", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        DialogResult = DialogResult.None;
                    }
                    else
                    {
                        mModel.IsCreating = true;
                        mModel.Record();
                        MessageBox.Show("Job Record Created!");
                    }
                }
                else
                {
                    mModel.Record();
                    MessageBox.Show("Job Record Saved!");
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }

        }

        public FrmJob(ApplicationPresenter ap, BOJob model)
            : base(ap)
        {
            InitializeComponent();

            mModel = model;
            mViewModel = new BOViewModel(mModel);
            mViewModel.ErrorProvider = errorProvider;

            BindViews();
            RegisterEventHandlers();
        }

        public BOJob Model
        {
            set
            {
                mModel = value;
                mViewModel.Model = mModel;
            }
        }

        protected override void LoadView()
        {
            if (cboCustomer.Items.Count > 0) cboCustomer.SelectedIndex = 0;
            if (cboParentJob.Items.Count > 0) cboParentJob.SelectedIndex = 0;

            mViewModel.UpdateView();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
