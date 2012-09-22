namespace Projekt_BD.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Domain;
    using Projekt_BD.View;

    public class EditRoomController : ControllerBase
    {
        #region Field

        private static readonly string IdColumnName = "Id";

        private static readonly string NameColumnName = "Name";

        private static readonly string IsAddedColumnName = "IsAdded";

        #endregion

        #region Constructors

        public EditRoomController()
        {
            base.Form = new EditRoomForm();

            this.SetupEvents();
        }

        #endregion

        #region Properties

        public new EditRoomForm Form
        {
            get
            {
                return base.Form as EditRoomForm;
            }
        }

        #endregion

        #region Methods

        private void SetupEvents()
        {
            this.Form.Load += this.Form_Load;
            this.Form.OkButton.Click += this.OkButton_Click;
            this.Form.CancelButton.Click += this.CancelButton_Click;
        }

        private void SetColumnNamesAndVisibility()
        {
            this.Form.FeaturesDataGridView.Columns[IdColumnName].Visible = false;
            this.Form.FeaturesDataGridView.Columns[NameColumnName].HeaderText = "Nazwa";
            this.Form.FeaturesDataGridView.Columns[IsAddedColumnName].HeaderText = string.Empty;
        }

        private void AddFeaturesToRoom(Room room)
        {
            foreach (DataGridViewRow row in this.Form.FeaturesDataGridView.Rows)
            {
                var cell = row.Cells[IsAddedColumnName] as DataGridViewCheckBoxCell;
                var featureId = (int)row.Cells[IdColumnName].Value;
                Feature feature = DataAccess.Instance.Features.Single(f => f.Id == featureId);

                if (Convert.ToBoolean(cell.Value) == true)
                {
                    room.Features.Add(feature);
                }
                else
                {
                    room.Features.Remove(feature);
                }
            }
        }

        #endregion

        #region Event Methods

        private void Form_Load(object sender, EventArgs e)
        {
            var availableTypes = DataAccess.Instance.RoomTypes.GetAll().ToDictionary(availableType => availableType.Id, availableType => availableType.Name);
            this.Form.TypeComboBox.DataSource = new BindingSource(availableTypes, null);
            this.Form.TypeComboBox.DisplayMember = "Value";
            this.Form.TypeComboBox.ValueMember = "Key";
            if (this.IsEditForm)
            {
                var room = DataAccess.Instance.Rooms.Single(r => r.Number == this.ItemToEditID);
                this.Form.NumberTextBox.Text = room.Number.ToString();
                this.Form.FloorTextBox.Text = room.Floor.ToString();
                this.Form.TypeComboBox.Text = availableTypes.Where(x => x.Key == room.TypeId).Select(x => x.Value).FirstOrDefault();
                this.Form.CapacityTextBox.Text = room.Capacity.ToString();

                var notAddedFeatures = (from feature in DataAccess.Instance.Features.GetAll().ToList()
                                        select feature).Except(from feature2 in room.Features select feature2);

                var featureList = (from f in room.Features.ToList()
                                   select new { f.Id, f.Name, added = true })
                                   .Union(from f2 in notAddedFeatures
                                          select new { f2.Id, f2.Name, added = false }).ToList();

                this.Form.FeaturesDataGridView.DataSource = (from feature in featureList select new { feature.Id, feature.Name }).ToList();
                this.Form.FeaturesDataGridView.Columns.Add(new DataGridViewCheckBoxColumn() { Name = IsAddedColumnName });

                int lastColumnIndex = this.Form.FeaturesDataGridView.Columns.Count - 1;

                foreach (var feature in featureList)
                {
                    if (feature.added)
                    {
                        this.Form.FeaturesDataGridView.Rows[featureList.IndexOf(feature)].Cells[lastColumnIndex].Value = true;
                    }
                }

                this.Form.Text = "Edycja pokoju";
            }
            else
            {
                var featureList = (from feature in DataAccess.Instance.Features.GetAll()
                                   select new { feature.Id, feature.Name }).ToList();

                this.Form.FeaturesDataGridView.DataSource = featureList;
                this.Form.FeaturesDataGridView.Columns.Add(new DataGridViewCheckBoxColumn() { Name = IsAddedColumnName });
                
                this.Form.Text = "Nowy pokój";
            }

            this.SetColumnNamesAndVisibility();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            int roomNumber = 0;
            int roomFloor = 0;
            int roomCapacity = 0;
            int roomType = 0;

            int.TryParse(this.Form.NumberTextBox.Text, out roomNumber);
            int.TryParse(this.Form.FloorTextBox.Text, out roomFloor);
            int.TryParse(this.Form.CapacityTextBox.Text, out roomCapacity);
            int.TryParse(this.Form.TypeComboBox.SelectedValue.ToString(), out roomType);

            if (roomNumber <= 0 || roomFloor < 0 || roomCapacity <= 0 || roomType <= 0)
            {
                MessageBox.Show(
                    "Podane wartości nie są prawidłowe lub pozostawiono niewypełnione pola.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            if (this.IsEditForm)
            {
                var room = DataAccess.Instance.Rooms.Single(r => r.Number == this.ItemToEditID);
                room.Number = roomNumber;
                room.Capacity = roomCapacity;
                room.Floor = roomFloor;
                room.TypeId = roomType;

                this.AddFeaturesToRoom(room);
            }
            else
            {
                var room = new Room
                {
                    Number = roomNumber,
                    Capacity = roomCapacity,
                    Floor = roomFloor,
                    TypeId = roomType
                };

                DataAccess.Instance.Rooms.Add(room);
                this.AddFeaturesToRoom(room);
            }

            DataAccess.Instance.UnitOfWork.Commit();

            this.Form.Dispose();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Form.Dispose();
        }

        #endregion
    }
}
