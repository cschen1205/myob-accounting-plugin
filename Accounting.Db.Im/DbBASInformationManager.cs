using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using Accounting.Core;
using Accounting.Core.Misc;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Db.Im
{
    public class DbBASInformationManager : BASInformationManager
    {
        public DbBASInformationManager(DbManager mgr)
            : base(mgr)
        {
            
        }



        protected override void CreateTableCommands() //BASInformation()
        {
            Dictionary<string, DbManager.FIELDTYPE> fields = new Dictionary<string, DbManager.FIELDTYPE>();
            Dictionary<string, string> foreignKeys = new Dictionary<string, string>();

            fields["BASInformationID"] = DbManager.FIELDTYPE.INTEGER_INDEXED;
            fields["GSTFrequencyID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["GSTBasisID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["GSTOption"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["GSTInstalmentAmount"] = DbManager.FIELDTYPE.INTEGER;
            fields["CalculationMethodID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["ClaimFuelTaxCredits"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["UseSimplifiedAccounting"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["GSTFreeSales"] = DbManager.FIELDTYPE.DOUBLE;
            fields["GSTFreePurchases"] = DbManager.FIELDTYPE.DOUBLE;
            fields["InstalmentFrequencyID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InstalmentBasisID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["InstalmentOption"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["PAYGInstalmentAmount"] = DbManager.FIELDTYPE.INTEGER;
            fields["PAYGInstalmentRate"] = DbManager.FIELDTYPE.DOUBLE;
            fields["WithholdingFrequencyID"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["HaveFBTObligations"] = DbManager.FIELDTYPE.VARCHAR_1;
            fields["FBTInstalmentAmount"] = DbManager.FIELDTYPE.INTEGER;
            fields["Include13Period"] = DbManager.FIELDTYPE.VARCHAR_1;


            TableCommands["BASInformation"] = DbMgr.CreateTableCommand("BASInformation", fields, "BASInformationID", foreignKeys);
        }

        private DbInsertStatement GetQuery_InsertQuery(BASInformation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = GetFields(_obj);
            return DbMgr.CreateInsertClause("BASInformation", fields);
        }

        private DbUpdateStatement GetQuery_UpdateQuery(BASInformation _obj)
        {
            return DbMgr.CreateUpdateClause("BASInformation", GetFields(_obj), "BASInformationID", _obj.BASInformationID);
        }

        protected override OpResult _Store(BASInformation _obj)
        {
            if (_obj == null)
            {
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.ObjectIsNull, _obj, "BASInformation object cannot be created as it is null");
            }

            if (Exists(_obj))
            {
                ExecuteNonQuery(GetQuery_UpdateQuery(_obj));
                return OpResult.NotifyStoreAction(OpResult.ResultStatus.Updated, _obj);
            }

            ExecuteNonQuery(GetQuery_InsertQuery(_obj));
            if (_obj.BASInformationID == null)
            {
                _obj.BASInformationID = DbMgr.GetLastInsertID();
            }
            _obj.FromDb = true;
            return OpResult.NotifyStoreAction(OpResult.ResultStatus.Created, _obj);
        }
    }
}
