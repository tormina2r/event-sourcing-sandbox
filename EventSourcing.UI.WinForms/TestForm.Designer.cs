namespace EventSourcing.UI.WinForms
{
    partial class TestForm
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
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.gbEvents = new System.Windows.Forms.GroupBox();
            this.gbCommands = new System.Windows.Forms.GroupBox();
            this.btnAddPersonCommand = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.gbEvents.SuspendLayout();
            this.gbCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.Location = new System.Drawing.Point(8, 21);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.Size = new System.Drawing.Size(768, 180);
            this.dgvEvents.TabIndex = 0;
            // 
            // gbEvents
            // 
            this.gbEvents.Controls.Add(this.dgvEvents);
            this.gbEvents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbEvents.Location = new System.Drawing.Point(8, 233);
            this.gbEvents.Name = "gbEvents";
            this.gbEvents.Padding = new System.Windows.Forms.Padding(8);
            this.gbEvents.Size = new System.Drawing.Size(784, 209);
            this.gbEvents.TabIndex = 1;
            this.gbEvents.TabStop = false;
            this.gbEvents.Text = "Events";
            // 
            // gbCommands
            // 
            this.gbCommands.Controls.Add(this.btnAddPersonCommand);
            this.gbCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCommands.Location = new System.Drawing.Point(8, 8);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.Size = new System.Drawing.Size(784, 225);
            this.gbCommands.TabIndex = 2;
            this.gbCommands.TabStop = false;
            this.gbCommands.Text = "Commands";
            // 
            // btnAddPersonCommand
            // 
            this.btnAddPersonCommand.Location = new System.Drawing.Point(8, 19);
            this.btnAddPersonCommand.Name = "btnAddPersonCommand";
            this.btnAddPersonCommand.Size = new System.Drawing.Size(166, 23);
            this.btnAddPersonCommand.TabIndex = 0;
            this.btnAddPersonCommand.Text = "Add new person";
            this.btnAddPersonCommand.UseVisualStyleBackColor = true;
            this.btnAddPersonCommand.Click += new System.EventHandler(this.btnAddPersonCommand_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(8, 230);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(784, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.gbCommands);
            this.Controls.Add(this.gbEvents);
            this.Name = "TestForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.gbEvents.ResumeLayout(false);
            this.gbCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.GroupBox gbEvents;
        private System.Windows.Forms.GroupBox gbCommands;
        private System.Windows.Forms.Button btnAddPersonCommand;
        private System.Windows.Forms.Splitter splitter1;
    }
}

