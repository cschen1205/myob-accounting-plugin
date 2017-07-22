
namespace DacII.WinForms.Help
{
    using DacII.Presenters;
    using Accounting.Bll;

    public partial class FrmUserGuide : BaseView
    {
        public FrmUserGuide(ApplicationPresenter ap)
            : base(ap)
        {
            InitializeComponent();

            BindViews();
            RegisterEventHandlers();
        }

        protected override void LoadView()
        {
            Accountant acc = mApplicationController.mAccountant;
            wb.Navigate(acc.GetFullPath("UserGuide\\index.htm"));
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            GoBack();
        }
    }
}
