namespace CSCScheduler
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteScheduleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todoHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.finishCheckBox = new System.Windows.Forms.CheckBox();
            this.limitDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.limitLabel = new System.Windows.Forms.Label();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.listLabel = new System.Windows.Forms.Label();
            this.dataLabel = new System.Windows.Forms.Label();
            this.scheduleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scheduleListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMenuItem,
            this.exportMenuItem,
            this.toolStripSeparator1,
            this.deleteScheduleMenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(86, 23);
            this.fileMenuItem.Text = "ファイル(&F)";
            // 
            // importMenuItem
            // 
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.Size = new System.Drawing.Size(186, 24);
            this.importMenuItem.Text = "インポート(&I)";
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.Size = new System.Drawing.Size(186, 24);
            this.exportMenuItem.Text = "エクスポート(&E)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // deleteScheduleMenuItem
            // 
            this.deleteScheduleMenuItem.Name = "deleteScheduleMenuItem";
            this.deleteScheduleMenuItem.Size = new System.Drawing.Size(186, 24);
            this.deleteScheduleMenuItem.Text = "リストから削除(&D)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(186, 24);
            this.exitMenuItem.Text = "終了(&X)";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todoHelpMenuItem,
            this.versionMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(81, 23);
            this.helpMenuItem.Text = "ヘルプ(&H)";
            // 
            // todoHelpMenuItem
            // 
            this.todoHelpMenuItem.Name = "todoHelpMenuItem";
            this.todoHelpMenuItem.Size = new System.Drawing.Size(245, 24);
            this.todoHelpMenuItem.Text = "CSCChedulerのヘルプ(&H)";
            // 
            // versionMenuItem
            // 
            this.versionMenuItem.Name = "versionMenuItem";
            this.versionMenuItem.Size = new System.Drawing.Size(210, 24);
            this.versionMenuItem.Text = "バージョン情報(&A)";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(535, 323);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 26;
            this.closeButton.Text = "終了";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(422, 323);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 25;
            this.deleteButton.Text = "削除";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(330, 323);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 24;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(334, 295);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(277, 15);
            this.errorLabel.TabIndex = 27;
            this.errorLabel.Text = "　　　　　　　　　　　　　　　　　　　　　　　　　　　";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(13, 323);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 18;
            this.newButton.Text = "新規";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // finishCheckBox
            // 
            this.finishCheckBox.AutoSize = true;
            this.finishCheckBox.Location = new System.Drawing.Point(541, 267);
            this.finishCheckBox.Name = "finishCheckBox";
            this.finishCheckBox.Size = new System.Drawing.Size(57, 19);
            this.finishCheckBox.TabIndex = 23;
            this.finishCheckBox.Text = "済み";
            this.finishCheckBox.UseVisualStyleBackColor = true;
            // 
            // limitDateTimePicker
            // 
            this.limitDateTimePicker.Location = new System.Drawing.Point(378, 263);
            this.limitDateTimePicker.Name = "limitDateTimePicker";
            this.limitDateTimePicker.Size = new System.Drawing.Size(157, 22);
            this.limitDateTimePicker.TabIndex = 21;
            // 
            // limitLabel
            // 
            this.limitLabel.AutoSize = true;
            this.limitLabel.Location = new System.Drawing.Point(327, 267);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(45, 15);
            this.limitLabel.TabIndex = 22;
            this.limitLabel.Text = "期限：";
            // 
            // dataTextBox
            // 
            this.dataTextBox.Location = new System.Drawing.Point(331, 100);
            this.dataTextBox.Multiline = true;
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataTextBox.Size = new System.Drawing.Size(267, 156);
            this.dataTextBox.TabIndex = 20;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(392, 48);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(208, 22);
            this.titleTextBox.TabIndex = 19;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(327, 48);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(59, 15);
            this.titleLabel.TabIndex = 17;
            this.titleLabel.Text = "タイトル：";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(13, 100);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(293, 214);
            this.listBox.TabIndex = 16;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(231, 45);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 15;
            this.clearButton.Text = "クリア";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(150, 45);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(13, 45);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(131, 22);
            this.searchTextBox.TabIndex = 13;
            // 
            // listLabel
            // 
            this.listLabel.AutoSize = true;
            this.listLabel.Location = new System.Drawing.Point(12, 82);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(106, 15);
            this.listLabel.TabIndex = 29;
            this.listLabel.Text = "スケジュール一覧";
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(327, 82);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(37, 15);
            this.dataLabel.TabIndex = 30;
            this.dataLabel.Text = "詳細";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 353);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.listLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.finishCheckBox);
            this.Controls.Add(this.limitDateTimePicker);
            this.Controls.Add(this.limitLabel);
            this.Controls.Add(this.dataTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "Form1";
            this.Text = "CSCScheduler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteScheduleMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todoHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionMenuItem;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox finishCheckBox;
        private System.Windows.Forms.DateTimePicker limitDateTimePicker;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.TextBox dataTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.BindingSource scheduleBindingSource;
        private System.Windows.Forms.BindingSource scheduleListBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

