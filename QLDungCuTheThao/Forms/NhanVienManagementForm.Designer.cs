namespace QLDungCuTheThao.Forms
{
    partial class NhanVienManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhanVienManagementForm));
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReload1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateEnd_TopNVBanNhieuHang = new System.Windows.Forms.DateTimePicker();
            this.dateStart_TopNVBanNhieuHang = new System.Windows.Forms.DateTimePicker();
            this.cbbBranch_1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbBranch_2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReload2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateEnd_TopNVKoBanDuoc = new System.Windows.Forms.DateTimePicker();
            this.dateStart_TopNVKoBanDuoc = new System.Windows.Forms.DateTimePicker();
            this.dgvTopNVBanDuocNhieuHang = new System.Windows.Forms.DataGridView();
            this.dgv_DSNVKoBanDuocHang = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopNVBanDuocNhieuHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSNVKoBanDuocHang)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Tomato;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(1370, 0);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(41, 31);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 12;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Tomato;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(1407, 0);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(42, 31);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExit.TabIndex = 11;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font(".Helvetica NeueUI", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(743, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 33);
            this.label1.TabIndex = 38;
            this.label1.Text = "Danh sách các NV không bán được hàng";
            // 
            // btnReload1
            // 
            this.btnReload1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReload1.FlatAppearance.BorderSize = 0;
            this.btnReload1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload1.Font = new System.Drawing.Font(".Helvetica NeueUI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReload1.ForeColor = System.Drawing.Color.White;
            this.btnReload1.Location = new System.Drawing.Point(412, 156);
            this.btnReload1.Name = "btnReload1";
            this.btnReload1.Size = new System.Drawing.Size(247, 36);
            this.btnReload1.TabIndex = 65;
            this.btnReload1.Text = "Tải lại";
            this.btnReload1.UseVisualStyleBackColor = false;
            this.btnReload1.Click += new System.EventHandler(this.btnReload1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font(".Helvetica NeueUI", 8.999999F);
            this.label2.Location = new System.Drawing.Point(47, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "Ngày kết thúc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font(".Helvetica NeueUI", 8.999999F);
            this.label6.Location = new System.Drawing.Point(47, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 63;
            this.label6.Text = "Ngày bắt đầu";
            // 
            // dateEnd_TopNVBanNhieuHang
            // 
            this.dateEnd_TopNVBanNhieuHang.Location = new System.Drawing.Point(152, 166);
            this.dateEnd_TopNVBanNhieuHang.Name = "dateEnd_TopNVBanNhieuHang";
            this.dateEnd_TopNVBanNhieuHang.Size = new System.Drawing.Size(221, 22);
            this.dateEnd_TopNVBanNhieuHang.TabIndex = 62;
            this.dateEnd_TopNVBanNhieuHang.ValueChanged += new System.EventHandler(this.dateEnd_TopNVBanNhieuHang_ValueChanged);
            // 
            // dateStart_TopNVBanNhieuHang
            // 
            this.dateStart_TopNVBanNhieuHang.Location = new System.Drawing.Point(152, 122);
            this.dateStart_TopNVBanNhieuHang.Name = "dateStart_TopNVBanNhieuHang";
            this.dateStart_TopNVBanNhieuHang.Size = new System.Drawing.Size(221, 22);
            this.dateStart_TopNVBanNhieuHang.TabIndex = 61;
            this.dateStart_TopNVBanNhieuHang.ValueChanged += new System.EventHandler(this.dateStart_TopNVBanNhieuHang_ValueChanged);
            // 
            // cbbBranch_1
            // 
            this.cbbBranch_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBranch_1.Font = new System.Drawing.Font(".Helvetica NeueUI", 7.8F);
            this.cbbBranch_1.FormattingEnabled = true;
            this.cbbBranch_1.Items.AddRange(new object[] {
            "Bùi Thị Xuân",
            "Hòa Bình"});
            this.cbbBranch_1.Location = new System.Drawing.Point(496, 122);
            this.cbbBranch_1.Name = "cbbBranch_1";
            this.cbbBranch_1.Size = new System.Drawing.Size(163, 23);
            this.cbbBranch_1.TabIndex = 67;
            this.cbbBranch_1.SelectionChangeCommitted += new System.EventHandler(this.cbbBranch_1_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font(".Helvetica NeueUI", 10.2F);
            this.label3.Location = new System.Drawing.Point(408, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 66;
            this.label3.Text = "Chi nhánh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font(".Helvetica NeueUI", 16.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(44, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(638, 33);
            this.label4.TabIndex = 68;
            this.label4.Text = "Danh sách các NV bán được nhiều hàng nhất";
            // 
            // cbbBranch_2
            // 
            this.cbbBranch_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBranch_2.Font = new System.Drawing.Font(".Helvetica NeueUI", 7.8F);
            this.cbbBranch_2.FormattingEnabled = true;
            this.cbbBranch_2.Items.AddRange(new object[] {
            "Bùi Thị Xuân",
            "Hòa Bình"});
            this.cbbBranch_2.Location = new System.Drawing.Point(1195, 119);
            this.cbbBranch_2.Name = "cbbBranch_2";
            this.cbbBranch_2.Size = new System.Drawing.Size(163, 23);
            this.cbbBranch_2.TabIndex = 75;
            this.cbbBranch_2.SelectionChangeCommitted += new System.EventHandler(this.cbbBranch_2_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font(".Helvetica NeueUI", 10.2F);
            this.label5.Location = new System.Drawing.Point(1107, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 74;
            this.label5.Text = "Chi nhánh";
            // 
            // btnReload2
            // 
            this.btnReload2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReload2.FlatAppearance.BorderSize = 0;
            this.btnReload2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload2.Font = new System.Drawing.Font(".Helvetica NeueUI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReload2.ForeColor = System.Drawing.Color.White;
            this.btnReload2.Location = new System.Drawing.Point(1111, 153);
            this.btnReload2.Name = "btnReload2";
            this.btnReload2.Size = new System.Drawing.Size(247, 36);
            this.btnReload2.TabIndex = 73;
            this.btnReload2.Text = "Tải lại";
            this.btnReload2.UseVisualStyleBackColor = false;
            this.btnReload2.Click += new System.EventHandler(this.btnReload2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font(".Helvetica NeueUI", 8.999999F);
            this.label7.Location = new System.Drawing.Point(746, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 72;
            this.label7.Text = "Ngày kết thúc";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font(".Helvetica NeueUI", 8.999999F);
            this.label8.Location = new System.Drawing.Point(746, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 17);
            this.label8.TabIndex = 71;
            this.label8.Text = "Ngày bắt đầu";
            // 
            // dateEnd_TopNVKoBanDuoc
            // 
            this.dateEnd_TopNVKoBanDuoc.Location = new System.Drawing.Point(851, 163);
            this.dateEnd_TopNVKoBanDuoc.Name = "dateEnd_TopNVKoBanDuoc";
            this.dateEnd_TopNVKoBanDuoc.Size = new System.Drawing.Size(221, 22);
            this.dateEnd_TopNVKoBanDuoc.TabIndex = 70;
            this.dateEnd_TopNVKoBanDuoc.ValueChanged += new System.EventHandler(this.dateEnd_TopNVKoBanDuoc_ValueChanged);
            // 
            // dateStart_TopNVKoBanDuoc
            // 
            this.dateStart_TopNVKoBanDuoc.Location = new System.Drawing.Point(851, 119);
            this.dateStart_TopNVKoBanDuoc.Name = "dateStart_TopNVKoBanDuoc";
            this.dateStart_TopNVKoBanDuoc.Size = new System.Drawing.Size(221, 22);
            this.dateStart_TopNVKoBanDuoc.TabIndex = 69;
            this.dateStart_TopNVKoBanDuoc.ValueChanged += new System.EventHandler(this.dateStart_TopNVKoBanDuoc_ValueChanged);
            // 
            // dgvTopNVBanDuocNhieuHang
            // 
            this.dgvTopNVBanDuocNhieuHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopNVBanDuocNhieuHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopNVBanDuocNhieuHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName2,
            this.Quantity2,
            this.Address2,
            this.PhoneNumber2,
            this.Position2,
            this.Salary2});
            this.dgvTopNVBanDuocNhieuHang.Location = new System.Drawing.Point(50, 198);
            this.dgvTopNVBanDuocNhieuHang.Name = "dgvTopNVBanDuocNhieuHang";
            this.dgvTopNVBanDuocNhieuHang.RowTemplate.Height = 24;
            this.dgvTopNVBanDuocNhieuHang.Size = new System.Drawing.Size(609, 600);
            this.dgvTopNVBanDuocNhieuHang.TabIndex = 76;
            // 
            // dgv_DSNVKoBanDuocHang
            // 
            this.dgv_DSNVKoBanDuocHang.BackgroundColor = System.Drawing.Color.White;
            this.dgv_DSNVKoBanDuocHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DSNVKoBanDuocHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FullName,
            this.DateOfBirth,
            this.Address,
            this.PhoneNumber,
            this.Position,
            this.Salary});
            this.dgv_DSNVKoBanDuocHang.Location = new System.Drawing.Point(749, 198);
            this.dgv_DSNVKoBanDuocHang.Name = "dgv_DSNVKoBanDuocHang";
            this.dgv_DSNVKoBanDuocHang.RowTemplate.Height = 24;
            this.dgv_DSNVKoBanDuocHang.Size = new System.Drawing.Size(609, 600);
            this.dgv_DSNVKoBanDuocHang.TabIndex = 77;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Họ tên";
            this.FullName.Name = "FullName";
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            this.DateOfBirth.HeaderText = "Ngày sinh";
            this.DateOfBirth.Name = "DateOfBirth";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Ngày sinh";
            this.Address.Name = "Address";
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "Số điện thoại";
            this.PhoneNumber.Name = "PhoneNumber";
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "Vị trí";
            this.Position.Name = "Position";
            // 
            // Salary
            // 
            this.Salary.DataPropertyName = "Salary";
            this.Salary.HeaderText = "Lương";
            this.Salary.Name = "Salary";
            // 
            // FullName2
            // 
            this.FullName2.DataPropertyName = "FullName";
            this.FullName2.HeaderText = "Họ tên";
            this.FullName2.Name = "FullName2";
            this.FullName2.Width = 150;
            // 
            // Quantity2
            // 
            this.Quantity2.DataPropertyName = "Quantity";
            this.Quantity2.HeaderText = "Số lượng mặt hàng đã bán";
            this.Quantity2.Name = "Quantity2";
            // 
            // Address2
            // 
            this.Address2.DataPropertyName = "Address";
            this.Address2.HeaderText = "Địa chỉ";
            this.Address2.Name = "Address2";
            // 
            // PhoneNumber2
            // 
            this.PhoneNumber2.DataPropertyName = "PhoneNumber";
            this.PhoneNumber2.HeaderText = "Số điện thoại";
            this.PhoneNumber2.Name = "PhoneNumber2";
            // 
            // Position2
            // 
            this.Position2.DataPropertyName = "Position";
            this.Position2.HeaderText = "Chức vụ";
            this.Position2.Name = "Position2";
            // 
            // Salary2
            // 
            this.Salary2.DataPropertyName = "Salary";
            this.Salary2.HeaderText = "Lương";
            this.Salary2.Name = "Salary2";
            // 
            // NhanVienManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1449, 828);
            this.Controls.Add(this.dgv_DSNVKoBanDuocHang);
            this.Controls.Add(this.dgvTopNVBanDuocNhieuHang);
            this.Controls.Add(this.cbbBranch_2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnReload2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateEnd_TopNVKoBanDuoc);
            this.Controls.Add(this.dateStart_TopNVKoBanDuoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbBranch_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReload1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateEnd_TopNVBanNhieuHang);
            this.Controls.Add(this.dateStart_TopNVBanNhieuHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.pbExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NhanVienManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhanVienKhongBanDuocHangForm";
            this.Load += new System.EventHandler(this.NhanVienKhongBanDuocHangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopNVBanDuocNhieuHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSNVKoBanDuocHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReload1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateEnd_TopNVBanNhieuHang;
        private System.Windows.Forms.DateTimePicker dateStart_TopNVBanNhieuHang;
        private System.Windows.Forms.ComboBox cbbBranch_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbBranch_2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReload2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateEnd_TopNVKoBanDuoc;
        private System.Windows.Forms.DateTimePicker dateStart_TopNVKoBanDuoc;
        private System.Windows.Forms.DataGridView dgvTopNVBanDuocNhieuHang;
        private System.Windows.Forms.DataGridView dgv_DSNVKoBanDuocHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary2;
    }
}