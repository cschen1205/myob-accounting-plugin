using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace OAS.Database
{
    public class OASDB
    {
        DBManager mDBMgr;

        private OASJobInformation mJobInformation;
        private OASCardInformation mCardInformation;
        private OASCategoryInformation mCategoryInformation;
        private OASMiscellaneousInformation mMiscellaneousInformation;
        private OASJournalRecordsAndTransations mJournalRecordsAndTransations;

        public OASDB(DBManager mgr)
        {
            mDBMgr = mgr;
            mJobInformation = new OASJobInformation(mgr);
            mCategoryInformation = new OASCategoryInformation(mgr);
            mCardInformation = new OASCardInformation(mgr);
            mMiscellaneousInformation = new OASMiscellaneousInformation(mgr);
            mJournalRecordsAndTransations = new OASJournalRecordsAndTransations(mgr);
        }

        public void Setup()
        {
            mCardInformation.CreateDBs();
            mMiscellaneousInformation.CreateDBs();
            mCategoryInformation.CreateDBs();
            mJobInformation.CreateDBs();
            mJournalRecordsAndTransations.CreateDBs();
        }


        

        

        

        

        
    }
}
