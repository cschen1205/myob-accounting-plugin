using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Definitions
{
    public abstract class PriceLevelManager : EntityManager<PriceLevel>
    {
        public PriceLevelManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region PriceLevel factory methods
        protected override PriceLevel _CreateDbEntity()
        {
            return new PriceLevel(true, this);
        }

        protected override PriceLevel _CreateEntity()
        {
            return new PriceLevel(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(PriceLevel _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["PriceLevelID"] = DbMgr.CreatePrimaryKeyStringFieldEntry(_obj.PriceLevelID);
            fields["Description"] = DbMgr.CreateStringFieldEntry(_obj.Description);
            fields["ImportPriceLevel"] = DbMgr.CreateStringFieldEntry(_obj.ImportPriceLevel);
            fields["ImportSalesTaxCalcMethod"] = DbMgr.CreateStringFieldEntry(_obj.ImportSalesTaxCalcMethod);


            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PriceLevels");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByPriceLevelID(string PriceLevelID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("PriceLevels")
                .Criteria
                    .IsEqual("PriceLevels", "PriceLevelID", PriceLevelID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByPriceLevelID(string PriceLevelID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("PriceLevels")
                .Criteria
                    .IsEqual("PriceLevels", "PriceLevelID", PriceLevelID);

            return clause;
        }

        private bool Exists(string PriceLevelID)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByPriceLevelID(PriceLevelID)) != 0;
        }

        public override bool Exists(PriceLevel _obj)
        {
            return ExecuteScalarInt(GetQuery_SelectCountByPriceLevelID(_obj.PriceLevelID)) != 0;
        }

        protected override void LoadFromReader(PriceLevel _obj, DbDataReader _reader)
        {
            _obj.PriceLevelID =GetString(_reader, ("PriceLevelID"));
            _obj.Description =GetString(_reader, ("Description"));
            _obj.ImportSalesTaxCalcMethod =GetString(_reader, ("ImportSalesTaxCalcMethod"));
            _obj.ImportPriceLevel =GetString(_reader, ("ImportPriceLevel"));
        }

        protected override PriceLevel _FindByTextId(string PriceLevelID)
        {
            if (Exists(PriceLevelID))
            {
                PriceLevel _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByPriceLevelID(PriceLevelID));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<PriceLevel>_FindAllCollection()
        {
            List<PriceLevel> objs = new List<PriceLevel>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                PriceLevel _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);

                objs.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return objs;
        }
    }
}
