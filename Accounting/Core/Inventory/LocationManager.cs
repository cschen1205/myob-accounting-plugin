using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Accounting.Db;
using Accounting.Db.Elements;

namespace Accounting.Core.Inventory
{
    public abstract class LocationManager : EntityManager<Location>
    {
        public LocationManager(DbManager mgr)
            : base(mgr)
        {

        }

        #region +(Factory Methods)
        protected override Location _CreateDbEntity()
        {
            return new Location(true, this);
        }

        protected override Location _CreateEntity()
        {
            return new Location(false, this);
        }
        #endregion

        public override Dictionary<string, DbFieldEntry> GetFields(Location _obj)
        {
            Dictionary<string, DbFieldEntry> fields = new Dictionary<string, DbFieldEntry>();
            fields["LocationID"] = DbMgr.CreateAutoIntFieldEntry(_obj.LocationID);
            fields["IsInactive"] = DbMgr.CreateStringFieldEntry(_obj.IsInactive);
            fields["CanBeSold"] = DbMgr.CreateStringFieldEntry(_obj.CanBeSold);
            fields["LocationIdentification"] = DbMgr.CreateStringFieldEntry(_obj.LocationIdentification);
            fields["LocationName"] = DbMgr.CreateStringFieldEntry(_obj.LocationName);
            fields["Street"] = DbMgr.CreateStringFieldEntry(_obj.Street);
            fields["City"] = DbMgr.CreateStringFieldEntry(_obj.City);
            fields["State"] = DbMgr.CreateStringFieldEntry(_obj.State);
            fields["Postcode"] = DbMgr.CreateStringFieldEntry(_obj.Postcode);
            fields["Country"] = DbMgr.CreateStringFieldEntry(_obj.Country);
            fields["Contact"] = DbMgr.CreateStringFieldEntry(_obj.Contact);
            fields["ContactPhone"] = DbMgr.CreateStringFieldEntry(_obj.ContactPhone);
            fields["Notes"] = DbMgr.CreateStringFieldEntry(_obj.Notes);
            return fields;
        }

        private DbSelectStatement GetQuery_SelectAll()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Locations");

            return clause;
        }

        private DbSelectStatement GetQuery_SelectByLocationID(int LocationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectAll()
                .From("Locations")
                .Criteria
                    .IsEqual("Locations", "LocationID", LocationID);

            return clause;
        }

        private DbSelectStatement GetQuery_SelectCountByLocationID(int LocationID)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectCount()
                .From("Locations")
                .Criteria
                    .IsEqual("Locations", "LocationID", LocationID);

            return clause;
        }

        private bool Exists(int? LocationID)
        {
            if (LocationID == null) return false;
            return ExecuteScalarInt(GetQuery_SelectCountByLocationID(LocationID.Value)) != 0;
        }

        public override bool Exists(Location _obj)
        {
            return Exists(_obj.LocationID);
        }

        protected override void LoadFromReader(Location _obj, DbDataReader reader)
        {
            _obj.LocationID =GetInt32(reader, ("LocationID"));
            _obj.IsInactive =GetString(reader, ("IsInactive"));
            _obj.CanBeSold =GetString(reader, ("CanBeSold"));
            _obj.LocationIdentification =GetString(reader, ("LocationIdentification"));
            _obj.LocationName =GetString(reader, ("LocationName"));
            _obj.Street =GetString(reader, ("Street"));
            _obj.City =GetString(reader, ("City"));
            _obj.State =GetString(reader, ("State"));
            _obj.Postcode =GetString(reader, ("Postcode"));
            _obj.Country =GetString(reader, ("Country"));
            _obj.Contact =GetString(reader, ("Contact"));
            _obj.ContactPhone =GetString(reader, ("ContactPhone"));
            _obj.Notes =GetString(reader, ("Notes"));
        }

        public Location FindByLocationID(int? LocationID)
        {
            if (Exists(LocationID))
            {
                Location _obj = CreateDbEntity();
                LoadFromDb(_obj, GetQuery_SelectByLocationID(LocationID.Value));
                return _obj;
            }
            else
            {
                return null;
            }
        }

        protected override IList<Location>_FindAllCollection()
        {
            List<Location> _grp = new List<Location>();

            DbCommand _cmd = CreateDbCommand(GetQuery_SelectAll());
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                Location _obj = CreateDbEntity();
                LoadFromReader(_obj, _reader);
                _grp.Add(_obj);
            }
            _reader.Close();
            _cmd.Dispose();

            return _grp;
        }

        public virtual DataTable Table()
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("Locations", "LocationID", "ID")
                .SelectColumn("Locations", "LocationName", "Name")
                .SelectColumn("Locations", "IsInactive", "Inactive")
                .From("Locations");
            

            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Active");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["ID"] = GetInt32(_reader, "ID");
                row["Name"] = GetString(_reader, "Name");
                row["Active"] = (GetString(_reader, "Inactive") == "N");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }

        public virtual DataTable Table(DbCriteria criteria)
        {
            DbSelectStatement clause = DbMgr.CreateSelectClause();
            clause
                .SelectColumn("Locations", "LocationID", "ID")
                .SelectColumn("Locations", "LocationName", "Name")
                .SelectColumn("Locations", "IsInactive", "Inactive")
                .From("Locations")
                .Criteria.And(criteria);
            

            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Active");

            DbCommand _cmd = CreateDbCommand(clause);
            DbDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                DataRow row = table.NewRow();
                row["ID"] = GetInt32(_reader, "ID");
                row["Name"] = GetString(_reader, "Name");
                row["Active"] = (GetString(_reader, "Inactive") == "N");
                table.Rows.Add(row);
            }
            _reader.Close();
            _cmd.Dispose();

            return table;
        }
    }
}
