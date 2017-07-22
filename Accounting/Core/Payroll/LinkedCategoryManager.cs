using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Payroll
{
    public abstract class LinkedCategoryManager : EntityManager<LinkedCategory>
    {
        public LinkedCategoryManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override LinkedCategory _CreateDbEntity()
        {
            return new LinkedCategory(true, this);
        }
        protected override LinkedCategory _CreateEntity()
        {
            return new LinkedCategory(false, this);
        }
        #endregion

        protected override void LoadFromReader(LinkedCategory _obj, DbDataReader reader)
        {

            _obj.LinkedCategoryID = GetInt32(reader, "LinkedCategoryID");
            _obj.CategoryID = GetInt32(reader, "CategoryID");
            _obj.CategoryTypeID = GetString(reader, "CategoryTypeID");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
           
        }

        public override Dictionary<string, DbFieldEntry> GetFields(LinkedCategory _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["LinkedCategoryID"] = DbMgr.CreateAutoIntFieldEntry(_obj.LinkedCategoryID); //GetInt32(reader, "LinkedCategoryID");
            fields["CategoryID"] = DbMgr.CreateIntFieldEntry(_obj.CategoryID); //GetInt32(reader, "CategoryID");
            fields["CategoryTypeID"] = DbMgr.CreateStringFieldEntry(_obj.CategoryTypeID); //GetString(reader, "CategoryTypeID");
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "CardRecordID");
           

            return fields;
        }

        protected override object GetDbProperty(LinkedCategory _obj, string property_name)
        {
            if (property_name.Equals("Card"))
            {
                return RepositoryMgr.CardMgr.FindByCardId(_obj.CardRecordID, true);
            }
            else if (property_name.Equals("CategoryType"))
            {
                return RepositoryMgr.CategoryTypeMgr.FindById(_obj.CategoryTypeID);
            }
 
            return null;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause.SelectAll().From("LinkedCategories");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByLinkedCategoryID(int LinkedCategoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("LinkedCategories")
                .Criteria
                    .IsEqual("LinkedCategories", "LinkedCategoryID", LinkedCategoryID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByLinkedCategoryID(int LinkedCategoryID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("LinkedCategories")
                .Criteria
                    .IsEqual("LinkedCategories", "LinkedCategoryID", LinkedCategoryID);

            return clause;
        }

        public bool Exists(int? LinkedCategoryID)
        {
            if (LinkedCategoryID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByLinkedCategoryID(LinkedCategoryID.Value)) != 0;
        }

        public override bool Exists(LinkedCategory _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.LinkedCategoryID);
        }

        protected override LinkedCategory _FindByIntId(int? LinkedCategoryID)
        {
            if (LinkedCategoryID == null) return null;
            LinkedCategory _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByLinkedCategoryID(LinkedCategoryID.Value));
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

        protected override IList<LinkedCategory>_FindAllCollection()
        {
            List<LinkedCategory> _grp = new List<LinkedCategory>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                LinkedCategory _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
