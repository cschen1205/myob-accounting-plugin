using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Misc
{
    public abstract class BASInformationManager : EntityManager<BASInformation>
    {
        public BASInformationManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override BASInformation _CreateDbEntity()
        {
            return new BASInformation(true, this);
        }
        protected override BASInformation _CreateEntity()
        {
            return new BASInformation(false, this);
        }
        #endregion

        protected override void LoadFromReader(BASInformation _obj, DbDataReader reader)
        {
            _obj.BASInformationID = GetInt32(reader, "BASInformationID");
            _obj.CalculationMethodID = GetString(reader, "CalculationMethodID");
            _obj.ClaimFuelTaxCredits = GetString(reader, "ClaimFuelTaxCredits");
            _obj.FBTInstalmentAmount = GetInt32(reader, "FBTInstalmentAmount");
            _obj.GSTBasisID = GetString(reader, "GSTBasisID");
            _obj.GSTFreePurchases = GetDouble(reader, "GSTFreePurchases");
            _obj.GSTFreeSales = GetDouble(reader, "GSTFreeSales");
            _obj.GSTFrequencyID = GetString(reader, "GSTFrequencyID");
            _obj.GSTInstalmentAmount = GetInt32(reader, "GSTInstalmentAmount");
            _obj.GSTOption = GetString(reader, "GSTOption");
            _obj.HaveFBTObligations = GetString(reader, "HaveFBTObligations");
            _obj.Include13Period = GetString(reader, "Include13Period");
            _obj.InstalmentBasisID = GetString(reader, "InstalmentBasisID");
            _obj.InstalmentFrequencyID = GetString(reader, "InstalmentFrequencyID");
            _obj.InstalmentOption = GetString(reader, "InstalmentOption");
            _obj.PAYGInstalmentAmount = GetInt32(reader, "PAYGInstalmentAmount");
            _obj.PAYGInstalmentRate = GetDouble(reader, "PAYGInstalmentRate");
            _obj.UseSimplifiedAccounting = GetString(reader, "UseSimplifiedAccounting");
            _obj.WithholdingFrequencyID = GetString(reader, "WithholdingFrequencyID");
        }

        public override Dictionary<string, DbFieldEntry> GetFields(BASInformation _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["BASInformationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.BASInformationID); //GetInt32(reader, "BASInformationID");
            fields["CalculationMethodID"] = DbMgr.CreateStringFieldEntry(_obj.CalculationMethodID); //GetString(reader, "CalculationMethodID");
            fields["ClaimFuelTaxCredits"] = DbMgr.CreateStringFieldEntry(_obj.ClaimFuelTaxCredits); //GetString(reader, "ClaimFuelTaxCredits");
            fields["FBTInstalmentAmount"] = DbMgr.CreateIntFieldEntry(_obj.FBTInstalmentAmount); //GetInt32(reader, "FBTInstalmentAmount");
            fields["GSTBasisID"] = DbMgr.CreateStringFieldEntry(_obj.GSTBasisID); //GetString(reader, "GSTBasisID");
            fields["GSTFreePurchases"] = DbMgr.CreateDoubleFieldEntry(_obj.GSTFreePurchases); //GetDouble(reader, "GSTFreePurchases");
            fields["GSTFreeSales"] = DbMgr.CreateDoubleFieldEntry(_obj.GSTFreeSales); //GetDouble(reader, "GSTFreeSales");
            fields["GSTFrequencyID"] = DbMgr.CreateStringFieldEntry(_obj.GSTFrequencyID); //GetString(reader, "GSTFrequencyID");
            fields["GSTInstalmentAmount"] = DbMgr.CreateIntFieldEntry(_obj.GSTInstalmentAmount); //GetInt32(reader, "GSTInstalmentAmount");
            fields["GSTOption"] = DbMgr.CreateStringFieldEntry(_obj.GSTOption); //GetString(reader, "GSTOption");
            fields["HaveFBTObligations"] = DbMgr.CreateStringFieldEntry(_obj.HaveFBTObligations); //GetString(reader, "HaveFBTObligations");
            fields["Include13Period"] = DbMgr.CreateStringFieldEntry(_obj.Include13Period); //GetString(reader, "Include13Period");
            fields["InstalmentBasisID"] = DbMgr.CreateStringFieldEntry(_obj.InstalmentBasisID); //GetString(reader, "InstalmentBasisID");
            fields["InstalmentFrequencyID"] = DbMgr.CreateStringFieldEntry(_obj.InstalmentFrequencyID); //GetString(reader, "InstalmentFrequencyID");
            fields["InstalmentOption"] = DbMgr.CreateStringFieldEntry(_obj.InstalmentOption); //GetString(reader, "InstalmentOption");
            fields["PAYGInstalmentAmount"] = DbMgr.CreateIntFieldEntry(_obj.PAYGInstalmentAmount); //GetInt32(reader, "PAYGInstalmentAmount");
            fields["PAYGInstalmentRate"] = DbMgr.CreateDoubleFieldEntry(_obj.PAYGInstalmentRate); //GetDouble(reader, "PAYGInstalmentRate");
            fields["UseSimplifiedAccounting"] = DbMgr.CreateStringFieldEntry(_obj.UseSimplifiedAccounting); //GetString(reader, "UseSimplifiedAccounting");
            fields["WithholdingFrequencyID"] = DbMgr.CreateStringFieldEntry(_obj.WithholdingFrequencyID); //GetString(reader, "WithholdingFrequencyID");

            return fields;
        }

        protected override object GetDbProperty(BASInformation _obj, string property_name)
        {
            if (property_name.Equals("GSTFrequency"))
            {
                return RepositoryMgr.FrequencyMgr.FindById(_obj.GSTFrequencyID);
            }
            else if (property_name.Equals("GSTBasis"))
            {
                return RepositoryMgr.AccountingBasisMgr.FindById(_obj.GSTBasisID);
            }
            else if (property_name.Equals("CalculationMethod"))
            {
                return RepositoryMgr.CalculationMethodMgr.FindById(_obj.CalculationMethodID);
            }
            else if (property_name.Equals("InstalmentFrequency"))
            {
                return RepositoryMgr.FrequencyMgr.FindById(_obj.InstalmentFrequencyID);
            }
            else if (property_name.Equals("InstalmentBasis"))
            {
                return RepositoryMgr.AccountingBasisMgr.FindById(_obj.InstalmentBasisID);
            }
            else if (property_name.Equals("WithholdingFrequency"))
            {
                return RepositoryMgr.FrequencyMgr.FindById(_obj.WithholdingFrequencyID);
            }

            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            return clause.SelectAll().From("BASInformation");
        }

        private DbSelectStatement GetQuery_SelectByBASInformationID(int BASInformationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("BASInformation")
                .Criteria
                    .IsEqual("BASInformation", "BASInformationID", BASInformationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByBASInformationID(int BASInformationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("BASInformation")
                .Criteria
                    .IsEqual("BASInformation", "BASInformationID", BASInformationID);

            return clause;
        }

        public bool Exists(int? BASInformationID)
        {
            if (BASInformationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByBASInformationID(BASInformationID.Value)) != 0;
        }

        public override bool Exists(BASInformation _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.BASInformationID);
        }

        protected override BASInformation _FindByIntId(int? BASInformationID)
        {
            if (BASInformationID == null) return null;
            BASInformation _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByBASInformationID(BASInformationID.Value));
            DbDataReader _reader = _cmd.ExecuteReader();

            if (_reader.Read())
            {
                _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
            }

            _reader.Close();
            _cmd.Dispose();

            return _obj;
        }

        protected override IList<BASInformation>_FindAllCollection()
        {
            List<BASInformation> _grp = new List<BASInformation>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                BASInformation _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }
    }
}
