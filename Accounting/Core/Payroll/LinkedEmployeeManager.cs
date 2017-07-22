using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Payroll
{
    public abstract class LinkedEmployeeManager : EntityManager<LinkedEmployee>
    {
        public LinkedEmployeeManager(DbManager mgr)
            : base(mgr)
        {
        }

        #region +(Factory Methods)
        protected override LinkedEmployee _CreateDbEntity()
        {
            return new LinkedEmployee(true, this);
        }
        protected override LinkedEmployee _CreateEntity()
        {
            return new LinkedEmployee(false, this);
        }
        #endregion

        protected override void LoadFromReader(LinkedEmployee _obj, DbDataReader reader)
        {

            _obj.LinkedEmployeeID = GetInt32(reader, "LinkedEmployeeID");
            _obj.CategoryID = GetInt32(reader, "CategoryID");
            _obj.CategoryTypeID = GetString(reader, "CategoryTypeID");
            _obj.CardRecordID = GetInt32(reader, "CardRecordID");
           
        }

        public override Dictionary<string, DbFieldEntry> GetFields(LinkedEmployee _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();

            fields["LinkedEmployeeID"] = DbMgr.CreateAutoIntFieldEntry(_obj.LinkedEmployeeID); //GetInt32(reader, "LinkedEmployeeID");
            fields["CategoryID"] = DbMgr.CreateIntFieldEntry(_obj.CategoryID); //GetInt32(reader, "CategoryID");
            fields["CategoryTypeID"] = DbMgr.CreateStringFieldEntry(_obj.CategoryTypeID); //GetString(reader, "CategoryTypeID");
            fields["CardRecordID"] = DbMgr.CreateIntFieldEntry(_obj.CardRecordID); //GetInt32(reader, "CardRecordID");
           

            return fields;
        }

        protected override object GetDbProperty(LinkedEmployee _obj, string property_name)
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

            clause.SelectAll().From("LinkedEmployees");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByLinkedEmployeeID(int LinkedEmployeeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectAll()
                .From("LinkedEmployees")
                .Criteria
                    .IsEqual("LinkedEmployees", "LinkedEmployeeID", LinkedEmployeeID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByLinkedEmployeeID(int LinkedEmployeeID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();

            clause
                .SelectCount()
                .From("LinkedEmployees")
                .Criteria
                    .IsEqual("LinkedEmployees", "LinkedEmployeeID", LinkedEmployeeID);

            return clause;
        }

        public bool Exists(int? LinkedEmployeeID)
        {
            if (LinkedEmployeeID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByLinkedEmployeeID(LinkedEmployeeID.Value)) != 0;
        }

        public override bool Exists(LinkedEmployee _obj)
        {
            if (_obj == null) return false;
            return Exists(_obj.LinkedEmployeeID);
        }

        protected override LinkedEmployee _FindByIntId(int? LinkedEmployeeID)
        {
            if (LinkedEmployeeID == null) return null;
            LinkedEmployee _obj = null;

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectByLinkedEmployeeID(LinkedEmployeeID.Value));
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

        protected override IList<LinkedEmployee>_FindAllCollection()
        {
            List<LinkedEmployee> _grp = new List<LinkedEmployee>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                LinkedEmployee _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }

            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }


    }
}
