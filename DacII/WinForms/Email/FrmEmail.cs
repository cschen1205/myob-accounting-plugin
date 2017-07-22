using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SwissArmyKnife.Emails;
using Accounting.Bll;
using Accounting.Bll.Util;
using Accounting.Core.Cards;

namespace DacII.WinForms.Email
{
    using DacII.Presenters;

    public partial class FrmEmail : BaseView
    {
        BOEmail mCardModel;
        public FrmEmail(ApplicationPresenter ap, BOEmail cards)
            : base(ap)
        {
            InitializeComponent();
            mCardModel = cards;

            Subject = cards.Subject;
            Message = cards.Body;
            foreach (string attachment in cards.Attachments)
            {
                this.Attachments.Add(attachment);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            GoBack();
        }

        public string Subject
        {
            set { txtSubject.Text = value; }
            get { return txtSubject.Text; }
        }

        public string Message
        {
            set { txtMessage.Text = value; }
            get { return txtMessage.Text; }
        }

        private List<string> mAttachments=new List<string>();
        public List<string> Attachments
        {
            get { return mAttachments; }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string to = txtEmail.Text;
            string subject = txtSubject.Text;
            string body = txtMessage.Text;

            MAPI mapi = new MAPI();

            foreach(string filename in mAttachments)
            {
                mapi.AddAttachment(filename);
            }
            
            mapi.AddRecipientTo(to);

            string error;
            mapi.SendMailPopup(subject, body, out error);
            if(!error.Equals(""))
            {
                MessageBox.Show(error);
                DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void FrmEmail_Load(object sender, EventArgs e)
        {
            cboName.DataSource = mCardModel.AllCards;
            if(cboName.Items.Count > 0)
            {
                cboName.SelectedIndex=0;
            }
            Card _card=(Card)cboName.SelectedItem;
            txtEmail.Text = _card.Address1.Email;

            cboEmail.Items.Add("Email 1");
            cboEmail.Items.Add("Email 2");
            cboEmail.Items.Add("Email 3");
            cboEmail.Items.Add("Email 4");
            cboEmail.Items.Add("Email 5");

            cboEmail.SelectedIndex = 0;

            cboName.SelectedValueChanged += new EventHandler(cboName_SelectedValueChanged);
            cboEmail.SelectedValueChanged += new EventHandler(cboEmail_SelectedValueChanged);
        }

        void cboEmail_SelectedValueChanged(object sender, EventArgs e)
        {
            Card _card = (Card)cboName.SelectedItem;
            if (cboEmail.Text.Equals("Email 1"))
            {
                txtEmail.Text = _card.Address1.Email;
            }
            else if (cboEmail.Text.Equals("Email 2"))
            {
                txtEmail.Text = _card.Address2.Email;
            }
            else if (cboEmail.Text.Equals("Email 3"))
            {
                txtEmail.Text = _card.Address3.Email;
            }
            else if (cboEmail.Text.Equals("Email 4"))
            {
                txtEmail.Text = _card.Address4.Email;
            }
            else if (cboEmail.Text.Equals("Email 5"))
            {
                txtEmail.Text = _card.Address5.Email;
            }
        }

        void cboName_SelectedValueChanged(object sender, EventArgs e)
        {
            Card _card = (Card)cboName.SelectedItem;
            txtEmail.Text = _card.Address1.Email;
            cboEmail.SelectedIndex = 0;
        }
    }
}
